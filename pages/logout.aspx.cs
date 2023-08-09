using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.pages
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Remove cookies, log out from the session and redirect to index page
                HttpCookie cookie = new HttpCookie("PsychometricCookies");


                cookie.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(cookie);
                Response.Cookies.Clear();

                Autorization.SessionAccount = null;
                Autorization.SessionId = 0;
                Autorization.SessionUsername = null;

                RemoveCookie("PsychometricCookies");
                //removing session and logging out
                Session.Abandon();
                Response.Redirect("../pages/login.aspx");
            }
        }

        //removing the website cookies
        public static void RemoveCookie(string cookieName)
        {
            if (HttpContext.Current.Response.Cookies[cookieName] != null)
            {
                HttpContext.Current.Response.Cookies[cookieName].Value = null;
                HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.UtcNow.AddMonths(-1);
            }
        }
    }
}