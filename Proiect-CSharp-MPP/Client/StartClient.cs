using Networking;
using Services;
using System;
using System.Windows.Forms;

namespace Client
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IServices server = new ServerProxy("127.0.0.1", 55565);
            EmployeePageController employeePageController = new EmployeePageController(server);
            LoginPageController loginPageController = new LoginPageController(server, employeePageController);
            LoginPageForm loginPageForm = new LoginPageForm(loginPageController);
            Application.Run(loginPageForm);
        }
    }
}
