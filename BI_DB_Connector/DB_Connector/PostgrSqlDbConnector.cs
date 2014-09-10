using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace DB_Connector
{
    public class PostgrSqlDbConnector
    {
        public NpgsqlConnection GetCon(string conString)
        {
            NpgsqlConnection con = new NpgsqlConnection(conString);
            return con;
        }

    }
}
