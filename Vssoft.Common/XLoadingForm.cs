namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
   
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class XLoadingForm : XtraForm
    {
        private bool _autoClose;
        private bool _die;
        private Form _form;
        private IContainer components;
        private const int CS_DROPSHADOW = 0x20000;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl lblTitle;
        private LabelControl lblVersion;
        private LabelControl lbTitle;
        private PictureBox pictureBox2;

        public XLoadingForm()
        {
            this._die = false;
            this._autoClose = false;
            this.InitializeComponent();
            FileInfo info = new FileInfo(Application.StartupPath + @"\Vssoft.HumanResource.exe");
            this.lblVersion.Text = "Phiên bản"; //MultiLanguages.GetString("tbl_Loading", "Version", "Phi\x00ean bản") + ": " + MyAssembly.AssemblyVersion + " (D\x00f9ng chung) -  Bi\x00ean dịch ng\x00e0y " + info.LastWriteTime.ToShortDateString();
        }

        public XLoadingForm(Form parent)
        {
            this._die = false;
            this._autoClose = false;
            this.InitializeComponent();
            this._form = parent;
        }

        public XLoadingForm(UserControl parent)
        {
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
            this.lblTitle = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.labelControl6 = new LabelControl();
            this.labelControl5 = new LabelControl();
            this.lbTitle = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.lblVersion = new LabelControl();
            this.pictureBox2 = new PictureBox();
            this.labelControl4 = new LabelControl();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            base.SuspendLayout();
            this.lblTitle.Anchor = AnchorStyles.Left;
            this.lblTitle.Appearance.ForeColor = Color.Moccasin;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new Point(14, 0xe8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(0x49, 13);
            this.lblTitle.TabIndex = 0x43;
            this.lblTitle.Text = "Đang tải... 0%";
            this.labelControl7.Appearance.ForeColor = Color.Khaki;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new Point(0xd8, 0x58);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(0x6c, 13);
            this.labelControl7.TabIndex = 0x4f;
            this.labelControl7.Text = "sales@Vssoft.com.vn";
            this.labelControl6.Appearance.ForeColor = Color.Khaki;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new Point(0x3a, 0x58);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x66, 13);
            this.labelControl6.TabIndex = 0x4e;
            this.labelControl6.Text = "www.Vssoft.com.vn";
            this.labelControl5.Appearance.ForeColor = Color.LightSkyBlue;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new Point(170, 0x58);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x2c, 13);
            this.labelControl5.TabIndex = 0x4d;
            this.labelControl5.Text = "-   Email: ";
            this.lbTitle.AllowHtmlString = true;
            this.lbTitle.Appearance.Font = new Font("Tahoma", 16f);
            this.lbTitle.Appearance.ForeColor = Color.Snow;
            this.lbTitle.Appearance.Options.UseFont = true;
            this.lbTitle.Appearance.Options.UseForeColor = true;
            this.lbTitle.Location = new Point(12, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new Size(0xa7, 0x1a);
            this.lbTitle.TabIndex = 0x4c;
            this.lbTitle.Text = "Perfect HRM 2012";
            this.labelControl3.Appearance.ForeColor = Color.LightSkyBlue;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new Point(12, 0x58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x2e, 13);
            this.labelControl3.TabIndex = 0x4b;
            this.labelControl3.Text = "Website: ";
            this.labelControl2.Appearance.ForeColor = Color.LightSkyBlue;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new Point(12, 0x45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x12d, 13);
            this.labelControl2.TabIndex = 0x4a;
            this.labelControl2.Text = "\x00a9 Bản quyền 2011 - 2014 bởi C\x00d4NG TY PHẦN MỀM HO\x00c0N HẢO";
            this.lblVersion.Appearance.ForeColor = Color.Snow;
            this.lblVersion.Appearance.Options.UseForeColor = true;
            this.lblVersion.Location = new Point(12, 0x31);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new Size(0xa7, 13);
            this.lblVersion.TabIndex = 0x49;
            this.lblVersion.Text = "Version: 1.0.0.0  -  Build 00000000";
            this.pictureBox2.BackColor = Color.Transparent;
            //this.pictureBox2.Image = Resources.logo;
            this.pictureBox2.Location = new Point(0xff, 0xc0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(0xce, 0x48);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 80;
            this.pictureBox2.TabStop = false;
            this.labelControl4.Appearance.ForeColor = Color.SteelBlue;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new Point(14, 0xd6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x85, 13);
            this.labelControl4.TabIndex = 0x52;
            this.labelControl4.Text = "Vui l\x00f2ng đợi trong gi\x00e2y l\x00e1t...";
            base.Appearance.BackColor = Color.FromArgb(0x20, 0x4f, 150);
            base.Appearance.Options.UseBackColor = true;
            this.AutoScaleBaseSize = new Size(5, 14);
            base.BackgroundImageLayoutStore = ImageLayout.Tile;
            //base.BackgroundImageStore = Resources.flash_screen;
            base.ClientSize = new Size(0x1c9, 0x103);
            base.ControlBox = false;
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.pictureBox2);
            base.Controls.Add(this.labelControl7);
            base.Controls.Add(this.labelControl6);
            base.Controls.Add(this.labelControl5);
            base.Controls.Add(this.lbTitle);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.lblVersion);
            base.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "XLoadingForm";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.TopMost = true;
            base.TransparencyKey = Color.Transparent;
            ((ISupportInitialize) this.pictureBox2).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        public void SetProgressValue(int position)
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
                this.lblTitle.Text = "Đang tải..." + position.ToString() + "%";
                base.Update();
            }
        }

        public void SetProgressValue(int position, string message)
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
                this.lblTitle.Text =  message + position.ToString() + "%";
                base.Update();
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

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= 0x20000;
                return createParams;
            }
        }
    }
}

