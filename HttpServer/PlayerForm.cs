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
        }

        private void PlayerForm_Resize(object sender,EventArgs e) {
            SetWinSize();
        }
        public void SetWinSize() {
            splitContainer1.SplitterDistance=splitContainer1.Width/2;
            //splitContainer1.SplitterDistance=splitContainer1.Height/2;
            splitContainer2.SplitterDistance=splitContainer2.Height/2;
            splitContainer3.SplitterDistance=splitContainer3.Height/2;
        }
    }
}
