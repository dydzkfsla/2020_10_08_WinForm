using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Random random = new Random();
        int score = 0;
        int opportunity = 10;
        int success = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            label4.Text = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value -=  5;
            if(progressBar1.Value <= 0)
            {
                progressBar1.Value = 100;
                Run();
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
                Run();
            }
        }

        private void 초급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            SetDefault();
            vs = ReadText(global::_2020_10_08_WinForm.Properties.Resources.typedata1);
        }

        private void 중급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            SetDefault();
            vs = ReadText(Properties.Resources.typedata2);
        }

        private void 고급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            SetDefault();
            vs =  ReadText(Properties.Resources.typedata3);
        }

        private void SetDefault()
        {
            timer1.Interval = 500;
            success = 0;
            opportunity = 10;
            label1.Text = score.ToString();
            label2.Text = opportunity.ToString(); ;
            label4.Text = "";
            progressBar1.Value = 100;
            timer1.Stop();
            textBox1.Enabled = true;
        }

        private List<string> ReadText(string FileSo)
        {
            List<string> temp = new List<string>();
            string[] Stemp = FileSo.Replace('\r', '\0').Split('\n');
            foreach(string tString in Stemp)
            {
                temp.Add(tString);
            }
            label4.Text = temp[random.Next(0, temp.Count)];
            return temp;
        }

        private void Run()
        {
            if (textBox1.Text == label4.Text)
            {
                score += 100;
                label1.Text = score.ToString();
                success++;
            }
            else
            {
                opportunity -= 1;
                label2.Text = opportunity.ToString();
            }
            textBox1.Text = "";
            label4.Text = vs[random.Next(0, vs.Count)];
            progressBar1.Value = 100;

            if (success % 2 == 0)
            {
                timer1.Interval -= 20;
            }

            if (opportunity == 0)
            {
                SetDefault();
                textBox1.Enabled = false;
                success = 0;
            }
        }

    }
}
