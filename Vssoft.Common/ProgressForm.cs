namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ProgressForm : XtraForm
    {
        private bool _autoClose;
        private bool _die;
        private Form _form;
        private Container components;
        private LabelControl lblMessage;
        private LabelControl lblTitle;
        private ProgressBarControl progressBarControl1;

        public ProgressForm()
        {
            this.components = null;
            this._die = false;
            this._autoClose = false;
            this.InitializeComponent();
        }

        public ProgressForm(Form parent)
        {
            this.components = null;
            this._die = false;
            this._autoClose = false;
            this.InitializeComponent();
            this._form = parent;
        }

        public ProgressForm(UserControl parent)
        {
            this.components = null;
            this._die = false;
            this._autoClose = false;
            this.InitializeComponent();
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
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(12, 16);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            this.progressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Size = new System.Drawing.Size(338, 16);
            this.progressBarControl1.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AllowHtmlString = true;
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Appearance.Options.UseFont = true;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Location = new System.Drawing.Point(13, 2);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(338, 15);
            this.lblMessage.TabIndex = 66;
            // 
            // lblTitle
            // 
            this.lblTitle.AllowHtmlString = true;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Location = new System.Drawing.Point(14, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(337, 13);
            this.lblTitle.TabIndex = 65;
            // 
            // ProgressForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(362, 48);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.progressBarControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        public void SetProgressValue(int position)
        {
            this.SetProgressValue(position, this.lblTitle.Text);
        }

        public void SetProgressValue(string message)
        {
            this.SetProgressValue(this.progressBarControl1.Position, message);
        }

        public void SetProgressValue(int position, string message)
        {
            this.SetProgressValue(position, message, "Vui l\x00f2ng đợi trong gi\x00e2y l\x00e1t");
        }

        public void SetProgressValue(int position, string message, string caption)
        {
            if (!this._die)
            {
                if (!base.Visible)
                {
                    if (this._form != null)
                    {
                        base.Show(this._form);
                    }
                    else
                    {
                        base.Show();
                    }
                }
                this.lblMessage.Text = message;
                this.progressBarControl1.Position = position;
                this.lblTitle.Text = caption;
                base.Update();
                if ((position >= 100) && this.AutoClose)
                {
                    base.Visible = false;
                }
            }
        }

        public bool AutoClose
        {
            get => 
                this._autoClose;
            set
            {
                this._autoClose = value;
            }
        }
    }
}

