using _DoAn.Models;
using System;
using _DoAn.Views.Accountant;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public class AddPaySlipPresenter
    {
        IAddPaySlip addPaySlipview;
        PaySlip paySlip = new PaySlip();

        public AddPaySlipPresenter(IAddPaySlip view)
        {
            addPaySlipview = view;
        }

        public bool AddDataToDB()
        {
            if (CheckInformation())
            {
                paySlip.AddPaySlip(addPaySlipview.Employee, addPaySlipview.Content, addPaySlipview.Value, addPaySlipview.Status, "");
                addPaySlipview.message = "Created pay slip successfully";

                return true;
            }
            else
            {
                addPaySlipview.message = "Please fullfill information";
                return false;
            }
        }

        public bool UpdateData()
        {
            if (CheckInformation())
            {
                paySlip.UpdatePaySlip(addPaySlipview.PaySlip_id, addPaySlipview.Status);
                addPaySlipview.message = "Updated pay slip successfully";

                return true;
            }
            else
            {
                addPaySlipview.message = "Please fullfill information";
                return false;
            }
        }



        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(addPaySlipview.Content))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(addPaySlipview.Value))
                return false;
            else if (string.IsNullOrEmpty(addPaySlipview.Status))
                return false;
            else
                return true;
        }

        public bool RetriveData(string content, string value, string date, string status)
        {
            ClearInformation();
            //addPaySlipview.Receipts_id = receipts_id;
            addPaySlipview.Content = content;
            addPaySlipview.Value = value;
            addPaySlipview.Date = date;
            addPaySlipview.Status = status;

            return true;
        }

        public bool ClearInformation()
        {
            addPaySlipview.Content = "";
            addPaySlipview.Value = "";
            addPaySlipview.Date = "";
            addPaySlipview.Status = "";

            return true;
        }
    }
}
