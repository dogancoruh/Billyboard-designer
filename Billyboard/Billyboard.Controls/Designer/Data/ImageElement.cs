using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billyboard.Controls.Designer.Data
{
    public class ImageElement : VisualLayoutElement
    {
        public const string TYPE_NAME = "image";

        private Bitmap image;

        public Bitmap Image
        {
            get { return image; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;

                if (!string.IsNullOrEmpty(fileName))
                    image = (Bitmap)Bitmap.FromFile(fileName);
            }
        }

        public ImageElement() : base(TYPE_NAME)
        {

        }
    }
}
