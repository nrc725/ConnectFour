using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ConnectFour.View;

namespace ConnectFour
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameBoardForm g = new GameBoardForm();
            g.Closed += (s, args) => this.Close();
            g.Show();
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            CreditsForm c = new CreditsForm();
            c.Closed += (s, args) => this.Close();
            c.Show();
        }

        private void multiplayerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServerForm sf = new ServerForm();
            sf.Closed += (s, args) => this.Close();
            sf.Show();
        }
    }
}
