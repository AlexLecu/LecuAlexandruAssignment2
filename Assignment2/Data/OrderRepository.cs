using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Assignment2.Data
{
    class OrderRepository
    {
        private string connString;

        public OrderRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Order> RetrieveOrders()
        {
            IList<Order> orderList = new List<Order>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM orderfurniture";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.Id = reader.GetInt32("Id");
                        order.ShippingAddress = reader.GetString("ShippingAddress");
                        order.DeliveryDate = reader.GetDateTime("DeliveryDate");
                        order.Status = reader.GetString("StatusOrder");
                        order.CustomerId = reader.GetInt32("CustomerId");
                        order.ProductId = reader.GetInt32("ProductId");

                        orderList.Add(order);
                    }
                }
            }

            return orderList;
        }

        public void AddOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO orderfurniture(Id, ShippingAddress, DeliveryDate, StatusOrder, ProductId, CustomerId) VALUES(@Id, @ShippingAddress, @DeliveryDate, @StatusOrder, @ProductId, @CustomerId)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", order.Id);
                cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                cmd.Parameters.AddWithValue("@StatusOrder", order.Status);
                cmd.Parameters.AddWithValue("@ProductId", order.ProductId);
                cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);

                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO report(Id, customerName, orderId) VALUES (@Idr, @customerNamer, @orderIdr)";
                cmd.Parameters.AddWithValue("@Idr", order.Id);
                cmd.Parameters.AddWithValue("@customerNamer", order.ShippingAddress);
                cmd.Parameters.AddWithValue("@orderIdr", order.Id);
            }
        }

        public void UpdateOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE orderfurniture SET ShippingAddress = @ShippingAddress, DeliveryDate = @DeliveryDate, StatusOrder = @StatusOrder, ProductId = @ProductId, CustomerId = @CustomerId  WHERE Id = @Id;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", order.Id);
                cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                cmd.Parameters.AddWithValue("@StatusOrder", order.Status);
                cmd.Parameters.AddWithValue("@ProductId", order.ProductId);
                cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);

                cmd.ExecuteNonQuery();
            }
        }

        public Order GetById(int id)
        {
            Order order = new Order();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM orderfurniture WHERE Id = @Id";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        order.Id = reader.GetInt32("Id");
                        order.ShippingAddress = reader.GetString("ShippingAddress");
                        order.DeliveryDate = reader.GetDateTime("DeliveryDate");
                        order.Status = reader.GetString("StatusOrder");
                        order.CustomerId = reader.GetInt32("CustomerId");
                        order.ProductId = reader.GetInt32("ProductId");
                    }
                }
            }

            return order;
        }
    }
}
