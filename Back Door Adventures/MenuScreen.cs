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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            
        } 
        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            controlButton.Visible = false;
            highScoreButton.Visible = false;
            exitButton.Visible = false;
            PlayScreen ps = new PlayScreen();
            this.Controls.Add(ps);
        }

        private void controlButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            controlButton.Visible = false;
            highScoreButton.Visible = false;
            exitButton.Visible = false;
            ControlsScreen cs = new ControlsScreen();
            this.Controls.Add(cs);
        }

        private void highScoreButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            controlButton.Visible = false;
            highScoreButton.Visible = false;
            exitButton.Visible = false;
            HighScoreScreen hs = new HighScoreScreen();
            this.Controls.Add(hs);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
            controlButton.BackgroundImage = Properties.Resources.Button_Background;
            highScoreButton.BackgroundImage = Properties.Resources.Button_Background;
            exitButton.BackgroundImage = Properties.Resources.Button_Background;
        }

        private void controlButton_Enter(object sender, EventArgs e)
        {
            playButton.BackgroundImage = Properties.Resources.Button_Background;
            controlButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
            highScoreButton.BackgroundImage = Properties.Resources.Button_Background;
            exitButton.BackgroundImage = Properties.Resources.Button_Background;
        }

        private void highScoreButton_Enter(object sender, EventArgs e)
        {
            playButton.BackgroundImage = Properties.Resources.Button_Background;
            controlButton.BackgroundImage = Properties.Resources.Button_Background;
            highScoreButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
            exitButton.BackgroundImage = Properties.Resources.Button_Background;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            playButton.BackgroundImage = Properties.Resources.Button_Background;
            controlButton.BackgroundImage = Properties.Resources.Button_Background;
            highScoreButton.BackgroundImage = Properties.Resources.Button_Background;
            exitButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
        }

        
    }
}
