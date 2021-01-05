using System;
using ConsoleRPG.Server;

namespace ConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServerHandler.ListenUserConnections();
        }
    }
}