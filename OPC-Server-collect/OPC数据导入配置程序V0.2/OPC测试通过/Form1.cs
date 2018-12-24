using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OPC测试通过
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //数据信息录入，并进行连接测试
        {
            Program.SQLinfo[0] = this.textBox1.Text;
            Program.SQLinfo[1] = this.RemoteSqlServerName.Text;
            Program.SQLinfo[2] = this.textBox2.Text;
            Program.SQLinfo[3] = this.textBox3.Text;
            string ip = Program.SQLinfo[0];
            string user = Program.SQLinfo[1];
            string password = Program.SQLinfo[2];
            string database = Program.SQLinfo[3];
            string SqlStr = "Server = " + ip + ";User Id = " + user + ";Pwd =" + password + ";DataBase = " + database + "";
            Program.sql_str = SqlStr;
            try
            {
                Program.lo_conn = new SqlConnection(SqlStr);
                Program.lo_conn.Open();
                if (Program.lo_conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("数据库连接成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！\n" + ex);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
