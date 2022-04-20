using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proiect_CSharp_MPP.TouristAgency.Service;
using Proiect_CSharp_MPP.TouristAgency.Domain;
using Proiect_CSharp_MPP.TouristAgency.Exceptions;

namespace Proiect_CSharp_MPP
{
    partial class EmployeePageForm : Form
    {
        private LoginPageForm loginPageForm;
        private EmployeePageController employeePageController;
        private LoginPageController loginPageController;
        private Employee employee;

        public EmployeePageForm(LoginPageForm loginPageForm, LoginPageController loginPageController, EmployeePageController employeePageController, Employee employee)
        {
            this.loginPageForm = loginPageForm;
            this.loginPageController = loginPageController;
            this.employeePageController = employeePageController;
            this.employee = employee;
            InitializeComponent();
            InitializeDataGridView();
        }

        public void InitializeDataGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Destination", typeof(string));
            dataTable.Columns.Add("Departure", typeof(DateTime));
            dataTable.Columns.Add("Airport", typeof(string));
            dataTable.Columns.Add("Seats", typeof(int));
            List<Flight> allFlights = employeePageController.GetAllFlights();
            foreach(Flight flight in allFlights)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Destination"] = flight.Destination;
                dataRow["Departure"] = flight.DepartureDate;
                dataRow["Airport"] = flight.Airport;
                dataRow["Seats"] = flight.NumberOfAvailablePlaces;
                dataTable.Rows.Add(dataRow);
            }
            
            dataGridViewFlights.DataSource = dataTable;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            loginPageForm.Visible = true;
            Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Flight> flights = employeePageController.FilterByDestinationAndDepartureDate(textBoxSearchDestination.Text, dateTimePickerDeparture.Value);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Destination", typeof(string));
            dataTable.Columns.Add("Departure", typeof(DateTime));
            dataTable.Columns.Add("Seats", typeof(int));
            foreach (Flight flight in flights)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["id"] = flight.ID;
                dataRow["Destination"] = flight.Destination;
                dataRow["Departure"] = flight.DepartureDate;
                dataRow["Seats"] = flight.NumberOfAvailablePlaces;
                dataTable.Rows.Add(dataRow);
            }

            dataGridViewFilteredFlights.DataSource = dataTable;
            dataGridViewFilteredFlights.Columns[0].Visible = false;
        }

        private void buttonPurchaseTicket_Click(object sender, EventArgs e)
        {
            if (dataGridViewFilteredFlights.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a flight!\n");
            }
            else
            {
                DataGridViewRow selectedRow = dataGridViewFilteredFlights.SelectedRows[0];
                int flightId = (int)selectedRow.Cells[0].Value;
                PurchaseTicketPageController purchaseTicketPageController = new PurchaseTicketPageController(employeePageController.GetService());
                PurchaseTicketPageForm purchaseTicketPageForm = new PurchaseTicketPageForm(purchaseTicketPageController, flightId);
                purchaseTicketPageForm.Show();
            }
            
        }
    }
}
