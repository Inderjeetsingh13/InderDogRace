using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InderDogRace
{
    public partial class Form1 : Form
    {
        int ct = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //the event of the timer that is used to increase the counting of the tick so the no of counter wil increase 
        //so thus the progress bar can be filled when the progressbar is filled then the next page will be display 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ct < 100)
            {
               // label2.Text = "" + ct;
                ct = ct + 10;
                progressBar1.Value = ct;
            }
            else {
                timer1.Stop();
                //code to move to the next page of the race 
                RaceCoat frm = new RaceCoat();
                frm.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
