using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Views;
using Assignment2.Models;
using Assignment2.Reports;

namespace Assignment2.Presenters
{
    class RegularUserPresenter
    {
        private readonly RegularUserView view;
        private readonly RegularUserRepository regularUserRepository;
        private readonly ProductRepository productRepository;
        private readonly OrderRepository orderRepository;
        private readonly CustomerRepository customerRepository;
        private readonly AdminRepository adminRepository;
        private readonly RegularUserControl regularUserControl;
        private readonly AdminControl adminControl;
        private readonly ReportRepository reportRepository;

        public RegularUserPresenter(RegularUserView view, RegularUserRepository regularUserRepository, RegularUserControl regularUserControl, ProductRepository productRepository, OrderRepository orderRepository, CustomerRepository customerRepository, AdminRepository adminRepository, AdminControl adminControl, ReportRepository reportRepository)
        {
            this.view = view;
            this.regularUserRepository = regularUserRepository;
            this.regularUserControl = regularUserControl;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.customerRepository = customerRepository;
            this.adminRepository = adminRepository;
            this.adminControl = adminControl;
            this.reportRepository = reportRepository;

            this.view.Ok += OnOk;
            this.view.Admin += OnAdmin;

            this.regularUserControl.CreateProduct += OnCreateProduct;
            this.regularUserControl.UpdateProduct += OnUpdateProduct;
            this.regularUserControl.DeleteProduct += OnDeleteProduct;
            this.regularUserControl.ViewProduct += OnViewProduct;

            this.regularUserControl.ProductSelected += OnProductSelected;

            this.regularUserControl.CreateOrder += OnCreateOrder;
            this.regularUserControl.UpdateOrder += OnUpdateOrder;
            this.regularUserControl.ViewOrder += OnViewOrder;

            this.regularUserControl.OrderSelected += OnOrderSelected;

            this.adminControl.Add += OnAddUser;

            this.adminControl.Update += OnUpdateUser;
            this.adminControl.Delete += OnDeleteUser;
            this.adminControl.View += OnViewUser;
            this.adminControl.RegularUserSelected += OnUserSelected;
            this.adminControl.GenerateReport += OnGenerateReport;
        }

        public void OnOk()
        {
            var regularUser = this.view.RetrieveRegularUser();
            IList<RegularUser> regularUserList = regularUserRepository.RetrieveRegularUsers();


            Security secure = new Security();
            
            for (int i = 0; i < regularUserList.Count; i++)
            {
                if (regularUserList.ElementAt(i).UserName.Equals(regularUser.UserName) && secure.VerifyHash(regularUser.Password, regularUserList.ElementAt(i).Password))
                {
                    //this.view.Dispose();
                    this.regularUserControl.Show();
                }

            }
        }

        public void OnGenerateReport()
        {
            var type = this.adminControl.RetrieveReportType();
            IList<Report> reports = new List<Report>();
            reports = reportRepository.RetrieveReports();

            Factory factory = new Factory();
            ReportAbstract abstractReport = factory.createReport(type);
            abstractReport.genReport(reports);

        }

        public void OnAdmin()
        {
            this.adminControl.Show();
        }

        public void OnCreateProduct()
        {
            var product = this.regularUserControl.RetrieveProduct();

            productRepository.AddProduct(product);
        }

        public void OnUpdateProduct()
        {
            var product = this.regularUserControl.RetrieveProduct();

            productRepository.UpdateProduct(product);
        }

        public void OnDeleteProduct()
        {
            var product = this.regularUserControl.RetrieveProduct();

            productRepository.DeleteProduct(product);
        }

        public void OnViewProduct()
        {
            var products = productRepository.RetrieveProducts();
            this.regularUserControl.LoadProducts(products);
        }

        public void OnProductSelected()
        {
            if (this.regularUserControl.SelectedProduct != null)
            {
                var id = this.regularUserControl.SelectedProduct.Id;
                var product = this.productRepository.GetById(id);

                this.regularUserControl.LoadProduct(product);
            }
        }

        public void OnCreateOrder()
        {
            var customer = this.regularUserControl.RetrieveCustomer();
            customerRepository.AddCustomer(customer);

            var order = this.regularUserControl.RetrieveOrder();
            orderRepository.AddOrder(order);
        }

        public void OnUpdateOrder()
        {
            var order = this.regularUserControl.RetrieveOrder();

            orderRepository.UpdateOrder(order);
        }

        public void OnViewOrder()
        {
            var orders = orderRepository.RetrieveOrders();
            this.regularUserControl.LoadOrders(orders);
        }

        public void OnOrderSelected()
        {
            if (this.regularUserControl.SelectedOrder != null)
            {
                var id = this.regularUserControl.SelectedOrder.Id;
                var order = this.orderRepository.GetById(id);

                this.regularUserControl.LoadOrder(order);
            }
        }

        public void OnAddUser()
        {
            Security secure = new Security();

            var regularUser = this.adminControl.RetrieveRegularUser();

            regularUser.Password = secure.HashSHA1(regularUser.Password);
            regularUserRepository.AddUser(regularUser);
        }

        public void OnUpdateUser()
        {

            Security secure = new Security();

            var regularUser = this.adminControl.RetrieveRegularUser();

            regularUser.Password = secure.HashSHA1(regularUser.Password);
            regularUserRepository.UpdateUser(regularUser);

        }

        public void OnDeleteUser()
        {
            Security secure = new Security();

            var regularUser = this.adminControl.RetrieveRegularUser();

            regularUser.Password = secure.HashSHA1(regularUser.Password);
            regularUserRepository.DeleteUser(regularUser);
        }

        public void OnViewUser()
        {
            var regularUsers = regularUserRepository.RetrieveRegularUsers();
            this.adminControl.LoadRegularUsers(regularUsers);
        }

        public void OnUserSelected()
        {
            if (this.adminControl.SelectedRegularUser != null)
            {
                var id = this.adminControl.SelectedRegularUser.Id;
                var regularUser = this.regularUserRepository.GetById(id);

                this.adminControl.LoadRegularUser(regularUser);
            }
        }
    }
}
