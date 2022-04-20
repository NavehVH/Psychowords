using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMKB.App_Data;

namespace AMKB.Classes
{
    class Keyshort
    {
        private int id;
        private String keystroke;
        private String shorter;

        public Keyshort(String keystroke)
        {
            String query = "SELECT * FROM keyshort WHERE keystroke = '" + keystroke + "'";
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.keystroke = r.GetString(1);
                if (!r.IsDBNull(2))
                    this.shorter = r.GetString(2);
                else
                    this.shorter = "";
            }
            con.conClose();
        }

        public Keyshort()
        {

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; UpdateDb(); }
        }

        public String Keystroke
        {
            get { return this.keystroke; }
            set { this.keystroke = value; UpdateDb(); }
        }

        public String Shorter
        {
            get { return this.shorter; }
            set { this.shorter = value; UpdateDb(); }
        }

        public void UpdateDb()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [keyshort] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("UPDATE [keyshort] SET [keystroke] = '" + Keystroke + "', [shorter] = '" + Shorter + "' WHERE [Id] = " + Id + "");
            }
        }

        public void AddBot()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [keyshort] WHERE [Id] = " + Id + "");
            if (!r.Read())
            {
                con.conClose();
                con.NonQuery("INSERT INTO [keyshort] ([keystroke], [shorter]) VALUES ('" + Keystroke + "', '" + Shorter + "')");
            }
        }
    }
}
