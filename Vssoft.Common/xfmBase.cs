namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xfmBase : XtraForm
    {
        private IContainer components = null;
        protected bool Simple = true;

        public event ButtonClickEventHander AddClick;

        public event ButtonClickEventHander Expanded;

        public event SendIDEventHander SendID;

        public xfmBase()
        {
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3f4, 0x2de);
            base.Name = "xfmBase";
            this.Text = "Phiếu";
            base.ResumeLayout(false);
        }

        protected void RaiseAddClickEventHander()
        {
            if (this.AddClick != null)
            {
                this.AddClick(this);
            }
        }

        protected void RaiseExpandedEventHander()
        {
            if (this.Expanded != null)
            {
                this.Expanded(this);
            }
        }

        protected void RaiseSendIDEventHander(string ID)
        {
            if (this.SendID != null)
            {
                this.SendID(ID);
            }
        }

        public delegate void SendIDEventHander(string ID);
    }
}

