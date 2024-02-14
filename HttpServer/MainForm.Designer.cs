namespace HttpServer {
   partial class MainForm {
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if(disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripShow = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripStart = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripStop = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripExit = new System.Windows.Forms.ToolStripTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_connStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_firstTime = new System.Windows.Forms.Label();
            this.label_theNthTime = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label_breakTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_connNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "右键单击显示菜单";
            this.notifyIcon.BalloonTipTitle = "右键单击显示菜单";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "视频窗口管理器";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            this.notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseMove);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.DropShadowEnabled = false;
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShow,
            this.toolStripStart,
            this.toolStripStop,
            this.toolStripExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip.ShowCheckMargin = true;
            this.contextMenuStrip.Size = new System.Drawing.Size(183, 120);
            // 
            // toolStripShow
            // 
            this.toolStripShow.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripShow.Name = "toolStripShow";
            this.toolStripShow.ReadOnly = true;
            this.toolStripShow.Size = new System.Drawing.Size(100, 27);
            this.toolStripShow.Text = "显示";
            this.toolStripShow.Click += new System.EventHandler(this.toolStripShow_Click);
            // 
            // toolStripStart
            // 
            this.toolStripStart.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripStart.Name = "toolStripStart";
            this.toolStripStart.ReadOnly = true;
            this.toolStripStart.Size = new System.Drawing.Size(100, 27);
            this.toolStripStart.Text = "启动";
            this.toolStripStart.Click += new System.EventHandler(this.toolStripStart_Click);
            // 
            // toolStripStop
            // 
            this.toolStripStop.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripStop.Name = "toolStripStop";
            this.toolStripStop.ReadOnly = true;
            this.toolStripStop.Size = new System.Drawing.Size(100, 27);
            this.toolStripStop.Text = "停止";
            this.toolStripStop.Click += new System.EventHandler(this.toolStripStop_Click);
            // 
            // toolStripExit
            // 
            this.toolStripExit.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.ReadOnly = true;
            this.toolStripExit.Size = new System.Drawing.Size(100, 27);
            this.toolStripExit.Text = "退出";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "客户端状态：";
            // 
            // label_connStatus
            // 
            this.label_connStatus.AutoSize = true;
            this.label_connStatus.Location = new System.Drawing.Point(163, 19);
            this.label_connStatus.Name = "label_connStatus";
            this.label_connStatus.Size = new System.Drawing.Size(52, 16);
            this.label_connStatus.TabIndex = 2;
            this.label_connStatus.Text = "无连接";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "第1次连接时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "第n次连接时间：";
            // 
            // label_firstTime
            // 
            this.label_firstTime.AutoSize = true;
            this.label_firstTime.Location = new System.Drawing.Point(163, 78);
            this.label_firstTime.Name = "label_firstTime";
            this.label_firstTime.Size = new System.Drawing.Size(67, 16);
            this.label_firstTime.TabIndex = 5;
            this.label_firstTime.Text = "还没发生";
            // 
            // label_theNthTime
            // 
            this.label_theNthTime.AutoSize = true;
            this.label_theNthTime.Location = new System.Drawing.Point(163, 106);
            this.label_theNthTime.Name = "label_theNthTime";
            this.label_theNthTime.Size = new System.Drawing.Size(67, 16);
            this.label_theNthTime.TabIndex = 6;
            this.label_theNthTime.Text = "还没发生";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 136);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(119, 16);
            this.label.TabIndex = 7;
            this.label.Text = "上1次断开时间：";
            // 
            // label_breakTime
            // 
            this.label_breakTime.AutoSize = true;
            this.label_breakTime.Location = new System.Drawing.Point(163, 136);
            this.label_breakTime.Name = "label_breakTime";
            this.label_breakTime.Size = new System.Drawing.Size(67, 16);
            this.label_breakTime.TabIndex = 8;
            this.label_breakTime.Text = "还没发生";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "共计连接：";
            // 
            // label_connNum
            // 
            this.label_connNum.Location = new System.Drawing.Point(163, 46);
            this.label_connNum.Name = "label_connNum";
            this.label_connNum.Size = new System.Drawing.Size(62, 16);
            this.label_connNum.TabIndex = 10;
            this.label_connNum.Text = "0";
            this.label_connNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "次";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 205);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_connNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_breakTime);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label_theNthTime);
            this.Controls.Add(this.label_firstTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_connStatus);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频窗口管理器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripTextBox toolStripStart;
        private System.Windows.Forms.ToolStripTextBox toolStripStop;
        private System.Windows.Forms.ToolStripTextBox toolStripExit;
        private System.Windows.Forms.ToolStripTextBox toolStripShow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private  System.Windows.Forms.Label label_connStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_firstTime;
        private System.Windows.Forms.Label label_theNthTime;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_breakTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_connNum;
        private System.Windows.Forms.Label label6;
    }
}

