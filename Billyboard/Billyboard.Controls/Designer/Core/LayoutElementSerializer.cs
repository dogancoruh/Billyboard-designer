using Billyboard.Controls.Designer.Data;
using Billyboard.Controls.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Core
{
    public abstract class LayoutElementSerializer
    {
        private string typeName;

        public string TypeName
        {
            get { return typeName; }
        }

        public LayoutElementSerializer(string typeName)
        {
            this.typeName = typeName;
        }

        public abstract JObject Serialize(LayoutElement element);
        public abstract LayoutElement Deserialize(JObject jObject);

        protected virtual void Deserialize(JObject jObject, LayoutElement element)
        {
            JObject jObjectLocation = (JObject)jObject["location"];
            int x = JObjectHelper.GetInt32(jObject, "x", 0);
            int y = JObjectHelper.GetInt32(jObject, "y", 0);
            element.Location = new Point(x, y);

            JObject jObjectSize = (JObject)jObject["size"];
            int width = JObjectHelper.GetInt32(jObject, "width", 0);
            int height = JObjectHelper.GetInt32(jObject, "height", 0);
            element.Size = new Size(width, height);
        }
    }
}
