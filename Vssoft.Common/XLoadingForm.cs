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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lbTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Moccasin;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 232);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(73, 13);
            this.lblTitle.TabIndex = 67;
            this.lblTitle.Text = "Đang tải... 0%";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Khaki;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(216, 88);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(103, 13);
            this.labelControl7.TabIndex = 79;
            this.labelControl7.Text = "sales@Vssoft.com.vn";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Khaki;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(58, 88);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(97, 13);
            this.labelControl6.TabIndex = 78;
            this.labelControl6.Text = "www.Vssoft.com.vn";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(170, 88);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(44, 13);
            this.labelControl5.TabIndex = 77;
            this.labelControl5.Text = "-   Email: ";
            // 
            // lbTitle
            // 
            this.lbTitle.AllowHtmlString = true;
            this.lbTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lbTitle.Appearance.ForeColor = System.Drawing.Color.Snow;
            this.lbTitle.Appearance.Options.UseFont = true;
            this.lbTitle.Appearance.Options.UseForeColor = true;
            this.lbTitle.Location = new System.Drawing.Point(12, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(148, 25);
            this.lbTitle.TabIndex = 76;
            this.lbTitle.Text = "Vssoft HIS 2018";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "Website: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(401, 13);
            this.labelControl2.TabIndex = 74;
            this.labelControl2.Text = "© Bản quyền 2014 - 2018 bởi CÔNG TY CP PHÁT TRIỂN GIẢI PHÁP PHẦN MỀM VIỆT";
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.ForeColor = System.Drawing.Color.Snow;
            this.lblVersion.Appearance.Options.UseForeColor = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 49);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(167, 13);
            this.lblVersion.TabIndex = 73;
            this.lblVersion.Text = "Version: 1.0.0.0  -  Build 00000000";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(279, 194);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(206, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 80;
            this.pictureBox2.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(14, 214);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(133, 13);
            this.labelControl4.TabIndex = 82;
            this.labelControl4.Text = "Vui lòng đợi trong giây lát...";
            // 
            // XLoadingForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(485, 259);
            this.ControlBox = false;
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XLoadingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

