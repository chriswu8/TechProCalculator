using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Calculator_1
{
    public partial class Form1 : Form
    {
        private List<String> textboxText = new List<string>();
        private double memory = 0;

        public Form1()
        {
            InitializeComponent();

            button0.Tag = "0";
            button1.Tag = "1";
            button2.Tag = "2";
            button3.Tag = "3";
            button4.Tag = "4";
            button5.Tag = "5";
            button6.Tag = "6";
            button7.Tag = "7";
            button8.Tag = "8";
            buttonPlus.Tag = "+";
            buttonMinus.Tag = "-";
            buttonMultiply.Tag = "*";
            buttonDivide.Tag = "/";
            buttonSqrt.Tag = "√";
            buttonPercent.Tag = "%";
            buttonInverse.Tag = "1/";
            buttonSquare.Tag = "/";
            buttonDot.Tag = ".";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics gfx = Graphics.FromImage(pictureBox1.Image);
                Point point = new Point(0, 0);
                Image mathImage = Image.FromFile(Application.StartupPath + "/Resources/bcit.png");
                gfx.DrawImage(mathImage, point);
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error opening image", MessageBoxButtons.OK);
            }

        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics gfx = Graphics.FromImage(pictureBox1.Image);
                Point point = new Point(0, 0);
                Image mathImage = Image.FromFile(Application.StartupPath + "/Resources/bcit.png");
                gfx.DrawImage(mathImage, point);
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error opening image", MessageBoxButtons.OK);
            }

        }

        private void buttonArithmetic_Click(object sender, EventArgs e)
        {
            // retrieve # f/ sender obj's Tag property
            string num = (string)((Button)sender).Tag;

            if(textBox1.Text.Equals("0"))
            {
                textBox1.Text = num;
            }
            else
            {
            textBox1.Text += num;
            }
            textboxText.Add(textBox1.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (input.Length > 0)
            {
                textBox1.Text = input.Substring(0, input.Length - 1);
                textboxText.Add(textBox1.Text);
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textboxText.Add(textBox1.Text);
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            memory += double.Parse(textBox1.Text);
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            memory = double.Parse(textBox1.Text);
        }
    }
}
