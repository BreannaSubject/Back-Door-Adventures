using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;

namespace Back_Door_Adventures
{
    public partial class Form1 : Form
    {
        public static bool leftArrowDown, rightArrowDown, upArrowDown, downArrowDown; //booleans for Arrow Keys
        public static bool win, hardLevel, mediumLevel, easyLevel;
        public static bool oneLife = false;
        public static int heroStart = 50;
        public static int keySize = 32;
        public static int lives = 3;
        public static DateTime startTime;
        public static DateTime stopTime;
        public static List<Score> highscores = new List<Score>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("HighScore.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    string name = reader.ReadString();

                    reader.ReadToNextSibling("score");
                    int score = Convert.ToInt32(reader.ReadString());

                    Score score1 = new Score(score, name);
                    highscores.Add(score1);


                }
            }

            reader.Close();
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
        }
    }
}
