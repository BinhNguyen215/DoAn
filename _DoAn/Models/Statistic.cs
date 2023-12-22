using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class Statistics
    {
     
        public DataTable GetTop10ProductData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT TOP 10 with TIES ProductName as Name , Sum(Quantities) as Sales from Product, DetailBill "
                + "Where DetailBill.Product_id = Product.Product_id "
                + "Group BY ProductName "
                + "Order By Sum(Quantities) DESC";
            return connect.GetData(sqlQuery);
        }
        public DataTable GetEmployee()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select distinct bi.DateBill 'Date',bi.Bill_id as 'Bill ID', emp.EmployName as 'Employee Name', bi.BillValue"
                + " FROM  Bill bi, Employee emp, DetailBill dtl"
                + " WHERE bi.Employee_id = emp.Employee_id ";
            return connect.GetData(sqlQuery);
        }
        public DataTable GetDetailBill(string bill) { 
            ConnectDB connect=new ConnectDB();
            string sqlQuery = "SELECT distinct bi.Bill_id,dtl.Price, pro.ProductName, dtl.Unit_Name, dtl.Quantities, spl.SuplierName "
                +"FROM Bill bi, DetailBill dtl, Product pro, Supplier spl, ImportForm im "
                +"WHERE bi.Bill_id = dtl.Bill_id and dtl.Product_id = pro.Product_id and spl.Supplier_id = im.Suplier_id "
                +"And bi.Bill_id = '"+bill+"'";
            return connect.GetData(sqlQuery);
        }
       /* public DataTable GetDetailBill()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = " " +
                " ";
            return connect.GetData(sqlQuery);
        }*/
        public string GetImportMonth(string month, string year)
        {
            //string sMonth = DateTime.Now.ToString("MM");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT SUM(TotalPrice) as SL from ImportForm Where Month(FormDate) ='" + month + "' and Year(FormDate) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["SL"].ToString();
        }
        public string GetNumberOfProductMonth(string month, string year)
        {
            //string sMonth = DateTime.Now.ToString("MM");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT SUM(DetailBill.Quantities) as SL from Bill, DetailBill Where Bill.Bill_id = DetailBill.Bill_id and Month(DateBill) ='" + month + "' and Year(DateBill) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["SL"].ToString();
        }
        public string GetNumberOfProductToday(string day, string month, string year)
        {
            //string sDay = DateTime.Now.ToString("dd");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT SUM(DetailBill.Quantities) as SL from Bill, DetailBill Where Bill.Bill_id = DetailBill.Bill_id and Day(DateBill) ='" + day + "' and Month(DateBill) = '" + month + "' and Year(DateBill) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["SL"].ToString();
        }
        public string GetNumberOfBillMonth(string month, string year)
        {
            //string sMonth = DateTime.Now.ToString("MM");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT COUNT(Bill_id) as SL from Bill Where Month(DateBill) ='" + month + "' and Year(DateBill) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["SL"].ToString();
        }
        public string GetNumberOfBillToday(string day, string month, string year)
        {
            //string sDay = DateTime.Now.ToString("dd");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT COUNT(Bill_id) as SL from Bill Where Day(DateBill) ='" + day + "' and Month(DateBill) = '" + month + "' and Year(DateBill) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["SL"].ToString();
        }
        public string GetNumberOfRevuewnueMonth(string month, string year)
        {
            //string sMonth = DateTime.Now.ToString("MM");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT Sum(BillValue) as Tong from Bill Where Month(DateBill) ='" + month + "' and Year(DateBill) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["Tong"].ToString();
        }
        public string GetNumberOfRevuenueToday(string day, string month, string year)
        {
            //string sDay = DateTime.Now.ToString("dd");
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "SELECT Sum(BillValue) as Tong from Bill Where Day(DateBill) ='" + day + "' and Month(DateBill) = '" + month + "' and Year(DateBill) = '" + year + "'";
            return connect.GetData(sqlQuery).Rows[0]["Tong"].ToString();
        }

        public DataTable GetChartData(string month, string year)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select CAST (DateBill AS DATE) AS Ngay, sum(BillValue) as Tong from Bill where MONTH(DateBill) = '" + month + "' and Year(DateBill) = '" + year + "' group by CAST (DateBill AS DATE) order by CAST (DateBill AS DATE)";
            return connect.GetData(sqlQuery);
        }
        //*
        public string GetName(string bill)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuerry = "Select emp.EmployName From Employee emp, Bill bi Where bi.Employee_id = emp.Employee_id and bi.Bill_id = '" + bill + "'";
            return connect.GetData(sqlQuerry).Rows[0][0].ToString();
        }
        public string GetDate (string bill)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuerry = "SELECT DateBill FROM Bill WHERE Bill_id='"+bill+"'";
            return connect.GetData(sqlQuerry).Rows[0][0].ToString();
        }
        public DataTable GetTopData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select top 5 with ties em.EmployName 'Employee Name', Sum(BillValue) 'Doanh thu' "
                + " FROM Bill bi, Employee em"
                + " WHERE bi.Employee_id = em.Employee_id"
                   + " Group by em.EmployName"
                   + " Order by  Sum(BillValue) Desc";
                return connect.GetData(sqlQuery);
        }
    }
}
