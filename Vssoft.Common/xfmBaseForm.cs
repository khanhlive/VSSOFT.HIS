namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class xfmBaseForm : XtraForm
    {
        public SimpleButton btClose;
        public SimpleButton btNext;
        private IContainer components = null;
        public Label label1;
        public Label label2;
        public LabelControl lblSubTitle;
        public LabelControl lblTitle;
        public Panel panel1;
        public Panel panel2;
        public Panel panel3;

        public xfmBaseForm()
        {
            this.InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Cancel();
            base.Close();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            this.Next();
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

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.lblSubTitle = new LabelControl();
            this.lblTitle = new LabelControl();
            this.panel3 = new Panel();
            this.btClose = new SimpleButton();
            this.btNext = new SimpleButton();
            this.label2 = new Label();
            this.panel2 = new Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSubTitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1f1, 0x3f);
            this.panel1.TabIndex = 2;
            this.label1.BorderStyle = BorderStyle.Fixed3D;
            this.label1.Dock = DockStyle.Bottom;
            this.label1.Location = new Point(0, 0x3d);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1f1, 2);
            this.label1.TabIndex = 6;
            this.lblSubTitle.AllowHtmlString = true;
            this.lblSubTitle.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.lblSubTitle.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblSubTitle.Appearance.ForeColor = Color.Black;
            this.lblSubTitle.Appearance.Options.UseFont = true;
            this.lblSubTitle.Appearance.Options.UseForeColor = true;
            this.lblSubTitle.Appearance.Options.UseTextOptions = true;
            this.lblSubTitle.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.lblSubTitle.AutoSizeMode = LabelAutoSizeMode.None;
            this.lblSubTitle.Location = new Point(9, 30);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new Size(0x1dc, 0x1c);
            this.lblSubTitle.TabIndex = 5;
            this.lblSubTitle.Text = "lblSubTitle";
            this.lblTitle.AllowHtmlString = true;
            this.lblTitle.Appearance.BackColor = Color.Transparent;
            this.lblTitle.Appearance.Font = new Font("Tahoma", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblTitle.Appearance.ForeColor = Color.Black;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.lblTitle.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.lblTitle.AutoSizeMode = LabelAutoSizeMode.Horizontal;
            this.lblTitle.Location = new Point(8, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(0x36, 0x17);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "lblTitle";
            this.panel3.Controls.Add(this.btClose);
            this.panel3.Controls.Add(this.btNext);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = DockStyle.Bottom;
            this.panel3.Location = new Point(0, 0x13d);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(0x1f1, 50);
            this.panel3.TabIndex = 4;
            this.btClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btClose.Location = new Point(0x194, 15);
            this.btClose.Name = "btClose";
            this.btClose.Size = new Size(0x4b, 0x17);
            this.btClose.TabIndex = 0x22;
            this.btClose.Text = "Hủy";
            this.btClose.Click += new EventHandler(this.btClose_Click);
            this.btNext.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btNext.Location = new Point(0x143, 15);
            this.btNext.Name = "btNext";
            this.btNext.Size = new Size(0x4b, 0x17);
            this.btNext.TabIndex = 0x22;
            this.btNext.Text = "Đồng \x00dd";
            this.btNext.Click += new EventHandler(this.btNext_Click);
            this.label2.BorderStyle = BorderStyle.Fixed3D;
            this.label2.Dock = DockStyle.Top;
            this.label2.Location = new Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1f1, 2);
            this.label2.TabIndex = 0x21;
            this.panel2.BackColor = Color.White;
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new Point(0, 0x3f);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(5);
            this.panel2.Size = new Size(0x1f1, 0xfe);
            this.panel2.TabIndex = 5;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1f1, 0x16f);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "xfmBaseForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        protected virtual void Next()
        {
        }
    }
}

