using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Data
{
    public class Layout
    {
        const int VERSION_MAJOR = 1;
        const int VERSION_MINOR = 0;

        private List<LayoutElement> elements;

        public List<LayoutElement> Elements
        {
            get { return elements; }
        }

        public Color DesignAreaBackgroundColor { get; set; }

        public Size WorkspaceSize { get; set; }
        public Size DesignAreaSize { get; set; }

        private double zoomRatio;

        public double ZoomRatio
        {
            get { return zoomRatio; }
            set
            {
                zoomRatio = value;

                if (zoomRatio < MinimumZoomRatio)
                    zoomRatio = MinimumZoomRatio;

                if (zoomRatio > MaximumZoomRatio)
                    zoomRatio = MaximumZoomRatio;
            }
        }

        public double MinimumZoomRatio { get; set; }
        public double MaximumZoomRatio { get; set; }

        public Layout()
        {
            elements = new List<LayoutElement>();

            DesignAreaBackgroundColor = Color.White;
            WorkspaceSize = new Size(2500, 2500);
            DesignAreaSize = new Size(400, 300);

            ZoomRatio = 1;
            MinimumZoomRatio = 0.5;
            MaximumZoomRatio = 4;
        }

        public void AddElement(LayoutElement element)
        {
            elements.Add(element);
        }

        public void RemoveElement(LayoutElement element)
        {
            elements.Remove(element);
        }

        public LayoutElement GetElement(Guid uniqueId)
        {
            foreach (LayoutElement element in elements)
                if (element.UniqueId.Equals(uniqueId))
                    return element;

            return null;
        }

        public LayoutElement GetElement(string name)
        {
            foreach (LayoutElement element in elements)
                if (element.Name.Equals(name))
                    return element;

            return null;
        }

        public bool IncreaseZoomRatio(double zoomDelta)
        {
            if (zoomRatio + zoomDelta > MinimumZoomRatio &&
                zoomRatio + zoomDelta < MaximumZoomRatio)
            {
                zoomRatio += zoomDelta;
                return true;
            }
            else
                return false;
        }

        public void SaveToFile(string fileName)
        {
            JObject jObject = new JObject();

            jObject["version"] = string.Format("{0}.{1}", VERSION_MAJOR, VERSION_MINOR);

            JArray jArrayElements = new JArray();

            foreach (var element in Elements)
            {
                JObject jObjectElement = new JObject();

                jObjectElement["typeName"] = element.TypeName;
                jObjectElement["id"] = element.UniqueId.ToString();
                jObjectElement["name"] = element.Name;

                // location
                var jObjectLocation = new JObject();
                jObjectLocation["x"] = element.Location.X;
                jObjectLocation["y"] = element.Location.Y;
                jObjectElement["location"] = jObjectLocation;

                // size
                var jObjectSize = new JObject();
                jObjectSize["width"] = element.Size.Width;
                jObjectSize["height"] = element.Size.Height;
                jObjectElement["size"] = jObjectSize;

                jArrayElements.Add(jObjectElement);
            }

            jObject["elements"] = jArrayElements;

            File.WriteAllText(fileName, jObject.ToString(), Encoding.UTF8);
        }

        public void LoadFromFile(string fileName)
        {
            var content = File.ReadAllText(fileName, Encoding.UTF8);
            JObject jObject = JObject.Parse(content);

            Elements.Clear();
            var jArrayElements = (JArray)jObject["elements"];
            foreach (var jObjectElement in jArrayElements)
            {
                
            }
        }
    }
}
