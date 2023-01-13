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
using Dangl.Calculator;


namespace Calculator_1
{
    public partial class Form1 : Form
    {

        List<String> userInput = new List<String>();

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
            button9.Tag = "9";
            buttonOpenBracket.Tag = "(";
            buttonCloseBracket.Tag = ")";
            buttonPlus.Tag = "+";
            buttonMinus.Tag = "-";
            buttonMultiply.Tag = "*";
            buttonDivide.Tag = "/";
            buttonSqrt.Tag = "SQRT";
            buttonPercent.Tag = "%";
            buttonInverse.Tag = "invr";
            buttonSquare.Tag = "SQR";
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

            if (num == "%")
            {
                string veryFirstNumber = userInput.Last();
                double res = evaluatePercentage(Convert.ToDouble(veryFirstNumber));
                userInput.Clear();
                userInput.Add(veryFirstNumber + "/100");
                textBox1.Text += num;
            }
            else if (num == "invr")
            {
                string veryFirstNumber = userInput.Last();
                double res = evaluateInverse(Convert.ToDouble(veryFirstNumber));
                userInput.Clear();
                userInput.Add("1/"+veryFirstNumber);
                textBox1.Text += num;
            }
            else if (num == "SQRT" && userInput.Count() == 1)
            {
                string veryFirstNumber = userInput.Last();
                userInput.Clear();
                userInput.Add("SQRT(" + veryFirstNumber + ")");
                textBox1.Text = "SQRT(" + veryFirstNumber + ")";
            }
            else if (num == "SQR" && userInput.Count() == 1)
            {
                string veryFirstNumber = userInput.Last();
                userInput.Clear();
                userInput.Add("SQR(" + veryFirstNumber + ")");
                textBox1.Text = "SQR(" + veryFirstNumber + ")";
            }
            else 
            {
                textBox1.Text += num;
                userInput.Add(num);
            }
            
        }

        private double evaluatePercentage(double value)
        {
            return value / 100;
        }

        private double evaluateInverse(double value)
        {
            return 1 / value;
        }

        private void evaluateFunction(object sender, EventArgs e)
        {
             
            var result = string.Join("", userInput.ToArray());
            var calculation = Calculator.Calculate(result);

            
            if (calculation.IsValid)
            {
                textBox1.Text = calculation.Result.ToString();
                userInput.Clear();
                userInput.Add(calculation.Result.ToString());
            }
            else
            {
                textBox1.Text = "Please enter a valid expression!";
            }

           
        }

        
    }
}
