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
        public Point ControlMouseDownLocation { get; set; }
        public Point ControlMouseMoveLocation { get; set; }
        public Point DesignAreaMouseDownLocation { get; set; }
        public Point DesignAreaMouseMoveLocation { get; set; }
        public Point SelectedElementLocation { get; set; }
        public Size SelectedElementSize { get; set; }
    }
}
