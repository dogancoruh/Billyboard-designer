using System.IO;
using System.Windows.Forms;

namespace Billyboard.Controls.Utilities
{
    public class CursorHelper
    {
        public static Cursor LoadFromResource(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                return new Cursor(memoryStream);
            }
        }
    }
}
