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

        // constructor with zero parameters
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

        /// <summary>
        /// This method initializes a picture to be displayed in the calculator.
        /// </summary>
        /// <param name="sender">Button Press</param>
        /// <param name="e">Event Arguments</param>
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

        /// <summary>
        /// Performs the sign switch logic.
        /// </summary>
        /// <param name="result">result is the conjoined elements from the userInput list</param>
        private void signSwitchLogic(String result)
        {
            var temp = Calculator.Calculate(result);
            //string veryFirstbuttonTagNumber = userInput.Last();
            //userInput.Clear();

            /// place a "-" sign in front of the number in the textbox if the number is positive 
            if (temp.IsValid)
            {
                var curr_num = Int64.Parse(temp.Result.ToString());
                if (curr_num > 0)
                {
                    userInput.Clear();
                    userInput.Add("-" + curr_num);
                    textBox1.Text = "-" + curr_num;
                }
                else
                {
                    var positiveNumber = curr_num.ToString().Substring(1);
                    userInput.Clear();
                    userInput.Add(positiveNumber);
                    textBox1.Text = positiveNumber;
                }
            }
        }

        /// <summary>
        /// Performs the textbox square root display logic.
        /// </summary>
        /// <param name="result">result is the conjoined elements from the userInput list</param>
        private void signSquareRootLogic(String result)
        {
            userInput.Clear();
            userInput.Add("SQRT(" + result + ")");
            textBox1.Text = "SQRT(" + result + ")";
        }

        /// <summary>
        /// Performs the textbox square display logic.
        /// </summary>
        /// <param name="result">result is the conjoined elements from the userInput list</param>
        private void signSquareLogic(String result)
        {
            userInput.Clear();
            userInput.Add("SQR(" + result + ")");
            textBox1.Text = "SQR(" + result + ")";
        }

        /// <summary>
        /// Performs the textbox percentage display logic.
        /// </summary>
        /// <param name="result">result is the conjoined elements from the userInput list</param>
        private void signPercentageLogic(String result)
        {
            userInput.Clear();
            userInput.Add(result + "/100");
            textBox1.Clear();
            textBox1.Text += result + "%";
        }

        /// <summary>
        /// Performs the textbox inverse display logic.
        /// </summary>
        /// <param name="result">result is the conjoined elements from the userInput list</param>
        private void signInverseLogic(String result)
        {
            userInput.Clear();
            userInput.Add("1/" + result);
            textBox1.Clear();
            textBox1.Text += "1/" + result;
        }

        /// <summary>
        /// Performs the calculation logic based on  the button tag passed
        /// </summary>
        /// <param name="buttonTag">The tag from the button</param>
        private void calculationLogic(String buttonTag)
        {
            // displays the button tag of the clicked button into the textbox after initialization
            if (textBox1.Text == "0" && userInput.Count() == 0)
            {
                textBox1.Clear();
                textBox1.Text += buttonTag;
                userInput.Add(buttonTag);
            }
            // displays in the textbox the button tag of the clicked button when textbox contains a prompt
            else if (textBox1.Text.Equals("Please enter a valid expression!"))
            {
                textBox1.Clear();
                userInput.Clear();
                textBox1.Text = buttonTag;
                userInput.Add(buttonTag);
            }
            // displays in the textbox the percent sign after the number that was retrieved from memory
            else if (buttonTag == "%" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstbuttonTagNumber = string.Join("", memory.ToArray());
                signPercentageLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox
            else if (buttonTag == "%")
            {
                string veryFirstbuttonTagNumber = string.Join("", userInput.ToArray());
                signPercentageLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox "1/" before the number that was retrieved from memory
            else if (buttonTag == "invr" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstbuttonTagNumber = string.Join("", memory.ToArray());
                signInverseLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox
            else if (buttonTag == "invr")
            {
                string veryFirstbuttonTagNumber = string.Join("", userInput.ToArray());
                signInverseLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox "SQRT(x)" where x is the number retrieved from memory
            else if (buttonTag == "SQRT" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstbuttonTagNumber = string.Join("", memory.ToArray());
                signSquareRootLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox
            else if (buttonTag == "SQRT")
            {
                string veryFirstbuttonTagNumber = string.Join("", userInput.ToArray());
                signSquareRootLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox "SQR(x)" where x is the number retrieved from memory
            else if (buttonTag == "SQR" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                string veryFirstbuttonTagNumber = string.Join("", memory.ToArray());
                signSquareLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox
            else if (buttonTag == "SQR")
            {
                string veryFirstbuttonTagNumber = string.Join("", userInput.ToArray());
                signSquareLogic(veryFirstbuttonTagNumber);
            }
            // displays in the textbox "-" in front if the number (coming from memory) in the textbox is positive 
            else if (buttonTag == "+/-" && memory.Count() == 1 && textBox1.Text.Equals(string.Join("", memory.ToArray())))
            {
                var result = string.Join("", memory.ToArray());
                signSwitchLogic(result);
            }
            // displays in the textbox "-" in front if the number (coming from userInput) in the textbox is positive
            else if (buttonTag == "+/-" && userInput.Count() >= 1)
            {
                var result = string.Join("", userInput.ToArray());
                signSwitchLogic(result);
            }
            // adds the digits or other four operators to the textbox
            else
            {
                textBox1.Text += buttonTag;
                userInput.Add(buttonTag);
            }
        }

        /// <summary>
        /// This method takes in button presses and calls their appropriate functions.
        /// </summary>
        /// <param name="sender">Button Press</param>
        /// <param name="e">Event Arguments</param>
        private void buttonArithmetic_Click(object sender, EventArgs e)
        {
            // retrieve the tag id for each button
            string buttonTag = (string)((Button)sender).Tag;

            // check the calculator's power state
            if (allEnabled == true)
            {
                if (buttonTag.Equals("M+")) 
                {
                    // evaluate the response and add it to memory
                    evaluateFunction(sender, e);
                }
                else if (buttonTag.Equals("Mr"))
                {
                    // check if memory is empty
                    if (memory.Count() > 0)
                    {
                        // populate the textbox with the value that's currently in memory
                        textBox1.Text = memory.First();
                    }
                    else
                    {
                        textBox1.Text = "0";
                    }
                }
                else if (buttonTag.Equals("Mc"))
                {
                    // clear the memory if the MC button is pressed
                    memory.Clear();
                }
                else
                {
                    // otherwise if all cases fail, add the button press into an array to be processed
                    calculationLogic(buttonTag);
                }
            } 
        }

        /// <summary>
        /// This method powers on or powers off the calculator.
        /// </summary>
        /// <param name="sender">Button Press</param>
        /// <param name="e">Event Arguments</param>
        private void onOff(object sender, EventArgs e)
        {

            if (allEnabled == true)
            {
                // turn the calculator off
                allEnabled = false;
            }
            else
            {
                // turn the calculator on
                allEnabled = true;
                textBox1.Text = "0";
            }
        }

        /// <summary>
        /// This method deletes a number one at a time from the calculator display.
        /// </summary>
        /// <param name="sender">Button Press</param>
        /// <param name="e">Event Arguments</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // get the current input from the calculator display
            string input = textBox1.Text;

            if (input.Length > 0)
            {
                // remove one character from the calculator display
                textBox1.Text = input.Substring(0, input.Length - 1);
                // clear the user input array
                userInput.Clear();
                // add the modified calculator display back into the user input
                userInput.Add(textBox1.Text);
            }
        }

        /// <summary>
        /// This method clears the calculator display.
        /// </summary>
        /// <param name="sender">Button Press</param>
        /// <param name="e">Event Arguments</param>
        private void buttonC_Click(object sender, EventArgs e)
        {
            // reset the calculator display and the userinput array
            textBox1.Text = "";
            userInput.Clear();
            userInput.Add(textBox1.Text);
        }

        /// <summary>
        /// Parses the equation from the calculator display and evaluates the result.
        /// </summary>
        /// <param name="sender">Button Press</param>
        /// <param name="e">Event Arguments</param>
        private void evaluateFunction(object sender, EventArgs e)
        {
            // parse the numbers in the userInput array into a string
            var result = string.Join("", userInput.ToArray());

            // evaluate the result
            var calculation = Calculator.Calculate(result);

            string toSave = (string)((Button)sender).Tag;

            if (calculation.IsValid)
            {
                // set calculator display to the value from the expression
                textBox1.Text = calculation.Result.ToString();
                if (toSave.Equals("M+"))
                {
                    // if memory is empty and the M+ button has been added, add the result of the calculation
                    // to the memory
                    if (memory.Count() == 0)
                    {
                        memory.Add(calculation.Result.ToString());
                    }
                    // otherwise, add what's in the textbox into the memory so the M+ operation can be formed.
                    else
                    {
                        memory.Add("+");
                        memory.Add(textBox1.Text);
                    }

                    // join the expression that's currently in the memory into a string
                    var memString = string.Join("", memory.ToArray());

                    // evaluate the expression from the memory
                    var memCalc = Calculator.Calculate(memString);

                    // clear the memory so the final result from the memory can be added into the memory
                    memory.Clear();
                    memory.Add(memCalc.Result.ToString());
                }
                if (!toSave.Equals("M+"))
                {
                    // otherwise, evaluate the expression from the calcuator display
                    userInput.Clear();
                    userInput.Add(calculation.Result.ToString());
                }
            }
            // if the Calculator class can't properly handle the expression to be evaluated, show this on the screen
            else
            {
                textBox1.Text = "Please enter a valid expression!";
            }
        }     
    }
}
