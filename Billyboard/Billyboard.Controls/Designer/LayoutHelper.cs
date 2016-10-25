using Billyboard.Controls.Designer.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer
{
    public class LayoutHelper
    {
        public static Rectangle GetBoundingBoxOfElements(List<LayoutElement> elements)
        {
            int minimumX = 0;
            int minimumY = 0;
            int maximumX = 0;
            int maximumY = 0;

            foreach (LayoutElement element in elements)
            {
                if (element.Location.X < minimumX)
                    minimumX = element.Location.X;

                if (element.Location.Y < minimumY)
                    minimumY = element.Location.Y;

                if (element.Location.X + element.Size.Width > maximumX)
                    maximumX = element.Location.X + element.Size.Width;

                if (element.Location.Y + element.Size.Height > maximumY)
                    maximumY = element.Location.Y + element.Size.Height;
            }

            return new Rectangle(minimumX, minimumY, maximumX - minimumX, maximumY - minimumY);
        }
    }
}
