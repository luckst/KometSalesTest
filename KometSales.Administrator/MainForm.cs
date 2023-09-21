namespace KometSales.Administrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            TokenValidatorService.Logout(this);
        }

        private void linkTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!TokenValidatorService.IsAdmin)
            {
                MessageBox.Show("Only administrators can use this option");
                return;
            }

            this.Close();
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (TokenValidatorService.TokenHasExpired())
            {
                MessageBox.Show("Your session has expired. Please log in again.");
                TokenValidatorService.Logout(this);
            }
        }

        private void lnkUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!TokenValidatorService.IsAdmin)
            {
                MessageBox.Show("Only administrators can use this option");
                return;
            }

            this.Close();
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void lnkProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!TokenValidatorService.IsAdmin)
            {
                MessageBox.Show("Only administrators can use this option");
                return;
            }

            this.Close();
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }
    }
}
