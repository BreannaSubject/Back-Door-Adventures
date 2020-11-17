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

namespace Back_Door_Adventures
{
    public partial class HighScoreScreen : UserControl
    {
        public HighScoreScreen()
        {
            InitializeComponent();
        }
        private void HighScoreScreen_Load(object sender, EventArgs e)
        {
            foreach (Score s in Form1.highscores)
            {
                Form1.highscores = Form1.highscores.OrderByDescending(x => x.score).ToList();
                //Sorting highscores
            }
            

            outputLabel2.Text = ""; // making sure the label is clear

            for (int i = 0; i < 10; i++)
            {
                outputLabel2.Text += Convert.ToString(i+1) + "  " + Form1.highscores[i].name + "   " + Form1.highscores[i].score + "\n";
                // printing to the label
            }
            
        }

        private void returnButton_Click(object sender, EventArgs e)
        {   
            // returns to the menu screen
            outputLabel2.Text = "";
            returnButton.Visible = false;
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
            outputLabel2.Visible = false;
        }

        private void returnButton_Enter(object sender, EventArgs e)
        {
            //changes the button background when over it
            returnButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
        }

       
    }
}
