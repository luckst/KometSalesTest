namespace KometSales.Administrator
{
    partial class UserForm
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
            btnClean = new Button();
            btnDelete = new Button();
            label6 = new Label();
            dgData = new DataGridView();
            btnBack = new Button();
            btnSave = new Button();
            txtEmail = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cmbRole = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgData).BeginInit();
            SuspendLayout();
            // 
            // btnClean
            // 
            btnClean.Location = new Point(175, 135);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 10017;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(94, 135);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10016;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(474, 40);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 10011;
            label6.Text = "Role";
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
            dgData.Location = new Point(12, 173);
            dgData.Name = "dgData";
            dgData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgData.RowTemplate.Height = 25;
            dgData.Size = new Size(634, 150);
            dgData.TabIndex = 10010;
            dgData.CellFormatting += dgData_CellFormatting;
            dgData.SelectionChanged += dgData_SelectionChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(256, 135);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 10009;
            btnBack.Text = "Go Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 135);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10008;
            btnSave.Text = "Create";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(287, 58);
            txtEmail.MaxLength = 255;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(176, 23);
            txtEmail.TabIndex = 10006;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(287, 40);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 10012;
            label5.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(150, 58);
            txtPassword.MaxLength = 255;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(125, 23);
            txtPassword.TabIndex = 10004;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 40);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 10014;
            label3.Text = "Password";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(12, 58);
            txtUserName.MaxLength = 255;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(125, 23);
            txtUserName.TabIndex = 10003;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 10015;
            label2.Text = "User Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(5, 7);
            label1.Name = "label1";
            label1.Size = new Size(111, 28);
            label1.TabIndex = 10002;
            label1.Text = "Customers";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(474, 58);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(145, 23);
            cmbRole.TabIndex = 10018;
            // 
            // UserForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 360);
            Controls.Add(cmbRole);
            Controls.Add(btnClean);
            Controls.Add(btnDelete);
            Controls.Add(label6);
            Controls.Add(dgData);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClean;
        private Button btnDelete;
        private Label label6;
        private DataGridView dgData;
        private Button btnBack;
        private Button btnSave;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUserName;
        private Label label2;
        private Label label1;
        private ComboBox cmbRole;
    }
}