using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject420
{
    abstract class Block
    {

        public List<Rectangle> rectList;
        public Point pos;
        public int width;
        public int height;
        public bool isFalled;
        public Color color;

        public Block()
        {

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
            using (SolidBrush b = new SolidBrush(color))
            {
                foreach (Rectangle r in rectList)
                {
                    g.FillEllipse(b, new Rectangle(pos.X + r.Left, pos.Y + r.Top, r.Width - 1, r.Height - 1));
                }
            }


        }

        public void Move(Point offset)
        {
            pos = new Point(pos.X + offset.X, pos.Y + offset.Y);
        }
    }
}
