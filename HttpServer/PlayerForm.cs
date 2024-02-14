using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpServer {
    public partial class PlayerForm:Form {
        public PlayerForm() {
            InitializeComponent();
            //Resize+=PlayerForm_Resize;
        }

        private void PlayerForm_Resize(object sender,EventArgs e) {
            if(WindowState==FormWindowState.Maximized) {
                // 窗口正在最大化
            }
            if(WindowState==FormWindowState.Normal) {
                // 窗口退出最大化状态
            }
            SetWinSize();
        }
        public void SetWinSize() {
            splitContainer1.SplitterDistance=splitContainer1.Width/2;
            //splitContainer1.SplitterDistance=splitContainer1.Height/2;
            splitContainer2.SplitterDistance=splitContainer2.Height/2;
            splitContainer3.SplitterDistance=splitContainer3.Height/2;
        }

        private void PlayerForm_MouseClick(object sender,MouseEventArgs e) {
            if(e.Button==MouseButtons.Right) {
                mouseRightMenu.Visible=true;
            }
        }

        private void exitFullScreen_Click(object sender,EventArgs e) {
            WindowState=FormWindowState.Normal;
        }
    }
}
