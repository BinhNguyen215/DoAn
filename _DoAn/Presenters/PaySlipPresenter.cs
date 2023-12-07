using _DoAn.Models;
using _DoAn.Views.Accountant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    internal class PaySlipPresenter
    {
        IPaySlip paySlipview;
        PaySlip paySlip = new PaySlip();
        public PaySlipPresenter(IPaySlip view)
        {
            paySlipview = view;
        }

        public bool LoadPaySlip()
        {
            paySlipview.dgvPaySlip.DataSource = paySlip.GetPaySlipData();
            return true;
        }

        public bool GetPaySlipByDay(string day, string month, string year)
        {
            paySlipview.dgvPaySlip.DataSource = paySlip.GetPaySlipToday(day, month, year);
            return true;
        }

        public bool GetPaySlipByStatus(string status)
        {
            paySlipview.dgvPaySlip.DataSource = paySlip.GetPaySlipByStatus(status);
            return true;
        }
        public bool FilterByDay()
        {
            string date = paySlipview.Date;
            string[] arrayDate = date.Split('-');
            GetPaySlipByDay(arrayDate[0], arrayDate[1], arrayDate[2]);
            return true;
        }

        public bool FilterByStatus()
        {
            string status = paySlipview.Status;
            GetPaySlipByStatus(status);
            return true;
        }
    }
}