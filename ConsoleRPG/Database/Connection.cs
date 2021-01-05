using System;
using Npgsql;

namespace ConsoleRPG.Database
{
    public class Connection
    {
        private static Connection _instance;
        public static Connection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Connection();
                }
                return _instance; 
            }
        }
       
        private Connection() { }

        public NpgsqlConnection GetConnectionFromPool()
        {
            return new NpgsqlConnection(DBConfig.CONNECTION_STRING);
        }
    }
}