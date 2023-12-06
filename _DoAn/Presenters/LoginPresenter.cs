using _DoAn.Models;
using _DoAn.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public  class LoginPresenter
    {
        ILoginView loginView;

        public LoginPresenter(ILoginView loginView)
        {
            this.loginView = loginView;
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
    }
}
