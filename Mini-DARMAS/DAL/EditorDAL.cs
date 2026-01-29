using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniDarmas.Models;
using System.Data;
using System.Data.SqlClient;



namespace Mini_DARMAS.DAL
{
    public class EditorDAL
    {
        // Fetch all transcriptions that need review
        public DataTable GetAwaitingReview()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Join with Agendas and Meetings so the Editor knows the context
                string sql = @"SELECT T.TranscriptionID, M.MeetingNo, Ag.Title AS AgendaTitle, 
                               T.TranscribedText, T.Status
                               FROM Transcriptions T
                               JOIN Agendas Ag ON T.AgendaID = Ag.AgendaID
                               JOIN Meetings M ON Ag.MeetingID = M.MeetingID
                               WHERE T.Status IN ('Submitted', 'Under Review')";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // Update transcription (Requirement 4.4.A: Edit text, Provide comments, Approve/Return)
        public bool ProcessReview(int transId, string newStatus, string fixedText, string comments)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"UPDATE Transcriptions 
                               SET Status = @status, 
                                   TranscribedText = @text, 
                                   EditorComments = @comments, 
                                   LastModified = GETDATE() 
                               WHERE TranscriptionID = @tid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@text", fixedText);
                cmd.Parameters.AddWithValue("@comments", comments);
                cmd.Parameters.AddWithValue("@tid", transId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

