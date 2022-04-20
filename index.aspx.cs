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

namespace Psychometric
{
    public partial class index : System.Web.UI.Page
    {
        int usersCount = 0, hebrewCount = 0, englishCount = 0, associationsCount = 0, examplesCount = 0, likesCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Autorization.CheckAutorization())
                {
                }
                SetCountInfo();
            }
        }

        private void SetCountInfo()
        {

            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT COUNT(id) FROM accounts;
SELECT COUNT(DISTINCT word) FROM words WHERE `language` = 'hebrew';
SELECT COUNT(DISTINCT word) FROM words WHERE `language` = 'english';
SELECT COUNT(id) FROM associations;
SELECT COUNT(id) FROM examples;
SELECT COUNT(id) FROM words WHERE liked_id != 0;
SELECT COUNT(id) FROM definitions WHERE liked_id != 0;
SELECT COUNT(id) FROM examples WHERE liked_id != 0;
SELECT COUNT(id) FROM associations WHERE liked_id != 0;
");
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                    usersCount = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    hebrewCount = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    englishCount = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    associationsCount = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    examplesCount = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    likesCount += r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    likesCount += r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    likesCount += r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    likesCount += r.GetInt32(0);
                r.Close();
            } finally
            {
                con.conClose();
            }

            //userCountSpan.InnerText = usersCount.ToString();
            hebrewCountSpan.InnerText = hebrewCount.ToString();
            englishCountSpan.InnerText = englishCount.ToString();
            associationsCountSpan.InnerText = associationsCount.ToString();
            examplesCountSpan.InnerText = examplesCount.ToString();
            likesCountSpan.InnerText = likesCount.ToString();
        }

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

        [WebMethod]
        public static bool IsUsernameUsed(string username)
        {
            bool used = false;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `accounts` WHERE username = @username");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@username", username);
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

        [WebMethod]
        public static bool RegisterAccountAjax(string username, string password, string email, string firstName, string lastName)
        {
            bool registered = false;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT id FROM accounts WHERE last_ip = @last_ip ORDER BY id DESC LIMIT 0, 1");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@last_ip", Security.HashFull(Security.GET_IP_ADDRESS));
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    Accounts lastAcc = new Accounts(r.GetInt32(0));
                    if (lastAcc.Registration_date.AddMinutes(5) > DateTime.UtcNow)
                        registered = true;
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }

            if (registered == true) //Registered in the last 5 mins
                return false;

            Accounts acc = new Accounts();
            acc.Username = username;
            acc.Password = Security.HashFull(password);
            acc.Email = email;
            acc.First_name = firstName;
            acc.Last_name = lastName;
            acc.Subscription_days = 0;
            acc.Admin = 0;
            acc.Ghosted = false;
            acc.Warnings = 0;
            acc.Banned = false;
            acc.Registration_date = DateTime.UtcNow;
            acc.Last_login_date = DateTime.UtcNow;
            acc.Trial = false;
            acc.Last_ip = Security.HashFull(Security.GET_IP_ADDRESS);;
            Random rnd = new Random();
            int random = rnd.Next(1000000, 9999999);
            acc.Verification = random.ToString();
            acc.AddAccount();

            string subject = @"
ברוך הבא לאתר, 
" + username + @"!

האתר כרגע נמצא בתקופת בטא עד להודעה חדשה, אז הכניסה היא חינם.
המטרה של האתר ליצור מאגר של מילים לפסיכומטרי לאנשים שיוכלו ללמוד בצורה נוחה, בצורה בה יוכלו לבחור איזה מילים לעבוד עליהם.
בכניסה הראשונית שלך תצטרך להכניס קוד אימות בשביל להתחבר. הקוד שלך הוא: " + random.ToString() + @".

כתובת האתר: http://psychowords.com 

יש לשים לב, זו אחריות המשתמש, לבדוק האם המילה\פירוש\דוגמה שהוא מכניס נכונה בעזרת מילונים\אינטרנט וכדומה.
האתר נועד ליצור כלי שיעזור ללמידה של המילים ואינו לקוח אחריות על נתונים לא נכונים שמתמשים אחרים הכניסו.
זוהי אחריות המשתמש בלבד לשים לב שהנתונים שלו נכונים.
";
            Security.SendEmail(email, "Welcome to Psychowords.com", subject);
            return true;
        }
    }
}