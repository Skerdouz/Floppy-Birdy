using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floppy_Birdy
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score : " + score.ToString();

            if(pipeBottom.Left < -80)
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -80)
            {
                pipeTop.Left = 910;
                score++;
            }

            if (score >= 5 && score < 15)
            {
                pipeSpeed = 14;
            }
            else
            {
                if (score >= 15 && score < 30)
                {
                    pipeSpeed = 17;
                }
                else
                {
                    if(score > 29)
                    {
                        pipeSpeed = 25;
                    }
                }
            }


            if(bird.Bounds.IntersectsWith(pipeBottom.Bounds) || bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25
               )
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 14;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " - Fin de la partie !";
        }
    }
}
