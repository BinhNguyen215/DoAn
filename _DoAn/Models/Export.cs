using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class Export
    {
        public int Export_id;
        public int Employee_id;
        public string ExportReason;
        public float TotalPrice;

        public int Product_id;
        public float ExportPrice;
        public int Quantity;
        public float Total;


        public DataTable GetProductData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Product_id as ID, ProductName as Name, Price, Description, Origin, Unit, TypeName as Type from Product , ProductType where Product.ProductType = ProductType.ProductType_id";
            return connect.GetData(sqlQuery);
        }
        public DataTable SearchData(string search)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Product_id as ID, ProductName as Name, Price, Description, Origin, Unit, TypeName as Type from Product , ProductType where Product.ProductType = ProductType.ProductType_id and (Product_id like '" + search + "%' or ProductName like N'" + search + "%')";
            return connect.GetData(sqlQuery);
        }

        public string AddData(string employee, string re, string totalprice)
        {
            DateTime dateTime = DateTime.UtcNow.Date;

            SqlCommand cmd = new SqlCommand("INSERT INTO ExportForm (Employee_id, ExportReason, ExportDate,TotalMoney) VALUES (@employ, @re, @date, @price)"
                + "Select Scope_Identity()");

            cmd.Parameters.Add("@employ", SqlDbType.Int);
            cmd.Parameters["@employ"].Value = Convert.ToInt32(employee);
            cmd.Parameters.AddWithValue("@re", re);
            cmd.Parameters.Add("@date", SqlDbType.Date);
            cmd.Parameters["@date"].Value = dateTime;
            cmd.Parameters.Add("@price", SqlDbType.Float);
            cmd.Parameters["@price"].Value = Convert.ToDouble(totalprice);

            ConnectDB connect = new ConnectDB();
            return connect.GetId(cmd).ToString();
            ////////////////

        }
        
        public bool UpdateProduct(string quantity, string id)
        {
            SqlCommand cmd = new SqlCommand("Update Product set Quantities = Quantities - @quan where Product_id = @id");
            cmd.Parameters.Add("@quan", SqlDbType.Int);
            cmd.Parameters["@quan"].Value = Convert.ToInt32(quantity);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = Convert.ToInt32(id);

            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
                return false;
        }
    }
}
