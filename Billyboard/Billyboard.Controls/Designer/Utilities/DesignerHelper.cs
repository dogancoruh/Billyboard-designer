using Billyboard.Controls.Designer.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billyboard.Controls.Utilities;
using System.Windows.Forms;

namespace Billyboard.Controls.Designer.Utilities
{
    public enum TransformHandleType
    {
        None,
        All,
        OnlyCorners
    }

    public enum TransformHandle
    {
        None,
        TopLeft,
        TopCenter,
        TopRight,
        Left,
        Right,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public class DesignerHelper
    {
        public const int HANDLE_WIDTH = 8;
        public const int HANDLE_HEIGHT = 8;

        public static void DrawTransformHandles(Graphics graphics, LayoutElement element, LayoutProperties layoutProperties, TransformHandleType handleType)
        {
            Point elementLocation = element.Location.Multiply(layoutProperties.ZoomRatio);
            elementLocation = elementLocation.Add(layoutProperties.DesignAreaLocation);
            elementLocation = elementLocation.Subtract(layoutProperties.ViewportLocation);

            Size elementSize = element.Size;
            elementSize = elementSize.Multiply(layoutProperties.ZoomRatio);

            Pen penRectangle = new Pen(Color.Silver);

            graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation, elementSize), 1);

            Pen penHandle = new Pen(Color.Black);
            Brush brushHandle = new SolidBrush(Color.White);

            Size handleSize = new Size(HANDLE_WIDTH, HANDLE_HEIGHT);

            if (handleType == TransformHandleType.All || handleType == TransformHandleType.OnlyCorners)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()), handleSize), 2);
            }

            if (handleType == TransformHandleType.All)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width / 2), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width / 2), handleSize), 2);
            }

            if (handleType == TransformHandleType.All || handleType == TransformHandleType.OnlyCorners)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width), handleSize), 2);
            }

            if (handleType == TransformHandleType.All)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddY(elementSize.Height / 2), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddY(elementSize.Height / 2), handleSize), 2);
            }

            if (handleType == TransformHandleType.All)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width).AddY(elementSize.Height / 2), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width).AddY(elementSize.Height / 2), handleSize), 2);
            }

            if (handleType == TransformHandleType.All || handleType == TransformHandleType.OnlyCorners)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddY(elementSize.Height), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddY(elementSize.Height), handleSize), 2);
            }

            if (handleType == TransformHandleType.All)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width / 2).AddY(elementSize.Height), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width / 2).AddY(elementSize.Height), handleSize), 2);
            }
            
            if (handleType == TransformHandleType.All || handleType == TransformHandleType.OnlyCorners)
            {
                graphics.FillRoundedRectangle(brushHandle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width).AddY(elementSize.Height), handleSize), 2);
                graphics.DrawRoundedRectangle(penRectangle, new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width).AddY(elementSize.Height), handleSize), 2);
            }
        }

        public static TransformHandle GetTransformHandleType(LayoutElement element, LayoutProperties layoutProperties, Point location)
        {
            Point elementLocation = element.Location.Multiply(layoutProperties.ZoomRatio);
            elementLocation = elementLocation.Add(layoutProperties.DesignAreaLocation);
            elementLocation = elementLocation.Subtract(layoutProperties.ViewportLocation);

            Size elementSize = element.Size;
            elementSize = elementSize.Multiply(layoutProperties.ZoomRatio);

            Size handleSize = new Size(HANDLE_WIDTH, HANDLE_HEIGHT);

            Rectangle rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.TopLeft;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width / 2), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.TopCenter;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.TopRight;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddY(elementSize.Height / 2), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.Left;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width).AddY(elementSize.Height / 2), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.Right;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddY(elementSize.Height), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.BottomLeft;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width / 2).AddY(elementSize.Height), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.BottomCenter;

            rectangle = new Rectangle(elementLocation.Subtract(handleSize.Half()).AddX(elementSize.Width).AddY(elementSize.Height), handleSize);
            if (rectangle.Contains(location))
                return TransformHandle.BottomRight;

            return TransformHandle.None;
        }

        public static Cursor GetCursorForTransformHandle(TransformHandle handle)
        {
            switch (handle)
            {
                case TransformHandle.None:
                    return Cursors.Default;
                case TransformHandle.TopLeft:
                    return Cursors.SizeNWSE;
                case TransformHandle.TopCenter:
                    return Cursors.SizeNS;
                case TransformHandle.TopRight:
                    return Cursors.SizeNESW;
                case TransformHandle.Left:
                    return Cursors.SizeWE;
                case TransformHandle.Right:
                    return Cursors.SizeWE;
                case TransformHandle.BottomLeft:
                    return Cursors.SizeNESW;
                case TransformHandle.BottomCenter:
                    return Cursors.SizeNS;
                case TransformHandle.BottomRight:
                    return Cursors.SizeNWSE;
                default:
                    return Cursors.Default;
            }
        }

        public static bool ExceedsThreshold(Point pointA, Point pointB, double threshold)
        {
            return Math.Pow(pointA.X - pointB.Y, 2) + Math.Pow(pointA.Y - pointB.Y, 2) > threshold;
        }

        public static Rectangle GetRectangleFromTwoPoints(Point pointA, Point pointB)
        {
            int minimumX = 0;
            int minimumY = 0;
            int maximumX = 0;
            int maximumY = 0;

            if (pointA.X < pointB.X)
            {
                minimumX = pointA.X;
                maximumX = pointB.X;
            }
            else
            {
                minimumX = pointB.X;
                maximumX = pointA.X;
            }

            if (pointA.Y < pointB.Y)
            {
                minimumY = pointA.Y;
                maximumY = pointB.Y;
            }
            else
            {
                minimumY = pointB.Y;
                maximumY = pointA.Y;
            }

            return new Rectangle(minimumX, minimumY, maximumX - minimumX, maximumY - minimumY);
        }

        public static void SizeElement(LayoutElement layoutElement,
                                       TransformHandle transformHandle,
                                       Point interactionLocation,
                                       Size interactionSize,
                                       Point viewportLocation,
                                       Point designAreaDownLocation,
                                       Point designAreaMoveLocation)
        {
            switch (transformHandle)
            {
                case TransformHandle.None:
                    break;
                case TransformHandle.TopLeft:
                    break;
                case TransformHandle.TopCenter:
                    break;
                case TransformHandle.TopRight:
                    break;
                case TransformHandle.Left:
                    break;
                case TransformHandle.Right:
                    break;
                case TransformHandle.BottomLeft:
                    break;
                case TransformHandle.BottomCenter:
                    break;
                case TransformHandle.BottomRight:
                    layoutElement.Size = new Size(viewportLocation.X - designAreaMoveLocation.X - interactionLocation.X,
                                                  viewportLocation.Y - designAreaMoveLocation.Y - interactionLocation.Y);
                    break;
                default:
                    break;
            }
        }
    }
}
