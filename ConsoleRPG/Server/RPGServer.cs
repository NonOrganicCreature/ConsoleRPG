using System.Net;
using System.Net.Sockets;

namespace ConsoleRPG.Server
{
    public class RPGServer
    {
        private TcpListener _listener;

        public TcpListener Listener
        {
            get => _listener;
            set => _listener = value;
        }

        public TcpListener Start()
        {
            IPAddress localAddr = IPAddress.Parse(ServerConfig.IPADDRESS);
            int port = ServerConfig.PORT;
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();
            _listener = server;
            return server;
        }
    }
}