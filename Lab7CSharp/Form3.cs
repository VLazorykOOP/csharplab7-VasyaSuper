using System;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

using figure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab7CSharp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private Color borderColor = Color.Coral;
        private Color fillColor = Color.DarkKhaki;
        private Figure lastAddedFigure;

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;

                borderColor = selectedColor;

                this.pictureBox2.BackColor = selectedColor;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;

                fillColor = selectedColor;

                this.pictureBox3.BackColor = selectedColor;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Int32.Parse(textBox1.Text) + 1).ToString();

            string widthStrRec = textBox2.Text;
            string heightStrRec = textBox3.Text;
            string cornerRadiusStrRec = textBox4.Text;

            string widthStrEllips = textBox5.Text;
            string heightStrEllips = textBox6.Text;

            string radiusStrArc = textBox7.Text;
            string startAngleStrArc = textBox8.Text;
            string endAngleStrArc = textBox9.Text;

            string sideStrSquare = textBox10.Text;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            int widthRec = Int32.Parse(widthStrRec);
            int heightRec = Int32.Parse(heightStrRec);
            int cornerRadiusRec = Int32.Parse(cornerRadiusStrRec);

            int widthEllips = Int32.Parse(widthStrEllips);
            int heightEllips = Int32.Parse(heightStrEllips);

            int radiusArc = Int32.Parse(radiusStrArc);
            float startAngleArc = Single.Parse(startAngleStrArc);
            float endAngleArc = Single.Parse(endAngleStrArc);

            int sideSquare = Int32.Parse(sideStrSquare);

            Square square = new Square();
            RoundedRectangle rectangle = new RoundedRectangle();
            Ellipse ellipse = new Ellipse();
            Arc arc = new Arc();

            if (radioButton1.Checked)
            {
                Random random = new Random();
                int x = random.Next(0, pictureBox1.Width - widthRec);
                int y = random.Next(0, pictureBox1.Height - heightRec);

                rectangle.SetValues(x, y, widthRec, heightRec, cornerRadiusRec, borderColor, fillColor);
                rectangle.Draw(pictureBox1);
                lastAddedFigure = rectangle;
    }
            else if (radioButton2.Checked)
            {
                Random random = new Random();
                int x = random.Next(0, pictureBox1.Width - widthEllips);
                int y = random.Next(0, pictureBox1.Height - heightEllips);

                ellipse.SetValues(x, y, heightEllips, widthEllips, borderColor, fillColor);
                ellipse.Draw(pictureBox1);
                lastAddedFigure = ellipse;
            }
            else if (radioButton3.Checked)
            {
                Random random = new Random();
                int startX = random.Next(radiusArc, pictureBox1.Width - radiusArc);
                int startY = random.Next(radiusArc, pictureBox1.Height - radiusArc);

                arc.SetValues(startX, startY, radiusArc, startAngleArc, endAngleArc, borderColor);
                arc.Draw(pictureBox1);
                lastAddedFigure = arc;
            }
            else if (radioButton4.Checked)
            {
                Random random = new Random();
                int x = random.Next(0, pictureBox1.Width - sideSquare);
                int y = random.Next(0, pictureBox1.Height - sideSquare);

                square.SetValues(x, y, sideSquare, borderColor, fillColor);
                square.Draw(pictureBox1);
                lastAddedFigure = square;
            }
        }
        private void MoveLastAddedFigure(int deltaX, int deltaY)
        {
            if (lastAddedFigure != null)
            {
                lastAddedFigure.ChangeColors(Color.Khaki, Color.Khaki, pictureBox1);
                lastAddedFigure.Move(deltaX, deltaY);
                lastAddedFigure.ChangeColors(borderColor, fillColor, pictureBox1);
                lastAddedFigure.Draw(pictureBox1);
                pictureBox1.Refresh();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MoveLastAddedFigure(0, -10);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            MoveLastAddedFigure(0, 10);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MoveLastAddedFigure(-10, 0);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            MoveLastAddedFigure(10, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            pictureBox1.Image = null;
        }
    }
}
