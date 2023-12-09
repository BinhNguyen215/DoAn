using _DoAn.Models;
using _DoAn.Views.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public class EmployeePresenter
    {
        IManageEmployeeView manageEmployeeview;
        User user = new User();

        public EmployeePresenter(IManageEmployeeView view)
        {
            manageEmployeeview = view;
        }

        public bool LoadListEmployee()
        {
            manageEmployeeview.dgvEmployee.DataSource = user.LoadListEmployee();
            return true;
        }
        public bool SearchInformation(string search)
        {
            DataTable dt = new DataTable();
            dt = user.SearchData(search);
            manageEmployeeview.dgvEmployee.DataSource = dt;
            return true;
        }


        public bool DeleteData()
        {

            if (user.DeleteEmployee(manageEmployeeview.employee_id))
            {
                manageEmployeeview.message = "Deleted employee successfully";
                return true;
            }
            else
            {
                manageEmployeeview.message = "Deleted employee unsuccessfully";
                return false;
            }
        }
    }
}