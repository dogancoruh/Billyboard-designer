using Billyboard.Controls.Designer.Core;
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
        Layout layout;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            layout = new Layout();

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

            designerControl1.AddElementType(ImageElement.TYPE_NAME, typeof(ImageElement));
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

        private void actionFileNew_Execute(object sender, EventArgs e)
        {
            document1.NewDocument();
        }

        private void actionFileOpen_Execute(object sender, EventArgs e)
        {
            document1.OpenDocument();
        }

        private void actionFileSave_Execute(object sender, EventArgs e)
        {
            document1.SaveDocument();
        }

        private void actionFileSaveAs_Execute(object sender, EventArgs e)
        {
            document1.SaveDocumentAs();
        }

        private void actionFileExit_Execute(object sender, EventArgs e)
        {
            Close();
        }

        private void document1_OnNewDocument(object sender, DocumentFramework.Events.DocumentNewEventArgs e)
        {
            layout = new Layout();
            layout.WorkspaceSize = new Size(4000, 4000);
            layout.DesignAreaSize = new Size(800, 600);
            designerControl1.Layout = layout;
            designerControl1.Refresh();
        }

        private void document1_OnNewDocumentPrompt(object sender, DocumentFramework.Events.DocumentNewPromptEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirmation", "Current document is modified.\nDo you want to save it?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            if (dialogResult == DialogResult.Yes)
                e.DialogResult = DocumentFramework.Enums.DialogResult.Yes;
            else if (dialogResult == DialogResult.No)
                e.DialogResult = DocumentFramework.Enums.DialogResult.No;
            else if (dialogResult == DialogResult.Cancel)
                e.DialogResult = DocumentFramework.Enums.DialogResult.Cancel;
        }

        private void document1_OnOpenDocument(object sender, DocumentFramework.Events.DocumentOpenEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "layout";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                layout = LayoutLoader.Load(dialog.FileName);
                document1.DocumentFileName = dialog.FileName;
                designerControl1.Layout = layout;
                designerControl1.Refresh();
            }
        }

        private void document1_OnSaveDocument(object sender, DocumentFramework.Events.DocumentSaveEventArgs e)
        {
            LayoutLoader.Save(e.FileName, layout);
        }

        private void document1_OnSaveAsDocumentPrompt(object sender, DocumentFramework.Events.DocumentSaveAsPromptEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "layout";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                e.FileName = dialog.FileName;
                e.IsHandled = true;
            }
        }

        private void document1_OnSaveDocumentAs(object sender, DocumentFramework.Events.DocumentSaveAsEventArgs e)
        {
            LayoutLoader.Save(e.FileName, layout);
        }

        private void document1_OnDocumentModified(object sender, DocumentFramework.Events.DocumentModifiedEventArgs e)
        {
            Text = document1.Title;
        }

        private void document1_OnDocumentFileNameChanged(object sender, DocumentFramework.Events.DocumentFileNameChangedEventArgs e)
        {
            Text = document1.Title;
        }
    }
}
