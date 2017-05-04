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
    class CustomerRepository
    {
        private string connString;

        public CustomerRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Customer> RetrieveCustomers()
        {
            IList<Customer> customersList = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM customer";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.Id = reader.GetInt32("Id");
                        customer.FirstName = reader.GetString("FirstName");
                        customer.LastName = reader.GetString("LastName");

                        customersList.Add(customer);
                    }
                }
            }

            return customersList;
        }


        public void AddCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO customer(Id, FirstName, LastName) VALUES(@Id, @FirstName, @LastName)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE customer SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
