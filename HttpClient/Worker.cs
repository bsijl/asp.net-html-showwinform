using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Diagnostics;


namespace HttpClient {
    public class Worker:Hub {
        //public string?  HttpClinetId=null;//这里每一次都会运行，所以在这里设置程序集变量无意义
        //public string ? HtmlID=null;


        //服务器接收消息处理
        public void SendMessage(string opt,string msg) {
            switch(opt) {
                case "HtmlConnOK"://网页首次打开 刷新的时候
                    //Form1 r=new Form1();
                //Application.Run(r);

                Program.BrowserHandle=FindWindow(msg);
                BrowserHandle bh=new(Program.BrowserHandle);//这么做是为了在HttpClinet中可以用json转化，目前不知道字符串怎么转化成IntPtr！IntPtr是个指针
                Program.HtmlId=Context.ConnectionId;
                if(Program.HttpClinetId!=null) {//将浏览器窗口句柄传递给HttpClinet
                    Clients.Client(Program.HttpClinetId).SendAsync("ReceiveMessage","BrowserHandle",JsonConvert.SerializeObject(bh));
                } else {
                    Clients.Client(Program.HtmlId).SendAsync("ReceiveMessage","HttpClinetNO","HttpClinet正在启动");
                    //获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。
                    string path = System.Environment.CurrentDirectory;
                    //string programPath = @"C:\Path\To\Your\Application.exe";
                    //Process.Start(path+@"\HttpClient.exe");//启动之后会自动与HttpClient进行连接，并向其发送一个消息 StartOK
                }
                break;
                case "HttpClinetConnOK"://这个的实现只发生在HttpClinet重启时才能在HTML页面显示，因为太快了，html还没连接时就已经完成了
                //接收到HttpClient发送过来一个消息告诉HttpClient它已经启动成功，并已连接
                //由于网页与HttpClient不是WebWorkdr连接，所以网页端在启动后不断ajax发送消息询问是否就绪，一但接续
                Program.HttpClinetId=Context.ConnectionId;
                if(Program.HtmlId!=null&&Program.BrowserHandle>0) {
                    bh=new(Program.BrowserHandle);
                    Clients.Client(Program.HttpClinetId).SendAsync("ReceiveMessage","BrowserHandle",JsonConvert.SerializeObject(bh));
                    Clients.Client(Program.HtmlId).SendAsync("ReceiveMessage",opt,msg);//,"给它一个你窗口，让HttpClient将Form绑定上"  发送给网页程序，告诉其已经就绪。可以显示窗口了
                }
                break;
                case "ShowWin":
                Program.HtmlId=Context.ConnectionId;
                if(Program.HttpClinetId!=null) {
                    Clients.Client(Program.HttpClinetId).SendAsync("ReceiveMessage","ShowWin",msg);//,"给它一个你窗口，让HttpClient将Form绑定上"  发送给网页程序，告诉其已经就绪。可以显示窗口了
                } else {
                    Clients.Client(Program.HtmlId).SendAsync("ReceiveMessage","HttpClinetNO",msg);
                }
                break;
                case "HideWin":
                Program.HtmlId=Context.ConnectionId;
                if(Program.HttpClinetId!=null) {
                    Clients.Client(Program.HttpClinetId).SendAsync("ReceiveMessage","HideWin",msg);//,"给它一个你窗口，让HttpClient将Form绑定上"  发送给网页程序，告诉其已经就绪。可以显示窗口了
                } else {
                    Clients.Client(Program.HtmlId).SendAsync("ReceiveMessage","HttpClinetNO",msg);
                }
                break;
            }

        }
        // 客户端断开连接事件
        public override async Task OnDisconnectedAsync(Exception? exception) {
            string ConnectionId= Context.ConnectionId;
            if(Program.HttpClinetId==ConnectionId) {
                Program.HttpClinetId=null;
                await Clients.Client(Program.HtmlId!).SendAsync("ReceiveMessage","HttpClinetNO","HttpClinet已断开");
            }
            if(Program.HtmlId==ConnectionId) {
                Program.HtmlId=null; Program.BrowserHandle=0;
                if(Program.HttpClinetId!=null) {
                    await Clients.Client(Program.HttpClinetId!).SendAsync("ReceiveMessage","HttpClinetNO","HttpClinet已断开");
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
        // 客户端连接事件
        public override Task OnConnectedAsync() {
            // 您可以在这里执行任何操作，如记录连接、通知其他客户端等
            string connectionId = Context.ConnectionId;
            // 将连接信息发送给客户端
            Clients.Client(connectionId).SendAsync("ReceiveMessage","HtmlConnNO","");//发送这个语句，是为了形成一个回路，因为这里并不知道是html端还是HttpClinet端
            return base.OnConnectedAsync();
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
        public BrowserHandle(IntPtr hb) {
            this.browserHandle=hb;
        }
        public IntPtr browserHandle;
    }
}

