namespace Mini_DARMAS.Forms
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            dgvReviewQueue = new DataGridView();
            txtEditorWorkspace = new TextBox();
            txtEditorComments = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnApprove = new Button();
            btnReturn = new Button();
            lblMeetingInfo = new Label();
            btnLogOut = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReviewQueue).BeginInit();
            SuspendLayout();
            // 
            // dgvReviewQueue
            // 
            dgvReviewQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReviewQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviewQueue.Dock = DockStyle.Left;
            dgvReviewQueue.Location = new Point(0, 0);
            dgvReviewQueue.Name = "dgvReviewQueue";
            dgvReviewQueue.RowHeadersWidth = 62;
            dgvReviewQueue.Size = new Size(754, 1050);
            dgvReviewQueue.TabIndex = 0;
            dgvReviewQueue.CellClick += dgvReviewQueue_CellClick;
            // 
            // txtEditorWorkspace
            // 
            txtEditorWorkspace.Location = new Point(911, 117);
            txtEditorWorkspace.Multiline = true;
            txtEditorWorkspace.Name = "txtEditorWorkspace";
            txtEditorWorkspace.ScrollBars = ScrollBars.Both;
            txtEditorWorkspace.Size = new Size(766, 480);
            txtEditorWorkspace.TabIndex = 1;
            // 
            // txtEditorComments
            // 
            txtEditorComments.Location = new Point(911, 658);
            txtEditorComments.Multiline = true;
            txtEditorComments.Name = "txtEditorComments";
            txtEditorComments.ScrollBars = ScrollBars.Vertical;
            txtEditorComments.Size = new Size(479, 84);
            txtEditorComments.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(803, 658);
            label1.Name = "label1";
            label1.Size = new Size(102, 28);
            label1.TabIndex = 3;
            label1.Text = "Comment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(830, 117);
            label2.Name = "label2";
            label2.Size = new Size(75, 28);
            label2.TabIndex = 4;
            label2.Text = "Review";
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(925, 814);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(123, 54);
            btnApprove.TabIndex = 5;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(1092, 819);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(123, 49);
            btnReturn.TabIndex = 6;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblMeetingInfo
            // 
            lblMeetingInfo.AutoSize = true;
            lblMeetingInfo.Location = new Point(911, 23);
            lblMeetingInfo.Name = "lblMeetingInfo";
            lblMeetingInfo.Size = new Size(202, 28);
            lblMeetingInfo.TabIndex = 7;
            lblMeetingInfo.Text = "Meeting Information";
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(1552, 952);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(125, 50);
            btnLogOut.TabIndex = 8;
            btnLogOut.Text = "Log Out➜]";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnLogOut);
            Controls.Add(lblMeetingInfo);
            Controls.Add(btnReturn);
            Controls.Add(btnApprove);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEditorComments);
            Controls.Add(txtEditorWorkspace);
            Controls.Add(dgvReviewQueue);
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editor Window";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvReviewQueue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReviewQueue;
        private TextBox txtEditorWorkspace;
        private TextBox txtEditorComments;
        private Label label1;
        private Label label2;
        private Button btnApprove;
        private Button btnReturn;
        private Label lblMeetingInfo;
        private Button btnLogOut;
    }
}