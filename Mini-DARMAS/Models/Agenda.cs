namespace MiniDarmas.Models
{
    public class Agenda
    {
        public int AgendaID { get; set; }
        public int MeetingID { get; set; }
        public string Title { get; set; }
        public string Office { get; set; }
        public string SupportingDocPath { get; set; }
    }
}