using System;

namespace MiniDarmas.Models
{
    
    public static class SessionManager
    {
        
        public static User CurrentUser { get; private set; }

        
        public static event EventHandler UserChanged;

        // Helper property to check if anyone is logged in
        public static bool IsLoggedIn => CurrentUser != null;

        
        public static void Login(User user)
        {
            CurrentUser = user;

            // Trigger the event (check if anyone is listening first with '?.')
            UserChanged?.Invoke(null, EventArgs.Empty);
        }

        
        public static void Logout()
        {
            CurrentUser = null;

            
            UserChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}