using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DB_Connector;

namespace DBDataReaders
{
    public class MssqlReader
    {
        string conString = "Data Source=GAMAGE;Initial Catalog=bi_framework;Integrated Security=True";
        public void Read()
        {
            Console.WriteLine("Connecting.....");
            MsSqlDBConnector getCon = new MsSqlDBConnector();
            SqlConnection con = getCon.GetCon(conString);
            try
            {
                con.Open();
                Console.WriteLine("Connected\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not connect to MsSql Database\n\n"+e.ToString());
            }
            try
            {
                
                string sql = "select user_id,fname,lname,password from user_login";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader red = cmd.ExecuteReader();
               
                while (red.Read())
                {
                    
                    Console.WriteLine("{0}\t{1}" + " " + "{2}\t{3}", red["user_id"].ToString(), red["fname"].ToString(), red["lname"].ToString(), red["Password"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong with Database..."+e.ToString());
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
