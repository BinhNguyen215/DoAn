using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    internal class Receipts
    {
        public int Receipt_id;
        public int Employee_id;
        public string Content;
        public float TotalPay;

        public DataTable GetReceiptsData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Receipt_id, Employee_id, Content, TotalPay, Status, CreateDate from Receipt";
            return connect.GetData(sqlQuery);
        }

        public DataTable GetReceiptsToday(string day, string month, string year)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Receipt_id, Employee_id, Content, TotalPay, Status, CreateDate from Receipt Where Day(CreateDate) ='" + day + "' and Month(CreateDate) = '" + month + "' and Year(CreateDate) = '" + year + "'";
            return connect.GetData(sqlQuery);
        }

        public DataTable GetReceiptsByStatus(string status)
        {

            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Receipt_id, Employee_id, Content, TotalPay, Status, CreateDate from Receipt Where Status ='" + status + "'";
            return connect.GetData(sqlQuery);
        }

        public bool AddReceipts(string Employee_id, string Content, string TotalPay, string Status, string Note)
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

        public bool UpdateReceipts(string receipts_id, string Status)
        {
            DateTime dateTime = DateTime.UtcNow.Date;

            SqlCommand cmd = new SqlCommand("UPDATE Receipt set Status= @Status WHERE Receipt_id=@receipts_id");
            cmd.Parameters.Add("@receipts_id", SqlDbType.Int);
            cmd.Parameters["@receipts_id"].Value = Convert.ToInt32(receipts_id);
            cmd.Parameters.AddWithValue("@Status", Status);

            cmd.Parameters.Add("@date", SqlDbType.Date);
            cmd.Parameters["@date"].Value = dateTime;


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
