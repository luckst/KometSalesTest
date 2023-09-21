namespace KometSales.Administrator
{
    partial class MainForm
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
            linkTest = new LinkLabel();
            btnLogOut = new Button();
            lnkUsers = new LinkLabel();
            lnkProducts = new LinkLabel();
            SuspendLayout();
            // 
            // linkTest
            // 
            linkTest.AutoSize = true;
            linkTest.Location = new Point(39, 9);
            linkTest.Name = "linkTest";
            linkTest.Size = new Size(64, 15);
            linkTest.TabIndex = 0;
            linkTest.TabStop = true;
            linkTest.Text = "Customers";
            linkTest.LinkClicked += linkTest_LinkClicked;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(39, 122);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(75, 23);
            btnLogOut.TabIndex = 1;
            btnLogOut.Text = "Log out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // lnkUsers
            // 
            lnkUsers.AutoSize = true;
            lnkUsers.Location = new Point(39, 40);
            lnkUsers.Name = "lnkUsers";
            lnkUsers.Size = new Size(35, 15);
            lnkUsers.TabIndex = 2;
            lnkUsers.TabStop = true;
            lnkUsers.Text = "Users";
            lnkUsers.LinkClicked += lnkUsers_LinkClicked;
            // 
            // lnkProducts
            // 
            lnkProducts.AutoSize = true;
            lnkProducts.Location = new Point(39, 75);
            lnkProducts.Name = "lnkProducts";
            lnkProducts.Size = new Size(54, 15);
            lnkProducts.TabIndex = 3;
            lnkProducts.TabStop = true;
            lnkProducts.Text = "Products";
            lnkProducts.LinkClicked += lnkProducts_LinkClicked;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(153, 159);
            Controls.Add(lnkProducts);
            Controls.Add(lnkUsers);
            Controls.Add(btnLogOut);
            Controls.Add(linkTest);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkTest;
        private Button btnLogOut;
        private LinkLabel lnkUsers;
        private LinkLabel lnkProducts;
    }
}