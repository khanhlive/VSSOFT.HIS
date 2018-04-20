namespace Vssoft.Common.UI
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Timers;
    using System.Windows.Forms;
    
    public class SpinningProgress : UserControl
    {
        private IContainer components;
        private Region innerBackgroundRegion;
        private Color m_ActiveColour = Color.FromArgb(0x23, 0x92, 0x21);
        private bool m_AutoIncrement = true;
        private System.Timers.Timer m_AutoRotateTimer;
        private bool m_BehindIsActive = true;
        private Color m_InactiveColour = Color.FromArgb(0xda, 0xda, 0xda);
        private double m_IncrementFrequency = 100.0;
        private Color m_TransistionColour = Color.FromArgb(0x81, 0xf2, 0x79);
        private int m_TransitionSegment = 0;
        private GraphicsPath[] segmentPaths = new GraphicsPath[12];

        public SpinningProgress()
        {
            this.InitializeComponent();
            this.CalculateSegments();
            this.m_AutoRotateTimer = new System.Timers.Timer(this.m_IncrementFrequency);
            this.m_AutoRotateTimer.Elapsed += new ElapsedEventHandler(this.IncrementTransisionSegment);
            this.DoubleBuffered = true;
            this.m_AutoRotateTimer.Start();
            base.EnabledChanged += new EventHandler(this.SpinningProgress_EnabledChanged);
            base.Paint += new PaintEventHandler(this.ProgressDisk_Paint);
            base.Resize += new EventHandler(this.ProgressDisk_Resize);
            base.SizeChanged += new EventHandler(this.ProgressDisk_SizeChanged);
        }

        private void CalculateSegments()
        {
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Rectangle rectangle2 = new Rectangle((base.Width * 7) / 30, (base.Height * 7) / 30, base.Width - ((base.Width * 14) / 30), base.Height - ((base.Height * 14) / 30));
            GraphicsPath path = null;
            for (int i = 0; i < 12; i++)
            {
                this.segmentPaths[i] = new GraphicsPath();
                this.segmentPaths[i].AddPie(rect, (float) ((i * 30) - 90), 25f);
            }
            path = new GraphicsPath();
            path.AddPie(rectangle2, 0f, 360f);
            this.innerBackgroundRegion = new Region(path);
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void IncrementTransisionSegment(object sender, ElapsedEventArgs e)
        {
            if (this.m_TransitionSegment == 11)
            {
                this.m_TransitionSegment = 0;
                this.m_BehindIsActive = !this.m_BehindIsActive;
            }
            else if (this.m_TransitionSegment == -1)
            {
                this.m_TransitionSegment = 0;
            }
            else
            {
                this.m_TransitionSegment++;
            }
            base.Invalidate();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Name = "SpinningProgress";
            base.Size = new Size(30, 30);
            base.ResumeLayout(false);
        }

        private void ProgressDisk_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.ExcludeClip(this.innerBackgroundRegion);
            for (int i = 0; i < 12; i++)
            {
                if (base.Enabled)
                {
                    if (i == this.m_TransitionSegment)
                    {
                        e.Graphics.FillPath(new SolidBrush(this.m_TransistionColour), this.segmentPaths[i]);
                    }
                    else if (i < this.m_TransitionSegment)
                    {
                        if (this.m_BehindIsActive)
                        {
                            e.Graphics.FillPath(new SolidBrush(this.m_ActiveColour), this.segmentPaths[i]);
                        }
                        else
                        {
                            e.Graphics.FillPath(new SolidBrush(this.m_InactiveColour), this.segmentPaths[i]);
                        }
                    }
                    else if (this.m_BehindIsActive)
                    {
                        e.Graphics.FillPath(new SolidBrush(this.m_InactiveColour), this.segmentPaths[i]);
                    }
                    else
                    {
                        e.Graphics.FillPath(new SolidBrush(this.m_ActiveColour), this.segmentPaths[i]);
                    }
                }
                else
                {
                    e.Graphics.FillPath(new SolidBrush(this.m_InactiveColour), this.segmentPaths[i]);
                }
            }
        }

        private void ProgressDisk_Resize(object sender, EventArgs e)
        {
            this.CalculateSegments();
        }

        private void ProgressDisk_SizeChanged(object sender, EventArgs e)
        {
            this.CalculateSegments();
        }

        private void SpinningProgress_EnabledChanged(object sender, EventArgs e)
        {
            if (base.Enabled)
            {
                if (this.m_AutoRotateTimer != null)
                {
                    this.m_AutoRotateTimer.Start();
                }
            }
            else if (this.m_AutoRotateTimer != null)
            {
                this.m_AutoRotateTimer.Stop();
            }
        }

        [DefaultValue(typeof(Color), "35, 146, 33")]
        public Color ActiveSegmentColour
        {
            get => 
                this.m_ActiveColour;
            set
            {
                this.m_ActiveColour = value;
                base.Invalidate();
            }
        }

        [DefaultValue(true)]
        public bool AutoIncrement
        {
            get => 
                this.m_AutoIncrement;
            set
            {
                this.m_AutoIncrement = value;
                if (!(value || (this.m_AutoRotateTimer == null)))
                {
                    this.m_AutoRotateTimer.Dispose();
                    this.m_AutoRotateTimer = null;
                }
                if (value && (this.m_AutoRotateTimer == null))
                {
                    this.m_AutoRotateTimer = new System.Timers.Timer(this.m_IncrementFrequency);
                    this.m_AutoRotateTimer.Elapsed += new ElapsedEventHandler(this.IncrementTransisionSegment);
                    this.m_AutoRotateTimer.Start();
                }
            }
        }

        [DefaultValue(100)]
        public double AutoIncrementFrequency
        {
            get => 
                this.m_IncrementFrequency;
            set
            {
                this.m_IncrementFrequency = value;
                if (this.m_AutoRotateTimer != null)
                {
                    this.AutoIncrement = false;
                    this.AutoIncrement = true;
                }
            }
        }

        [DefaultValue(true)]
        public bool BehindTransistionSegmentIsActive
        {
            get => 
                this.m_BehindIsActive;
            set
            {
                this.m_BehindIsActive = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "218, 218, 218")]
        public Color InactiveSegmentColour
        {
            get => 
                this.m_InactiveColour;
            set
            {
                this.m_InactiveColour = value;
                base.Invalidate();
            }
        }

        [DefaultValue(-1)]
        public int TransistionSegment
        {
            get => 
                this.m_TransitionSegment;
            set
            {
                if ((value > 11) || (value < -1))
                {
                    throw new ArgumentException("TransistionSegment must be between -1 and 11");
                }
                this.m_TransitionSegment = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "129, 242, 121")]
        public Color TransistionSegmentColour
        {
            get => 
                this.m_TransistionColour;
            set
            {
                this.m_TransistionColour = value;
                base.Invalidate();
            }
        }
    }
}

