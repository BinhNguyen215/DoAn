using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class Supplier
    {
        public int SuplierId;
        public string SuplierName;
        public string SuplierEmail;
        public string SuplierPhone;
        public string SuplierAddress;
        public DataTable GetSuplierData()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Supplier_id, SuplierName, Address, PhoneNumber, Email from Supplier";
            return connect.GetData(sqlQuery);
        }
        public bool AddSuplier(string name, string add, string phone, string email)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Supplier (SuplierName, Address,PhoneNumber,Email) VALUES (@name, @add, @phone, @email)");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@add", add);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);

            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteSuplier(string id)
        {
            SqlCommand cmd = new SqlCommand("DELETE Supplier WHERE Supplier_id = @id");
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

        public bool UpdateSuplier(string id, string name, string add, string phone, string email)
        {

            SqlCommand cmd = new SqlCommand("UPDATE	Supplier SET SuplierName = @name, Address = @add, PhoneNumber= @phone, Email = @email WHERE Supplier_id = @id");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@add", add);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
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
