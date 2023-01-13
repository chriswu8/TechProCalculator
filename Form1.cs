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
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics gfx = Graphics.FromImage(pictureBox1.Image);
                Point point = new Point(0, 0);
                Image mathImage = Image.FromFile(Application.StartupPath + "/Resources/bcit.png");
                gfx.DrawImage(mathImage, point );
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
    }
}
