using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe_cs
{
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grid1.newGame();
        }
    }
}
