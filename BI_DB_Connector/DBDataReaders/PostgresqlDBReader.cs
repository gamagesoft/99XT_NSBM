using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Connector;
using Npgsql;

namespace DBDataReaders
{
    public class PostgresqlDBReader
    {
        public void Read()
        {

            Console.WriteLine("Connecting....");
            string connstring = "User ID=postgres;Password=19657312;Host=localhost;Port=5432;Database=bi_framework;";
            //"Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";
            PostgrSqlDbConnector getCon = new PostgrSqlDbConnector();
            NpgsqlConnection con = getCon.GetCon(connstring);
            try
            {
                con.Open();
                Console.WriteLine("Connected\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not Connect to the database..!!!\n" + e.ToString());
            }
            try
            {
                string query = "select * from user_login.user_login";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader red = cmd.ExecuteReader();
                while (red.Read())
                {

                    Console.WriteLine("{0}\t{1}" + " " + "{2}\t{3}", red["user_id"].ToString(), red["fname"].ToString(), red["lname"].ToString(), red["Password"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong with Database..\n"+e.ToString());
            }
        }
    }
}
