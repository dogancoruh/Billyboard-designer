using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billyboard.Controls.Designer.Data;
using Newtonsoft.Json.Linq;

namespace Billyboard.Controls.Designer.Core
{
    public class VisualLayoutElementSerializer : LayoutElementSerializer
    {
        public VisualLayoutElementSerializer(string typeName) : base(typeName)
        {

        }

        public override JObject Serialize(LayoutElement element)
        {
            return null;
        }

        public override LayoutElement Deserialize(JObject jObject)
        {
            return null;
        }

        protected override void Deserialize(JObject jObject, LayoutElement element)
        {
            base.Deserialize(jObject, element);

            
        }
    }
}
