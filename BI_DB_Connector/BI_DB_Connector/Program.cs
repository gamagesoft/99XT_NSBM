using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBDataReaders;


namespace BI_DB_Connector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n----------MySql Database------------\n\n");
            MysqlReader myDBReader = new MysqlReader();
            myDBReader.Read();
            Console.WriteLine("\n\n----------MsSql Database------------\n\n");
            MssqlReader msDBReader = new MssqlReader();
            msDBReader.Read();
            Console.WriteLine("\n\n----------Mongo Database------------\n\n");
            MongoDBReader mongoDBReader = new MongoDBReader();
            mongoDBReader.read();
            Console.WriteLine("\n\n----------PostgreSql Database------------\n\n");
            PostgresqlDBReader r = new PostgresqlDBReader();
            r.Read();
            
        }
    }
}
