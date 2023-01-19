using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dangl.Calculator;


namespace Calculator_1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// A list containing the user input from the calculator as a string.
        /// </summary>
        List<String> userInput = new List<String>();

        /// <summary>
        /// A list containing the user input when the M+ button is selected.
        /// </summary>
        List<String> memory = new List<String>();

        bool allEnabled = false;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
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
            buttonMPlus.Tag = "M+";
            buttonMR.Tag = "Mr";
            buttonMC.Tag = "Mc";
            buttonPlus.Tag = "+";
            buttonMinus.Tag = "-";
            buttonMultiply.Tag = "*";
            buttonDivide.Tag = "/";
            buttonSqrt.Tag = "SQRT";
            buttonPercent.Tag = "%";
            buttonInverse.Tag = "invr";
            buttonSquare.Tag = "SQR";
            buttonDot.Tag = ".";
            buttonEqual.Tag = "=";
            buttonPlusMinus.Tag = "+/-";

        }



        private void displayPictureBox(object sender, EventArgs e)
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

        private void calculationLogic(String num)
        {

            if (textBox1.Text == "0" && userInput.Count() == 0)
            {
                textBox1.Clear();
                textBox1.Text += num;
                userInput.Add(num);
            }
            else if (textBox1.Text.Equals("Please enter a valid expression!"))
            {
                textBox1.Clear();
                userInput.Clear();
                textBox1.Text = num;
                userInput.Add(num);
            }
            else if (num == "%" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstNumber = string.Join("", memory.ToArray());
                userInput.Clear();
                userInput.Add(veryFirstNumber + "/100");
                textBox1.Clear();
                textBox1.Text += veryFirstNumber + num;
            }
            else if (num == "%")
            {
                string veryFirstNumber = string.Join("", userInput.ToArray());
                userInput.Clear();
                userInput.Add(veryFirstNumber + "/100");
                textBox1.Clear();
                textBox1.Text += veryFirstNumber + num;
            }

            else if (num == "invr" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstNumber = string.Join("", memory.ToArray());
                userInput.Clear();
                userInput.Add("1/" + veryFirstNumber);
                textBox1.Clear();
                textBox1.Text += "1/" + veryFirstNumber;
            }
            else if (num == "invr")
            {
                string veryFirstNumber = string.Join("", userInput.ToArray());
                userInput.Clear();
                userInput.Add("1/" + veryFirstNumber);
                textBox1.Clear();
                textBox1.Text += "1/" + veryFirstNumber;
            }
            else if (num == "SQRT" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstNumber = string.Join("", memory.ToArray());
                userInput.Clear();
                userInput.Add("SQRT(" + veryFirstNumber + ")");
                textBox1.Text = "SQRT(" + veryFirstNumber + ")";
            }
            else if (num == "SQRT")
            {
                string veryFirstNumber = string.Join("", userInput.ToArray());
                userInput.Clear();
                userInput.Add("SQRT(" + veryFirstNumber + ")");
                textBox1.Text = "SQRT(" + veryFirstNumber + ")";
            }
            else if (num == "SQR" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstNumber = string.Join("", memory.ToArray());
                userInput.Clear();
                userInput.Add("SQR(" + veryFirstNumber + ")");
                textBox1.Text = "SQR(" + veryFirstNumber + ")";
            }
            else if (num == "SQR")
            {
                string veryFirstNumber = string.Join("", userInput.ToArray());
                userInput.Clear();
                userInput.Add("SQR(" + veryFirstNumber + ")");
                textBox1.Text = "SQR(" + veryFirstNumber + ")";
            }
            else if (num == "+/-" && userInput.Count() == 1)
            {
                string veryFirstNumber = userInput.Last();
                userInput.Clear();
                if (int.Parse(veryFirstNumber) > 0)
                {
                    userInput.Add("-1 *" + veryFirstNumber);
                    var result = string.Join("", userInput.ToArray());
                    var calculation = Calculator.Calculate(result);
                    if (calculation.IsValid)
                    {
                        textBox1.Text = "-" + veryFirstNumber;
                        userInput.Clear();
                        userInput.Add(calculation.Result.ToString());
                    }

                }
                else
                {
                    userInput.Add("-1 *" + veryFirstNumber);
                    var result = string.Join("", userInput.ToArray());
                    var calculation = Calculator.Calculate(result);
                    if (calculation.IsValid)
                    {
                        textBox1.Text = calculation.Result.ToString();
                        userInput.Clear();
                        userInput.Add(calculation.Result.ToString());
                    }
                }

            }
            else if (num == "+/-" && memory.Count() == 1)
            {
                string veryFirstNumber = string.Join("", userInput.ToArray());
                userInput.Clear();
                if (int.Parse(veryFirstNumber) > 0)
                {
                    userInput.Add("-1 *" + veryFirstNumber);
                    var result = string.Join("", userInput.ToArray());
                    var calculation = Calculator.Calculate(result);
                    if (calculation.IsValid)
                    {
                        textBox1.Text = "-" + veryFirstNumber;
                        userInput.Clear();
                        userInput.Add(calculation.Result.ToString());
                    }

                }
                else
                {
                    userInput.Add("-1 *" + veryFirstNumber);
                    var result = string.Join("", userInput.ToArray());
                    var calculation = Calculator.Calculate(result);
                    if (calculation.IsValid)
                    {
                        textBox1.Text = calculation.Result.ToString();
                        userInput.Clear();
                        userInput.Add(calculation.Result.ToString());
                    }
                }

            }
            else
            {
                textBox1.Text += num;
                userInput.Add(num);
            }


        }

        /// <summary>
        /// Adds the user input from the calculator and adds it to an array so the equation can be calculated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonArithmetic_Click(object sender, EventArgs e)
        {
            // retrieve # f/ sender obj's Tag property
            string num = (string)((Button)sender).Tag;

            if (allEnabled == true)
            {
                // SQR, SQRT, 1/X and percentages are special operations that need to be 
                // handled differently from basic operations like addition or subtraction.


                if (num.Equals("M+"))
                {
                    evaluateFunction(sender, e);
                }
                else if (num.Equals("Mr"))
                {
                    if (memory.Count() > 0)
                    {
                        textBox1.Text = memory.First();
                    }
                    else
                    {
                        textBox1.Text = "0";
                    }
                }
                else if (num.Equals("Mc"))
                {
                    memory.Clear();
                }
                else
                {
                    calculationLogic(num);
                }





            }
        }

        private void onOff(object sender, EventArgs e)
        {

            if (allEnabled == true)
            {
                allEnabled = false;
            }
            else
            {
                allEnabled = true;
                textBox1.Text = "0";
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (input.Length > 0)
            {
                textBox1.Text = input.Substring(0, input.Length - 1);
                userInput.Clear();
                userInput.Add(textBox1.Text);
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            userInput.Clear();
            userInput.Add(textBox1.Text);
        }




        /// <summary>
        /// Parses the string from the user input and returns the value of the calculation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evaluateFunction(object sender, EventArgs e)
        {

            var result = string.Join("", userInput.ToArray());
            var calculation = Calculator.Calculate(result);

            string toSave = (string)((Button)sender).Tag;

            if (calculation.IsValid)
            {
                textBox1.Text = calculation.Result.ToString();
                if (toSave.Equals("M+"))
                {

                    if (memory.Count() == 0)
                    {
                        memory.Add(calculation.Result.ToString());
                    }
                    else
                    {
                        memory.Add("+");
                        memory.Add(textBox1.Text);
                    }


                    var memString = string.Join("", memory.ToArray());

                    var memCalc = Calculator.Calculate(memString);

                    memory.Clear();
                    memory.Add(memCalc.Result.ToString());
                }
                if (!toSave.Equals("M+"))
                {
                    userInput.Clear();
                    userInput.Add(calculation.Result.ToString());
                }

            }
            else
            {
                textBox1.Text = "Please enter a valid expression!";
            }


        }


    }
}
