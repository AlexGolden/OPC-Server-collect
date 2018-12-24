namespace OPC测试通过
{
    partial class MainFrom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslServerState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslServerStartTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslversion = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSetGroupPro = new System.Windows.Forms.Button();
            this.txtGroupDeadband = new System.Windows.Forms.TextBox();
            this.txtGroupIsActive = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUpdateRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIsSubscribed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRemoteServerIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConnServer = new System.Windows.Forms.Button();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.btnGetServerName = new System.Windows.Forms.Button();
            this.btnRecurBrowse = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslServerState,
            this.tsslServerStartTime,
            this.tsslversion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(885, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // tsslServerState
            // 
            this.tsslServerState.Name = "tsslServerState";
            this.tsslServerState.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslServerStartTime
            // 
            this.tsslServerStartTime.Name = "tsslServerStartTime";
            this.tsslServerStartTime.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslversion
            // 
            this.tsslversion.Name = "tsslversion";
            this.tsslversion.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSetGroupPro
            // 
            this.btnSetGroupPro.Enabled = false;
            this.btnSetGroupPro.Location = new System.Drawing.Point(109, 364);
            this.btnSetGroupPro.Name = "btnSetGroupPro";
            this.btnSetGroupPro.Size = new System.Drawing.Size(75, 23);
            this.btnSetGroupPro.TabIndex = 19;
            this.btnSetGroupPro.Text = "设置";
            this.btnSetGroupPro.UseVisualStyleBackColor = true;
            this.btnSetGroupPro.Click += new System.EventHandler(this.btnSetGroupPro_Click);
            // 
            // txtGroupDeadband
            // 
            this.txtGroupDeadband.Location = new System.Drawing.Point(149, 235);
            this.txtGroupDeadband.Name = "txtGroupDeadband";
            this.txtGroupDeadband.Size = new System.Drawing.Size(35, 21);
            this.txtGroupDeadband.TabIndex = 9;
            this.txtGroupDeadband.Text = "0";
            // 
            // txtGroupIsActive
            // 
            this.txtGroupIsActive.ForeColor = System.Drawing.Color.Blue;
            this.txtGroupIsActive.Location = new System.Drawing.Point(149, 208);
            this.txtGroupIsActive.Name = "txtGroupIsActive";
            this.txtGroupIsActive.Size = new System.Drawing.Size(35, 21);
            this.txtGroupIsActive.TabIndex = 8;
            this.txtGroupIsActive.Text = "true";
            this.txtGroupIsActive.TextChanged += new System.EventHandler(this.txtGroupIsActive_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "DefaultGroupDeadband:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "DefaultGroupIsActive:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtUpdateRate
            // 
            this.txtUpdateRate.Location = new System.Drawing.Point(149, 316);
            this.txtUpdateRate.Name = "txtUpdateRate";
            this.txtUpdateRate.Size = new System.Drawing.Size(35, 21);
            this.txtUpdateRate.TabIndex = 5;
            this.txtUpdateRate.Text = "1000";
            this.txtUpdateRate.TextChanged += new System.EventHandler(this.txtUpdateRate_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "UpdateRate:";
            // 
            // txtIsSubscribed
            // 
            this.txtIsSubscribed.ForeColor = System.Drawing.Color.Blue;
            this.txtIsSubscribed.Location = new System.Drawing.Point(149, 289);
            this.txtIsSubscribed.Name = "txtIsSubscribed";
            this.txtIsSubscribed.Size = new System.Drawing.Size(35, 21);
            this.txtIsSubscribed.TabIndex = 3;
            this.txtIsSubscribed.Text = "true";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(61, 292);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "IsSubscribed:";
            // 
            // txtIsActive
            // 
            this.txtIsActive.ForeColor = System.Drawing.Color.Blue;
            this.txtIsActive.Location = new System.Drawing.Point(149, 262);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(35, 21);
            this.txtIsActive.TabIndex = 1;
            this.txtIsActive.Text = "true";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "IsActive:";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(210, 13);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(234, 422);
            this.treeView.TabIndex = 19;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "添加数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(759, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "删除数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(627, 426);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "读取所有值";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(726, 426);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "暂停数据库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(508, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "配置数据库";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(726, 426);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 29;
            this.button6.Text = "插入数据库";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(627, 426);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 30;
            this.button7.Text = "暂停读数";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "OPC采集";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick_1);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(508, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(326, 323);
            this.listView1.TabIndex = 31;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "所属表格";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID编号";
            this.columnHeader3.Width = 80;
            // 
            // txtRemoteServerIP
            // 
            this.txtRemoteServerIP.Location = new System.Drawing.Point(63, 37);
            this.txtRemoteServerIP.Name = "txtRemoteServerIP";
            this.txtRemoteServerIP.Size = new System.Drawing.Size(121, 21);
            this.txtRemoteServerIP.TabIndex = 12;
            this.txtRemoteServerIP.Text = "192.168.100.221";
            this.txtRemoteServerIP.TextChanged += new System.EventHandler(this.txtRemoteServerIP_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "IP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "服务器:";
            // 
            // btnConnServer
            // 
            this.btnConnServer.Location = new System.Drawing.Point(89, 102);
            this.btnConnServer.Name = "btnConnServer";
            this.btnConnServer.Size = new System.Drawing.Size(53, 23);
            this.btnConnServer.TabIndex = 16;
            this.btnConnServer.Text = "连接";
            this.btnConnServer.UseVisualStyleBackColor = true;
            this.btnConnServer.Click += new System.EventHandler(this.btnConnLocalServer_Click);
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(63, 68);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(121, 20);
            this.cmbServerName.TabIndex = 17;
            this.cmbServerName.SelectedIndexChanged += new System.EventHandler(this.cmbServerName_SelectedIndexChanged);
            // 
            // btnGetServerName
            // 
            this.btnGetServerName.Location = new System.Drawing.Point(9, 102);
            this.btnGetServerName.Name = "btnGetServerName";
            this.btnGetServerName.Size = new System.Drawing.Size(75, 23);
            this.btnGetServerName.TabIndex = 18;
            this.btnGetServerName.Text = "获取服务器";
            this.btnGetServerName.UseVisualStyleBackColor = true;
            this.btnGetServerName.Click += new System.EventHandler(this.btnGetServerName_Click);
            // 
            // btnRecurBrowse
            // 
            this.btnRecurBrowse.Location = new System.Drawing.Point(148, 102);
            this.btnRecurBrowse.Name = "btnRecurBrowse";
            this.btnRecurBrowse.Size = new System.Drawing.Size(53, 23);
            this.btnRecurBrowse.TabIndex = 19;
            this.btnRecurBrowse.Text = "展开";
            this.btnRecurBrowse.UseVisualStyleBackColor = true;
            this.btnRecurBrowse.Click += new System.EventHandler(this.btnRecurBrowse_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(528, 426);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 32;
            this.button8.Text = "保存配置";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(6, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 121);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接OPC服务器";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Location = new System.Drawing.Point(5, 172);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 263);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "属性";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "值";
            this.columnHeader4.Width = 80;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(885, 472);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnSetGroupPro);
            this.Controls.Add(this.btnRecurBrowse);
            this.Controls.Add(this.txtGroupDeadband);
            this.Controls.Add(this.btnGetServerName);
            this.Controls.Add(this.txtGroupIsActive);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbServerName);
            this.Controls.Add(this.txtUpdateRate);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnConnServer);
            this.Controls.Add(this.txtIsSubscribed);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIsActive);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtRemoteServerIP);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPC采集";
            this.Load += new System.EventHandler(this.MainFrom_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerState;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerStartTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslversion;
        private System.Windows.Forms.TextBox txtUpdateRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIsSubscribed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGroupDeadband;
        private System.Windows.Forms.TextBox txtGroupIsActive;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSetGroupPro;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtRemoteServerIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConnServer;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnGetServerName;
        private System.Windows.Forms.Button btnRecurBrowse;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

