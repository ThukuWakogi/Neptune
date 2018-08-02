using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Neptune.Models
{
    public static class NeptuneDatabase
    {
        private static readonly string conn = "Server=localhost;Database=neptune;Uid=root;Pwd=root;";
        private static MySqlConnection connect;

        public static async Task OpenConnection()
        {
            try
            {
                connect = new MySqlConnection(conn);
                await connect.OpenAsync();
            }
            catch (MySqlException e)
            {
                await new MessageDialog(e.Message).ShowAsync();
            }
        }

        public static void CloseConnection() => connect.Close();

        public static async Task<bool> AuthenticatedAsync(int id, string password)
        {
            bool authenticate = false;

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnection();
                cmd.CommandText = "SELECT id, password, salt FROM neptune.credentials WHERE id = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connect;
                //MySqlDataReader reader = (await cmd.ExecuteReaderAsync() as MySqlDataReader);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) if (Security.HashSHA1(password + reader["salt"].ToString()) == reader["password"].ToString()) authenticate = true;

                CloseConnection();
            }

            return authenticate;
        }
    }
}
