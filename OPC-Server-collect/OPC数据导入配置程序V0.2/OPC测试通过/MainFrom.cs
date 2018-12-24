using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using CollectProtocol.OPC;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.InteropServices;
using System.Data.OleDb;


namespace OPC测试通过
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        Thread OPC_thread = null; //初始化OPC线程
        Thread threadsql = null;  //初始化数据库线程
        [DllImport("kernel32.dll")] 
        static extern uint GetTickCount(); //毫秒级计时


        private OPC opc = new OPC();
        private bool flag = false; //读OPC数值得标志位
        private string[] valuebox = new string[1024]; //OPC数值缓存区



        private void DataChange(object sender, EventArgs e) //OPC数据更新
        {
            Program.dataname = opc.TagPath;
        }
        /// <summary>
        /// 载入窗体时处理的事情
        /// </summary>
        private void MainFrom_Load(object sender, EventArgs e)
        {
            this.button6.Enabled = false;
            this.button4.Hide();
            this.button7.Hide();
            this.FormClosing += new FormClosingEventHandler(MainFrom_FormClosing);
            opc.DataChangeEvent += new OPC.DataChangeEventHandler(DataChange);
            if (opc.ServerName.Count > 0)//只添加没有的项
            {
                foreach (string str in opc.ServerName)
                {
                    if (!cmbServerName.Items.Contains(str))
                        cmbServerName.Items.Add(str);
                }
            }
        }
        /// <summary>
        /// 关闭窗体时处理的事情
        /// </summary>
        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出？选否,最小化到托盘", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                opc.Close();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;

            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                this.notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            } 
        }
        /// <summary>
        /// 【按钮】设置
        /// </summary>
        private void btnSetGroupPro_Click(object sender, EventArgs e)
        {
            opc.SetGroupProperty(txtGroupIsActive.Text, txtGroupDeadband.Text, txtUpdateRate.Text, txtIsActive.Text, txtIsSubscribed.Text);
        }
        /// <summary>
        /// 【按钮】连接ＯＰＣ服务器
        /// </summary>
        private void btnConnLocalServer_Click(object sender, EventArgs e)
        {

            if (opc.ConnectServer(txtRemoteServerIP.Text, cmbServerName.Text))
            {
                btnSetGroupPro.Enabled = true;
                tsslServerState.Text = opc.ServerState;
                tsslServerStartTime.Text = opc.ServerStartTime;
                tsslversion.Text = opc.version;
            }

        }
 

        /// <summary>
        /// 选择列表项时处理的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void btnGetServerName_Click(object sender, EventArgs e)//只添加没有的项
        {
            opc.GetRomoteServer(txtRemoteServerIP.Text);
            if (opc.ServerName.Count > 0)
            {
                foreach (string str in opc.ServerName)
                {
                    if (!cmbServerName.Items.Contains(str))
                        cmbServerName.Items.Add(str);
                }
            }
        }


        private void btnRecurBrowse_Click(object sender, EventArgs e) //查看root树
        {
            try
            {
                opc.RecurBrowse();
                foreach (TreeNode node in opc.ItemTreeNode.Nodes)
                {
                    TreeNode newNode = node.Clone() as TreeNode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cmbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtRemoteServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtGroupIsActive_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            getExcel(dataGridView1, dataGridView2);
        }

        public bool getExcel(DataGridView dgv1, DataGridView dgv2) //导入excel操作
        {
            bool fflag = true;

            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要导入的Excel文件";
            open.Filter = "Excel文件(*.xls)|*.xls";

            if (open.ShowDialog() == DialogResult.OK)
            {
                string fileName = open.FileName;
                //根据路径打开一个Excel文件并将数据填充到DataSet中   
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + fileName + ";Extended Properties ='Excel 8.0;HDR=NO;IMEX=1'";//导入时包含Excel中的第一行数据，并且将数字和字符混合的单元格视为文本进行导入   
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "select  * from   [sheet1$]";
                OleDbDataAdapter comm = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet();
                try
                {
                    comm.Fill(ds, "table1");
                }
                catch
                {
                    MessageBox.Show("错误信息：009", "错误");
                }
                comm.Fill(ds, "table1");

                //根据DataGridView的列构造一个新的DataTable   
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                foreach (DataGridViewColumn dgvc in dgv1.Columns)
                {
                    if (dgvc.Visible)
                    {

                        DataColumn dc = new DataColumn();
                        dc.ColumnName = dgvc.DataPropertyName;
                        dt.Columns.Add(dc);
                        DataColumn dc2 = new DataColumn();
                        dc2.ColumnName = dgvc.DataPropertyName;
                        dt2.Columns.Add(dc2);

                        if (dgvc.CellType == typeof(DataGridViewCheckBoxCell))
                        {
                            dc2.DataType = Type.GetType("System.Boolean");
                        }
                    }
                }

                //根据Excel的行逐一对上面构造的DataTable的列进行赋值   
                foreach (DataRow excelRow in ds.Tables[0].Rows)
                {
                    int i = 0;
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dr[dc] = excelRow[i];
                        i++;
                    }
                    dt.Rows.Add(dr);
                }

                //判断Excel的格式是否正确   
                int n = 0;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    bool flag = false;
                    for (int k = n; k < dgv1.ColumnCount; k++)
                    {
                        if (dgv1.Columns[k].Visible)  //隐藏的列   
                        {
                            if (dgv1.Columns[k].HeaderText.Trim().ToString() == dt.Rows[0][j].ToString())
                            {
                                if (dgv1.Columns[k].CellType == typeof(DataGridViewCheckBoxCell))
                                {
                                    //list.Add(j);   
                                    //num++;   
                                }
                                flag = true;
                                n = k + 1;
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        MessageBox.Show("导入的Excel的格式错误", "提示");
                        fflag = false;
                        return fflag;
                    }
                }

                //删除多余的行   
                int rowCount = (dt.Rows.Count) / 2;

                for (int i = 0; i <= rowCount; i++)
                {
                    dt.Rows.RemoveAt(0);
                }

                //处理Boolean类型的数据   
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt2.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        try
                        {
                            dr[j] = dt.Rows[i][j];
                        }
                        catch
                        {
                            dr[j] = false;
                        }
                    }
                    dt2.Rows.Add(dr);
                }

                //导入到dataGridView   
                dgv2.DataSource = dt2;
            }
            else
            {
                fflag = false;
            }
            return fflag;
        }    

        private void datacollect() //OPC数据获取
        {
            List<string> Namelist = new List<string>();
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                Namelist.Add(this.dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0, this.dataGridView2.Rows[i].Cells[0].Value.ToString().Length-1));
            }
            while (true)
            {
                if (this.flag == true)
                {
                    break;
                }
                //Action<int> actionDelegate = delegate(int txt) { opc.AsyncReadItems(Namelist); };
                //this.dataGridView1.BeginInvoke(actionDelegate, 1);
                opc.AsyncReadItems(Namelist);
                Thread.Sleep(60000);
            }
        }


        private void DatagridChange(object sender, EventArgs e) //OPC数据组更新
        {
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                valuebox[i] = opc.TagValueList[i];
            }
        }


        private void button5_Click(object sender, EventArgs e) //获取数据库信息
        {
            Form1 f = new Form1();
            f.Owner = this;
            if (f.ShowDialog() == DialogResult.OK)
            {

            }
        }


        private void button3_Click(object sender, EventArgs e) //OPC读取按钮
        {
            try
            {
                this.button3.Hide();
                this.button7.Show();
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button6.Enabled = true;
                this.button7.Enabled = true;
                this.txtRemoteServerIP.Enabled = false;
                this.cmbServerName.Enabled = false;
                this.btnGetServerName.Enabled = false;
                this.btnConnServer.Enabled = false;
                this.txtGroupIsActive.Enabled = false;
                this.txtGroupDeadband.Enabled = false;
                this.txtIsActive.Enabled = false;
                this.txtIsSubscribed.Enabled = false;
                this.txtUpdateRate.Enabled = false;
                this.btnSetGroupPro.Enabled = false;
                this.flag = false;
                OPC_thread = new Thread(datacollect);
                OPC_thread.IsBackground = true;
                //OPC_thread.Priority = ThreadPriority.Highest;
                OPC_thread.Start();
                opc.ReadCompleteEvent += new OPC.ReadCompleteEventHandler(DatagridChange);
            }
            catch(Exception ex)
            {
                MessageBox.Show("出现异常！\n" + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e) //数据库连接按钮
        {
            try
            {
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button5.Enabled = false;
                this.button7.Enabled = false;
                this.button4.Show();
                this.button6.Hide();
                string SqlStr = "Server = " + Program.SQLinfo[0] + ";User Id = " + Program.SQLinfo[1] + ";Pwd =" + Program.SQLinfo[2] + ";DataBase = " + Program.SQLinfo[3] + "";
                threadsql = new Thread(sqlcollect);
                threadsql.IsBackground = true;
                Program.lo_conn = new SqlConnection(SqlStr);
                Program.lo_conn.Open();
                threadsql.Start(); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("出现异常！\n" + ex);
            }
        }


        private void sqlcollect() //数据连接并插入，为保证稳定，每次插入数据库都进行数据库重连
        {
            while (true)
            {
                try
                {
                    Program.lo_conn = new SqlConnection(Program.sql_str);
                    Program.lo_conn.Open();
                    for (int i = 0; i < (dataGridView2.Rows.Count); i++)
                    {
                        if (dataGridView2.Rows[i].Cells[0].Value != null)
                        {
                            try
                            {
                                string SQLString = "insert into " + this.dataGridView2.Rows[i].Cells[1].Value.ToString().Substring(0, this.dataGridView2.Rows[i].Cells[1].Value.ToString().Length - 1) + "(TIME,ITEM_ID,VALUE) values('" + GetCurrentTime() + "'," + this.dataGridView2.Rows[i].Cells[2].Value.ToString().Substring(0, this.dataGridView2.Rows[i].Cells[2].Value.ToString().Length - 1) + ",'" + decimal.Parse(valuebox[i]) + "')";
                                SqlCommand cmd = new SqlCommand(SQLString, Program.lo_conn);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Program.lo_conn.Close();
                }
                
                Program.lo_conn.Close();
                Array.Clear(valuebox, 0, valuebox.Length);
                Thread.Sleep(60000);
            }
        }


        public static bool Delay(int delayTime) //秒级延时
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        static void Delayms(uint ms) //毫秒级延时
        {
            uint start = GetTickCount();
            while (GetTickCount() - start < ms)
            {
                Application.DoEvents();
            }
        }


        /// 当前时间   
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        private void button4_Click(object sender, EventArgs e) //暂停数据操作
        {
            try
            {
                this.button4.Hide();
                this.button6.Show();
                this.button7.Enabled = true;
                this.button5.Enabled = true;
                threadsql.Abort();
                MessageBox.Show("暂停数据库操作");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现异常！\n" + ex);
            }
        }



        private void button7_Click(object sender, EventArgs e) //暂停OPC数据的读取
        {
            try
            {
                this.flag = true;
                this.button7.Hide();
                this.button3.Show();
                this.button6.Enabled = false;
                this.button1.Enabled = true;
                this.button2.Enabled = true;
                this.txtRemoteServerIP.Enabled = true;
                this.cmbServerName.Enabled = true;
                this.btnGetServerName.Enabled = true;
                this.btnConnServer.Enabled = true;
                this.txtGroupIsActive.Enabled = true;
                this.txtGroupDeadband.Enabled = true;
                this.txtIsActive.Enabled = true;
                this.txtIsSubscribed.Enabled = true;
                this.txtUpdateRate.Enabled = true;
                this.btnSetGroupPro.Enabled = true;
                Delayms(100);
                OPC_thread.Abort();
                MessageBox.Show("暂停OPC读数");
            }
            catch(Exception ex)
            {
                MessageBox.Show("出现异常！\n" + ex);
            }
        }


        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e) //双击后台图标还原采集窗口
        {
            base.Visible = true;
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            base.WindowState = FormWindowState.Normal;
        }

        private void txtUpdateRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //删除所选行
        {
            try
            {
                if (this.dataGridView2.SelectedRows.Count > 0)
                {
                    for (int i = this.dataGridView2.SelectedRows.Count; i > 0; i--)
                    {
                        dataGridView2.Rows.Remove(dataGridView2.SelectedRows[i - 1]);
                    }
                }
                else
                {
                    MessageBox.Show("请选取数据行！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！\n" + ex);
            }
        }


    }
}