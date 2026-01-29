namespace Mini_DARMAS.Forms
{
    partial class ApproverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApproverForm));
            cmbMeetings = new ComboBox();
            btnGenerate = new Button();
            panelTop = new Panel();
            lblTransMeetings = new Label();
            panelCenter = new Panel();
            rtbFinalDoc = new RichTextBox();
            groupBoxSignature = new GroupBox();
            btnClearSig = new Button();
            pnlSignature = new Panel();
            panelAction = new Panel();
            btnExportTxt = new Button();
            btnApprove = new Button();
            btnExportRtf = new Button();
            btnExportPdf = new Button();
            groupBox1 = new GroupBox();
            btnLogOut = new Button();
            panelTop.SuspendLayout();
            panelCenter.SuspendLayout();
            groupBoxSignature.SuspendLayout();
            panelAction.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbMeetings
            // 
            cmbMeetings.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMeetings.FormattingEnabled = true;
            cmbMeetings.Location = new Point(321, 35);
            cmbMeetings.Name = "cmbMeetings";
            cmbMeetings.Size = new Size(200, 36);
            cmbMeetings.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(650, 35);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(147, 46);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate \U0001fa84";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTransMeetings);
            panelTop.Controls.Add(cmbMeetings);
            panelTop.Controls.Add(btnGenerate);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1672, 101);
            panelTop.TabIndex = 2;
            // 
            // lblTransMeetings
            // 
            lblTransMeetings.AutoSize = true;
            lblTransMeetings.Location = new Point(76, 38);
            lblTransMeetings.Name = "lblTransMeetings";
            lblTransMeetings.Size = new Size(206, 28);
            lblTransMeetings.TabIndex = 2;
            lblTransMeetings.Text = "Transcriped Meetings";
            // 
            // panelCenter
            // 
            panelCenter.Controls.Add(rtbFinalDoc);
            panelCenter.Dock = DockStyle.Left;
            panelCenter.Location = new Point(0, 101);
            panelCenter.Name = "panelCenter";
            panelCenter.Size = new Size(653, 949);
            panelCenter.TabIndex = 3;
            // 
            // rtbFinalDoc
            // 
            rtbFinalDoc.Dock = DockStyle.Fill;
            rtbFinalDoc.Location = new Point(0, 0);
            rtbFinalDoc.Name = "rtbFinalDoc";
            rtbFinalDoc.Size = new Size(653, 949);
            rtbFinalDoc.TabIndex = 0;
            rtbFinalDoc.Text = "";
            // 
            // groupBoxSignature
            // 
            groupBoxSignature.Controls.Add(btnClearSig);
            groupBoxSignature.Controls.Add(pnlSignature);
            groupBoxSignature.Location = new Point(890, 159);
            groupBoxSignature.Name = "groupBoxSignature";
            groupBoxSignature.Size = new Size(425, 332);
            groupBoxSignature.TabIndex = 4;
            groupBoxSignature.TabStop = false;
            groupBoxSignature.Text = "Digital Signature";
            // 
            // btnClearSig
            // 
            btnClearSig.Location = new Point(169, 255);
            btnClearSig.Name = "btnClearSig";
            btnClearSig.Size = new Size(123, 50);
            btnClearSig.TabIndex = 1;
            btnClearSig.Text = "Clear";
            btnClearSig.UseVisualStyleBackColor = true;
            btnClearSig.Click += btnClearSig_Click;
            // 
            // pnlSignature
            // 
            pnlSignature.BackColor = Color.White;
            pnlSignature.BorderStyle = BorderStyle.FixedSingle;
            pnlSignature.Cursor = Cursors.Cross;
            pnlSignature.Dock = DockStyle.Top;
            pnlSignature.Location = new Point(3, 30);
            pnlSignature.Name = "pnlSignature";
            pnlSignature.Size = new Size(419, 208);
            pnlSignature.TabIndex = 0;
            pnlSignature.MouseDown += pnlSignature_MouseDown;
            pnlSignature.MouseMove += pnlSignature_MouseMove;
            pnlSignature.MouseUp += pnlSignature_MouseUp;
            // 
            // panelAction
            // 
            panelAction.Controls.Add(btnExportTxt);
            panelAction.Controls.Add(btnApprove);
            panelAction.Controls.Add(btnExportRtf);
            panelAction.Controls.Add(btnExportPdf);
            panelAction.Location = new Point(31, 72);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(560, 171);
            panelAction.TabIndex = 5;
            // 
            // btnExportTxt
            // 
            btnExportTxt.Location = new Point(410, 19);
            btnExportTxt.Name = "btnExportTxt";
            btnExportTxt.Size = new Size(123, 57);
            btnExportTxt.TabIndex = 3;
            btnExportTxt.Text = "Export Text";
            btnExportTxt.UseVisualStyleBackColor = true;
            btnExportTxt.Click += btnExportTxt_Click;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(220, 102);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(123, 53);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnExportRtf
            // 
            btnExportRtf.Location = new Point(220, 19);
            btnExportRtf.Name = "btnExportRtf";
            btnExportRtf.Size = new Size(123, 57);
            btnExportRtf.TabIndex = 1;
            btnExportRtf.Text = "Export Rtf";
            btnExportRtf.UseVisualStyleBackColor = true;
            btnExportRtf.Click += btnExportRtf_Click;
            // 
            // btnExportPdf
            // 
            btnExportPdf.Location = new Point(36, 19);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(123, 57);
            btnExportPdf.TabIndex = 0;
            btnExportPdf.Text = "Export Pdf";
            btnExportPdf.UseVisualStyleBackColor = true;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelAction);
            groupBox1.Location = new Point(777, 576);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(630, 297);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Export Final Document ";
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(1295, 957);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(138, 53);
            btnLogOut.TabIndex = 7;
            btnLogOut.Text = "Log Out ➜]";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // ApproverForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1672, 1050);
            Controls.Add(btnLogOut);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxSignature);
            Controls.Add(panelCenter);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ApproverForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Approver Window";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCenter.ResumeLayout(false);
            groupBoxSignature.ResumeLayout(false);
            panelAction.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbMeetings;
        private Button btnGenerate;
        private Panel panelTop;
        private Panel panelCenter;
        private RichTextBox rtbFinalDoc;
        private GroupBox groupBoxSignature;
        private Button btnClearSig;
        private Panel pnlSignature;
        private Panel panelAction;
        private Button btnExportRtf;
        private Button btnExportPdf;
        private Button btnApprove;
        private Button btnExportTxt;
        private Label lblTransMeetings;
        private GroupBox groupBox1;
        private Button btnLogOut;
    }
}