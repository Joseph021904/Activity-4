using System;
using MySql.Data.MySqlClient;

namespace OOP
{
    class ManageProduct
    {
        public class InsertNewProduct
        {
            private string server = "localhost";
            private string database = "csharpapp";
            private string username = "root";
            private string password = "";
            private string connString;

            public InsertNewProduct()
            {
                connString = $"Server={server};Database={database};User ID={username};Password={password};";
            }

            public bool Login(string username, string password)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);

                            int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                            return userCount > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }

            public void InsertData(string productName, int productPrice, string productDescription)
            {
                if (string.IsNullOrWhiteSpace(productName) || productPrice <= 0 || string.IsNullOrWhiteSpace(productDescription))
                {
                    Console.WriteLine("Product name, price, and description must be provided.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        Console.WriteLine(" ______     ______     __   __     __   __     ______     ______     ______   ______     _____        ______   ______        __    __     __  __     ______     ______     __        \r\n/\\  ___\\   /\\  __ \\   /\\ \"-.\\ \\   /\\ \"-.\\ \\   /\\  ___\\   /\\  ___\\   /\\__  _\\ /\\  ___\\   /\\  __-.     /\\__  _\\ /\\  __ \\      /\\ \"-./  \\   /\\ \\_\\ \\   /\\  ___\\   /\\  __ \\   /\\ \\       \r\n\\ \\ \\____  \\ \\ \\/\\ \\  \\ \\ \\-.  \\  \\ \\ \\-.  \\  \\ \\  __\\   \\ \\ \\____  \\/_/\\ \\/ \\ \\  __\\   \\ \\ \\/\\ \\    \\/_/\\ \\/ \\ \\ \\/\\ \\     \\ \\ \\-./\\ \\  \\ \\____ \\  \\ \\___  \\  \\ \\ \\/\\_\\  \\ \\ \\____  \r\n \\ \\_____\\  \\ \\_____\\  \\ \\_\\\\\"\\_\\  \\ \\_\\\\\"\\_\\  \\ \\_____\\  \\ \\_____\\    \\ \\_\\  \\ \\_____\\  \\ \\____-       \\ \\_\\  \\ \\_____\\     \\ \\_\\ \\ \\_\\  \\/\\_____\\  \\/\\_____\\  \\ \\___\\_\\  \\ \\_____\\ \r\n  \\/_____/   \\/_____/   \\/_/ \\/_/   \\/_/ \\/_/   \\/_____/   \\/_____/     \\/_/   \\/_____/   \\/____/        \\/_/   \\/_____/      \\/_/  \\/_/   \\/_____/   \\/_____/   \\/___/_/   \\/_____/");

                        string query = "INSERT INTO products (productName, productPrice, productDescription) VALUES (@name, @price, @description)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", productName);
                            cmd.Parameters.AddWithValue("@price", productPrice);
                            cmd.Parameters.AddWithValue("@description", productDescription);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            Console.WriteLine(rowsAffected > 0 ? "  __ \\            |                _)                                |                |                                                          _|           |   |           | \r\n  |   |    _` |   __|    _` |       |   __ \\     __|    _ \\    __|   __|    _ \\    _` |        __|   |   |    __|    __|    _ \\    __|    __|   |     |   |   |   |   |   |   | \r\n  |   |   (   |   |     (   |       |   |   |  \\__ \\    __/   |      |      __/   (   |      \\__ \\   |   |   (      (       __/  \\__ \\  \\__ \\   __|   |   |   |   |   |   |  _| \r\n ____/   \\__,_|  \\__|  \\__,_|      _|  _|  _|  ____/  \\___|  _|     \\__|  \\___|  \\__,_|      ____/  \\__,_|  \\___|  \\___|  \\___|  ____/  ____/  _|    \\__,_|  _|  _|  \\__, |  _) \r\n                                                                                                                                                                     ____/      " : "  ____|          _)   |              |       |                _)                                |             |           |               \r\n  |        _` |   |   |    _ \\    _` |       __|    _ \\        |   __ \\     __|    _ \\    __|   __|        _` |    _` |   __|    _` |     \r\n  __|     (   |   |   |    __/   (   |       |     (   |       |   |   |  \\__ \\    __/   |      |         (   |   (   |   |     (   |     \r\n _|      \\__,_|  _|  _|  \\___|  \\__,_|      \\__|  \\___/       _|  _|  _|  ____/  \\___|  _|     \\__|      \\__,_|  \\__,_|  \\__|  \\__,_|  _) \r\n                                                                                                                                          ");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
