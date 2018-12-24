using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace OPC测试通过
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFrom());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string [] SQLinfo = new string[6];
        public static SqlConnection lo_conn;
        public static string dataname;
       
    }
}