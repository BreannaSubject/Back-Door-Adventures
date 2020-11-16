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


            for (int i = 0; i < Form1.names.Count(); i++)
            {
                outputLabel.Text += i + "  " + Form1.names[i] + "   " + Form1.scores[i] + "\n";
            }
            
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            returnButton.Visible = false;
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
            outputLabel.Visible = false;
        }

        private void returnButton_Enter(object sender, EventArgs e)
        {
            returnButton.BackgroundImage = Properties.Resources.Button_Background_Inverted;
        }

       
    }
}
