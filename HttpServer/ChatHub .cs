using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
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
        
        public void SendMessage(string opt,string msg) {
            // 处理客户端发送的消息
            // 在这里可以实现您的自定义逻辑，比如将消息广播给所有连接的客户端
            //Clients.Client(MainForm.HtmlClinetId).SendAsync(opt,msg);
            Clients.Caller.SendMessage(opt,msg);
            switch(opt) {
                case "HtmlClinetOK":
                WinInfo  winInfo=JsonConvert.DeserializeObject<WinInfo>(msg);
                IntPtr bh= FindWindow(winInfo.title);
                int style=Helper.GetWindowLong(MainForm.PlayerHandle,Helper.GWL_STYLE);
                if(MainForm.player.InvokeRequired) {
                    MainForm.player.Invoke(new Action(() => {
                        //https://blog.csdn.net/qq_59075481/article/details/133581281  SetParent 函数修改父窗口的误区
                        IntPtr i= Helper.SetParent(MainForm.PlayerHandle,bh);
                        //MainForm.player.Show();
                        Helper.SetWindowPos(MainForm.PlayerHandle,IntPtr.Zero,winInfo.rect.left,winInfo.rect.top,winInfo.rect.width,winInfo.rect.height,0);//Helper.SWP_SHOWWINDOW|Helper.WS_CHILD
                    }));
                } else {
                    MainForm.player.Hide();
                }
                    break;
                default:
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
            return Task.CompletedTask;
        }
        // 客户端断开事件
        public override Task OnDisconnected(bool stopCalled) {
            // 在客户端断开连接时执行的逻辑
            // 可以在这里清理连接信息、向其他客户端发送通知等
            // 例如，可以从在线用户列表中移除断开的客户端
            MainForm.BrowserHandle=(IntPtr)0;
            // 获取断开连接的客户端标识
            if(MainForm.player.InvokeRequired) {
                MainForm.player.Invoke(new Action(() => {
                    Helper.SetParent(MainForm.PlayerHandle,IntPtr.Zero);
                    MainForm.player.Hide();
                }));
            } else {
                MainForm.player.Hide();
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
