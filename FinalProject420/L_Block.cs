﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject420
{
    class L_Block : Block
    {
        public L_Block()
        {
            rectList = new List<Rectangle>
            {
                new Rectangle(20, 0, 10, 10),
                new Rectangle(0, 10, 10, 10),
                new Rectangle(10, 10, 10, 10),
                new Rectangle(20, 10, 10, 10)
            };
            width = 30;
            height = 20;
            color = Color.Orange;
        }
    }
}
