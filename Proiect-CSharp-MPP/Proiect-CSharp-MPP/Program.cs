using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proiect_CSharp_MPP.TouristAgency.Repository;
using Proiect_CSharp_MPP.TouristAgency.Service;
using Proiect_CSharp_MPP.TouristAgency.Validators;

namespace Proiect_CSharp_MPP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ICustomerRepository customerRepo = new CustomerDBRepository();
            IFlightRepository flightRepo = new FlightDBRepository();
            IEmployeeRepository employeeRepo = new EmployeeDBRepository();
            ITicketRepository ticketRepo = new TicketDBRepository();
            TicketValidator ticketValidator = new TicketValidator();
            CustomerValidator customerValidator = new CustomerValidator();
            Service service = new Service(customerRepo, employeeRepo, flightRepo, ticketRepo, ticketValidator, customerValidator);
            LoginPageController loginPageController = new LoginPageController(service);
            LoginPageForm loginPageForm = new LoginPageForm(loginPageController);
            Application.Run(loginPageForm);
        }
    }
}
