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
        public string colour;
        public bool direction;
        public int x, y, speed, size;

        public Car(string _colour, bool _direction, int _x, int _y, int _speed, int _size)
        {
            colour = _colour;
            direction = _direction;
            x = _x;
            y = _y;
            speed = _speed;
            size = _size;
        }

        public void Move()
        {
            if (direction == true)
            {
                y += speed;
            }
            else
            {
                y -= speed;
            }
        }
    }

    
}
