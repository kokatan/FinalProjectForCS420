using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject420
{
    class I_Block : Block
    {
        public I_Block()
        {
            rectList = new List<Rectangle>
            {
                new Rectangle(0, 0, 10, 10),
                new Rectangle(10, 0, 10, 10),
                new Rectangle(20, 0, 10, 10),
                new Rectangle(30, 0, 10, 10)
            };
            width = 40;
            height = 10;
            color = Color.Cyan;
        }
    }
}
