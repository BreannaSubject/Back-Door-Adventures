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
        public static bool win, hardLevel, mediumLevel, easyLevel; //booleans for scoring
        public static bool oneLife = false; 
        public static int heroStart = 50; //starting position of the hero
        public static int keySize = 32; //the size of the key
        public static int lives = 3;//life counter

        //time for scoring
        public static DateTime startTime; 
        public static DateTime stopTime;

        // highscores list 
        public static List<Score> highscores = new List<Score>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //reads the XML file and puts all the scores in the list
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

            //takes you to the menu screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
        }
    }
}
