using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class Product
    {
        public int Product_id;
        public string ProductName;
        public float Price;
        public string Unit;
        public string Description;
        public string Original;
        public int ProductType;
        public List<string> GetProductType()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select TypeName from ProductType";
            List<string> data = new List<string>();
            foreach (DataRow row in connect.GetData(sqlQuery).Rows)
            {
                data.Add(row["TypeName"].ToString());
            }
            return data;
        }
        public DataTable GetProductData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Product_id, ProductName, Price, Description, Origin, Unit, TypeName from Product , ProductType where Product.ProductType = ProductType.ProductType_id";
            return connect.GetData(sqlQuery);
        }
        public string GetTypeString(string name)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select ProductType_id from ProductType where TypeName = '" + name + "'";
            return connect.GetData(sqlQuery).Rows[0]["ProductType_id"].ToString();
        }
        public bool AddProduct(string name, string price, string des, string ori, string unit, string type)
        {
            string typeid = GetTypeString(type);

            SqlCommand cmd = new SqlCommand("INSERT INTO Product (ProductName, Price,Description,Origin,Unit,ProductType) VALUES (@name, @price, @des, @ori, @uni, @ptid)");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@ori", ori);
            cmd.Parameters.AddWithValue("@uni", unit);
            //cmd.Parameters.AddWithValue("@ptid", 1);
            cmd.Parameters.Add("@ptid", SqlDbType.Int);
            cmd.Parameters["@ptid"].Value = Convert.ToInt32(typeid);

            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteProduct(string id)
        {
            if (id != "")
            {
                SqlCommand cmd = new SqlCommand("DELETE Product WHERE Product_id = @id");
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
            else { return false; }
        }

        public bool UpdateProduct(string id, string name, string price, string des, string ori, string unit, string type)
        {
            string typeid = GetTypeString(type);

            SqlCommand cmd = new SqlCommand("UPDATE	Product SET ProductName = @name, Price = @price, Description= @des, Origin = @ori, Unit = @uni, ProductType = @ptid WHERE Product_id = @id");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@ori", ori);
            cmd.Parameters.AddWithValue("@uni", unit);
            cmd.Parameters.Add("@ptid", SqlDbType.Int);
            cmd.Parameters["@ptid"].Value = Convert.ToInt32(typeid);
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
