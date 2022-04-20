using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Psychometric.Classes
{

    public class SqlHelper
    {
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
    }
}