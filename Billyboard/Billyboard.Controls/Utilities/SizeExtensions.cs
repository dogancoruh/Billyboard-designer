using System.Drawing;

namespace System
{
    public static class SizeExtensions
    {
        public static Size Add(this Size size_, Size size)
        {
            return new Size(size_.Width + size.Width, size_.Height + size.Height);
        }

        public static Size AddWidth(this Size size, int width)
        {
            return new Size(size.Width + width, size.Height);
        }

        public static Size AddHeight(this Size size, int height)
        {
            return new Size(size.Width, size.Height + height);
        }

        public static Size Subtract(this Size size_, Size size)
        {
            return new Size(size_.Width - size.Width, size_.Height - size.Height);
        }

        public static Size SubtractWidth(this Size size, int width)
        {
            return new Size(size.Width - width, size.Height);
        }

        public static Size SubtractHeight(this Size size, int height)
        {
            return new Size(size.Width, size.Height - height);
        }

        public static Size Multiply(this Size size, int value)
        {
            return new Size(size.Width * value, size.Height * value);
        }

        public static Size Multiply(this Size size, double value)
        {
            return new Size((int)(size.Width * value), (int)(size.Height * value));
        }

        public static Size Divide(this Size size, int value)
        {
            return new Size((int)(size.Width / value), (int)(size.Height / value));
        }

        public static Size Percent(this Size size, double percentage)
        {
            return new Size((int)(size.Width + (size.Width * percentage / 100)), (int)(size.Height + size.Height * percentage / 100));
        }

        public static Size Inflate(this Size size, int offset)
        {
            return new Size(size.Width + offset, size.Height + offset);
        }

        public static Size Deflate(this Size size, int offset)
        {
            return new Size(size.Width - offset, size.Height - offset);
        }

        public static Size Double(this Size size)
        {
            return new Size(size.Width * 2, size.Height * 2);
        }

        public static Size Half(this Size size)
        {
            return new Size(size.Width / 2, size.Height / 2);
        }

        public static double AspectRatio(this Size size)
        {
            return ((double)size.Width) / ((double)size.Height);
        }
    }
}
