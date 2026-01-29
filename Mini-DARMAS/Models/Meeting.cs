using System;

namespace MiniDarmas.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public string MeetingNo { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Location { get; set; }
        public string Chairperson { get; set; }
        public string Status { get; set; } // Created, Finalized
    }
}