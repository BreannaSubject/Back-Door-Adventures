using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Back_Door_Adventures
{
    class Oni
    {
        public int x, y, size;
        public Oni(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }

        public void Move(int speed, int direction, Form f)
        {
            if (direction == 1 && x > 0 + size/10)
            {
                x -= speed;
            }
            else if (direction == 2 && x < f.Width - size)
            {
                x += speed;
            }
            else if (direction == 3 && y > 0 + size/10)
            {
                y -= speed;
            }
            else if (direction == 4 && y < f.Height - size)
            {
                y += speed;
            }
            Console.WriteLine(direction);
            Console.WriteLine(y + "y");
        }
    }
}
