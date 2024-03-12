using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab7CSharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            colorDialog1.Color = Color.DarkKhaki;
            button3.BackColor = Color.Aqua;
            button4.BackColor = Color.Blue;
            button5.BackColor = Color.Olive;

            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 2;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Times New Roman", 8);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 8);

            plot();
        }

        Color lineColor = Color.Aqua;
        Color textAndGridColor = Color.Blue;
        Color backgroundColor = Color.Olive;

        private double xS = -2;
        private double xE = 0;
        private double step = 0.01;

        void plot()
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            series.Color = lineColor;
            series.BorderWidth = 3;

            double x = xS;
            while (x <= xE)
            {
                double y = (1 - x * x) * (x - 2);
                series.Points.AddXY(x, y);
                x += 0.01;
            }
            xE += step;

            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = textAndGridColor;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = textAndGridColor;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = textAndGridColor;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = textAndGridColor;
            chart1.ChartAreas[0].AxisX.LineColor = textAndGridColor;
            chart1.ChartAreas[0].AxisY.LineColor = textAndGridColor;

            chart1.ChartAreas[0].BackColor = backgroundColor;

            chart1.Series.Add(series);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            plot();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xS = -2;
            xE = 0;

            plot();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button3.BackColor = colorDialog1.Color;
            lineColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button4.BackColor = colorDialog1.Color;
            textAndGridColor = colorDialog1.Color;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button5.BackColor = colorDialog1.Color;
            backgroundColor = colorDialog1.Color;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2; 
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 2;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Times New Roman", 8);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 8);
            plot();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 4;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 4;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Times New Roman", 10);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 10);
            plot();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 6;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 6;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Times New Roman", 16);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 16);
            plot();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 8;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 8;
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Times New Roman", 32);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 32);
            plot();
        }
    }
}
