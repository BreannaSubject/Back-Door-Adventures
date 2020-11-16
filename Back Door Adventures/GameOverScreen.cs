using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace Back_Door_Adventures
{
    public partial class GameOverScreen : UserControl
    {
        List<string> skz = new List<string>() {"Chan","Minho", "Changbin","Hyunjin","Jisung","Felix","Seungmin","Jeongin"};
        Random random = new Random();
        int score = 0;
        string highScoreName;
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            Form1.oneLife = false;
            int time = (Form1.stopTime - Form1.startTime).Milliseconds;

            if (Form1.win == true)
            {
                score += 500;
                if (time > 30000)
                {
                    score += 250;
                }
                else if (time < 30000 && time > 15000)
                {
                    score += 500;
                }
                else
                {
                    score += 1000;
                }
            }

            if (Form1.lives == 3)
            {
                score += 400;
            }
            else if (Form1.lives == 2)
            {
                score += 300;
            }
            else if (Form1.lives == 1)
            {
                score += 200;
            }
            else
            {
                score += 100;
            }

            if (Form1.easyLevel == true)
            {
                score += 100;
            }
            else if (Form1.mediumLevel == true)
            {
                score += 200;
            }
            else if (Form1.hardLevel == true)
            {
                score += 300;
            }

            

            int name = random.Next(0, 8);
            int number = random.Next(1, 100);

            for (int i = 0; i < skz.Count(); i++)
            {
                if (name == i)
                {
                    highScoreName = skz[i] + number;
                    Form1.names.Add(highScoreName);
                    Form1.scores.Add(score);
                    scoreLabel.Text = skz[i] + number + " : " + score;
                }
            }


        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //Form f = FindForm();
            Form1.lives = 3;
            score = 0;
            PlayScreen ps = new PlayScreen();
            this.Controls.Add(ps);
            this.Controls.Remove(this);
            playAgainButton.Visible = false;
            exitButton.Visible = false;
            scoreLabel.Visible = false;
            yourScoreLabel.Visible = false;

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Write();
            score = 0;
            Application.Exit();
        }

        private void playAgainButton_Enter(object sender, EventArgs e)
        {
            playAgainButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
            exitButton.BackgroundImage = Properties.Resources.Button_Background;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            playAgainButton.BackgroundImage = Properties.Resources.Button_Background;
            exitButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
        }

        public void Write()
        {
            
            XmlWriter writer = XmlWriter.Create("HighScore.xml", null);

            writer.WriteStartElement("highscores");

            for (int i = 0; i < Form1.scores.Count(); i++)
            {
                writer.WriteStartElement("highscore");

                writer.WriteElementString("name", Form1.names[i]);
                writer.WriteElementString("score", Convert.ToString(Form1.scores[i]));

                writer.WriteEndElement();

            }

            writer.WriteEndElement();

            writer.Close();
        }

        
    }
}
