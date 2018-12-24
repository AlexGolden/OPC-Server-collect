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
        public static string [] SQLinfo = new string[5]; //数据库信息
        public static SqlConnection lo_conn;             //数据库句柄
        public static string dataname;                   //数据名（全局量）
        public static string sql_str;                    //数据库信息整合
    }
}