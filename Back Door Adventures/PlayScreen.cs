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
    public partial class PlayScreen : UserControl
    {
        public PlayScreen()
        {
            InitializeComponent();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {

        }

        private void mediumButton_Click(object sender, EventArgs e)
        {

        }

        private void hardButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void easyButton_Enter(object sender, EventArgs e)
        {
            easyButton.BackgroundImage = Properties.Resources.God_s_Menu_Door;
            mediumButton.BackgroundImage = Properties.Resources.Back_Door;
            hardButton.BackgroundImage = Properties.Resources.Back_Door;
            exitButton.BackgroundImage = Properties.Resources.Back_Door;
        }

        private void mediumButton_Enter(object sender, EventArgs e)
        {
            easyButton.BackgroundImage = Properties.Resources.Back_Door;
            mediumButton.BackgroundImage = Properties.Resources.Easy_Door;
            hardButton.BackgroundImage = Properties.Resources.Back_Door;
            exitButton.BackgroundImage = Properties.Resources.Back_Door;
        }

        private void hardButton_Enter(object sender, EventArgs e)
        {
            easyButton.BackgroundImage = Properties.Resources.Back_Door;
            mediumButton.BackgroundImage = Properties.Resources.Back_Door;
            hardButton.BackgroundImage = Properties.Resources.Back_Door_Door;
            exitButton.BackgroundImage = Properties.Resources.Back_Door;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            easyButton.BackgroundImage = Properties.Resources.Back_Door;
            mediumButton.BackgroundImage = Properties.Resources.Back_Door;
            hardButton.BackgroundImage = Properties.Resources.Back_Door;
            exitButton.BackgroundImage = Properties.Resources.Exit_Door;
        }
    }
}
