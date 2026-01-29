using MiniDarmas.DAL;
using MiniDarmas.Models; 
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Mini_DARMAS.Forms
{
    public partial class LoginForm : Form
    {
        public UserDAL _userDAL = new UserDAL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var path = Path.Combine(Application.StartupPath, "Resources", "HPR.png"); // ensure file is copied into output
            if (File.Exists(path))
            {
                pictureBox1.Image = Image.FromFile(path);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // 1. Ensure a role is selected
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select your Role.");
                return;
            }

            string role = cmbRole.SelectedItem.ToString();

            // 2. Validate against database
            User authenticatedUser = _userDAL.Login(user, pass, role);

            if (authenticatedUser != null)
            {
                // 3. Set the global session
                SessionManager.Login(authenticatedUser);

                // 4. Close with OK result
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials for the selected Role.", "Login Failed");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            txtUsername.Clear();
            txtPassword.Clear();


            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = -1;
            }


            txtUsername.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit Mini-DARMAS?",
                                "Exit Application",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTooglePassword_Click(object sender, EventArgs e)
        {
            
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            
            if (txtPassword.UseSystemPasswordChar)
            {
                
                btnTooglePassword.Text = "👁️";
            }
            else
            {
                
                btnTooglePassword.Text = "🙈";
            }
        }
    }
}