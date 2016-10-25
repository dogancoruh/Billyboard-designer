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
            this.designerControl1 = new Billyboard.Controls.Designer.Control.DesignerControl();
            this.buttonZoom1 = new System.Windows.Forms.Button();
            this.buttonZoom2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // designerControl1
            // 
            this.designerControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.designerControl1.Layout = null;
            this.designerControl1.Location = new System.Drawing.Point(12, 12);
            this.designerControl1.Name = "designerControl1";
            this.designerControl1.Size = new System.Drawing.Size(800, 800);
            this.designerControl1.TabIndex = 0;
            this.designerControl1.ViewportLocation = new System.Drawing.Point(0, 0);
            // 
            // buttonZoom1
            // 
            this.buttonZoom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoom1.Location = new System.Drawing.Point(655, 827);
            this.buttonZoom1.Name = "buttonZoom1";
            this.buttonZoom1.Size = new System.Drawing.Size(75, 23);
            this.buttonZoom1.TabIndex = 1;
            this.buttonZoom1.Text = "Zoom 1:1";
            this.buttonZoom1.UseVisualStyleBackColor = true;
            this.buttonZoom1.Click += new System.EventHandler(this.buttonZoom1_Click);
            // 
            // buttonZoom2
            // 
            this.buttonZoom2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonZoom2.Location = new System.Drawing.Point(737, 827);
            this.buttonZoom2.Name = "buttonZoom2";
            this.buttonZoom2.Size = new System.Drawing.Size(75, 23);
            this.buttonZoom2.TabIndex = 2;
            this.buttonZoom2.Text = "Zoom 2:1";
            this.buttonZoom2.UseVisualStyleBackColor = true;
            this.buttonZoom2.Click += new System.EventHandler(this.buttonZoom2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 862);
            this.Controls.Add(this.buttonZoom2);
            this.Controls.Add(this.buttonZoom1);
            this.Controls.Add(this.designerControl1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billyboard";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Designer.Control.DesignerControl designerControl1;
        private System.Windows.Forms.Button buttonZoom1;
        private System.Windows.Forms.Button buttonZoom2;
    }
}

