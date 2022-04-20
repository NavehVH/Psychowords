using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.pages
{
    public partial class verification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Autorization.CheckAutorization())
                {
                    Response.Redirect("../pages/login.aspx");
                }

                if (Session["EmailVer"] == null)
                {
                    Response.Redirect("../pages/login.aspx");
                }
            }

        }

        protected void ClickLogin(object sender, EventArgs e)
        {
            Accounts acc = new Accounts(UsernameTextBox.Text, CodeTextBox.Text, true);
            if (acc.Id != 0)
            {
                if (acc.Verification != "1")
                {
                    if (Autorization.ChangeVerification(UsernameTextBox.Text, CodeTextBox.Text))
                        Response.Redirect("../pages/login.aspx");
                    else
                    {
                        LabelError.Text = "משהו לא הסתדר, נסה שוב מאוחר יותר.";
                    }
                }
                else
                {
                    LabelError.Text = "המשתמש כבר מאומת, אתה יכול להתחבר למשתמש כרגיל.";
                }
            }
            else
            {
                LabelError.Text = "שם משתמש או קוד אימות לא נכונים.";
            }
        }

        protected void EmailButton_Click(object sender, EventArgs e)
        {
            if (Session["EmailVer"] != null)
            {
                Accounts acc = (Accounts)Session["EmailVer"];

                if (acc.Last_login_date.AddMinutes(5) > DateTime.UtcNow)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('המערכת שלחה לך אימייל ב5 דקות האחרונות. תוכל לנסות שוב לאחר שיעברו.');", true);
                    return;
                }

                Random rnd = new Random();
                int random = rnd.Next(1000000, 9999999);
                acc.Last_login_date = DateTime.UtcNow;
                acc.Last_ip = Security.HashFull(Security.GET_IP_ADDRESS); ;
                acc.Verification = random.ToString();

                string subject = @"
עשית בקשה לשליחת קוד אימות חדש לאימייל, הקוד החדש שלך הוא: " + acc.Verification + @".";

                Security.SendEmail(acc.Email, "Verification Code", subject);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('המערכת שלחה לך אימייל לכתובת של המשתמש: " + acc.Email + ".');", true);
            } else
            {
                Response.Redirect("../pages/login.aspx");
            }
        }
    }
}