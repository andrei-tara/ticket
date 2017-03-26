using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Controller;
using App.UI;
using Core.Manager;

namespace App.UI
{
    public partial class LoginView : Form
    {
       
        public LoginView()
        {
            InitializeComponent();
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

           var user  = UserManager.Instance.Login(emailTextBox.Text, passwordTextBox.Text);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials !");
                return;
            }
            
            FlowController.Instance.Context.UserId = user.Id;
            FlowController.Instance.NavigateToTicketList(user.Id);
            Hide();
        }
    }
}
