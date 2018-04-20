namespace Vssoft.Common.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class Arrow : UserControl
    {
        private IContainer components = null;
        private System.Drawing.Color m_Color = System.Drawing.Color.LightSteelBlue;
        private LineCap m_EndCap = LineCap.Square;
        private Graphics m_GraphicsHover;
        private Direction m_LineDirection;
        private float m_PenWidth = 5f;
        private LineCap m_StartCap = LineCap.Square;
        private float m_X1 = 5f;
        private float m_X2 = 0f;
        private float m_Y1 = 5f;
        private float m_Y2 = 0f;

        public Arrow()
        {
            this.InitializeComponent();
        }

        private void Arrow_MouseHover(object sender, EventArgs e)
        {
            if (this.m_GraphicsHover != null)
            {
                this.m_GraphicsHover = null;
            }
            this.m_GraphicsHover = base.CreateGraphics();
            this.m_GraphicsHover.SmoothingMode = SmoothingMode.AntiAlias;
            this.m_GraphicsHover.FillRectangle(Brushes.Transparent, base.ClientRectangle);
            if ((this.m_LineDirection != Direction.Slant) && (this.m_LineDirection != Direction.BackSlant))
            {
                Pen pen = new Pen(System.Drawing.Color.FromArgb(((this.m_Color.G + 30) > 0xff) ? (this.m_Color.R - 30) : (this.m_Color.R + 30), ((this.m_Color.G + 30) > 0xff) ? (this.m_Color.G - 30) : (this.m_Color.G + 30), ((this.m_Color.B + 30) > 0xff) ? (this.m_Color.B - 30) : (this.m_Color.B + 30)), this.m_PenWidth) {
                    StartCap = this.m_StartCap,
                    EndCap = this.m_EndCap,
                    DashStyle = DashStyle.Dot
                };
                this.m_GraphicsHover.DrawLine(pen, this.m_X1, this.m_Y1, this.m_X2, this.m_Y2);
                pen.Dispose();
            }
        }

        private void Arrow_MouseLeave(object sender, EventArgs e)
        {
            if (this.m_GraphicsHover != null)
            {
                this.m_GraphicsHover = null;
            }
            this.m_GraphicsHover = base.CreateGraphics();
            this.m_GraphicsHover.SmoothingMode = SmoothingMode.AntiAlias;
            this.m_GraphicsHover.FillRectangle(Brushes.Transparent, base.ClientRectangle);
            if ((this.m_LineDirection != Direction.Slant) && (this.m_LineDirection != Direction.BackSlant))
            {
                Pen pen = new Pen(this.m_Color, this.m_PenWidth) {
                    StartCap = this.m_StartCap,
                    EndCap = this.m_EndCap,
                    DashStyle = DashStyle.Solid
                };
                this.m_GraphicsHover.DrawLine(pen, this.m_X1, this.m_Y1, this.m_X2, this.m_Y2);
                pen.Dispose();
            }
        }

        private void Arrow_Resize(object sender, EventArgs e)
        {
            if (this.m_LineDirection == Direction.BackSlant)
            {
                this.m_X1 = this.m_PenWidth;
                this.m_Y1 = this.m_PenWidth;
                this.m_X2 = base.Width - this.m_PenWidth;
                this.m_Y2 = base.Height - this.m_PenWidth;
            }
            else if (this.m_LineDirection == Direction.Slant)
            {
                this.m_X1 = this.m_PenWidth;
                this.m_Y1 = base.Height - this.m_PenWidth;
                this.m_X2 = base.Width - this.m_PenWidth;
                this.m_Y2 = this.m_PenWidth;
            }
            else if (this.m_LineDirection == Direction.Horizontal)
            {
                this.m_X1 = 0f;
                this.m_Y1 = this.m_PenWidth / 2f;
                this.m_X2 = base.Width;
                this.m_Y2 = this.m_PenWidth / 2f;
            }
            else if (this.m_LineDirection == Direction.Vertical)
            {
                this.m_X1 = this.m_PenWidth / 2f;
                this.m_Y1 = 0f;
                this.m_X2 = this.m_PenWidth / 2f;
                this.m_Y2 = base.Height;
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
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            base.Name = "Arrow";
            base.Size = new Size(0x102, 0xc6);
            base.MouseLeave += new EventHandler(this.Arrow_MouseLeave);
            base.Resize += new EventHandler(this.Arrow_Resize);
            base.MouseHover += new EventHandler(this.Arrow_MouseHover);
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(Brushes.Transparent, base.ClientRectangle);
            if (this.m_LineDirection == Direction.Slant)
            {
                Pen pen = new Pen(this.m_Color, this.m_PenWidth) {
                    StartCap = this.m_StartCap,
                    DashStyle = DashStyle.Solid
                };
                graphics.DrawLine(pen, this.m_X1, this.m_Y1, this.m_X2, this.m_Y2);
                pen.Dispose();
            }
            else if (this.m_LineDirection != Direction.BackSlant)
            {
                Pen pen2 = new Pen(this.m_Color, this.m_PenWidth) {
                    StartCap = this.m_StartCap,
                    EndCap = this.m_EndCap,
                    DashStyle = DashStyle.Solid
                };
                graphics.DrawLine(pen2, this.m_X1, this.m_Y1, this.m_X2, this.m_Y2);
                pen2.Dispose();
            }
            base.OnPaint(e);
        }

        public System.Drawing.Color Color
        {
            get => 
                this.m_Color;
            set
            {
                this.m_Color = value;
            }
        }

        public LineCap EndCap
        {
            get => 
                this.m_EndCap;
            set
            {
                this.m_EndCap = value;
            }
        }

        [DefaultValue(0)]
        public Direction LineDirection
        {
            get => 
                this.m_LineDirection;
            set
            {
                this.m_LineDirection = value;
            }
        }

        public float PenWidth
        {
            get => 
                this.m_PenWidth;
            set
            {
                this.m_PenWidth = value;
            }
        }

        public LineCap StartCap
        {
            get => 
                this.m_StartCap;
            set
            {
                this.m_StartCap = value;
            }
        }

        public float X1
        {
            get => 
                this.m_X1;
            set
            {
                this.m_X1 = value;
            }
        }

        public float X2
        {
            get => 
                this.m_X2;
            set
            {
                this.m_X2 = value;
            }
        }

        public float Y1
        {
            get => 
                this.m_Y1;
            set
            {
                this.m_Y1 = value;
            }
        }

        public float Y2
        {
            get => 
                this.m_Y2;
            set
            {
                this.m_Y2 = value;
            }
        }
    }
}

