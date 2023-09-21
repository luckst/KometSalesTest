namespace KometSales.Administrator
{
    partial class CustomerForm
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
            label2 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            label3 = new Label();
            txtPhone = new MaskedTextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            btnSave = new Button();
            btnBack = new Button();
            dgData = new DataGridView();
            txtAddress = new TextBox();
            label6 = new Label();
            btnDelete = new Button();
            btnClean = new Button();
            ((System.ComponentModel.ISupportInitialize)dgData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(111, 28);
            label1.TabIndex = 0;
            label1.Text = "Customers";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 53);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 9999;
            label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(32, 71);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 23);
            txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(170, 71);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 23);
            txtLastName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 53);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 9999;
            label3.Text = "Last Name";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(306, 71);
            txtPhone.Mask = "(000) 000-0000";
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 23);
            txtPhone.TabIndex = 5;
            txtPhone.Validating += txtPhone_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(306, 53);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 9999;
            label4.Text = "Phone";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(418, 71);
            txtEmail.MaxLength = 255;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(217, 23);
            txtEmail.TabIndex = 8;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(418, 53);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 9999;
            label5.Text = "Email";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(32, 148);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Create";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(276, 148);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 11;
            btnBack.Text = "Go Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
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
            dgData.Location = new Point(32, 186);
            dgData.Name = "dgData";
            dgData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgData.RowTemplate.Height = 25;
            dgData.Size = new Size(634, 150);
            dgData.TabIndex = 12;
            dgData.SelectionChanged += dgData_SelectionChanged;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(32, 119);
            txtAddress.MaxLength = 255;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(374, 23);
            txtAddress.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 101);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 9999;
            label6.Text = "Adress";
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(114, 148);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10000;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(195, 148);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 10001;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // CustomerForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            CancelButton = btnBack;
            ClientSize = new Size(698, 375);
            Controls.Add(btnClean);
            Controls.Add(btnDelete);
            Controls.Add(txtAddress);
            Controls.Add(label6);
            Controls.Add(dgData);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtPhone);
            Controls.Add(txtLastName);
            Controls.Add(label3);
            Controls.Add(txtFirstName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customers";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label label3;
        private MaskedTextBox txtPhone;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private Button btnSave;
        private Button btnBack;
        private DataGridView dgData;
        private TextBox txtAddress;
        private Label label6;
        private Button btnDelete;
        private Button btnClean;
    }
}