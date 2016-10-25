using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Data
{
    public class LayoutProperties
    {
        public Point DesignAreaLocation { get; set; }
        public Size DesignAreaSize { get; set; }
        public Point ViewportLocation { get; set; }
        public Size ViewportSize { get; set; }
        public double ZoomRatio { get; set; }
    }
}
