using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectFour.View;

namespace ConnectFour
{
    class ResultCheck
    {
        bool win = false;

        public void CheckRows(CircularButton[,] gameBoard, GameBoardForm g)
        {
            for (int i = 6; i >= 0; i--)
            {
                if ((gameBoard[i, 0].BackColor == Color.Red && gameBoard[i, 1].BackColor == Color.Red && gameBoard[i, 2].BackColor == Color.Red && gameBoard[i, 3].BackColor == Color.Red)
                || (gameBoard[i, 1].BackColor == Color.Red && gameBoard[i, 2].BackColor == Color.Red && gameBoard[i, 3].BackColor == Color.Red && gameBoard[i, 4].BackColor == Color.Red)
                || (gameBoard[i, 2].BackColor == Color.Red && gameBoard[i, 3].BackColor == Color.Red && gameBoard[i, 4].BackColor == Color.Red && gameBoard[i, 5].BackColor == Color.Red)
                || (gameBoard[i, 3].BackColor == Color.Red && gameBoard[i, 4].BackColor == Color.Red && gameBoard[i, 5].BackColor == Color.Red && gameBoard[i, 6].BackColor == Color.Red)
                || (gameBoard[i, 4].BackColor == Color.Red && gameBoard[i, 5].BackColor == Color.Red && gameBoard[i, 6].BackColor == Color.Red && gameBoard[i, 7].BackColor == Color.Red))
                {
                    win = true;
                    int p = Convert.ToInt32(g.label3.Text);
                    g.label3.Text = p + 1 +"";
                    WinnerForm w = new WinnerForm("Red Wins!!", g);
                    w.Show();
                }

                else if ((gameBoard[i, 0].BackColor == Color.Yellow && gameBoard[i, 1].BackColor == Color.Yellow && gameBoard[i, 2].BackColor == Color.Yellow && gameBoard[i, 3].BackColor == Color.Yellow)
                || (gameBoard[i, 1].BackColor == Color.Yellow && gameBoard[i, 2].BackColor == Color.Yellow && gameBoard[i, 3].BackColor == Color.Yellow && gameBoard[i, 4].BackColor == Color.Yellow)
                || (gameBoard[i, 2].BackColor == Color.Yellow && gameBoard[i, 3].BackColor == Color.Yellow && gameBoard[i, 4].BackColor == Color.Yellow && gameBoard[i, 5].BackColor == Color.Yellow)
                || (gameBoard[i, 3].BackColor == Color.Yellow && gameBoard[i, 4].BackColor == Color.Yellow && gameBoard[i, 5].BackColor == Color.Yellow && gameBoard[i, 6].BackColor == Color.Yellow)
                || (gameBoard[i, 4].BackColor == Color.Yellow && gameBoard[i, 5].BackColor == Color.Yellow && gameBoard[i, 6].BackColor == Color.Yellow && gameBoard[i, 7].BackColor == Color.Yellow))
                {
                    win = true;
                    int p = Convert.ToInt32(g.label4.Text);
                    g.label4.Text = p + 1 + "";
                    WinnerForm w = new WinnerForm("Yellow Wins", g);
                    w.Show();
                }
            }
        }

