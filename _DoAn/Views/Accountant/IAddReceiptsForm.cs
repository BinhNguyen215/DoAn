using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Views.Accountant
{
    public interface IAddReceiptsForm
    {
        string Employee { get; }
        string Receipts_id { get; }
        string Content { get; set; }
        string Date { get; set; }
        string Value { get; set; }
        string Status { get; set; }
        string message { get; set; }
    }
}
