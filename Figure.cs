namespace figure
{
    public abstract class Figure
    {
        public abstract void Draw(PictureBox pictureBox);

        public abstract void Move(int deltaX, int deltaY);
    }

    public class RoundedRectangle : Figure
    {
        private int width;
        private int height;
        private int cornerRadius;
        private Color borderColor;
        private Color fillColor;

        public void SetValues(int width, int height, int cornerRadius, Color borderColor, Color fillColor)
        {
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

            // Випадкові координати
            Random random = new Random();
            int x = random.Next(0, pictureBox.Width - width);
            int y = random.Next(0, pictureBox.Height - height);

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

                // Малюємо контур прямокутника зі скругленими кутами
                Pen borderPen = new Pen(borderColor, 3); // Змінити ширину пера на 2 пікселі
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

        public override void Move(int deltaX, int deltaY)
        {
            // Логіка переміщення прямокутника з заокругленими кутами
        }
        // Додаткові методи та поля для прямокутника з заокругленими кутами
    }

    public class Rhombus : Figure
    {
        private int diagonal1;
        private int diagonal2;
        private Color borderColor;
        private Color fillColor;

        public void SetValues(int diagonal1, int diagonal2, Color borderColor, Color fillColor)
        {
            this.diagonal1 = diagonal1;
            this.diagonal2 = diagonal2;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
        }

        public override void Draw(PictureBox pictureBox)
        {
            // Логіка малювання ромба
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

            // Випадкові координати
            Random random = new Random();
            int x = random.Next(0, pictureBox.Width - diagonal1);
            int y = random.Next(0, pictureBox.Height - diagonal2);

            // Обчислюємо координати вершин ромба
            int halfDiagonal1 = diagonal1 / 2;
            int halfDiagonal2 = diagonal2 / 2;

            Point topLeft = new Point(x + halfDiagonal1, y);
            Point topRight = new Point(x + diagonal1, y + halfDiagonal2);
            Point bottomRight = new Point(x + halfDiagonal1, y + diagonal2);
            Point bottomLeft = new Point(x, y + halfDiagonal2);

            // Створюємо масив точок вершин ромба
            Point[] points = { topLeft, topRight, bottomRight, bottomLeft };

            // Малюємо ромб
            SolidBrush fillBrush = new SolidBrush(fillColor);
            Pen borderPen = new Pen(borderColor, 3);

            graphics.FillPolygon(fillBrush, points);
            graphics.DrawPolygon(borderPen, points);

            pictureBox.Image = bitmap;
        }

        public override void Move(int deltaX, int deltaY)
        {
            // Логіка переміщення ромба
        }

        // Додаткові методи та поля для ромба
    }

    public class Circle : Figure
    {
        private int radius;
        private Color borderColor;
        private Color fillColor;

        public void SetValues(int radius, Color borderColor, Color fillColor)
        {
            this.radius = radius;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
        }

        public override void Draw(PictureBox pictureBox)
        {
            // Логіка малювання кола
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

            // Отримання розмірів PictureBox
            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;

            // Випадкові координати
            Random random = new Random();
            int x = random.Next(radius, pictureBoxWidth - radius);
            int y = random.Next(radius, pictureBoxHeight - radius);

            // Малювання кола
            SolidBrush fillBrush = new SolidBrush(fillColor);
            Pen borderPen = new Pen(borderColor, 2); // Товщина контуру - 2 пікселі
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillEllipse(fillBrush, x - radius, y - radius, radius * 2, radius * 2);
            graphics.DrawEllipse(borderPen, x - radius, y - radius, radius * 2, radius * 2);

            // Оновлення PictureBox з новим зображенням
            pictureBox.Image = bitmap;
        }

        public override void Move(int deltaX, int deltaY)
        {
            // Логіка переміщення кола
        }

        // Додаткові методи та поля для кола
    }

    public class Arc : Figure
    {
        private int radius;
        private float startAngle; // У градусах
        private float endAngle; // У градусах
        private Color borderColor;

        public void SetValues(int radius, float startAngle, float endAngle, Color borderColor)
        {
            this.radius = radius;
            this.startAngle = startAngle;
            this.endAngle = endAngle;
            this.borderColor = borderColor;
        }

        public override void Draw(PictureBox pictureBox)
        {
            // Логіка малювання дуги
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

            // Отримання розмірів PictureBox
            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;

            // Генерація випадкових координат
            Random random = new Random();
            int startX = random.Next(radius, pictureBoxWidth - radius);
            int startY = random.Next(radius, pictureBoxHeight - radius);

            // Малювання дуги
            Pen borderPen = new Pen(borderColor, 3);
            graphics.DrawArc(borderPen, startX - radius, startY - radius, radius * 2, radius * 2, startAngle, endAngle - startAngle);

            // Оновлення PictureBox з новим зображенням
            pictureBox.Image = bitmap;
        }

        public override void Move(int deltaX, int deltaY)
        {
            // Логіка переміщення дуги
        }

        // Додаткові методи та поля для дуги
    }
}