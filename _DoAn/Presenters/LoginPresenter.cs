using _DoAn.Models;
using _DoAn.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace _DoAn.Presenters
{
    public  class LoginPresenter
    {
        ILoginView loginView;
        string storedOTP;
        public LoginPresenter(ILoginView loginView)
        {
            this.loginView = loginView;
            storedOTP = generateOTP();
        }

        public bool Login()
        {
            User user = new User();

            if (user.CheckValidate(loginView.username, loginView.password))
            {
                loginView.message = string.Format("Login successfully!");
                return true;
            }

            else
            {
                loginView.message = string.Format("Fail to login! Check your Username and Password again");
                return false;
            }
        }
        public string GetId()
        {
            User user = new User();
            return user.UserID(loginView.username, loginView.password);
        }
        public string GetName()
        {
            User user = new User();
            return user.UserName(loginView.username, loginView.password);
        }
        public string GetPosition()
        {
            User user = new User();
            return user.GetPosition(loginView.username, loginView.password);
        }
        public string GetEmail()
        {
            User user = new User();
            return user.GetEmail(loginView.usernameFP);
        }
        

        public void SendEmailOTP(string email)
        {
            try
            { 

                var fromAddress = new MailAddress("kiseryouta2003@gmail.com");
                var toAddress = new MailAddress(email);

                const string fromPass = "ixrb qaxf csve vpvt";
                const string subject = "OTP code";
                string body = $"Your OTP code is {storedOTP}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPass),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("OTP is now send to mail!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        public string generateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }

        public bool VerifyOTP()
        {
            return storedOTP.Equals(loginView.OTP);
        }

        public bool VerifyNewPassword()
        {
            return loginView.newPassword.Equals(loginView.newPasswordAgain);
        }

        public bool UpdatePassword()
        {
            User user = new User();
            return user.UpdatePassword(loginView.usernameFP,loginView.newPasswordAgain);
        }
    }
}
