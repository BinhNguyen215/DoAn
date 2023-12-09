using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Supplier
{
    public interface ISupplier
    {
        string SuplierId { get; set; }
        string SuplierName { get; set; }
        string SuplierPhone { get; set; }
        string SuplierAddress { get; set; }
        string SuplierEmail { get; set; }
        string message { get; set; }
        BunifuDataGridView gvData { get; set; }
    }
}
