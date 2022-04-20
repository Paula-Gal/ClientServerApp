using Model.Domain;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginPageForm : Form
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
            // EmployeePageController employeePageController = new EmployeePageController(loginPageController.GetService());
            EmployeePageForm employeePageForm = new EmployeePageForm(this, loginPageController, loginPageController.GetEmployeePageController() ,employee);
            employeePageForm.Show();
            Visible = false;
        }

        private void LoginPageForm_Load(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
