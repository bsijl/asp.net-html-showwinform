namespace HttpServer {
    partial class MainForm {
        /// <summary>
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
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "视频窗口管理器1";
            this.notifyIcon.BalloonTipTitle = "视频窗口管理器2";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "视频窗口管理器";
            this.notifyIcon.Visible = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 260);
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

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripTextBox toolStripStart;
        private System.Windows.Forms.ToolStripTextBox toolStripStop;
        private System.Windows.Forms.ToolStripTextBox toolStripExit;
        private System.Windows.Forms.ToolStripTextBox toolStripShow;
        private System.Windows.Forms.Timer timer1;
    }
}

