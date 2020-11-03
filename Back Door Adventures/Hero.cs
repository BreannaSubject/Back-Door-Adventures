using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_Door_Adventures
{
    
    class Hero
    {
        public int x, y, xSpeed, ySpeed, size;
        public string direction;

        public Hero(int _x, int _y, int _xSpeed, int _ySpeed, int _size, string _direction)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _size;
            direction = _direction;
        }

        public void Move(string direction)
        {
            if (direction == "up" && Form1.upArrowDown == true)
            {
                y -= ySpeed;
            }
            else if (direction == "down" && Form1.downArrowDown == true)
            {
                y += ySpeed;
            }

            if (direction == "left" && Form1.leftArrowDown == true)
            {
                x -= xSpeed;
            }
            else if (direction == "right" && Form1.rightArrowDown == true)
            {
                x += xSpeed;
            }
        }
    }
}
