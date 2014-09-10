using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB_Connector
{
    public class MySqlDBConnector
    {
        public MySqlConnection GetCon(string conString)
        {
            MySqlConnection con = new MySqlConnection(conString);
            return con;
        }
    }
}
