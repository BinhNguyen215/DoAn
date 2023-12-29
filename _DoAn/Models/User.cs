using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

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
        public int CheckValidate(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            password = GetHash(password);
            string sqlQuery = "Select * from Employee where Username = '" + username + "' and DefaultPassword = '" + password + "'";
            if (connect.GetData(sqlQuery).Rows.Count == 1)
            {
                return 1; // default
            }
            else
            {
                string sqlQuery1 = "Select * from Employee where Username = '" + username + "' and Password = '" + password + "'";
                if (connect.GetData(sqlQuery1).Rows.Count == 1)
                {
                    return 2; // primary password
                }
                else return 0; // sai mật khẩu
            }    
                

        }
        public string UserID(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            password = GetHash(password);
            string sqlQuery = "Select Employee_id from Employee where Username = '" + username + "' and Password = '" + password + "'";
            return connect.GetData(sqlQuery).Rows[0]["Employee_id"].ToString();
        }
        public string UserName(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            password = GetHash(password);
            string sqlQuery = "Select EmployName from Employee where Username = '" + username + "' and Password = '" + password + "'";
            return connect.GetData(sqlQuery).Rows[0]["EmployName"].ToString();
        }
        public string GetPosition(string username, string password)
        {
            ConnectDB connect = new ConnectDB();
            password = GetHash(password);
            string sqlQuery = "Select Position from Employee where Username = '" + username + "' and Password = '" + password + "'";
            return connect.GetData(sqlQuery).Rows[0]["Position"].ToString();
        }
        // Forgot password
        public string GetEmail(string username)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select Email from Employee where Username = '" + username + "' ";
            return (connect.GetData(sqlQuery)!= null && connect.GetData(sqlQuery).Rows.Count >0 ) ?  connect.GetData(sqlQuery).Rows[0]["Email"].ToString() : string.Format("No email found for this username");
        }
        
        public DataTable LoadListEmployee()
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "Select Employee_id as ID, EmployName as Name, Citizen_id, Address, PhoneNumber as Phone, Email, Position, Username from Employee";
            return connect.GetData(sqlQuery);

        }

        /// <summary>
        /// Function random password
        /// </summary>

        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";


        public string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = "";
            System.Random _random = new Random();
            int counter;


            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CASE;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);
        }

        public bool AddEmployee(string name, string citizen_id, string email, string phone, string position, string address)
        {
            string _pass = GeneratePassword(true, true, true, false, 6);
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee (EmployName, Citizen_id, Address, PhoneNumber, Email, Position, Username,DefaultPassWord) VALUES (@name, @citizen_id, @address, @phone, @email, @position, @username,@default)");

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@citizen_id", citizen_id);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@position", position);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@username", email);
            cmd.Parameters.AddWithValue("@default", _pass);
            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteEmployee(string id)
        {
            SqlCommand cmd = new SqlCommand("DELETE Employee WHERE Employee_id = @id");
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

        public bool UpdateEmployee(string id, string name, string citizen_id, string email, string phone, string position,
            string address, string username)
        {
            SqlCommand cmd = new SqlCommand("UPDATE	Employee SET EmployName = @name, Citizen_id = @citizen_id, Address = @address, PhoneNumber = @phone, Email = @email, Position = @position, Password = @password, Username = @username WHERE Employee_id = @id");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@citizen_id", citizen_id);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@position", position);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@username", username);
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

        public DataTable SearchData(string search)
        {
            ConnectDB connect = new ConnectDB();
            string sqlQuery = "select Employee_id as ID, EmployName, Citizen_id, Address, PhoneNumber, Email, Position, Username, Password from Employee where (Employee_id like '" + search + "%' or EmployName like N'% " + search + "%')";
            return connect.GetData(sqlQuery);
        }

        public bool UpdatePassword(string username,string newPassword,int index)
        {
            newPassword = GetHash(newPassword);

            SqlCommand cmd;
            if (index == 0)
            {
                 cmd = new SqlCommand("UPDATE Employee SET Password = @newpassword, DefaultPassword = NULL  WHERE Username = @username ");
                cmd.Parameters.AddWithValue("@newpassword", newPassword);
                cmd.Parameters.AddWithValue("@username", username);
            }    
            else
            {
                 cmd = new SqlCommand("UPDATE Employee SET Password = @newpassword WHERE Username = @username ");
                cmd.Parameters.AddWithValue("@newpassword", newPassword);
                cmd.Parameters.AddWithValue("@username", username);
            }
            ConnectDB connect = new ConnectDB();
            if (connect.HandleData(cmd))
            {
                return true;
            }
            else
                return false;
        }
        public string GetHash(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            // Compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            // Get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
