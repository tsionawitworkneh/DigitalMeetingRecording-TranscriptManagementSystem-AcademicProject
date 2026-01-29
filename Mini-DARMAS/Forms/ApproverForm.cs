using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mini_DARMAS.DAL;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace Mini_DARMAS.Forms
{
    public partial class ApproverForm : Form
    {

        private ApproverDAL _dal = new ApproverDAL();

        // --- Signature State ---
        private Bitmap _signatureBmp; // The "Memory" of the drawing
        private Graphics _bmpGraphics; // Used to draw on the bitmap
        private bool _isDrawing = false;
        private Point _lastPoint;
        private Pen _pen = new Pen(Color.Black, 2f);
        public ApproverForm()
        {
            InitializeComponent();
            LoadMeetings();
            InitializeCanvas();

        }

        private void InitializeCanvas()
        {
            // Create a bitmap the same size as the panel
            _signatureBmp = new Bitmap(pnlSignature.Width, pnlSignature.Height);
            _bmpGraphics = Graphics.FromImage(_signatureBmp);
            _bmpGraphics.Clear(Color.White);
            _bmpGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pnlSignature.Invalidate(); // Force redraw
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbMeetings.SelectedValue == null) return;

            DataTable dt = _dal.GetApprovedContent((int)cmbMeetings.SelectedValue);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("OFFICIAL MEETING MINUTES\n" + cmbMeetings.Text);
            sb.AppendLine("==========================================\n");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine("ITEM: " + row["Title"]);
                sb.AppendLine(row["TranscribedText"].ToString() + "\n");
            }

            rtbFinalDoc.Text = sb.ToString();
        }


        // ==========================================
        // PANEL DRAWING EVENTS 
        // ==========================================
        private void pnlSignature_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDrawing = true;
                _lastPoint = e.Location;
            }
        }

        private void pnlSignature_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                // 1. Draw on the Bitmap (for saving later)
                _bmpGraphics.DrawLine(_pen, _lastPoint, e.Location);

                // 2. Draw on the Panel (for live visual)
                using (Graphics g = pnlSignature.CreateGraphics())
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(_pen, _lastPoint, e.Location);
                }

                _lastPoint = e.Location;
            }
        }

        private void pnlSignature_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
        }

        private void btnClearSig_Click(object sender, EventArgs e)
        {
            InitializeCanvas();
            pnlSignature.Refresh();
        }


        // ==========================================
        // DOCUMENT & FINAL APPROVAL
        // ==========================================
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (cmbMeetings.SelectedValue == null) return;

            // Convert drawing to Byte Array for SQL VARBINARY
            byte[] signatureData;
            using (MemoryStream ms = new MemoryStream())
            {
                _signatureBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                signatureData = ms.ToArray();
            }

            int mid = (int)cmbMeetings.SelectedValue;
            if (_dal.FinalizeMeeting(mid, signatureData, "Officially Approved"))
            {
                MessageBox.Show("Meeting Finalized and Digitally Signed.");
                LoadMeetings();
                rtbFinalDoc.Clear();
                InitializeCanvas();
            }

        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF File|*.pdf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (PdfWriter writer = new PdfWriter(sfd.FileName))
                {
                    PdfDocument pdf = new PdfDocument(writer);
                    Document doc = new Document(pdf);

                    // Add Text
                    doc.Add(new Paragraph(rtbFinalDoc.Text));

                    // Add Signature Image from Panel/Bitmap
                    using (MemoryStream ms = new MemoryStream())
                    {
                        _signatureBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var data = iText.IO.Image.ImageDataFactory.Create(ms.ToArray());
                        var img = new iText.Layout.Element.Image(data).SetWidth(120);

                        doc.Add(new Paragraph("\n\nDigital Signature:"));
                        doc.Add(img);
                    }
                    doc.Close();
                }
                MessageBox.Show("PDF Document exported with signature.");
            }
        }

        // Load Meeting logic as defined previously...
        private void LoadMeetings()
        {
            cmbMeetings.DataSource = _dal.GetMeetingsToApprove();
            cmbMeetings.DisplayMember = "DisplayName";
            cmbMeetings.ValueMember = "MeetingID";
        }


        // --- EXPORT TO PLAIN TEXT (.txt) ---
        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbFinalDoc.Text)) return;

            SaveFileDialog sfd = new SaveFileDialog { Filter = "Text Files|*.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Plain text cannot hold images, so we append a text signature
                string content = rtbFinalDoc.Text + "\r\n\r\n[DIGITALLY SIGNED BY CHAIRPERSON]";
                File.WriteAllText(sfd.FileName, content);
                MessageBox.Show("Plain text exported successfully.");
            }
        }

        private void btnExportRtf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbFinalDoc.Text)) return;

            SaveFileDialog sfd = new SaveFileDialog { Filter = "RTF Files|*.rtf" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Get the current RTF text from the RichTextBox
                    string rtfContent = rtbFinalDoc.Rtf;

                    // 2. Convert the signature bitmap to a compatible RTF hex string
                    // We use PNG format as it's better supported
                    string rtfImage = GetRtfImageCode(_signatureBmp);

                    // 3. Find the end of the RTF document (the last '}')
                    int lastBrace = rtfContent.LastIndexOf('}');

                    // 4. Inject the image code before the end
                    // \par adds a new line
                    string finalRtf = rtfContent.Insert(lastBrace,
                        "\\par\\par\\b Digital Signature:\\b0\\par " + rtfImage + "\\par");

                    // 5. Save the file
                    File.WriteAllText(sfd.FileName, finalRtf);
                    MessageBox.Show("Rich Text (RTF) exported with visible Digital Signature!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RTF Export Error: " + ex.Message);
                }
            }
        }

        private string GetRtfImageCode(Bitmap img)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = ms.ToArray();
                string strImg = BitConverter.ToString(bytes).Replace("-", "");


                int widthTwips = img.Width * 15;
                int heightTwips = img.Height * 15;


                return "{\\pict\\pngblip" +
                       "\\picw" + img.Width +
                       "\\pich" + img.Height +
                       "\\picwgoal" + widthTwips +
                       "\\pichgoal" + heightTwips +
                       " " + strImg + "}";
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
