namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class xfmBaseHelp : XtraForm
    {
        private IContainer components;
        private WebBrowser webBrowser1;

        public xfmBaseHelp()
        {
            this.components = null;
            this.InitializeComponent();
        }

        public xfmBaseHelp(string FileName)
        {
            this.components = null;
            this.InitializeComponent();
            try
            {
                this.webBrowser1.Url = new Uri(Application.StartupPath + @"\Help\" + FileName);
            }
            catch
            {
            }
        }

        public xfmBaseHelp(string Title, string FileName)
        {
            this.components = null;
            this.InitializeComponent();
            this.Text = Title;
            try
            {
                this.webBrowser1.Url = new Uri(Application.StartupPath + @"\Help\" + FileName);
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.webBrowser1 = new WebBrowser();
            base.SuspendLayout();
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.Location = new Point(0, 0);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(0x1ee, 0x23c);
            this.webBrowser1.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1ee, 0x23c);
            base.Controls.Add(this.webBrowser1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "xfmBaseHelp";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Trợ gi\x00fap";
            base.ResumeLayout(false);
        }
    }
}

