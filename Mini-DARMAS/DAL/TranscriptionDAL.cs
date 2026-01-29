using Mini_DARMAS.DAL;
using MiniDarmas.Models;
using System;
using System.Data.SqlClient;

namespace MiniDarmas.DAL
{
    public class TranscriptionDAL
    {
        // Upsert: Updates if exists, otherwise Inserts
        public void SaveTranscription(int agendaId, string text, string status)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"IF EXISTS (SELECT 1 FROM Transcriptions WHERE AgendaID = @aid)
                               UPDATE Transcriptions SET TranscribedText = @txt, Status = @st, LastModified = GETDATE() WHERE AgendaID = @aid
                               ELSE
                               INSERT INTO Transcriptions (AgendaID, TranscribedText, Status) VALUES (@aid, @txt, @st)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@aid", agendaId);
                cmd.Parameters.AddWithValue("@txt", text);
                cmd.Parameters.AddWithValue("@st", status);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // For Editor/Approver: Combine all approved agendas for a meeting
        public string GetFinalMeetingText(int meetingId)
        {
            string finalText = "";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"SELECT a.Title, t.TranscribedText 
                               FROM Agendas a
                               JOIN Transcriptions t ON a.AgendaID = t.AgendaID
                               WHERE a.MeetingID = @mid AND t.Status = 'Approved'
                               ORDER BY a.AgendaID ASC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mid", meetingId);
                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        finalText += "AGENDA: " + r["Title"].ToString() + "\r\n";
                        finalText += r["TranscribedText"].ToString() + "\r\n\r\n";
                    }
                }
            }
            return finalText;
        }

        public string GetExistingTranscription(int agendaId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // We look for any text saved for this specific Agenda
                string sql = "SELECT TranscribedText FROM Transcriptions WHERE AgendaID = @aid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@aid", agendaId);

                conn.Open();
                object result = cmd.ExecuteScalar(); // Get just the one text value

                // If result is null, return empty string; otherwise return the saved text
                return result != null ? result.ToString() : "";
            }
        }

        public Transcription GetExistingTranscriptionData(int agendaId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Select BOTH the text and the editor's comments
                string sql = "SELECT TranscribedText, EditorComments FROM Transcriptions WHERE AgendaID = @aid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@aid", agendaId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Transcription
                        {
                            TranscribedText = reader["TranscribedText"]?.ToString() ?? "",
                            EditorComments = reader["EditorComments"]?.ToString() ?? ""
                        };
                    }
                }
            }
            return null; // Return null if no record exists yet
        }


    }
}