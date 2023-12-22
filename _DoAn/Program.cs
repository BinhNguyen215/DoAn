using _DoAn.Views;
using _DoAn.Views.Employee;
using _DoAn.Views.Import;
using _DoAn.Views.Product;
using _DoAn.Views.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetupEnv();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginView());
        }

        static void SetupEnv()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map["TWILIO_ACCOUNT_SID"] = "AC8101a8703a9eb4d3ba980fb559dfd060";
            map["TWILIO_AUTH_TOKEN"] = "026d6c50335ac21f954f563393196cb7";

            foreach (KeyValuePair<string, string> item in map)
            {
                try
                {
                    // Lấy thông tin biến môi trường hệ thống
                    var systemVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);

                    // Kiểm tra xem biến môi trường đã tồn tại chưa
                    if (!systemVariables.Contains(item.Key))
                    {
                        // Nếu chưa tồn tại, thêm biến môi trường mới
                        Environment.SetEnvironmentVariable(item.Key, item.Value, EnvironmentVariableTarget.User);
                    }
                    else
                    {
                        // Nếu đã tồn tại, cập nhật giá trị của biến môi trường
                        Environment.SetEnvironmentVariable(item.Key, item.Value, EnvironmentVariableTarget.User);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
