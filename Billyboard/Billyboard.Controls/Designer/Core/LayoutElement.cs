using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Data
{
    public class LayoutElement
    {
        private string typeName;

        public string TypeName
        {
            get { return typeName; }
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(Location, Size);
            }
        }

        public LayoutElement(string typeName)
        {
            this.typeName = typeName;
            UniqueId = Guid.NewGuid();
            Name = string.Empty;
            Location = Point.Empty;
            Size = Size.Empty;
        }
    }
}
