using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace _DoAn.Models
{
    public class Product
    {
        public int Product_id;
        public string ProductName;
        public float Price;
        public int Unit_id;
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
            string sqlQuery = "select p.Product_id as ID, p.ProductName as Name, p.Price, p.Description, p.Origin, uni.Unit_Namelv2 as 'Unit(Small)', uni.Unit_Namelv1 as 'Unit(Big)', pty.TypeName as Type from Product p, ProductType pty,Unit uni where p.ProductType = pty.ProductType_id and uni.Unit_id=p.Unit_id;";
            return connect.GetData(sqlQuery);
        }
        public string GetTypeString(string name)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select ProductType_id from ProductType where TypeName = '" + name + "'";
            return connect.GetData(sqlQuery).Rows[0]["ProductType_id"].ToString();
        }
        public int GetUnitId(string unit1,string unit2) //*
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Unit_id from Unit where Unit_Namelv1 = '" + unit2 + "' and Unit_Namelv2 = '" + unit1 + "'";
            return Convert.ToInt32(connect.GetData(sqlQuery).Rows[0]["Unit_id"]);
        }
        static string[] CutString(string str) //*
        {
            return str.Split('/');
        }
       
        public bool AddProduct(string name, string price, string des, string ori, string unit, string type)
        {
            string typeid = GetTypeString(type);
            string[] units = CutString(unit); //*
            int uni= GetUnitId(units[0], units[1]);//*
 
            //*
            SqlCommand cmd = new SqlCommand("INSERT INTO Product (ProductName, Price,Description,Origin,ProductType,Unit_id) VALUES (@name, @price, @des, @ori, @ptid, @uni)");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@ori", ori);
            cmd.Parameters.AddWithValue("@uni", uni);
            //cmd.Parameters.Add("@uni", SqlDbType.Int);
            //cmd.Parameters["@uni"].Value = Convert.ToInt32(unit_id);
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
            string[] units = CutString(unit); //*
            int uni = GetUnitId(units[0], units[1]);//*

            SqlCommand cmd = new SqlCommand("UPDATE	Product SET ProductName = @name, Price = @price, Description= @des, Origin = @ori, Unit_id = @uni, ProductType = @ptid WHERE Product_id = @id");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@ori", ori);
            cmd.Parameters.AddWithValue("@uni", uni);
            //cmd.Parameters.Add("@uni", SqlDbType.Int);
            //cmd.Parameters["@uni"].Value = Convert.ToInt32(unit_id);
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