        public void CheckColumns(CircularButton[,] gameBoard, GameBoardForm g)
        {
            for (int i = 7; i >= 0; i--)
            {
                if ((gameBoard[0,i].BackColor == Color.Red && gameBoard[1,i].BackColor == Color.Red && gameBoard[2, i].BackColor == Color.Red && gameBoard[3, i].BackColor == Color.Red)
                || (gameBoard[1, i].BackColor == Color.Red && gameBoard[2, i].BackColor == Color.Red && gameBoard[3, i].BackColor == Color.Red && gameBoard[4, i].BackColor == Color.Red)
                || (gameBoard[2, i].BackColor == Color.Red && gameBoard[3, i].BackColor == Color.Red && gameBoard[4, i].BackColor == Color.Red && gameBoard[5, i].BackColor == Color.Red)
                || (gameBoard[3, i].BackColor == Color.Red && gameBoard[4, i].BackColor == Color.Red && gameBoard[5, i].BackColor == Color.Red && gameBoard[6, i].BackColor == Color.Red))
                {
                    win = true;
                    int p = Convert.ToInt32(g.label3.Text);
                    g.label3.Text = p + 1 + "";
                    WinnerForm w = new WinnerForm("Red Wins!!", g);
                    w.Show();
                }

                else if ((gameBoard[0, i].BackColor == Color.Yellow && gameBoard[1, i].BackColor == Color.Yellow && gameBoard[2, i].BackColor == Color.Yellow && gameBoard[3, i].BackColor == Color.Yellow)
                || (gameBoard[1, i].BackColor == Color.Yellow && gameBoard[2, i].BackColor == Color.Yellow && gameBoard[3, i].BackColor == Color.Yellow && gameBoard[4, i].BackColor == Color.Yellow)
                || (gameBoard[2, i].BackColor == Color.Yellow && gameBoard[3, i].BackColor == Color.Yellow && gameBoard[4, i].BackColor == Color.Yellow && gameBoard[5, i].BackColor == Color.Yellow)
                || (gameBoard[3, i].BackColor == Color.Yellow && gameBoard[4, i].BackColor == Color.Yellow && gameBoard[5, i].BackColor == Color.Yellow && gameBoard[6, i].BackColor == Color.Yellow))
                {
                    win = true;
                    int p = Convert.ToInt32(g.label4.Text);
                    g.label4.Text = p + 1 + "";
                    WinnerForm w = new WinnerForm("Yellow Wins", g);
                    w.Show();
                }
            }
        }

        public void CheckDiagonals(CircularButton[,] gameBoard, GameBoardForm g)
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if ((gameBoard[i, j].BackColor == Color.Red && gameBoard[(i + 1), (j + 1)].BackColor == Color.Red && gameBoard[(i + 2), (j + 2)].BackColor == Color.Red && gameBoard[(i + 3), (j + 3)].BackColor == Color.Red)
                        ||(gameBoard[(i +3), j].BackColor == Color.Red && gameBoard[(i + 2), (j + 1)].BackColor == Color.Red && gameBoard[(i + 1), (j + 2)].BackColor == Color.Red && gameBoard[(i + 0), (j + 3)].BackColor == Color.Red))
                    {
                        win = true;
                        int p = Convert.ToInt32(g.label3.Text);
                        g.label3.Text = p + 1 + "";
                        WinnerForm w = new WinnerForm("Red Wins", g);
                        w.Show();
                    }

                    else if (gameBoard[i, j].BackColor == Color.Yellow && gameBoard[(i + 1), (j + 1)].BackColor == Color.Yellow && gameBoard[(i + 2), (j + 2)].BackColor == Color.Yellow && gameBoard[(i + 3), (j + 3)].BackColor == Color.Yellow
                        || (gameBoard[(i + 3), j].BackColor == Color.Yellow && gameBoard[(i + 2), (j + 1)].BackColor == Color.Yellow && gameBoard[(i + 1), (j + 2)].BackColor == Color.Yellow && gameBoard[(i + 0), (j + 3)].BackColor == Color.Yellow))
                    {
                        win = true;
                        int p = Convert.ToInt32(g.label4.Text);
                        g.label4.Text = p + 1 + "";
                        WinnerForm w = new WinnerForm("Yellow Wins", g);
                        w.Show();
                    }
                }
            }
        }

        public void CheckTie(CircularButton[,] gameBoard, GameBoardForm g)
        {
            if (gameBoard[0, 0].BackColor != Color.White && gameBoard[0, 1].BackColor != Color.White && gameBoard[0, 2].BackColor != Color.White
               && gameBoard[0, 3].BackColor != Color.White && gameBoard[0, 4].BackColor != Color.White && gameBoard[0, 5].BackColor != Color.White
               && gameBoard[0, 6].BackColor != Color.White && gameBoard[0, 7].BackColor != Color.White && win == false)
            {
                WinnerForm w = new WinnerForm("It's a Tie!", g);
                w.Show();
            }
        }
    }
}
