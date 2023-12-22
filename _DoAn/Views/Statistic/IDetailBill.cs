using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Statistic
{
    public interface IDetailBill
    {
        string Name { get; set; }
        string BillId { get; set; }
        string Date { get; set; }

        BunifuDataGridView dtgvDetail { get; set; }
    }
}
