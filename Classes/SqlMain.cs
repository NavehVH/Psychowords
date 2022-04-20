using MySql.Data.MySqlClient;
using Psychometric.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Psychometric.Classes
{
    public class SqlMain
    {
        public int id;
        public SqlMain()
        {
        }

        public bool Exists()
        {
            if (this.id != 0)
                return true;
            return false;
        }
    }
}



//ALTER TABLE psychometry_data.associations MODIFY COLUMN association VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL;