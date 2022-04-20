using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{
    public class Definitions : SqlMain
    {
        private int username_id;
        private int word_id;
        private string definition;
        private DateTime registration_date;
        private bool ghosted;
        private int liked_id;
        public Definitions()
        {
        }

        public Definitions(int id)
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `definitions` WHERE id = @id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@id", id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    this.id = r.GetInt32(0);
                    this.username_id = r.GetInt32(1);
                    this.word_id = r.GetInt32(2);
                    this.definition = r.GetString(3);
                    this.registration_date = r.GetDateTime(4);
                    this.ghosted = r.GetBoolean(5);
                    this.liked_id = r.GetInt32(6);
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
        public int Word_id { get => word_id; set { word_id = value; UpdateDb(); } }
        public string Definition { get => definition; set { definition = value; UpdateDb(); } }
        public DateTime Registration_date { get => registration_date; set { registration_date = value; UpdateDb(); } }
        public bool Ghosted { get => ghosted; set { ghosted = value; UpdateDb(); } }
        public int Liked_id { get => liked_id; set { liked_id = value; UpdateDb(); } }

        public void UpdateDb()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `definitions` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("UPDATE `definitions` SET username_id = @username_id, word_id = @word_id, definition = @definition, registration_date = @registration_date, ghosted = @ghosted, liked_id = @liked_id WHERE `id` = @id");
                    cm.Parameters.AddWithValue("@username_id", Username_id);
                    cm.Parameters.AddWithValue("@word_id", Word_id);
                    cm.Parameters.AddWithValue("@definition", Definition);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
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

        public void AddDefinition()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `definitions` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (!r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("INSERT INTO `definitions` (username_id, word_id, definition, registration_date, ghosted, liked_id) VALUES (@username_id, @word_id, @definition, @registration_date, @ghosted, @liked_id)");
                    cm.Parameters.AddWithValue("@username_id", Username_id);
                    cm.Parameters.AddWithValue("@word_id", Word_id);
                    cm.Parameters.AddWithValue("@definition", Definition);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
                    cm.Parameters.AddWithValue("@ghosted", Ghosted);
                    cm.Parameters.AddWithValue("@liked_id", liked_id);
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

        public void DeleteDefinition()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `definitions` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("DELETE FROM `definitions` WHERE id = @id");
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
    }
}