using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KometSales.Administrator
{
    public partial class ProductForm : Form
    {
        bool editMode = false;
        Guid productId = Guid.Empty;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (TokenValidatorService.TokenHasExpired())
            {
                MessageBox.Show("Your session has expired. Please log in again.");
                TokenValidatorService.Logout(this);
            }

            LoadProducts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Please fill in all required fields. \n Name \n Price \n Quantity");
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
                LoadProducts();
                CleanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Do you want to delete the register?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    HttpUtil.Send<object, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}products/{productId}", HttpMethod.Delete);

                    CleanForm();
                    LoadProducts();
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

        private void CleanForm()
        {
            productId = Guid.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Text = "Create";

            editMode = false;
        }

        private void LoadProducts()
        {
            try
            {
                var products = HttpUtil.Send<object, List<ProductDto>>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}products", HttpMethod.Get);
                dgData.DataSource = products;
                dgData.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Create()
        {
            ProductModel productModel = GetModel();

            HttpUtil.Send<ProductModel, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}products", HttpMethod.Post, body: productModel);
        }

        private void Update()
        {
            ProductModel productModel = GetModel();

            HttpUtil.Send<ProductModel, object>(AppContext.AuthToken, $"{Constants.ApiBaseUrl}products/{productId}", HttpMethod.Put, body: productModel);
        }

        private ProductModel GetModel()
        {
            return new ProductModel
            {
                ProductName = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                Quantity = int.Parse(txtQuantity.Text)
            };
        }

        private void dgData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count > 0)
            {
                editMode = true;
                btnSave.Text = "Update";
                btnDelete.Enabled = true;

                DataGridViewRow selectedRow = dgData.SelectedRows[0];

                var selectedProduct = (ProductDto)selectedRow.DataBoundItem;

                productId = selectedProduct.Id;
                txtName.Text = selectedProduct.ProductName;
                txtDescription.Text = selectedProduct.Description;
                txtPrice.Text = $"{selectedProduct.Price:N2}";
                txtQuantity.Text = $"{selectedProduct.Quantity:n0}";
            }
        }

        private void dgData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                dgData.Columns[e.ColumnIndex].DefaultCellStyle.Format = "C2";
            }

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                dgData.Columns[e.ColumnIndex].DefaultCellStyle.Format = "N0";
            }
        }
    }
}
