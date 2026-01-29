using Mini_DARMAS.DAL;
using MiniDarmas.DAL;
using MiniDarmas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mini_DARMAS.Forms
{
    public partial class EditorForm : Form
    {
        private EditorDAL _editorDAL = new EditorDAL();
        private int _selectedTranscriptionId = -1;

        public EditorForm()
        {
            InitializeComponent();
            LoadQueue();
        }

        private void LoadQueue()
        {
            // 1. Force the grid to forget the old data
            dgvReviewQueue.DataSource = null;

            // 2. Re-fetch from the database
            DataTable dt = _editorDAL.GetAwaitingReview();

            // 3. Re-bind the fresh data
            dgvReviewQueue.DataSource = dt;

            // 4. (Optional) Refresh the visual drawing
            dgvReviewQueue.Refresh();
        }


        // EVENT: When Editor selects a row, load it into the workspace
        private void dgvReviewQueue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReviewQueue.Rows[e.RowIndex];

                _selectedTranscriptionId = Convert.ToInt32(row.Cells["TranscriptionID"].Value);

                // Requirement 4.4.A: View and Edit transcription text
                txtEditorWorkspace.Text = row.Cells["TranscribedText"].Value.ToString();

                lblMeetingInfo.Text = $"Reviewing Meeting: {row.Cells["MeetingNo"].Value} - {row.Cells["AgendaTitle"].Value}";

                // Automatically move status to 'Under Review' to let others know someone is working on it
                _editorDAL.ProcessReview(_selectedTranscriptionId, "Under Review", txtEditorWorkspace.Text, "");

                LoadQueue();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_selectedTranscriptionId == -1)
            {
                MessageBox.Show("Please select a transcription to review first.");
                return;
            }

            // Requirement 4.4.A: Approve
            bool success = _editorDAL.ProcessReview(
                _selectedTranscriptionId,
                "Approved",
                txtEditorWorkspace.Text.Trim(),
                txtEditorComments.Text.Trim()
            );

            if (success)
            {
                MessageBox.Show("Transcription Approved! It is now ready for the final document.");
                ClearWorkspace();
                LoadQueue();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (_selectedTranscriptionId == -1) return;

            if (string.IsNullOrWhiteSpace(txtEditorComments.Text))
            {
                MessageBox.Show("Please provide comments explaining why this is being returned.");
                return;
            }

            // Requirement 4.4.A: Return for correction
            bool success = _editorDAL.ProcessReview(
                _selectedTranscriptionId,
                "Returned",
                txtEditorWorkspace.Text.Trim(),
                txtEditorComments.Text.Trim()
            );

            if (success)
            {
                MessageBox.Show("Returned to transcriber for corrections.");

                // Note: You should also update the Assignments table status to 'Assigned' 
                // so it reappears in the Transcriber's queue.
                AssignmentDAL assignDAL = new AssignmentDAL();
                assignDAL.UpdateStatusByTranscriptionId(_selectedTranscriptionId, "Assigned");

                ClearWorkspace();
                LoadQueue();
            }
        }

        private void ClearWorkspace()
        {
            _selectedTranscriptionId = -1;
            txtEditorWorkspace.Clear();
            txtEditorComments.Clear();
            lblMeetingInfo.Text = "Select a submission to begin review.";
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

