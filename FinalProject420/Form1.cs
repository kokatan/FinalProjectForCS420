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
            foreach (Block b in blockList)
            {
                b.Update(pictureBox1.Height);
            }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Block b = new I_Block();
            blockList.Add(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Block b = new J_Block();
            blockList.Add(b);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Block b = new L_Block();
            blockList.Add(b);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Block b = new O_Block();
            blockList.Add(b);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Block b = new S_Block();
            blockList.Add(b);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Block b = new Z_Block();
            blockList.Add(b);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Block b = new T_Block();
            blockList.Add(b);
        }
    }
}
