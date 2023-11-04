using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox2.BackColor = Color.FromArgb(128, Color.Red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = richTextBox1.Rtf;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedRtf = textBox1.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(16, 12);
            Graphics graphics = Graphics.FromImage(bitmap);
            Random random = new Random();

            graphics.Clear(Color.White);
            graphics.DrawString("gA", richTextBox1.Font, Brushes.Black, new Point());

            graphics.Dispose();
            bitmap.Save("bitmap.png");

            Clipboard.SetImage(bitmap);
            richTextBox1.Paste();
        }
    }
}
