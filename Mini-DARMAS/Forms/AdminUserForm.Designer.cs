namespace Mini_DARMAS.Forms
{
    partial class AdminUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUserForm));
            tabAdmin = new TabControl();
            tbUserMgmt = new TabPage();
            btnToggleStatus = new Button();
            groupBoxUserMgmt = new GroupBox();
            txtEditPassword = new TextBox();
            txtEditUserName = new TextBox();
            txtEditFullName = new TextBox();
            label7 = new Label();
            cmbEditRole = new ComboBox();
            label6 = new Label();
            lblUserName = new Label();
            lblFullName = new Label();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            btnLogOut = new Button();
            btnRefresh = new Button();
            dgvUsers = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            tabCreateUser = new TabPage();
            groupBoxCreateUser = new GroupBox();
            label2 = new Label();
            btnSaveUser = new Button();
            txtFullName = new TextBox();
            cmbRole = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            tabAdmin.SuspendLayout();
            tbUserMgmt.SuspendLayout();
            groupBoxUserMgmt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabCreateUser.SuspendLayout();
            groupBoxCreateUser.SuspendLayout();
            SuspendLayout();
            // 
            // tabAdmin
            // 
            tabAdmin.Controls.Add(tbUserMgmt);
            tabAdmin.Controls.Add(tabCreateUser);
            tabAdmin.Dock = DockStyle.Fill;
            tabAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabAdmin.Location = new Point(0, 0);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.SelectedIndex = 0;
            tabAdmin.Size = new Size(1924, 1050);
            tabAdmin.TabIndex = 0;
            // 
            // tbUserMgmt
            // 
            tbUserMgmt.BackColor = Color.White;
            tbUserMgmt.Controls.Add(btnToggleStatus);
            tbUserMgmt.Controls.Add(groupBoxUserMgmt);
            tbUserMgmt.Controls.Add(btnLogOut);
            tbUserMgmt.Controls.Add(btnRefresh);
            tbUserMgmt.Controls.Add(dgvUsers);
            tbUserMgmt.Controls.Add(label1);
            tbUserMgmt.Controls.Add(txtSearch);
            tbUserMgmt.Location = new Point(4, 37);
            tbUserMgmt.Name = "tbUserMgmt";
            tbUserMgmt.Padding = new Padding(3);
            tbUserMgmt.Size = new Size(1916, 1009);
            tbUserMgmt.TabIndex = 0;
            tbUserMgmt.Text = "User Managment";
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnToggleStatus.Location = new Point(21, 138);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(303, 48);
            btnToggleStatus.TabIndex = 4;
            btnToggleStatus.Text = "Activate/Deactivate Selected";
            btnToggleStatus.UseVisualStyleBackColor = true;
            btnToggleStatus.Click += btnToggleStatus_Click;
            // 
            // groupBoxUserMgmt
            // 
            groupBoxUserMgmt.Controls.Add(txtEditPassword);
            groupBoxUserMgmt.Controls.Add(txtEditUserName);
            groupBoxUserMgmt.Controls.Add(txtEditFullName);
            groupBoxUserMgmt.Controls.Add(label7);
            groupBoxUserMgmt.Controls.Add(cmbEditRole);
            groupBoxUserMgmt.Controls.Add(label6);
            groupBoxUserMgmt.Controls.Add(lblUserName);
            groupBoxUserMgmt.Controls.Add(lblFullName);
            groupBoxUserMgmt.Controls.Add(btnDeleteUser);
            groupBoxUserMgmt.Controls.Add(btnUpdateUser);
            groupBoxUserMgmt.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxUserMgmt.Location = new Point(21, 256);
            groupBoxUserMgmt.Name = "groupBoxUserMgmt";
            groupBoxUserMgmt.Size = new Size(528, 495);
            groupBoxUserMgmt.TabIndex = 6;
            groupBoxUserMgmt.TabStop = false;
            groupBoxUserMgmt.Text = "Account Management -Update/Delete";
            // 
            // txtEditPassword
            // 
            txtEditPassword.Location = new Point(187, 229);
            txtEditPassword.Name = "txtEditPassword";
            txtEditPassword.Size = new Size(322, 34);
            txtEditPassword.TabIndex = 9;
            // 
            // txtEditUserName
            // 
            txtEditUserName.Location = new Point(187, 158);
            txtEditUserName.Name = "txtEditUserName";
            txtEditUserName.Size = new Size(322, 34);
            txtEditUserName.TabIndex = 8;
            // 
            // txtEditFullName
            // 
            txtEditFullName.Location = new Point(178, 80);
            txtEditFullName.Name = "txtEditFullName";
            txtEditFullName.Size = new Size(331, 34);
            txtEditFullName.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 295);
            label7.Name = "label7";
            label7.Size = new Size(51, 28);
            label7.TabIndex = 6;
            label7.Text = "Role";
            // 
            // cmbEditRole
            // 
            cmbEditRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditRole.FormattingEnabled = true;
            cmbEditRole.Items.AddRange(new object[] { "Admin", "Operator", "Transcriber", "Editor", "Approver" });
            cmbEditRole.Location = new Point(178, 295);
            cmbEditRole.Name = "cmbEditRole";
            cmbEditRole.Size = new Size(182, 36);
            cmbEditRole.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 229);
            label6.Name = "label6";
            label6.Size = new Size(97, 28);
            label6.TabIndex = 4;
            label6.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(45, 153);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(113, 28);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "User Name";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(34, 80);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(104, 28);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Full Name";
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.Transparent;
            btnDeleteUser.Location = new Point(294, 428);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(145, 43);
            btnDeleteUser.TabIndex = 1;
            btnDeleteUser.Text = "Delete 🗑";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BackColor = Color.Transparent;
            btnUpdateUser.ForeColor = SystemColors.InactiveCaptionText;
            btnUpdateUser.Location = new Point(84, 428);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(143, 43);
            btnUpdateUser.TabIndex = 0;
            btnUpdateUser.Text = "Update 🔄";
            btnUpdateUser.UseVisualStyleBackColor = false;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.White;
            btnLogOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.Black;
            btnLogOut.Location = new Point(422, 919);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(163, 54);
            btnLogOut.TabIndex = 5;
            btnLogOut.Text = "Log Out ➜]";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(371, 66);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 42);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh ⟳";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Dock = DockStyle.Right;
            dgvUsers.Location = new Point(1107, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(806, 1003);
            dgvUsers.TabIndex = 2;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(282, 28);
            label1.TabIndex = 1;
            label1.Text = "⌕ Search by Name/Username";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(21, 73);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(303, 34);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tabCreateUser
            // 
            tabCreateUser.Controls.Add(groupBoxCreateUser);
            tabCreateUser.Location = new Point(4, 37);
            tabCreateUser.Name = "tabCreateUser";
            tabCreateUser.Padding = new Padding(3);
            tabCreateUser.Size = new Size(1916, 1009);
            tabCreateUser.TabIndex = 1;
            tabCreateUser.Text = "Create User";
            tabCreateUser.UseVisualStyleBackColor = true;
            // 
            // groupBoxCreateUser
            // 
            groupBoxCreateUser.Controls.Add(label2);
            groupBoxCreateUser.Controls.Add(btnSaveUser);
            groupBoxCreateUser.Controls.Add(txtFullName);
            groupBoxCreateUser.Controls.Add(cmbRole);
            groupBoxCreateUser.Controls.Add(label5);
            groupBoxCreateUser.Controls.Add(label3);
            groupBoxCreateUser.Controls.Add(txtUsername);
            groupBoxCreateUser.Controls.Add(txtPassword);
            groupBoxCreateUser.Controls.Add(label4);
            groupBoxCreateUser.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxCreateUser.Location = new Point(129, 100);
            groupBoxCreateUser.Name = "groupBoxCreateUser";
            groupBoxCreateUser.Size = new Size(917, 634);
            groupBoxCreateUser.TabIndex = 9;
            groupBoxCreateUser.TabStop = false;
            groupBoxCreateUser.Text = "Create User Accounts";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 98);
            label2.Name = "label2";
            label2.Size = new Size(104, 28);
            label2.TabIndex = 0;
            label2.Text = "Full Name";
            // 
            // btnSaveUser
            // 
            btnSaveUser.Location = new Point(366, 497);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(161, 57);
            btnSaveUser.TabIndex = 8;
            btnSaveUser.Text = "Create Account";
            btnSaveUser.UseVisualStyleBackColor = true;
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(252, 92);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(487, 34);
            txtFullName.TabIndex = 3;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Operator", "Transcriber", "Editor", "Approver" });
            cmbRole.Location = new Point(252, 397);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(182, 36);
            cmbRole.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(81, 397);
            label5.Name = "label5";
            label5.Size = new Size(51, 28);
            label5.TabIndex = 7;
            label5.Text = "Role";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 200);
            label3.Name = "label3";
            label3.Size = new Size(104, 28);
            label3.TabIndex = 1;
            label3.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(252, 200);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(487, 34);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(252, 292);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(487, 34);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 292);
            label4.Name = "label4";
            label4.Size = new Size(97, 28);
            label4.TabIndex = 2;
            label4.Text = "Password";
            // 
            // AdminUserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1924, 1050);
            Controls.Add(tabAdmin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Window";
            WindowState = FormWindowState.Maximized;
            tabAdmin.ResumeLayout(false);
            tbUserMgmt.ResumeLayout(false);
            tbUserMgmt.PerformLayout();
            groupBoxUserMgmt.ResumeLayout(false);
            groupBoxUserMgmt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabCreateUser.ResumeLayout(false);
            groupBoxCreateUser.ResumeLayout(false);
            groupBoxCreateUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabAdmin;
        private TabPage tbUserMgmt;
        private Label label1;
        private TextBox txtSearch;
        private TabPage tabCreateUser;
        private Button btnToggleStatus;
        private Button btnRefresh;
        private DataGridView dgvUsers;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnSaveUser;
        private Label label5;
        private ComboBox cmbRole;
        private Button btnLogOut;
        private GroupBox groupBoxUserMgmt;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private Label lblFullName;
        private TextBox txtEditFullName;
        private Label label7;
        private ComboBox cmbEditRole;
        private Label label6;
        private Label lblUserName;
        private TextBox txtEditPassword;
        private TextBox txtEditUserName;
        private GroupBox groupBoxCreateUser;
    }
}