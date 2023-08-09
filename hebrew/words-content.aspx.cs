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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int IdShown = 0;

        public DataTable CurrentWordTable;

        public DataTable DefinitionsTable;
        public DataTable AssociationsTable;
        public DataTable ExamplesTable;

        public static string CurrentWord = "-";
        protected void Page_Load(object sender, EventArgs e)
        {
            string get = ""; //#TODO check its a number...
            if (Request.QueryString["type"] != null)
            {
                get = Request.QueryString["type"];

                if (get == "1")
                    CurrentWordTable = GetWordsByType("words", 1);
                if (get == "2")
                    CurrentWordTable = GetWordsByType("words", 2);
                if (get == "3")
                    CurrentWordTable = GetWordsByType("words", 3);
                if (get == "4")
                    CurrentWordTable = AllWordsTable();
                if (get == "5")
                    CurrentWordTable = AllWordsIAddedTable(); //#TODO make it work
                if (get == "6")
                    CurrentWordTable = AllLikedWordsTable();
            }
            else if (Request.QueryString["category"] != null)
            {
                get = Request.QueryString["category"];
                CurrentWordTable = GetWordsByCategory("words", int.Parse(get));
            }
            else
            {
                Response.Redirect("../hebrew/self-dictionary.aspx");
            }

            if (CurrentWordTable != null && CurrentWordTable.Rows.Count != 0)
            {
                allWordsSpan.InnerText = CurrentWordTable.Rows.Count.ToString();

                if (!IsPostBack)
                {
                    IdShown = int.Parse(CurrentWordTable.Rows[0][0].ToString());
                    //UpdateSuggestionTables(CurrentWordTable.Rows[0][2].ToString());
                    Tab4.Visible = false;
                    Tab5.Visible = false;
                    Tab6.Visible = false;

                    DataTable Categories = SetAllCategories();
                    foreach (DataRow r in Categories.Rows)
                    {
                        CategoryDropDownList.Items.Add(new ListItem { Text = r[2].ToString(), Value = r[0].ToString() });
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

        protected void UpdateAss(object sender, EventArgs e)
        {
            AssociationsTable = GetTypeBySearch(CurrentWord, "associations");

            Tab4.Visible = true;
            Tab5.Visible = false;
            Tab6.Visible = false;
            DefinitionsPanel.Update();
        }

        protected void UpdateExa(object sender, EventArgs e)
        {
            ExamplesTable = GetTypeBySearch(CurrentWord, "examples");

            Tab4.Visible = false;
            Tab5.Visible = true;
            Tab6.Visible = false;
            DefinitionsPanel.Update();
        }

        protected void UpdateDef(object sender, EventArgs e)
        {
            DefinitionsTable = GetTypeBySearch(CurrentWord, "definitions");

            Tab4.Visible = false;
            Tab5.Visible = false;
            Tab6.Visible = true;
            DefinitionsPanel.Update();
        }

        public DataTable AllWordsTable()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM words WHERE `username_id` = " + Autorization.SessionId + " AND `language` = 'hebrew'", c.Con);
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public DataTable AllLikedWordsTable()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM words WHERE `username_id` = " + Autorization.SessionId + " AND `liked_id` != 0 AND `language` = 'hebrew'", c.Con);
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public DataTable AllWordsIAddedTable()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM words WHERE `username_id` = " + Autorization.SessionId + " AND `liked_id` = 0 AND `language` = 'hebrew'", c.Con);
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        [WebMethod]
        public static string[] GetWordInfo(int id, string table)
        {
            IdShown = id;
            DataTable dt = GetTable(table, id);

            List<string> list = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr[3].ToString());
            }
            DataTable likes = GetTableLikes(table, id); //I guess?
            foreach (DataRow dr in likes.Rows)
            {
                switch (table)
                {
                    case "definitions":
                        Definitions d = new Definitions(int.Parse(dr[0].ToString()));
                        list.Add(d.Definition);
                        break;
                    case "examples":
                        Examples e = new Examples(int.Parse(dr[0].ToString()));
                        list.Add(e.Example);
                        break;
                    case "associations":
                        Associations a = new Associations(int.Parse(dr[0].ToString()));
                        list.Add(a.Association);
                        break;
                }
            }
            return list.ToArray();
        }

        private static DataTable GetTable(string table, int id)
        {
            Words w = new Words(id); //Exists
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `word_id` = @word_id AND liked_id = 0", c.Con);
                msc.Parameters.AddWithValue("@word_id", w.Id);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        private static DataTable GetTableLikes(string table, int id)
        {
            Words w = new Words(id); //Exists
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `word_id` = @word_id AND liked_id != 0", c.Con);
                msc.Parameters.AddWithValue("@word_id", w.Id);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        [WebMethod]
        public static int[] GetKnown(int id)
        {
            int[] info = new int[2];
            Words w = new Words(id);

            //Using the ajax to reset some stuff ~.~
            CurrentWord = w.Word;
            IdShown = id;

            info[0] = w.Knowledge;
            info[1] = w.Category_id;

            return info;
        }

        [WebMethod]
        public static void SetKnown(int type)
        {
            Words w = new Words(IdShown);
            w.Knowledge = type;
        }

        private static DataTable GetWordsByType(string table, int type)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `username_id` = @username_id AND `knowledge` = @knowledge AND `language` = 'hebrew'", c.Con);
                msc.Parameters.AddWithValue("@username_id", Autorization.SessionId);
                msc.Parameters.AddWithValue("@knowledge", type);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        private static DataTable GetWordsByCategory(string table, int categoryId)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `username_id` = @username_id AND `category_id` = @category_id AND `language` = 'hebrew'", c.Con);
                msc.Parameters.AddWithValue("@username_id", Autorization.SessionId);
                msc.Parameters.AddWithValue("@category_id", categoryId);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public Words GetWordById(int id)
        {
            Words w = new Words(id);
            return w;
        }

        public static int GetTypeLikesCount(int id, string table)
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
        public static void LikeAssAjax(int wordId, int assId)
        {
            Words likedWord = new Words(wordId);
            Associations ass = new Associations(assId);

            Likes assLike = new Likes("associations_likes");
            assLike.Word_id = GetWordIdByNameAjax(likedWord.Id);
            assLike.Registration_date = DateTime.UtcNow;
            assLike.Gave_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
            assLike.Got_id = ass.Username_id;
            assLike.Type_id = ass.id;
            assLike.AddLike();
        }

        [WebMethod]
        public static void LikeExaAjax(int wordId, int exaId)
        {
            Words likedWord = new Words(wordId);
            Examples exa = new Examples(exaId);

            Likes exaLike = new Likes("examples_likes");
            exaLike.Word_id = GetWordIdByNameAjax(likedWord.Id);
            exaLike.Registration_date = DateTime.UtcNow;
            exaLike.Gave_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
            exaLike.Got_id = exa.Username_id;
            exaLike.Type_id = exa.id;
            exaLike.AddLike();
        }

        [WebMethod]
        public static void LikeDefinitionAjax(int wordId, int definitionId, bool withWord)
        {
            Words likedWord = new Words(wordId);
            Definitions likedDefinition = new Definitions(definitionId);

            Words word = new Words();

            if (withWord)
            {
                word.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
                word.Word = likedWord.Word;
                word.Knowledge = 0;
                word.Category_id = 0;
                word.Registration_date = DateTime.UtcNow;
                word.Language = "hebrew";
                word.Ghosted = false;
                word.Liked_id = likedWord.Id;
                word.AddWord();

                Definitions newD = new Definitions();
                newD.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
                newD.Word_id = word.Id;
                newD.Definition = likedDefinition.Definition;
                newD.Registration_date = DateTime.UtcNow;
                newD.Ghosted = false;
                newD.Liked_id = likedDefinition.Id;
                newD.AddDefinition();
            }
            else
            {
                Definitions newD = new Definitions();
                newD.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
                newD.Word_id = GetWordIdByNameAjax(likedWord.Id);
                newD.Definition = likedDefinition.Definition;
                newD.Registration_date = DateTime.UtcNow;
                newD.Ghosted = false;
                newD.Liked_id = likedDefinition.Id;
                newD.AddDefinition();
            }
        }

        [WebMethod]
        public static void LikeWordAjax(int id)
        {
            Words w = new Words(id);

            Words newWord = new Words();
            newWord.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
            newWord.Word = w.Word;
            newWord.Knowledge = 0;
            newWord.Category_id = 0;
            newWord.Registration_date = DateTime.UtcNow;
            newWord.Language = "hebrew";
            newWord.Ghosted = false;
            newWord.Liked_id = w.Id;
            newWord.AddWord();

            w.GetFullInfo(); //Getting needed info
            Definitions def;

            //Adding likes to all definitions
            foreach (Definitions d in w.DefinitionsList)
            {
                def = new Definitions();
                def.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
                def.Word_id = newWord.Id;
                def.Definition = d.Definition;
                def.Registration_date = DateTime.UtcNow;
                def.Ghosted = false;
                def.Liked_id = d.Id;
                def.AddDefinition();
            }

            //Adding likes to all definitions
            foreach (Definitions l in w.DefinitionsLikesList)
            {
                def = new Definitions();
                def.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
                def.Word_id = newWord.Id;
                def.Definition = l.Definition;
                def.Registration_date = DateTime.UtcNow;
                def.Ghosted = false;
                def.Liked_id = l.Id;
                def.AddDefinition();
            }
        }

        [WebMethod]
        public static int GetWordIdByNameAjax(int id)
        {
            Words w = new Words(id);
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            return acc.GetWordIdByName(w.Word);

        }

        [WebMethod]
        public static string[] GetInfoByWordAjax(int wordId, string table)
        {
            return GetInfoByWord(wordId, table).ToArray();
        }

        public static List<string> GetInfoByWord(int wordId, string table)
        {
            DataTable dt = GetTable(table, wordId);

            List<string> list = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr[3].ToString());
            }
            DataTable likes = GetTableLikes(table, wordId); //I guess?
            foreach (DataRow dr in likes.Rows)
            {
                switch (table)
                {
                    case "definitions":
                        Definitions d = new Definitions(int.Parse(dr[0].ToString()));
                        list.Add(d.Definition);
                        break;
                    case "examples":
                        Examples e = new Examples(int.Parse(dr[0].ToString()));
                        list.Add(e.Example);
                        break;
                    case "associations":
                        Associations a = new Associations(int.Parse(dr[0].ToString()));
                        list.Add(a.Association);
                        break;
                }
            }
            return list;
        }

        private static DataTable GetTableWithLikesCount(string table, int id)
        {
            Words w = new Words(id); //Exists
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                //MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `word_id` = @word_id", c.Con);
                MySqlCommand msc = new MySqlCommand("SELECT *,(SELECT count(id) FROM " + table + "_likes WHERE " + table + "_likes .type_id = " + table + ".id) AS total FROM " + table + " WHERE word_id = @word_id ORDER BY total DESC;", c.Con);
                msc.Parameters.AddWithValue("@word_id", w.Id);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public DataTable GetTypeBySearch(string searchValue, string table)
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
        ON ass.word_id = w.id AND w.`language` = 'hebrew'
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM " + table + @" a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE w.word = @type AND ass.liked_Id = 0 ORDER BY a.liked_id DESC LIMIT 0, 50",
    c.Con);
                msc.Parameters.AddWithValue("@type", searchValue);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public DataTable GetWordsBySearch(string searchValue)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT w.*, wl.num_likes 
FROM words w LEFT JOIN
     (SELECT wl.liked_id, COUNT(*) AS num_likes
      FROM words wl
      GROUP BY wl.liked_id
     ) wl
     ON wl.liked_id = w.id
ORDER BY wl.num_likes DESC;",
    c.Con);
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            if (dt.Select("word like '%" + searchValue + "%'", "num_likes DESC").Length > 0)
                return dt.Select("word like '%" + searchValue + "%'", "num_likes DESC").CopyToDataTable();
            else
            {
                dt.Clear();
                return dt;
            }
        }

        [WebMethod]
        public static void SaveEditSettingsAjax(int wordId, int categoryIndex, bool deleteBool)
        {
            Words w = new Words(wordId);
            if (!deleteBool)
            {
                w.Category_id = categoryIndex;
            }
            else //delete
            {
                w.GetFullInfo();

                foreach (Definitions d in w.DefinitionsList)
                    d.DeleteDefinition();
                foreach (Definitions d in w.DefinitionsLikesList)
                    d.DeleteDefinition();
                foreach (Examples e in w.ExamplesList)
                    e.DeleteExample();
                foreach (Examples e in w.ExamplesLikesList)
                    e.DeleteExample();
                foreach (Associations a in w.AssociationsList)
                    a.DeleteAssociation();
                foreach (Associations a in w.AssociationsLikesList)
                    a.DeleteAssociation();

                w.DeleteWord();
            }
        }
    }
}