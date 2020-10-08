using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020_10_08_WinForm
{
    public partial class Form1 : Form
    {
        List<string> vs = new List<string>();
        StreamReader file = null;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value -=  10;
            if(progressBar1.Value == 0)
            {
                progressBar1.Value = 100;
                timer1.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                timer1.Stop();
            }
        }

        private void 초급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "10";
            progressBar1.Value = 100;
            textBox1.Enabled = true;
        }

        private void 중급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "10";
            progressBar1.Value = 100;
            textBox1.Enabled = true;
        }

        private void 고급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "10";
            progressBar1.Value = 100;
            textBox1.Enabled = true;
        }
    }
}
