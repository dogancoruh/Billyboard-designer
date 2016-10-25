using System.Drawing;

namespace System
{
    public static class RectangleExtensions
    {
        public static Rectangle AddX(this Rectangle rectangle, int x)
        {
            return new Rectangle(rectangle.Location.AddX(x), rectangle.Size);
        }

        public static Rectangle AddY(this Rectangle rectangle, int y)
        {
            return new Rectangle(rectangle.Location.AddY(y), rectangle.Size);
        }

        public static Rectangle SubtractX(this Rectangle rectangle, int x)
        {
            return new Rectangle(rectangle.Location.SubtractX(x), rectangle.Size);
        }

        public static Rectangle SubtractY(this Rectangle rectangle, int y)
        {
            return new Rectangle(rectangle.Location.SubtractY(y), rectangle.Size);
        }

        public static Rectangle AddWidth(this Rectangle rectangle, int width)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.AddWidth(width));
        }

        public static Rectangle AddHeight(this Rectangle rectangle, int height)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.AddHeight(height));
        }

        public static Rectangle SubtractWidth(this Rectangle rectangle, int width)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.SubtractWidth(width));
        }

        public static Rectangle SubtractHeight(this Rectangle rectangle, int height)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.SubtractHeight(height));
        }

        public static Rectangle Multiply(this Rectangle rectangle, int value)
        {
            return new Rectangle(rectangle.Location.Multiply(value), rectangle.Size.Multiply(value));
        }

        public static Rectangle Multiply(this Rectangle rectangle, double value)
        {
            return new Rectangle(rectangle.Location.Multiply(value), rectangle.Size.Multiply(value));
        }

        public static Rectangle Divide(this Rectangle rectangle, int value)
        {
            return new Rectangle(rectangle.Location.Divide(value), rectangle.Size.Divide(value));
        }

        public static Rectangle Percent(this Rectangle rectangle, double percentage)
        {
            return new Rectangle(rectangle.Location.Percent(percentage), rectangle.Size.Percent(percentage));
        }

        public static Rectangle Double(this Rectangle rectangle)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.Double());
        }

        public static Rectangle Half(this Rectangle rectangle)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.Half());
        }

        public static Rectangle AddToLocation(this Rectangle rectangle, Point point)
        {
            return new Rectangle(rectangle.Location.Add(point), rectangle.Size);
        }

        public static Rectangle AddToLocation(this Rectangle rectangle, Size size)
        {
            return new Rectangle(rectangle.Location.Add(size), rectangle.Size);
        }

        public static Rectangle AddToSize(this Rectangle rectangle, int x, int y)
        {
            return AddToSize(rectangle, new Size(x, y));
        }

        public static Rectangle AddToSize(this Rectangle rectangle, Size size)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.Add(size));
        }

        public static Rectangle SubtractFromLocation(this Rectangle rectangle, Point point)
        {
            return new Rectangle(rectangle.Location.Subtract(point), rectangle.Size);
        }

        public static Rectangle SubtractFromLocation(this Rectangle rectangle, Size size)
        {
            return new Rectangle(rectangle.Location.Subtract(size), rectangle.Size);
        }

        public static Rectangle SubtractFromSize(this Rectangle rectangle, int x, int y)
        {
            return SubtractFromSize(rectangle, new Size(x, y));
        }

        public static Rectangle SubtractFromSize(this Rectangle rectangle, Size size)
        {
            return new Rectangle(rectangle.Location, rectangle.Size.Subtract(size));
        }

        public static Rectangle Inflate(this Rectangle rectangle, int offset)
        {
            return new Rectangle(rectangle.Location.Deflate(offset), rectangle.Size.Inflate(offset * 2));
        }

        public static Rectangle Deflate(this Rectangle rectangle, int offset)
        {
            return new Rectangle(rectangle.Location.Inflate(offset), rectangle.Size.Deflate(offset * 2));
        }
    }
}
