using Billyboard.Controls.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    public static class GraphicsExtensions
    {
        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rectangle, int radius)
        {
            graphics.DrawPath(pen, GraphicsHelper.GetRoundedPath(rectangle, radius));
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle rectangle, int radius)
        {
            graphics.FillPath(brush, GraphicsHelper.GetRoundedPath(rectangle, radius));
        }
    }
}
