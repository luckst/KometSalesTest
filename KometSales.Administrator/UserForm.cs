using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Utils;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace KometSales.Administrator
{
    public partial class UserForm : Form
    {
        bool editMode = false;
        Guid userId = Guid.Empty;

        public UserForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!editMode)
                {
                    if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtEmail.Text) || cmbRole.SelectedValue.ToString() == Guid.Empty.ToString())
                    {
                        MessageBox.Show("Please fill in all required fields. \n User Name \n Password \n Email \n Role");
                        return;
                    }
                    Create();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtEmail.Text) || cmbRole.SelectedValue.ToString() == Guid.Empty.ToString())
                    {
                        MessageBox.Show("Please fill in all required fields. \n User Name \n Email \n Role");
                        return;
                    }
                    Update();
                }

                MessageBox.Show("Register saved!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                CleanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (TokenValidatorService.TokenHasExpired())
            {
                MessageBox.Show("Your session has expired. Please log in again.");
                TokenValidatorService.Logout(this);
            }

            LoadUsers();
            LoadRoles();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Do you want to delete the register?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    HttpUtil.Send<object, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}users/{userId}", HttpMethod.Delete);

                    CleanForm();
                    LoadUsers();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void dgData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count > 0)
            {
                editMode = true;
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
                txtPassword.Enabled = false;

                DataGridViewRow selectedRow = dgData.SelectedRows[0];

                var selectedUser = (UserDto)selectedRow.DataBoundItem;

                userId = selectedUser.Id;
                txtUserName.Text = selectedUser.UserName;
                txtEmail.Text = selectedUser.Email;
                cmbRole.SelectedValue = selectedUser.UserRol.Id;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                e.Cancel = true;
                MessageBox.Show("Please enter a valid email address.");
            }
        }

        private void CleanForm()
        {
            userId = Guid.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Enabled = true;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbRole.SelectedIndex = 0;
            btnDelete.Enabled = false;
            btnSave.Text = "Create";

            editMode = false;
        }

        private void LoadUsers()
        {
            try
            {
                var users = HttpUtil.Send<object, List<UserDto>>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}users", HttpMethod.Get);
                dgData.DataSource = users;
                dgData.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadRoles()
        {
            try
            {
                var roles = HttpUtil.Send<object, List<UserRolDto>>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}userroles", HttpMethod.Get);

                roles.Insert(0, new UserRolDto() { Id = Guid.Empty, RoleName = "Select one..." });

                cmbRole.DataSource = roles;
                cmbRole.SelectedIndex = 0;

                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Create()
        {
            var userModel = new CreateUserModel
            {
                UserName = txtUserName.Text,
                Email = txtEmail.Text,
                RoleId = Guid.Parse(cmbRole.SelectedValue.ToString()),
                Password = txtPassword.Text
            };

            HttpUtil.Send<CreateUserModel, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}users", HttpMethod.Post, body: userModel);
        }

        private void Update()
        {
            var userModel = new UpdateUserModel
            {
                UserName = txtUserName.Text,
                Email = txtEmail.Text,
                RoleId = Guid.Parse(cmbRole.SelectedValue.ToString())
            };

            HttpUtil.Send<UpdateUserModel, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}users/{userId}", HttpMethod.Put, body: userModel);
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void dgData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                var user = dgData.Rows[e.RowIndex].DataBoundItem as UserDto;
                if (user != null)
                {
                    e.Value = user.UserRol.RoleName;
                }
            }
        }
    }
}
