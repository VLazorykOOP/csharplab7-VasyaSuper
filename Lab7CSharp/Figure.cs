using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace figure
{
    public abstract class Figure
    {
        public abstract void Draw(PictureBox pictureBox);

        public abstract void Move(int deltaX, int deltaY);

        public abstract void ChangeColors(Color newBorderColor, Color newFillColor, PictureBox pictureBox);
    }

    public class RoundedRectangle : Figure
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private int cornerRadius;
        private Color borderColor;
        private Color fillColor;

        public void SetValues(int x, int y, int width, int height, int cornerRadius, Color borderColor, Color fillColor)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.cornerRadius = cornerRadius;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
        }
        public override void Draw(PictureBox pictureBox)
        {
            Bitmap bitmap;
            Graphics graphics;

            if (pictureBox.Image == null)
            {
                bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                graphics = Graphics.FromImage(bitmap);
            }
            else
            {
                bitmap = new Bitmap((Bitmap)pictureBox.Image);
                graphics = Graphics.FromImage(bitmap);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectangle = new Rectangle(x, y, width, height);
            int diameter = 2 * cornerRadius;

            if (cornerRadius <= 0)
            {
                graphics.FillRectangle(new SolidBrush(fillColor), rectangle);
            }
            else if (diameter >= width && diameter >= height)
            {
                graphics.FillEllipse(new SolidBrush(fillColor), rectangle);
            }
            else
            {
                GraphicsPath path = CreateRoundedRectangle(rectangle, cornerRadius);
                graphics.FillPath(new SolidBrush(fillColor), path);

                Pen borderPen = new Pen(borderColor, 3);
                graphics.DrawPath(borderPen, path);
            }

            pictureBox.Image = bitmap;
        }
        private GraphicsPath CreateRoundedRectangle(Rectangle rectangle, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = 2 * cornerRadius;

            if (cornerRadius <= 0)
            {
                path.AddRectangle(rectangle);
            }
            else if (diameter >= rectangle.Width && diameter >= rectangle.Height)
            {
                path.AddEllipse(rectangle);
            }
            else
            {
                path.AddArc(rectangle.X, rectangle.Y, diameter, diameter, 180, 90);
                path.AddArc(rectangle.X + rectangle.Width - diameter, rectangle.Y, diameter, diameter, 270, 90);
                path.AddArc(rectangle.X + rectangle.Width - diameter, rectangle.Y + rectangle.Height - diameter, diameter, diameter, 0, 90);
                path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();
            }

            return path;
        }
        public override void ChangeColors(Color newBorderColor, Color newFillColor, PictureBox pictureBox)
        {
            borderColor = newBorderColor;
            fillColor = newFillColor;

            Draw(pictureBox);
        }
        public override void Move(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
        }
    }

    public class Square : Figure
    {
        private int x;
        private int y;
        private int side;
        private Color borderColor;
        private Color fillColor;

        public void SetValues(int x, int y, int side, Color borderColor, Color fillColor)
        {
            this.x = x;
            this.y = y;
            this.side = side;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
        }
        public override void Draw(PictureBox pictureBox)
        {
            Bitmap bitmap;
            Graphics graphics;

            if (pictureBox.Image == null)
            {
                bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                graphics = Graphics.FromImage(bitmap);
            }
            else
            {
                bitmap = new Bitmap((Bitmap)pictureBox.Image);
                graphics = Graphics.FromImage(bitmap);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Point topLeft = new Point(x, y);
            Point topRight = new Point(x + side, y);
            Point bottomRight = new Point(x + side, y + side);
            Point bottomLeft = new Point(x, y + side);

            Point[] points = { topLeft, topRight, bottomRight, bottomLeft };

            SolidBrush fillBrush = new SolidBrush(fillColor);
            Pen borderPen = new Pen(borderColor, 3);

            graphics.FillPolygon(fillBrush, points);
            graphics.DrawPolygon(borderPen, points);

            pictureBox.Image = bitmap;
        }
        public override void ChangeColors(Color newBorderColor, Color newFillColor, PictureBox pictureBox)
        {
            borderColor = newBorderColor;
            fillColor = newFillColor;

            Draw(pictureBox);
        }
        public override void Move(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
        }
    }

    public class Ellipse : Figure
    {
        private int x;
        private int y;
        private int height;
        private int width;
        private Color borderColor;
        private Color fillColor;

        public void SetValues(int x, int y, int height, int width, Color borderColor, Color fillColor)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
        }
        public override void Draw(PictureBox pictureBox)
        {
            Bitmap bitmap;
            Graphics graphics;

            if (pictureBox.Image == null)
            {
                bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                graphics = Graphics.FromImage(bitmap);
            }
            else
            {
                bitmap = new Bitmap((Bitmap)pictureBox.Image);
                graphics = Graphics.FromImage(bitmap);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;

            SolidBrush fillBrush = new SolidBrush(fillColor);
            Pen borderPen = new Pen(borderColor, 3); 
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillEllipse(fillBrush, x - width, y - height, width * 2, height * 2);
            graphics.DrawEllipse(borderPen, x - width, y - height, width * 2, height * 2);

            pictureBox.Image = bitmap;
        }
        public override void Move(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
        }
        public override void ChangeColors(Color newBorderColor, Color newFillColor, PictureBox pictureBox)
        {
            borderColor = newBorderColor;
            fillColor = newFillColor;

            Draw(pictureBox);
        }
    }

    public class Arc : Figure
    {
        private int x;
        private int y;
        private int radius;
        private float startAngle;
        private float endAngle;
        private Color borderColor;

        public void SetValues(int x, int y, int radius, float startAngle, float endAngle, Color borderColor)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.startAngle = startAngle;
            this.endAngle = endAngle;
            this.borderColor = borderColor;
        }
        public override void Draw(PictureBox pictureBox)
        {
            Bitmap bitmap;
            Graphics graphics;

            if (pictureBox.Image == null)
            {
                bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                graphics = Graphics.FromImage(bitmap);
            }
            else
            {
                bitmap = new Bitmap((Bitmap)pictureBox.Image);
                graphics = Graphics.FromImage(bitmap);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;

            Pen borderPen = new Pen(borderColor, 3);
            graphics.DrawArc(borderPen, x - radius, y - radius, radius * 2, radius * 2, startAngle, endAngle - startAngle);

            pictureBox.Image = bitmap;
        }
        public override void Move(int deltaX, int deltaY)
        {
            x += deltaX;
            y += deltaY;
        }
        public override void ChangeColors(Color newBorderColor, Color newFillColor, PictureBox pictureBox)
        {
            borderColor = newBorderColor;

            Draw(pictureBox);
        }
    }
}