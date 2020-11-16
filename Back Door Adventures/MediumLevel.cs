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
    public partial class MediumLevel : UserControl
    {
        Hero hyunjin; 
        Rectangle key;

        //hero variables
        int heroSpeed = 4;
        int heroSize = 36;
        int skullSpeed = 6;
        int skullSize = 32;

        int tick = 0; //tick for event timers
        bool skullDirection; 
        Random random = new Random();
        List<Skull> downSkulls = new List<Skull>();
        List<Skull> leftSkulls = new List<Skull>();
        List<Rectangle> explosions = new List<Rectangle>();
        Image blueLight = Properties.Resources.Blue_Easy_Light;
        Image greenLight = Properties.Resources.Green_Easy_Light;
        public MediumLevel()
        {
            InitializeComponent();
        }

        private void MediumLevel_Load(object sender, EventArgs e)
        {
            //initializes variables and creates a rectangle for the key and a hero
            lightBox.BackgroundImage = blueLight;

            Form1.leftArrowDown = false;
            Form1.rightArrowDown = false;
            Form1.upArrowDown = false;
            Form1.downArrowDown = false;

            hyunjin = new Hero(Form1.heroStart, this.Height / 2, heroSpeed, heroSpeed, heroSize, "right");
            key = new Rectangle(this.Width - heroSize, this.Height / 2, Form1.keySize, Form1.keySize);

            //reads the XML file for the starting positions of the skulls
            XmlReader reader = XmlReader.Create("MediumLevel.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    int x = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    int y = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("direction");
                    string direction = reader.ReadString();

                    if (direction == "down")
                    {
                        skullDirection = false;
                        Skull skull = new Skull(skullDirection, x, y, skullSpeed, skullSize);
                        downSkulls.Add(skull);
                    }
                    else
                    {
                        skullDirection = true;
                        Skull skull = new Skull(skullDirection, x, y, skullSpeed, skullSize);
                        leftSkulls.Add(skull);
                    }
                }
            }
            reader.Close();

            Form1.startTime = DateTime.Now; //captures the start time
        }

        public void MakeDownSkulls()
        {
            // creates skulls that go down the screen
            skullDirection = false;
            int x1 = random.Next(50, 280);
            int x2 = random.Next(314, 629);
            int y = 45;
            Skull skull1 = new Skull(skullDirection, x1, y, skullSpeed, skullSize);
            Skull skull2 = new Skull(skullDirection, x2, y, skullSpeed, skullSize);
            downSkulls.Add(skull1);
            downSkulls.Add(skull2);

        }

        public void MakeLeftSkulls()
        {
            // creates skulls that go to the left
            skullDirection = true;
            int x = 650;
            int y1 = random.Next(45, 200);
            int y2 = random.Next(250,355);
            int yValue = random.Next(1, 3);
            Skull skull1 = new Skull(skullDirection, x, y1, skullSpeed, skullSize);
            Skull skull2 = new Skull(skullDirection, x, y2, skullSpeed, skullSize);

            leftSkulls.Add(skull1);
            leftSkulls.Add(skull2);
        }

        public void SkullIntersection()
        {
            // creates an explosion if two skulls intersect and changes the light colour
            if (leftSkulls.Count() >= 1 && downSkulls.Count() >= 1)
            {
                for (int i1 = 0; i1 < leftSkulls.Count; i1++)
                {
                    Skull ls = leftSkulls[i1];
                    Rectangle lSRec = new Rectangle(ls.x, ls.y, ls.size, ls.size);

                    for (int i = 0; i < downSkulls.Count; i++)
                    {
                        Skull ds = downSkulls[i];
                        Rectangle dSRec = new Rectangle(ds.x, ds.y, ds.size, ds.size);

                        if (dSRec.IntersectsWith(lSRec))
                        {
                            if (lightBox.BackgroundImage == blueLight)
                            {
                                lightBox.BackgroundImage = greenLight;
                            }
                            else if (lightBox.BackgroundImage == greenLight)
                            {
                                lightBox.BackgroundImage = blueLight;
                            }

                            Rectangle explosion = new Rectangle(ls.x, ds.y, skullSize, skullSize);
                            for (int i2 = 0; i2 < explosions.Count(); i2++)
                            {
                                if (explosion.IntersectsWith(explosions[i2]))
                                {
                                    explosions.RemoveAt(i2);
                                }
                            }
                            explosions.Add(explosion);
                            
                            leftSkulls.Remove(ls);
                            downSkulls.Remove(ds);
                        }
                    }
                }
            }
        }

        public void ExplosionIntersection ()
        {
            //makes it so that the player only has one life if they intersect with an explosion
            Rectangle hyunjinRec = new Rectangle(hyunjin.x, hyunjin.y, hyunjin.size, hyunjin.size);

            foreach (Rectangle ex in explosions)
            {
                if (ex.IntersectsWith(hyunjinRec))
                {
                    Form1.oneLife = true;
                    hyunjin.x = Form1.heroStart;
                    hyunjin.y = this.Height / 2;
                    
                }
            }
        }

        public void Intersection()
        {
            Rectangle hyunjinRec = new Rectangle(hyunjin.x, hyunjin.y, hyunjin.size, hyunjin.size);

            foreach (Skull s in leftSkulls)
            {
                //checks for intersections with the left skulls
                Rectangle skullRec = new Rectangle(s.x, s.y, s.size, s.size);

                if (skullRec.IntersectsWith(hyunjinRec))
                {
                    hyunjin.x = Form1.heroStart;
                    hyunjin.y = this.Height / 2;

                    if (Form1.oneLife == true)
                    {
                        //exits the level and goes to the game over screen
                        Form1.stopTime = DateTime.Now;
                        Form1.win = false;
                        gameLoopTimer.Enabled = false;
                        healthBox.Visible = false;
                        lightBox.Visible = false;
                        GameOverScreen go = new GameOverScreen();
                        this.Controls.Add(go);
                    }
                    else if (Form1.oneLife == false)
                    {
                        Form1.lives--;
                    }
                }
            }

            foreach (Skull s in downSkulls)
            {
                //checks for intersections with the down skulls
                Rectangle skullRec = new Rectangle(s.x, s.y, s.size, s.size);

                if (skullRec.IntersectsWith(hyunjinRec))
                {
                    hyunjin.x = Form1.heroStart;
                    hyunjin.y = this.Height / 2;

                    if (Form1.oneLife == true)
                    {
                        //exits the level and goes to the game over screen
                        Form1.stopTime = DateTime.Now;
                        Form1.win = false;
                        gameLoopTimer.Enabled = false;
                        healthBox.Visible = false;
                        lightBox.Visible = false;
                        GameOverScreen go = new GameOverScreen();
                        this.Controls.Add(go);
                    }
                    else if (Form1.oneLife == false)
                    {
                        Form1.lives--;
                    }

                }
            }

            //changes the life counter 
            if (Form1.lives == 3 && Form1.oneLife == false)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_Full;
            }
            else if (Form1.lives == 3 && Form1.oneLife == true)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_Full_Green;
            }
            else if (Form1.lives == 2 && Form1.oneLife == true)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_2_Green;
            }
            else if (Form1.lives == 2)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_2;
            }
            else if (Form1.lives == 1 && Form1.oneLife == true)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_1_Green;
            }
            else if (Form1.lives == 1)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_1;
            }
            else if (Form1.lives == 0 )
            {
                //exits the level and goes to the game over screen
                Form1.stopTime = DateTime.Now;
                Form1.win = false;
                gameLoopTimer.Enabled = false;
                healthBox.Visible = false;
                lightBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }

            if (hyunjinRec.IntersectsWith(key))
            {
                //exits the level and goes to the game over screen
                Form1.stopTime = DateTime.Now;
                Form1.win = true;
                Form1.mediumLevel = true;
                gameLoopTimer.Enabled = false;
                healthBox.Visible = false;
                lightBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }

            
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            
            tick ++;

            if (tick == 100)
            {
                MakeDownSkulls();
                MakeLeftSkulls();
                tick = 0;
            }

            SkullIntersection();
            ExplosionIntersection();

            foreach (Skull s in leftSkulls)
            {
                s.Move();
            }

            foreach (Skull s in downSkulls)
            {
                s.Move();
            }

            for (int i = 0; i < leftSkulls.Count(); i++)
            {
                if (leftSkulls[i].x > 700 || leftSkulls[i].x < 0)
                {
                    leftSkulls.RemoveAt(i);
                }
            }

            for (int i = 0; i < downSkulls.Count(); i++)
            {
                if (downSkulls[i].y > 400 || downSkulls[i].y < 0)
                {
                    downSkulls.RemoveAt(i);
                }
            }

            if (Form1.leftArrowDown == true && hyunjin.x < this.Width - hyunjin.size)
            {
                hyunjin.Move("left");
                hyunjin.direction = "left";
            }
            else if (Form1.rightArrowDown == true && hyunjin.x > 0)
            {
                hyunjin.Move("right");
                hyunjin.direction = "right";
            }
            else if (Form1.downArrowDown == true && hyunjin.y < this.Height - hyunjin.size * 2)
            {
                hyunjin.Move("down");
                hyunjin.direction = "down";
            }
            else if (Form1.upArrowDown == true && hyunjin.y > 0)
            {
                hyunjin.Move("up");
                hyunjin.direction = "up";
            }

            Intersection();

            Refresh();
        }

        private void MediumLevel_KeyUp(object sender, KeyEventArgs e)
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

        private void MediumLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void MediumLevel_Paint(object sender, PaintEventArgs e)
        {
            //draws all the images to the screen
            e.Graphics.DrawImage(Properties.Resources.Clé, key);

            if (hyunjin.direction == "right")
            {
                e.Graphics.DrawImage(Properties.Resources.Hyunjin_Right, hyunjin.x, hyunjin.y, hyunjin.size, hyunjin.size);
            }
            else if (hyunjin.direction == "left")
            {
                e.Graphics.DrawImage(Properties.Resources.Hyunjin_Left, hyunjin.x, hyunjin.y, hyunjin.size, hyunjin.size);
            }
            else if (hyunjin.direction == "up")
            {
                e.Graphics.DrawImage(Properties.Resources.Hyunjin_Back, hyunjin.x, hyunjin.y, hyunjin.size, hyunjin.size);
            }
            else if (hyunjin.direction == "down")
            {
                e.Graphics.DrawImage(Properties.Resources.Hyunjin_Forward, hyunjin.x, hyunjin.y, hyunjin.size, hyunjin.size);
            }

            foreach (Skull s in leftSkulls)
            {
                e.Graphics.DrawImage(Properties.Resources.Easy_Skull, s.x, s.y, s.size, s.size);
            }

            foreach (Skull s in downSkulls)
            {
                e.Graphics.DrawImage(Properties.Resources.Easy_Skull_Foreward, s.x, s.y, s.size, s.size);
            }

            foreach (Rectangle ex in explosions)
            {
                e.Graphics.DrawImage(Properties.Resources.Green_Explosion, ex);
            }
        }
    }
}
