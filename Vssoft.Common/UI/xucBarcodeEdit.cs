namespace Vssoft.Common.UI
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using Vssoft.Utils.UI.BarcodeLib;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;

    public class xucBarcodeEdit : PictureEdit
    {
        private SimpleButton btnPrint;
        private IContainer components;
        private RepositoryItemPictureEdit fProperties;

        public xucBarcodeEdit()
        {
            this.components = null;
            //this.Barcode = new BarcodeEdit("Barcode", BarCodeStyles.CODE128);
            this.InitializeComponent();
            base.Controls.Add(this.btnPrint);
            base.Properties.SizeMode = PictureSizeMode.Stretch;
        }

        public xucBarcodeEdit(IContainer icContainer)
        {
            this.components = null;
            //this.Barcode = new BarcodeEdit("Barcode", BarCodeStyles.CODE128);
            this.components = icContainer;
            this.InitializeComponent();
            base.Controls.Add(this.btnPrint);
            //this.Barcode.Styles = BarCodeStyles.CODE128;
            this.Barcode.Text = base.Name;
            this.Barcode.Title = base.Name;
            base.Properties.SizeMode = PictureSizeMode.Stretch;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xucBarcodeEdit));
            this.fProperties = new RepositoryItemPictureEdit();
            this.btnPrint = new SimpleButton();
            this.fProperties.BeginInit();
            base.SuspendLayout();
            this.fProperties.Name = "fProperties";
            this.btnPrint.Image = (Image) manager.GetObject("btnPrint.Image");
            this.btnPrint.Location = new Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x17);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "In";
            this.btnPrint.Visible = false;
            this.fProperties.EndInit();
            base.ResumeLayout(false);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
            this.Barcode.Width = base.Width;
            this.Barcode.Height = base.Height;
            this.Update();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Barcode.Text = this.Text;
            this.Update();
        }

        internal void SetText(string text)
        {
            this.Barcode.Text = text;
        }

        public void Update()
        {
            if (this.Active)
            {
                this.Image = this.Barcode.Encode(this.Barcode.Styles, this.Barcode.Text);
            }
        }

        public bool Active { get; set; }

        public Color BackColor
        {
            get => 
                this.Barcode.BackColor;
            set
            {
                this.Barcode.BackColor = value;
                this.Update();
            }
        }

        //public BarcodeEdit Barcode { get; private set; }

        public Size BarcodeSize
        {
            get => 
                new Size(this.Barcode.Width, this.Barcode.Height);
            set
            {
                this.Barcode.Width = value.Width;
                this.Barcode.Height = value.Height;
            }
        }

        public string CAMCode =>
            this.Barcode.CAM_Code;

        public Image EncodedImage =>
            this.Barcode.EncodedImage;

        public string EncodedValue =>
            this.Barcode.EncodedValue;

        public double EncodingTime
        {
            get => 
                this.Barcode.EncodingTime;
            set
            {
                this.Barcode.EncodingTime = value;
                this.Update();
            }
        }

        public Color ForeColor
        {
            get => 
                this.Barcode.ForeColor;
            set
            {
                this.Barcode.ForeColor = value;
                this.Update();
            }
        }

        public string FormattedData =>
            this.Barcode.FormattedData;

        public System.Drawing.Imaging.ImageFormat ImageFormat
        {
            get => 
                this.Barcode.ImageFormat;
            set
            {
                this.Barcode.ImageFormat = value;
            }
        }

        public bool ShowText
        {
            get => 
                this.Barcode.ShowText;
            set
            {
                this.Barcode.ShowText = value;
                this.Update();
            }
        }

        public BarCodeStyles Styles
        {
            get => 
                this.Barcode.Styles;
            set
            {
                this.Barcode.Styles = value;
                this.Update();
            }
        }

        public Font TextFont
        {
            get => 
                this.Barcode.TextFont;
            set
            {
                this.Barcode.TextFont = value;
                this.Update();
            }
        }

        public string Title
        {
            get => 
                this.Barcode.Title;
            set
            {
                this.Barcode.Title = value;
                this.Update();
            }
        }

        public Font TitleFont
        {
            get => 
                this.Barcode.Font;
            set
            {
                this.Barcode.Font = value;
                this.Update();
            }
        }

        public string Value
        {
            get => 
                this.Barcode.Text;
            set
            {
                this.Barcode.Text = value;
                this.Update();
            }
        }

        public string XML =>
            this.Barcode.XML;
    }
}

