using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DB_Connector
{
    public class MsSqlDBConnector
    {
        public SqlConnection GetCon(string conString)
        {
            SqlConnection con = new SqlConnection(conString);
            return con;
        }
    }
}
