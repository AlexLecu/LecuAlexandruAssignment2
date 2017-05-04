using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2.Models;

namespace Assignment2.Views
{
    public partial class RegularUserControl : Form, IRegularUserControl
    {
        public event Action CreateProduct;
        public event Action UpdateProduct;
        public event Action DeleteProduct;
        public event Action ViewProduct;
        public event Action ProductSelected;

        public event Action CreateOrder;
        public event Action UpdateOrder;
        public event Action ViewOrder;
        public event Action OrderSelected;

        public RegularUserControl()
        {
            this.InitializeComponent();
            this.BindComponent();
        }

        private void BindComponent()
        {
            this.createProductButton.Click += OnCreateButtonClick;
            this.updateProductButton.Click += OnUpdateButtonClick;
            this.deleteProductButton.Click += OnDeleteButtonClick;
            this.viewProductButton.Click += OnViewProductButtonClick;

            this.btnCreateOrder.Click += OnCreateOrderClick;
            this.btnUpdateOrder.Click += OnUpdateOrderClick;
            this.btnViewOrder.Click += OnViewOrderClick;

            this.ProductListBox.DisplayMember = "Title";
            this.ProductListBox.SelectedIndexChanged += OnProductListBoxSelectedIndexChanged;

            this.OrderListBox.DisplayMember = "ProductId";
            this.OrderListBox.SelectedIndexChanged += OnOrderListBoxSelectedIndexChanged;
        }

        public Product SelectedProduct
        {
            get { return this.ProductListBox.SelectedItem as Product; }
        }

        public void LoadProducts(IList<Product> products)
        {
            this.ProductListBox.DataSource = products;
        }

        public Order SelectedOrder
        {
            get { return this.OrderListBox.SelectedItem as Order; }
        }

        public void LoadOrders(IList<Order> orders)
        {
            this.OrderListBox.DataSource = orders;
        }

        public Product RetrieveProduct()
        {
            Product product = new Product();

            product.Id = Convert.ToInt32(txtId.Text);
            product.Title = txtTitle.Text;
            product.Description = txtDescription.Text;
            product.Color = txtColor.Text;
            product.Size = Convert.ToInt32(txtSize.Text);
            product.Price = Convert.ToInt32(txtPrice.Text);
            product.Stock = Convert.ToInt32(txtStock.Text);

            return product;
        }

        public void LoadProduct(Product product)
        {
            txtId.Text = product.Id.ToString();
            txtTitle.Text = product.Title;
            txtDescription.Text = product.Description;
            txtColor.Text = product.Color;
            txtSize.Text = product.Size.ToString();
            txtPrice.Text = product.Price.ToString();
            txtStock.Text = product.Stock.ToString();

        }

        public Order RetrieveOrder()
        {
            Order order = new Order();

            order.CustomerId = Convert.ToInt32(txtCustomerId.Text);
            order.ProductId = Convert.ToInt32(txtProductId.Text);
            order.ShippingAddress = txtShippingAddress.Text;
            order.Id = Convert.ToInt32(txtOrderId.Text);
            order.DeliveryDate = dateTimePicker.Value;
            order.Status = txtStatus.Text;

            return order;
        }

        public void LoadOrder(Order order)
        {
            txtCustomerId.Text = order.CustomerId.ToString();
            txtProductId.Text = order.ProductId.ToString();
            txtShippingAddress.Text = order.ShippingAddress;
            txtOrderId.Text = order.Id.ToString();
            dateTimePicker.Value = order.DeliveryDate;
            txtStatus.Text = order.Status;
        }

        public Customer RetrieveCustomer()
        {
            Customer customer = new Customer();

            customer.Id = Convert.ToInt32(txtCustomerId.Text);
            customer.FirstName = txtCustomerFirstName.Text;
            customer.LastName = txtCustomerLastName.Text;

            return customer;
        }
        public void OnCreateOrderClick(object sender, EventArgs e)
        {
            try
            {
                if (this.CreateOrder != null)
                {
                    this.CreateOrder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnUpdateOrderClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UpdateOrder != null)
                {
                    this.UpdateOrder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void OnViewOrderClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ViewOrder != null)
                {
                    this.ViewOrder();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnOrderListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.OrderSelected != null)
                {
                    this.OrderSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnCreateButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.CreateProduct != null)
                {
                    this.CreateProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void OnUpdateButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UpdateProduct != null)
                {
                    this.UpdateProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void OnDeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.DeleteProduct != null)
                {
                    this.DeleteProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnViewProductButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ViewProduct != null)
                {
                    this.ViewProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnProductListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ProductSelected != null)
                {
                    this.ProductSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
