using _DoAn.Views.Statistic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using _DoAn.Models;

namespace _DoAn.Presenters
{
    public class StatisticPresenter
    {
        IStatistics statisticview;
        Statistics statistics = new Statistics();

        public StatisticPresenter(IStatistics i)
        {
            this.statisticview = i;
        }
        public bool GetProductMonth(string month, string year)
        {
            statisticview.SumProduct = statistics.GetNumberOfProductMonth(month, year);
            if (statisticview.SumProduct == "")
                statisticview.SumProduct = "0";
            return true;
        }
        public bool GetProductToday(string day, string month, string year)
        {
            statisticview.ProductToday = statistics.GetNumberOfProductToday(day, month, year);
            if (statisticview.ProductToday == "")
                statisticview.ProductToday = "0";
            return true;
        }
        public bool GetBillMonth(string month, string year)
        {
            statisticview.BillMonth = statistics.GetNumberOfBillMonth(month, year);
            if (statisticview.BillMonth == "")
                statisticview.BillMonth = "0";
            return true;
        }
        public bool GetBillToday(string day, string month, string year)
        {
            statisticview.BillToday = statistics.GetNumberOfBillToday(day, month, year);
            if (statisticview.BillToday == "")
                statisticview.BillToday = "0";
            return true;
        }
        public bool GetRevenueMonth(string month, string year)
        {
            if (!String.IsNullOrEmpty(statistics.GetNumberOfRevuewnueMonth(month, year)))
            {
                float revenue = 0f;
                float r = float.Parse(statistics.GetNumberOfRevuewnueMonth(month, year));
                revenue = r;
                statisticview.RevenueMonth = revenue.ToString("###,###");
                return true;
            }
            else
            {
                statisticview.RevenueMonth = "0";
                return true;
            }
            //float revenue = 0f;
            //float r = float.Parse(statistics.GetNumberOfRevuewnueMonth());
            //revenue = r;
            //statisticview.RevenueMonth = revenue.ToString("###,###");
            //return true;
        }
        public bool GetRevenueToday(string day, string month, string year)
        {
            if (!String.IsNullOrEmpty(statistics.GetNumberOfRevuenueToday(day, month, year)))
            {
                float revenue = 0f;
                float r = float.Parse(statistics.GetNumberOfRevuenueToday(day, month, year));
                revenue = r;
                statisticview.RevenueToday = revenue.ToString("###,###");
                return true;
            }
            else
            {
                statisticview.RevenueToday = "0";
                return true;
            }
        }
        public bool GetTopProduct()
        {
            DataTable dt = new DataTable();
            dt = statistics.GetTop10ProductData();
            statisticview.gvBestSeller.DataSource = dt;
            return true;
        }
        public bool GetLineChart(string month, string year)
        {
            statisticview.data = statistics.GetChartData(month, year);
            return true;
        }
        public bool RetriveData()
        {
            string date = statisticview.Date;
            string[] arrayDate = date.Split('-');
            GetBillMonth(arrayDate[1], arrayDate[2]);
            GetBillToday(arrayDate[0], arrayDate[1], arrayDate[2]);
            GetRevenueMonth(arrayDate[1], arrayDate[2]);
            GetRevenueToday(arrayDate[0], arrayDate[1], arrayDate[2]);
            GetLineChart(arrayDate[1], arrayDate[2]);
            GetProductMonth(arrayDate[1], arrayDate[2]);
            GetProductToday(arrayDate[0], arrayDate[1], arrayDate[2]);
            return true;
        }
        public bool Print(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            string date = statisticview.Date;
            string[] arrayDate = date.Split('-');
            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up
            string sMonth = arrayDate[1];
            string sYear = arrayDate[2];
            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Green Beauty", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            graphic.DrawString("Report for " + sMonth + " - " + sYear, new Font("Courier New", 18), new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString("Addresss: 136, Linh Trung, Thủ Đức, TP Thủ Đức", font, new SolidBrush(Color.Black), startX, 70);

            graphic.DrawString("Phone: 1900 1555".PadRight(30) + "Employee: " + statisticview.EmployeeName, font, new SolidBrush(Color.Black), startX, 90);
            offset = offset + 60;
            string top = "Product Sold".PadRight(20) + "Bills".PadRight(20) + "Revenues".PadRight(20);
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent
            string bot = statisticview.SumProduct.PadRight(20) + statisticview.BillMonth.PadRight(20) + statisticview.RevenueMonth.PadRight(20);
            graphic.DrawString(bot, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            string total;
            if (!String.IsNullOrEmpty(statistics.GetImportMonth(sMonth, sYear)))
            {
                float import = 0f;
                float r = float.Parse(statistics.GetImportMonth(sMonth, sYear));
                import = r;
                total = import.ToString("###,###");
            }
            else
            {
                total = "0";
            }
            graphic.DrawString("------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("Import: ".PadRight(40) + total, font, new SolidBrush(Color.Black), startX, startY + offset);
            return true;
        }
    }
}
