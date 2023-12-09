using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Employee
{
    public interface IManageEmployeeView
    {
        string employee_id { get; set; }
        string message { get; set; }
        BunifuDataGridView dgvEmployee { get; set; }
    }
}
