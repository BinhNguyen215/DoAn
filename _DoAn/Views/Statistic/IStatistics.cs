using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Statistic
{
    public interface IStatistics
    {
        string Date { get; set; }
        string RevenueMonth { get; set; }
        string RevenueToday { get; set; }
        string SumProduct { get; set; }
        string ProductToday { get; set; }
        string BillMonth { get; set; }
        string BillToday { get; set; }
        string EmployeeName { get; set; }
      

        BunifuDataGridView gvBestSeller { get; set; }

        BunifuDataGridView gvEmployee { get; set; }
        DataTable data { set; }
    }
}
