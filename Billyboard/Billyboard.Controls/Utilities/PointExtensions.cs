using System.Drawing;

namespace System
{
    public static class PointExtensions
    {
        public static Point Add(this Point p, Point point)
        {
            return new Point(p.X + point.X, p.Y + point.Y); 
        }

        public static Point Add(this Point p, int x, int y)
        {
            return new Point(p.X + x, p.Y + y);
        }

        public static Point Add(this Point p, Size size)
        {
            return new Point(p.X + size.Width, p.Y + size.Height);
        }

        public static Point AddX(this Point p, int value)
        {
            return new Point(p.X + value, p.Y);
        }

        public static Point SubtractX(this Point p, int value)
        {
            return new Point(p.X - value, p.Y);
        }

        public static Point AddY(this Point p, int value)
        {
            return new Point(p.X, p.Y + value);
        }

        public static Point SubtractY(this Point p, int value)
        {
            return new Point(p.X, p.Y - value);
        }

        public static Point Subtract(this Point p, int x, int y)
        {
            return new Point(p.X - x, p.Y - y);
        }

        public static Point Subtract(this Point p, Point point)
        {
            return new Point(p.X - point.X, p.Y - point.Y);
        }

        public static Point Subtract(this Point p, Size size)
        {
            return new Point(p.X - size.Width, p.Y - size.Height);
        }

        public static Point Multiply(this Point point, int value)
        {
            return new Point(point.X * value, point.Y * value);
        }

        public static Point Multiply(this Point point, double value)
        {
            return new Point((int)(point.X * value), (int)(point.Y * value));
        }

        public static Point Divide(this Point point, int value)
        {
            return new Point(point.X / value, point.Y / value);
        }

        public static Point Divide(this Point point, double value)
        {
            return new Point((int)(point.X / value), (int)(point.Y / value));
        }

        public static double Distance(this Point p, Point point)
        {
            return Math.Sqrt(Math.Pow(p.X - point.X, 2) + Math.Pow(p.Y - point.Y, 2));
        }

        public static Point Percent(this Point point, double percentage)
        {
            return new Point((int)(point.X + (point.X * percentage / 100)), (int)(point.Y + (point.Y * percentage / 100)));
        }

        public static Point Inflate(this Point point, int value)
        {
            return new Point(point.X + value, point.Y + value);
        }

        public static Point Deflate(this Point point, int value)
        {
            return new Point(point.X - value, point.Y - value);
        }

        public static Point Inflate(this Point point, Size size)
        {
            return new Point(point.X + size.Width, point.Y + size.Height);
        }

        public static Point Deflate(this Point point, Size size)
        {
            return new Point(point.X - size.Width, point.Y - size.Height);
        }

        public static Point Double(this Point point, Size size)
        {
            return new Point(point.X * 2, point.Y * 2);
        }

        public static Point Half(this Point point)
        {
            return new Point(point.X / 2, point.Y / 2);
        }

        public static Size ToSize(this Point point)
        {
            return new Size(point.X, point.Y);
        }
    }
}
