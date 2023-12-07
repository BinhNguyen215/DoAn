using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class DetailImport
    {
        public int Product_id;
        public float ImportPrice;
        public int Quantity;
        public float Total;
        public bool AddDetailData(string proid, string id, string importprice, string quantity, string total)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DetailImportForm (Product_id, ImportForm_id,ImportPrice,Quantity, Total) VALUES (@pid, @importid, @imprice, @quan, @total)");
            cmd.Parameters.Add("@pid", SqlDbType.Int);
            cmd.Parameters["@pid"].Value = Convert.ToInt32(proid);
            cmd.Parameters.Add("@importid", SqlDbType.Int);
            cmd.Parameters["@importid"].Value = Convert.ToInt32(id);
            cmd.Parameters.Add("@imprice", SqlDbType.Float);
            cmd.Parameters["@imprice"].Value = Convert.ToDouble(importprice);
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