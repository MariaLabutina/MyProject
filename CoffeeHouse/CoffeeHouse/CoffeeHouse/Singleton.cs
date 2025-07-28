using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CoffeeHouse
{
    public class Singleton
    {
        public string connectString;
        private static Singleton instance;
        public OleDbConnection myConn;
        private Singleton() { }
        //реализация подключения к бд через singleton
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public OleDbConnection Connection()
        {
            connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\User\\Desktop\\жизнь\\программист новичек\\CoffeeHouse\\CoffeeHouse\\CoffeeHouse.mdb;";
            myConn = new OleDbConnection(connectString);
            myConn.Open();
            return myConn;
        }


    }
}
