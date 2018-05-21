using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConnectFour.View
{
    public partial class WaitForm : Form
    {
        public ServerForm s;
        public WaitForm(ServerForm server)
        {
            InitializeComponent();
            s = server;
        }

        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            s.readyUpButton.Enabled = true;
            s.readyCount = 0;
        }
    }
}
