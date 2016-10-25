using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public class KeyboardHelper
    {
        public static bool IsShiftKeyPressed
        {
            get { return (System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift; }
        }

        public static bool IsControlKeyPressed
        {
            get { return (System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control; }
        }

        public static bool IsAltKeyPressed
        {
            get { return (System.Windows.Forms.Control.ModifierKeys & Keys.Alt) == Keys.Alt; }
        }
    }
}
