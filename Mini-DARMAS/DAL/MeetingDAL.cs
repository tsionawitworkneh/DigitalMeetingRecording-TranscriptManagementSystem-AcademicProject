using MiniDarmas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Mini_DARMAS.DAL
{
    public class MeetingDAL
    {
        
        public List<Meeting> GetAllMeetings()
        {
            List<Meeting> meetings = new List<Meeting>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "SELECT * FROM Meetings ORDER BY MeetingDate DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        meetings.Add(new Meeting
                        {
                            MeetingID = (int)r["MeetingID"],
                            MeetingNo = r["MeetingNo"].ToString(),
                            MeetingDate = (DateTime)r["MeetingDate"],
                            Location = r["Location"].ToString(),
                            Chairperson = r["Chairperson"].ToString(),
                            Status = r["Status"].ToString()
                        });
                    }
                }
            }
            return meetings;
        }

        public DataTable GetMeetingAgendas(int meetingId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // We filter by @mid to only get agendas for the selected meeting
                string sql = "SELECT AgendaID, MeetingID, Title, Office, SupportingDocPath FROM Agendas WHERE MeetingID = @mid";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@mid", meetingId);

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    // Useful for debugging if the column names don't match exactly
                    throw new Exception("Error fetching meeting agendas: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable GetAllAgendas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Use LEFT JOINs so we see ALL agendas, even those not yet assigned
                string sql = @"SELECT 
                        A.AgendaID, 
                        M.MeetingNo, 
                        A.Title, 
                        ISNULL(U.FullName, '---') AS Transcriber, 
                        ISNULL(ASS.Status, 'Pending Assignment') AS [Work Status]
                       FROM Agendas A
                       INNER JOIN Meetings M ON A.MeetingID = M.MeetingID
                       LEFT JOIN Assignments ASS ON A.AgendaID = ASS.AgendaID
                       LEFT JOIN Users U ON ASS.TranscriberID = U.UserID";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // AddAgendaWithRecording
        public bool AddAgendaWithRecording(int meetingId, string title, string office, string suppDoc, string audioPath)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlA = "INSERT INTO Agendas (MeetingID, Title, Office, SupportingDocPath) OUTPUT INSERTED.AgendaID VALUES (@mid, @t, @o, @d)";
                    SqlCommand cmdA = new SqlCommand(sqlA, conn, trans);
                    cmdA.Parameters.AddWithValue("@mid", meetingId);
                    cmdA.Parameters.AddWithValue("@t", title);
                    cmdA.Parameters.AddWithValue("@o", office);
                    cmdA.Parameters.AddWithValue("@d", suppDoc);
                    int agendaId = (int)cmdA.ExecuteScalar();

                    string sqlR = "INSERT INTO Recordings (AgendaID, FilePath, FileName) VALUES (@aid, @p, @n)";
                    SqlCommand cmdR = new SqlCommand(sqlR, conn, trans);
                    cmdR.Parameters.AddWithValue("@aid", agendaId);
                    cmdR.Parameters.AddWithValue("@p", audioPath);
                    cmdR.Parameters.AddWithValue("@n", System.IO.Path.GetFileName(audioPath));
                    cmdR.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch { trans.Rollback(); return false; }
            }
        }

        // Add this empty CreateMeeting method if it is missing
        public int CreateMeeting(Meeting m)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "INSERT INTO Meetings (MeetingNo, MeetingDate, Location, Chairperson, Status) OUTPUT INSERTED.MeetingID VALUES (@no, @dt, @loc, @chair, @st)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@no", m.MeetingNo);
                cmd.Parameters.AddWithValue("@dt", m.MeetingDate);
                cmd.Parameters.AddWithValue("@loc", m.Location);
                cmd.Parameters.AddWithValue("@chair", m.Chairperson);
                cmd.Parameters.AddWithValue("@st", m.Status);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }


        // Add these inside public class MeetingDAL
        public bool UpdateMeeting(Meeting m)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"UPDATE Meetings SET MeetingNo=@no, MeetingDate=@dt, 
                       Location=@loc, Chairperson=@chair WHERE MeetingID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@no", m.MeetingNo);
                cmd.Parameters.AddWithValue("@dt", m.MeetingDate);
                cmd.Parameters.AddWithValue("@loc", m.Location);
                cmd.Parameters.AddWithValue("@chair", m.Chairperson);
                cmd.Parameters.AddWithValue("@id", m.MeetingID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteMeeting(int meetingId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Delete Assignments
                    string sql1 = @"DELETE FROM Assignments WHERE AgendaID IN 
                            (SELECT AgendaID FROM Agendas WHERE MeetingID = @mid)";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn, trans);
                    cmd1.Parameters.AddWithValue("@mid", meetingId);
                    cmd1.ExecuteNonQuery();

                    // 2. Delete Recordings
                    string sql2 = @"DELETE FROM Recordings WHERE AgendaID IN 
                            (SELECT AgendaID FROM Agendas WHERE MeetingID = @mid)";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn, trans);
                    cmd2.Parameters.AddWithValue("@mid", meetingId);
                    cmd2.ExecuteNonQuery();

                    // 3. ADD THIS: Delete Transcriptions (This is what caused your error)
                    string sqlTrans = @"DELETE FROM Transcriptions WHERE AgendaID IN 
                                (SELECT AgendaID FROM Agendas WHERE MeetingID = @mid)";
                    SqlCommand cmdTrans = new SqlCommand(sqlTrans, conn, trans);
                    cmdTrans.Parameters.AddWithValue("@mid", meetingId);
                    cmdTrans.ExecuteNonQuery();

                    // 4. Delete the Agendas
                    string sql3 = "DELETE FROM Agendas WHERE MeetingID = @mid";
                    SqlCommand cmd3 = new SqlCommand(sql3, conn, trans);
                    cmd3.Parameters.AddWithValue("@mid", meetingId);
                    cmd3.ExecuteNonQuery();

                    // 5. Finally, delete the Meeting
                    string sql4 = "DELETE FROM Meetings WHERE MeetingID = @mid";
                    SqlCommand cmd4 = new SqlCommand(sql4, conn, trans);
                    cmd4.Parameters.AddWithValue("@mid", meetingId);
                    cmd4.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    // Optional: Log the error or show it
                    MessageBox.Show("Delete failed: " + ex.Message);
                    return false;
                }
            }
        }

        // 1. Update Agenda Details
        public bool UpdateAgenda(int agendaId, string title, string office, string suppDoc, string audioPath)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 1. Update Agendas Table
                    string sqlAg = "UPDATE Agendas SET Title=@t, Office=@o, SupportingDocPath=@d WHERE AgendaID=@id";
                    SqlCommand cmd1 = new SqlCommand(sqlAg, conn, trans);
                    cmd1.Parameters.AddWithValue("@t", title);
                    cmd1.Parameters.AddWithValue("@o", office);
                    cmd1.Parameters.AddWithValue("@d", suppDoc);
                    cmd1.Parameters.AddWithValue("@id", agendaId);
                    cmd1.ExecuteNonQuery();

                    // 2. Update Recordings Table
                    // Only update if a new path was provided (audioPath is not empty)
                    if (!string.IsNullOrEmpty(audioPath))
                    {
                        string sqlRec = "UPDATE Recordings SET FilePath=@p, FileName=@n WHERE AgendaID=@id";
                        SqlCommand cmd2 = new SqlCommand(sqlRec, conn, trans);
                        cmd2.Parameters.AddWithValue("@p", audioPath);
                        cmd2.Parameters.AddWithValue("@n", Path.GetFileName(audioPath));
                        cmd2.Parameters.AddWithValue("@id", agendaId);
                        cmd2.ExecuteNonQuery();

                        // 3. Update Assignments Table (Logic Fix)
                        // If the audio changed, we reset the status to 'Assigned' 
                        // so the transcriber knows to start fresh with the new file.
                        string sqlAss = "UPDATE Assignments SET Status = 'Assigned' WHERE AgendaID = @id";
                        SqlCommand cmd3 = new SqlCommand(sqlAss, conn, trans);
                        cmd3.Parameters.AddWithValue("@id", agendaId);
                        cmd3.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // 2. Delete Agenda
        public bool DeleteAgenda(int agendaId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Delete related children first 
                    string sqlRec = "DELETE FROM Recordings WHERE AgendaID = @id";
                    new SqlCommand(sqlRec, conn, trans).Parameters.AddWithValue("@id", agendaId);

                    string sqlAss = "DELETE FROM Assignments WHERE AgendaID = @id";
                    new SqlCommand(sqlAss, conn, trans).Parameters.AddWithValue("@id", agendaId);

                    string sqlTrans = "DELETE FROM Transcriptions WHERE AgendaID = @id";
                    new SqlCommand(sqlTrans, conn, trans).Parameters.AddWithValue("@id", agendaId);

                    // Finally delete the agenda
                    string sqlAg = "DELETE FROM Agendas WHERE AgendaID = @id";
                    SqlCommand cmd = new SqlCommand(sqlAg, conn, trans);
                    cmd.Parameters.AddWithValue("@id", agendaId);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}