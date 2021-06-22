using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject420
{
    class Block
    {

        List<Rectangle> rectList;
        Point pos;
        int width;
        int height;
        bool isFalled;

        public Block()
        {
            rectList = new List<Rectangle>
            {
                new Rectangle(0, 0, 10, 10),
                new Rectangle(10, 0, 10, 10),
                new Rectangle(10, 10, 10, 10),
                new Rectangle(20, 10, 10, 10)
            };
            width = 30;
            height = 20;
        }

        public void Update(int fieldHeight)
        {
            if (isFalled == false)
            {
                Point newPos = new Point(pos.X, pos.Y + 10);
                if (newPos.Y + height > fieldHeight)
                {
                    newPos.Y = fieldHeight - height;
                    isFalled = true;
                }
                pos = newPos;
            }

        }

        public void Draw(Graphics g)
        {
            foreach (Rectangle r in rectList)
            {
                g.FillEllipse(Brushes.Red, new Rectangle(pos.X + r.Left, pos.Y + r.Top, r.Width - 1, r.Height - 1));
            }

        }
    }
}
