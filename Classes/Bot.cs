using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMKB.App_Data;

namespace AMKB.Classes
{
    class Bot
    {
        private int id;
        private String keystroke;
        private double timer;
        private int position;
        private int botId;
        private int eventId;
        private String eventType;

        public Bot(int id)
        {
            String query = "SELECT * FROM bot WHERE id = " + id + "";
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.keystroke = r.GetString(1);
                this.timer = r.GetDouble(2);
                this.position = r.GetInt32(3);
                if(r.IsDBNull(4) == true)
                    this.botId = 0;
                else
                    this.botId = r.GetInt32(4);
                this.eventId = r.GetInt32(5);
                if (r.IsDBNull(6) == true)
                    this.eventType = null;
                else
                    this.eventType = r.GetString(6);
            }
            con.conClose();
        }

        public Bot()
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

        public double Timer
        {
            get { return this.timer; }
            set { this.timer = value; UpdateDb(); }
        }

        public int Position
        {
            get { return this.position; }
            set { this.position = value; UpdateDb(); }
        }

        public int BotId
        {
            get { return this.botId; }
            set { this.botId = value; UpdateDb(); }
        }

        public int EventId
        {
            get { return this.eventId; }
            set { this.eventId = value; UpdateDb(); }
        }

        public String EventType
        {
            get { return this.eventType; }
            set { this.eventType = value; UpdateDb(); }
        }

        public void UpdateDb()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [bot] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("UPDATE [bot] SET [keystroke] = '" + Keystroke + "', [timer] = " + Timer + ", [Position] = " + Position + ", [botId] = " + BotId + ", [eventId] = " + EventId + ", [eventType] = '" + EventType + "' WHERE [Id] = " + Id + "");
            }
        }

        public void AddBot()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [bot] WHERE [Id] = " + Id + "");
            if (!r.Read())
            {
                con.conClose();
                con.NonQuery("INSERT INTO [bot] ([keystroke], [timer], [position], [botId], [eventId], [eventType]) VALUES ('" + Keystroke + "', " + Timer + ", " + Position + ", " + BotId + ", " + EventId + ", '" + EventType + "')");
            }
        }

        public void DeleteBot()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [bot] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("DELETE FROM [bot] WHERE id = " + Id + "");
            }
        }
    }
}
