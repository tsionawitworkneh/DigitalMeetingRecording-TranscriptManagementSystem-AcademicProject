using System;
using System.Data;
using System.Data.SqlClient;

namespace Mini_DARMAS.DAL
{
    public class ApproverDAL
    {
        // 1. Get meetings that have approved agendas
        public DataTable GetMeetingsToApprove()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"SELECT DISTINCT M.MeetingID, M.MeetingNo + ' (' + CONVERT(VARCHAR, M.MeetingDate, 106) + ')' as DisplayName 
                               FROM Meetings M
                               JOIN Agendas A ON M.MeetingID = A.MeetingID
                               JOIN Transcriptions T ON A.AgendaID = T.AgendaID
                               WHERE T.Status = 'Approved' AND M.Status != 'Final Approved'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Fetch all approved text
        public DataTable GetApprovedContent(int meetingId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"SELECT Ag.Title, T.TranscribedText 
                               FROM Transcriptions T
                               JOIN Agendas Ag ON T.AgendaID = Ag.AgendaID
                               WHERE Ag.MeetingID = @mid AND T.Status = 'Approved'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@mid", meetingId);
                da.Fill(dt);
            }
            return dt;
        }

        // 3. Finalize with Signature (Requirement 4.4.B)
        public bool FinalizeMeeting(int meetingId, byte[] signatureImg, string remarks)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"UPDATE Meetings 
                               SET Status = 'Final Approved', 
                                   DigitalSignature = @sig, 
                                   FinalRemarks = @rem 
                               WHERE MeetingID = @mid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sig", (object)signatureImg ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@rem", remarks);
                cmd.Parameters.AddWithValue("@mid", meetingId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}