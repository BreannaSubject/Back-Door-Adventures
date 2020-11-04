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
        Hero chan;
        Rectangle key;
        int heroSpeed = 4;
        int heroSize = 36;
        int skullSpeed = 6;
        int skullSize = 32;
        int tick = 0;
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
            lightBox.BackgroundImage = blueLight;

            Form1.leftArrowDown = false;
            Form1.rightArrowDown = false;
            Form1.upArrowDown = false;
            Form1.downArrowDown = false;

            chan = new Hero(Form1.heroStart, this.Height / 2, heroSpeed, heroSpeed, heroSize, "right");
            key = new Rectangle(this.Width - heroSize, this.Height / 2, Form1.keySize, Form1.keySize);
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
        }

        public void MakeDownSkulls()
        {
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
            Rectangle chanRec = new Rectangle(chan.x, chan.y, chan.size, chan.size);

            foreach (Rectangle ex in explosions)
            {
                if (ex.IntersectsWith(chanRec))
                {
                    Form1.oneLife = true;
                    chan.x = Form1.heroStart;
                    chan.y = this.Height / 2;
                    
                }
            }
        }

        public void Intersection()
        {
            Rectangle chanRec = new Rectangle(chan.x, chan.y, chan.size, chan.size);

            foreach (Skull s in leftSkulls)
            {
                Rectangle skullRec = new Rectangle(s.x, s.y, s.size, s.size);

                if (skullRec.IntersectsWith(chanRec))
                {
                    chan.x = Form1.heroStart;
                    chan.y = this.Height / 2;

                    if (Form1.oneLife == true)
                    {
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
                Rectangle skullRec = new Rectangle(s.x, s.y, s.size, s.size);

                if (skullRec.IntersectsWith(chanRec))
                {
                    chan.x = Form1.heroStart;
                    chan.y = this.Height / 2;

                    if (Form1.oneLife == true)
                    {
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
                Form1.stopTime = DateTime.Now;
                Form1.win = false;
                gameLoopTimer.Enabled = false;
                healthBox.Visible = false;
                lightBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }

            if (chanRec.IntersectsWith(key))
            {
                Form1.stopTime = DateTime.Now;
                Form1.win = true;
                gameLoopTimer.Enabled = false;
                healthBox.Visible = false;
                lightBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }

            
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            Form1.startTime = DateTime.Now;
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
