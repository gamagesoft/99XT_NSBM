using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DB_Connector
{
    public class MongoDBConnector
    {
        public MongoServer GetCon(string conString)
        {
            MongoServer con = MongoServer.Create(conString);
            return con;
        }
    }
}
