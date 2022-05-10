using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchBone
{
    public partial class Form1 : Form
    {

        bool goleft; 
        bool goright;
        int speed = 5;
        int score = 0; 
        int missed = 0;
        Random rndY = new Random(); 
        Random rndX = new Random(); 
        
        public Form1()
        {
            InitializeComponent();
            reset();
           
        }
        private void Image_Load()
        {


        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label1.Text = "Score: " + score; 
            if (goleft == true && pictureBox2.Left > 0)
            {
                pictureBox2.Left -= 12;
                pictureBox2.Image = Properties.Resources.billi1;
            }
            
            if (goright == true && pictureBox2.Left + pictureBox2.Width < this.ClientSize.Width)
            {
                pictureBox2.Left += 12;
                pictureBox2.Image = Properties.Resources.billi1;
            }

            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && X.Tag == "haddi")
                {
                    X.Top += speed;
                   
                    if (X.Top + X.Height > this.ClientSize.Height)
                    {
                        X.Top = rndY.Next(80, 300) * -1; 
                        X.Left = rndX.Next(5, this.ClientSize.Width - X.Width); 
                        missed++;
                    }
                    if (X.Bounds.IntersectsWith(pictureBox2.Bounds))
                    {
                        X.Top = rndY.Next(100, 300) * -1; 
                        X.Left= rndX.Next(5, this.ClientSize.Width - X.Width);
                        score++; 
                    }
                    
                    
                    if (score >= 5)
                    {
                        speed = 16;  
                    }
                    
                    if(missed>3)
                    {
                        speed = 8;
                    }
                    if (missed == 5)
                    {
                        timer1.Stop(); 
                        MessageBox.Show("Total Score: " + score + "\r\n" + "Click OK to restart","Game Over!!");
                        reset();
                    }

                }
            }
        }
        private void reset()
        {
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && X.Tag == "haddi")
                {
                    X.Top = rndY.Next(80, 300) * -1; 
                    X.Left = rndX.Next(5, this.ClientSize.Width - X.Width);
                }
            }

            pictureBox2.Left = this.ClientSize.Width / 2; 
            pictureBox2.Image = Properties.Resources.billi1;

            score = 0; 
            missed = 0;
            speed = 8; 

            goleft = false; 
            goright = false;
            timer1.Start(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
