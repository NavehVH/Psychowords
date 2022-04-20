using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMKB.App_Data;

namespace AMKB.Classes
{
    class ScreenShot
    {
        private int id;
        private int botId;
        private String capture;
        private int xUpperLeftCornerSource;
        private int yUpperLeftCornerSource;
        private int xUpperLeftCornerDestination;
        private int yUpperLeftCornerDestination;
        private int pictureHeight;
        private int pictureWidth;

        public ScreenShot(int botId, String capture)
        {
            if (capture == "player position" || capture == "player in map")
                capture = "map";
            String query = "SELECT * FROM screenshot WHERE botId = " + botId + " AND capture = '" + capture + "'";
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader(query);
            if (r.Read())
            {
                this.id = r.GetInt32(0);
                this.botId = r.GetInt32(1);
                this.capture = r.GetString(2);
                this.xUpperLeftCornerSource = r.GetInt32(3);
                this.yUpperLeftCornerSource = r.GetInt32(4);
                this.xUpperLeftCornerDestination = r.GetInt32(5);
                this.yUpperLeftCornerDestination = r.GetInt32(6);
                this.pictureHeight = r.GetInt32(7);
                this.pictureWidth = r.GetInt32(8);
            }
            con.conClose();
        }

        public ScreenShot()
        {

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; UpdateDb(); }
        }

        public int BotId
        {
            get { return this.botId; }
            set { this.botId = value; UpdateDb(); }
        }

        public String Capture
        {
            get { return this.capture; }
            set { this.capture = value; UpdateDb(); }
        }

        public int XUpperLeftCornerSource
        {
            get { return this.xUpperLeftCornerSource; }
            set { this.xUpperLeftCornerSource = value; UpdateDb(); }
        }

        public int YUpperLeftCornerSource
        {
            get { return this.yUpperLeftCornerSource; }
            set { this.yUpperLeftCornerSource = value; UpdateDb(); }
        }

        public int XUpperLeftCornerDestination
        {
            get { return this.xUpperLeftCornerDestination; }
            set { this.xUpperLeftCornerDestination = value; UpdateDb(); }
        }

        public int YUpperLeftCornerDestination
        {
            get { return this.yUpperLeftCornerDestination; }
            set { this.yUpperLeftCornerDestination = value; UpdateDb(); }
        }

        public int PictureHeight
        {
            get { return this.pictureHeight; }
            set { this.pictureHeight = value; UpdateDb(); }
        }

        public int PictureWidth
        {
            get { return this.pictureWidth; }
            set { this.pictureWidth = value; UpdateDb(); }
        }

        public void UpdateDb()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [screenshot] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("UPDATE [screenshot] SET [botId] = " + BotId + ", [capture] = '" + Capture + "', [xUpperLeftCornerSource] = " + XUpperLeftCornerSource + ", [yUpperLeftCornerSource] = " + YUpperLeftCornerSource + ", [xUpperLeftCornerDestination] = " + XUpperLeftCornerDestination + ", [yUpperLeftCornerDestination] = " + YUpperLeftCornerDestination + ", [pictureHeight] = " + PictureHeight + ", [pictureWidth] = " + PictureWidth + " WHERE [Id] = " + Id + "");
            }
        }

        public void AddScreenShot()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [screenshot] WHERE id = " + Id + "");
            if (!r.Read())
            {
                if (capture == "player position" || capture == "player in map")
                    Capture = "map";
                con.conClose();
                con.NonQuery("INSERT INTO [screenshot] ([botId], [capture]) VALUES (" + BotId + ", '" + Capture + "')");
                ScreenShot s = new ScreenShot(BotId, Capture);
                Id = s.Id;
                
                con.NonQuery("UPDATE [screenshot] SET [botId] = " + BotId + ", [capture] = '" + Capture + "', [xUpperLeftCornerSource] = " + XUpperLeftCornerSource + ", [yUpperLeftCornerSource] = " + YUpperLeftCornerSource + ", [xUpperLeftCornerDestination] = " + XUpperLeftCornerDestination + ", [yUpperLeftCornerDestination] = " + YUpperLeftCornerDestination + ", [pictureHeight] = " + PictureHeight + ", [pictureWidth] = " + PictureWidth + " WHERE [Id] = " + Id + "");
            }
        }

        public void DeleteScreenShot()
        {
            Connection con = new Connection("maple_data");
            OleDbDataReader r = con.getDataReader("SELECT * FROM [screenshot] WHERE id = " + Id + "");
            if (r.Read())
            {
                con.conClose();
                con.NonQuery("DELETE FROM [screenshot] WHERE id = " + Id + "");
            }
        }
    }
}
