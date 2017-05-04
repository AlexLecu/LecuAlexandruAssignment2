using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2.Data;
using Assignment2.Models;
using Assignment2.Views;
using Assignment2.Presenters;

namespace Assignment2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var rur = new RegularUserRepository();
            var pr = new ProductRepository();
            var ruv = new RegularUserView();
            var ruc = new RegularUserControl();
            var or = new OrderRepository();
            var cr = new CustomerRepository();
            var ar = new AdminRepository();
            var ac = new AdminControl();
            var rr = new ReportRepository();

            var rup = new RegularUserPresenter(ruv, rur, ruc, pr, or, cr, ar, ac, rr);



            Application.Run(ruv);

            /*
            RegularUserRepository rur = new RegularUserRepository();
            RegularUser ru = new RegularUser();
            ru.Id = 3;
            ru.Password = "parola";
            ru.UserName = "alex";
            rur.AddUser(ru);
            */
        }
    }
}
