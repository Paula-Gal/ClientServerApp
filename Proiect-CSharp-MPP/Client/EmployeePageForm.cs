using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Client
{
    public partial class EmployeePageForm : Form
    {
        private LoginPageForm loginPageForm;
        private EmployeePageController employeePageController;
        private LoginPageController loginPageController;
        private Employee employee;
        private IList<Ticket> tickets;
        private IList<Flight> allFlights;

        public EmployeePageForm(LoginPageForm loginPageForm, LoginPageController loginPageController, EmployeePageController employeePageController, Employee employee)
        {
            Console.WriteLine("employee page form invoked");
            InitializeComponent();
            this.loginPageForm = loginPageForm;
            this.loginPageController = loginPageController;
            this.employeePageController = employeePageController;
            this.employee = employee;
            this.allFlights = employeePageController.GetAllFlights();
            dataGridViewFlights.DataSource = allFlights;
            Console.WriteLine("Preparing to enter in user update");
            employeePageController.updateEvent += userUpdate;
            InitializeDataGridView();
        }
        
        public void userUpdate(object sender, EmployeeEventArgs e)
        {
            Ticket ticket = (Ticket) e.Data;

            if (e.EmployeeEventType == EmployeeEvent.TicketPurchased)
            {
                Console.WriteLine("userUpdate invoked");
            
                foreach (var flight in allFlights)
                {
                    if (ticket.Flight.ID == flight.ID)
                    {
                        flight.NumberOfAvailablePlaces -= ticket.NumberOfPlaces;
                    }
                } 
                
                // nu intra in updateGridView
                // aici se blocheaza
                
                // dataGridViewFlights.BeginInvoke(new UpdateDataGridViewCallBack(this.updateGridView),
                //     new object[] {dataGridViewFlights, allFlights, e.Data});
                //ultima var
                dataGridViewFlights.BeginInvoke(new UpdateDataGridViewCallBack(this.updateGridView), dataGridViewFlights, allFlights);
                
                // dataGridViewFlights.Invoke((MethodInvoker) delegate
                // {
                //     Console.WriteLine("HERE");
                //     dataGridViewFlights.DataSource = null;
                //     dataGridViewFlights.DataSource = allFlights;
                //     InitializeDataGridView();
                // });
            }
        }
        
        // public delegate void UpdateDataGridViewCallBack(DataGridView dataGridView, IList<Flight> flights, TicketDto ticketDto);
         public delegate void UpdateDataGridViewCallBack(DataGridView dataGridView, IList<Flight> flights);

        public void InitializeDataGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Destination", typeof(string));
            dataTable.Columns.Add("Departure", typeof(DateTime));
            dataTable.Columns.Add("Airport", typeof(string));
            dataTable.Columns.Add("Seats", typeof(int));
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
        
        private void updateGridView(DataGridView dataGridView, IEnumerable<Flight> flightsNew)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = flightsNew;
            InitializeDataGridView();

            // foreach (var flight in allFlights)
            // {
            //     if (ticketDto.FlightId.ID == flight.ID)
            //     {
            //         flight.NumberOfAvailablePlaces -= ticketDto.Seats;
            //     }
            // } 
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            loginPageForm.Visible = true;
            Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Search from Employee Form");
            List<Flight> flights = employeePageController.FilterByDestinationAndDepartureDate(textBoxSearchDestination.Text, dateTimePickerDeparture.Value);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Destination", typeof(string));
            dataTable.Columns.Add("Departure", typeof(DateTime));
            dataTable.Columns.Add("Airport", typeof(string));
            dataTable.Columns.Add("Seats", typeof(int));
            foreach (Flight flight in flights)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["id"] = flight.ID;
                dataRow["Destination"] = flight.Destination;
                dataRow["Departure"] = flight.DepartureDate;
                dataRow["Airport"] = flight.Airport;
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

                Flight flight = new Flight((int)selectedRow.Cells[0].Value, selectedRow.Cells[1].Value.ToString(), (DateTime) selectedRow.Cells[2].Value,
                    selectedRow.Cells[3].Value.ToString(), (int)selectedRow.Cells[4].Value);
                try
                {
                    PurchaseTicketPageController purchaseTicketPageController =
                        new PurchaseTicketPageController(employeePageController.GetService());
                    PurchaseTicketPageForm purchaseTicketPageForm =
                        new PurchaseTicketPageForm(purchaseTicketPageController, flight);
                    purchaseTicketPageForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void EmployeePageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
