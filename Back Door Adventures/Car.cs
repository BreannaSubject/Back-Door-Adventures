using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Back_Door_Adventures
{
    class Car
    {
        public string colour, direction;
        public int x, y, size;

        public Car(string _colour, string _direction, int _x, int _y, int _size)
        {
            colour = _colour;
            direction = _direction;
            x = _x;
            y = _y;
            size = _size;
        }

        public void UpMove(int speed)
        {
            y = y - speed;
        }

        public void Move (int speed, string direction)
        {
            if (direction == "up")
            {
                y = y - speed;
            }
            else if (direction == "down")
            {
                y = y + speed;
            }
        }
        public void DownMove (int speed)
        {
            y = y + speed;
        }
    }

    
}
