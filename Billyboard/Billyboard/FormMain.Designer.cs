namespace Billyboard
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayoutAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.designerControl1 = new Billyboard.Controls.Designer.Control.DesignerControl();
            this.actionList = new Crad.Windows.Forms.Actions.ActionList();
            this.actionFileNew = new Crad.Windows.Forms.Actions.Action();
            this.actionFileOpen = new Crad.Windows.Forms.Actions.Action();
            this.actionFileSave = new Crad.Windows.Forms.Actions.Action();
            this.actionFileSaveAs = new Crad.Windows.Forms.Actions.Action();
            this.actionFileExit = new Crad.Windows.Forms.Actions.Action();
            this.document1 = new DocumentFramework.Core.Document();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openLayoutToolStripMenuItem,
            this.saveLayoutToolStripMenuItem,
            this.saveLayoutAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.actionList.SetAction(this.newToolStripMenuItem, this.actionFileNew);
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newToolStripMenuItem.Text = "&New Layout";
            // 
            // openLayoutToolStripMenuItem
            // 
            this.actionList.SetAction(this.openLayoutToolStripMenuItem, this.actionFileOpen);
            this.openLayoutToolStripMenuItem.AutoToolTip = true;
            this.openLayoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openLayoutToolStripMenuItem.Image")));
            this.openLayoutToolStripMenuItem.Name = "openLayoutToolStripMenuItem";
            this.openLayoutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.openLayoutToolStripMenuItem.Text = "&Open Layout";
            // 
            // saveLayoutToolStripMenuItem
            // 
            this.actionList.SetAction(this.saveLayoutToolStripMenuItem, this.actionFileSave);
            this.saveLayoutToolStripMenuItem.AutoToolTip = true;
            this.saveLayoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveLayoutToolStripMenuItem.Image")));
            this.saveLayoutToolStripMenuItem.Name = "saveLayoutToolStripMenuItem";
            this.saveLayoutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLayoutToolStripMenuItem.Text = "&Save Layout";
            // 
            // saveLayoutAsToolStripMenuItem
            // 
            this.actionList.SetAction(this.saveLayoutAsToolStripMenuItem, this.actionFileSaveAs);
            this.saveLayoutAsToolStripMenuItem.AutoToolTip = true;
            this.saveLayoutAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveLayoutAsToolStripMenuItem.Image")));
            this.saveLayoutAsToolStripMenuItem.Name = "saveLayoutAsToolStripMenuItem";
            this.saveLayoutAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveLayoutAsToolStripMenuItem.Text = "Save Layout As";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.actionList.SetAction(this.exitToolStripMenuItem, this.actionFileExit);
            this.exitToolStripMenuItem.AutoToolTip = true;
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(861, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.actionList.SetAction(this.toolStripButton1, this.actionFileNew);
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "&New Layout";
            // 
            // toolStripButton2
            // 
            this.actionList.SetAction(this.toolStripButton2, this.actionFileOpen);
            this.toolStripButton2.AutoToolTip = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "&Open Layout";
            // 
            // toolStripButton3
            // 
            this.actionList.SetAction(this.toolStripButton3, this.actionFileSave);
            this.toolStripButton3.AutoToolTip = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "&Save Layout";
            // 
            // toolStripButton4
            // 
            this.actionList.SetAction(this.toolStripButton4, this.actionFileSaveAs);
            this.toolStripButton4.AutoToolTip = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Save Layout As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(846, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // designerControl1
            // 
            this.designerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl1.Layout = null;
            this.designerControl1.Location = new System.Drawing.Point(0, 49);
            this.designerControl1.Name = "designerControl1";
            this.designerControl1.Size = new System.Drawing.Size(861, 575);
            this.designerControl1.TabIndex = 6;
            this.designerControl1.ViewportLocation = new System.Drawing.Point(0, 0);
            // 
            // actionList
            // 
            this.actionList.Actions.Add(this.actionFileNew);
            this.actionList.Actions.Add(this.actionFileOpen);
            this.actionList.Actions.Add(this.actionFileSave);
            this.actionList.Actions.Add(this.actionFileSaveAs);
            this.actionList.Actions.Add(this.actionFileExit);
            this.actionList.ContainerControl = this;
            // 
            // actionFileNew
            // 
            this.actionFileNew.Image = ((System.Drawing.Image)(resources.GetObject("actionFileNew.Image")));
            this.actionFileNew.Text = "&New Layout";
            this.actionFileNew.Execute += new System.EventHandler(this.actionFileNew_Execute);
            // 
            // actionFileOpen
            // 
            this.actionFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("actionFileOpen.Image")));
            this.actionFileOpen.Text = "&Open Layout";
            this.actionFileOpen.Execute += new System.EventHandler(this.actionFileOpen_Execute);
            // 
            // actionFileSave
            // 
            this.actionFileSave.Image = ((System.Drawing.Image)(resources.GetObject("actionFileSave.Image")));
            this.actionFileSave.Text = "&Save Layout";
            this.actionFileSave.Execute += new System.EventHandler(this.actionFileSave_Execute);
            // 
            // actionFileSaveAs
            // 
            this.actionFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("actionFileSaveAs.Image")));
            this.actionFileSaveAs.Text = "Save Layout As";
            this.actionFileSaveAs.Execute += new System.EventHandler(this.actionFileSaveAs_Execute);
            // 
            // actionFileExit
            // 
            this.actionFileExit.Image = ((System.Drawing.Image)(resources.GetObject("actionFileExit.Image")));
            this.actionFileExit.Text = "E&xit";
            this.actionFileExit.Execute += new System.EventHandler(this.actionFileExit_Execute);
            // 
            // document1
            // 
            this.document1.DefaultTitle = null;
            this.document1.DocumentFileName = "";
            this.document1.IsDocumentModified = false;
            this.document1.OnNewDocument += new System.EventHandler<DocumentFramework.Events.DocumentNewEventArgs>(this.document1_OnNewDocument);
            this.document1.OnNewDocumentPrompt += new System.EventHandler<DocumentFramework.Events.DocumentNewPromptEventArgs>(this.document1_OnNewDocumentPrompt);
            this.document1.OnOpenDocument += new System.EventHandler<DocumentFramework.Events.DocumentOpenEventArgs>(this.document1_OnOpenDocument);
            this.document1.OnSaveDocument += new System.EventHandler<DocumentFramework.Events.DocumentSaveEventArgs>(this.document1_OnSaveDocument);
            this.document1.OnSaveDocumentAs += new System.EventHandler<DocumentFramework.Events.DocumentSaveAsEventArgs>(this.document1_OnSaveDocumentAs);
            this.document1.OnSaveDoucmentAsPrompt += new System.EventHandler<DocumentFramework.Events.DocumentSaveAsPromptEventArgs>(this.document1_OnSaveAsDocumentPrompt);
            this.document1.OnDocumentFileNameChanged += new System.EventHandler<DocumentFramework.Events.DocumentFileNameChangedEventArgs>(this.document1_OnDocumentFileNameChanged);
            this.document1.OnDocumentModified += new System.EventHandler<DocumentFramework.Events.DocumentModifiedEventArgs>(this.document1_OnDocumentModified);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 646);
            this.Controls.Add(this.designerControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billyboard";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Controls.Designer.Control.DesignerControl designerControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private Crad.Windows.Forms.Actions.ActionList actionList;
        private Crad.Windows.Forms.Actions.Action actionFileNew;
        private DocumentFramework.Core.Document document1;
        private System.Windows.Forms.ToolStripMenuItem openLayoutToolStripMenuItem;
        private Crad.Windows.Forms.Actions.Action actionFileOpen;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private Crad.Windows.Forms.Actions.Action actionFileSave;
        private Crad.Windows.Forms.Actions.Action actionFileSaveAs;
        private Crad.Windows.Forms.Actions.Action actionFileExit;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayoutAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

