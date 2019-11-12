using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
       
        // here we define variables
        int xWins = 0;
        int yWins = 0;
        int d = 0;
        Button[] b = new Button[9];
     
        public Form1()
        {
            InitializeComponent();
        }

       //Here form will be loaded like a program load in to memory
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                b[i] = new Button();
                b[i].Width = 100;
                b[i].Height = 100;
                b[i].Click += new EventHandler(Form1_Click);
                
                flowLayoutPanel1.Controls.Add(b[i]);
            }

        }

        int flag = 0;
        int draw = 0;
        /// <summary>
        /// Reset is function who clear the board.
        /// </summary>
        void reset()
        {
            for (int i = 0; i < 9; i++)
            {
                b[i].Enabled = true;
                b[i].Text = "";
                draw = 0;
            }
        }

        void Form1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (flag == 0)
            {
                bt.Text = "X";
                label10.Text = "O";
                flag = 1;
                
            }
            else
            {
                bt.Text = "O";
                label10.Text = "X";
                flag = 0;
            }
            bt.Enabled = false;

            draw++;

            //call check funtion for conditions
            check();
            if (draw == 9)
            {
                MessageBox.Show("Game Draw");
                d++;
                label6.Text = d.ToString();
                reset();
            }
        }

        void check() // Here is the check() function in which conditions will full fill.
        {
            //FOr Rows
            if (b[0].Text == b[1].Text && b[1].Text == b[2].Text && b[0].Text!="")
            {
                MessageBox.Show(b[0].Text + " Wins");
                if (b[0].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }

                reset();
            }
            if (b[3].Text == b[4].Text && b[4].Text == b[5].Text && b[3].Text != "")
            {
                MessageBox.Show(b[3].Text + " Wins");
                if (b[3].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
            if (b[6].Text == b[7].Text && b[7].Text == b[8].Text && b[6].Text != "")
            {
                MessageBox.Show(b[6].Text + " Wins");
                if (b[6].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
            
            //For Coloums
            if (b[0].Text == b[3].Text && b[3].Text == b[6].Text && b[0].Text != "")
            {
                MessageBox.Show(b[0].Text + " Wins");
                if (b[0].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
            if (b[1].Text == b[4].Text && b[4].Text == b[7].Text && b[1].Text != "")
            {
                MessageBox.Show(b[1].Text + " Wins");
                if (b[1].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
            if (b[2].Text == b[5].Text && b[5].Text == b[8].Text && b[2].Text != "")
            {
                MessageBox.Show(b[2].Text + " Wins");
                if (b[2].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
        
            //For Diagnols
            if (b[0].Text == b[4].Text && b[4].Text == b[8].Text && b[0].Text != "")
            {
                MessageBox.Show(b[0].Text + " Wins");
                if (b[0].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
            if (b[2].Text == b[4].Text && b[4].Text == b[6].Text && b[2].Text != "")
            {
                MessageBox.Show(b[2].Text + " Wins");
                if (b[2].Text == "X")
                {
                    xWins++;
                    label3.Text = xWins.ToString();
                }
                else
                {
                    yWins++;
                    label4.Text = yWins.ToString();
                }
                reset();
            }
        }

 
        
    }

}
