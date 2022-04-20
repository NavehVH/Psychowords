using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{
    public class Accounts : SqlMain
    {
        private string username = "";
        private string password = "";
        private string email = "";
        private string first_name = "";
        private string last_name = "";
        private int subscription_days = 0;
        private int admin = 0;
        private bool ghosted = false;
        private int warnings = 0;
        private bool banned = false;
        private DateTime registration_date;
        private DateTime last_login_date;
        private bool trial = false;
        private string last_ip = "";
        private string verification = "";

        public Accounts()
        {

        }

        public Accounts(int id)
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `accounts` WHERE id = @id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@id", id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    this.id = r.GetInt32(0);
                    this.username = r.GetString(1);
                    this.password = r.GetString(2);
                    this.email = r.GetString(3);
                    this.first_name = r.GetString(4);
                    this.last_name = r.GetString(5);
                    this.subscription_days = r.GetInt32(6);
                    this.admin = r.GetInt32(7);
                    this.ghosted = r.GetBoolean(8);
                    this.warnings = r.GetInt32(9);
                    this.banned = r.GetBoolean(10);
                    this.registration_date = r.GetDateTime(11);
                    this.last_login_date = r.GetDateTime(12);
                    this.trial = r.GetBoolean(13);
                    this.last_ip = r.GetString(14);
                    this.verification = r.GetString(15);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        //get all user data
        public Accounts(String username, String password, bool verificationCheck)
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc;
                if (verificationCheck)
                {
                    msc = new MySqlCommand("SELECT * FROM `accounts` WHERE `username` = @username AND `verification` = @verification");
                    msc.Parameters.AddWithValue("@username", username);
                    msc.Parameters.AddWithValue("@verification", password);
                }
                else
                {
                    msc = new MySqlCommand("SELECT * FROM `accounts` WHERE `username` = @username AND `password` = @password");
                    msc.Parameters.AddWithValue("@username", username);
                    msc.Parameters.AddWithValue("@password", password);
                }
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    this.id = r.GetInt32(0);
                    this.username = r.GetString(1);
                    this.password = r.GetString(2);
                    this.email = r.GetString(3);
                    this.first_name = r.GetString(4);
                    this.last_name = r.GetString(5);
                    this.subscription_days = r.GetInt32(6);
                    this.admin = r.GetInt32(7);
                    this.ghosted = r.GetBoolean(8);
                    this.warnings = r.GetInt32(9);
                    this.banned = r.GetBoolean(10);
                    this.registration_date = r.GetDateTime(11);
                    this.last_login_date = r.GetDateTime(12);
                    this.trial = r.GetBoolean(13);
                    this.last_ip = r.GetString(14);
                    this.verification = r.GetString(15);
                    r.Close();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        //get and set
        public int Id { get => id; set { id = value; } }
        public string Username { get => username; set { username = value; UpdateDb(); } }
        public string Password { get => password; set { password = value; UpdateDb(); } }
        public string Email { get => email; set { email = value; UpdateDb(); } }
        public string First_name { get => first_name; set { first_name = value; UpdateDb(); } }
        public string Last_name { get => last_name; set { last_name = value; UpdateDb(); } }
        public int Subscription_days { get => subscription_days; set { subscription_days = value; UpdateDb(); } }
        public int Admin { get => admin; set { admin = value; UpdateDb(); } }
        public bool Ghosted { get => ghosted; set { ghosted = value; UpdateDb(); } }
        public int Warnings { get => warnings; set { warnings = value; UpdateDb(); } }
        public bool Banned { get => banned; set { banned = value; UpdateDb(); } }
        public DateTime Registration_date { get => registration_date; set { registration_date = value; UpdateDb(); } }
        public DateTime Last_login_date { get => last_login_date; set { last_login_date = value; UpdateDb(); } }
        public bool Trial { get => trial; set { trial = value; UpdateDb(); } }
        public string Last_ip { get => last_ip; set { last_ip = value; UpdateDb(); } }
        public string Verification { get => verification; set { verification = value; UpdateDb(); } }

        //Updates DB
        public void UpdateDb()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `accounts` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("UPDATE `accounts` SET `username` = @username, `password` = @password, `email` = @email, `first_name` = @first_name, last_name = @last_name, subscription_days = @subscription_days, admin = @admin, `ghosted` = @ghosted, `warnings` = @warnings, `banned` = @banned, `registration_date` = @registration_date, `last_login_date` = @last_login_date, `trial` = @trial, last_ip = @last_ip, verification = @verification WHERE `id` = @id");
                    cm.Parameters.AddWithValue("@username", Username);
                    cm.Parameters.AddWithValue("@password", Password);
                    cm.Parameters.AddWithValue("@email", Email);
                    cm.Parameters.AddWithValue("@first_name", First_name);
                    cm.Parameters.AddWithValue("@last_name", Last_name);
                    cm.Parameters.AddWithValue("@subscription_days", Subscription_days);
                    cm.Parameters.AddWithValue("@admin", Admin);
                    cm.Parameters.AddWithValue("@ghosted", Ghosted);
                    cm.Parameters.AddWithValue("@warnings", Warnings);
                    cm.Parameters.AddWithValue("@banned", Banned);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
                    cm.Parameters.AddWithValue("@last_login_date", Last_login_date);
                    cm.Parameters.AddWithValue("@trial", Trial);
                    cm.Parameters.AddWithValue("@last_ip", Last_ip);
                    cm.Parameters.AddWithValue("@verification", Verification);
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

        //Adds new row in accounts based on the object
        public void AddAccount()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `accounts` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                msc.Connection = con.Con;
                MySqlDataReader r = msc.ExecuteReader();
                if (!r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("INSERT INTO `accounts` (username, password, email, first_name, last_name, subscription_days, admin, ghosted, warnings, banned, registration_date, last_login_date, trial, last_ip, verification) VALUES (@username, @password, @email, @first_name, @last_name, @subscription_days, @admin, @ghosted, @warnings, @banned, @registration_date, @last_login_date, @trial, @last_ip, @verification)");
                    cm.Parameters.AddWithValue("@username", Username);
                    cm.Parameters.AddWithValue("@password", Password);
                    cm.Parameters.AddWithValue("@email", Email);
                    cm.Parameters.AddWithValue("@first_name", First_name);
                    cm.Parameters.AddWithValue("@last_name", Last_name);
                    cm.Parameters.AddWithValue("@subscription_days", Subscription_days);
                    cm.Parameters.AddWithValue("@admin", Admin);
                    cm.Parameters.AddWithValue("@ghosted", Ghosted);
                    cm.Parameters.AddWithValue("@warnings", Warnings);
                    cm.Parameters.AddWithValue("@banned", Banned);
                    cm.Parameters.AddWithValue("@registration_date", Registration_date);
                    cm.Parameters.AddWithValue("@last_login_date", Last_login_date);
                    cm.Parameters.AddWithValue("@trial", Trial);
                    cm.Parameters.AddWithValue("@last_ip", Last_ip);
                    cm.Parameters.AddWithValue("@verification", Verification);
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

        //Delete this object from sql
        public void DeleteAccount()
        {
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `accounts` WHERE id = @id");
                msc.Parameters.AddWithValue("@id", Id);
                MySqlDataReader r = msc.ExecuteReader();
                if (r.Read())
                {
                    r.Close();
                    MySqlCommand cm = new MySqlCommand("DELETE FROM `accounts` WHERE id = @id");
                    cm.Parameters.AddWithValue("@id", Id);
                    cm.Prepare();
                    cm.ExecuteNonQuery();
                }
            }
            finally
            {
                con.conClose();
            }
        }

        public int GetWordIdByName(string word)
        {
            int id = 0;
            Connection con = new Connection();
            try
            {
                con.conOpen();
                MySqlCommand msc = new MySqlCommand("SELECT id FROM `words` WHERE `word` = @word AND username_id = @username_id");
                msc.Connection = con.Con;
                msc.Parameters.AddWithValue("@word", word);
                msc.Parameters.AddWithValue("@username_id", Id);
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
    }
}