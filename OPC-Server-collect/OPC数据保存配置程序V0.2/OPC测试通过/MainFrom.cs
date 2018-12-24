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


namespace OPC测试通过
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        Thread OPC_thread = null;
        Thread threadsql = null;
        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();


        private OPC opc = new OPC();
        private bool flag = false;
        private string [] valuebox = new string [1024];



        private void DataChange(object sender, EventArgs e)
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
            if (opc.ServerName.Count > 0)
            {//只添加没有的项
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
                treeView.Nodes.Clear();
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
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /* 
             * 全路径，依次减少父节点路径。如全路径为：a.b.c,那么分成数组Item[3]={a,b,c}
             *  那么依次测试a.b.c,b.c,和c是否能正确取回对象，能取回，则直接返回
             */
            
            Array Item = treeView.SelectedNode.FullPath.Split('\\');
            Array.Reverse(Item);
            List<string> Name = new List<string>();
            string str = "";
            foreach (string item in Item)
            {
                str = item + str;
                Name.Add(str);
                str = "." + str;
            }
            Name.Reverse();
            opc.SelectedItem(Name);
        }


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


        private void btnRecurBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                treeView.Nodes.Clear();
                opc.RecurBrowse();
                foreach (TreeNode node in opc.ItemTreeNode.Nodes)
                {
                    TreeNode newNode = node.Clone() as TreeNode;
                    treeView.Nodes.Add(newNode);
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
            if (Program.dataname != "")
            {
                Form2 f = new Form2();
                f.Owner = this;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem lv = new ListViewItem();
                    lv.SubItems[0].Text = Program.dataname;
                    lv.SubItems.Add(Program.SQLinfo[4]);
                    lv.SubItems.Add(Program.SQLinfo[5]);
                    lv.SubItems.Add("0");
                    listView1.Items.Add(lv);
                    listView1.Refresh();
                }
            }
            else
            {
                MessageBox.Show("请选取读数！");
            }
        }


        private void datacollect()
        {
            List<string> Namelist = new List<string>();
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                Namelist.Add(this.listView1.Items[i].SubItems[0].Text.ToString());
            }
            while (true)
            {
                if (this.flag == true)
                {
                    break;
                }
                //Action<int> actionDelegate = delegate(int txt) { opc.AsyncReadItems(Namelist); };
                //this.listView1.BeginInvoke(actionDelegate, 1);
                opc.AsyncReadItems(Namelist);
                Thread.Sleep(1000);
            }
        }


        private void DatagridChange(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                this.listView1.Items[i].SubItems[3].Text = opc.TagValueList[i];
                valuebox[i] = opc.TagValueList[i];
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Owner = this;
            if (f.ShowDialog() == DialogResult.OK)
            {

            }
        }


        private void button3_Click(object sender, EventArgs e)
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
                this.btnRecurBrowse.Enabled = false;
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

        private void button6_Click(object sender, EventArgs e)
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


        private void sqlcollect()
        {
            while (true)
            {
                for (int i = 0; i < (listView1.Items.Count); i++)
                {
                    if (listView1.Items[i].SubItems[0].Text != null)
                    {
                        try
                        {
                            string SQLString = "insert into " + this.listView1.Items[i].SubItems[1].Text + "(ITEM_ID,TIME,VALUE) values('" + this.listView1.Items[i].SubItems[2].Text + "','" + GetCurrentTime() + "','" + decimal.Parse(valuebox[i]) + "')";
                            SqlCommand cmd = new SqlCommand(SQLString, Program.lo_conn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        { 
                            
                        }
                    }
                }
                Array.Clear(valuebox, 0, valuebox.Length);
                Thread.Sleep(60000);
            }
        }


        public static bool Delay(int delayTime)
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

        static void Delayms(uint ms)
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

        private void button4_Click(object sender, EventArgs e)
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


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    for (int i = this.listView1.SelectedItems.Count; i > 0; i--)
                    {
                        listView1.Items.Remove(listView1.SelectedItems[i - 1]);
                    }
                }
                else
                {
                    MessageBox.Show("请选取数据名称！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！\n" + ex);
            }
        }


        private void button7_Click(object sender, EventArgs e)
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
                this.btnRecurBrowse.Enabled = true;
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


        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            base.Visible = true;
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            base.WindowState = FormWindowState.Normal;
        }

        private void txtUpdateRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExportToExecl();
        }


        /// <summary>
        /// 执行导出数据
        /// </summary>
        public void ExportToExecl()
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DoExport(this.listView1, sfd.FileName);
            }
        }

        /// <summary>
        /// 具体导出的方法
        /// </summary>
        /// <param name="listView">ListView</param>
        /// <param name="strFileName">导出到的文件名</param>
        private void DoExport(ListView listView, string strFileName)
        {
            int rowNum = listView.Items.Count;
            int columnNum = listView.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表第一行
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;
                MessageBox.Show("导出成功");
            }
        }
    }
}