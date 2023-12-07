using _DoAn.Models;
using _DoAn.Views.Accountant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    internal class ReceiptsPresenter
    {
        IReceiptsForm receiptsFromview;
        Receipts receipts = new Receipts();

        public ReceiptsPresenter(IReceiptsForm view)
        {
            receiptsFromview = view;
        }

        public bool LoadReceipts()
        {
            receiptsFromview.dgvReceipts.DataSource = receipts.GetReceiptsData();
            return true;
        }

        public bool GetReceiptsByDay(string day, string month, string year)
        {
            receiptsFromview.dgvReceipts.DataSource = receipts.GetReceiptsToday(day, month, year);
            return true;
        }

        public bool GetReceiptsByStatus(string status)
        {
            receiptsFromview.dgvReceipts.DataSource = receipts.GetReceiptsByStatus(status);
            return true;
        }
        public bool FilterByDay()
        {
            string date = receiptsFromview.Date;
            string[] arrayDate = date.Split('-');
            GetReceiptsByDay(arrayDate[0], arrayDate[1], arrayDate[2]);
            return true;
        }

        public bool FilterByStatus()
        {
            string status = receiptsFromview.Status;
            GetReceiptsByStatus(status);
            return true;
        }




    }
}
