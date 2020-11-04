using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_Door_Adventures
{
    class Skull
    {
        public bool direction;
        public int x, y, speed, size;

        public Skull(bool _direction, int _x, int _y,  int _speed, int _size)
        {
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
                x -= speed;
            }
            else
            {
                y += speed;
            }
        }
    }
}
