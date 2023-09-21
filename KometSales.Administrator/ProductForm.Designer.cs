namespace KometSales.Administrator
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            btnClean = new Button();
            btnDelete = new Button();
            dgData = new DataGridView();
            btnBack = new Button();
            btnSave = new Button();
            txtQuantity = new TextBox();
            label5 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtPrice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 10019;
            label1.Text = "Products";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(14, 102);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(451, 49);
            txtDescription.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 84);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 10030;
            label4.Text = "Description";
            // 
            // btnClean
            // 
            btnClean.Location = new Point(177, 157);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 10029;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(96, 157);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10028;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgData
            // 
            dgData.AllowUserToAddRows = false;
            dgData.AllowUserToDeleteRows = false;
            dgData.AllowUserToOrderColumns = true;
            dgData.AllowUserToResizeColumns = false;
            dgData.AllowUserToResizeRows = false;
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgData.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgData.Location = new Point(14, 195);
            dgData.Name = "dgData";
            dgData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgData.RowTemplate.Height = 25;
            dgData.Size = new Size(634, 150);
            dgData.TabIndex = 10024;
            dgData.CellFormatting += dgData_CellFormatting;
            dgData.SelectionChanged += dgData_SelectionChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(258, 157);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 10023;
            btnBack.Text = "Go Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(14, 157);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10022;
            btnSave.Text = "Create";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(289, 55);
            txtQuantity.MaxLength = 255;
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(176, 23);
            txtQuantity.TabIndex = 3;
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(289, 37);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 10025;
            label5.Text = "Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(152, 37);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 10026;
            label3.Text = "Price";
            // 
            // txtName
            // 
            txtName.Location = new Point(14, 55);
            txtName.MaxLength = 255;
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 23);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 37);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 10027;
            label2.Text = "Name";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(152, 55);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(117, 23);
            txtPrice.TabIndex = 2;
            txtPrice.KeyPress += txtPrice_KeyPress;
            // 
            // ProductForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 351);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(btnClean);
            Controls.Add(btnDelete);
            Controls.Add(dgData);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtQuantity);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Products";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtDescription;
        private Label label4;
        private Button btnClean;
        private Button btnDelete;
        private DataGridView dgData;
        private Button btnBack;
        private Button btnSave;
        private TextBox txtQuantity;
        private Label label5;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtPrice;
    }
}