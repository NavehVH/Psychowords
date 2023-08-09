using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Psychometric.App_Data
{
    public class Connection
    {
        private MySqlConnection con;
        private MySqlDataAdapter ad;

        public Connection()
        {
            //string connString = "server=" + Security.SERVER + "; userid=" + Security.USER_ID + ";password=" + Security.PASSWORD + "; database=" + Security.DATABASE + ";Convert Zero Datetime=True; ;Allow User Variables=True;CHARSET=utf8;";
            //string connString = "server='localhost'; userid='root';password=''; database=" + Security.DATABASE + ";Convert Zero Datetime=True; ;Allow User Variables=True;CHARSET=utf8;";
            //string connString = "server='mysql5046.site4now.net'; userid='a884d9_psy';password='qwer1234'; database='db_a884d9_psy';Convert Zero Datetime=True; ;Allow User Variables=True;CHARSET=utf8;";
            string connString = "server='localhost'; userid='root';password=''; database='psychometry_data';Convert Zero Datetime=True; ;Allow User Variables=True;CHARSET=utf8;";
            this.con = new MySqlConnection(connString);
        }

        public MySqlConnection Con
        {
            get { return this.con; }
            set { this.con = value; }
        }

        public MySqlDataReader getDataReader(String sqlStr)
        {
            this.con.Open();
            MySqlCommand cmd = new MySqlCommand(sqlStr, this.con);
            return cmd.ExecuteReader();
        }

        public DataSet getDataSet(MySqlCommand SqlStr, String TableName)
        {
            ad = new MySqlDataAdapter(SqlStr);
            DataSet ds = new DataSet();
            ad.Fill(ds, TableName);
            return ds;
        }

        public void conClose()
        {
            this.con.Close();
        }

        public void conOpen()
        {
            this.con.Open();
        }

        public bool NonQuery(String SqlStr)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(SqlStr, this.con);
            int a = cmd.ExecuteNonQuery();
            conClose();
            return a > 0;
        }

        public void UpdateDataSet(DataSet ds)
        {
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(ad);
            ad.InsertCommand = Builder.GetInsertCommand();
            ad.UpdateCommand = Builder.GetUpdateCommand();
            ad.DeleteCommand = Builder.GetDeleteCommand();
            ad.Update(ds.Tables[0]);
        }

        public void UpdateDataSet(DataSet ds, String TableName)
        {
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(ad);
            ad.InsertCommand = Builder.GetInsertCommand();
            ad.UpdateCommand = Builder.GetUpdateCommand();
            ad.DeleteCommand = Builder.GetDeleteCommand();
            ad.Update(ds, TableName);
        }
    }
}