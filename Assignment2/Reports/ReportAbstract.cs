using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Reports
{
    public abstract class ReportAbstract
    {
        abstract public string getType();
        abstract public void genReport(IList<Report> reports);
    }
}
