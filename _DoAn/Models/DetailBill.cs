using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class DetailBill
    {
        public int Bill_id;
        public int Product_id;
        public float PresentPrice;
        public int Quantity;

        public bool AddDetailData(string bill_id, string product_id, string price, string quantity, string unit)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DetailBill (Bill_id, Product_id, Quantities, Unit_Name, Price) VALUES (@bill_id, @product_id,  @quan,@uni, @price)");
            cmd.Parameters.Add("@product_id", SqlDbType.Int);
            cmd.Parameters["@product_id"].Value = Convert.ToInt32(product_id);
            cmd.Parameters.Add("@bill_id", SqlDbType.Int);
            cmd.Parameters["@bill_id"].Value = Convert.ToInt32(bill_id);
            cmd.Parameters.AddWithValue("@uni", unit);
            cmd.Parameters.Add("@price", SqlDbType.Int);
            cmd.Parameters["@price"].Value = Convert.ToInt32(price);
            cmd.Parameters.Add("@quan", SqlDbType.Int);
            cmd.Parameters["@quan"].Value = Convert.ToInt32(quantity);

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
