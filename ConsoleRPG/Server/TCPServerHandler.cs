using System.Net.Sockets;
using System.Threading;
using ConsoleRPG.Database;
using ConsoleRPG.Player;

namespace ConsoleRPG.Server
{
    public class TCPServerHandler
    {
        public static void ListenUserConnections()
        {
            RPGServer server = new RPGServer();
            TcpListener serverListener = server.Start();
            while (true)
            {
                TcpClient client = serverListener.AcceptTcpClient();
                
                PlayerConnection playerConnection = new PlayerConnection(null, client, Connection.Instance.GetConnectionFromPool());

                Thread clientThread = new Thread(new ThreadStart(playerConnection.ProcessPlayerConnection));
                clientThread.Start();
            }
        }
    }
}