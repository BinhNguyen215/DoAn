using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Sale
{
    public interface ISaleView
    {
        string Find { get; set; }
        string Cus_Name { get; set; }
        string Phone { get; set; }
        string Employee { get; }
        string BillValue { get; set; }
        string Product_id { get; set; }
        string Product_Name { get; set; }
        string Price { get; set; }
        string Quantities { get; set; }
        string Unit_Name{ get; set; }
        string message { get; set; }
        BunifuDataGridView dgvCart { get; set; }
        BunifuDataGridView dgv_ListProduct { get; set; }
        BunifuDataGridView dgvDetailBill { get; set; }
    }
}
