using System;
using Npgsql;
using ConsoleRPG.Player;
namespace ConsoleRPG.Database
{
    public static class DBQueries
    {
        public static bool AddUser(string name, string login, string password, NpgsqlConnection conn)
        {
            bool result;
            using (var command = new NpgsqlCommand("INSERT INTO PLAYER (name, login, password) VALUES (@n, @l, @p)", conn))
            {
                command.Parameters.AddWithValue("n", name);
                command.Parameters.AddWithValue("l", login);
                command.Parameters.AddWithValue("p", password);
                int nRows = command.ExecuteNonQuery();
                result = nRows > 0;
            }
            return result;
        }

        public static PlayerC GetUser(AuthenticationData authData, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand("SELECT * FROM PLAYER WHERE login = @l AND password = @p", conn))
            {
                command.Parameters.AddWithValue("l", authData.Login);
                command.Parameters.AddWithValue("p", authData.Password);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    long id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int level = reader.GetInt32(2);
                    float exp = reader.GetFloat(3);
                    int hp = reader.GetInt32(6);
                    int mp = reader.GetInt32(7);
                    int stamina = reader.GetInt32(8);
                    int meleeDamage = reader.GetInt32(9);
                    int rangeDamage = reader.GetInt32(10);
                    int mageDamage = reader.GetInt32(11);
                    return new PlayerC(
                            id,
                            name,
                            level,
                            exp,
                            new PlayerCStats(hp, mp, stamina, meleeDamage, rangeDamage, mageDamage),
                            null, // later
                            authData
                        );
                }

                return null;
            }
            
        }
    }
}