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
    public partial class RegularUserView : Form, IRegularUserView
    {
        public event Action Ok;
        public event Action Admin;

        public RegularUserView()
        {
            this.InitializeComponent();
            this.BindComponent();
        }

        private void BindComponent()
        {
            this.okButton.Click += OnOkButtonClick;
            this.btnAdmin.Click += OnAdminButtonClick;
        }

        public RegularUser RetrieveRegularUser()
        {
            RegularUser regularUser = new RegularUser();

            regularUser.Id = 0;
            regularUser.UserName = txtUserName.Text;
            regularUser.Password = txtPassword.Text;

            return regularUser;
        }

        public Admin RetrieveAdmin()
        {
            Admin admin = new Admin();

            admin.Id = 0;
            admin.UserName = txtUserName.Text;
            admin.Password = txtPassword.Text;

            return admin;
        }

        public void OnOkButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Ok != null)
                {
                    this.Ok();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnAdminButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Admin != null)
                {
                    this.Admin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
