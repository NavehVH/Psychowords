using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if already logged, remove user from the login page
            if (!IsPostBack)
                if (Autorization.CheckAutorization())
                {
                    Response.Redirect("../index.aspx");
                }
        }

        //dealing with logging button
        protected void ClickLogin(object sender, EventArgs e)
        {
            Accounts acc = new Accounts(UsernameTextBox.Text, Security.HashFull(PasswordTextBox.Text), false);
            if (acc.Id == 0) //account doesn't exist
            {
                LabelError.Text = "שם משתמש או סיסמה לא נכונים.";
                return;
            }

            if (acc.Verification != "1") //checking if user verify their email
            {
                Session["EmailVer"] = acc;
                Response.Redirect("../pages/verification.aspx");
            }

            //logged
            if (Autorization.Login(UsernameTextBox.Text, Security.HashFull(PasswordTextBox.Text))) //checks if info is legin
                Response.Redirect("../index.aspx");
            else
                LabelError.Text = "שם משתמש או סיסמה לא נכונים.";
        }

        //sending email to deal if used the forgot pass button
        [WebMethod]
        public static bool ForgotPass_ServerClick(string username, string email)
        {
            int id = 0;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT id FROM `accounts` WHERE username = @username AND email = @email");
                msc.Parameters.AddWithValue("@username", username);
                msc.Parameters.AddWithValue("@email", email);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    id = r.GetInt32(0);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }

            if (id == 0)
                return false;

            Accounts acc = new Accounts(id);

            if (acc.Last_login_date.AddMinutes(5) > DateTime.UtcNow)
            {
                return false;
            }

            Random rnd = new Random();
            int random = rnd.Next(10000000, 99999999);
            acc.Last_login_date = DateTime.UtcNow;
            acc.Password = Security.HashFull(random.ToString());

            string subject = @"
עשית בקשה לשליחת סיסמה חדשה לאימייל, הסיסמה החדשה שלך היא: " + random.ToString() + @".";

            Security.SendEmail(acc.Email, "New Password", subject);
            return true;
        }
    }
}