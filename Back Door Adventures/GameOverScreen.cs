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
        List<string> skz = new List<string>() {"Chan","Minho", "Changbin","Hyunjin","Jisung","Felix","Seungmin","Jeongin"};
        Random random = new Random();
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            int name = random.Next(0, 8);

            for (int i = 0; i < skz.Count(); i++)
            {
                if (name == i)
                {
                    scoreLabel.Text = skz[i];
                }
            }
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
