using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{
    public class Categories : SqlMain
    {
        private int username_id;
        private string category_name = "";
        private DateTime registration_date;

        public Categories()
        {
        }

        public Categories(int id)
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE id = @id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@id", id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    this.Id = r.GetInt32(0);
                    this.Username_id = r.GetInt32(1);
                    this.Category_name = r.GetString(2);
                    this.Registration_date = r.GetDateTime(3);
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
        public string Category_name { get => category_name; set { category_name = value; UpdateDb(); } }
        public DateTime Registration_date { get => registration_date; set { registration_date = value; UpdateDb(); } }

        public void UpdateDb()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("UPDATE `categories` SET username_id = @username_id, category_name = @category_name, registration_date = @registration_date WHERE `id` = @id");
                    cm.Parameters.AddWithValue("@username_id", Username_id);
                    cm.Parameters.AddWithValue("@category_name", Category_name);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
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

        public void AddCategory()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (!r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("INSERT INTO `categories` (username_id, category_name, registration_date) VALUES (@username_id, @category_name, @registration_date)");
                    cm.Parameters.AddWithValue("@username_id", Username_id);
                    cm.Parameters.AddWithValue("@category_name", Category_name);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
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

        public void DeleteCategory()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `categories` WHERE id = @id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@id", Id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("DELETE FROM `categories` WHERE id = @id");
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