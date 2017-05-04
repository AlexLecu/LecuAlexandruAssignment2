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
    public class AdminRepository
    {
        private string connString;

        public AdminRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Admin> RetrieveAdmins()
        {
            IList<Admin> adminsList = new List<Admin>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM administrator";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Admin admin = new Admin();
                        admin.Id = reader.GetInt32("Id");
                        admin.UserName = reader.GetString("UserName");
                        admin.Password = reader.GetString("Password");

                        adminsList.Add(admin);
                    }
                }
            }

            return adminsList;
        }

        public Admin GetAdmin(string userName)
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
                        Admin admin = new Admin();
                        admin.Id = reader.GetInt32("Id");
                        admin.UserName = reader.GetString("UserName");
                        admin.Password = reader.GetString("Password");

                        return admin;
                    }
                }
            }

            return null;
        }

        public void AddAdmin(Admin admin)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO administrator(Id, UserName, Password) VALUES(@Id, @UserName, @Password)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", admin.Id);
                cmd.Parameters.AddWithValue("@UserName", admin.UserName);
                cmd.Parameters.AddWithValue("@Password", admin.Password);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
