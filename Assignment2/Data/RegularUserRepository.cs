using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using Assignment2.Models;

namespace Assignment2.Data
{
    class RegularUserRepository
    {
        private string connString;

        public RegularUserRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<RegularUser> RetrieveRegularUsers()
        {
            IList<RegularUser> regularUsersList = new List<RegularUser>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM regularuser";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RegularUser regularUser = new RegularUser();
                        regularUser.Id = reader.GetInt32("Id");
                        regularUser.UserName = reader.GetString("UserName");
                        regularUser.Password = reader.GetString("Password");

                        regularUsersList.Add(regularUser);
                    }
                }
            }

            return regularUsersList;
        }

        public RegularUser GetUser(string userName)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM regularUser where UserName=\"" + userName + "\";";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    {
                        RegularUser user = new RegularUser();
                        user.Id = reader.GetInt32("Id");
                        user.UserName = reader.GetString("UserName");
                        user.Password = reader.GetString("Password");

                        return user;
                    }
                }
            }

            return null;
        }

        public void AddUser(RegularUser user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO regularUser(Id, UserName, Password) VALUES(@Id, @UserName, @Password)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(RegularUser regularUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE regularuser SET UserName = @UserName, Password = @Password WHERE Id = @Id;";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", regularUser.Id);
                cmd.Parameters.AddWithValue("@UserName", regularUser.UserName);
                cmd.Parameters.AddWithValue("@Password", regularUser.Password);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(RegularUser regularUser)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM regularuser WHERE Id=@Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", regularUser.Id);
                cmd.Parameters.AddWithValue("@UserName", regularUser.UserName);
                cmd.Parameters.AddWithValue("@Password", regularUser.Password);


                cmd.ExecuteNonQuery();
            }
        }

        public RegularUser GetById(int id)
        {
            RegularUser regularUser = new RegularUser();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM regularuser WHERE Id = @Id";

                MySqlCommand cmd = new MySqlCommand(statement, conn);

                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regularUser.Id = reader.GetInt32("Id");
                        regularUser.UserName = reader.GetString("UserName");
                        regularUser.Password = reader.GetString("Password");
                    }
                }
            }

            return regularUser;
        }
    }
}
