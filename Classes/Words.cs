using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{
    public class Words : SqlMain
    {
        private int username_id;
        private string word;
        private int knowledge; //0 - not set, 1 - unknow >>
        private int category_id;
        private DateTime registration_date;
        private string language;
        private bool ghosted;
        private int liked_id;

        private List<Definitions> definitions = new List<Definitions>();
        private List<Definitions> definitionsLikes = new List<Definitions>();
        private List<Examples> examples = new List<Examples>();
        private List<Examples> examplesLikes = new List<Examples>();
        private List<Associations> associations = new List<Associations>();
        private List<Associations> associationsLikes = new List<Associations>();


        public Words()
        {
        }

        public Words(int id)
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `words` WHERE id = @id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@id", id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    this.id = r.GetInt32(0);
                    this.username_id = r.GetInt32(1);
                    this.word = r.GetString(2);
                    this.knowledge = r.GetInt32(3);
                    this.category_id = r.GetInt32(4);
                    this.registration_date = r.GetDateTime(5);
                    this.language = r.GetString(6);
                    this.ghosted = r.GetBoolean(7);
                    this.liked_id = r.GetInt32(8);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        public Words(string word)
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `words` WHERE word = @word");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@word", word);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    this.id = r.GetInt32(0);
                    this.username_id = r.GetInt32(1);
                    this.word = r.GetString(2);
                    this.knowledge = r.GetInt32(3);
                    this.category_id = r.GetInt32(4);
                    this.registration_date = r.GetDateTime(5);
                    this.language = r.GetString(6);
                    this.ghosted = r.GetBoolean(7);
                    this.liked_id = r.GetInt32(8);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        public int Id { get => id; set { id = value; UpdateDb(); } }
        public int Username_id { get => username_id; set { username_id = value; UpdateDb(); } }
        public string Word { get => word; set { word = value; UpdateDb(); } }
        public int Knowledge { get => knowledge; set { knowledge = value; UpdateDb(); } }
        public int Category_id { get => category_id; set { category_id = value; UpdateDb(); } }
        public DateTime Registration_date { get => registration_date; set { registration_date = value; UpdateDb(); } }
        public string Language { get => language; set { language = value; UpdateDb(); } }
        public bool Ghosted { get => ghosted; set { ghosted = value; UpdateDb(); } }
        public int Liked_id { get => liked_id; set { liked_id = value; UpdateDb(); } }
        public List<Definitions> DefinitionsList { get => definitions; set { definitions = value; } }
        public List<Definitions> DefinitionsLikesList { get => definitionsLikes; set { definitionsLikes = value; } }
        public List<Examples> ExamplesList { get => examples; set { examples = value; } }
        public List<Examples> ExamplesLikesList { get => examplesLikes; set { examplesLikes = value; } }
        public List<Associations> AssociationsList { get => associations; set { associations = value; } }
        public List<Associations> AssociationsLikesList { get => associationsLikes; set { associationsLikes = value; } }

        public void UpdateDb()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `words` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("UPDATE `words` SET username_id = @username_id, `word` = @word, knowledge = @knowledge, category_id = @category_id, registration_date = @registration_date, language = @language, ghosted = @ghosted, liked_id = @liked_id WHERE `id` = @id");
                    cm.Parameters.AddWithValue("@username_id", Username_id);
                    cm.Parameters.AddWithValue("@word", Word);
                    cm.Parameters.AddWithValue("@knowledge", Knowledge);
                    cm.Parameters.AddWithValue("@category_id", Category_id);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
                    cm.Parameters.AddWithValue("@language", Language);
                    cm.Parameters.AddWithValue("@ghosted", Ghosted);
                    cm.Parameters.AddWithValue("@liked_id", Liked_id);
                    cm.Parameters.AddWithValue("@id", Id);
                    cm.Connection = con.Con;
                    cm.ExecuteNonQuery();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        public void AddWord()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `words` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (!r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("INSERT INTO `words` (username_id, word, knowledge, category_id, registration_date, language, ghosted, liked_id) VALUES (@username_id, @word, @knowledge, @category_id, @registration_date, @language, @ghosted, @liked_id)");
                    cm.Parameters.AddWithValue("@username_id", Username_id);
                    cm.Parameters.AddWithValue("@word", Word);
                    cm.Parameters.AddWithValue("@knowledge", Knowledge);
                    cm.Parameters.AddWithValue("@category_id", Category_id);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
                    cm.Parameters.AddWithValue("@language", Language);
                    cm.Parameters.AddWithValue("@ghosted", Ghosted);
                    cm.Parameters.AddWithValue("@liked_id", Liked_id);
                    cm.Connection = con.Con;
                    cm.Prepare();
                    cm.ExecuteNonQuery();
                    Id = (int)cm.LastInsertedId;
                }
            }
            finally
            {
                con.conClose();
            }
        }

        public void DeleteWord()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `words` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("DELETE FROM `words` WHERE id = @id");
                    cm.Parameters.AddWithValue("@id", Id);
                    cm.Connection = con.Con;
                    cm.Prepare();
                    cm.ExecuteNonQuery();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        public static int GetLastInsertedId()
        {
            int id = 0;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT MAX(id) FROM `words` WHERE username_id = @username_id");
                msc.Parameters.AddWithValue("@username_id", HttpContext.Current.Session["Id"]);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    id = r.GetInt32(0);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
            return id;
        }

        public void GetFullInfo()
        {
            if (this.Id == 0)
                return;

            foreach (DataRow r in GetTable("definitions").Rows)
                definitions.Add(new Definitions(int.Parse(r[0].ToString())));

            foreach (DataRow r in GetTableLikes("definitions").Rows)
                definitionsLikes.Add(new Definitions(int.Parse(r[0].ToString())));

            foreach (DataRow r in GetTable("examples").Rows)
                examples.Add(new Examples(int.Parse(r[0].ToString())));

            foreach (DataRow r in GetTableLikes("examples").Rows)
                examplesLikes.Add(new Examples(int.Parse(r[0].ToString())));

            foreach (DataRow r in GetTable("associations").Rows)
                associations.Add(new Associations(int.Parse(r[0].ToString())));

            foreach (DataRow r in GetTableLikes("associations").Rows)
                associationsLikes.Add(new Associations(int.Parse(r[0].ToString())));
        }

        public DataTable GetTable(string table)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `word_id` = @word_id AND liked_id = 0", c.Con);
                msc.Parameters.AddWithValue("@word_id", this.Id);
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }

        public DataTable GetTableLikes(string table)
        {
            DataTable dt;
            Connection c = new Connection();
            try
            {
                c.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE `word_id` = @word_id AND liked_id != 0", c.Con);
                msc.Parameters.AddWithValue("@word_id", this.Id);
                msc.Connection = c.Con;
                DataSet ds = c.getDataSet(msc, table);
                dt = ds.Tables[table];
            }
            finally
            {
                c.conClose();
            }
            return dt;
        }
    }
}