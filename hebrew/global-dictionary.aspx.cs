﻿using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using Psychometric.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Psychometric.master_pages
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        //data of search vars
        public DataTable WordsTable;
        public DataTable DefinitionsTable;
        public DataTable AssociationsTable;
        public DataTable ExamplesTable;

        public List<Associations> AssociationsList; //#TODO remove this if not needed
        public List<Examples> ExamplesList; //#TODO remove this if not needed

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //checking if logged
                if (!Autorization.CheckAutorization())
                {
                    Response.Redirect("../pages/logout.aspx");
                }

                //reset search data on load

                //SearchPanel.Visible = false;
                WordsTable = null;
                DefinitionsTable = null;
                AssociationsTable = null;
                ExamplesTable = null;

                AssociationsList = null;
                ExamplesList = null;
            }
        }

        //clicking search button and showing search results
        protected void SearchClick(object sender, EventArgs e)
        {
            string SearchValue = SearchTextBox.Value;
            WordsTable = GetWordsBySearch(SearchValue);
            DefinitionsTable = GetDefinitionsBySearch(SearchValue);
            AssociationsTable = GetTypeBySearch(SearchValue, "associations");
            ExamplesTable = GetTypeBySearch(SearchValue, "examples");

            //AssociationsList = GetAssociationsBySearch(SearchValue);
            //ExamplesList = GetExamplesBySearch(SearchValue);
            GlobalDictionaryPanel.Update();
        }

        //getting the wanted info by given word
        public DataTable GetTypeBySearch(string searchValue, string table)
        {
            DataTable dt;
            Connection c = new Connection();
            //getting info from the database
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
WHERE w.word like @type AND ass.liked_Id = 0 ORDER BY a.liked_id DESC LIMIT 0, 50",
    c.Con);
                msc.Parameters.AddWithValue("@type", "%" + searchValue + "%");
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }

            //showing the currect table
            if (dt.Rows.Count == 0)
            {
                if (table == "associations")
                    AssEmptySpan.Visible = true;
                else if (table == "examples")
                    ExaEmptySpan.Visible = true;
            }
            else
            {
                if (table == "associations")
                    AssEmptySpan.Visible = false;
                else if (table == "examples")
                    ExaEmptySpan.Visible = false;
            }
            return dt;
        }

        //example for myself
        /*
         
        SELECT ass.*, a.total 
FROM associations ass
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM associations a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
         
         */

        //getting words from database by given word search
        public DataTable GetWordsBySearch(string searchValue)
        {
            DataTable dt;
            Connection c = new Connection();
            //finding the info about the word from the database
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT ass.*, a.total, w.`language`
FROM words ass
INNER JOIN words w
        ON ass.id = w.id AND w.`language` = 'hebrew'
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM words a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE w.word LIKE @search AND ass.liked_Id = 0 ORDER BY a.liked_id DESC LIMIT 0, 50",
    c.Con);
                msc.Parameters.AddWithValue("@search", "%" + searchValue + "%");
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"]; //updating table with found search info
            }
            finally
            {
                c.conClose();
            }

            //show table
            if (dt.Rows.Count == 0)
                WordsEmptySpan.Visible = true;
            else
                WordsEmptySpan.Visible = false;

            return dt;
        }

        //not used
        public string CheckLikes(string likes)
        {
            if (likes == "" || likes == null)
                return "0";
            else
                return likes;
        }

        //getting the definition string by given wordId
        public DataTable GetDefinitionByWord(int wordId)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM definitions WHERE `word_id` = @word_id", c.Con);
                msc.Parameters.AddWithValue("@word_id", wordId);
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        //get definition by search from definition
        public DataTable GetDefinitionsBySearch(string searchValue)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT ass.*, a.total, w.`language`
