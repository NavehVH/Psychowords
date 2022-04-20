using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using Psychometric.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.master_pages
{
    public partial class WebForm6x : System.Web.UI.Page
    {

        public DataTable DefenitionsTable;
        public DataTable AssociationsTable;
        public DataTable ExamplesTable;
        public DataTable Last10Words;

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
                    CategoryDropList.Items.Add(new ListItem { Text = r[2].ToString(), Value = r[0].ToString() });
                }

                if (Session["UseCategory"].ToString() == "true")
                {
                    CategoryAgain.Checked = true;

                    if (Session["UsedCategoryIndexCurrent"] != null)
                        CategoryDropList.SelectedValue = Session["UsedCategoryIndexCurrent"].ToString();
                    else
                        CategoryDropList.SelectedValue = Session["UsedCategoryIndex"].ToString();
                }
                else
                {
                    CategoryAgain.Checked = false;
                    CategoryDropList.SelectedValue = "0";
                }

                DefenitionsTable = GetTableByTextBox("definitions");
                AssociationsTable = GetTableByTextBox("associations");
                ExamplesTable = GetTableByTextBox("examples");
            }
            Last10Words = GetLast10Words("words");
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
        public static void AddAllLikes(int id, int type)
        {
            if (type == 1)
            {
                Definitions liked = new Definitions(id);

                Definitions newD = new Definitions();
                newD.Username_id = Autorization.SessionId;
                newD.Word_id = Words.GetLastInsertedId();
                newD.Definition = liked.Definition;
                newD.Registration_date = DateTime.UtcNow;
                newD.Ghosted = false;
                newD.Liked_id = liked.Id;
                newD.AddDefinition();
            }
            if (type == 2)
            {
                Examples liked = new Examples(id);

                Examples newE = new Examples();
                newE.Username_id = Autorization.SessionId;
                newE.Word_id = Words.GetLastInsertedId();
                newE.Example = liked.Example;
                newE.Registration_date = DateTime.UtcNow;
                newE.Ghosted = false;
                newE.Liked_id = liked.Id;
                newE.AddExample();
            }
            if (type == 3)
            {
                Associations liked = new Associations(id);

                Associations ass = new Associations();
                ass.Username_id = Autorization.SessionId;
                ass.Word_id = Words.GetLastInsertedId();
                ass.Association = liked.Association;
                ass.Registration_date = DateTime.UtcNow;
                ass.Ghosted = false;
                ass.Liked_id = liked.id;
                ass.AddAssociation();
            }
        }

        //ריראיראירא
        protected void WordTextBox_TextChanged(object sender, EventArgs e)
        {
            WordLabel.Text = WordTextBox.Text;
            HideTextBoxText();
            FoundLabel1.Text = "";
            FoundLabel2.Text = "";
            FoundLabel3.Text = "";

            if (WordTextBox.Text == "")
                return;

            Words w = new Words(WordTextBox.Text);
            if (!w.Exists())
            {
                DefenitionsTable = GetTableByTextBox("definitions");
                AssociationsTable = GetTableByTextBox("associations");
                ExamplesTable = GetTableByTextBox("examples");
                FoundLabel1.Text = "(לא נמצאו פירושים)";
                FoundLabel2.Text = "(לא נמצאו דוגמאות)";
                FoundLabel3.Text = "(לא נמצאו אסוציאציות)";
                WordAddingPanel.Update();
            }
            else
            {
                DefenitionsTable = GetTableByTextBox("definitions");
                if (DefenitionsTable.Rows.Count == 0)
                    FoundLabel1.Text = "(לא נמצאו פירושים)";
                ExamplesTable = GetTableByTextBox("examples");
                if (ExamplesTable.Rows.Count == 0)
                    FoundLabel2.Text = "(לא נמצאו דוגמאות)";
                AssociationsTable = GetTableByTextBox("associations");
                if (AssociationsTable.Rows.Count == 0)
                    FoundLabel3.Text = "(לא נמצאו אסוציאציות)";
                WordAddingPanel.Update();
            }
        }

        public DataTable GetTableByTextBox(string table)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT ass.*, a.total, w.`language`
