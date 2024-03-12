using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        private ButtonBorderStyle borderStyle = ButtonBorderStyle.Solid;
        private Color borderColor = Color.Blue;

        public Form1()
        {
            InitializeComponent();

            panel1.BackColor = Color.Yellow;
            borderColor = Color.Red;
            borderStyle = ButtonBorderStyle.None;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle, borderColor, borderStyle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Ширина - 200, Висота 100")
            {
                panel1.Width = 200;
                panel1.Height = 100;
                panel1.Invalidate();
            }
            if (comboBox1.SelectedItem.ToString() == "Ширина - 400, Висота 400")
            {
                panel1.Width = 400;
                panel1.Height = 400;
                panel1.Invalidate();
            }
            if (comboBox1.SelectedItem.ToString() == "Ширина - 100, Висота 500")
            {
                panel1.Width = 100;
                panel1.Height = 500;
                panel1.Invalidate();
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Yellow")
            {
                panel1.BackColor = Color.Yellow;
            }
            if (comboBox3.SelectedItem.ToString() == "Red")
            {
                panel1.BackColor = Color.Red;
            }
            if (comboBox3.SelectedItem.ToString() == "Blue")
            {
                panel1.BackColor = Color.Blue;
            }
            if (comboBox3.SelectedItem.ToString() == "Orange")
            {
                panel1.BackColor = Color.Orange;
            }
            if (comboBox3.SelectedItem.ToString() == "White")
            {
                panel1.BackColor = Color.White;
                panel1.Invalidate();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "None")
            {
                borderStyle = ButtonBorderStyle.None;
                panel1.Invalidate();
            }
            if (comboBox2.SelectedItem.ToString() == "Dashed")
            {
                borderStyle = ButtonBorderStyle.Dashed;
                panel1.Invalidate();
            }
            if (comboBox2.SelectedItem.ToString() == "Dotted")
            {
                borderStyle = ButtonBorderStyle.Dotted;
                panel1.Invalidate();
            }
            if (comboBox2.SelectedItem.ToString() == "Solid")
            {
                borderStyle = ButtonBorderStyle.Solid;
                panel1.Invalidate();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            float coefficient;

            if (float.TryParse(text, out coefficient))
            {
                panel1.Width = (int)(panel1.Width * coefficient);
                panel1.Height = (int)(panel1.Height * coefficient);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Red")
            {
                borderColor = Color.Red;
                panel1.Invalidate();
            }
            if (comboBox4.SelectedItem.ToString() == "Blue")
            {
                borderColor = Color.Blue;
                panel1.Invalidate();
            }
            if (comboBox4.SelectedItem.ToString() == "Orange")
            {
                borderColor = Color.Orange;
                panel1.Invalidate();
            }
            if (comboBox4.SelectedItem.ToString() == "Yellow")
            {
                borderColor = Color.Yellow;
                panel1.Invalidate();
            }
        }
    }
}
