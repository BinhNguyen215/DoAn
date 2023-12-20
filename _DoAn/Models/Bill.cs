using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class Bill
    {
        public int Bill_id;
        public int Employee_id;
        public string Cus_Name;
        public string PhoneNumber;
        public float BillValue;

        public int Product_id;
        public string Product_Name;
        public float Price;
        public int Quantities;
        public string Unit_Name;

        public DataTable GetProductData()//*
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Product_id as ID, ProductName as Name, Price as 'Price-UnitBig',  uni.Unit_Namelv2 as 'Unit(Small)', uni.Unit_Namelv1 as 'Unit(Big)', uni.Value as 'Coef' from Product, Unit uni ";
            return connect.GetData(sqlQuery);
        }

        public DataTable GetBillData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Bill_id, Cus_Name as Customer, PhoneNumber as Phone, BillValue as Value, DateBill as Date from Bill ";

            return connect.GetData(sqlQuery);
        }

        public DataTable GetDetailBill(string bill_id)//*
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Bill_id as BillID, pro.ProductName as 'Product Name', Quantities, Unit_Name as Unit, Price from DetailBill dtl, Product pro  where Bill_id =" + bill_id +" and pro.Product_id = dtl.Product_id";

            return connect.GetData(sqlQuery);
        }
        public DataTable SearchData(string search)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select pro.Product_id as ID, pro.ProductName as Name, pro.Price as 'Price-UnitBig',  uni.Unit_Namelv2 as 'Unit(Small)', uni.Unit_Namelv1 as 'Unit(Big)', uni.Value as 'Coef' from Product pro, Unit uni"
                +" where (pro.Product_id like '" + search + "%' or pro.ProductName like N'" + search + "%')"
                +" and uni.Unit_id = pro.Unit_id";
            return connect.GetData(sqlQuery);
        }
        public DataTable SearchBill(string search)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Bill_id, Cus_Name as Customer, PhoneNumber as Phone, BillValue as Value, DateBill as Date from Bill  where (Bill_id like '" + search + "%' or Cus_Name like N'" + search + "%' or PhoneNumber like '" + search + "%' )";
            return connect.GetData(sqlQuery);
        }

        public string AddData(string employee, string name, string phone, string bill_value)
        {

            DateTime dateTime = DateTime.UtcNow.Date;
                
            SqlCommand cmd = new SqlCommand("INSERT INTO Bill (Employee_id, Cus_Name, PhoneNumber, BillValue, DateBill) VALUES (@employ, @name, @phone, @bill_value, @date)"
                + "Select Scope_Identity()");

            cmd.Parameters.Add("@employ", SqlDbType.Int);
            cmd.Parameters["@employ"].Value = Convert.ToInt32(employee);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.Add("@date", SqlDbType.Date);
            cmd.Parameters["@date"].Value = dateTime;
            cmd.Parameters.Add("@bill_value", SqlDbType.Float);
            cmd.Parameters["@bill_value"].Value = Convert.ToDouble(bill_value);

            ConnectDB connect = new ConnectDB();
            return connect.GetId(cmd).ToString();
        }

        

        public bool UpdateProduct(string quantity, string id, string uni) //*
        {
            string query;
            if (uni == "Pill")
                query = "Update Product set lv2Quantity = lv2Quantity - @quan Where Product_id = @id";
            else
                query = "Update Product set lv1Quantity = lv1Quantity - @quan Where Product_id =@id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Add("@quan", SqlDbType.Int);
            cmd.Parameters["@quan"].Value = Convert.ToInt32(quantity);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = Convert.ToInt32(id);
            cmd.Parameters.AddWithValue("@uni", uni);

            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
                return false;
        }


        public bool AutoCreateReceipts(string Employee_id, string Content, string TotalPay, string Status, string Note)
        {
            DateTime dateTime = DateTime.UtcNow.Date;

            SqlCommand cmd = new SqlCommand("INSERT INTO Receipt (Employee_id, Content, CreateDate, TotalPay, Status, Note) VALUES (@Employee_id, @Content, @date, @TotalPay, @Status, @Note)");
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int);
            cmd.Parameters["@Employee_id"].Value = Convert.ToInt32(Employee_id);

            cmd.Parameters.AddWithValue("@Content", Content);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@Status", Status);

            cmd.Parameters.Add("@date", SqlDbType.Date);
            cmd.Parameters["@date"].Value = dateTime;

            cmd.Parameters.Add("@TotalPay", SqlDbType.Float);
            cmd.Parameters["@TotalPay"].Value = Convert.ToDouble(TotalPay);




            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
