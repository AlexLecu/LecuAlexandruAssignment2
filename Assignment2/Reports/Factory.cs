using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Reports
{
    public class Factory
    {
        public  ReportAbstract createReport(string type)
        {
            if (type.Equals("XML"))
            {
                return new FileXML();
            }

            else if (type.Equals("CSV"))
            {
                return new FileCSV();
            }
            return null;
        }
    }
}
