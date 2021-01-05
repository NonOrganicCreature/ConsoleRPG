using System;
using System.Net.Sockets;
using System.Text;
using ConsoleRPG.PlayableCreature;
using ConsoleRPG.Server;
using ConsoleRPG.View;
using Npgsql;

namespace ConsoleRPG.Player
{
    public class PlayerConnection
    {
        private PC _playerRef;
        private TcpClient _client;
        private NpgsqlConnection _dbConnection;

        public PlayerConnection(PC playerRef, TcpClient client, NpgsqlConnection dbConnection)
        {
            _playerRef = playerRef;
            _client = client;
            _dbConnection = dbConnection;
        }

        public void ProcessPlayerConnection()
        {
            NetworkStream stream = null;
            _dbConnection.Open();
            try
            {
                stream = _client.GetStream();
                while (true)
                {
                    int packetType = stream.ReadByte();
                    switch (packetType)
                    {
                        case (int) ServerPackets.AUTH_VIEW:
                        {
                            ProcessPackets.GetAuthView(stream);
                        }
                        break;
                        
                        case (int) ServerPackets.AUTHENTICATION_DATA:
                        {
                            _playerRef = ProcessPackets.AuthenticationData(stream, _dbConnection);
                        }
                        break;

                        case (int) ServerPackets.REGISTRATION_VIEW:
                        {
                            ProcessPackets.GetRegistrationView(stream);
                        }
                        break;

                        case (int) ServerPackets.REGISTRATION_DATA:
                        {
                            ProcessPackets.RegisterPlayer(stream, _dbConnection);
                        }
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (_client != null)
                    _client.Close();
                if (_client != null)
                    _dbConnection.Close();
            }
        }
    }
}