using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{
    public class Likes: SqlMain
    {
        private Object objectLiked = null;
        private string table; //Definitions_Likes, Examples_Likes, Associations_Likes

        private int word_id;
        private DateTime registration_date;
        private int gave_id;
        private int got_id;
        private int type_id;

        public Likes()
        {
        }

        public Likes(string table)
        {
            this.table = table;
        }

        public Likes(string table, int id)
        {
            Connection con = new Connection();
            con.conOpen();
            MySqlCommand msc = new MySqlCommand("SELECT * FROM " + table + " WHERE id = @id");
            msc.Connection = con.Con;
            msc.Parameters.AddWithValue("@id", id);
            MySqlDataReader r = msc.ExecuteReader();
            if (r.Read())
            {
                this.Table = table;

                this.id = r.GetInt32(0);
                this.Word_id = r.GetInt32(1);
                this.Registration_date = r.GetDateTime(2);
                this.Gave_id = r.GetInt32(3);
                this.Got_id = r.GetInt32(4);
                this.type_id = r.GetInt32(5);
                r.Close();
                switch(table)
                {
                    case "Definitions_Likes":
                        objectLiked = new Definitions(this.type_id);
                        break;
                    case "Examples_Likes":
                        objectLiked = new Examples(this.type_id);
                        break;
                    case "Associations_Likes":
                        objectLiked = new Associations(this.type_id);
                        break;
                    case "Words_Likes":
                        objectLiked = new Words(this.type_id);
                        break;
                }
            }
            con.conClose();
        }

        public string Table { get => table; set { table = value; UpdateDb(); } }
        public int Id { get => id; set { id = value; UpdateDb(); } }
        public int Word_id { get => word_id; set { word_id = value; UpdateDb(); } }
        public DateTime Registration_date { get => registration_date; set { registration_date = value; UpdateDb(); } }
        public int Gave_id { get => gave_id; set { gave_id = value; UpdateDb(); } }
        public int Got_id { get => got_id; set { got_id = value; UpdateDb(); } }
        public int Type_id { get => type_id; set { type_id = value; UpdateDb(); } }
        public Object ObjectLiked { get => objectLiked; set { objectLiked = value; } }

        public void UpdateDb()
        {
            Connection con = new Connection();
            con.conOpen();
            MySqlCommand msc = new MySqlCommand("SELECT * FROM " + Table + " WHERE id = @id");
            msc.Parameters.AddWithValue("@id", Id);
            msc.Connection = con.Con;
            MySqlDataReader r = msc.ExecuteReader();
            if (r.Read())
            {
                r.Close();
                MySqlCommand cm = new MySqlCommand("UPDATE " + Table + " SET word_id = @word_id, registration_date = @registration_date, gave_id = @gave_id, got_id = @got_id, type_id = @type_id WHERE `id` = @id");
                cm.Parameters.AddWithValue("@word_id", Word_id);
                cm.Parameters.AddWithValue("@registration_date", Registration_date);
                cm.Parameters.AddWithValue("@gave_id", Gave_id);
                cm.Parameters.AddWithValue("@got_id", Got_id);
                cm.Parameters.AddWithValue("@type_id", Type_id);
                cm.Parameters.AddWithValue("@id", Id);
                cm.Connection = con.Con;
                cm.ExecuteNonQuery();
            }
            con.conClose();
        }

        public void AddLike()
        {
            Connection con = new Connection();
            con.conOpen();
            MySqlCommand msc = new MySqlCommand("SELECT * FROM " + Table + " WHERE id = @id");
            msc.Parameters.AddWithValue("@id", Id);
            msc.Connection = con.Con;
            MySqlDataReader r = msc.ExecuteReader();
            if (!r.Read())
            {
                r.Close();
                MySqlCommand cm = new MySqlCommand("INSERT INTO " + Table + " (word_id, registration_date, gave_id, got_id, type_id) VALUES (@word_id, @registration_date, @gave_id, @got_id, @type_id)");
                cm.Parameters.AddWithValue("@word_id", Word_id);
                cm.Parameters.AddWithValue("@registration_date", Registration_date);
                cm.Parameters.AddWithValue("@gave_id", Gave_id);
                cm.Parameters.AddWithValue("@got_id", Got_id);
                cm.Parameters.AddWithValue("@type_id", Type_id);
                cm.Connection = con.Con;
                cm.Prepare();
                cm.ExecuteNonQuery();
            }
            con.conClose();
        }

        public void DeleteLike()
        {
            Connection con = new Connection();
            con.conOpen();
            MySqlCommand msc = new MySqlCommand("SELECT * FROM " + Table + " WHERE id = @id");
            msc.Parameters.AddWithValue("@id", Id);
            MySqlDataReader r = msc.ExecuteReader();
            if (r.Read())
            {
                r.Close();
                MySqlCommand cm = new MySqlCommand("DELETE FROM " + Table + " WHERE id = @id");
                cm.Parameters.AddWithValue("@id", Id);
                cm.Prepare();
                cm.ExecuteNonQuery();
            }
            con.conClose();
        }
    }
}