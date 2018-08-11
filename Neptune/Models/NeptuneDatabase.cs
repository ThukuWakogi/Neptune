using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Neptune.Models
{
    public static class NeptuneDatabase
    {
        private static readonly string conn = "Server=localhost;Database=neptune;Uid=client;Pwd=client;";
        private static MySqlConnection connect = new MySqlConnection(conn);

        public static async Task OpenConnectionAsync()
        {
            try
            {
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
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, password, salt FROM neptune.credentials WHERE id = @id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;
                //MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) if (Security.HashSHA1(password + reader["salt"].ToString()) == reader["password"].ToString()) authenticate = true;

                reader.Close();
                CloseConnection();
            }

            return authenticate;
        }

        public static async Task<ObservableCollection<Modifier>> RetrieveModifiersAsync()
        {
            ObservableCollection<Modifier> modifiersToReturn = new ObservableCollection<Modifier>();

            using (MySqlCommand cmd = new MySqlCommand())
            {

                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, first_name, last_name, phone_number FROM neptune.workers WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) modifiersToReturn.Add(new Modifier
                {
                    Id = Convert.ToInt32(reader["id"]),
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString()
                });

                reader.Close();
                CloseConnection();
            }

            return modifiersToReturn;
        }

        public static async Task<ObservableCollection<Position>> RetrievePositionsAsync(ObservableCollection<Modifier> modifiers)
        {
            ObservableCollection<Position> positionsToReturn = new ObservableCollection<Position>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, position, salary, date_added, added_by, date_last_updated, last_updated_by FROM neptune.positions;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) positionsToReturn.Add(new Position
                {
                    Id = Convert.ToInt32(reader["id"]),
                    PositionName = reader["position"].ToString(),
                    Salary = Convert.ToDecimal(reader["salary"]),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = ModifierSelector(Convert.ToInt32(reader["added_by"]), modifiers),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = ModifierSelector(Convert.ToInt32(reader["last_updated_by"]), modifiers)
                });

                reader.Close();
                CloseConnection();
            }

            return positionsToReturn;
        }

        private static Modifier ModifierSelector(int id, ObservableCollection<Modifier> modifiers)
        {
            Modifier modifierToReturn = new Modifier();

            foreach (var modifier in modifiers) if (modifier.Id == id) modifierToReturn = modifier;

            return modifierToReturn;
        }

        public static async Task<ObservableCollection<Worker>> RetreiveWorkersAsync(ObservableCollection<Modifier> modifiers, ObservableCollection<Position> positions)
        {
            ObservableCollection<Worker> WorkersToReturn = new ObservableCollection<Worker>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, first_name, last_name, phone_number, position_id, date_added, added_by, date_last_updated, last_updated_by FROM neptune.workers WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) WorkersToReturn.Add(new Worker
                {
                    Id = Convert.ToInt32(reader["id"]),
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString(),
                    Position = PositionSelector(Convert.ToInt32(reader["id"]), positions),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = ModifierSelector(Convert.ToInt32(reader["added_by"]), modifiers),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = ModifierSelector(Convert.ToInt32(reader["last_updated_by"]), modifiers)
                });

                reader.Close();
                CloseConnection();
            }

            return WorkersToReturn;
        }

        private static Position PositionSelector(int id, ObservableCollection<Position> positions)
        {
            Position returningPosition = new Position();

            foreach (var position in positions) if (position.Id == id) returningPosition = position;

            return returningPosition;
        }

        public static Worker WorkerSelector(int id, ObservableCollection<Worker> workers)
        {
            Worker returningWorker = new Worker();

            foreach (var worker in workers) if (worker.Id == id) returningWorker = worker;

            return returningWorker;
        }

        public static async Task<ObservableCollection<Customer>> RetrieveCustomersAsync(ObservableCollection<Modifier> modifiers)
        {
            ObservableCollection<Customer> returningCustomers = new ObservableCollection<Customer>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, first_name, last_name, email, date_added, added_by, date_last_updated, last_updated_by, deleted FROM neptune.customers WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) returningCustomers.Add(new Customer
                {
                    Id = Convert.ToInt32(reader["id"]),
                    FirstName = reader["first_name"].ToString(),
                    LastName = reader["last_name"].ToString(),
                    Email = reader["email"].ToString(),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = ModifierSelector(Convert.ToInt32(reader["added_by"]), modifiers),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = ModifierSelector(Convert.ToInt32(reader["last_updated_by"]), modifiers)
                });

                reader.Close();
                CloseConnection();
            }

            return returningCustomers;
        }
    }
}
