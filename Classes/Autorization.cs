using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{
    public class Autorization
    {

        public static Accounts SessionAccount;
        public static int SessionId;
        public static string SessionUsername;

        public static bool CheckAutorization()
        {
            bool registered = false;
            CheckCookies();
            if (HttpContext.Current.Session["Id"] != null)
                if (HttpContext.Current.Session["Id"].ToString() != "0")
                    registered = true;

            if (registered)
            {
                SessionAccount = new Accounts(int.Parse(HttpContext.Current.Session["Id"].ToString()));
                SessionId = SessionAccount.Id;
                SessionUsername = SessionAccount.Username;
                return true;
            } else
            {
                SessionAccount = null;
                SessionId = 0;
                SessionUsername = null;
                return false;
            }

        }

        private static void CheckCookies()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["PsychometricCookies"];
            if (cookie != null)
            {
                //Account
                HttpContext.Current.Session["Account"] = new Accounts(int.Parse(cookie["Id"]));
                HttpContext.Current.Session["Id"] = cookie["Id"];
                HttpContext.Current.Session["Username"] = cookie["Username"];
                //Training info
                HttpContext.Current.Session["AnswerOptions"] = cookie["AnswerOptions"];
                HttpContext.Current.Session["CategoryToTrain"] = cookie["CategoryToTrain"];

                //Memory
                HttpContext.Current.Session["WordsCount"] = cookie["WordsCount"];
                HttpContext.Current.Session["CategoryToMemory"] = cookie["CategoryToMemory"];
                HttpContext.Current.Session["ShowExamples"] = cookie["ShowExamples"];
                HttpContext.Current.Session["ShowAssociations"] = cookie["ShowAssociations"];

                //AddWord
                HttpContext.Current.Session["UseCategory"] = cookie["UseCategory"];
                HttpContext.Current.Session["UsedCategoryIndex"] = cookie["UsedCategoryIndex"];

                //Memorization
                HttpContext.Current.Session["Interval"] = cookie["Interval"];
            }
            else
            {
            }
        }

        public static string Cookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["PsychometricCookies"];
            if (cookie != null)
                return cookie[name];
            return "";
        }

        public static bool ChangeVerification(string username, string code)
        {
            Accounts acc = new Accounts(username, code, true);
            if (acc.Id != 0)
            {
                if (acc.Verification != "1")
                {
                    acc.Verification = "1";
                    return true;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Login(string username, string password)
        {
            Accounts acc = new Accounts(username, password, false);
            if (acc.Id != 0)
            {
                HttpCookie cookie = new HttpCookie("PsychometricCookies");
                //Account
                cookie["Id"] = acc.Id.ToString();
                cookie["Username"] = acc.Username.ToString();


                //Training info
                cookie["AnswerOptions"] = "4";
                cookie["CategoryToTrain"] = "1";

                //Memory
                cookie["WordsCount"] = "8";
                cookie["CategoryToMemory"] = "1";
                cookie["ShowExamples"] = "true";
                cookie["ShowAssociations"] = "true";

                //AddWord
                cookie["UseCategory"] = "true";
                cookie["UsedCategoryIndex"] = "0";

                //Memorization
                cookie["Interval"] = "false";

                cookie.Expires = DateTime.UtcNow.AddDays(30);
                HttpContext.Current.Response.Cookies.Add(cookie);
                HttpContext.Current.Session["Account"] = new Accounts(acc.Id);
                HttpContext.Current.Session["Id"] = acc.Id;
                HttpContext.Current.Session["Username"] = acc.Username;

                acc.Last_login_date = DateTime.UtcNow;
                acc.Last_ip = Security.HashFull(Security.GET_IP_ADDRESS);

                return true;
            }
            else
            {
                return false;
            }
        }

        public static HttpCookie NewCookieData()
        {
            HttpCookie newCookie = null;
            HttpCookie cookie = HttpContext.Current.Request.Cookies["PsychometricCookies"];
            if (cookie != null)
            {
                newCookie = new HttpCookie("PsychometricCookies");
                newCookie["Id"] = SessionId.ToString();
                newCookie["Username"] = SessionUsername;


                //Training info
                newCookie["AnswerOptions"] = cookie["AnswerOptions"];
                newCookie["CategoryToTrain"] = cookie["CategoryToTrain"];

                //Memory
                newCookie["WordsCount"] = cookie["WordsCount"];
                newCookie["CategoryToMemory"] = cookie["CategoryToMemory"];
                newCookie["ShowExamples"] = cookie["ShowExamples"];
                newCookie["ShowAssociations"] = cookie["ShowAssociations"];

                //AddWord
                newCookie["UseCategory"] = cookie["UseCategory"];
                newCookie["UsedCategoryIndex"] = cookie["UsedCategoryIndex"];

                //Memorization
                newCookie["Interval"] = cookie["Interval"];
            }
            return newCookie;
        }
    }
}