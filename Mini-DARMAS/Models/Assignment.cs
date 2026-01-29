using System;

namespace MiniDarmas.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int AgendaID { get; set; }
        public int TranscriberID { get; set; }
        public string Status { get; set; } // Assigned, In Progress, Completed
        public DateTime AssignedDate { get; set; }
    }
}