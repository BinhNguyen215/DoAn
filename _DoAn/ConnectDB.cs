using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn
{
    public class ConnectDB
    {
        SqlConnection connect;
        public ConnectDB()
        {
            this.connect = new SqlConnection(@"Data Source=LAPTOP-7UOGDK8A;Initial Catalog=ComesticDB;Integrated Security=True");
        }
        public DataTable GetData(string sqlquery)
        {
            SqlDataAdapter sqldata = new SqlDataAdapter(sqlquery, this.connect);
            DataTable dataTable = new DataTable();  
            sqldata.Fill(dataTable);
            return dataTable;
        }
        public bool HandleData(SqlCommand cmd)
        {
            cmd.Connection = this.connect;
            connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    connect.Close();
                    return true;
                }
                connect.Close();
            return false;
        }
        public int GetId(SqlCommand cmd)
        {
            cmd.Connection = this.connect;
            connect.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            return i;
        }
    }
}
