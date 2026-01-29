namespace Mini_DARMAS.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panel1 = new Panel();
            lblWelcome = new Label();
            btnTooglePassword = new Button();
            btnExit = new Button();
            btnClear = new Button();
            lblPasswordIcon = new Label();
            lblUserIcon = new Label();
            label3 = new Label();
            cmbRole = new ComboBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(280, 240);
            label1.Name = "label1";
            label1.Size = new Size(135, 32);
            label1.TabIndex = 0;
            label1.Text = "Username ";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(280, 293);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(454, 34);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(280, 383);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(280, 437);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(454, 34);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(288, 775);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(152, 64);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login ↪";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(btnTooglePassword);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(lblPasswordIcon);
            panel1.Controls.Add(lblUserIcon);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(461, 144);
            panel1.Name = "panel1";
            panel1.Size = new Size(1107, 894);
            panel1.TabIndex = 5;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(470, 79);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(212, 48);
            lblWelcome.TabIndex = 14;
            lblWelcome.Text = "Login Form";
            // 
            // btnTooglePassword
            // 
            btnTooglePassword.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTooglePassword.Location = new Point(757, 432);
            btnTooglePassword.Name = "btnTooglePassword";
            btnTooglePassword.Size = new Size(50, 50);
            btnTooglePassword.TabIndex = 13;
            btnTooglePassword.Text = "👁";
            btnTooglePassword.UseVisualStyleBackColor = true;
            btnTooglePassword.Click += btnTooglePassword_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(739, 775);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(123, 64);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(530, 775);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(133, 64);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear 󠁝󠁝󠁝󠁝󠁝\U0001f9f9";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblPasswordIcon
            // 
            lblPasswordIcon.AutoSize = true;
            lblPasswordIcon.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPasswordIcon.Location = new Point(200, 429);
            lblPasswordIcon.Name = "lblPasswordIcon";
            lblPasswordIcon.Size = new Size(55, 38);
            lblPasswordIcon.TabIndex = 10;
            lblPasswordIcon.Text = "🔑";
            // 
            // lblUserIcon
            // 
            lblUserIcon.AutoSize = true;
            lblUserIcon.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserIcon.Location = new Point(200, 279);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(64, 45);
            lblUserIcon.TabIndex = 9;
            lblUserIcon.Text = "👨🏻‍💼";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(280, 531);
            label3.Name = "label3";
            label3.Size = new Size(64, 32);
            label3.TabIndex = 8;
            label3.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Operator", "Transcriber", "Editor", "Approver" });
            cmbRole.Location = new Point(280, 589);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(308, 36);
            cmbRole.TabIndex = 7;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.HPR;
            pictureBox2.Location = new Point(106, 18);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(165, 140);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Ethiopia_Flag;
            pictureBox1.Location = new Point(879, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(189, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1924, 1050);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mini-DARMAS Login";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogin;
        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label3;
        private ComboBox cmbRole;
        private Label lblPasswordIcon;
        private Label lblUserIcon;
        private Button btnExit;
        private Button btnClear;
        private Button btnTooglePassword;
        private Label lblWelcome;
    }
}