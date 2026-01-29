using Mini_DARMAS.DAL;
using MiniDarmas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MiniDarmas.DAL
{
    public class UserDAL
    {
        public User Login(string username, string password, string role)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Added 'AND Role = @role' to the security check
                string sql = "SELECT * FROM Users WHERE Username=@u AND Password=@p AND Role=@r AND IsActive=1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@r", role);

                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new User
                        {
                            UserID = (int)r["UserID"],
                            FullName = r["FullName"].ToString(),
                            Username = r["Username"].ToString(),
                            Role = r["Role"].ToString(),
                            IsActive = (bool)r["IsActive"]
                        };
                    }
                }
            }
            return null;
        }
        public List<User> SearchUsers(string name, string role)
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Use LIKE for partial matches
                string sql = "SELECT * FROM Users WHERE (FullName LIKE @n OR Username LIKE @n)";
                if (!string.IsNullOrEmpty(role)) sql += " AND Role = @r";

                SqlCommand cmd = new SqlCommand(sql, conn);

                // IMPORTANT: You must wrap the name in % symbols
                // Example: If name is "A", it becomes "%A%"
                cmd.Parameters.AddWithValue("@n", "%" + name + "%");

                if (!string.IsNullOrEmpty(role)) cmd.Parameters.AddWithValue("@r", role);

                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        users.Add(new User
                        {
                            UserID = (int)r["UserID"],
                            FullName = r["FullName"].ToString(),
                            Username = r["Username"].ToString(),
                            Role = r["Role"].ToString(),
                            IsActive = (bool)r["IsActive"]
                        });
                    }
                }
            }
            return users;
        }

        public bool CreateUser(User u)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "INSERT INTO Users (FullName, Username, Password, Role, IsActive) VALUES (@f, @u, @p, @r, 1)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@f", u.FullName);
                cmd.Parameters.AddWithValue("@u", u.Username);
                cmd.Parameters.AddWithValue("@p", u.Password);
                cmd.Parameters.AddWithValue("@r", u.Role);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private User MapUser(SqlDataReader r)
        {
            return new User
            {
                UserID = (int)r["UserID"],
                FullName = r["FullName"].ToString(),
                Username = r["Username"].ToString(),
                Role = r["Role"].ToString(),
                IsActive = (bool)r["IsActive"]
            };
        }

        public bool UpdateUserStatus(int userId, bool newStatus)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                
                string sql = "UPDATE Users SET IsActive = @status WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", userId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; 
            }
        }

        // 1. Update User Details
        public bool UpdateUser(User u)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string sql = "UPDATE Users SET FullName=@f, Username=@u, Password=@p, Role=@r WHERE UserID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@f", u.FullName);
                cmd.Parameters.AddWithValue("@u", u.Username);
                cmd.Parameters.AddWithValue("@p", u.Password);
                cmd.Parameters.AddWithValue("@r", u.Role);
                cmd.Parameters.AddWithValue("@id", u.UserID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 2. Delete User
        public bool DeleteUser(int userId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                // Note: If a user has assignments, this will throw an error (Foreign Key)
                // That is good! You shouldn't delete users who have meeting history.
                string sql = "DELETE FROM Users WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}