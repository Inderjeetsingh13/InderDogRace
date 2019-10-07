using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InderDogRace
{
    public partial class RaceCoat : Form
    {
        int inderAmunt = 90, rahulAmunt = 100, naguAmunt = 110;

        int err = 0;

        frstMove frstcls = new frstMove();
        scndMove scndcls = new scndMove();
        thrdMove thrdcls = new thrdMove();
        frthMove frthcls = new frthMove();


        public RaceCoat()
        {
            InitializeComponent();
            race.Visible = false;

        }

        public bool IsNumeric(String input)
        {
            return Regex.IsMatch(input, "[^0-9]");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (Inder.Checked == true)
                {
                    Rahul.Checked = false;
                    Nagu.Checked = false;
                    if (Convert.ToInt32(txtDog.Text.ToString()) > 0 && Convert.ToInt32(txtDog.Text.ToString()) <= 4 && !txtDog.Text.ToString().Equals(""))
                    {
                        if (Convert.ToInt32(txtBet.Text.ToString()) > 0 && Convert.ToInt32(txtBet.Text.ToString()) <= inderAmunt && !txtBet.Text.ToString().Equals(""))
                        {

                            frst.Text = "Inder set the bet at " + txtDog.Text + " of $" + txtBet.Text;
                            cbDetails.Items.Add("1-" + txtBet.Text + "-" + txtDog.Text);

                            race.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Bet Amount must be Less or equal to the amount in the bet ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dogs are only 1 to 4 so choose any one from them ");
                    }

                }

                else if (Rahul.Checked == true)
                {
                    Inder.Checked = false;
                    Nagu.Checked = false;
                    if (Convert.ToInt32(txtDog.Text.ToString()) > 0 && Convert.ToInt32(txtDog.Text.ToString()) <= 4 && !txtDog.Text.ToString().Equals(""))
                    {
                        if (Convert.ToInt32(txtBet.Text.ToString()) > 0 && Convert.ToInt32(txtBet.Text.ToString()) <= rahulAmunt && !txtBet.Text.ToString().Equals(""))
                        {
                            scnd.Text = "Rahul set the bet at " + txtDog.Text + " of $" + txtBet.Text;
                            cbDetails.Items.Add("2-" + txtBet.Text + "-" + txtDog.Text);
                            race.Visible = true;

                        }
                    else
                        {
                            MessageBox.Show("Bet Amount must be Less or equal to the amount in the bet ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dogs are only 1 to 4 so choose any one from them ");
                    }

                }

                else if (Nagu.Checked == true)
                {
                    Inder.Checked = false;
                    Rahul.Checked = false;
                    if (Convert.ToInt32(txtDog.Text.ToString()) > 0 && Convert.ToInt32(txtDog.Text.ToString()) <= 4 && !txtDog.Text.ToString().Equals(""))
                    {
                        if (Convert.ToInt32(txtBet.Text.ToString()) > 0 && Convert.ToInt32(txtBet.Text.ToString()) <= naguAmunt && !txtBet.Text.ToString().Equals(""))
                        {
                            thrd.Text = "Nagu set the bet at " + txtDog.Text + " of $" + txtBet.Text;
                            cbDetails.Items.Add("3-" + txtBet.Text + "-" + txtDog.Text);

                            race.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Bet Amount must be Less or equal to the amount in the bet ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dogs are only 1 to 4 so choose any one from them ");
                    }

                }
                else {
                        
                }
                if (txtBet.Text == "" || txtDog.Text == "") {
                    MessageBox.Show("Follow all the instruction ");
                }

            }
            catch (Exception ex) {
                MessageBox.Show("follow the instructions to play the game ");
            }



        }

        private void Inder_CheckedChanged(object sender, EventArgs e)
        {
            if (Inder.Checked == true) {
                Rahul.Checked = false;
                Nagu.Checked = false;
            }


        }

        private void Rahul_CheckedChanged(object sender, EventArgs e)
        {
            if (Rahul.Checked == true)
            {
                Inder.Checked = false;
                Nagu.Checked = false;
            }
        }

        private void Nagu_CheckedChanged(object sender, EventArgs e)
        {
            if (Nagu.Checked == true)
            {
                Rahul.Checked = false;
                Inder.Checked = false;
            }
        }

        private void race_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (frstDog.Left < 700)
            {
                frstDog.Left += frstcls.move();
            }
            else {
                timer1.Stop();
                winner(1);

            }

            if (scndDog.Left < 700)
            {
                scndDog.Left += frstcls.move();
            }
            else
            {
                timer1.Stop();
                winner(2);
            }

            if (thrdDog.Left < 700)
            {
                thrdDog.Left += frstcls.move();
            }
            else
            {
                timer1.Stop();
                winner(3);
            }
            if (frthDog.Left < 700)
            {
                frthDog.Left += frstcls.move();
            }
            else
            {
                timer1.Stop();
                winner(4);
            }

        }

        public void winner(int win) {
            MessageBox.Show("Dog No ==" + win + " is the winner ");
            int y = 0,z=0;
            for (y=0; y<cbDetails.Items.Count;y++) {
                String[] details = cbDetails.Items[y].ToString().Split('-');
                
                    if (details[0]=="1" && Convert.ToInt32(details[2])==win) {
                        inderAmunt += Convert.ToInt32(details[1]);
                        Inder.Text = "Inder has $"+inderAmunt +" in his Account";
                    }
                    if (details[0] == "1" && Convert.ToInt32(details[2]) != win)
                    {
                    inderAmunt -= Convert.ToInt32(details[1]);
                    Inder.Text = "Inder has $" + inderAmunt + " in his Account";
                }
                if (details[0] == "2" && Convert.ToInt32(details[2]) == win)
                {
                    rahulAmunt += Convert.ToInt32(details[1]);
                    Rahul.Text= "Rahul has $" + rahulAmunt + " in his Account";

                }
                if (details[0] == "2" && Convert.ToInt32(details[2]) != win)
                {
                    rahulAmunt -= Convert.ToInt32(details[1]);
                    Rahul.Text = "Rahul has $" + rahulAmunt + " in his Account";

                }

                if (details[0] == "3" && Convert.ToInt32(details[2]) == win)
                {
                    naguAmunt += Convert.ToInt32(details[1]);
                    Nagu.Text ="Nagu has $" + naguAmunt + " in his Account";
                }
                if (details[0] == "3" && Convert.ToInt32(details[2]) != win)
                {
                    naguAmunt -= Convert.ToInt32(details[1]);
                    Nagu.Text = "Nagu has $" + naguAmunt + " in his Account";
                }
            }
            //this code is used to remove all the details from the combo box
            cbDetails.Items.Clear();
            frst.Text = "Player1";
            scnd.Text = "Player2";
            thrd.Text = "player3";
            set.Enabled = true;
            race.Visible = false;
            txtBet.Text = "";
            txtDog.Text = "";
            frstDog.Left = 0;
            scndDog.Left = 0;
            thrdDog.Left = 0;
            frthDog.Left = 0;
            Inder.Checked = false;
            Rahul.Checked = false;
            Nagu.Checked = false;

            MessageBox.Show("Your game is Finished Now ");
        }


        private void txtDog_KeyPress(object sender, KeyPressEventArgs e)
        {
            //the keypressed event is used to check the givent string is accurate or not if the given no is not accurate then the error message  will display 
            if (IsNumeric(txtDog.Text.ToString()))
            {
                errorProvider1.SetError(txtDog, "Enter only Numeric Values");
                
            }
            else
            {
                errorProvider1.Clear();
                
            }
        }

        private void txtBet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsNumeric(txtBet.Text.ToString()))
            {
                errorProvider1.SetError(txtBet, "Enter only Numeric Values");
                
            }
            else
            {
                set.Enabled = true;

                errorProvider1.Clear();
            }

        }
    }
}
