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
    public partial class WebForm3x : System.Web.UI.Page
    {
        public string[][] MyData = null;
        public List<List<List<string>>> WordData = new List<List<List<string>>>();

        public int OptionsNumber = 0;

        public string Interval = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                trainButton.Visible = false;

                memorizationDiv.Visible = false;
                if (!Autorization.CheckAutorization())
                {
                    Response.Redirect("../pages/logout.aspx");
                }

                DataTable Categories = SetAllCategories();
                foreach (DataRow r in Categories.Rows)
                {
                    CategoryDropDownList.Items.Add(new ListItem { Text = r[2].ToString(), Value = r[0].ToString() });
                }

                IntervalDropDownList.SelectedValue = Session["Interval"].ToString();
                WordsDropList.SelectedValue = Session["WordsCount"].ToString();
                CategoryDropDownList.SelectedValue = Session["CategoryToMemory"].ToString();
                ShowExample.Checked = bool.Parse(Session["ShowExamples"].ToString());
                ShowAssociation.Checked = bool.Parse(Session["ShowAssociations"].ToString());
            }
            Interval = Session["Interval"].ToString();
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

        protected void SaveInfoButton_ServerClick(object sender, EventArgs e)
        {
            HttpCookie cookie = Autorization.NewCookieData();

            HttpCookie cookieOld = new HttpCookie("PsychometricCookies");
            cookieOld.Expires = DateTime.UtcNow.AddDays(-1);
            Response.Cookies.Add(cookieOld);

            cookie["WordsCount"] = WordsDropList.SelectedValue.ToString();
            cookie["CategoryToMemory"] = CategoryDropDownList.SelectedValue.ToString();
            cookie["ShowExamples"] = ShowExample.Checked.ToString();
            cookie["ShowAssociations"] = ShowAssociation.Checked.ToString();
            cookie["Interval"] = IntervalDropDownList.SelectedValue.ToString();

            cookie.Expires = DateTime.UtcNow.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        [WebMethod]
        public string[][] GetData(int optionsNum, string category)
        {
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
                msc.Parameters.AddWithValue("@username_id", Session["Id"].ToString());
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

        protected void sessionButton_ServerClick(object sender, EventArgs e)
        {
            if (MyData == null)
            {
                OptionsNumber = int.Parse(WordsDropList.SelectedValue.ToString()); //Edit this later ~.~
                MyData = GetData(OptionsNumber, CategoryDropDownList.SelectedValue.ToString());

                if (MyData.Length < 2) //Not enough words
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('אין לך מספיק מילים בקטגוריה זו, צריך מינימום של " + OptionsNumber + " מילים.');", true);
                    return;
                }

                WordData.Add(new List<List<string>>()); //def
                WordData.Add(new List<List<string>>()); //exa
                WordData.Add(new List<List<string>>()); //ass
                for (int i = 0; i < MyData[0].Length; i++)
                {
                    WordData[0].Add(SqlHelper.GetInfoByWord(int.Parse(MyData[0][i]), "definitions")); //def
                    WordData[1].Add(SqlHelper.GetInfoByWord(int.Parse(MyData[0][i]), "examples")); //exa
                    WordData[2].Add(SqlHelper.GetInfoByWord(int.Parse(MyData[0][i]), "associations")); //ass
                }
                memorizationDiv.Visible = true;
                sessionButton.Visible = false;
                trainButton.Visible = true;
                SettingButton.Visible = false;

                if (IntervalDropDownList.SelectedValue != "false")
                {
                    FlipCardButton.Visible = false;
                    NextButton.Visible = false;
                    PrevButton.Visible = false;
                }
                HttpContext.Current.Session["Memory"] = MyData;
            }
        }

        protected void trainButton_ServerClick(object sender, EventArgs e)
        {
            HttpContext.Current.Session["MemoryBool"] = true;
            Response.Redirect("../english/questions.aspx");
        }
    }
}