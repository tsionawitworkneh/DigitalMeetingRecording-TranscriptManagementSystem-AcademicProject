using Mini_DARMAS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace MiniDarmas.DAL
{
    public class AssignmentDAL
    {
        public void AssignTranscriber(int agendaId, int userId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "INSERT INTO Assignments (AgendaID, TranscriberID, Status) VALUES (@aid, @uid, 'Assigned')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@aid", agendaId);
                cmd.Parameters.AddWithValue("@uid", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetTranscriberTasks(int transcriberId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = @"SELECT a.AgendaID, m.MeetingNo, a.Title, ass.Status 
                               FROM Assignments ass
                               JOIN Agendas a ON ass.AgendaID = a.AgendaID
                               JOIN Meetings m ON a.MeetingID = m.MeetingID
                               WHERE ass.TranscriberID = @tid";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@tid", transcriberId);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetTranscriberQueue(int transcriberId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Join Assignments, Agendas, Meetings, and Recordings to get all info for the UI
                string sql = @"SELECT 
                        A.AgendaID, 
                        M.MeetingNo, 
                        Ag.Title AS AgendaTitle, 
                        R.FileName, 
                        R.FilePath, 
                        CASE 
                            WHEN T.Status = 'Returned' THEN 'Returned' 
                            ELSE A.Status 
                        END AS Status
                       FROM Assignments A
                       JOIN Agendas Ag ON A.AgendaID = Ag.AgendaID
                       JOIN Meetings M ON Ag.MeetingID = M.MeetingID
                       JOIN Recordings R ON Ag.AgendaID = R.AgendaID
                       LEFT JOIN Transcriptions T ON Ag.AgendaID = T.AgendaID
                       WHERE A.TranscriberID = @tid AND A.Status != 'Completed'";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@tid", transcriberId);
                da.Fill(dt);
            }
            return dt;
        }

        public void UpdateStatus(int agendaId, string status)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "UPDATE Assignments SET Status = @s WHERE AgendaID = @aid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@aid", agendaId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStatusByTranscriptionId(int transId, string status)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // This subquery finds the AgendaID linked to the TranscriptionID
                string sql = @"UPDATE Assignments 
                       SET Status = @s 
                       WHERE AgendaID = (SELECT AgendaID FROM Transcriptions WHERE TranscriptionID = @tid)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@tid", transId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}