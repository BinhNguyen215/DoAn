﻿using _DoAn.Presenters;
using _DoAn.Views.Statistic;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _DoAn.Views.Statistic
{
    public partial class StatisticsView : Form, IStatistics
    {
        StatisticPresenter statisticPresenter;

        public StatisticsView()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            statisticPresenter = new StatisticPresenter(this);
        }
        public string Date
        {
            get { return bunifuDatePicker1.Text.ToString(); }
            set { bunifuDatePicker1.Text = value; }
        }
        public string RevenueMonth
        {
            get { return lbRevenueThisMonth.Text; }
            set { lbRevenueThisMonth.Text = value; }
        }
        public string RevenueToday
        {
            get { return lbRevenueToday.Text; }
            set { lbRevenueToday.Text = value; }
        }
        public string SumProduct
        {
            get { return lbSumProduct.Text; }
            set { lbSumProduct.Text = value; }
        }
        public string BillMonth
        {
            get { return lbBillThisMonth.Text; }
            set { lbBillThisMonth.Text = value; }
        }
        public string BillToday
        {
            get { return lbBillToday.Text; }
            set { lbBillToday.Text = value; }
        }
        BunifuDataGridView IStatistics.gvBestSeller
        {
            get { return dtgvBestSeller; }
            set { dtgvBestSeller = value; }
        }

        BunifuDataGridView IStatistics.gvEmployee
        {
            get { return dtgvEmployee; }
            set { dtgvEmployee = value; }
        }
        private DataTable _data;
        public DataTable data { set { _data = value; } }

        public string ProductToday
        {
            get { return lbProduct.Text; }
            set { lbProduct.Text = value; }
        }
        private string _name;
        string IStatistics.EmployeeName { get; set; }
      

        public StatisticsView(string name) : this()
        {
            this._name = name;
        }
        
        private void ChartMoneydaybydate()
        {
            //chart1.Series["Revenue"].ChartType = SeriesChartType.Line;
            chart1.Series["Revenue"].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd";
            chart1.DataSource = _data;
            chart1.Series["Revenue"].XValueMember = "Ngay";
            chart1.Series["Revenue"].YValueMembers = "Tong";
            chart1.Series["Revenue"].IsValueShownAsLabel = true;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            statisticPresenter.RetriveData();
            ChartMoneydaybydate();
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.Document = printDocument;
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Createform);
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }
        }
        public void Createform(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            statisticPresenter.Print(e);
        }

        private void StatisticsView_Load(object sender, EventArgs e)
        {
            string sDay = DateTime.Now.ToString("dd");
            string sMonth = DateTime.Now.ToString("MM");
            string sYear = DateTime.Now.ToString("yyyy");
            statisticPresenter.GetBillMonth(sMonth, sYear);
            statisticPresenter.GetBillToday(sDay, sMonth, sYear);
            statisticPresenter.GetRevenueMonth(sMonth, sYear);
            statisticPresenter.GetRevenueToday(sDay, sMonth, sYear);
            statisticPresenter.GetTopProduct(sMonth,sYear);
            statisticPresenter.GetSaleStatus();
            statisticPresenter.GetLineChart(sMonth, sYear);
            statisticPresenter.GetProductMonth(sMonth, sYear);
            statisticPresenter.GetProductToday(sDay, sMonth, sYear);
            ChartMoneydaybydate();
        }

        private void dtgvEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (dtgvEmployee.CurrentRow.Cells[0].Value.ToString() != "" && !lbstt.Text.Equals("Sale Results"))
            {
                StatisticDetail statisticDetail = new StatisticDetail(dtgvEmployee.CurrentRow.Cells[1].Value.ToString());
                statisticDetail.ShowDialog();
            }
        }

        private void lbViewAllBill_Click(object sender, EventArgs e)
        {
            string sMonth = DateTime.Now.ToString("MM");
            string sYear = DateTime.Now.ToString("yyyy");
            if (lbViewAllBill.Text == "View all statuses")
            {
                statisticPresenter.GetSaleStatus();
                lbViewAllBill.Text = "View sale results";
                lbstt.Text = "Sale statuses";
            }
            else
            {
                statisticPresenter.GetTopResult(sMonth,sYear);
                lbViewAllBill.Text = "View all statuses";
                lbstt.Text = "Sale Results";
            }
        }
    }
}
