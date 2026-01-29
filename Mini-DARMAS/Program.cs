using Mini_DARMAS.Forms;
using MiniDarmas.Models;
using System;
using System.Windows.Forms;

namespace Mini_DARMAS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            LoginForm login = new LoginForm();

            if (login.ShowDialog() == DialogResult.OK)
            {
                
                string userRole = SessionManager.CurrentUser.Role;

                
                switch (userRole)
                {
                    case "Admin":
                        Application.Run(new AdminUserForm());
                        break;
                    case "Operator":
                        Application.Run(new OperatorForm());
                        break;
                    case "Transcriber":
                        Application.Run(new TranscriberForm());
                        break;
                    case "Editor":
                        Application.Run(new EditorForm());
                        break;
                    case "Approver":
                        Application.Run(new ApproverForm());
                        break;
                    
                    default:
                        MessageBox.Show("Role not recognized. Access Denied.");
                        break;
                }
            }
        }
    }
}