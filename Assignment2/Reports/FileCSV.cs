using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Assignment2.Models;

namespace Assignment2.Reports
{
    public class FileCSV:ReportAbstract
    {
        public override string getType()
        {
            return "CSV";
        }

        public override void genReport(IList<Report> reports)
        {
            string path = @"F:\csv.txt";

            var csv = new StringBuilder();
            foreach (var report in reports)
            {
                var newLine = string.Format("{0},{1},{2}", report.Id.ToString(), report.customerName.ToString(), report.orderId.ToString());
                csv.AppendLine(newLine);

            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(csv);
            }
        }
    }
}
