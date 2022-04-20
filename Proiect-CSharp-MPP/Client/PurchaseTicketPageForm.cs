using Model.Validators;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model.Domain;

namespace Client
{
    partial class PurchaseTicketPageForm : Form
    {
        private Flight flight;
        private PurchaseTicketPageController purchaseTicketPageController;
        public PurchaseTicketPageForm(PurchaseTicketPageController purchaseTicketPageController, Flight flight)
        {
            InitializeComponent();
            this.flight = flight;
            this.purchaseTicketPageController = purchaseTicketPageController;
        }

        private void buttonAddTourist_Click(object sender, EventArgs e)
        {
            listViewTourists.Items.Add(textBoxTouristName.Text);
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button finished buy a ticket pressed - Form!");
            List<string> tourists = new List<string>();
            foreach(ListViewItem item in listViewTourists.Items)
            {
                tourists.Add(item.Text);
            }
            int seats = tourists.Count() + 1;
        try
            {
                Console.WriteLine("Trying to purchase ticket - Form!");
                purchaseTicketPageController.purchaseTicket(textBoxCustomerName.Text, textBoxCustomerCnp.Text, textBoxCustomerAddress.Text, flight, tourists, seats);
                textBoxCustomerName.Clear();
                textBoxCustomerCnp.Clear();
                textBoxCustomerAddress.Clear();
                textBoxTouristName.Clear();
                listViewTourists.Clear();
            }
            catch(ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void PurchaseTicketPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
