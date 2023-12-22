using _DoAn.Models;
using _DoAn.Views.Statistic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Presenters
{
    public class DetailStatisticPresenter
    {
        IDetailBill iDetail;
        Statistics statistic = new Statistics();
        public DetailStatisticPresenter(IDetailBill i)
        {
            this.iDetail = i;
        }
        public bool GetName (string bill)
        {
            iDetail.BillId= bill;
            iDetail.Name = statistic.GetName(bill);
            return true;
        }
        public bool GetDate(string bill)
        {

            iDetail.Date= statistic.GetDate(bill);
            return true;
        }
        public  bool GetDTGVDetail(string bill)
        {
            DataTable dt= new DataTable();
            dt = statistic.GetDetailBill(bill);
            iDetail.dtgvDetail.DataSource = dt;
            return true;
        }

    }
}
