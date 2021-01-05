using System;
using System.Net.Sockets;
using System.Text;
using ConsoleRPG.Database;
using ConsoleRPG.PlayableCreature;
using ConsoleRPG.Player;
using ConsoleRPG.View;
using Npgsql;

namespace ConsoleRPG.Server
{
    public static class ProcessPackets
    {
        public static PC AuthenticationData(in NetworkStream stream, in NpgsqlConnection dbConnection)
        {
            StringBuilder builder = new StringBuilder();
            byte[] packetData = new byte[64];
            int bytes = 0;
            do
            {
                bytes = stream.Read(packetData, 0, packetData.Length - 1);
                builder.Append(Encoding.UTF8.GetString(packetData, 0, bytes));
            }
            while (stream.DataAvailable);

            string[] credentials = builder.ToString().TrimEnd().Split(' ');
            
            AuthenticationData authData = new AuthenticationData(credentials[0], credentials[1]);
            PC playerCDB = DBQueries.GetUser(authData, dbConnection);

            if (playerCDB == null)
            {
                stream.WriteByte((byte) ServerPackets.AUTHENTICATION_STATUS);
                stream.WriteByte((byte) ServerPackets.AUTHENTICATION_FAILED);
            }
            else
            {
                stream.WriteByte((byte) ServerPackets.AUTHENTICATION_STATUS);
                stream.WriteByte((byte) ServerPackets.AUTHENTICATION_SUCCESS);
            }
            
            return playerCDB;
        }

        public static void GetAuthView(in NetworkStream stream)
        {
            stream.WriteByte((byte)ServerPackets.AUTH_VIEW);
            byte[] packetData = Encoding.UTF8.GetBytes(TextViews.AUTH_VIEW);
            stream.Write(packetData, 0, packetData.Length);
        }

        public static void GetRegistrationView(in NetworkStream stream)
        {
            stream.WriteByte((byte)ServerPackets.REGISTRATION_VIEW);
            byte[] packetData = Encoding.UTF8.GetBytes(TextViews.REG_VIEW);
            stream.Write(packetData, 0, packetData.Length);
        }

        public static bool RegisterPlayer(in NetworkStream stream, in NpgsqlConnection dbConnection)
        {
            StringBuilder builder = new StringBuilder();
            byte[] packetData = new byte[64];
            int bytes = 0;
            do
            {
                bytes = stream.Read(packetData, 0, packetData.Length - 1);
                builder.Append(Encoding.UTF8.GetString(packetData, 0, bytes));
            }
            while (stream.DataAvailable);

            string[] credentials = builder.ToString().TrimEnd().Split(' ');
            bool inserted = DBQueries.AddUser(credentials[0], credentials[1], credentials[2], dbConnection);

            if (inserted)
            {
                Console.WriteLine(credentials[1] + " inserted to DB");
                stream.WriteByte((byte) ServerPackets.REGISTRATION_STATUS);
                stream.WriteByte((byte) ServerPackets.REGISTRATION_SUCCESS);
            }
            else
            {
                stream.WriteByte((byte) ServerPackets.REGISTRATION_STATUS);
                stream.WriteByte((byte) ServerPackets.REGISTRATION_FAILED);
            }
            return inserted;
        }
    }
}