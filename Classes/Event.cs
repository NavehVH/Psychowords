using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMKB.App_Data;

namespace AMKB.Classes
{
    class Event
    {

        private int id;
        private int botId;
        private String eventName;
        private String eventType;
        private int from1 = -100, from2 = -100;
        private int to1 = -100, to2 = -100;
        private Boolean bigger1, bigger2;
        private Boolean between1, between2;
        private Boolean playerInMap;

        public Event(String eventName)
        {
            String query = "SELECT * FROM [event] WHERE eventName = '" + eventName + "'";
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.botId = r.GetInt32(1);
                this.eventName = r.GetString(2);
                this.eventType = r.GetString(3);
                this.from1 = r.GetInt32(4);
                this.from2 = r.GetInt32(5);
                this.to1 = r.GetInt32(6);
                this.to2 = r.GetInt32(7);
                this.bigger1 = r.GetBoolean(8);
                this.bigger2 = r.GetBoolean(9);
                this.between1 = r.GetBoolean(10);
                this.between2 = r.GetBoolean(11);
                this.playerInMap = r.GetBoolean(12);
            }
            con.conClose();
        }

        public Event(int id)
        {
            String query = "SELECT * FROM [event] WHERE id = " + id + "";
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.botId = r.GetInt32(1);
                this.eventName = r.GetString(2);
                this.eventType = r.GetString(3);
                this.from1 = r.GetInt32(4);
                this.from2 = r.GetInt32(5);
                this.to1 = r.GetInt32(6);
                this.to2 = r.GetInt32(7);
                this.bigger1 = r.GetBoolean(8);
                this.bigger2 = r.GetBoolean(9);
                this.between1 = r.GetBoolean(10);
                this.between2 = r.GetBoolean(11);
                this.playerInMap = r.GetBoolean(12);
            }
            con.conClose();
        }

        public Event()
        {
        }

        public int Id { get => id; set { id = value; } }
        public int BotId { get => botId; set { botId = value; UpdateDb(); } }
        public string EventName { get => eventName; set { eventName = value; UpdateDb(); } }
        public string EventType { get => eventType; set { eventType = value; UpdateDb(); } }
        public int From1 { get => from1; set { from1 = value; UpdateDb(); } }
        public int From2 { get => from2; set { from2 = value; UpdateDb(); } }
        public int To1 { get => to1; set { to1 = value; UpdateDb(); } }
        public int To2 { get => to2; set { to2 = value; UpdateDb(); } }
        public bool Bigger1 { get => bigger1; set { bigger1 = value; UpdateDb(); } }
        public bool Bigger2 { get => bigger2; set { bigger2 = value; UpdateDb(); } }
        public bool Between1 { get => between1; set { between1 = value; UpdateDb(); } }
        public bool Between2 { get => between2; set { between2 = value; UpdateDb(); } }
        public bool PlayerInMap { get => playerInMap; set { playerInMap = value; UpdateDb(); } }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public void UpdateDb()
        {
            if (Program.EventId != -1)
                Program.EventId = Id;
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [event] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("UPDATE [event] SET botId = " + BotId + ", eventName = '" + EventName + "', eventType = '" + EventType + "', from1 = " + From1 + ", from2 = " + from2 + ", to1 = " + to1 + ", to2 = " + to2 + ", bigger1 = " + Bigger1 + ", bigger2 = " + Bigger2 + ", between1 = " + Between1 + ", between2 = " + Between2 + ", playerInMap = " + PlayerInMap + " WHERE [Id] = " + Id + "");
            }
        }

        public void AddEvent()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [event] WHERE id = " + Id + "");
            if (!r.Read())
            {
                con.conClose();
                con.NonQuery("INSERT INTO [event] ([botId], [eventName], [eventType]) VALUES (" + BotId + ", 'NewEventAdded', 'hp')");
                Event s = new Event("NewEventAdded"); //means doesn't exists
                Id = s.Id;
                con.NonQuery("UPDATE [event] SET botId = " + BotId + ", eventName = '" + EventName + "', eventType = '" + EventType + "', from1 = " + From1 + ", from2 = " + from2 + ", to1 = " + to1 + ", to2 = " + to2 + ", bigger1 = " + Bigger1 + ", bigger2 = " + Bigger2 + ", between1 = " + Between1 + ", between2 = " + Between2 + ", playerInMap = " + PlayerInMap + " WHERE [Id] = " + Id + "");

            }
        }

        public void DeleteEvent()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [event] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("DELETE FROM [event] WHERE id = " + Id + "");
            }
        }
    }
}