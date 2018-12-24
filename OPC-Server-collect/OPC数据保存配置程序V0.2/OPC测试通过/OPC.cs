using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using OPCAutomation;
using System.Threading;

namespace CollectProtocol.OPC
{
    public class OPC
    {
        #region 声明关于事件的委托
        public delegate void DataChangeEventHandler(object sender, EventArgs e);
        public delegate void WriteCompleteEventHandler(object sender, EventArgs e);
        public delegate void ReadCompleteEventHandler(object sender, EventArgs e);
        public delegate void GetLocalServerHandle();
        #endregion

        #region 委托

        #endregion

        #region 声明事件
        public event DataChangeEventHandler DataChangeEvent;
        public event WriteCompleteEventHandler WriteCompleteEvent;
        public event ReadCompleteEventHandler ReadCompleteEvent;
        #endregion

        #region 私有变量
        /// <summary>
        /// OPCServer Object
        /// </summary>
        OPCServer KepServer = new OPCServer();
        /// <summary>
        /// OPCGroups Object
        /// </summary>
        OPCGroups KepGroups;
        /// <summary>
        /// OPCGroup Object
        /// </summary>
        OPCGroup KepGroup;
        /// <summary>
        /// OPCItems Object
        /// </summary>
        OPCItems KepItems;
        /// <summary>
        /// OPCItem Object
        /// </summary>
        OPCItem KepItem;
        /// <summary>
        /// 主机IP
        /// </summary>
        string strHostIP = "";
        /// <summary>
        /// 主机名称
        /// </summary>
        string strHostName = "";
        /// <summary>
        /// 连接状态
        /// </summary>
        bool opc_connected = false;
        /// <summary>
        /// 客户端句柄
        /// </summary>
        int itmHandleClient = 0;
        List<int> itmHandleClientList = new List<int>();
        /// <summary>
        /// 服务端句柄
        /// </summary>
        int itmHandleServer = 0;
        List<int> itmHandleServerList = new List<int>();

        /// <summary>
        /// 查询时的时间
        /// </summary>
        DateTime QueryTime;
        bool QueryTimeBool = false;
        #endregion

        #region 公有变量
        public string TagValue;
        public string Qualities;
        public string TimeStamps;

        /// <summary>
        /// 异步读取多个
        /// </summary>
        public List<string> TagValueList = new List<string>();
        public List<string> QualitiesList = new List<string>();
        public List<string> TimeStampsList = new List<string>();

        public string lblState;

        public TreeView ItemTreeNode = new TreeView();

        public string ServerState;
        public string ServerStartTime;
        public string version;
        public List<string> ServerName = new List<string>();
        public string TagPath;
        public int DataRecDelayTime = 0;
        #endregion

