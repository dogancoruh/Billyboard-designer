using Billyboard.Controls.Designer.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Core
{
    public class LayoutLoader
    {
        public Layout Load(string fileName)
        {
            string content = File.ReadAllText(fileName, Encoding.UTF8);
            JObject jObject = JObject.Parse(content); ;

            Layout layout = new Layout();

            LayoutElementFactory elementFactory = new LayoutElementFactory();

            JArray jArrayElements = (JArray)jObject["elements"];
            foreach (JObject jObjectElement in jArrayElements)
            {
                LayoutElement element = elementFactory.Deserialize(jObjectElement);
            }

            return layout;
        }

        public void Save(string fileName, Layout layout)
        {
            JObject jObject = new JObject();

            JArray jArrayElements = new JArray();
            foreach (LayoutElement element in layout.Elements)
            {
                JObject jObjectElement = new JObject();

            }
        }
    }
}
