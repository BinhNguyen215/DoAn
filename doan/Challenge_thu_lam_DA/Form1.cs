using Challenge_thu_lam_DA.Model;
using Challenge_thu_lam_DA.Modify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Challenge_thu_lam_DA;

namespace Challenge_thu_lam_DA
{
    public partial class Form_Login : Form
    {
        static string cnt = "Data Source=LAPTOP-7UOGDK8A;Initial Catalog=DateUser;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(cnt);

        static SqlDataReader reader;

        public static void testConnection()
        {

            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't connect with DB sao ki, " + ex.Message);

            }
        }
        public static User hasUser(string email, string password)
        {
            testConnection();

            using (connection)
            {
                string query = $"SELECT * FROM  [DateUser].[dbo].[user_pw] WHERE username = @username and password=@pw";
                SqlCommand sqlcmd = new SqlCommand(query, connection);
                sqlcmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = email.ToString();
                sqlcmd.Parameters.Add("@pw", SqlDbType.VarChar, 100).Value = password.ToString();
                try
                {
                    using (SqlDataReader reader = sqlcmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                            return user;
                        }
                        else
                        {
                            // No matching row found
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Key combination hasUser!" + ex.Message);
                    return null;
                }


            }
        }

        public Form_Login()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage2);

        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            ReFresh1();// gọi hàm sửa lỗi

        }
        public void ReFresh1()
        {
            tab1_tbx_username.Refresh();
            tab1_tbx_password.Refresh();
            tbx_email.Refresh();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);

        }

        private void btn_si_Click(object sender, EventArgs e)
        {
            testConnection();
            connection.Open();


        }

    }
}
