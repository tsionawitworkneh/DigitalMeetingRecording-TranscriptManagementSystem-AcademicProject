using Mini_DARMAS.DAL;
using MiniDarmas.Models;
using MiniDarmas.DAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mini_DARMAS.Forms
{
    public partial class AdminUserForm : Form
    {
        private UserDAL _userDAL = new UserDAL();
        private int _selectedUserId = -1;

        public AdminUserForm()
        {
            InitializeComponent();
            LoadUserData(); // Load list on startup
        }

        // --- TAB 1: SEARCH & MANAGE LOGIC ---

        private void LoadUserData()
        {
            string search = txtSearch.Text.Trim();
            var results = _userDAL.SearchUsers(search, "");

            dgvUsers.DataSource = null; // Reset the binding
            dgvUsers.DataSource = results; // Re-bind the new results

            if (dgvUsers.Columns["Password"] != null)
                dgvUsers.Columns["Password"].Visible = false;
        }

        // EVENT-DRIVEN: Real-time search (Filters as you type)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            // 2. Clear any selection in the grid
            dgvUsers.ClearSelection();

            // 3. Call your Load method to get a fresh copy of the data from SQL
            LoadUserData();
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {

                int userId = (int)dgvUsers.SelectedRows[0].Cells["UserID"].Value;
                bool currentStatus = (bool)dgvUsers.SelectedRows[0].Cells["IsActive"].Value;


                string action = currentStatus ? "Deactivate" : "Activate";
                var result = MessageBox.Show($"Are you sure you want to {action} this user?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bool success = _userDAL.UpdateUserStatus(userId, !currentStatus);

                    if (success)
                    {
                        MessageBox.Show($"User successfully {action}d!");
                        LoadUserData();
                    }
                    else
                    {
                        MessageBox.Show("Database update failed.");
                    }
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value != null)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                
                _selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

                
                txtEditFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtEditUserName.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtEditPassword.Text = row.Cells["Password"].Value?.ToString() ?? "";

                
                if (row.Cells["Role"].Value != null)
                {
                    cmbEditRole.SelectedItem = row.Cells["Role"].Value.ToString();
                }
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == -1) return;

            // PASSWORD LENGTH CHECK for Update
            if (txtEditPassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error");
                return;
            }

            User u = new User
            {
                UserID = _selectedUserId,
                FullName = txtEditFullName.Text.Trim(),
                Username = txtEditUserName.Text.Trim(),
                Password = txtEditPassword.Text.Trim(),
                Role = cmbEditRole.SelectedItem.ToString()
            };

            if (_userDAL.UpdateUser(u))
            {
                MessageBox.Show("User Updated!");
                LoadUserData();
                ClearCreateFields();

            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // 1. Check if a user is actually selected
            if (_selectedUserId == -1)
            {
                MessageBox.Show("Please select a user from the table first.", "Selection Required");
                return;
            }

            // 2. Ask for confirmation (Safety first!)
            var result = MessageBox.Show("Are you sure you want to PERMANENTLY delete this user? This cannot be undone.",
                                        "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 3. Call the DAL method
                    bool success = _userDAL.DeleteUser(_selectedUserId);

                    if (success)
                    {
                        MessageBox.Show("User deleted successfully.");

                        // 4. Refresh the UI
                        LoadUserData(); // Reload the grid
                        ClearCreateFields();  // Clear the textboxes
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    // Error Number 547 is a Foreign Key constraint violation
                    if (ex.Number == 547)
                    {
                        MessageBox.Show("CANNOT DELETE: This user has meeting history (assignments or transcriptions). " +
                                        "\n\nPlease use the 'Deactivate' button instead to block their access.",
                                        "Data Integrity Protection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Database error: " + ex.Message);
                    }
                }
            }
        }


        // --- TAB 2: CREATE USER LOGIC ---

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                cmbRole.SelectedItem == null)
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            // 2. PASSWORD LENGTH CHECK
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Security Requirement: Password must be at least 8 characters long.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Create Model Object
                User newUser = new User
                {
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = cmbRole.SelectedItem.ToString(),
                    IsActive = true
                };

                // 4. Save to Database
                if (_userDAL.CreateUser(newUser))
                {
                    MessageBox.Show("User Created Successfully!");
                    ClearCreateFields();
                    LoadUserData();
                    tabAdmin.SelectedIndex = 0;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Check for Duplicate Username (Unique Constraint Error)
                if (ex.Number == 2627)
                {
                    MessageBox.Show($"The username '{txtUsername.Text}' is already taken. Please choose a different one.",
                                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void ClearCreateFields()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;

            txtEditFullName.Clear();
            txtEditUserName.Clear();
            txtEditPassword.Clear();
            cmbEditRole.SelectedIndex = -1;

            _selectedUserId = -1;
            dgvUsers.ClearSelection();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        
    }
}