using Billyboard.Controls.Designer.Data;
using Billyboard.Controls.Designer.Renderer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billyboard
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Layout layout = new Layout();

            layout.ZoomRatio = 1.0;

            layout.AddElement(new ImageElement()
            {
                Visible = true,
                Location = new Point(100, 100),
                Size = new Size(100, 100),
                Alpha = 100,
                FileName = Path.Combine(Application.StartupPath, "candy.png")
            });

            layout.AddElement(new ImageElement()
            {
                Visible = true,
                Location = new Point(-1040, -1040),
                Size = new Size(100, 100),
                Alpha = 100,
                FileName = Path.Combine(Application.StartupPath, "candy.png")
            });

            designerControl1.AddElementRenderer(ImageElement.TYPE_NAME, typeof(ImageElementRenderer));

            designerControl1.Layout = layout;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            designerControl1.CenterViewport();
            //designerControl1.LocateViewport(new Point(9700, 9500));
            //designerControl1.LocateViewport(new Point(0, 0));
        }

        private void buttonZoom1_Click(object sender, EventArgs e)
        {
            designerControl1.Layout.ZoomRatio = 1;
            designerControl1.Refresh();
            designerControl1.CenterViewport();
        }

        private void buttonZoom2_Click(object sender, EventArgs e)
        {
            designerControl1.Layout.ZoomRatio = 2;
            designerControl1.Refresh();
            designerControl1.CenterViewport();
        }
    }
}
