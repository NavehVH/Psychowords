using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Psychometric.master_pages
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        int allWords, knownWords, almostKnownWords, unknownWords, wordsLiked; //user satistics vars

        protected void Page_Load(object sender, EventArgs e)
        {
            //setting the count on login
            if (!IsPostBack)
            {
                SetCount();
            }
        }

        //getting user satistics from database and setting it
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
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @";
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `knowledge` = 3;
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `knowledge` = 2;
SELECT COUNT(*) FROM `words` WHERE username_id = " + id + @" AND `knowledge` = 1;
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
                r.Close();
            } finally
            {
                con.conClose();
            }

            allWordsSpan.InnerText = allWords.ToString();
            knownWordsSpan.InnerText = knownWords.ToString();
            almostKnownWordsSpan.InnerText = almostKnownWords.ToString();
            unknownWordsSpan.InnerText = unknownWords.ToString();
            //selfAddedSpan.InnerText = allWords.ToString();
            //wordsLikedSpan.InnerText = wordsLiked.ToString();
        }
    }
}