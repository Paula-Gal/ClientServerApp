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
    partial class LoginPageForm : Form
    {
        private LoginPageController loginPageController;
        public LoginPageForm(LoginPageController loginPageController)
        {
            this.loginPageController = loginPageController;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Employee employee = loginPageController.Login(textBoxUsername.Text, textBoxPassword.Text);
            EmployeePageController employeePageController = new EmployeePageController(loginPageController.GetService());
            EmployeePageForm employeePageForm = new EmployeePageForm(this, loginPageController, employeePageController ,employee);
            employeePageForm.Show();
            Visible = false;
        }
    }
}
