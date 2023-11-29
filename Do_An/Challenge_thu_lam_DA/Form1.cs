using Do_An.Model;
using Do_An.Modify;
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
using Do_An;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace Do_An
{
    public partial class Form_Login : Form
    {
        //
        static string cnt = "Data Source=LAPTOP-7UOGDK8A;Initial Catalog=DateUser;Integrated Security=True";
        static SqlConnection connection ;
        static SqlDataReader reader;
        //
        int index = 0;
        public static void testConnection()
        {

            try
            {

                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't connect with DB, sao ki z, " + ex.Message);

            }
        }
        public static User hasUser(string email, string password)
        {
            using (connection)
            {
                string query = $"SELECT * FROM  [DateUser].[dbo].[user_pw] WHERE username = @username and password = @pw";
                SqlCommand sqlcmd = new SqlCommand(query, connection);
              // MessageBox.Show($"{email}-user - {password}-pw");
                sqlcmd.Parameters.Add("@username", SqlDbType.VarChar, 1000).Value = email;
                sqlcmd.Parameters.Add("@pw", SqlDbType.VarChar, 1000).Value = Program.CaculateMD5(password);
              //  MessageBox.Show($"{email}-user - {Program.CaculateMD5(password)}-pw");

                try
                {
                    using (SqlDataReader reader = sqlcmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
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
                    MessageBox.Show("Key combination at hasUser!" + ex.Message);
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
            tab3_a.Refresh();
        }
   
  
        private void btn_si_Click(object sender, EventArgs e)

        {
            connection = new SqlConnection(cnt);
            //testConnection();
            connection.Open();
            User user = hasUser(tab1_tbx_username.Text, tab1_tbx_password.Text);
            connection.Close();
            if (user == null)
            {
                MessageBox.Show("Invalid Login Credentials");
            }
            else
            {
                tab1_tbx_password.Text  = tab3_a.Text = tbx_code.Text = string.Empty;

                this.Visible = false;
               // var home = new frmDashboard(user);
               // home.ShowDialog();
               // if (home.DialogResult != DialogResult.No) { this.Close(); }
                this.Visible = true;
            }
        }

        public static int getLastId()
        {
            int i=0;
            string query = "SELECT MAX(ID) FROM [DateUser].[dbo].[user_pw]";
            SqlCommand sqlcmd= new SqlCommand(query,connection);
            try
            {
                
               object j =Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (j != null && j != DBNull.Value)
                {
                    i = Convert.ToInt32(j);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Key combination at getLastID!, "+ex.Message);
            }
            return i;
            
        }
       /* private void bunifuButton1_Click(object sender, EventArgs e)// sign up
        {
             connection = new SqlConnection(cnt);
            connection.Open();
            string query = $"SELECT * FROM [DateUser].[dbo].[user_pw] WHERE username = @email";
            SqlCommand sqlcmd = new SqlCommand(query, connection);
            sqlcmd.Parameters.Add("@email",SqlDbType.VarChar,50).Value = tab2_tbx_email.Text;
            try
            {
                reader = sqlcmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Key combination2-signup!, " + ex.Message);
                connection.Close();
                return;
            }
            if (reader.HasRows)
            {
                MessageBox.Show("Valid Login Credentials");
                connection.Close();
                return;
            }
            else
            {
                reader.Close();
                int last_ID = getLastId();
                query = $"INSERT INTO [DateUser].[dbo].[user_pw] values ('{last_ID + 1}',@ten,@email,@password)";
                sqlcmd = new SqlCommand(query, connection);
                sqlcmd.Parameters.Add("@ten", SqlDbType.NVarChar, 40).Value = tbx_code.Text;
                sqlcmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = tab2_tbx_email.Text.ToString();
                sqlcmd.Parameters.Add("@password", SqlDbType.VarChar, 1000).Value = Program.CaculateMD5(tbx_pw.Text);
                try
                {
                    reader = sqlcmd.ExecuteReader();
                    connection.Close();
                    MessageBox.Show("Đăng ký thành công");
                    tab1_tbx_password.Text = tbx_pw.Text;
                    tab1_tbx_username.Text = tab2_tbx_email.Text;
                    btn_si_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Key combination1-signup!, " + ex.Message);
                    connection.Close();
                }
            }
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (index==0)
            {
                tab2_btn_sendcode.Enabled = false;
                tab2_tbx_code.Enabled = false;
                tab2_btn_confirm.Enabled = false;
            }
            if(index ==1)
            {

            }
            if (string.IsNullOrEmpty(tab3_a.Text))
            {
                tab3_btn_sendcode.Enabled = false;
            }
            else
            {
                

            }
        }

        private void tab2_tbx_email_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void tab2_btn_sendcode_Click(object sender, EventArgs e)
        {

        }
    }
}
