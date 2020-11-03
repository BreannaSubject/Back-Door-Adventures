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
    public partial class EasyLevel : UserControl
    {
        List<Car> cars = new List<Car>();
        int carSpeed = 1;
        int carSize = 20;
        int heroSpeed = 5;
        int heroSize = 36;
        string direction, heroDirection;
        Random random = new Random();
        int tick = 0;
        Hero chan;
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

            chan = new Hero(140 / 2, this.Height / 2, heroSpeed, heroSpeed, heroSize, "right");
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
            int y = this.Height - carSize*2;
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



        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {

            tick +=  4;

            if (tick == 200)
            {
                MakeBottomCars();
                MakeTopCars();
                tick = 0;
            }

            foreach (Car c in cars)
            {
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
                if (cars[i].y > 400 || cars[i].y < 0)
                {
                    cars.RemoveAt(i);
                }
            }

            if (Form1.leftArrowDown == true && chan.x < this.Width - chan.size*2)
            {
                chan.Move("left");
                chan.direction = "left";
            }
            else if (Form1.rightArrowDown == true && chan.x > 0)
            {
                chan.Move("right");
                chan.direction = "right";
            }
            else if (Form1.downArrowDown == true && chan.y < this.Height - chan.size*2)
            {
                chan.Move("down");
                chan.direction = "down";
            }
            else if (Form1.upArrowDown == true && chan.y > 0)
            {
                chan.Move("up");
                chan.direction = "up";
            }

            Refresh();
        }

        private void EasyLevel_Paint(object sender, PaintEventArgs e)
        {

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

