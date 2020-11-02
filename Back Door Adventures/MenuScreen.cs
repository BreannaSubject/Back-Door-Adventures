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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
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

        }

        private void highScoreButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
