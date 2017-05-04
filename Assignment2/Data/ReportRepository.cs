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
    public class ReportRepository
    {
        private string connString;

        public ReportRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        }

        public IList<Report> RetrieveReports()
        {
            IList<Report> reports = new List<Report>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM report";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Report report = new Report();
                        report.Id = reader.GetInt32("Id");
                        report.customerName = reader.GetString("customerName");
                        report.orderId = reader.GetInt32("orderId");
                        
                        reports.Add(report);
                    }
                }
            }

            return reports;
        }
    }
}
