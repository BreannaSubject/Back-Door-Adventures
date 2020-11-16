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
    public partial class HardLevel : UserControl
    {
        
        Rectangle key;

        // oni lists and variables
        List<Oni> oni = new List<Oni>();
        List<int> speeds = new List<int>();
        List<int> directions = new List<int>();
        List<int> lastdirections = new List<int>();
        int oniSize = 50;

        //hero variables
        Hero chan;
        int heroSpeed = 4;
        int heroSize = 36;

        Random random = new Random();
        int tick, speed, direction;

        //images for the inversion
        Image invertOni = Properties.Resources.Inverted_Oni;
        Image invertHealthBar = Properties.Resources.Health_Bar_Full_Green_Inverted;
        Image invertScreen = Properties.Resources.Back_Door_Screen_Inverted;
        Image normalOni = Properties.Resources.Oni;
        Image healthBar = Properties.Resources.Health_Bar_Full_Green;
        Image normalScreen = Properties.Resources.Back_Door_Screen;
        Image oniImage = Properties.Resources.Oni;
        string image = "nonInvert";
        public HardLevel()
        {
            InitializeComponent();
        }

        private void HardLevel_Load(object sender, EventArgs e)
        {
            Form1.leftArrowDown = false;
            Form1.rightArrowDown = false;
            Form1.upArrowDown = false;
            Form1.downArrowDown = false;
            Form1.oneLife = true;

           chan = new Hero(Form1.heroStart, this.Height / 2, heroSpeed, heroSpeed, heroSize, "right");
            key = new Rectangle(this.Width - heroSize, this.Height / 2, Form1.keySize, Form1.keySize);

            //randomly choses the x and y of each Oni and loads them
            int x1, x2, x3, x4, x5, y1, y2, y3, y4, y5;
            x1 = random.Next(130, 551);
            x2 = random.Next(130, 551);
            x3 = random.Next(130, 551);
            x4 = random.Next(130, 551);
            x5 = random.Next(130, 551);
            y1 = random.Next(50, 351);
            y2 = random.Next(50, 351);
            y3 = random.Next(50, 351);
            y4 = random.Next(50, 351);
            y5 = random.Next(50, 351);

            Oni oni1 = new Oni(x1, y1, oniSize);
            Oni oni2 = new Oni(x2, y2, oniSize);
            Oni oni3 = new Oni(x3, y3, oniSize);
            Oni oni4 = new Oni(x4, y4, oniSize);
            Oni oni5 = new Oni(x5, y5, oniSize);

            oni.Add(oni1);
            oni.Add(oni2);
            oni.Add(oni3);
            oni.Add(oni4);
            oni.Add(oni5);

            for (int i = 0; i < oni.Count(); i++)
            {
                //randomizes the speed and direction
                speed = random.Next(1, 9);
                direction = random.Next(1, 4);
                speeds.Add(speed);
                directions.Add(direction);
                lastdirections.Add(direction);
            }

        }

        private void HardLevel_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Form1.leftArrowDown = false;
                    break;
                case Keys.Right:
                    Form1.rightArrowDown = false;
                    break;
                case Keys.Up:
                    Form1.upArrowDown = false;
                    break;
                case Keys.Down:
                    Form1.downArrowDown = false;
                    break;

            }
        }

        private void HardLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Form1.leftArrowDown = true;
                    break;
                case Keys.Right:
                    Form1.rightArrowDown = true;
                    break;
                case Keys.Up:
                    Form1.upArrowDown = true;
                    break;
                case Keys.Down:
                    Form1.downArrowDown = true;
                    break;
            }
        }

        private void gameTimerLoop_Tick(object sender, EventArgs e)
        {
            tick++;
            Form form = this.FindForm();
            Rectangle chanRec = new Rectangle(chan.x, chan.y, chan.size, chan.size);

            if (tick % 50 == 0)
            {
                //changes the speed and direction of the Onis every 50 ticks
                speeds.Clear();
                directions.Clear();

                for (int i =0; i < oni.Count(); i++)
                {
                        speed = random.Next(1, 9);
                        direction = random.Next(1, 5);
                        speeds.Add(speed);
                        directions.Add(direction);

                        if (directions[i] == lastdirections[i])
                        {
                            direction = random.Next(1, 4);
                        }
                        else
                        {

                        }
                }

                lastdirections.Clear();

                for (int i = 0; i < oni.Count(); i++)
                {
                    lastdirections.Add(directions[i]);
                }
                
            }

            if (tick == 100)
            {
                //inverts all the elements on the screen except the hero
                if (image == "nonInvert")
                {
                    this.BackgroundImage = invertScreen;
                    healthBox.BackgroundImage = invertHealthBar;
                    oniImage = invertOni;
                    image = "invert";

                }
                else if (image == "invert")
                {
                    this.BackgroundImage = normalScreen;
                    healthBox.BackgroundImage = healthBar;
                    oniImage = normalOni;
                    image = "nonInvert";
                }

                tick = 0;
            }

            if (oni.Count() > 0)
            {//moves the onis
                for (int i = 0; i < oni.Count(); i++)
                {
                    oni[i].Move(speeds[i], directions[i], form);
                }
            }
            
            foreach (Oni o in oni)
            {//checks to see if the onis have intersected with the hero
                Rectangle oniRec = new Rectangle(o.x, o.y, o.size, o.size);

                if (chanRec.IntersectsWith(oniRec))
                {
                    //exits the level and goes to the game over screen
                    Form1.lives = 0;
                    Form1.win = false;
                    gameTimerLoop.Enabled = false;
                    healthBox.Visible = false;
                    GameOverScreen go = new GameOverScreen();
                    this.Controls.Add(go);

                }
            }
            //moving the character

            if (Form1.leftArrowDown == true && chan.x < this.Width - chan.size)
            {
                chan.Move("left");
                chan.direction = "left";
            }
            else if (Form1.rightArrowDown == true && chan.x > 0)
            {
                chan.Move("right");
                chan.direction = "right";
            }
            else if (Form1.downArrowDown == true && chan.y < this.Height - chan.size * 2)
            {
                chan.Move("down");
                chan.direction = "down";
            }
            else if (Form1.upArrowDown == true && chan.y > 0)
            {
                chan.Move("up");
                chan.direction = "up";
            }

            if (chanRec.IntersectsWith(key))
            {
                //exits the level and goes to the game over screen
                Form1.stopTime = DateTime.Now;
                Form1.win = true;
                Form1.hardLevel = true;
                gameTimerLoop.Enabled = false;
                healthBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }

            Refresh();
        }

        private void HardLevel_Paint(object sender, PaintEventArgs e)
        {
            //draws everthing to the screen
            e.Graphics.DrawImage(Properties.Resources.Clé, key);

            if (chan.direction == "right")
            {
                e.Graphics.DrawImage(Properties.Resources.Chan_Right, chan.x, chan.y, chan.size, chan.size);
            }
            else if (chan.direction == "left")
            {
                e.Graphics.DrawImage(Properties.Resources.Chan_Left, chan.x, chan.y, chan.size, chan.size);
            }
            else if (chan.direction == "up")
            {
                e.Graphics.DrawImage(Properties.Resources.Chan_Back, chan.x, chan.y, chan.size, chan.size);
            }
            else if (chan.direction == "down")
            {
                e.Graphics.DrawImage(Properties.Resources.Chan_Forward, chan.x, chan.y, chan.size, chan.size);
            }

            foreach (Oni o in oni) 
            {
                e.Graphics.DrawImage(oniImage, o.x, o.y, o.size, o.size);
            }
        }

       


       
    }
}
