using Model.Domain;
using Services;

namespace Client
{
    public class LoginPageController
    {
        private readonly IServices server;
        private EmployeePageController employeePageController;
        public LoginPageController(IServices server, EmployeePageController employeePageController)
        {
            this.server = server;
            this.employeePageController = employeePageController;
        }

        public Employee Login(string username, string password)
        {
            return server.Login(username, password, employeePageController);
        }

        public IServices GetService()
        {
            return server;
        }

        public EmployeePageController GetEmployeePageController()
        {
            return employeePageController;
        }

    }
}
