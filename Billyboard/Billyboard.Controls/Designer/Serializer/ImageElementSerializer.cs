using Billyboard.Controls.Designer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billyboard.Controls.Designer.Data;
using Newtonsoft.Json.Linq;

namespace Billyboard.Controls.Designer.Serializer
{
    public class ImageElementSerializer : LayoutElementSerializer
    {
        public ImageElementSerializer() : base("image")
        {

        }

        public override JObject Serialize(LayoutElement element)
        {
            return null;
        }

        public override LayoutElement Deserialize(JObject jObject)
        {
            ImageElement imageElement = new ImageElement();

            base.Deserialize(jObject, imageElement);



            return imageElement;
        }
    }
}
