using System;
using System.Net.Sockets;
using System.Text;

namespace ConsoleRPGClient
{
    public class ConnectionToServer
    {
        private UserConnectionData _userConnectionData;
        private TcpClient _tcpClient;
        
        public UserConnectionData UserConnectionData
        {
            get => _userConnectionData;
            set => _userConnectionData = value;
        }

        public TcpClient TcpClient
        {
            get => _tcpClient;
            set => _tcpClient = value;
        }

        public ConnectionToServer()
        {
            _userConnectionData = new UserConnectionData(null, null, false);
        }

        public void Connect()
        {
            try
            {
                _tcpClient = new TcpClient(ClientConfig.IP_ADDRESS, ClientConfig.PORT);
                
                NetworkStream stream = _tcpClient.GetStream();
                byte[] packetData = new byte[64];
                while (true)
                {
                    if (!_userConnectionData.IsAuthenticated || 
                        _userConnectionData.Login != null && _userConnectionData.Password != null)
                    {
                        stream.WriteByte((byte)ClientPackets.GET_AUTH_VIEW);
                        int packetId = stream.ReadByte();
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        do
                        {
                            bytes = stream.Read(packetData, 0, packetData.Length - 1);
                            builder.Append(Encoding.UTF8.GetString(packetData, 0, bytes));
                        }
                        while (stream.DataAvailable);
                        Console.WriteLine(builder.ToString());
                        string credentials = Console.ReadLine().TrimEnd();
                        Console.Clear();
                        if (credentials == "SignUp")
                        {
                            builder.Clear();
                            stream.WriteByte((byte)ClientPackets.REGISTRATION_VIEW);
                            packetId = stream.ReadByte();
                            bytes = 0;
                            do
                            {
                                bytes = stream.Read(packetData, 0, packetData.Length - 1);
                                builder.Append(Encoding.UTF8.GetString(packetData, 0, bytes));
                            }
                            while (stream.DataAvailable);
                            
                            Console.WriteLine(builder.ToString());

                            string registrationData = Console.ReadLine().TrimEnd();
                            stream.WriteByte((byte) ClientPackets.REGISTRATION_DATA);
                            stream.Write(Encoding.UTF8.GetBytes(registrationData), 0, registrationData.Length);
                            Console.Clear();

                            packetId = stream.ReadByte();
                            if (packetId == (int) ClientPackets.REGISTRATION_STATUS)
                            {
                                int status = stream.ReadByte();
                                if (status == 0x01)
                                {
                                    _userConnectionData.IsAuthenticated = true;
                                }
                            }
                            continue;
                        }
                        stream.WriteByte((byte)ClientPackets.AUTHENTICATION_DATA);
                        byte[] credentialsPacketData = Encoding.UTF8.GetBytes(credentials); 
                        stream.Write(credentialsPacketData, 0, credentialsPacketData.Length);

                        packetId = stream.ReadByte();
                        
                        
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _tcpClient.Close();
            }
        }
    }
}