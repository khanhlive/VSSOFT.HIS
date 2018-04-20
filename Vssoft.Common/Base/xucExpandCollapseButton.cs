namespace Vssoft.Common.Base
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucExpandCollapseButton : UserControl
    {
        private IContainer components = null;
        private Label label1;
        private Panel panel1;

        public event ExpandCollapsedHander ExpandCollapsed;

        public xucExpandCollapseButton()
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
            this.label1 = new Label();
            this.panel1 = new Panel();
            base.SuspendLayout();
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("Lucida Console", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(2, 1);
            this.label1.Name = "label1";
            this.label1.Size = new Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "▼";
            this.label1.MouseLeave += new EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
            this.label1.Click += new EventHandler(this.label1_Click);
            this.panel1.BackColor = Color.GhostWhite;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x11, 15);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.label1);
            base.Controls.Add(this.panel1);
            base.Name = "xucExpandCollapseButton";
            base.Size = new Size(0x11, 15);
            base.ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (this.label1.Text == "▲")
            {
                this.label1.Text = "▼";
                this.RaiseExpandCollapsedHander(false);
            }
            else
            {
                this.label1.Text = "▲";
                this.RaiseExpandCollapsedHander(true);
            }
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            this.panel1.Visible = true;
        }

        private void RaiseExpandCollapsedHander(bool IsExpand)
        {
            if (this.ExpandCollapsed != null)
            {
                this.ExpandCollapsed(this, IsExpand);
            }
        }

        public delegate void ExpandCollapsedHander(object sender, bool IsExpand);
    }
}

