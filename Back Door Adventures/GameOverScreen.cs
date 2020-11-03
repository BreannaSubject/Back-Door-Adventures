using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Back_Door_Adventures
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            PlayScreen ps = new PlayScreen();
            this.Controls.Add(ps);
            playAgainButton.Visible = false;
            exitButton.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
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
    }
}
