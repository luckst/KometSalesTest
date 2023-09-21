using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Utils;
using System.Text.RegularExpressions;

namespace KometSales.Administrator
{
    public partial class CustomerForm : Form
    {
        bool editMode = false;
        Guid customerId = Guid.Empty;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (TokenValidatorService.TokenHasExpired())
            {
                MessageBox.Show("Your session has expired. Please log in again.");
                TokenValidatorService.Logout(this);
            }

            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = HttpUtil.Send<object, List<CustomerDto>>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}customers", HttpMethod.Get);
                dgData.DataSource = customers;
                dgData.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string phoneNumber = txtPhone.Text;
            if (phoneNumber != "(   )    -" && !IsValidPhoneNumber(phoneNumber))
            {
                e.Cancel = true;
                MessageBox.Show("Please enter a valid phone number.");
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                e.Cancel = true;
                MessageBox.Show("Please enter a valid email address.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show("Please fill in all required fields. First Name and Last Name");
                    return;
                }

                if (!editMode)
                {
                    Create();
                }
                else
                {
                    Update();
                }

                MessageBox.Show("Register saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
                CleanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Create()
        {
            var customerModel = new CustomerModel
            {
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text
            };

            HttpUtil.Send<CustomerModel, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}customers", HttpMethod.Post, body: customerModel);
        }

        private void Update()
        {
            var customerModel = new CustomerModel
            {
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text
            };

            HttpUtil.Send<CustomerModel, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}customers/{customerId}", HttpMethod.Put, body: customerModel);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\(\d{3}\) \d{3}-\d{4}$";
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void dgData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count > 0)
            {
                editMode = true;
                btnSave.Text = "Update";
                btnDelete.Enabled = true;

                DataGridViewRow selectedRow = dgData.SelectedRows[0];

                CustomerDto selectedCustomer = (CustomerDto)selectedRow.DataBoundItem;

                customerId = selectedCustomer.Id;
                txtFirstName.Text = selectedCustomer.FirstName;
                txtLastName.Text = selectedCustomer.LastName;
                txtEmail.Text = selectedCustomer.Email;
                txtPhone.Text = selectedCustomer.Phone;
                txtAddress.Text = selectedCustomer.Address;
            }
        }

        private void CleanForm()
        {
            customerId = Guid.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Text = "Create";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Do you want to delete the register?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    HttpUtil.Send<object, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}customers/{customerId}", HttpMethod.Delete);

                    CleanForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanForm();
        }
    }
}
