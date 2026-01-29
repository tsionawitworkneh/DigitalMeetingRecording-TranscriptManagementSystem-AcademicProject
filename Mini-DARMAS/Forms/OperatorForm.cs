using Mini_DARMAS.DAL;
using MiniDarmas.DAL;
using MiniDarmas.Models;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mini_DARMAS.Forms
{
    public partial class OperatorForm : Form
    {
        // Data Access Layers
        private MeetingDAL _meetingDAL = new MeetingDAL();
        private UserDAL _userDAL = new UserDAL();
        private AssignmentDAL _assignDAL = new AssignmentDAL();

        private string _tempAudioPath = ""; // Stores the path from OpenFileDialog
        private int _selectedAgendaId = -1;

        public OperatorForm()
        {
            InitializeComponent();
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            RefreshMeetingList();
            LoadTranscribers();
            RefreshAllAgendasGrid();
        }

        // ==========================================
        // TAB 1: MEETING MANAGEMENT
        // ==========================================

        private void RefreshMeetingList()
        {
            // 1. Get the data
            var meetings = _meetingDAL.GetAllMeetings();

            // 2. Set Members BEFORE DataSource (This prevents errors during the SelectedIndexChanged event)
            cmbMeetingPicker.DisplayMember = "MeetingNo";
            cmbMeetingPicker.ValueMember = "MeetingID";

            // 3. Now set the source
            cmbMeetingPicker.DataSource = meetings;

            cmbMeetingPicker.SelectedIndex = -1;

            // 4. Update the Grid
            dvgMeetings.DataSource = meetings;
        }

        private void RefreshAllAgendasGrid()
        {
            dgvUnassigned.DataSource = _meetingDAL.GetAllAgendas();
        }


        private void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMeetingNo.Text))
            {
                MessageBox.Show("Meeting Number is required.");
                return;
            }

            try
            {
                Meeting m = new Meeting
                {
                    MeetingNo = txtMeetingNo.Text.Trim(),
                    MeetingDate = dtpDate.Value,
                    Location = txtLocation.Text.Trim(),
                    Chairperson = txtChairperson.Text.Trim(),
                    Status = "Created"
                };

                int newId = _meetingDAL.CreateMeeting(m);
                if (newId > 0)
                {
                    MessageBox.Show("Meeting created successfully!");
                    RefreshMeetingList();
                    ClearMeetingInputs();
                    tabOperator.SelectedIndex = 1;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Check for Duplicate Meeting Number
                if (ex.Number == 2627)
                {
                    MessageBox.Show($"Meeting Number '{txtMeetingNo.Text}' already exists. Every meeting must have a unique number.",
                                    "Duplicate Meeting Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("An error occurred while saving the meeting: " + ex.Message);
                }
            }
        }



        private void btnUpdateMeeting_Click(object sender, EventArgs e)
        {
            if (dvgMeetings.SelectedRows.Count > 0)
            {
                // 1. Get the ID from the selected row in the Grid
                int id = Convert.ToInt32(dvgMeetings.SelectedRows[0].Cells["MeetingID"].Value);

                // 2. Create the Meeting object with the NEW values from your TextBoxes
                Meeting m = new Meeting
                {
                    MeetingID = id,
                    MeetingNo = txtMeetingNo.Text,
                    MeetingDate = dtpDate.Value,
                    Location = txtLocation.Text,
                    Chairperson = txtChairperson.Text
                };

                // 3. Call DAL
                if (_meetingDAL.UpdateMeeting(m))
                {
                    MessageBox.Show("Meeting updated successfully!");
                    RefreshMeetingList(); // Refresh the grid to show changes
                    RefreshAllAgendasGrid();
                    ClearMeetingInputs();
                }
            }
            else { MessageBox.Show("Please select a meeting to update."); }
        }

        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            if (dvgMeetings.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dvgMeetings.SelectedRows[0].Cells["MeetingID"].Value);

                var result = MessageBox.Show("Are you sure? This will delete all agendas for this meeting.",
                                            "Confirm Delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (_meetingDAL.DeleteMeeting(id))
                    {
                        MessageBox.Show("Meeting deleted.");
                        RefreshMeetingList();
                        ClearMeetingInputs();
                    }
                }
            }
            else { MessageBox.Show("Please select a meeting to delete."); }
        }



        private void ClearMeetingInputs()
        {
            txtMeetingNo.Clear();
            txtLocation.Clear();
            txtChairperson.Clear();
            dtpDate.Value = DateTime.Now;
            dvgMeetings.ClearSelection();
        }

        // ==========================================
        // TAB 2: AGENDA & RECORDING MANAGEMENT
        // ==========================================

        private void cmbMeetingPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMeetingPicker.SelectedValue is int meetingId)
            {
                LoadAgendasForMeeting(meetingId);
            }
        }

        private void LoadAgendasForMeeting(int meetingId)
        {
            dvgAgendas.DataSource = _meetingDAL.GetMeetingAgendas(meetingId);



        }

        private void btnAttachAudio_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Audio Files (*.mp3;*.wav)|*.mp3;*.wav";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _tempAudioPath = ofd.FileName;
                    lblAudioPath.Text = "Attached: " + Path.GetFileName(_tempAudioPath);
                }
            }
        }

        private void btnAddAgenda_Click(object sender, EventArgs e)
        {
            if (cmbMeetingPicker.SelectedValue == null || !(cmbMeetingPicker.SelectedValue is int))
            {
                MessageBox.Show("Please select a valid meeting from the dropdown.");
                return;
            }

            if (string.IsNullOrEmpty(_tempAudioPath))
            {
                MessageBox.Show("Please attach an audio file.");
                return;
            }

            int mid = (int)cmbMeetingPicker.SelectedValue;

            bool success = _meetingDAL.AddAgendaWithRecording(
                mid,
                txtAgendaTitle.Text.Trim(),
                txtOffice.Text.Trim(),
                txtSuppDoc.Text.Trim(),
                _tempAudioPath
            );

            if (success)
            {
                MessageBox.Show("Agenda and Recording saved!");


                LoadAgendasForMeeting(mid);


                RefreshAllAgendasGrid();

                ClearAgendaInputs();
            }
        }

        private void ClearAgendaInputs()
        {
            txtAgendaTitle.Clear();
            txtOffice.Clear();
            txtSuppDoc.Clear();
            _tempAudioPath = "";
            lblAudioPath.Text = "No file attached";
        }

        // ==========================================
        // TAB 3: ASSIGNMENTS TO TRANSCRIBERS
        // ==========================================

        private void LoadTranscribers()
        {
            // Requirement 4.2.D: Assignment to Transcriber using ComboBox
            cmbTranscribers.DataSource = _userDAL.SearchUsers("", "Transcriber");
            cmbTranscribers.DisplayMember = "FullName";
            cmbTranscribers.ValueMember = "UserID";
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            if (dgvUnassigned.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an agenda from the grid.");
                return;
            }

            if (cmbTranscribers.SelectedValue == null) return;

            try
            {

                string currentStatus = dgvUnassigned.SelectedRows[0].Cells["Work Status"].Value.ToString();

                // Prevent re-assigning if already Assigned, In Progress, or Completed
                if (currentStatus != "Pending Assignment")
                {
                    MessageBox.Show($"This agenda is currently '{currentStatus}'. You cannot assign it again.",
                                    "Assignment Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int agendaId = Convert.ToInt32(dgvUnassigned.SelectedRows[0].Cells["AgendaID"].Value);
                int transcriberId = (int)cmbTranscribers.SelectedValue;


                _assignDAL.AssignTranscriber(agendaId, transcriberId);


                MessageBox.Show($"Successfully assigned to {cmbTranscribers.Text}", "Success");


                RefreshAllAgendasGrid();


                if (cmbMeetingPicker.SelectedValue is int mid)
                {
                    LoadAgendasForMeeting(mid);
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("Database Error: This agenda is already assigned in the system record.", "Integrity Error");
                }
                else
                {
                    MessageBox.Show("An unexpected database error occurred: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void dvgAgendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgAgendas.Rows[e.RowIndex];
                _selectedAgendaId = Convert.ToInt32(row.Cells["AgendaID"].Value);

                txtAgendaTitle.Text = row.Cells["Title"].Value?.ToString();
                txtOffice.Text = row.Cells["Office"].Value?.ToString();
                txtSuppDoc.Text = row.Cells["SupportingDocPath"].Value?.ToString();

                // Show what is currently in the DB
                lblAudioPath.Text = "Current: " + row.Cells["SupportingDocPath"].Value?.ToString();
                // Important: Reset temp path so we don't accidentally update with an old selection
                _tempAudioPath = "";
            }
        }



        private void btnUpdateAgenda_Click(object sender, EventArgs e)
        {
            if (_selectedAgendaId == -1)
            {
                MessageBox.Show("Please select an agenda from the table first.");
                return;
            }

            // Call the new DAL method that includes the audio path
            bool success = _meetingDAL.UpdateAgenda(
                _selectedAgendaId,
                txtAgendaTitle.Text.Trim(),
                txtOffice.Text.Trim(),
                txtSuppDoc.Text.Trim(),
                _tempAudioPath
    );

            if (success)
            {
                MessageBox.Show("Agenda, Recording, and Assignment Status Updated!");
                if (cmbMeetingPicker.SelectedValue is int mid) LoadAgendasForMeeting(mid);
                _tempAudioPath = ""; // Clear after use
                RefreshAllAgendasGrid();
                ClearAgendaInputs();
            }
            else
            {
                MessageBox.Show("Failed to update database.");
            }
        }

        private void btnDeleteAgenda_Click(object sender, EventArgs e)
        {
            if (_selectedAgendaId == -1) return;

            var result = MessageBox.Show("Are you sure? This will delete the agenda and its recording/transcription.",
                                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_meetingDAL.DeleteAgenda(_selectedAgendaId))
                {
                    MessageBox.Show("Agenda deleted.");
                    if (cmbMeetingPicker.SelectedValue is int mid) LoadAgendasForMeeting(mid);
                    RefreshAllAgendasGrid();
                    ClearAgendaInputs();
                    _selectedAgendaId = -1;
                    ClearAgendaInputs();
                }
                else
                {
                    MessageBox.Show("Delete failed. Ensure you have proper permissions.");
                }
            }
        }

        private void dvgMeetings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgMeetings.Rows[e.RowIndex];

                // Fill the textboxes with data from the specific row cells
                // Make sure the names in [" "] match your SQL column names exactly
                txtMeetingNo.Text = row.Cells["MeetingNo"].Value?.ToString() ?? "";
                txtLocation.Text = row.Cells["Location"].Value?.ToString() ?? "";
                txtChairperson.Text = row.Cells["Chairperson"].Value?.ToString() ?? "";

                // Handle the date conversion safely
                if (row.Cells["MeetingDate"].Value != null)
                {
                    dtpDate.Value = Convert.ToDateTime(row.Cells["MeetingDate"].Value);
                }
            }
        }

        private void dgvUnassigned_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUnassigned.Columns[e.ColumnIndex].HeaderText == "Work Status")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    if (status == "Pending Assignment")
                        e.CellStyle.ForeColor = Color.Red; // Needs attention
                    else if (status == "In Progress")
                        e.CellStyle.BackColor = Color.LightYellow;
                    else if (status == "Completed")
                        e.CellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void btnLogoutPage1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnLogOutPage2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}