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
    public partial class AdminControl : Form, IAdminControl
    {
        public event Action Add;
        public event Action Delete;
        public event Action Update;
        public event Action View;
        public event Action RegularUserSelected;
        public event Action GenerateReport;

        private string exceptionMessage { get; set; }

        public AdminControl()
        {
            this.InitializeComponent();
            this.BindComponent();
        }

        private void BindComponent()
        {
            this.btnAdd.Click += OnAddButtonClick;
            this.btnDelete.Click += OnDeleteButtonClick;
            this.btnUpdate.Click += OnUpdateButtonClick;
            this.btnView.Click += OnViewButtonClick;
            this.btnGenerate.Click += OnGenerateButtonClick;

            this.UserListBox.DisplayMember = "UserName";
            this.UserListBox.SelectedIndexChanged += OnUserListBoxSelectedIndexChanged;
        }

        public RegularUser RetrieveRegularUser()
        {
            RegularUser regularUser = new RegularUser();

            regularUser.Id = Convert.ToInt32(txtUserId.Text);
            regularUser.UserName = txtUserName.Text;
            regularUser.Password = txtUserPassword.Text;

            return regularUser;
        }

        public void LoadRegularUser(RegularUser regularUser)
        {
            txtUserId.Text = regularUser.Id.ToString();
            txtUserName.Text = regularUser.UserName;
            txtUserPassword.Text = regularUser.Password;
        }

        public RegularUser SelectedRegularUser
        {
            get { return this.UserListBox.SelectedItem as RegularUser; }
        }

        public void LoadRegularUsers(IList<RegularUser> regularUsers)
        {
            this.UserListBox.DataSource = regularUsers;
        }

        public string RetrieveReportType()
        {
            return this.txtType.Text; 
        }

        public void OnGenerateButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.GenerateReport != null)
                {
                    this.GenerateReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnAddButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Add != null)
                {
                    this.Add();
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
                if (this.Delete != null)
                {
                    this.Delete();
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
                if (this.Update != null)
                {
                    this.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.View != null)
                {
                    this.View();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnUserListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.RegularUserSelected != null)
                {
                    this.RegularUserSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
