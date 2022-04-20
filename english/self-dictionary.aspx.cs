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
    public partial class WebForm4x : System.Web.UI.Page
    {

        int allWords, knownWords, almostKnownWords, unknownWords, wordsLiked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCount();
            }
        }

        protected void AddCategoryButton(object sender, EventArgs e)
        {
            Categories c = new Categories();
            c.Username_id = int.Parse(Session["Id"].ToString());
            c.Category_name = CategoryTextBox.Text;
            c.Registration_date = DateTime.UtcNow;
            c.AddCategory();
            CategoryTextBox.Text = "";
        }

        public DataTable GetUserCategories()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE `username_id` = @username_id", c.Con);
                msc.Parameters.AddWithValue("@username_id", int.Parse(Session["Id"].ToString()));
                DataSet ds = c.getDataSet(msc, "categories");
                dt = ds.Tables["categories"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public int GetCategoryCount(int categoryId)
        {
            int count = 0;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT COUNT(*) FROM `words` WHERE category_id = @category_id AND username_id = @username_id AND `language` = 'english'");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@category_id", categoryId);
                msc.Parameters.AddWithValue("@username_id", Session["Id"]);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    count = r.GetInt32(0);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
            return count;
        }

        [WebMethod]
        public static string DeleteButton(int id)
        {
            Categories c = new Categories(id);
            c.DeleteCategory();
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand cm = new MySqlCommand("UPDATE `words` SET category_id = 0 WHERE category_id = @category_id");
                cm.Parameters.AddWithValue("@category_id", id);
                cm.Connection = con.Con;
                cm.ExecuteNonQuery();
            }
            finally
            {
                con.conClose();
            }
            return "Done";
        }

        private void SetCount()
        {
            int id = 0;

            if (Session["Id"] != null)
            {
                id = int.Parse(Session["Id"].ToString());
            }

            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `language` = 'english';
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `knowledge` = 3 AND `language` = 'english';
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `knowledge` = 2 AND `language` = 'english';
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `knowledge` = 1 AND `language` = 'english';
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `liked_id` != 0 AND `language` = 'english';
");
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                    allWords = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    knownWords = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    almostKnownWords = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    unknownWords = r.GetInt32(0);
                r.NextResult();
                if (r.Read())
                    wordsLiked = r.GetInt32(0);

            }
            finally
            {
                con.conClose();
            }

            allWordsSpan.InnerText = allWords.ToString();
            knownWordsSpan.InnerText = knownWords.ToString();
            almostKnownWordsSpan.InnerText = almostKnownWords.ToString();
            unknownWordsSpan.InnerText = unknownWords.ToString();
            selfAddedSpan.InnerText = (allWords - wordsLiked).ToString();
            wordsLikedSpan.InnerText = wordsLiked.ToString();
        }
    }


}