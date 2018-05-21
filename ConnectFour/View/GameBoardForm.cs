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
    public partial class GameBoardForm : Form
    {
        bool turn = true;
        CircularButton[,] gameBoard = new CircularButton[7,8];
        ResultCheck r = new ResultCheck();
        
        
 
        public GameBoardForm()
        {
            InitializeComponent();
            gameBoard[0,0] = R1C1;
            gameBoard[0,1] = R1C2;
            gameBoard[0,2] = R1C3;
            gameBoard[0,3] = R1C4;
            gameBoard[0,4] = R1C5;
            gameBoard[0,5] = R1C6;
            gameBoard[0,6] = R1C7;
            gameBoard[0,7] = R1C8;
            gameBoard[1,0] = R2C1;
            gameBoard[1,1] = R2C2;
            gameBoard[1,2] = R2C3;
            gameBoard[1,3] = R2C4;
            gameBoard[1,4] = R2C5;
            gameBoard[1,5] = R2C6;
            gameBoard[1,6] = R2C7;
            gameBoard[1,7] = R2C8;
            gameBoard[2,0] = R3C1;
            gameBoard[2,1] = R3C2;
            gameBoard[2,2] = R3C3;
            gameBoard[2,3] = R3C4;
            gameBoard[2,4] = R3C5;
            gameBoard[2,5] = R3C6;
            gameBoard[2,6] = R3C7;
            gameBoard[2,7] = R3C8;
            gameBoard[3,0] = R4C1;
            gameBoard[3,1] = R4C2;
            gameBoard[3,2] = R4C3;
            gameBoard[3,3] = R4C4;
            gameBoard[3,4] = R4C5;
            gameBoard[3,5] = R4C6;
            gameBoard[3,6] = R4C7;
            gameBoard[3,7] = R4C8;
            gameBoard[4,0] = R5C1;
            gameBoard[4,1] = R5C2;
            gameBoard[4,2] = R5C3;
            gameBoard[4,3] = R5C4;
            gameBoard[4,4] = R5C5;
            gameBoard[4,5] = R5C6;
            gameBoard[4,6] = R5C7;
            gameBoard[4,7] = R5C8;
            gameBoard[5,0] = R6C1;
            gameBoard[5,1] = R6C2;
            gameBoard[5,2] = R6C3;
            gameBoard[5,3] = R6C4;
            gameBoard[5,4] = R6C5;
            gameBoard[5,5] = R6C6;
            gameBoard[5,6] = R6C7;
            gameBoard[5,7] = R6C8;
            gameBoard[6,0] = R7C1;
            gameBoard[6,1] = R7C2;
            gameBoard[6,2] = R7C3;
            gameBoard[6,3] = R7C4;
            gameBoard[6,4] = R7C5;
            gameBoard[6,5] = R7C6;
            gameBoard[6,6] = R7C7;
            gameBoard[6,7] = R7C8;

            label1.ForeColor = Color.Red;
            label3.ForeColor = Color.Red;
        }

        public void ResetBoard()
        {
            foreach (CircularButton c in gameBoard)
            {
                c.BackColor = Color.White;
                c.Enabled = false;
            }

            for (int i = 0; i <= 7; i++)
            {
                gameBoard[6, i].Enabled = true;
            }

            if (turn == true)
            {
                label1.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
            }

            else
            {
                label2.ForeColor = Color.Yellow;
                label4.ForeColor = Color.Yellow;
            }
        }

        private void ChangeColor(CircularButton c)
        {
            if (turn)
            {
                c.BackColor = Color.Red;
                turn = false;
                label1.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label2.ForeColor = Color.Yellow;
                label4.ForeColor = Color.Yellow;
            }
            else
            {
                c.BackColor = Color.Yellow;
                turn = true;
                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label1.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
            }
            r.CheckRows(gameBoard, this);
            r.CheckColumns(gameBoard, this);
            r.CheckDiagonals(gameBoard, this);
            r.CheckTie(gameBoard, this);
            c.Enabled = false;    
        }

        //Makes the buttons change colors when clicked, enables the next column above if not at top
        private void R1C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C1);
        }

        private void R1C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C2);
        }

        private void R1C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C3);
        }

        private void R1C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C4);
        }

        private void R1C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C5);
        }

        private void R1C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C6);
        }

        private void R1C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C7);
        }

        private void R1C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R1C8);
        }

        private void R2C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C1);
            R1C1.Enabled = true;
        }

        private void R2C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C2);
            R1C2.Enabled = true;
        }

        private void R2C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C3);
            R1C3.Enabled = true;
        }

        private void R2C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C4);
            R1C4.Enabled = true;
        }

        private void R2C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C5);
            R1C5.Enabled = true;
        }

        private void R2C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C6);
            R1C6.Enabled = true;
        }

        private void R2C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C7);
            R1C7.Enabled = true;
        }

        private void R2C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R2C8);
            R1C8.Enabled = true;
        }

        private void R3C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C1);
            R2C1.Enabled = true;
        }

        private void R3C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C2);
            R2C2.Enabled = true;
        }

        private void R3C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C3);
            R2C3.Enabled = true;
        }

        private void R3C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C4);
            R2C4.Enabled = true;
        }

        private void R3C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C5);
            R2C5.Enabled = true;
        }

        private void R3C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C6);
            R2C6.Enabled = true;
        }

        private void R3C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C7);
            R2C7.Enabled = true;
        }

        private void R3C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R3C8);
            R2C8.Enabled = true;
        }

        private void R4C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C1);
            R3C1.Enabled = true;
        }

        private void R4C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C2);
            R3C2.Enabled = true;
        }

        private void R4C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C3);
            R3C3.Enabled = true;
        }

        private void R4C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C4);
            R3C4.Enabled = true;
        }

        private void R4C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C5);
            R3C5.Enabled = true;
        }

        private void R4C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C6);
            R3C6.Enabled = true;
        }

        private void R4C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C7);
            R3C7.Enabled = true;
        }

        private void R4C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R4C8);
            R3C8.Enabled = true;
        }

        private void R5C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C1);
            R4C1.Enabled = true;
        }

        private void R5C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C2);
            R4C2.Enabled = true;
        }

        private void R5C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C3);
            R4C3.Enabled = true;
        }

        private void R5C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C4);
            R4C4.Enabled = true;
        }

        private void R5C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C5);
            R4C5.Enabled = true;
        }

        private void R5C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C6);
            R4C6.Enabled = true;
        }

        private void R5C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C7);
            R4C7.Enabled = true;
        }

        private void R5C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R5C8);
            R4C8.Enabled = true;
        }

        private void R6C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C1);
            R5C1.Enabled = true;
        }

        private void R6C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C2);
            R5C2.Enabled = true;
        }

        private void R6C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C3);
            R5C3.Enabled = true;
        }

        private void R6C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C4);
            R5C4.Enabled = true;
        }

        private void R6C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C5);
            R5C5.Enabled = true;
        }

        private void R6C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C6);
            R5C6.Enabled = true;
        }

        private void R6C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C7);
            R5C7.Enabled = true;
        }

        private void R6C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R6C8);
            R5C8.Enabled = true;
        }

        private void R7C1_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C1);
            R6C1.Enabled = true;
        }

        private void R7C2_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C2);
            R6C2.Enabled = true;
        }

        private void R7C3_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C3);
            R6C3.Enabled = true;
        }

        private void R7C4_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C4);
            R6C4.Enabled = true;
        }

        private void R7C5_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C5);
            R6C5.Enabled = true;
        }

        private void R7C6_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C6);
            R6C6.Enabled = true;
        }

        private void R7C7_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C7);
            R6C7.Enabled = true;
        }

        private void R7C8_Click(object sender, EventArgs e)
        {
            ChangeColor(R7C8);
            R6C8.Enabled = true;
        }
    }
}
