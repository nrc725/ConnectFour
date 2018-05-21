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
    public partial class WinnerForm : Form
    {
        GameBoardForm gb = new GameBoardForm();

        public WinnerForm(String results ,GameBoardForm game)
        {
            InitializeComponent();
            winnerLabel.Text = results;
            gb = game;
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            gb.Hide();
            this.Hide();
            MainMenuForm m = new MainMenuForm();
            m.Closed += (s, args) => this.Close();
            m.Show();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            gb.ResetBoard();
            this.Hide();
        }
    }
}
