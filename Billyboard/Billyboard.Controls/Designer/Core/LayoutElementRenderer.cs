using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Data
{
    public abstract class LayoutElementRenderer
    {
        public abstract string TypeName { get; }
        public abstract void Draw(LayoutElement element, Graphics graphics, LayoutProperties layoutProperties);
    }
}
