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
    partial class PurchaseTicketPageForm : Form
    {
        private int flightId;
        private PurchaseTicketPageController purchaseTicketPageController;
        public PurchaseTicketPageForm(PurchaseTicketPageController purchaseTicketPageController, int flightId)
        {
            this.flightId = flightId;
            this.purchaseTicketPageController = purchaseTicketPageController;
            InitializeComponent();
        }

        private void buttonAddTourist_Click(object sender, EventArgs e)
        {
            listViewTourists.Items.Add(textBoxTouristName.Text);
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            List<string> tourists = new List<string>();
            foreach(ListViewItem item in listViewTourists.Items)
            {
                tourists.Add(item.Text);
            }
            int seats = tourists.Count() + 1;
            try
            {
                purchaseTicketPageController.purchaseTicket(textBoxCustomerName.Text, textBoxCustomerCnp.Text, textBoxCustomerAddress.Text, flightId, tourists, seats);
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
    }
}
