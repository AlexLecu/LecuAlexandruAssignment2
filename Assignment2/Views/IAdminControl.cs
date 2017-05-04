using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    interface IAdminControl
    {
        event Action Add;
        event Action Delete;
        event Action Update;
        event Action View;
        event Action GenerateReport;
    }
}
