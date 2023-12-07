using _DoAn.Models;
using _DoAn.Views.Accountant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    internal class AddReceiptsPresenter
    {
        IAddReceiptsForm addReceiptsview;
        Receipts receipts = new Receipts();

        public AddReceiptsPresenter(IAddReceiptsForm view)
        {
            addReceiptsview = view;
        }

        public bool AddDataToDB()
        {
            if (CheckInformation())
            {
                receipts.AddReceipts(addReceiptsview.Employee, addReceiptsview.Content, addReceiptsview.Value, addReceiptsview.Status, "");

                addReceiptsview.message = "Created receipts successfully";

                return true;
            }
            else
            {
                addReceiptsview.message = "Please fullfill information";
                return false;
            }
        }

        public bool UpdateData()
        {
            if (CheckInformation())
            {
                receipts.UpdateReceipts(addReceiptsview.Receipts_id, addReceiptsview.Status);
                addReceiptsview.message = "Updated receipts successfully";

                return true;
            }
            else
            {
                addReceiptsview.message = "Please fullfill information";
                return false;
            }
        }
        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(addReceiptsview.Content))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(addReceiptsview.Value))
                return false;
            else if (string.IsNullOrEmpty(addReceiptsview.Status))
                return false;
            else
                return true;
        }

        public bool RetriveData(string content, string value, string date, string status)
        {
            ClearInformation();
            addReceiptsview.Content = content;
            addReceiptsview.Value = value;
            addReceiptsview.Date = date;
            addReceiptsview.Status = status;

            return true;
        }

        public bool ClearInformation()
        {
            addReceiptsview.Content = "";
            addReceiptsview.Value = "";
            addReceiptsview.Date = "";
            addReceiptsview.Status = "";
            return true;
        }
    }
}
