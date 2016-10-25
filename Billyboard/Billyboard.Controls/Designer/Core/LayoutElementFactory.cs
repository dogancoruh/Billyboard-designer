using Billyboard.Controls.Designer.Data;
using Billyboard.Controls.Designer.Serializer;
using Billyboard.Controls.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Core
{
    public class LayoutElementFactory
    {
        private List<LayoutElementSerializer> elementSerializers;

        public LayoutElementFactory()
        {
            elementSerializers = new List<LayoutElementSerializer>();
            elementSerializers.Add(new ImageElementSerializer());
        }

        public LayoutElement Deserialize(JObject jObjectElement)
        {
            string elementTypeName = JObjectHelper.GetString(jObjectElement, "typeName", string.Empty);
            if (!string.IsNullOrEmpty(elementTypeName))
            {
                foreach (LayoutElementSerializer elementSerializer in elementSerializers)
                {
                    if (elementSerializer.TypeName.Equals(elementTypeName))
                        return elementSerializer.Deserialize(jObjectElement);
                }

                throw new Exception("Element renderer not found for element type name!");
            }
            else
                throw new Exception("Element type name not found!");
        }
    }
}
