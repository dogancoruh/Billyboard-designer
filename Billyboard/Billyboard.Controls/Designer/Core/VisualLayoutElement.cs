using Billyboard.Controls.Designer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Data
{
    public class VisualLayoutElement : LayoutElement
    {
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public int Alpha { get; set; }
        public virtual bool Rotatable
        {
            get { return true; }
        }
        public int Rotation { get; set; }

        public PivotLocation PivotLocation { get; set; }
        public Point PivotPoint { get; set; }

        public virtual bool Resizable
        {
            get { return true; }
        }

        public VisualLayoutElement(string typeName) : base(typeName)
        {

        }
    }
}
