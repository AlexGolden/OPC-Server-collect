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
            this.txtRemoteServerIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetServerName = new System.Windows.Forms.Button();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.btnConnServer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSetGroupPro = new System.Windows.Forms.Button();
            this.txtGroupDeadband = new System.Windows.Forms.TextBox();
            this.txtGroupIsActive = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUpdateRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIsSubscribed = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslServerState,
            this.tsslServerStartTime,
            this.tsslversion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
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
            // txtRemoteServerIP
            // 
            this.txtRemoteServerIP.Location = new System.Drawing.Point(59, 17);
            this.txtRemoteServerIP.Name = "txtRemoteServerIP";
            this.txtRemoteServerIP.Size = new System.Drawing.Size(121, 21);
            this.txtRemoteServerIP.TabIndex = 12;
            this.txtRemoteServerIP.Text = "192.168.100.221";
            this.txtRemoteServerIP.TextChanged += new System.EventHandler(this.txtRemoteServerIP_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "IP:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnGetServerName);
            this.groupBox1.Controls.Add(this.cmbServerName);
            this.groupBox1.Controls.Add(this.btnConnServer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRemoteServerIP);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 121);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接OPC服务器";
            // 
            // btnGetServerName
            // 
            this.btnGetServerName.Location = new System.Drawing.Point(5, 82);
            this.btnGetServerName.Name = "btnGetServerName";
            this.btnGetServerName.Size = new System.Drawing.Size(75, 23);
            this.btnGetServerName.TabIndex = 18;
            this.btnGetServerName.Text = "获取服务器";
            this.btnGetServerName.UseVisualStyleBackColor = true;
            this.btnGetServerName.Click += new System.EventHandler(this.btnGetServerName_Click);
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(59, 48);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(121, 20);
            this.cmbServerName.TabIndex = 17;
            this.cmbServerName.SelectedIndexChanged += new System.EventHandler(this.cmbServerName_SelectedIndexChanged);
            // 
            // btnConnServer
            // 
            this.btnConnServer.Location = new System.Drawing.Point(104, 82);
            this.btnConnServer.Name = "btnConnServer";
            this.btnConnServer.Size = new System.Drawing.Size(75, 23);
            this.btnConnServer.TabIndex = 16;
            this.btnConnServer.Text = "连接";
            this.btnConnServer.UseVisualStyleBackColor = true;
            this.btnConnServer.Click += new System.EventHandler(this.btnConnLocalServer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "服务器:";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.btnSetGroupPro);
            this.groupBox5.Controls.Add(this.txtGroupDeadband);
            this.groupBox5.Controls.Add(this.txtGroupIsActive);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtUpdateRate);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtIsSubscribed);
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtIsActive);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(4, 142);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 293);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "尝试更改一下组的属性";
            // 
            // btnSetGroupPro
            // 
            this.btnSetGroupPro.Enabled = false;
            this.btnSetGroupPro.Location = new System.Drawing.Point(105, 180);
            this.btnSetGroupPro.Name = "btnSetGroupPro";
            this.btnSetGroupPro.Size = new System.Drawing.Size(75, 23);
            this.btnSetGroupPro.TabIndex = 19;
            this.btnSetGroupPro.Text = "设置";
            this.btnSetGroupPro.UseVisualStyleBackColor = true;
            this.btnSetGroupPro.Click += new System.EventHandler(this.btnSetGroupPro_Click);
            // 
            // txtGroupDeadband
            // 
            this.txtGroupDeadband.Location = new System.Drawing.Point(145, 51);
            this.txtGroupDeadband.Name = "txtGroupDeadband";
            this.txtGroupDeadband.Size = new System.Drawing.Size(35, 21);
            this.txtGroupDeadband.TabIndex = 9;
            this.txtGroupDeadband.Text = "0";
            // 
            // txtGroupIsActive
            // 
            this.txtGroupIsActive.ForeColor = System.Drawing.Color.Blue;
            this.txtGroupIsActive.Location = new System.Drawing.Point(145, 24);
            this.txtGroupIsActive.Name = "txtGroupIsActive";
            this.txtGroupIsActive.Size = new System.Drawing.Size(35, 21);
            this.txtGroupIsActive.TabIndex = 8;
            this.txtGroupIsActive.Text = "true";
            this.txtGroupIsActive.TextChanged += new System.EventHandler(this.txtGroupIsActive_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "DefaultGroupDeadband:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "DefaultGroupIsActive:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtUpdateRate
            // 
            this.txtUpdateRate.Location = new System.Drawing.Point(145, 132);
            this.txtUpdateRate.Name = "txtUpdateRate";
            this.txtUpdateRate.Size = new System.Drawing.Size(35, 21);
            this.txtUpdateRate.TabIndex = 5;
            this.txtUpdateRate.Text = "100";
            this.txtUpdateRate.TextChanged += new System.EventHandler(this.txtUpdateRate_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "UpdateRate:";
            // 
            // txtIsSubscribed
            // 
            this.txtIsSubscribed.ForeColor = System.Drawing.Color.Blue;
            this.txtIsSubscribed.Location = new System.Drawing.Point(145, 105);
            this.txtIsSubscribed.Name = "txtIsSubscribed";
            this.txtIsSubscribed.Size = new System.Drawing.Size(35, 21);
            this.txtIsSubscribed.TabIndex = 3;
            this.txtIsSubscribed.Text = "true";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(83, 221);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(46, 51);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 107;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "所属表格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 107;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 107;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "IsSubscribed:";
            // 
            // txtIsActive
            // 
            this.txtIsActive.ForeColor = System.Drawing.Color.Blue;
            this.txtIsActive.Location = new System.Drawing.Point(145, 78);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(35, 21);
            this.txtIsActive.TabIndex = 1;
            this.txtIsActive.Text = "true";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "IsActive:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(412, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "导入配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(294, 425);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "读取所有值";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(413, 425);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "暂停数据库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(242, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 40);
            this.button5.TabIndex = 28;
            this.button5.Text = "配置数据库";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(413, 424);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 29;
            this.button6.Text = "插入数据库";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(294, 424);
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
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(228, 63);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(343, 343);
            this.dataGridView2.TabIndex = 31;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "删除数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(616, 486);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerState;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerStartTime;
        private System.Windows.Forms.TextBox txtRemoteServerIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConnServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripStatusLabel tsslversion;
        private System.Windows.Forms.GroupBox groupBox5;
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
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnGetServerName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