FROM definitions ass
INNER JOIN words w
        ON ass.word_id = w.id AND w.`language` = 'hebrew'
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM definitions a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE ass.definition LIKE @search AND ass.liked_Id = 0 ORDER BY a.liked_id DESC LIMIT 0, 50",
    c.Con);
                msc.Parameters.AddWithValue("@search", "%" + searchValue + "%");
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }

            if (dt.Rows.Count == 0)
                DefsEmptySpan.Visible = true;
            else
                DefsEmptySpan.Visible = false;
            return dt;
        }

        //not used
        public DataTable GetAssociationsBySearch2(string searchValue)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT *,(SELECT count(id) FROM associations_likes WHERE associations_likes .type_id = associations.id) AS total FROM associations WHERE association LIKE @association ORDER BY total DESC;", c.Con);
                msc.Parameters.AddWithValue("@association", "%" + searchValue + "%");
                DataSet ds = c.getDataSet(msc, "associations");
                dt = ds.Tables["associations"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        //not used
        public DataTable GetExamplesBySearch2(string searchValue)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT *,(SELECT count(id) FROM examples_likes WHERE examples_likes .type_id = examples.id) AS total FROM examples WHERE example LIKE @example ORDER BY total DESC;", c.Con);
                msc.Parameters.AddWithValue("@example", "%" + searchValue + "%");
                DataSet ds = c.getDataSet(msc, "examples");
                dt = ds.Tables["examples"];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        //adding the info of the search found into arrays to be able to transfer it from backend to frontend with AJAX
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

        //getting a given table with all the words with the specific ID
        private static DataTable GetTable(string table, int wordId)
        {
            Words w = new Words(wordId); //Exists
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

        //getting a given table with all the words with the specific ID (from liked words)
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

        //getting table info from wordId, But based on most liked 
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

        //returns a word based on its ID from database
        public Words GetWordById(int id)
        {
            Words w = new Words(id);
            return w;
        }


        //getting likes amount of specific type and id
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

        //getting associations by search
        public DataTable GetAssociationsBySearch(string searchValue)
        {
            DataTable words = GetWordsBySearch(searchValue); //search data
            DataTable dt = new DataTable();

            foreach (DataRow wordRow in words.Rows) //merging with liked type
            {
                dt.Merge(GetTableWithLikesCount("associations", int.Parse(wordRow[0].ToString())));
            }

            if (dt.Select("", "total DESC").Length > 0)
                return dt.Select("", "total DESC").CopyToDataTable(); //returning data by DESC order
            else
            {
                dt.Clear();
                return dt;
            }
        }

        //not used
        public List<Examples> GetExamplesBySearch(string searchValue)
        {
            List<Examples> exaList = new List<Examples>();
            DataTable words = GetWordsBySearch(searchValue);
            DataTable dt;
            foreach (DataRow wordRow in words.Rows)
            {
                dt = GetTable("examples", int.Parse(wordRow[0].ToString()));
                foreach (DataRow row in dt.Rows)
                {
                    exaList.Add(new Examples(int.Parse(row[0].ToString())));
                }
            }
            return exaList;
        }

        //if liked an ass, add it to user data
        [WebMethod]
        public static void LikeAssAjax(int wordId, int assId)
        {
            Words likedWord = new Words(wordId);
            Associations assLiked = new Associations(assId);

            Associations ass = new Associations();
            ass.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString());
            ass.Word_id = GetWordIdByNameAjax(likedWord.Id);
            ass.Association = assLiked.Association;
            ass.Registration_date = DateTime.UtcNow;
            ass.Ghosted = false;
            ass.Liked_id = assLiked.id;
            ass.AddAssociation();
        }

        //if liked an exa, add it to user data
        [WebMethod]
        public static void LikeExaAjax(int wordId, int exaId)
        {
            Words likedWord = new Words(wordId);
            Examples exaLiked = new Examples(exaId);

            Examples newE = new Examples();
            newE.Username_id = int.Parse(HttpContext.Current.Session["Id"].ToString()); ;
            newE.Word_id = GetWordIdByNameAjax(likedWord.Id);
            newE.Example = exaLiked.Example;
            newE.Registration_date = DateTime.UtcNow;
            newE.Ghosted = false;
            newE.Liked_id = exaLiked.id;
            newE.AddExample();
        }

        //if liked a def, add it to user data
        [WebMethod]
        public static void LikeDefinitionAjax(int wordId, int definitionId, bool withWord)
        {
            Words likedWord = new Words(wordId);
            Definitions likedDefinition = new Definitions(definitionId);

            Words word = new Words();

            //word doesn't exist yet, add it with word
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
            else //have the world already, add definition
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

        //liked a word, add it to the user data
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

            w.GetFullInfo(); //Getting needed info (#TODO only need def', change that(?))
            Definitions def;

            //Adding likes to all definitions inside the word
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

            //Adding likes to all definitions inside the word
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

        //getting user word id, by word
        [WebMethod]
        public static int GetWordIdByNameAjax(int id)
        {
            Words w = new Words(id);
            Accounts acc = (Accounts)HttpContext.Current.Session["Account"];
            return acc.GetWordIdByName(w.Word);

        }

        //getting all the info from backend to frontend
        [WebMethod]
        public static string[] GetInfoByWordAjax(int wordId, string table)
        {
            return GetInfoByWord(wordId, table).ToArray();
        }

        //searching by subject button
        protected void SubjectButton_Click(object sender, EventArgs e)
        {
            string SearchValue = SearchTextBox.Value;
            DefinitionsTable = null;
            AssociationsTable = null;
            ExamplesTable = null;

            if (SelectList.SelectedIndex > -1)
            {
                if (SelectList.SelectedIndex == 0) //selected first option, most popular
                {
                    WordsTable = GetWordsMostPopular();
                }
                else
                {
                    WordsTable = GetWordsByLetter(SelectList.Items[SelectList.SelectedIndex].Text); //getting words by choosen letter
                }
            }

            GlobalDictionaryPanel.Update(); //update table
        }
        
        //getting results by given letter
        public DataTable GetWordsByLetter(string searchValue)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT ass.*, a.total, w.`language`
FROM words ass
INNER JOIN words w
        ON ass.id = w.id AND w.`language` = 'hebrew' AND w.username_id != @username_id
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM words a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE w.word LIKE @search AND ass.liked_Id = 0 ORDER BY a.total DESC LIMIT 0, 100",
    c.Con);
                msc.Parameters.AddWithValue("@username_id", Autorization.SessionId);
                msc.Parameters.AddWithValue("@search", "" + searchValue + "%");
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            if (dt.Rows.Count == 0)
                WordsEmptySpan.Visible = true;
            else
                WordsEmptySpan.Visible = false;
            return dt;
        }

        //getting results by most popular words
        public DataTable GetWordsMostPopular()
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand(@"
SELECT ass.*, a.total, w.`language`
FROM words ass
INNER JOIN words w
        ON ass.id = w.id AND w.`language` = 'hebrew' AND w.username_id != @username_id
    LEFT JOIN (
                SELECT liked_id, COUNT(liked_id) as total
                FROM words a1
                GROUP BY liked_id
               ) a
        ON ass.id = a.liked_id
WHERE ass.liked_Id = 0 ORDER BY a.total DESC LIMIT 0, 100",
    c.Con);
                msc.Parameters.AddWithValue("@username_id", Autorization.SessionId);
                DataSet ds = c.getDataSet(msc, "words");
                dt = ds.Tables["words"];
            }
            finally
            {
                c.conClose();
            }
            if (dt.Rows.Count == 0)
                WordsEmptySpan.Visible = true;
            else
                WordsEmptySpan.Visible = false;
            return dt;
        }
    }
}