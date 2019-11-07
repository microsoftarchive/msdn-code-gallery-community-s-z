using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace ShipDestroyer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int ShipsDestroyed = 0;
        int Shots = 0;
	// cycle of ship cruises  controlled by Timer2	 
		 private void timer2_Tick(object sender, EventArgs e)
        {
               	 
				explosion.Left -=5;
				ship.Left -=5;

				 // as ship come too close ship movement reset 
            if (explosion.Location.X == 240)
             	 {timer2.Enabled = false;
                 explosion.Location = new Point (680, 42);
 
				 explosion.Visible = false;
				 ship.Visible = true; 
				 ship.Location = new Point(700, 42); 
				 timer2.Enabled = true;
                 }
		 }	 

	
			 // canon set up  
         

         private void button1_Click(object sender, EventArgs e)
        {
        
				 ship.Visible = true;
				 explosion.Visible = false;
				 canonBall.Location = new Point(120, 102);
				 timer1.Enabled = true;
				 Shots = Shots +1;
				 label5.Text =System.Convert.ToString(Shots);
		 }
			 // canon fire controled by Timer 1
	private void timer1_Tick(object sender, EventArgs e)
        {	 
        canonBall.Left +=50;
				
			}

    private void canonBall_LocationChanged(object sender, EventArgs e)
    {

                     if ((canonBall.Location.X == 320 ||
                     canonBall.Location.X == 380 ||
                     canonBall.Location.X == 400 ||
                     canonBall.Location.X == 420 ||
                     canonBall.Location.X == 520) &&
                     (explosion.Location.X ==  320  ||
                     explosion.Location.X ==  325  ||
                     explosion.Location.X ==  330  ||
                     explosion.Location.X ==  420  ||
                     explosion.Location.X ==  425  ||
                     explosion.Location.X ==  520  ||
                     explosion.Location.X ==  525  ||
                     explosion.Location.X ==  530  ||
                     explosion.Location.X ==  650 ))
				 {
				 backgroundWorker1.RunWorkerAsync();
				 timer1.Enabled = false; 
				 timer2.Enabled = false;
                 explosion.Visible = true;
				 ship.Visible = false;
				 timer2.Enabled = true;
				 ShipsDestroyed =  ShipsDestroyed +1;
				 label3.Text =System.Convert.ToString(ShipsDestroyed);
				 }

				 
			 }

        
			 	
//background worker to play sound		 

private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
		SoundPlayer player = new SoundPlayer();
		player.SoundLocation = "c:\\windows\\media\\tada.wav";
			//"c:\\Users\\yegoris\\Desktop\\bomb.waw";
		player.Load();
		player.PlaySync();
		}



        

       
        
        
        
       

       

};
}
    
