using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelRace_0._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private Skeleton[] Skeletons = new Skeleton[3];
        private Random random = new Random();
        Betters[] betters = new Betters[3];

        public void Start()
        {
            int Start = racer1.Right - panel1.Left;
            int raceTrackLenght = panel1.Size.Width-68;


            Skeletons[0] = new Skeleton() { MyPictureBox = racer1, RacetrackLength = raceTrackLenght, StartingPosition = Start };
            Skeletons[1] = new Skeleton() { MyPictureBox = racer2, RacetrackLength = raceTrackLenght, StartingPosition = Start };
            Skeletons[2] = new Skeleton() { MyPictureBox = racer3, RacetrackLength = raceTrackLenght, StartingPosition = Start };

            betters[0] = new Betters("Emre", null, 400, emreButton, emreBet);
            betters[1] = new Betters("Joe", null, 400, JoeButton, JoeBet);
            betters[2] = new Betters("Bob", null, 400, BobButton, BobBet);

            foreach (Betters bettor in betters)
            {
                bettor.UpdateLabels();
            }


            
        }

        private void SetBettorNameTextLabel(string Name)
        {
            BettorName.Text = Name;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BettorName.ForeColor = Color.Blue;
            SetBettorNameTextLabel("Emre");
        }
        private void JoeButton_CheckedChanged(object sender, EventArgs e)
        {
            BettorName.ForeColor = Color.DarkMagenta;
            SetBettorNameTextLabel("Joe");
        }

        private void BobButton_CheckedChanged(object sender, EventArgs e)
        {
            BettorName.ForeColor = Color.Green;
            SetBettorNameTextLabel("Bob");
        }

        private void button2_Click(object sender, EventArgs e) // Bet butonu
        {
            int GuyNumber = 0;

            if (emreButton.Checked)
            {
                GuyNumber = 0;
            }
            if (JoeButton.Checked)
            {
                GuyNumber = 1;
            }
            if (BobButton.Checked)
            {
                GuyNumber = 2;
            }

            betters[GuyNumber].PlaceBet((int)BetAmount.Value, (int)RacerNumber.Value); //Numerik tooldan gelen değeri ve radio buttondan kimin bahis yaptığını alır.
            betters[GuyNumber].UpdateLabels();
        }

        private void button1_Click(object sender, EventArgs e) //Race butonu
        {
            bool Winner = true;
            int winningSkeleton;
            race.Enabled = false;
            resetButton.Enabled = false;
            betButton.Enabled = false;

            while (Winner)
            {
                if (Skeletons[0].LiveRacer() > Skeletons[1].LiveRacer() && Skeletons[0].LiveRacer() > Skeletons[2].LiveRacer()) //Canlı yarış
                    label2.Text = " Skeleton #1 takes the race ahead";

                if (Skeletons[1].LiveRacer() > Skeletons[0].LiveRacer() && Skeletons[1].LiveRacer() > Skeletons[2].LiveRacer())
                    label2.Text = " Skeleton #2 now is the leader";

                if (Skeletons[2].LiveRacer() > Skeletons[0].LiveRacer() && Skeletons[2].LiveRacer() > Skeletons[1].LiveRacer())
                    label2.Text = " Skeleton #3 takes the lead";

                Application.DoEvents();
                for (int i = 0; i < Skeletons.Length; i++)
                {
                    Skeletons[random.Next(0, 3)].Run();
                    if (Skeletons[i].Run())
                    {
                        winningSkeleton = i + 1;
                        Winner = false;
                        if (winningSkeleton == 1)
                        {
                            label7.Text = ("Racer #" + winningSkeleton.ToString() + " is the ");
                            label6.Visible = true;
                            label7.Visible = true;
                            groupBox4.Visible = true;
                        }
                        else if (winningSkeleton == 2)
                        {
                            label7.Text = ("Racer #" + winningSkeleton.ToString() + " is the ");
                            label6.Visible = true;
                            label7.Visible = true;
                            groupBox4.Visible = true;
                        }
                        else if (winningSkeleton == 3)
                        {
                            label7.Text = ("Racer #" + winningSkeleton.ToString() + " is the ");
                            label6.Visible = true;
                            label7.Visible = true;
                            groupBox4.Visible = true;
                        }                      
                        foreach (Betters bettor in betters)
                        {
                            if (bettor.MyBet != null)
                            {
                                bettor.Collect(winningSkeleton);
                                bettor.MyBet = null;
                                bettor.UpdateLabels();
                            }
                        }
                        break;
                    }
                }
            }
            resetButton.Enabled = true;
        }

        private void ınformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("There are 3 Racer Skeletons, 3 Betters(Emre,Joe and Bob) and Bet system. Choose your bettor and racer, bet and start Race button!" +
                "\nYou can see your cash on the Bets Group.\nGood Luck! ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void BettorName_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click_1(object sender, EventArgs e) //Reset butonu
        {
            foreach (Skeleton skeleton in Skeletons)
            {
                skeleton.TakeStartingPosition(); //Konumu resetler
                race.Enabled = true;
                betButton.Enabled = true;
                label2.Text = "Click Race and Watch Live Race!";
            }
            
        }
    }
}
