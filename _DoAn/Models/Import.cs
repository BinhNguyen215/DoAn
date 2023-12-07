using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class Import
    {
        public int Import_id;
        public int Employee_id;
        public int Suplier_id;
        public float TotalPrice;

        public int Product_id;
        public float ImportPrice;
        public int Quantity;
        public float Total;
        public List<string> GetSuplier()
        {
            ConnectDB concect = new ConnectDB();
            string sqlQuery = "Select SuplierName from Supplier";
            List<string> data = new List<string>();
            foreach (DataRow row in concect.GetData(sqlQuery).Rows)
            {
                data.Add(row["SuplierName"].ToString());
            }
            return data;
        }
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
        public string GetTypeString(string name)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Supplier_id from Supplier where SuplierName = '" + name + "'";
            return connect.GetData(sqlQuery).Rows[0]["Supplier_id"].ToString();
        }
        public string AddData(string employee, string suplier, string totalprice)
        {
            string Suplier_id = GetTypeString(suplier);
            DateTime dateTime = DateTime.UtcNow.Date;

            SqlCommand cmd = new SqlCommand("INSERT INTO ImportForm (Employee_id, Suplier_id,FormDate,TotalPrice) VALUES (@employ, @sup, @date, @price)"
                + "Select Scope_Identity()");

            cmd.Parameters.Add("@employ", SqlDbType.Int);
            cmd.Parameters["@employ"].Value = Convert.ToInt32(employee);
            cmd.Parameters.Add("@sup", SqlDbType.Int);
            cmd.Parameters["@sup"].Value = Convert.ToInt32(Suplier_id);
            cmd.Parameters.Add("@date", SqlDbType.Date);
            cmd.Parameters["@date"].Value = dateTime;
            cmd.Parameters.Add("@price", SqlDbType.Float);
            cmd.Parameters["@price"].Value = Convert.ToDouble(totalprice);

            ConnectDB connect = new ConnectDB();
            return connect.GetId(cmd).ToString();
        }
        public bool UpdateProduct(string quantity, string id)
        {
            SqlCommand cmd = new SqlCommand("Update Product set Quantities = Quantities + @quan where Product_id = @id");
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
        public bool AutoCreatePaySlip(string Employee_id, string Content, string TotalPay, string Status, string Note)
        {
            DateTime dateTime = DateTime.UtcNow.Date;

            SqlCommand cmd = new SqlCommand("INSERT INTO PaySlip (Employee_id, Content, CreateDate, TotalPay, Status, Note) VALUES (@Employee_id, @Content, @date, @TotalPay, @Status, @Note)");
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
