using System;

namespace ConsoleRPGClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionToServer connectionToServer = new ConnectionToServer();
            connectionToServer.Connect();
        }
    }
}