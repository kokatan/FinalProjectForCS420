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
                foreach (Rectangle r in GetRectList())
                {
                    g.FillRectangle(b, new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1));
                }
            }


        }

        public void Move(Point offset, Size fieldSize)
        {
            Point newPos = new Point(pos.X + offset.X, pos.Y + offset.Y);
            if(newPos.X < 0)
            {
                newPos.X = 0;
            }
            else if(newPos.X + width > fieldSize.Width)
            {
                newPos.X = fieldSize.Width - width;
            }
            if(newPos.Y + height > fieldSize.Height)
            {
                newPos.Y = fieldSize.Height - height;
            }
            pos = newPos;
        }

        public List<Rectangle> GetRectList()
        {
            List<Rectangle> drawRectList = new List<Rectangle>();
            foreach(Rectangle r in rectList)
            {
                drawRectList.Add(new Rectangle(pos.X + r.Left, pos.Y + r.Top, r.Width, r.Height));
            }
            return drawRectList;
        }
    }
}
