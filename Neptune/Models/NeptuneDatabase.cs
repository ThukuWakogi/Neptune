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
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }

            return positionsToReturn;
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
                    Position = positions.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["position_id"])),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }

            return WorkersToReturn;
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
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }

            return returningCustomers;
        }

        public static async Task<ObservableCollection<MaterialCategory>> RetrieveMaterialCategoriesAsync(ObservableCollection<Modifier> modifiers)
        {
            ObservableCollection<MaterialCategory> returningMaterialCategories = new ObservableCollection<MaterialCategory>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, category, date_added, added_by, date_last_updated, last_updated_by FROM neptune.material_categories WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) returningMaterialCategories.Add(new MaterialCategory
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Category = reader["category"].ToString(),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }

            return returningMaterialCategories;
        }

        public static async Task RetrieveMaterialsAsync(ObservableCollection<Modifier> modifiers, ObservableCollection<MaterialCategory> materialCategories)
        {
            using(MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, material, material_category_id, quantity, depletion_alert_level, date_added, added_by, date_last_updated, last_updated_by FROM neptune.materials WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) materialCategories.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["material_category_id"])).Materials.Add(new Material
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["material"].ToString(),
                    Quantity = Convert.ToDecimal(reader["quantity"]),
                    DepletionAlertLevel = Convert.ToDecimal(reader["depletion_alert_level"]),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }
        }

        public static async Task<ObservableCollection<FlyPattern>> RetrieveFlyPatternsAsync(ObservableCollection<Modifier> modifiers)
        {
            ObservableCollection<FlyPattern> returningFlyPatterns = new ObservableCollection<FlyPattern>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, fly_pattern, date_added, added_by, date_last_updated, last_updated_by FROM neptune.fly_patterns where deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) returningFlyPatterns.Add(new FlyPattern
                {
                    Id = Convert.ToInt32(reader["id"]),
                    FlyPatternName = reader["fly_pattern"].ToString(),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }

            return returningFlyPatterns;
        }

        public static async Task<ObservableCollection<Fly>> RetrieveFliesAsync(ObservableCollection<Modifier> modifiers, ObservableCollection<FlyPattern> flypatterns)
        {
            ObservableCollection<Fly> returningFlies = new ObservableCollection<Fly>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, fly_number, fly, fly_pattern, date_added, added_by, date_last_updated, last_updated_by FROM neptune.flies WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) returningFlies.Add(new Fly
                {
                    Id = Convert.ToInt32(reader["id"]),
                    FlyNumber = reader["fly_number"].ToString(),
                    FlyName = reader["fly"].ToString(),
                    FlyPattern = flypatterns.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["fly_pattern"])),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"])),
                });

                reader.Close();
                CloseConnection();
            }

            return returningFlies;
        }

        public static async Task RetrieveFlyMaterialsAsync(ObservableCollection<Modifier> modifiers, ObservableCollection<FlyPattern> flyPatterns, ObservableCollection<Fly> flies, ObservableCollection<MaterialCategory> materialCategories)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT fly_materials.id AS id, fly_id, material_id, material_category_id, part, fly_materials.date_added AS date_added, fly_materials.added_by AS added_by, fly_materials.date_last_updated AS date_last_updated , fly_materials.last_updated_by AS last_updated_by FROM neptune.fly_materials, neptune.materials WHERE fly_materials.deleted = 0 AND fly_materials.material_id = materials.id;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;
                
                while (reader.Read()) flies.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["fly_id"])).Materials.Add(new FlyMaterial
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Material = new MaterialCategory().Materials.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["material_id"])),
                    FlyPart = reader["part"].ToString(),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"]))
                });

                reader.Close();
                CloseConnection();
            }
        }

        public static async Task<ObservableCollection<Order>> RetrieveOrdersAsync(ObservableCollection<Modifier> modifiers, ObservableCollection<Customer> customers)
        {
            ObservableCollection<Order> returningOrders = new ObservableCollection<Order>();

            using(MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, customer_id, date_added, added_by, date_last_updated, last_updated_by FROM neptune.orders WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read())
                {
                    returningOrders.Add(new Order
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Customer = customers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["customer_id"])),
                        DateAdded = Convert.ToDateTime(reader["date_added"]),
                        AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                        DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                        LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"]))
                    });
                }

                reader.Close();
                CloseConnection();
            }

            return returningOrders;
        }

        public static async Task RetrieveOrderItemsAsync(ObservableCollection<Modifier> modifiers, ObservableCollection<Order> orders, ObservableCollection<Fly> flies)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, order_id, fly_id, fly_size, dozens, is_complete, date_added, added_by, date_last_updated, last_updated_by FROM neptune.order_items WHERE deleted = 0;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read()) orders.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["order_id"])).OrderItems.Add(new OrderItem
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Fly = flies.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["fly_id"])),
                    FlySize = Convert.ToInt32(reader["fly_size"]),
                    Dozens = Convert.ToInt32(reader["dozens"]),
                    IsComplete = Convert.ToBoolean(reader["is_complete"]),
                    DateAdded = Convert.ToDateTime(reader["date_added"]),
                    AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                    DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                    LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"]))
                });

                reader.Close();
                CloseConnection();
            }
        }

        public static async Task<ObservableCollection<JobCard>> RetrieveJobCardsAsync(ObservableCollection<Order> orders, ObservableCollection<Worker> workers, ObservableCollection<Modifier> modifiers)
        {
            ObservableCollection<JobCard> returningJobCards = new ObservableCollection<JobCard>();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT jobcards.id AS id, order_items.order_id AS order_id, order_item, jobcards.dozens AS dozens, qa, tier, tie_complete_date, packer, pack_complete_date, jobcards.date_added AS date_added, jobcards.added_by AS added_by, jobcards.date_last_updated AS date_last_updated, jobcards.last_updated_by AS last_updated_by FROM neptune.jobcards, neptune.order_items WHERE jobcards.deleted = 0 AND jobcards.order_item = order_items.id;";
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read())
                {
                    returningJobCards.Add(new JobCard
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        OrderItem = orders.FirstOrDefault(x => x.Id == Convert.ToInt32(reader["order_id"])).OrderItems.FirstOrDefault(x => x.Id == Convert.ToInt32(reader["order_item"])),
                        Dozens = Convert.ToInt32(reader["dozens"]),
                        Qa = workers.FirstOrDefault(x => x.Id == Convert.ToInt32(reader["qa"])),
                        Tier = workers.FirstOrDefault(x => x.Id == Convert.ToInt32(reader["tier"])),
                        TieDateCompleted = Convert.IsDBNull(reader["tie_complete_date"]) ? default(DateTime) : Convert.ToDateTime(reader["tie_complete_date"]),
                        Packer = workers.FirstOrDefault(x => x.Id == Convert.ToInt32(reader["packer"])),
                        PackDateComplete = Convert.IsDBNull(reader["pack_complete_date"]) ? default(DateTime) : Convert.ToDateTime(reader["pack_complete_date"]),
                        DateAdded = Convert.ToDateTime(reader["date_added"]),
                        AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"])),
                        DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]),
                        LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"]))
                    });
                }

                reader.Close();
                CloseConnection();
            }

            return returningJobCards;
        }

        public static async Task<bool> UpdatePositionRecordAsync(Worker updatingWorker, Position positionToUpdate, decimal salary)
        {
            bool updated = false;

            using(MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    await OpenConnectionAsync();
                    cmd.CommandText = "UPDATE `neptune`.`positions` SET `salary` = @salary, `date_last_updated` = CURRENT_TIMESTAMP, `last_updated_by` = @editingWorkerId WHERE (`id` = @positionBeingUpdated);";
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@editingWorkerId", updatingWorker.Id);
                    cmd.Parameters.AddWithValue("@positionBeingUpdated", positionToUpdate.Id);
                    cmd.Connection = connect;
                    await cmd.ExecuteNonQueryAsync();
                    await new MessageDialog($"{positionToUpdate.PositionName} salary updated").ShowAsync();
                    updated = true;
                }
                catch (MySqlException e)
                {
                    await new MessageDialog($"Error: {e.Message}").ShowAsync();
                }

                CloseConnection();
            }
            return updated;
        }

        public static async Task<bool> UpdateWorkerRecordAsync(
            Worker workerInUpdating, 
            Worker updatingWorker, 
            string firstName, 
            string lastName, 
            string phoneNumber, 
            Position position)
        {
            bool updated = false;

            using(MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    await OpenConnectionAsync();
                    cmd.CommandText = "UPDATE `neptune`.`workers` SET `first_name` = @firstName, `last_name` = @lastName, `phone_number` = @phoneNumber, `position_id` = @positionId, `date_last_updated` = CURRENT_TIMESTAMP, `last_updated_by` = @updatingUser WHERE (`id` = @workerInUpdating);";
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@positionId", position.Id);
                    cmd.Parameters.AddWithValue("@updatingUser", updatingWorker.Id);
                    cmd.Parameters.AddWithValue("@workerInUpdating", workerInUpdating.Id);
                    cmd.Connection = connect;
                    await cmd.ExecuteNonQueryAsync();
                    updated = true;
                }
                catch (MySqlException e)
                {
                    await new MessageDialog($"Error: {e.Message}").ShowAsync();

                }

                CloseConnection();
            }

            return updated;
        }

        public static async Task RetrieveWorkerAsync(Worker workerRequested, ObservableCollection<Worker> workers, ObservableCollection<Modifier> modifiers, ObservableCollection<Position> positions)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                await OpenConnectionAsync();
                cmd.CommandText = "SELECT id, first_name, last_name, phone_number, position_id, date_added, added_by, date_last_updated, last_updated_by FROM neptune.workers WHERE deleted = 0 AND id = @id;";
                cmd.Parameters.AddWithValue("@id", workerRequested.Id);
                cmd.Connection = connect;
                MySqlDataReader reader = await cmd.ExecuteReaderAsync() as MySqlDataReader;

                while (reader.Read())
                {
                    workers.First(x => x.Id == workerRequested.Id).FirstName = reader["first_name"].ToString();
                    workers.First(x => x.Id == workerRequested.Id).LastName = reader["last_name"].ToString();
                    workers.First(x => x.Id == workerRequested.Id).PhoneNumber = reader["phone_number"].ToString();
                    workers.First(x => x.Id == workerRequested.Id).Position = positions.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["position_id"]));
                    workers.First(x => x.Id == workerRequested.Id).DateAdded = Convert.ToDateTime(reader["date_added"]);
                    workers.First(x => x.Id == workerRequested.Id).AddedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["added_by"]));
                    workers.First(x => x.Id == workerRequested.Id).DateLastUpdated = Convert.ToDateTime(reader["date_last_updated"]);
                    workers.First(x => x.Id == workerRequested.Id).LastUpdatedBy = modifiers.FirstOrDefault(p => p.Id == Convert.ToInt32(reader["last_updated_by"]));
                }

                reader.Close();
                CloseConnection();
            }
        }
    }
}
