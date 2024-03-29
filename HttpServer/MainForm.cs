﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static HttpServer.MainForm;
[assembly: OwinStartup(typeof(Startup))]//注意这个，ChatGPT是这样说的
//这个错误通常是由于未正确配置 OWIN 启动类引起的。在您的项目中，需要将 OWIN 启动类配置为应用程序的入口点。
//请按照以下步骤检查和修复配置：
//确保您的项目中有一个类被标记为 OWIN 启动类。这可以通过在类上添加 [assembly: OwinStartup(typeof(Startup))] 属性来实现
namespace HttpServer {

    public partial class MainForm:Form {
        public static PlayerForm player = new PlayerForm();
        private IDisposable signalR;
        public static IntPtr BrowserHandle=(IntPtr)0;
        public static IntPtr PlayerHandle=player.Handle;
        public static bool FirstConnStatus=false;//是否是初次连接，确定服务器第一次被使用的时间
        public static int ConnNum=0;//总的连接次数
        public static MainForm form;
        //public string label_connStatusSetText {
        //    get { return label_connStatus.Text; }
        //    set { this.label_connStatus.Text=value; }
        //}

        #region 静态化Label
        //在MainForm.Designer.cs中静态化了
        //public static label_connStatus lb_firstTime=new System.Windows.Forms.Label();

        #endregion
        public MainForm() {
            InitializeComponent();
        }
        #region 窗体自身事件
        private void MainForm_Load(object sender,EventArgs e) {
            form =sender as MainForm;
            MainForm.player.Show();
            // 启动 SignalR 服务
            signalR=WebApp.Start("http://localhost:8082");
        }
        private void MainForm_FormClosing(object sender,FormClosingEventArgs e) {
            if(e.CloseReason==CloseReason.UserClosing) {
                e.Cancel=true;
                Hide();

            }
        }
        #endregion
        #region 窗体控件所有单击事件
        private void toolStripStart_Click(object sender,EventArgs e) {

        }

        private void toolStripStop_Click(object sender,EventArgs e) {

        }

        private void toolStripExit_Click(object sender,EventArgs e) {
            Application.Exit();
        }

        private void toolStripShow_Click(object sender,EventArgs e) {
            Show();
        }


        #endregion
        public class Startup {
            public void Configuration(IAppBuilder app) {
                // 配置 CORS 策略--其实就是跨域
                app.UseCors(CorsOptions.AllowAll);
                // 配置 SignalR
                app.MapSignalR();

                // 注册 ChatHub
                GlobalHost.DependencyResolver.Register(typeof(ChatHub),() => new ChatHub());
            }
        }
        #region   任务栏控件及时间控件
        private void timer1_Tick(object sender,EventArgs e) {
            Hide(); player.Hide();
            timer1.Stop();
        }

        private void notifyIcon_MouseMove(object sender,MouseEventArgs e) {
            // this.notifyIcon.ShowBalloonTip(3000);win11不能用，不信你开开试试
        }

        private void notifyIcon_MouseDoubleClick(object sender,MouseEventArgs e) {
            this.Show();
        }
        #endregion
        #region 自定义Label文本设置
        public void SetLabelText(string selectLabel,string value) {
            if(InvokeRequired) {
                this.Invoke(new Action(() => {
                    switch(selectLabel) {
                        case "connStatus":
                        label_connStatus.Text=value;
                        break;
                        case "connNum":
                        label_connNum.Text=value;
                        break;
                        case "firstTime":
                        label_firstTime.Text=value;
                        break;
                        case "theNthTime":
                        label_theNthTime.Text=value;
                        break;
                        case "breakTime":
                        label_breakTime.Text=value;
                        break;
                    }
                }));
            } 
        }
        #endregion
    }
}
