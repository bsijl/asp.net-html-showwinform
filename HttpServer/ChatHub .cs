﻿using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HttpServer {
    public class ChatHub:Hub {
        //public MainForm mainForm=new MainForm();
        string currentTime = DateTime.Now.ToString();
        //string? currentTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        public void SendMessage(string opt,string msg) {
            // 处理客户端发送的消息
            // 在这里可以实现您的自定义逻辑，比如将消息广播给所有连接的客户端
            switch(opt) {
                case "HtmlClinetOK"://每次刷新都会进行连接，所以这里是不是要做一下判断--好像没有必要
                WinInfo  winInfo=JsonConvert.DeserializeObject<WinInfo>(msg);
                IntPtr bh= FindWindow(winInfo.title);
                int style=Helper.GetWindowLong(MainForm.PlayerHandle,Helper.GWL_STYLE);
                if(MainForm.player.InvokeRequired) {
                    MainForm.player.Invoke(new Action(() => {
                        //https://blog.csdn.net/qq_59075481/article/details/133581281  SetParent 函数修改父窗口的误区
                        IntPtr i= Helper.SetParent(MainForm.PlayerHandle,bh);
                        MainForm.player.Visible=true;
                        Helper.SetWindowPos(MainForm.PlayerHandle,IntPtr.Zero,winInfo.rect.left,winInfo.rect.top,winInfo.rect.width,winInfo.rect.height,Helper.SWP_SHOWWINDOW);//Helper.SWP_SHOWWINDOW|Helper.WS_CHILD
                    }));
                } else {
                    MainForm.player.Visible=true ;
                }
                break;
                case "ShowWin":
                if(MainForm.player.InvokeRequired) {
                    MainForm.player.Invoke(new Action(() => {
                        MainForm.player.Visible=true;//用Visible不用Show是因为Show好像不会改变Visible,Hide可以改变这个值。为SetZoomScale设置使用这个方法
                    }));
                } else {
                    MainForm.player.Visible=true;
                }
                break;
                case "HideWin":
                if(MainForm.player.InvokeRequired) {
                    MainForm.player.Invoke(new Action(() => {
                        MainForm.player.Visible=false;
                    }));
                } else {
                    MainForm.player.Visible=false;
                }
                break;
                case "fullScreen":
                    if(MainForm.player.InvokeRequired) {
                    MainForm.player.Invoke(new Action(() => {
                        MainForm.player.WindowState=FormWindowState.Maximized;
                    }));
                   
                } else {
                    MainForm.player.WindowState=FormWindowState.Maximized;
                }
                break;
                case "SetZoomScale":
                winInfo=JsonConvert.DeserializeObject<WinInfo>(msg);
                if(MainForm.player.Visible) {
                    if(MainForm.player.InvokeRequired) {
                        MainForm.player.Invoke(new Action(() => {
                            Helper.SetWindowPos(MainForm.PlayerHandle,IntPtr.Zero,winInfo.rect.left,winInfo.rect.top,winInfo.rect.width,winInfo.rect.height,Helper.SWP_SHOWWINDOW);//Helper.SWP_SHOWWINDOW|Helper.WS_CHILD
                            MainForm.player.SetWinSize();
                        }));
                    } else {
                        Helper.SetWindowPos(MainForm.PlayerHandle,IntPtr.Zero,winInfo.rect.left,winInfo.rect.top,winInfo.rect.width,winInfo.rect.height,Helper.SWP_SHOWWINDOW);//Helper.SWP_SHOWWINDOW|Helper.WS_CHILD
                        MainForm.player.SetWinSize();
                    }
                }
                break;
            }

        }
        // 客户端连接事件
        public override Task OnConnected() {
            // 在客户端连接时执行的逻辑
            // 可以在这里记录连接信息、向其他客户端发送通知等
            // 例如，可以将新连接的客户端添加到一个列表中，以便跟踪在线用户
            // 获取连接的客户端标识
            // 返回一个已完成的任务
            MainForm.ConnNum++;
            if(!MainForm.FirstConnStatus) {
                MainForm.FirstConnStatus=true;
                MainForm.form.SetLabelText("firstTime",currentTime);
            }
            MainForm.form.SetLabelText("theNthTime",currentTime);
            MainForm.form.SetLabelText("connNum",MainForm.ConnNum.ToString());
            MainForm.form.SetLabelText("connStatus","客户端已连接");
            Clients.Caller.SendMessage("HtmlClientOK","客户端已连接！");
            return Task.CompletedTask;
        }
        // 客户端断开事件
        public override Task OnDisconnected(bool stopCalled) {
            // 在客户端断开连接时执行的逻辑
            // 可以在这里清理连接信息、向其他客户端发送通知等
            // 例如，可以从在线用户列表中移除断开的客户端
            MainForm.BrowserHandle=(IntPtr)0;
            MainForm.form.SetLabelText("connStatus","客户端已断开");
            MainForm.form.SetLabelText("breakTime",currentTime);
            // 获取断开连接的客户端标识
            Helper.SetParent(MainForm.PlayerHandle,IntPtr.Zero);
            if(MainForm.player.InvokeRequired) {
                MainForm.player.Invoke(new Action(() => {
                    MainForm.player.Visible=false;
                }));
            } else {
                MainForm.player.Visible=false;
            }
            // 向其他客户端发送通知，告知有客户端断开连接
            //Clients.Others.SendAsync("UserDisconnected",connectionId);

            // 返回一个已完成的任务
            return Task.CompletedTask;
        }
        public IntPtr FindWindow(string browserWindowTitle) {
            //浏览器的里程非常特殊，它是多标签的，用FindWindow查不出来，只能用进程的方式去查
            // 获取所有正在运行的进程
            Process[] processes = Process.GetProcesses();
            dynamic ps=processes.Where(e=>e.MainWindowTitle.Contains(browserWindowTitle)).First();
            if(ps!=null) {
                return ps.MainWindowHandle;//"{\"browserHandle\":"+ps.MainWindowHandle+"}";
            }
            return IntPtr.Zero;//"{\"browserHandle\":"+IntPtr.Zero+"}";
            //以下隐藏代码是用ChatGPT对话的形式查出来的 → C#怎么查找浏览器窗口句柄 它直接回答了这些代码。上面Where lambda是我搞出来的
            //IntPtr.Zero;
            //foreach(Process process in processes) {
            //    // 获取进程的主窗口句柄
            //    IntPtr mainWindowHandle = process.MainWindowHandle;
            //    // 如果主窗口句柄不为空
            //    if(mainWindowHandle!=IntPtr.Zero) {
            //        // 获取窗口标题
            //        string windowTitle = process.MainWindowTitle;
            //        // 检查窗口标题是否包含浏览器窗口标题
            //        if(windowTitle.Contains(browserWindowTitle)) {
            //            // 输出浏览器窗口句柄
            //            return mainWindowHandle;
            //        }
            //    }
            //}
            //return IntPtr.Zero;
        }
    }
    class BrowserHandle {
        public IntPtr browserHandle;
    }
    class WinInfo {
        public string title;
        public Rect rect;
    }
    class Rect {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

}
