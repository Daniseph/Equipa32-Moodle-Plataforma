\\Base da implementação do formulário de login
using System;
using System.Windows.Forms;

namespace PlatGestMoo
{
    public partial class LoginForm : Form
    {
        private Controller controller;

        public LoginForm(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            controller.Login(username, password);
        }
    }
}
