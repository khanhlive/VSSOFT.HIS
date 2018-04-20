namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucBaseOptionPrint : xucBase
    {
        protected SimpleButton btnCancel;
        protected SimpleButton btnPrint;
        protected SimpleButton btnPrintPreview;
        private IContainer components = null;
        internal DevExpress.Utils.ImageCollection imageCollection1;

        public event ButtonClickEventHander CancelClick;

        public event ButtonClickEventHander SaveClick;

        public xucBaseOptionPrint()
        {
            this.InitializeComponent();
            this.Init();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.PrintPreview();
        }

        protected virtual void Cancel()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected virtual void Init()
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xucBaseOptionPrint));
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipItem item3 = new ToolTipItem();
            this.btnPrintPreview = new SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnPrint = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.imageCollection1.BeginInit();
            base.SuspendLayout();
            this.btnPrintPreview.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnPrintPreview.ImageIndex = 1;
            this.btnPrintPreview.ImageList = this.imageCollection1;
            this.btnPrintPreview.Location = new Point(0xba, 0x125);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new Size(0x5c, 0x1b);
            item.Text = "Ctrl+S\r\n";
            tip.Items.Add(item);
            this.btnPrintPreview.SuperTip = tip;
            this.btnPrintPreview.TabIndex = 0x23;
            this.btnPrintPreview.Text = "Xem trước";
            this.btnPrintPreview.Click += new EventHandler(this.btnPrintPreview_Click);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "ico_alpha_Delete_16x16.png");
            this.imageCollection1.Images.SetKeyName(1, "ico_alpha_Search_16x16.png");
            this.imageCollection1.Images.SetKeyName(2, "print16x16.png");
            this.btnPrint.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnPrint.ImageIndex = 2;
            this.btnPrint.ImageList = this.imageCollection1;
            this.btnPrint.Location = new Point(0x67, 0x125);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4d, 0x1b);
            item2.Text = "Ctrl+S\r\n";
            tip2.Items.Add(item2);
            this.btnPrint.SuperTip = tip2;
            this.btnPrint.TabIndex = 0x23;
            this.btnPrint.Text = "In...";
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.ImageList = this.imageCollection1;
            this.btnCancel.Location = new Point(13, 0x125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x54, 0x1b);
            item3.Text = "Ctrl+S\r\n";
            tip3.Items.Add(item3);
            this.btnCancel.SuperTip = tip3;
            this.btnCancel.TabIndex = 0x24;
            this.btnCancel.Text = "Tho\x00e1t";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnPrint);
            base.Controls.Add(this.btnPrintPreview);
            base.Name = "xucBaseOptionPrint";
            base.Size = new Size(290, 0x14c);
            this.imageCollection1.EndInit();
            base.ResumeLayout(false);
        }

        protected virtual void MakerInterface()
        {
        }

        public bool Number(KeyPressEventArgs e)
        {
            if (((e.KeyChar == '\b') | (e.KeyChar == '.')) | (e.KeyChar == '-'))
            {
                return false;
            }
            return !char.IsNumber(e.KeyChar);
        }

        protected virtual void Print()
        {
        }

        protected virtual void PrintPreview()
        {
        }

        public void RaiseCancelClickEventHander()
        {
            if (this.CancelClick != null)
            {
                this.CancelClick(this);
            }
        }

        public void RaiseSaveClickEventHander()
        {
            if (this.SaveClick != null)
            {
                this.SaveClick(this);
            }
        }

        protected virtual void SetInterface()
        {
        }
    }
}

