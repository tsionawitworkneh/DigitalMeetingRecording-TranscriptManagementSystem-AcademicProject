namespace Mini_DARMAS.Forms
{
    partial class TranscriberForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranscriberForm));
            tcTranscriber = new TabControl();
            tbTaskDashBoard = new TabPage();
            btnLogOutPage1 = new Button();
            btnOpenTranscription = new Button();
            dgvTasks = new DataGridView();
            tbWorkspace = new TabPage();
            txtEditorComments = new TextBox();
            lblCommentHeader = new Label();
            btnLogOut = new Button();
            btnSubmit = new Button();
            btnSaveDraft = new Button();
            btnForward5 = new Button();
            btnBack5 = new Button();
            btnPlayPause = new Button();
            lblTimer = new Label();
            tkProgress = new TrackBar();
            txtTranscription = new TextBox();
            groupBox1 = new GroupBox();
            lblAgendaTitle = new Label();
            lblMeetingNo = new Label();
            TimerProgress = new System.Windows.Forms.Timer(components);
            tcTranscriber.SuspendLayout();
            tbTaskDashBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            tbWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tkProgress).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tcTranscriber
            // 
            tcTranscriber.Controls.Add(tbTaskDashBoard);
            tcTranscriber.Controls.Add(tbWorkspace);
            tcTranscriber.Dock = DockStyle.Fill;
            tcTranscriber.Location = new Point(0, 0);
            tcTranscriber.Name = "tcTranscriber";
            tcTranscriber.SelectedIndex = 0;
            tcTranscriber.Size = new Size(1924, 1050);
            tcTranscriber.TabIndex = 0;
            // 
            // tbTaskDashBoard
            // 
            tbTaskDashBoard.Controls.Add(btnLogOutPage1);
            tbTaskDashBoard.Controls.Add(btnOpenTranscription);
            tbTaskDashBoard.Controls.Add(dgvTasks);
            tbTaskDashBoard.Location = new Point(4, 37);
            tbTaskDashBoard.Name = "tbTaskDashBoard";
            tbTaskDashBoard.Padding = new Padding(3);
            tbTaskDashBoard.Size = new Size(1916, 1009);
            tbTaskDashBoard.TabIndex = 0;
            tbTaskDashBoard.Text = "Task Dashboard";
            tbTaskDashBoard.UseVisualStyleBackColor = true;
            // 
            // btnLogOutPage1
            // 
            btnLogOutPage1.Location = new Point(1516, 869);
            btnLogOutPage1.Name = "btnLogOutPage1";
            btnLogOutPage1.Size = new Size(157, 59);
            btnLogOutPage1.TabIndex = 2;
            btnLogOutPage1.Text = "Log Out ➜]";
            btnLogOutPage1.UseVisualStyleBackColor = true;
            btnLogOutPage1.Click += btnLogOutPage1_Click;
            // 
            // btnOpenTranscription
            // 
            btnOpenTranscription.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenTranscription.Location = new Point(872, 762);
            btnOpenTranscription.Name = "btnOpenTranscription";
            btnOpenTranscription.Size = new Size(239, 62);
            btnOpenTranscription.TabIndex = 1;
            btnOpenTranscription.Text = "Open Selected Task";
            btnOpenTranscription.UseVisualStyleBackColor = true;
            btnOpenTranscription.Click += btnOpenTranscription_Click;
            // 
            // dgvTasks
            // 
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(416, 116);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 62;
            dgvTasks.Size = new Size(1019, 522);
            dgvTasks.TabIndex = 0;
            dgvTasks.DataBindingComplete += dgvTasks_DataBindingComplete;
            // 
            // tbWorkspace
            // 
            tbWorkspace.BackColor = Color.Transparent;
            tbWorkspace.Controls.Add(txtEditorComments);
            tbWorkspace.Controls.Add(lblCommentHeader);
            tbWorkspace.Controls.Add(btnLogOut);
            tbWorkspace.Controls.Add(btnSubmit);
            tbWorkspace.Controls.Add(btnSaveDraft);
            tbWorkspace.Controls.Add(btnForward5);
            tbWorkspace.Controls.Add(btnBack5);
            tbWorkspace.Controls.Add(btnPlayPause);
            tbWorkspace.Controls.Add(lblTimer);
            tbWorkspace.Controls.Add(tkProgress);
            tbWorkspace.Controls.Add(txtTranscription);
            tbWorkspace.Controls.Add(groupBox1);
            tbWorkspace.Location = new Point(4, 34);
            tbWorkspace.Name = "tbWorkspace";
            tbWorkspace.Padding = new Padding(3);
            tbWorkspace.Size = new Size(1916, 1012);
            tbWorkspace.TabIndex = 1;
            tbWorkspace.Text = "Transcription Workspace";
            // 
            // txtEditorComments
            // 
            txtEditorComments.BackColor = SystemColors.Info;
            txtEditorComments.Location = new Point(1305, 418);
            txtEditorComments.Multiline = true;
            txtEditorComments.Name = "txtEditorComments";
            txtEditorComments.ReadOnly = true;
            txtEditorComments.ScrollBars = ScrollBars.Both;
            txtEditorComments.Size = new Size(366, 310);
            txtEditorComments.TabIndex = 11;
            // 
            // lblCommentHeader
            // 
            lblCommentHeader.AutoSize = true;
            lblCommentHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCommentHeader.Location = new Point(1305, 360);
            lblCommentHeader.Name = "lblCommentHeader";
            lblCommentHeader.Size = new Size(157, 28);
            lblCommentHeader.TabIndex = 10;
            lblCommentHeader.Text = "Editor Feedback";
            // 
            // btnLogOut
            // 
            btnLogOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(1252, 901);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(147, 58);
            btnLogOut.TabIndex = 9;
            btnLogOut.Text = "Log Out ➜]";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(366, 901);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(211, 58);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit to Editor";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveDraft.Location = new Point(154, 901);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(169, 58);
            btnSaveDraft.TabIndex = 7;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = true;
            btnSaveDraft.Click += btnSaveDraft_Click;
            // 
            // btnForward5
            // 
            btnForward5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnForward5.Location = new Point(697, 250);
            btnForward5.Name = "btnForward5";
            btnForward5.Size = new Size(123, 53);
            btnForward5.TabIndex = 6;
            btnForward5.Text = "5s >>";
            btnForward5.UseVisualStyleBackColor = true;
            btnForward5.Click += btnForward5_Click;
            // 
            // btnBack5
            // 
            btnBack5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack5.Location = new Point(404, 250);
            btnBack5.Name = "btnBack5";
            btnBack5.Size = new Size(123, 53);
            btnBack5.TabIndex = 5;
            btnBack5.Text = "<< 5s";
            btnBack5.UseVisualStyleBackColor = true;
            btnBack5.Click += btnBack5_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.BackColor = Color.White;
            btnPlayPause.FlatStyle = FlatStyle.Flat;
            btnPlayPause.Location = new Point(274, 156);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(110, 58);
            btnPlayPause.TabIndex = 4;
            btnPlayPause.Text = "▶ Play";
            btnPlayPause.UseVisualStyleBackColor = false;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(415, 205);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(130, 28);
            lblTimer.TabIndex = 3;
            lblTimer.Text = "00:00 / 00:00";
            // 
            // tkProgress
            // 
            tkProgress.BackColor = SystemColors.Control;
            tkProgress.Location = new Point(404, 156);
            tkProgress.Name = "tkProgress";
            tkProgress.Size = new Size(417, 69);
            tkProgress.TabIndex = 2;
            tkProgress.TickStyle = TickStyle.None;
            tkProgress.Scroll += tkProgress_Scroll;
            tkProgress.MouseUp += tkProgress_MouseUp;
            // 
            // txtTranscription
            // 
            txtTranscription.Location = new Point(109, 360);
            txtTranscription.Multiline = true;
            txtTranscription.Name = "txtTranscription";
            txtTranscription.ScrollBars = ScrollBars.Vertical;
            txtTranscription.Size = new Size(1030, 496);
            txtTranscription.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAgendaTitle);
            groupBox1.Controls.Add(lblMeetingNo);
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(189, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 85);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info Panel";
            // 
            // lblAgendaTitle
            // 
            lblAgendaTitle.AutoSize = true;
            lblAgendaTitle.Location = new Point(316, 43);
            lblAgendaTitle.Name = "lblAgendaTitle";
            lblAgendaTitle.Size = new Size(127, 28);
            lblAgendaTitle.TabIndex = 1;
            lblAgendaTitle.Text = "Agenda Title";
            // 
            // lblMeetingNo
            // 
            lblMeetingNo.AutoSize = true;
            lblMeetingNo.Location = new Point(100, 43);
            lblMeetingNo.Name = "lblMeetingNo";
            lblMeetingNo.Size = new Size(169, 28);
            lblMeetingNo.TabIndex = 0;
            lblMeetingNo.Text = "Meeting Number";
            // 
            // TimerProgress
            // 
            TimerProgress.Interval = 500;
            TimerProgress.Tick += TimerProgress_Tick;
            // 
            // TranscriberForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1050);
            Controls.Add(tcTranscriber);
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TranscriberForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transcriber Window";
            WindowState = FormWindowState.Maximized;
            tcTranscriber.ResumeLayout(false);
            tbTaskDashBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            tbWorkspace.ResumeLayout(false);
            tbWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tkProgress).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcTranscriber;
        private TabPage tbTaskDashBoard;
        private TabPage tbWorkspace;
        private Button btnOpenTranscription;
        private DataGridView dgvTasks;
        private GroupBox groupBox1;
        private Label lblAgendaTitle;
        private Label lblMeetingNo;
        private TextBox txtTranscription;
        private TrackBar tkProgress;
        private Label lblTimer;
        private Button btnForward5;
        private Button btnBack5;
        private Button btnPlayPause;
        private System.Windows.Forms.Timer TimerProgress;
        private Button btnSubmit;
        private Button btnSaveDraft;
        private Button btnLogOut;
        private TextBox txtEditorComments;
        private Label lblCommentHeader;
        private Button btnLogOutPage1;
    }
}