using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.master_pages
{
    public partial class WebForm2x : System.Web.UI.Page
    {

        public static string[][] MyData = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Autorization.CheckAutorization())
                {
                    Response.Redirect("../pages/logout.aspx");
                }

                DataTable Categories = SetAllCategories();
                foreach (DataRow r in Categories.Rows)
                {
                    CategoryDropDownList.Items.Add(new ListItem { Text = r[2].ToString(), Value = r[0].ToString() });
                }

                AnswersDropDownList.SelectedValue = Session["AnswerOptions"].ToString();
                CategoryDropDownList.SelectedValue = Session["CategoryToTrain"].ToString();

                if (HttpContext.Current.Session["MemoryBool"] != null)
                {
                    bool isTraining = bool.Parse(HttpContext.Current.Session["MemoryBool"].ToString());
                    if (isTraining)
                    {
                        TitlePage.InnerText = "התחל תרגול (תרגול רנדומלי על המילים שעברת)";
                        MemorySession.Value = "true";
                        MyData = (string[][])HttpContext.Current.Session["Memory"];
                        HttpContext.Current.Session["MemoryBool"] = false;
                    }
                    else
                    {
                        MyData = null;
                    }
                }
            }
        }

        private DataTable SetAllCategories()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE username_id = @username_id;", c.Con);
                msc.Parameters.AddWithValue("@username_id", Session["Id"]);
                DataSet ds = c.getDataSet(msc, "categories");
                dt = ds.Tables["categories"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        [WebMethod]
        public static string[][] GetData(int optionsNum, string category)
        {
            if (MyData != null)
            {
                return MyData;
            }

            string[][] dataArray = new string[3][];
            dataArray[0] = new string[optionsNum]; //id
            dataArray[1] = new string[optionsNum]; //word
            dataArray[2] = new string[optionsNum]; //definition
            int rIndex = 0;

            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc;

                if (category == "o1")
                    msc = new MySqlCommand("SELECT SQL_NO_CACHE * FROM `words` WHERE username_id = @username_id AND `language` = 'english' ORDER BY RAND() LIMIT @limit");
                else if (category == "o2")
                    msc = new MySqlCommand("SELECT SQL_NO_CACHE * FROM `words` WHERE username_id = @username_id AND `language` = 'english' AND knowledge = 3 ORDER BY RAND() LIMIT @limit");
                else if (category == "o3")
                    msc = new MySqlCommand("SELECT SQL_NO_CACHE * FROM `words` WHERE username_id = @username_id AND `language` = 'english' AND knowledge = 2 ORDER BY RAND() LIMIT @limit");
                else if (category == "o4")
                    msc = new MySqlCommand("SELECT SQL_NO_CACHE * FROM `words` WHERE username_id = @username_id AND `language` = 'english' AND knowledge = 1 ORDER BY RAND() LIMIT @limit");
                else if (category == "o5")
                    msc = new MySqlCommand("SELECT SQL_NO_CACHE * FROM `words` WHERE username_id = @username_id AND `language` = 'english' AND knowledge = 0 ORDER BY RAND() LIMIT @limit");
                else
                {
                    msc = new MySqlCommand("SELECT SQL_NO_CACHE * FROM `words` WHERE username_id = @username_id AND `language` = 'english' AND category_id = @category_id ORDER BY RAND() LIMIT @limit");
                    msc.Parameters.AddWithValue("@category_id", int.Parse(category));
                }

                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@username_id", Autorization.SessionId);
                msc.Parameters.AddWithValue("@limit", optionsNum);
                MySqlDataReader r = msc.ExecuteReader();
                Random rnd = new Random();
                List<string> defs = null;
                rIndex = 0;
                while (r.Read())
                {
                    dataArray[0][rIndex] = r.GetInt32(0).ToString();
                    dataArray[1][rIndex] = r.GetString(2);
                    defs = SqlHelper.GetInfoByWord(int.Parse(dataArray[0][rIndex]), "definitions");
                    dataArray[2][rIndex] = defs[rnd.Next(defs.Count)];
                    //Debug.WriteLine(defs.Count + ", " + rnd.Next(defs.Count));
                    //if (defs.Count == 0)
                    //    Debug.WriteLine(dataArray[0][rIndex].ToString());
                    rIndex++;
                }
            }
            finally
            {
                con.conClose();
            }

            if (rIndex != optionsNum)
                return new string[1][];
            return dataArray;
        }

        protected void SaveInfoButton_ServerClick(object sender, EventArgs e)
        {
            HttpCookie cookie = Autorization.NewCookieData();

            HttpCookie cookieOld = new HttpCookie("PsychometricCookies");
            cookieOld.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(cookieOld);

            cookie["AnswerOptions"] = AnswersDropDownList.SelectedValue.ToString();
            cookie["CategoryToTrain"] = CategoryDropDownList.SelectedValue.ToString();

            cookie.Expires = DateTime.UtcNow.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}