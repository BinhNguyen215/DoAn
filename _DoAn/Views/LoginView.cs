using _DoAn.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Views
{
    public partial class LoginView : Form, ILoginView
    {
        private string _message;
        public LoginView()
        {
            InitializeComponent();
            panelChangePassword.Hide();
            panelForgotpassword.Hide();
        }

        public string username { get => tbxUsername.Text; set => tbxUsername.Text = value; }
        public string password { get => tbxPassword.Text; set => tbxPassword.Text = value; }
        public string message { get => _message; set => _message = value; }
        public string OTP { get => tbxOTP.Text; set => tbxOTP.Text = value; }
        public string newPassword { get => tbxNewPassword.Text; set => tbxNewPassword.Text = value; }
        public string newPasswordAgain { get => tbxNewPassword2.Text; set => tbxNewPassword2.Text = value; }
        public string usernameFP { get => tbxUsernameFP.Text; set => tbxUsernameFP.Text = value; }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            LoginPresenter loginPresenter = new LoginPresenter(this);
            if (loginPresenter.Login())
            {
                string id = loginPresenter.GetId();
                string name = loginPresenter.GetName();
                string position = loginPresenter.GetPosition();
                Menu menu = new Menu(id, name, position);
                //Dialog menu = new Dialog();
                this.Hide();
                menu.ShowDialog();
                this.Show();
                tbxPassword.Clear();
            }
            else
            {
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private void tbnChangePassword_Click(object sender, EventArgs e)
        {
            panelChangePassword.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelForgotpassword.Show();
        }

        private void lbBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLogin.Show();
            panelChangePassword.Hide();
            panelForgotpassword.Hide();
        }

        private void lbSend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbSend.Hide();
            lbResend.Show();
        }
    }
}
