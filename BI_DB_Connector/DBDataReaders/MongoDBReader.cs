using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using DB_Connector;

namespace DBDataReaders
{
    public class MongoDBReader
    {
        public void read()
        {
            Console.WriteLine("Connecting....");
            string conString = "mongodb://localhost";
            MongoDBConnector getCon = new MongoDBConnector();
            MongoServer con = getCon.GetCon(conString);
            try
            {
                con.Connect();
                Console.WriteLine("Connected\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nCan not Connect to MongoDB..!!!!\n\n"+e.ToString());
            }
            try
            {
                var db = con.GetDatabase("test");
                using (con.RequestStart(db))
                {
                    var collection = db.GetCollection<BsonDocument>("user_login");
                    var query = new QueryDocument();

                    foreach (BsonDocument record in collection.Find(query))
                    {
                        BsonElement Id = record.GetElement("id");
                        BsonElement Fname = record.GetElement("fname");
                        BsonElement Lname = record.GetElement("lname");
                        BsonElement Password = record.GetElement("password");

                        Console.WriteLine("{0}\t{1}" + " " + "{2}\t{3}", Id.Value.ToString(), Fname.Value.ToString(), Lname.Value.ToString(), Password.Value.ToString());
                        //Console.WriteLine("{0}\t{1}" + " " + "{2}\t{3}", record.GetElement("id").ToString(), record.GetElement("fname").ToString(), record.GetElement("lname").ToString(), record.GetElement("password").ToString());


                        ////get element at a time
                        //foreach (BsonElement element in record.Elements)
                        //{
                        //    Console.Write("{0}\t", element.Value.ToString());
                        //}
                        //Console.WriteLine("\n");

                        ////--get to arraylist
                        //ArrayList records = new ArrayList();
                        //records.Add(record.GetElement("id"));
                        //records.Add(record.GetElement("fname"));
                        //records.Add(record.GetElement("lname"));
                        //records.Add(record.GetElement("password"));
                        ////Print by arrayList
                        //for(int i=0;i<records.Count;i++)
                        //{
                        //    Console.Write("{0}\t", records[i].ToString());
                        //}
                        //Console.WriteLine("\n");

                    }
                    con.Disconnect();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something Wrong with Database..\n" + e.ToString());
            }
            finally
            {
                if(con.State == MongoServerState.Connected)
                {
                    con.Disconnect();
                }
            }
        }
    }
}
