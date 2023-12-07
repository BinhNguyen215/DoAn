using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.CheckedListBox;
namespace _DoAn.Views.Accountant
{
    public interface IAddPaySlip
    {
        string Employee { get; }
        string PaySlip_id { get; }
        string Content { get; set; }
        string Date { get; set; }
        string Value { get; set; }
        string Status { get; set; }
        string message { get; set; }
    }
}
