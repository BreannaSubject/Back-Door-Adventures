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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
        }
    }
}
