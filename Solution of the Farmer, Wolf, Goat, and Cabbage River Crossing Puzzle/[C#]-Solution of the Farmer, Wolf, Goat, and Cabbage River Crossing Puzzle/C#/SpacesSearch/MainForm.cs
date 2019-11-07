using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpacesSearch
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Work(1);
            textBox1.Text += "\r\n";
            Work(2);
            textBox1.Text += "\r\n";
            Work(3);
        }

        private void Work(int i)
        {
            FarmerWolfGoatCabbageState fwgc = new FarmerWolfGoatCabbageState();
            LinkedList<State> moves = null;

            if (i == 1)
            {
                DepthFirstSolver solver = new DepthFirstSolver();
                moves = solver.Solve(fwgc);
                textBox1.Text += "Depth First Solution\r\n";
            }

            else if (i == 2)
            {
                BreadthFirstSolver solver = new BreadthFirstSolver();
                moves = solver.Solve(fwgc);
                textBox1.Text += "Breadth First Solution\r\n";
            }

            else if (i == 3)
            {
                BestFirstSolver solver = new BestFirstSolver();
                moves = solver.Solve(fwgc);
                textBox1.Text += "Best First Solution\r\n";
            }

            int number = 1;

            foreach (State s in moves)
            {
                FarmerWolfGoatCabbageState ns = (FarmerWolfGoatCabbageState)s;

                textBox1.Text += number.ToString("D2") + " ";

                if (ns.IsSolution())
                    textBox1.Text += "S ";
                else
                    textBox1.Text += "N ";

                textBox1.Text += ns.ToString();
                number++;
            }
        }   
    }
}