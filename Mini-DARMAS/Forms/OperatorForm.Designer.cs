namespace Mini_DARMAS.Forms
{
    partial class OperatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorForm));
            tabOperator = new TabControl();
            tbMeetings = new TabPage();
            btnLogoutPage1 = new Button();
            dvgMeetings = new DataGridView();
            groupBox1 = new GroupBox();
            btnDeleteMeeting = new Button();
            btnUpdateMeeting = new Button();
            btnCreateMeeting = new Button();
            txtChairperson = new TextBox();
            txtLocation = new TextBox();
            dtpDate = new DateTimePicker();
            txtMeetingNo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tbAgenda = new TabPage();
            btnLogOutPage2 = new Button();
            dvgAgendas = new DataGridView();
            gbAgendaInfo = new GroupBox();
            btnDeleteAgenda = new Button();
            btnUpdateAgenda = new Button();
            btnAddAgenda = new Button();
            txtSuppDoc = new TextBox();
            gbRecording = new GroupBox();
            lblAudioPath = new Label();
            btnAttachAudio = new Button();
            txtOffice = new TextBox();
            txtAgendaTitle = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            cmbMeetingPicker = new ComboBox();
            tabAssignment = new TabPage();
            btnLogOut = new Button();
            groupBoxAssignment = new GroupBox();
            label9 = new Label();
            btnAssignTask = new Button();
            cmbTranscribers = new ComboBox();
            dgvUnassigned = new DataGridView();
            tabOperator.SuspendLayout();
            tbMeetings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgMeetings).BeginInit();
            groupBox1.SuspendLayout();
            tbAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgAgendas).BeginInit();
            gbAgendaInfo.SuspendLayout();
            gbRecording.SuspendLayout();
            tabAssignment.SuspendLayout();
            groupBoxAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnassigned).BeginInit();
            SuspendLayout();
            // 
            // tabOperator
            // 
            tabOperator.Controls.Add(tbMeetings);
            tabOperator.Controls.Add(tbAgenda);
            tabOperator.Controls.Add(tabAssignment);
            tabOperator.Dock = DockStyle.Fill;
            tabOperator.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabOperator.Location = new Point(0, 0);
            tabOperator.Name = "tabOperator";
            tabOperator.SelectedIndex = 0;
            tabOperator.Size = new Size(1924, 1050);
            tabOperator.TabIndex = 0;
            // 
            // tbMeetings
            // 
            tbMeetings.Controls.Add(btnLogoutPage1);
            tbMeetings.Controls.Add(dvgMeetings);
            tbMeetings.Controls.Add(groupBox1);
            tbMeetings.Location = new Point(4, 37);
            tbMeetings.Name = "tbMeetings";
            tbMeetings.Padding = new Padding(3);
            tbMeetings.Size = new Size(1916, 1009);
            tbMeetings.TabIndex = 0;
            tbMeetings.Text = "Meetings";
            tbMeetings.UseVisualStyleBackColor = true;
            // 
            // btnLogoutPage1
            // 
            btnLogoutPage1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogoutPage1.Location = new Point(1631, 892);
            btnLogoutPage1.Name = "btnLogoutPage1";
            btnLogoutPage1.Size = new Size(157, 57);
            btnLogoutPage1.TabIndex = 2;
            btnLogoutPage1.Text = "Log Out➜]";
            btnLogoutPage1.UseVisualStyleBackColor = true;
            btnLogoutPage1.Click += btnLogoutPage1_Click;
            // 
            // dvgMeetings
            // 
            dvgMeetings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgMeetings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgMeetings.Dock = DockStyle.Left;
            dvgMeetings.Location = new Point(3, 381);
            dvgMeetings.Name = "dvgMeetings";
            dvgMeetings.RowHeadersWidth = 62;
            dvgMeetings.Size = new Size(957, 625);
            dvgMeetings.TabIndex = 1;
            dvgMeetings.CellClick += dvgMeetings_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeleteMeeting);
            groupBox1.Controls.Add(btnUpdateMeeting);
            groupBox1.Controls.Add(btnCreateMeeting);
            groupBox1.Controls.Add(txtChairperson);
            groupBox1.Controls.Add(txtLocation);
            groupBox1.Controls.Add(dtpDate);
            groupBox1.Controls.Add(txtMeetingNo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1910, 378);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Meeting Managment";
            // 
            // btnDeleteMeeting
            // 
            btnDeleteMeeting.Location = new Point(683, 250);
            btnDeleteMeeting.Name = "btnDeleteMeeting";
            btnDeleteMeeting.Size = new Size(230, 45);
            btnDeleteMeeting.TabIndex = 10;
            btnDeleteMeeting.Text = "Delete Meeting";
            btnDeleteMeeting.UseVisualStyleBackColor = true;
            btnDeleteMeeting.Click += btnDeleteMeeting_Click;
            // 
            // btnUpdateMeeting
            // 
            btnUpdateMeeting.Location = new Point(975, 154);
            btnUpdateMeeting.Name = "btnUpdateMeeting";
            btnUpdateMeeting.Size = new Size(230, 48);
            btnUpdateMeeting.TabIndex = 9;
            btnUpdateMeeting.Text = "Update Meeting";
            btnUpdateMeeting.UseVisualStyleBackColor = true;
            btnUpdateMeeting.Click += btnUpdateMeeting_Click;
            // 
            // btnCreateMeeting
            // 
            btnCreateMeeting.Location = new Point(683, 154);
            btnCreateMeeting.Name = "btnCreateMeeting";
            btnCreateMeeting.Size = new Size(230, 49);
            btnCreateMeeting.TabIndex = 8;
            btnCreateMeeting.Text = "Create Meeting";
            btnCreateMeeting.UseVisualStyleBackColor = true;
            btnCreateMeeting.Click += btnCreateMeeting_Click;
            // 
            // txtChairperson
            // 
            txtChairperson.Location = new Point(195, 324);
            txtChairperson.Name = "txtChairperson";
            txtChairperson.Size = new Size(333, 34);
            txtChairperson.TabIndex = 7;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(195, 232);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(333, 34);
            txtLocation.TabIndex = 6;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(195, 154);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(333, 34);
            dtpDate.TabIndex = 5;
            // 
            // txtMeetingNo
            // 
            txtMeetingNo.Location = new Point(195, 74);
            txtMeetingNo.Name = "txtMeetingNo";
            txtMeetingNo.Size = new Size(333, 34);
            txtMeetingNo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 324);
            label4.Name = "label4";
            label4.Size = new Size(121, 28);
            label4.TabIndex = 3;
            label4.Text = "Chairperson";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 232);
            label3.Name = "label3";
            label3.Size = new Size(89, 28);
            label3.TabIndex = 2;
            label3.Text = "Location";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 154);
            label2.Name = "label2";
            label2.Size = new Size(54, 28);
            label2.TabIndex = 1;
            label2.Text = "Date";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 77);
            label1.Name = "label1";
            label1.Size = new Size(121, 28);
            label1.TabIndex = 0;
            label1.Text = "Meeting No";
            // 
            // tbAgenda
            // 
            tbAgenda.Controls.Add(btnLogOutPage2);
            tbAgenda.Controls.Add(dvgAgendas);
            tbAgenda.Controls.Add(gbAgendaInfo);
            tbAgenda.Controls.Add(label5);
            tbAgenda.Controls.Add(cmbMeetingPicker);
            tbAgenda.Location = new Point(4, 37);
            tbAgenda.Name = "tbAgenda";
            tbAgenda.Padding = new Padding(3);
            tbAgenda.Size = new Size(1916, 1009);
            tbAgenda.TabIndex = 1;
            tbAgenda.Text = "Agendas & Audio";
            tbAgenda.UseVisualStyleBackColor = true;
            // 
            // btnLogOutPage2
            // 
            btnLogOutPage2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOutPage2.Location = new Point(725, 917);
            btnLogOutPage2.Name = "btnLogOutPage2";
            btnLogOutPage2.Size = new Size(154, 57);
            btnLogOutPage2.TabIndex = 4;
            btnLogOutPage2.Text = "Log Out ➜]";
            btnLogOutPage2.UseVisualStyleBackColor = true;
            btnLogOutPage2.Click += btnLogOutPage2_Click;
            // 
            // dvgAgendas
            // 
            dvgAgendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgAgendas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgAgendas.Dock = DockStyle.Right;
            dvgAgendas.Location = new Point(1081, 3);
            dvgAgendas.Name = "dvgAgendas";
            dvgAgendas.RowHeadersWidth = 62;
            dvgAgendas.Size = new Size(832, 1003);
            dvgAgendas.TabIndex = 3;
            dvgAgendas.CellClick += dvgAgendas_CellClick;
            // 
            // gbAgendaInfo
            // 
            gbAgendaInfo.Controls.Add(btnDeleteAgenda);
            gbAgendaInfo.Controls.Add(btnUpdateAgenda);
            gbAgendaInfo.Controls.Add(btnAddAgenda);
            gbAgendaInfo.Controls.Add(txtSuppDoc);
            gbAgendaInfo.Controls.Add(gbRecording);
            gbAgendaInfo.Controls.Add(txtOffice);
            gbAgendaInfo.Controls.Add(txtAgendaTitle);
            gbAgendaInfo.Controls.Add(label8);
            gbAgendaInfo.Controls.Add(label7);
            gbAgendaInfo.Controls.Add(label6);
            gbAgendaInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbAgendaInfo.Location = new Point(171, 174);
            gbAgendaInfo.Name = "gbAgendaInfo";
            gbAgendaInfo.Size = new Size(482, 686);
            gbAgendaInfo.TabIndex = 2;
            gbAgendaInfo.TabStop = false;
            gbAgendaInfo.Text = "Agenda Details";
            // 
            // btnDeleteAgenda
            // 
            btnDeleteAgenda.Location = new Point(257, 598);
            btnDeleteAgenda.Name = "btnDeleteAgenda";
            btnDeleteAgenda.Size = new Size(172, 52);
            btnDeleteAgenda.TabIndex = 4;
            btnDeleteAgenda.Text = "Delete Agenda";
            btnDeleteAgenda.UseVisualStyleBackColor = true;
            btnDeleteAgenda.Click += btnDeleteAgenda_Click;
            // 
            // btnUpdateAgenda
            // 
            btnUpdateAgenda.Location = new Point(27, 597);
            btnUpdateAgenda.Name = "btnUpdateAgenda";
            btnUpdateAgenda.Size = new Size(177, 53);
            btnUpdateAgenda.TabIndex = 5;
            btnUpdateAgenda.Text = "Update Agenda";
            btnUpdateAgenda.UseVisualStyleBackColor = true;
            btnUpdateAgenda.Click += btnUpdateAgenda_Click;
            // 
            // btnAddAgenda
            // 
            btnAddAgenda.Location = new Point(111, 500);
            btnAddAgenda.Name = "btnAddAgenda";
            btnAddAgenda.Size = new Size(191, 55);
            btnAddAgenda.TabIndex = 6;
            btnAddAgenda.Text = "Add Agenda";
            btnAddAgenda.UseVisualStyleBackColor = true;
            btnAddAgenda.Click += btnAddAgenda_Click;
            // 
            // txtSuppDoc
            // 
            txtSuppDoc.Location = new Point(203, 194);
            txtSuppDoc.Name = "txtSuppDoc";
            txtSuppDoc.Size = new Size(252, 34);
            txtSuppDoc.TabIndex = 5;
            // 
            // gbRecording
            // 
            gbRecording.Controls.Add(lblAudioPath);
            gbRecording.Controls.Add(btnAttachAudio);
            gbRecording.Location = new Point(17, 277);
            gbRecording.Name = "gbRecording";
            gbRecording.Size = new Size(438, 163);
            gbRecording.TabIndex = 3;
            gbRecording.TabStop = false;
            gbRecording.Text = "Audio Recording";
            // 
            // lblAudioPath
            // 
            lblAudioPath.AutoSize = true;
            lblAudioPath.Location = new Point(49, 114);
            lblAudioPath.Name = "lblAudioPath";
            lblAudioPath.Size = new Size(96, 28);
            lblAudioPath.TabIndex = 1;
            lblAudioPath.Text = "              ";
            // 
            // btnAttachAudio
            // 
            btnAttachAudio.Location = new Point(154, 33);
            btnAttachAudio.Name = "btnAttachAudio";
            btnAttachAudio.Size = new Size(112, 43);
            btnAttachAudio.TabIndex = 0;
            btnAttachAudio.Text = "Attach";
            btnAttachAudio.UseVisualStyleBackColor = true;
            btnAttachAudio.Click += btnAttachAudio_Click;
            // 
            // txtOffice
            // 
            txtOffice.Location = new Point(167, 136);
            txtOffice.Name = "txtOffice";
            txtOffice.Size = new Size(288, 34);
            txtOffice.TabIndex = 4;
            // 
            // txtAgendaTitle
            // 
            txtAgendaTitle.Location = new Point(171, 68);
            txtAgendaTitle.Name = "txtAgendaTitle";
            txtAgendaTitle.Size = new Size(284, 34);
            txtAgendaTitle.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 194);
            label8.Name = "label8";
            label8.Size = new Size(150, 28);
            label8.TabIndex = 2;
            label8.Text = "Supported Doc";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 142);
            label7.Name = "label7";
            label7.Size = new Size(66, 28);
            label7.TabIndex = 1;
            label7.Text = "Office";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 68);
            label6.Name = "label6";
            label6.Size = new Size(127, 28);
            label6.TabIndex = 0;
            label6.Text = "Agenda Title";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(171, 74);
            label5.Name = "label5";
            label5.Size = new Size(131, 28);
            label5.TabIndex = 1;
            label5.Text = "Pick Meeting";
            // 
            // cmbMeetingPicker
            // 
            cmbMeetingPicker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMeetingPicker.FormattingEnabled = true;
            cmbMeetingPicker.Location = new Point(333, 74);
            cmbMeetingPicker.Name = "cmbMeetingPicker";
            cmbMeetingPicker.Size = new Size(182, 36);
            cmbMeetingPicker.TabIndex = 0;
            // 
            // tabAssignment
            // 
            tabAssignment.Controls.Add(btnLogOut);
            tabAssignment.Controls.Add(groupBoxAssignment);
            tabAssignment.Controls.Add(dgvUnassigned);
            tabAssignment.Location = new Point(4, 37);
            tabAssignment.Name = "tabAssignment";
            tabAssignment.Padding = new Padding(3);
            tabAssignment.Size = new Size(1916, 1009);
            tabAssignment.TabIndex = 2;
            tabAssignment.Text = "Assign Transcriber";
            tabAssignment.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            btnLogOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(1332, 906);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(158, 53);
            btnLogOut.TabIndex = 5;
            btnLogOut.Text = "Log Out ➜]";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // groupBoxAssignment
            // 
            groupBoxAssignment.Controls.Add(label9);
            groupBoxAssignment.Controls.Add(btnAssignTask);
            groupBoxAssignment.Controls.Add(cmbTranscribers);
            groupBoxAssignment.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxAssignment.Location = new Point(1222, 219);
            groupBoxAssignment.Name = "groupBoxAssignment";
            groupBoxAssignment.Size = new Size(454, 316);
            groupBoxAssignment.TabIndex = 4;
            groupBoxAssignment.TabStop = false;
            groupBoxAssignment.Text = "Assignment";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(38, 55);
            label9.Name = "label9";
            label9.Size = new Size(110, 28);
            label9.TabIndex = 1;
            label9.Text = "Transcriber";
            // 
            // btnAssignTask
            // 
            btnAssignTask.Location = new Point(151, 168);
            btnAssignTask.Name = "btnAssignTask";
            btnAssignTask.Size = new Size(135, 49);
            btnAssignTask.TabIndex = 3;
            btnAssignTask.Text = "Assign Task";
            btnAssignTask.UseVisualStyleBackColor = true;
            btnAssignTask.Click += btnAssignTask_Click;
            // 
            // cmbTranscribers
            // 
            cmbTranscribers.FormattingEnabled = true;
            cmbTranscribers.Location = new Point(205, 52);
            cmbTranscribers.Name = "cmbTranscribers";
            cmbTranscribers.Size = new Size(182, 36);
            cmbTranscribers.TabIndex = 2;
            // 
            // dgvUnassigned
            // 
            dgvUnassigned.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnassigned.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnassigned.Dock = DockStyle.Left;
            dgvUnassigned.Location = new Point(3, 3);
            dgvUnassigned.Name = "dgvUnassigned";
            dgvUnassigned.RowHeadersWidth = 62;
            dgvUnassigned.Size = new Size(826, 1003);
            dgvUnassigned.TabIndex = 0;
            dgvUnassigned.CellFormatting += dgvUnassigned_CellFormatting;
            // 
            // OperatorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1050);
            Controls.Add(tabOperator);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OperatorForm";
            Text = "Operator Window";
            WindowState = FormWindowState.Maximized;
            tabOperator.ResumeLayout(false);
            tbMeetings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgMeetings).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tbAgenda.ResumeLayout(false);
            tbAgenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dvgAgendas).EndInit();
            gbAgendaInfo.ResumeLayout(false);
            gbAgendaInfo.PerformLayout();
            gbRecording.ResumeLayout(false);
            gbRecording.PerformLayout();
            tabAssignment.ResumeLayout(false);
            groupBoxAssignment.ResumeLayout(false);
            groupBoxAssignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnassigned).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabOperator;
        private TabPage tbMeetings;
        private TabPage tbAgenda;
        private GroupBox groupBox1;
        private DataGridView dvgMeetings;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpDate;
        private TextBox txtMeetingNo;
        private Button btnDeleteMeeting;
        private Button btnUpdateMeeting;
        private Button btnCreateMeeting;
        private TextBox txtChairperson;
        private TextBox txtLocation;
        private GroupBox gbAgendaInfo;
        private Label label5;
        private ComboBox cmbMeetingPicker;
        private TextBox txtAgendaTitle;
        private Label label8;
        private Label label7;
        private Label label6;
        private GroupBox gbRecording;
        private TextBox txtSuppDoc;
        private TextBox txtOffice;
        private Label lblAudioPath;
        private Button btnAttachAudio;
        private Button btnAddAgenda;
        private DataGridView dvgAgendas;
        private TabPage tabAssignment;
        private Label label9;
        private DataGridView dgvUnassigned;
        private GroupBox groupBoxAssignment;
        private Button btnAssignTask;
        private ComboBox cmbTranscribers;
        private Button btnLogOut;
        private Button btnUpdateAgenda;
        private Button btnDeleteAgenda;
        private Button btnLogoutPage1;
        private Button btnLogOutPage2;
    }
}