FROM " + table + @" ass
INNER JOIN words w
        ON ass.word_id = w.id AND w.`language` = 'english'
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM " + table + @" a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE w.word = @type AND ass.liked_Id = 0 ORDER BY a.liked_id DESC LIMIT 0, 50",
    c.Con);
                msc.Parameters.AddWithValue("@type", WordTextBox.Text);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        private void HideTextBoxText()
        {
            TextBox box;
            bool visible = false;
            foreach (Control ctr in TextboxPanel.Controls)
            {
                if (ctr is TextBox)
                {
                    box = (TextBox)ctr;
                    if (box.Text != "")
                    {
                        visible = true;
                        box.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                    else
                    {
                        box.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }
            }
            if (!visible)
                FirstBox1.Style.Add(HtmlTextWriterStyle.Display, "block");
            visible = false;
            foreach (Control ctr in TextboxPanelExamples.Controls)
            {
                if (ctr is TextBox)
                {
                    box = (TextBox)ctr;
                    if (box.Text != "")
                    {
                        visible = true;
                        box.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                    else
                    {
                        box.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }
            }
            if (!visible)
                FirstBox2.Style.Add(HtmlTextWriterStyle.Display, "block");
            visible = false;
            foreach (Control ctr in TextboxPanelAssociations.Controls)
            {
                if (ctr is TextBox)
                {
                    box = (TextBox)ctr;
                    if (box.Text != "")
                    {
                        visible = true;
                        box.Style.Add(HtmlTextWriterStyle.Display, "block");
                    }
                    else
                    {
                        box.Style.Add(HtmlTextWriterStyle.Display, "none");
                    }
                }
            }
            if (!visible)
                FirstBox3.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        public int GetTypeLikesCount(int id, string table)
        {
            int count = 0;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT COUNT(*) FROM " + table + " WHERE liked_id = @liked_id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@liked_id", id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    count = r.GetInt32(0);
                }
                r.Close();
            }
            finally
            {
                con.conClose();
            }
            return count;
        }

        [WebMethod]
        public static void AddWord(string WordTextBox, int lastCategoryIndex, string[] definitions, string[] examples, string[] associations)
        {
            //Add word
            Words word = new Words();
            word.Username_id = Autorization.SessionId;
            word.Word = WordTextBox;
            word.Knowledge = 0;
            word.Category_id = lastCategoryIndex;
            word.Registration_date = DateTime.UtcNow;
            word.Language = "english";
            word.Ghosted = false;
            word.Liked_id = 0;
            word.AddWord();

            //Add definitions
            foreach (string def in definitions)
            {
                Definitions definition = new Definitions();
                definition.Username_id = Autorization.SessionId;
                definition.Word_id = word.Id;
                definition.Definition = def;
                definition.Ghosted = false;
                definition.Registration_date = DateTime.UtcNow;
                definition.AddDefinition();
            }

            //Add examples
            foreach (string exa in examples)
            {
                Examples example = new Examples();
                example.Username_id = Autorization.SessionId;
                example.Word_id = word.Id;
                example.Example = exa;
                example.Ghosted = false;
                example.Registration_date = DateTime.UtcNow;
                example.AddExample();
            }

            //Add association
            foreach (string ass in associations)
            {
                Associations association = new Associations();
                association.Username_id = Autorization.SessionId;
                association.Word_id = word.Id;
                association.Association = ass;
                association.Ghosted = false;
                association.Registration_date = DateTime.UtcNow;
                association.AddAssociation();
            }

            //Add cookie of last category
            HttpCookie cookie = Autorization.NewCookieData();

            HttpCookie cookieOld = new HttpCookie("PsychometricCookies");
            cookieOld.Expires = DateTime.UtcNow.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookieOld);

            cookie["UsedCategoryIndex"] = lastCategoryIndex.ToString();
            HttpContext.Current.Session["UsedCategoryIndexCurrent"] = lastCategoryIndex;

            cookie.Expires = DateTime.UtcNow.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public DataTable GetLast10Words(string table)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM words WHERE username_id = @username_Id AND `language` = 'english' ORDER BY id DESC LIMIT 10;", c.Con);
                msc.Parameters.AddWithValue("@username_id", Autorization.SessionId);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        protected void SaveSettings_ServerClick(object sender, EventArgs e)
        {
            //Add cookie of last category
            HttpCookie cookie = Autorization.NewCookieData();

            HttpCookie cookieOld = new HttpCookie("PsychometricCookies");
            cookieOld.Expires = DateTime.UtcNow.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookieOld);

            if (CategoryAgain.Checked)
                cookie["UseCategory"] = "true";
            else
                cookie["UseCategory"] = "false";

            cookie.Expires = DateTime.UtcNow.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
            Response.Redirect("../english/add-word.aspx");
        }

        [WebMethod]
        public static int GetWordIdByNameAjax(string word)
        {
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            return acc.GetWordIdByName(word);
        }
    }
}