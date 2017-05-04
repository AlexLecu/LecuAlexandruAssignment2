using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Assignment2.Models;

namespace Assignment2.Reports
{
    public class FileXML:ReportAbstract
    {
        public override string getType()
        {

            return "XML";
        }

        public override void genReport(IList<Report> reports)
        {
            string path = @"F:\xml.txt";
            XmlTextWriter writer = new XmlTextWriter(path, null);
            writer.WriteStartDocument();
            writer.WriteStartElement("reports");
            foreach (Report report in reports)
            {
                writer.WriteStartElement("idReport");
                writer.WriteString(report.Id.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Customer");
                writer.WriteString(report.customerName.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Order");
                writer.WriteString(report.orderId.ToString());
                writer.WriteEndElement();

            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}
