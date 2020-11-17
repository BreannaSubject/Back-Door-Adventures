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
using System.Diagnostics;

namespace Back_Door_Adventures
{
    public partial class EasyLevel : UserControl
    {
        List<Car> cars = new List<Car>(); //list for all the cars
        //car variables
        int carSpeed = 1;
        int carSize = 20;

        //hero variables
        Hero minho;
        int heroSpeed = 5;
        int heroSize = 36;

        string direction;
        Random random = new Random();
        int tick = 0;
        Rectangle key;
        public EasyLevel()
        {
            InitializeComponent();
        }

        private void EasyLevel_Load(object sender, EventArgs e)
        {
            Form1.leftArrowDown = false;
            Form1.rightArrowDown = false;
            Form1.upArrowDown = false;
            Form1.downArrowDown = false;

            minho = new Hero(Form1.heroStart, this.Height / 2, heroSpeed, heroSpeed, heroSize, "right");
            key = new Rectangle(this.Width - heroSize, this.Height / 2, Form1.keySize, Form1.keySize);
            XmlReader reader = XmlReader.Create("EasyLevel.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    string colour = reader.ReadString();

                    reader.ReadToNextSibling("direction");
                    direction = reader.ReadString();

                    reader.ReadToNextSibling("x");
                    int x = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    int y = Convert.ToInt32(reader.ReadString());

                    Car car = new Car(colour, direction, x, y, carSize);
                    cars.Add(car);
                }
            }
            reader.Close();

            Form1.startTime = DateTime.Now;//captures the start time

        }

        private void EasyLevel_KeyUp(object sender, KeyEventArgs e)
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

        private void EasyLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        public void MakeBottomCars()
        {
            int y = this.Height - carSize * 2;
            int randPosition, position, randColour;
            string newDirection, carColour;

            randPosition = random.Next(1, 6);
            randColour = random.Next(1, 3);
            newDirection = "up";

            if (randPosition == 1)
            {
                position = 140;
            }
            else if (randPosition == 2)
            {
                position = 249;
            }
            else if (randPosition == 3)
            {
                position = 436;
            }
            else if (randPosition == 4)
            {
                position = 468;
            }
            else
            {
                position = 599;
            }

            if (randColour == 1)
            {
                carColour = "red";
            }
            else
            {
                carColour = "blue";
            }

            Car c = new Car(carColour, newDirection, position, y, carSize);
            cars.Add(c);
        }

        public void MakeTopCars()
        {
            int y = 0;
            int randPosition, position, randColour;
            string newDirection, carColour;

            randPosition = random.Next(1, 6);
            randColour = random.Next(1, 3);
            newDirection = "down";

            if (randPosition == 1)
            {
                position = 104;
            }
            else if (randPosition == 2)
            {
                position = 213;
            }
            else if (randPosition == 3)
            {
                position = 370;
            }
            else if (randPosition == 4)
            {
                position = 401;
            }
            else
            {
                position = 565;
            }

            if (randColour == 1)
            {
                carColour = "red";
            }
            else
            {
                carColour = "blue";
            }

            Car c = new Car(carColour, newDirection, position, y, carSize);
            cars.Add(c);
        }

        public void Intersection()
        {
            Rectangle minhoRec = new Rectangle(minho.x, minho.y, minho.size, minho.size);

            foreach (Car c in cars)
            {//checks if the hero intersects with the cars 
                Rectangle carRec = new Rectangle(c.x, c.y, c.size, c.size);

                if (carRec.IntersectsWith(minhoRec))
                {
                    minho.x = Form1.heroStart;
                    minho.y = this.Height / 2;
                    Form1.lives--;
                }
            }

            //changes the picture in the health box based on the lives
            if (Form1.lives == 3)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_Full;
            }
            else if (Form1.lives == 2)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_2;
            }
            else if (Form1.lives == 1)
            {
                healthBox.BackgroundImage = Properties.Resources.Health_Bar_1;
            }
            else if (Form1.lives == 0)
            {
                //exits the level and goes to the game over screen
                Form1.stopTime = DateTime.Now;
                Form1.win = false;
                gameLoopTimer.Enabled = false;
                healthBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }

            if (minhoRec.IntersectsWith(key))
            {
                //exits the level and goes to the game over screen
                Form1.stopTime = DateTime.Now;
                Form1.win = true;
                Form1.easyLevel = true;
                gameLoopTimer.Enabled = false;
                healthBox.Visible = false;
                GameOverScreen go = new GameOverScreen();
                this.Controls.Add(go);
            }
        }



        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            
            tick +=  2;

            if (tick == 200)
            {
                //makes cars every 200 ticks
                MakeBottomCars();
                MakeTopCars();
                tick = 0;
            }

            foreach (Car c in cars)
            {
                //moves the cars
                if (c.direction == "up")
                {
                    c.UpMove(carSpeed);
                }
                else
                {
                    c.DownMove(carSpeed);
                }
            }

            for (int i = 0; i < cars.Count(); i++)
            {
                //removes the cars from the list when they reach the edge of the screen
                if (cars[i].y > 400 || cars[i].y < 0)
                {
                    cars.RemoveAt(i);
                }
            }

            //moves the hero
            if (Form1.leftArrowDown == true && minho.x < this.Width - minho.size)
            {
                minho.Move("left");
                minho.direction = "left";
            }
            else if (Form1.rightArrowDown == true && minho.x > 0)
            {
                minho.Move("right");
                minho.direction = "right";
            }
            else if (Form1.downArrowDown == true && minho.y < this.Height - minho.size*2)
            {
                minho.Move("down");
                minho.direction = "down";
            }
            else if (Form1.upArrowDown == true && minho.y > 0)
            {
                minho.Move("up");
                minho.direction = "up";
            }

            Intersection();

            Refresh();
        }

        private void EasyLevel_Paint(object sender, PaintEventArgs e)
        {
            //draws to the screen
            e.Graphics.DrawImage(Properties.Resources.Clé, key);

            if (minho.direction == "right")
            {
                e.Graphics.DrawImage(Properties.Resources.Minho_Right, minho.x, minho.y, minho.size, minho.size);
            }
            else if (minho.direction == "left")
            {
                e.Graphics.DrawImage(Properties.Resources.Minho_Left, minho.x, minho.y, minho.size, minho.size);
            }
            else if (minho.direction == "up")
            {
                e.Graphics.DrawImage(Properties.Resources.Minho_Back, minho.x, minho.y, minho.size, minho.size);
            }
            else if (minho.direction == "down")
            {
                e.Graphics.DrawImage(Properties.Resources.Minho_Foreward, minho.x, minho.y, minho.size, minho.size);
            }

            foreach (Car c in cars)
            {
                if (c.direction == "up" && c.colour == "red")
                {
                    e.Graphics.DrawImage(Properties.Resources.Red_Car_Up, c.x, c.y, c.size, c.size);
                }
                else if (c.direction == "down" && c.colour == "red")
                {
                    e.Graphics.DrawImage(Properties.Resources.Red_Car_Down, c.x, c.y, c.size, c.size);
                }
                else if (c.direction == "down" && c.colour == "blue")
                {
                    e.Graphics.DrawImage(Properties.Resources.Blue_Car_Down, c.x, c.y, c.size, c.size);
                }
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.Blue_Car_Up, c.x, c.y, c.size, c.size);
                }
            }
        }

       
    }
}

