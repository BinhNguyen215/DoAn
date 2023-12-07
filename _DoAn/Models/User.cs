using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DoAn.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Employee_id { get; set; }
        public string EmployName { get; set; }
        public string Citizen_id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }

        public bool CheckValidate(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select * from Employee where Username = '" + username + "' and Password = '" + password + "'";
            if (connect.GetData(sqlQuery).Rows.Count == 1)
            {
                return true;
            }
            else
                return false;
        }
        public string UserID(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select Employee_id from Employee where Username = '" + username + "' and Password = '" + password + "'";
            return connect.GetData(sqlQuery).Rows[0]["Employee_id"].ToString();
        }
        public string UserName(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select EmployName from Employee where Username = '" + username + "' and Password = '" + password + "'";
            return connect.GetData(sqlQuery).Rows[0]["EmployName"].ToString();
        }
        public string GetPosition(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select Position from Employee where Username = '" + username + "' and Password = '" + password + "'";
            return connect.GetData(sqlQuery).Rows[0]["Position"].ToString();
        }
    }
}
