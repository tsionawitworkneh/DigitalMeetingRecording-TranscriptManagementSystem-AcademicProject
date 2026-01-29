using Mini_DARMAS.DAL;
using MiniDarmas.DAL;
using MiniDarmas.Models;
using NAudio.Wave;
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
    public partial class TranscriberForm : Form
    {

        // Audio Engine
        private IWavePlayer _waveOut;
        private AudioFileReader _audioFile;
        private bool _isDragging = false; // Prevents timer/slider conflict

        // Logic state
        private int _activeAgendaId = -1;
        private string _activeAudioPath = "";
        private AssignmentDAL _assignDAL = new AssignmentDAL();
        private TranscriptionDAL _transDAL = new TranscriptionDAL();

        public TranscriberForm()
        {
            InitializeComponent();

            LoadTaskQueue();

            // Connect the Timer Event
            TimerProgress.Tick += TimerProgress_Tick;
        }
        // ==========================================
        // TAB 1: TASK SELECTION (DASHBOARD)
        // ==========================================

        private void LoadTaskQueue()
        {
            // Only show tasks for the user currently logged in
            int currentUserID = SessionManager.CurrentUser.UserID;
            dgvTasks.DataSource = _assignDAL.GetTranscriberQueue(currentUserID);
        }

        private void dgvTasks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTasks.Rows)
            {
                if (row.Cells["Status"].Value != null && row.Cells["Status"].Value.ToString() == "Returned")
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose; // Light Red
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnOpenTranscription_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTasks.SelectedRows[0];

                // 1. Capture IDs and Paths
                _activeAgendaId = Convert.ToInt32(selectedRow.Cells["AgendaID"].Value);
                _activeAudioPath = selectedRow.Cells["FilePath"].Value.ToString();

                // 2. Update Info Panel
                lblMeetingNo.Text = "Meeting: " + selectedRow.Cells["MeetingNo"].Value.ToString();
                lblAgendaTitle.Text = "Agenda: " + selectedRow.Cells["AgendaTitle"].Value.ToString();

                // 3. FETCH BOTH TEXT AND COMMENTS (The Fix)
                var data = _transDAL.GetExistingTranscriptionData(_activeAgendaId);

                if (data != null)
                {
                    txtTranscription.Text = data.TranscribedText;
                    txtEditorComments.Text = data.EditorComments; // <--- This shows the feedback!


                }
                else
                {
                    // Reset if it's a brand new task
                    txtTranscription.Clear();
                    txtEditorComments.Clear();
                }

                // 4. Initialize Audio Engine
                InitializeAudioEngine();

                // 5. Switch to Workspace Tab
                tcTranscriber.SelectedIndex = 1;

                // Update status
                _assignDAL.UpdateStatus(_activeAgendaId, "In Progress");
            }
            else
            {
                MessageBox.Show("Please select a task from the list first.");
            }
        }

        // ==========================================
        // AUDIO ENGINE INITIALIZATION
        // ==========================================

        private void InitializeAudioEngine()
        {
            CleanUpAudio(); // Close any previous file

            if (!File.Exists(_activeAudioPath))
            {
                MessageBox.Show("Audio file not found at: " + _activeAudioPath);
                return;
            }

            try
            {
                _audioFile = new AudioFileReader(_activeAudioPath);
                _waveOut = new WaveOutEvent();
                _waveOut.Init(_audioFile);

                // Setup the Slider (TrackBar)
                tkProgress.Minimum = 0;
                tkProgress.Maximum = (int)_audioFile.TotalTime.TotalSeconds;
                tkProgress.Value = 0;

                // Update the Timer Label (00:00 / Total)
                UpdateTimerLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading audio: " + ex.Message);
            }
        }




        // ==========================================
        // TAB 2: ADVANCED WORKSPACE CONTROLS
        // ==========================================

        // Feature: Play/Pause Toggle
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (_waveOut == null || _audioFile == null) return;

            if (_waveOut.PlaybackState == PlaybackState.Playing)
            {
                _waveOut.Pause();
                btnPlayPause.Text = "▶ Play";
                TimerProgress.Stop();
            }
            else
            {
                _waveOut.Play();
                btnPlayPause.Text = "⏸ Pause";
                TimerProgress.Start();
            }
        }


        // Feature: Incremental Seeking (+5s / -5s)
        private void btnForward5_Click(object sender, EventArgs e)
        {
            if (_audioFile == null) return;
            var newTime = _audioFile.CurrentTime.Add(TimeSpan.FromSeconds(5));
            if (newTime < _audioFile.TotalTime)
                _audioFile.CurrentTime = newTime;
        }

        private void btnBack5_Click(object sender, EventArgs e)
        {
            if (_audioFile == null) return;
            var newTime = _audioFile.CurrentTime.Subtract(TimeSpan.FromSeconds(5));
            _audioFile.CurrentTime = newTime < TimeSpan.Zero ? TimeSpan.Zero : newTime;
        }


        // ==========================================
        // PROGRESS & SCROLLING (SCRUBBING)
        // ==========================================
        private void TimerProgress_Tick(object sender, EventArgs e)
        {
            if (_audioFile != null && !_isDragging)
            {
                tkProgress.Value = (int)_audioFile.CurrentTime.TotalSeconds;
                UpdateTimerLabel();
            }
        }

        private void UpdateTimerLabel()
        {
            lblTimer.Text = string.Format("{0:mm\\:ss} / {1:mm\\:ss}",
                _audioFile.CurrentTime, _audioFile.TotalTime);
        }


        // Feature: Manual Seeking (Scrubbing)
        private void tkProgress_Scroll(object sender, EventArgs e)
        {
            if (_audioFile != null)
            {
                _isDragging = true;
                _audioFile.CurrentTime = TimeSpan.FromSeconds(tkProgress.Value);
                UpdateTimerLabel();
            }
        }

        private void tkProgress_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false; // Resume timer updates
        }

        // ==========================================
        // DATA SUBMISSION LOGIC
        // ==========================================

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            if (_activeAgendaId == -1) return;
            _transDAL.SaveTranscription(_activeAgendaId, txtTranscription.Text, "InProgress");
            MessageBox.Show("Draft saved successfully.");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_activeAgendaId == -1) return;

            var result = MessageBox.Show("Submit to Editor? You cannot edit this after submission.",
                                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CleanUpAudio(); // Stop audio before leaving

                // 1. Save transcription with 'Submitted' status
                _transDAL.SaveTranscription(_activeAgendaId, txtTranscription.Text, "Submitted");

                // 2. Mark task as finished in Assignment table
                _assignDAL.UpdateStatus(_activeAgendaId, "Completed");

                MessageBox.Show("Transcription Submitted!");
                txtTranscription.Clear();
                LoadTaskQueue();
                tcTranscriber.SelectedIndex = 0;
            }
        }

        // ==========================================
        // CLEANUP (Prevents Memory Leaks)
        // ==========================================

        private void CleanUpAudio()
        {
            TimerProgress.Stop();
            btnPlayPause.Text = "▶ Play";

            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
                _waveOut = null;
            }
            if (_audioFile != null)
            {
                _audioFile.Dispose();
                _audioFile = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CleanUpAudio();
            base.OnFormClosing(e);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnLogOutPage1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
