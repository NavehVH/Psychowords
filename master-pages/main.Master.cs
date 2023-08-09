using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.master_pages
{
    public partial class Main : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if user is not logged, return him to login page, else session login
            if (!IsPostBack)
            {
                if (!Autorization.CheckAutorization())
                {
                    Response.Redirect("../pages/login.aspx");
                }


                usernameSpan.InnerText = Session["Username"].ToString();
            }
        }
    }
}