using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    internal class PaySlip
    {
        public int Receipt_id;
        public int Employee_id;
        public string Content;
        public float TotalPay;

        public DataTable GetPaySlipData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select PaySlip_id, Employee_id, Content, TotalPay, Status, CreateDate from PaySlip";
            return connect.GetData(sqlQuery);
        }

        public DataTable GetPaySlipToday(string day, string month, string year)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select PaySlip_id, Employee_id, Content, TotalPay, Status, CreateDate from PaySlip Where Day(CreateDate) ='" + day + "' and Month(CreateDate) = '" + month + "' and Year(CreateDate) = '" + year + "'";
            return connect.GetData(sqlQuery);
        }

        public DataTable GetPaySlipByStatus(string status)
        {

            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select PaySlip_id, Employee_id, Content, TotalPay, Status, CreateDate from PaySlip Where Status ='" + status + "'";
            return connect.GetData(sqlQuery);
        }

        public bool AddPaySlip(string Employee_id, string Content, string TotalPay, string Status, string Note)
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

        public bool UpdatePaySlip(string paySlip_id, string Status)
        {
            DateTime dateTime = DateTime.UtcNow.Date;

            SqlCommand cmd = new SqlCommand("UPDATE PaySlip set Status= @Status WHERE PaySlip_id=@paySlip_id");
            cmd.Parameters.Add("@paySlip_id", SqlDbType.Int);
            cmd.Parameters["@paySlip_id"].Value = Convert.ToInt32(paySlip_id);
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
