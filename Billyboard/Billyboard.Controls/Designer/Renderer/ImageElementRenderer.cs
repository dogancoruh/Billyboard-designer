using Billyboard.Controls.Designer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Billyboard.Controls.Designer.Renderer
{
    public class ImageElementRenderer : LayoutElementRenderer
    {
        public override string TypeName
        {
            get
            {
                return "image";
            }
        }

        public override void Draw(LayoutElement element, Graphics graphics, LayoutProperties layoutProperties)
        {
            ImageElement imageElement = element as ImageElement;
            if (imageElement != null)
            {
                Point elementLocation = imageElement.Location.Multiply(layoutProperties.ZoomRatio);
                elementLocation = elementLocation.Add(layoutProperties.DesignAreaLocation);
                elementLocation = elementLocation.Subtract(layoutProperties.ViewportLocation);

                Size elementSize = imageElement.Size;
                elementSize = elementSize.Multiply(layoutProperties.ZoomRatio);

                graphics.DrawImage(imageElement.Image,
                                   new Rectangle(elementLocation, elementSize),
                                   new Rectangle(Point.Empty, imageElement.Image.Size),
                                   GraphicsUnit.Pixel);
            }
            else
                throw new Exception("Cannot cast to ImageElement");
        }
    }
}
