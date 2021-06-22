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
            if (blockList.Count > 0)
            {
                Block lastBlock = blockList.Last();

                if(GetTouchBlock(lastBlock)[0] == false)
                {
                    lastBlock.Update(pictureBox1.Height);
                }
                else
                {
                    lastBlock.isFalled = true;
                }

                if (lastBlock.isFalled)
                {
                    AddBlock();
                }
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

        [System.Security.Permissions.UIPermission(
        System.Security.Permissions.SecurityAction.Demand,
        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (blockList.Count > 0)
            {
                Block lastBlock = blockList.Last();
                if ((keyData & Keys.KeyCode) == Keys.Down)
                {
                    lastBlock.Move(new Point(0, 10), pictureBox1.Size);
                }
                else if ((keyData & Keys.KeyCode) == Keys.Left)
                {
                    lastBlock.Move(new Point(-10, 0), pictureBox1.Size);
                }
                else if ((keyData & Keys.KeyCode) == Keys.Right)
                {
                    lastBlock.Move(new Point(10, 10), pictureBox1.Size);
                }

            }
            return base.ProcessDialogKey(keyData);
        }

        private bool[] GetTouchBlock(Block block)
        {
            bool[] isTouchArray = new bool[] { false, false, false };
            List<Rectangle> rectList1 = block.GetRectList();

            foreach(Block b in blockList)
            {
                if(b != block)
                {
                    List<Rectangle> rectList2 = b.GetRectList();
                    foreach (Rectangle rect in rectList1)
                    {
                        //Bottom
                        if (rectList2.Exists(r => rect.Left == r.Left && rect.Bottom == r.Top))
                        {
                            isTouchArray[0] = true;
                        }
                        //Left
                        if (rectList2.Exists(r => rect.Left == r.Right && rect.Top == r.Top))
                        {
                            isTouchArray[1] = true;
                        }
                        //Right
                        if (rectList2.Exists(r => rect.Right == r.Left && rect.Top == r.Top))
                        {
                            isTouchArray[2] = true;
                        }
                    } 
                }
            }
            return isTouchArray; 
        }
    }
}