        #region 私有方法
        /// <summary>
        /// 连接OPC服务器
        /// </summary>
        /// <param name="remoteServerIP">OPCServerIP</param>
        /// <param name="remoteServerName">OPCServer名称</param>
        private bool ConnectRemoteServer(string remoteServerIP, string remoteServerName)
        {
            try
            {
                KepServer.Connect(remoteServerName, remoteServerIP);

                if (KepServer.ServerState == (int)OPCServerState.OPCRunning)
                {
                    ServerState = "已连接到-" + KepServer.ServerName + "   ";
                }
                else
                {
                    //这里你可以根据返回的状态来自定义显示信息，请查看自动化接口API文档
                    ServerState = "状态：" + KepServer.ServerState.ToString() + "   ";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("连接远程服务器出现错误：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 创建组
        /// </summary>
        private bool CreateGroup()
        {
            try
            {
                KepGroups = KepServer.OPCGroups;
                KepGroup = KepGroups.Add("OPCDOTNETGROUP");
                SetGroupProperty("true", "0", "1000", "true", "true");
                KepGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
                KepGroup.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(KepGroup_AsyncWriteComplete);
                KepGroup.AsyncReadComplete += new DIOPCGroupEvent_AsyncReadCompleteEventHandler(GroupAsyncReadComplete);
                KepItems = KepGroup.OPCItems;
            }
            catch (Exception err)
            {
                MessageBox.Show("创建组出现错误：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }



        /// <summary>
        /// 建立分支树
        /// </summary>
        /// <param name="node"></param>
        /// <param name="oPCBrowser"></param>
        private void BuildBranchTree(ref TreeNode node, OPCBrowser oPCBrowser)
        {
            if (node == null)
            {
                MessageBox.Show("请创建根节点");
            }
            TreeNode treeNode;
            oPCBrowser.ShowBranches();
            foreach (object Branch in oPCBrowser)
            {
                treeNode = node.Nodes.Add(Branch.ToString()); 
                try
                {
                    oPCBrowser.MoveDown(Branch.ToString());
                    BuildBranchTree(ref treeNode, oPCBrowser);
                    oPCBrowser.MoveUp();
                }
                catch(Exception )
                {
                }
            }
            ListLeaf(ref node, oPCBrowser);

        }
        /// <summary>
        /// 遍历该分支节点下所有的叶节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="oPCBrowser"></param>
        private void ListLeaf(ref TreeNode node, OPCBrowser oPCBrowser)
        {
            if (null == node)
            {
                oPCBrowser.MoveToRoot();
                node = ItemTreeNode.Nodes.Add("Root");
            }
            else
            {//剔除无意义的Root根节点
                List<string> BranchesList = new List<string>();
                BranchesList.AddRange(node.FullPath.Split('\\'));
                BranchesList.RemoveAt(0);
                Array Branches=BranchesList.ToArray();
                oPCBrowser.MoveTo(ref Branches);
            }
            oPCBrowser.ShowLeafs(false);//false不展开子集叶，true展开所有子集叶
            foreach (object item in oPCBrowser)
            {
                node.Nodes.Add(item.ToString());
            }            
            oPCBrowser.ShowBranches();
            
        }

        #endregion

        #region 事件
        /// <summary>
        /// 写入TAG值时执行的事件
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="Errors"></param>
        void KepGroup_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            lblState = "";
            for (int i = 1; i <= NumItems; i++)
            {
                lblState += "Tran:" + TransactionID.ToString() + "   CH:" + ClientHandles.GetValue(i).ToString() + "   Error:" + Errors.GetValue(i).ToString();
            }
            if (this.WriteCompleteEvent != null)
            {
                this.WriteCompleteEvent(this, new EventArgs());   //发出数据变化信号
            }
        }
        /// <summary>
        /// 每当项数据有变化时执行的事件
        /// </summary>
        /// <param name="TransactionID">处理ID</param>
        /// <param name="NumItems">项个数</param>
        /// <param name="ClientHandles">项客户端句柄</param>
        /// <param name="ItemValues">TAG值</param>
        /// <param name="Qualities">品质</param>
        /// <param name="TimeStamps">时间戳</param>
        void KepGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            //为了测试，所以加了控制台的输出
            //MessageBox.Show("********" + NumItems.ToString() + "*********");           
            for (int i = 1; i <= NumItems; i++)
            {
                try
                {
                    this.TagValue = ItemValues.GetValue(i).ToString();
                }
                catch(Exception)
                {

                }
                this.Qualities = Qualities.GetValue(i).ToString();
                this.TimeStamps = TimeStamps.GetValue(i).ToString();
            }
            if (this.DataChangeEvent != null)
            {
                this.DataChangeEvent(this, new EventArgs());   //发出数据变化信号
            }
            if (QueryTimeBool)
            {
                DataRecDelayTime = (int)((TimeSpan)(DateTime.Now - QueryTime)).TotalMilliseconds;
                QueryTimeBool = false;
            }
        }

        /// <summary>
        /// 异步读完成
        /// 运行时，Array数组从下标1开始而非0！
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        /// <param name="Errors"></param>
        void GroupAsyncReadComplete(int TransactionID, int NumItems, ref System.Array ClientHandles, ref System.Array _ItemValues, ref System.Array _Qualities, ref System.Array _TimeStamps, ref System.Array Errors)
        {
            //MessageBox.Show("*"+ NumItems.ToString() +"*");
            for (int i = 1; i <= NumItems; i++)
            {
                //this.TagValueList[i - 1] = Convert.ToString(_ItemValues.GetValue(i));
                //this.QualitiesList[i - 1] = Convert.ToString(_Qualities.GetValue(i));
                //this.TimeStampsList[i - 1] = Convert.ToString(_TimeStamps.GetValue(i));
                TagValueList.Add(Convert.ToString(_ItemValues.GetValue(i)));
                QualitiesList.Add(Convert.ToString(_Qualities.GetValue(i)));
                TimeStampsList.Add(Convert.ToString(_TimeStamps.GetValue(i)));
            }
            if (this.ReadCompleteEvent != null)
            {
                this.ReadCompleteEvent(this, new EventArgs());   //发出数据变化信号
            }
            if (QueryTimeBool)
            {
                DataRecDelayTime = (int)((TimeSpan)(DateTime.Now - QueryTime)).TotalMilliseconds;
                QueryTimeBool = false;
            }
        }

        #endregion

        #region 公有方法
        /// <summary>
        /// 枚举本地OPC服务器
        /// </summary>
        public void GetLocalServer()
        {
            //获取本地计算机IP,计算机名称
            IPHostEntry IPHost = Dns.GetHostEntry(Environment.MachineName);
            if (IPHost.AddressList.Length > 0)
            {
                strHostIP = IPHost.AddressList[0].ToString();
            }
            else
            {
                return;
            }
            //通过IP来获取计算机名称，可用在局域网内
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostIP);
            strHostName = ipHostEntry.HostName.ToString();

            //获取本地计算机上的OPCServerName
            try
            {
                object serverList = KepServer.GetOPCServers(strHostName);

                if (serverList != null) ServerName.Clear();

                foreach (string turn in (Array)serverList)
                {
                    ServerName.Add(turn);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("枚举本地OPC服务器出错：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// 枚举远端OPC服务器
        /// </summary>
        public void GetRomoteServer(string strHostIP)
        {
            //获取远端计算机上的OPCServerName
            try
            {
                KepServer = new OPCServer();
                object serverList = KepServer.GetOPCServers(strHostIP);

                if (serverList != null) ServerName.Clear();

                foreach (string turn in (Array)serverList)
                {
                    ServerName.Add(turn);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("枚举远端OPC服务器出错：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// 初始，获取本地服务器
        /// </summary>
        public OPC()
        {
            //GetLocalServerHandle getLocalServerHandle = new GetLocalServerHandle(GetLocalServer);
            //getLocalServerHandle.BeginInvoke(null,null);
        }
        /// <summary>
        /// 关闭窗体时处理的事情
        /// </summary>
        public void Close()
        {
            if (!opc_connected)
            {
                return;
            }

            if (KepGroup != null)
            {
                KepGroup.DataChange -= new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
                KepGroup.AsyncWriteComplete -= new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(KepGroup_AsyncWriteComplete);
                KepGroup.AsyncReadComplete -= new DIOPCGroupEvent_AsyncReadCompleteEventHandler(GroupAsyncReadComplete);
            }

            if (KepServer != null)
            {
                //释放所有组资源
                KepServer.OPCGroups.RemoveAll();
                KepServer.Disconnect();
                KepServer = null;
            }

            opc_connected = false;
        }
        /// <summary>
        /// 写入
        /// </summary>
        public void WriteTagValue(string tagValue)
        {
            try
            {
                OPCItem bItem = KepItems.GetOPCItem(itmHandleServer);
                int[] temp = new int[2] { 0, bItem.ServerHandle };
                Array serverHandles = (Array)temp;
                object[] valueTemp = new object[2] { "", tagValue };
                Array values = (Array)valueTemp;
                Array Errors;
                int cancelID;
                KepGroup.AsyncWrite(1, ref serverHandles, ref values, out Errors, 2009, out cancelID);
                //KepItem.Write(txtWriteTagValue.Text);//这句也可以写入，但并不触发写入事件
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 选择列表项时处理的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectedItem(List<string> itemName)
        {
            try
            {
                if (itmHandleClient != 0)
                {
                    TagValue = "";
                    Qualities = "";
                    TimeStamps = "";

                    //Array Errors;
                    OPCItem bItem = KepItems.GetOPCItem(itmHandleServer);
                    //注：OPC中以1为数组的基数
                    int[] temp = new int[2] { 0, bItem.ServerHandle };
                    Array serverHandle = (Array)temp;
                    //移除上一次选择的项
                    //KepItems.Remove(KepItems.Count, ref serverHandle, out Errors);
                }
                itmHandleClient = 1234;
                foreach (string name in itemName)
                {
                    KepItem = KepItems.AddItem(name, itmHandleClient);
                    if (KepItem != null)
                    {
                        itmHandleServer = KepItem.ServerHandle;
                        TagPath = name;
                        QueryTime = DateTime.Now;
                        QueryTimeBool = true;
                        break;
                    }
                }
                if (KepItem == null)
                    itmHandleClient = 0;//如果依然为空则说明没有添加成功，则itmHandleClient保持为0                
            }
            catch (Exception)
            {
                //没有任何权限的项，都是OPC服务器保留的系统项，此处可不做处理。
                itmHandleClient = 0;
                TagValue = "Error ox";
                Qualities = "Error ox";
                TimeStamps = "Error ox";
                //MessageBox.Show("保留项1错误\n" + err);

            }
        }
        /// <summary>
        /// 异步读取多个Item
        /// </summary>
        /// <param name="itemName"></param>
        public void AsyncReadItems(List<string> ItemName)
        {
             try
            {
                if (itmHandleClientList.Count > 0)
                {
                    TagValueList.Clear();
                    QualitiesList.Clear();
                    TimeStampsList.Clear();

                    //Array Errors;
                    //List<OPCItem> bItem = new List<OPCItem>();
                    //foreach (int itmHandleServer in itmHandleServerList)
                    //{
                    //    bItem.Add(KepItems.GetOPCItem(itmHandleServer));
                    //}
                    ////注：OPC中以1为数组的基数
                    //int[] temp = new int[bItem.Count + 1];
                    //temp[0] = 0;
                    //for (int i = 1; i < temp.Length; i++)
                    //{
                    //    temp[i] = bItem[i - 1].ServerHandle;
                    //}
                    //Array serverHandle = (Array)temp;
                    ////移除上一次选择的项
                    //KepItems.Remove(KepItems.Count, ref serverHandle, out Errors);
                    itmHandleClientList.Clear();
                    itmHandleServerList.Clear();
                }
                for (int i = 0; i < ItemName.Count; i++)
                {
                    itmHandleClientList.Add(1234 + i);
                    KepItem = KepItems.AddItem(ItemName[i], 1234 + i);
                    if (KepItem != null)
                    {
                        itmHandleServerList.Add(KepItem.ServerHandle);
                        QueryTime = DateTime.Now;
                        QueryTimeBool = true;
                    }
                }
                int[] temp1 = new int[itmHandleServerList.Count + 1];
                temp1[0] = 0;
                for (int i = 1; i < temp1.Length; i++)
                {
                    temp1[i] = itmHandleServerList[i - 1];
                }
                Array serverHandles = (Array)temp1;
                Array _Errors;
                int cancelID;
                KepGroup.AsyncRead(itmHandleClientList.Count, ref serverHandles, out _Errors, 1, out cancelID);//第一参数为item数量
            }
            catch(Exception)
            {
                //没有任何权限的项，都是OPC服务器保留的系统项，此处可不做处理。
                itmHandleClient = 0;
                TagValue = "Error ox";
                Qualities = "Error ox";
                TimeStamps = "Error ox";
                //MessageBox.Show("保留项2错误！\n" + err);
            }
        }
        /// <summary>
        /// 连接ＯＰＣ服务器
        /// </summary>
        public bool ConnectServer(string remoteServerIP, string serverName)
        {
            try
            {
                if (!ConnectRemoteServer(remoteServerIP, serverName))
                {
                    return false;
                }

                itmHandleClient = 0;//重置

                opc_connected = true;

                GetServerInfo();                

                if (!CreateGroup())
                {
                    return false;
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("初始化出错：" + err.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// 获取服务器信息，并显示在窗体状态栏上
        /// </summary>
        public void GetServerInfo()
        {
            ServerStartTime = "开始时间:" + KepServer.StartTime.ToString() + "    ";
            version = "版本:" + KepServer.MajorVersion.ToString() + "." + KepServer.MinorVersion.ToString() + "." + KepServer.BuildNumber.ToString();
        }
        /// <summary>
        /// 设置组属性
        /// </summary>
        public void SetGroupProperty(string GroupIsActive, string GroupDeadband, string UpdateRate, string IsActive, string IsSubscribed)
        {
            KepServer.OPCGroups.DefaultGroupIsActive = Convert.ToBoolean(GroupIsActive);
            KepServer.OPCGroups.DefaultGroupDeadband = Convert.ToInt32(GroupDeadband);
            KepServer.OPCGroups.DefaultGroupUpdateRate = 1000;//默认组群的刷新频率为1000ms
            KepGroup.UpdateRate = Convert.ToInt32(UpdateRate);
            KepGroup.IsActive = Convert.ToBoolean(IsActive);
            KepGroup.IsSubscribed = Convert.ToBoolean(IsSubscribed);
        }
        /// <summary>
        /// 列出OPC服务器中所有节点
        /// </summary>
        /// <param name="oPCBrowser"></param>
        private void RecurBrowse(OPCBrowser oPCBrowser)
        {
            ItemTreeNode.Nodes.Clear();
            //建树 
            oPCBrowser.MoveToRoot();
            TreeNode root = ItemTreeNode.Nodes.Add("Root");
            BuildBranchTree(ref root, oPCBrowser);
        }
        public void RecurBrowse()
        {
            RecurBrowse(KepServer.CreateBrowser());
        }
        #endregion
    }
}
