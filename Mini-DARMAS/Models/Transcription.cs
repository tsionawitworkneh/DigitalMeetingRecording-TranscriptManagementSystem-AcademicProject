using System;

namespace MiniDarmas.Models
{
    public class Transcription
    {
        public int TranscriptionID { get; set; }
        public int AgendaID { get; set; }
        public string TranscribedText { get; set; }
        public string EditorComments { get; set; }
        public string Status { get; set; } // Submitted, Under Review, Approved, Returned
        public DateTime LastModified { get; set; }
    }
}