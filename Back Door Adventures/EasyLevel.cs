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
        int carSpeed = 5;
        int carSize = 20;
        bool carDirection;
        Random random = new Random();
        public EasyLevel()
        {
            InitializeComponent();
        }

        private void EasyLevel_Load(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("EasyLevel.xml");

            while (reader.Read())
            {
               if (reader.NodeType == XmlNodeType.Text)
                {
                    string colour = reader.ReadString();

                    reader.ReadToNextSibling("direction");
                    string direction = reader.ReadString();

                    reader.ReadToNextSibling("x");
                    int x = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    int y = Convert.ToInt32(reader.ReadString());

                    if (direction == "up")
                    {
                        carDirection = true;
                    }
                    else
                    {
                        carDirection = false;
                    }

                    Car car = new Car(colour, carDirection, x, y, carSpeed, carSize);
                    cars.Add(car);
                }
            }
            reader.Close();
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            int tick = 0;
            tick++;

            if (tick == 400)
            {
                tick = 0;
                

            }

            foreach (Car c in cars)
            {
                c.Move();
            }

            for (int i = 0; i < cars.Count(); i++)
            {
                if (cars[i].y > 400 || cars[i].y < 0)
                {
                    cars.RemoveAt(i);
                }
            }
        }

        private void EasyLevel_Paint(object sender, PaintEventArgs e)
        {
            foreach (Car c in cars)
            {
                if (c.direction == true && c.colour == "red")
                {
                    e.Graphics.DrawImage(Properties.Resources.Red_Car_Up, c.x, c.y, c.size, c.size);
                }
                else if (c.direction == false && c.colour == "red")
                {
                    e.Graphics.DrawImage(Properties.Resources.Red_Car_Down, c.x, c.y, c.size, c.size);
                }
                else if (c.direction == false && c.colour == "blue")
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
