using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class DetailExport
    {
        public int Product_id;
        public float ExportPrice;
        public int Quantity;
        public float Total;
        public bool AddDetailData(string proid, string id, string price, string quantity, string total)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DetailExportForm (Product_id, ExportForm_id,Price,Quantity, Total) VALUES (@pid, @exportid, @price, @quan, @total)");
            cmd.Parameters.Add("@pid", SqlDbType.Int);
            cmd.Parameters["@pid"].Value = Convert.ToInt32(proid);
            cmd.Parameters.Add("@exportid", SqlDbType.Int);
            cmd.Parameters["@exportid"].Value = Convert.ToInt32(id);
            cmd.Parameters.Add("@price", SqlDbType.Float);
            cmd.Parameters["@price"].Value = Convert.ToDouble(price);
            cmd.Parameters.Add("@quan", SqlDbType.Int);
            cmd.Parameters["@quan"].Value = Convert.ToInt32(quantity);
            cmd.Parameters.Add("@total", SqlDbType.Float);
            cmd.Parameters["@total"].Value = Convert.ToDouble(total);

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
