using _DoAn.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _DoAn.Views
{
    public partial class LoginView : Form, ILoginView
    {
        private string _message;
        private LoginPresenter loginPresenter;

        public LoginView()
        {
            InitializeComponent();
            loginPresenter = new LoginPresenter(this);
            panelChangePassword.Hide();
            panelForgotpassword.Hide();
            lbResend.Hide();

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
            int valid = loginPresenter.Login();
            if (valid == 2)
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
            if (valid == 1)
            {
                panelChangePassword.Show();
                panelForgotpassword.Hide();
                panelLogin.Hide();
            }
            else
            {
                MessageBox.Show(_message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void tbnChangePassword_Click(object sender, EventArgs e)
        {
            loginPresenter.CheckInfoFill();
            if (loginPresenter.VerifyOTP())
            {
                panelChangePassword.Show();
                panelLogin.Hide();
                panelForgotpassword.Hide();
            }
            else
            {
                MessageBox.Show(_message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelForgotpassword.Show();
            panelChangePassword.Hide();
            panelLogin.Hide();
        }

        private void lbBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLogin.Show();
            panelChangePassword.Hide();
            panelForgotpassword.Hide();
            lbResend.Hide();
            lbSend.Show();
        }

        private void lbSend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbSend.Hide();
            lbResend.Show();

            string email = loginPresenter.GetEmail();
            if (tbxUsernameFP.Text.Length == 0)
            {
                MessageBox.Show("Please entered your username!");
            }
            else if ((email.Equals("No email found for this username")))
            {
                MessageBox.Show("No email found for this username");
            }
            else loginPresenter.SendEmailOTP(email);
        }

        private void tbnConfirm_Click(object sender, EventArgs e)
        {
            if (loginPresenter.VerifyNewPassword())
            {
                if (loginPresenter.UpdatePassword())
                {
                    MessageBox.Show("Password is now changed!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
            else
            {
                MessageBox.Show("Wrong password re-entered, please check again!");
            }
        }

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSignin_Click(sender, e);
            }
        }

        private void tbxOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                tbnChangePassword_Click(sender, e);
            }
        }

        private void tbxNewPassword2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tbnConfirm_Click(sender, e);
            }
        }

        private void tbxUsername_TextChange(object sender, EventArgs e)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 

            string currentText = tbxUsername.Text;
            string newText = ""; 

            foreach (char c in currentText)
            {
                if (allowedChars.Contains(c)) 
                {
                    newText += c;
                }
            }

            tbxUsername.Text = newText; 
            tbxUsername.SelectionStart = tbxUsername.Text.Length; 
        }

        private void tbxPassword_TextChange(object sender, EventArgs e)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 

            string currentText = tbxPassword.Text;
            string newText = ""; 

            foreach (char c in currentText)
            {
                if (allowedChars.Contains(c)) 
                {
                    newText += c;
                }
            }

            tbxPassword.Text = newText; 
            tbxPassword.SelectionStart = tbxPassword.Text.Length; 
        }
    }
}
