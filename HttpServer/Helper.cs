using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer {
    public class Helper {


        #region   "常量定义 "
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOZORDER = 0x0004;
        public const uint SWP_SHOWWINDOW = 0x0040;
        public const int TVGN_CARET = 0x00000009;
        public const int TVM_SELECTITEM = 0x0000110b;
        public const int TVGN_ROOT = 0x00000000;
        public const int TVM_GETNEXTITEM = 0x0000110a;
        public const int TVIF_TEXT = 0x0001;
        public const int TVGN_NEXT = 0x00000001;
        public const int TVM_GETITEM = 0x0000110c;
        public const int TVGN_CHILD = 0x00000004;
        public const int GMEM_FIXED = 0x0000;
        public const int GWL_HWNDPARENT = -8;
        //public const uint HWND_TOPMOST = -1;0x40000000L
        public const long WS_CHILD = 0x40000000L;//GWL_STYLE
        public const int GWL_STYLE=-16;

        #endregion
        #region   "API函数定义 "
        #region SetWindowPos 说明：这个函数能改变窗口的大小、位置和设置子窗口、弹出窗口或顶层窗口的排列顺序。 
        [DllImport("user32.dll",SetLastError = true)]
        //设置顶层窗口//取消顶层窗口https://blog.csdn.net/liubing8609/article/details/82079303
        public static extern bool SetWindowPos(
           IntPtr hWnd, //窗口句柄 定位的窗口句柄；
           IntPtr hWndInsertAfter,//排列顺序的句柄 置于hwnd前面的窗口句柄。这个参数必须是窗口的句柄或是下面的值之一：HWND_BOTTOM：将窗口置于其它所有窗口的底部；
                                  //HWND_NOTOPMOST：将窗口置于其它所有窗口的顶部，并位于任何最顶部窗口的后面。如果这个窗口非顶部窗口，这个标记对该窗口并不产生影响；
                                  //HWND_TOP：将窗口置于它所有窗口的顶部；
                                  //HWND_TOPMOST：将窗口置于其它所有窗口的顶部，并位于任何最顶部窗口的前面。即使这个窗口不是活动窗口，也维持最顶部状态。
           int X, //水平坐标
           int Y, //垂直坐标
           int cx,//宽
           int cy,//高
           uint uFlags//窗口定位标识 指定窗口状态和位置的标记。这个参数使用下面值的组合：
                      //SWP_DRAWFRAME：围绕窗口画一个框。
                      //SWP_FRAMECHANGED：发送一条WM_NCCALCSIZE消息进入窗口，即使窗口的大小没有发生改变。如果不指定这个参数，消息WM_NCCALCSIZE只有在窗口大小发生改变时才发送
                      //SWP_HIDEWINDOW：隐藏窗口
                      //SWP_NOACTIVATE：不激活窗口
                      //SWP_NOCOPYBITS：屏蔽客户区域
                      //SWP_NOMOVE：保持当前位置（X和Y参数将被忽略）
                      //SWP_NOOWNERZORDER：不改变所有窗口的位置和排列顺序
                      //SWP_NOREDRAW：窗口不自动重画
                      //SWP_NOREPOSITION：与SWP_NOOWNERZORDER标记相同
                      //SWP_NOSENDCHANGING：防止这个窗口接受WM_WINDOWPOSCHANGING消息
                      //SWP_NOSIZE：保持当前大小（cx和cy会被忽略）
                      //SWP_NOZORDER：保持窗口在列表的当前位置（hWndInsertAfter将被忽略）
                      //SWP_SHOWWINDOW：显示窗口
           );
        #endregion
        [DllImport("user32.dll",SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWnd,IntPtr PanelHandle);
        [DllImport("user32.dll",SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd,int nIndex);
        [DllImport("user32.dll",SetLastError = true)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd,int nIndex);

        #endregion
    }
}
