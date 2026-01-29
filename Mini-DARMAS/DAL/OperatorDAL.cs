using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MiniDarmas.Models;

namespace Mini_DARMAS.DAL
{
    public class OperatorDAL
    {
        // 1. Get all Transcribers for the ComboBox
        public DataTable GetTranscribersList()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "SELECT UserID, FullName FROM Users WHERE Role = 'Transcriber' AND IsActive = 1";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Add an Agenda and Recording together
        public bool AddAgendaWithRecording(int meetingId, string title, string office, string audioPath)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Insert Agenda
                    string sqlAgenda = "INSERT INTO Agendas (MeetingID, Title, Office) OUTPUT INSERTED.AgendaID VALUES (@mid, @t, @o)";
                    SqlCommand cmdA = new SqlCommand(sqlAgenda, conn, trans);
                    cmdA.Parameters.AddWithValue("@mid", meetingId);
                    cmdA.Parameters.AddWithValue("@t", title);
                    cmdA.Parameters.AddWithValue("@o", office);
                    int agendaId = (int)cmdA.ExecuteScalar();

                    // Insert Recording Path
                    string sqlRec = "INSERT INTO Recordings (AgendaID, FilePath, FileName) VALUES (@aid, @path, @name)";
                    SqlCommand cmdR = new SqlCommand(sqlRec, conn, trans);
                    cmdR.Parameters.AddWithValue("@aid", agendaId);
                    cmdR.Parameters.AddWithValue("@path", audioPath);
                    cmdR.Parameters.AddWithValue("@name", System.IO.Path.GetFileName(audioPath));
                    cmdR.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch { trans.Rollback(); return false; }
            }
        }
    }
}