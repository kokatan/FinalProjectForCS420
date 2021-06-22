using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject420
{
    public partial class Form1 : Form
    {
        List<Block> blockList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blockList = new List<Block>();
            AddBlock();


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Block b in blockList)
            {
                b.Draw(e.Graphics);
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if(blockList.Count > 0)
            {
                Block lastBlock = blockList.Last();
                lastBlock.Update(pictureBox1.Height);

                if (lastBlock.isFalled)
                {
                    AddBlock();
                }
            }
            foreach (Block b in blockList)
            {
                b.Update(pictureBox1.Height);
            }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

        }

        private void AddBlock()
        {
            Block newBlock = null;
            Random rand = new Random();
            switch (rand.Next(7))
            {
                case 0:
                    newBlock = new I_Block();
                    break;

                case 1:
                    newBlock = new J_Block();
                    break;

                case 2:
                    newBlock = new L_Block();
                    break;

                case 3:
                    newBlock = new O_Block();
                    break;

                case 4:
                    newBlock = new S_Block();
                    break;

                case 5:
                    newBlock = new Z_Block();
                    break;

                case 6:
                    newBlock = new T_Block();
                    break;

            }
            blockList.Add(newBlock);
        }

    }
}
