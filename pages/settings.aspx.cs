using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.master_pages
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checking if user is logged
            if (!Autorization.CheckAutorization())
            {
                Response.Redirect("../pages/logout.aspx");
            }

            //adding user data
            if (!IsPostBack)
            {
                Accounts acc = (Accounts)Session["Account"]; //user info
                Username.InnerText = acc.Username;
                FirstName.InnerText = acc.First_name;
                LastName.InnerText = acc.Last_name;
                Email.InnerText = acc.Email.Substring(4) + "****";
                RegistrationDate.InnerText = acc.Registration_date.ToString("dd/MM/yyyy");
                DatePurchase.InnerText = "Null"; //DIDNT ADD
                PurchasedFor.InnerText = "0"; //DIDNT ADD
            }
        }

        //getting used email
        [WebMethod]
        public static string GetCurrentEmail()
        {
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            return acc.Email;
        }

        //checking if same password
        [WebMethod]
        public static bool GetCurrentPassword(string pass)
        {
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            return (Security.HashFull(pass) == acc.Password);
        }

        //checking if email is used
        [WebMethod]
        public static bool IsEmailUsed(string email)
        {
            bool used = false;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `accounts` WHERE email = @email");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@email", email);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    used = true;
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
            return used;
        }

        //update email to the database
        [WebMethod]
        public static void UpdateEmail(string newEmail)
        {
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            acc.Email = newEmail;
        }

        //update password to the database
        [WebMethod]
        public static void UpdatePassword(string newPassowrd)
        {
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            acc.Password = Security.HashFull(newPassowrd);
        }

        //send email if forgot password
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

            if (id != Autorization.SessionId)
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