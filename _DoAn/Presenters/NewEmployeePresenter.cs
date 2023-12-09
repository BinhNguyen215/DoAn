using _DoAn.Models;
using _DoAn.Views.Employee;
using _DoAn.Views.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public  class NewEmployeePresenter
    {
        INewEmployee newEmployeeview;
        User user = new User();
        public NewEmployeePresenter(INewEmployee view)
        {
            newEmployeeview = view;
        }
        public bool AddData()
        {
            if (CheckInformation())
            {
                if (newEmployeeview.Positiontext == "ShopOwner" || newEmployeeview.Positiontext == "SalesMan"
                 || newEmployeeview.Positiontext == "InventoryDepartment" || newEmployeeview.Positiontext == "AccountingDepartment")
                {
                    if (user.AddEmployee(newEmployeeview.Nametext, newEmployeeview.Citizen_idtext, newEmployeeview.Emailtext,
                newEmployeeview.PhoneNumtext, newEmployeeview.Positiontext, newEmployeeview.Addresstext))
                    {
                        newEmployeeview.message = "Add employee successfully";
                        return true;
                    }
                    else
                    {
                        newEmployeeview.message = "Add employee failed";
                        return false;
                    }
                }
                else
                {
                    newEmployeeview.message = "Position is not exist. Please try again";
                    return false;
                }
            }
            else
            {
                newEmployeeview.message = "Please fullfill information";
                return false;
            }

        }
        public bool EditData()
        {
            if (CheckInformation())
            {
                if (newEmployeeview.Positiontext == "ShopOwner" || newEmployeeview.Positiontext == "SalesMan"
                  || newEmployeeview.Positiontext == "InventoryDepartment" || newEmployeeview.Positiontext == "AccountingDepartment")
                {
                    if (user.UpdateEmployee(newEmployeeview.employee_id, newEmployeeview.Nametext,
                  newEmployeeview.Citizen_idtext, newEmployeeview.Emailtext, newEmployeeview.PhoneNumtext,
                  newEmployeeview.Positiontext, newEmployeeview.Addresstext, newEmployeeview.Username, newEmployeeview.Password))
                    {
                        newEmployeeview.message = "Update employee successfully";
                        return true;
                    }
                    else
                    {
                        newEmployeeview.message = "Update employee failed";
                        return false;
                    }
                }
                else
                {
                    newEmployeeview.message = "Position is not exist. Please try again";
                    return false;
                }
            }
            else
            {
                newEmployeeview.message = "Please fullfill information";
                return false;
            }

        }
        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(newEmployeeview.Nametext))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(newEmployeeview.PhoneNumtext))
                return false;
            else if (string.IsNullOrEmpty(newEmployeeview.Citizen_idtext))
                return false;
            // else if (string.IsNullOrEmpty(newEmployeeview.Positiontext))
            else if (newEmployeeview.Positiontext == "")
                return false;
            else if (string.IsNullOrEmpty(newEmployeeview.Emailtext))
                return false;
            else if (string.IsNullOrEmpty(newEmployeeview.Addresstext))
                return false;
            /* else if (string.IsNullOrEmpty(newEmployeeview.Username))
                 return false;
             else if (string.IsNullOrEmpty(newEmployeeview.Password))
                 return false;*/
            else
                return true;
        }
        public bool RetriveData(string name, string phone, string citizenID, string position,
          string email, string address, string username, string password)
        {
            ClearInformation();
            newEmployeeview.Nametext = name;
            newEmployeeview.PhoneNumtext = phone;
            newEmployeeview.Citizen_idtext = citizenID;
            newEmployeeview.Positiontext = position;
            newEmployeeview.Emailtext = email;
            newEmployeeview.Addresstext = address;
            newEmployeeview.Username = username;
            newEmployeeview.Password = password;


            return true;
        }

        public bool ClearInformation()
        {
            newEmployeeview.Nametext = "";
            newEmployeeview.PhoneNumtext = "";
            newEmployeeview.Citizen_idtext = "";
            newEmployeeview.Positiontext = "";
            newEmployeeview.Emailtext = "";
            newEmployeeview.Addresstext = "";
            newEmployeeview.Username = "";
            newEmployeeview.Password = "";

            return true;
        }
       
    }
}
