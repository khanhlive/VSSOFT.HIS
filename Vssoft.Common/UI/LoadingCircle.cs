namespace Vssoft.Common.UI
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class LoadingCircle : Control
    {
        private IContainer components = null;
        private readonly System.Drawing.Color DefaultColor = System.Drawing.Color.DarkGray;
        private const int DefaultInnerCircleRadius = 8;
        private const int DefaultNumberOfSpoke = 10;
        private const int DefaultOuterCircleRadius = 10;
        private const int DefaultSpokeThickness = 4;
        private const int FireFoxInnerCircleRadius = 6;
        private const int FireFoxNumberOfSpoke = 9;
        private const int FireFoxOuterCircleRadius = 7;
        private const int FireFoxSpokeThickness = 4;
        private const int IE7InnerCircleRadius = 8;
        private const int IE7NumberOfSpoke = 0x18;
        private const int IE7OuterCircleRadius = 9;
        private const int IE7SpokeThickness = 4;
        private double[] m_Angles;
        private PointF m_CenterPoint;
        private System.Drawing.Color m_Color;
        private System.Drawing.Color[] m_Colors;
        private int m_InnerCircleRadius;
        private bool m_IsTimerActive;
        private int m_NumberOfSpoke;
        private int m_OuterCircleRadius;
        private int m_ProgressValue;
        private int m_SpokeThickness;
        private StylePresets m_StylePreset;
        private Timer m_Timer;
        private const int MacOSXInnerCircleRadius = 5;
        private const int MacOSXNumberOfSpoke = 12;
        private const int MacOSXOuterCircleRadius = 11;
        private const int MacOSXSpokeThickness = 2;
        private const double NumberOfDegreesInCircle = 360.0;
        private const double NumberOfDegreesInHalfCircle = 180.0;

        public LoadingCircle()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.m_Color = this.DefaultColor;
            this.GenerateColorsPallet();
            this.GetSpokesAngles();
            this.GetControlCenterPoint();
            this.StylePreset = StylePresets.Custom;
            this.m_Timer = new Timer();
            this.m_Timer.Tick += new EventHandler(this.aTimer_Tick);
            this.ActiveTimer();
            base.Resize += new EventHandler(this.LoadingCircle_Resize);
        }

        private void ActiveTimer()
        {
            if (this.m_IsTimerActive)
            {
                this.m_Timer.Start();
            }
            else
            {
                this.m_Timer.Stop();
                this.Value = 0;
            }
            this.GenerateColorsPallet();
            base.Invalidate();
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            this.SetPosition(this.Value);
        }

        private System.Drawing.Color Darken(System.Drawing.Color _objColor, int _intPercent)
        {
            int r = _objColor.R;
            int g = _objColor.G;
            int b = _objColor.B;
            return System.Drawing.Color.FromArgb(_intPercent, Math.Min(r, 0xff), Math.Min(g, 0xff), Math.Min(b, 0xff));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawLine(Graphics _objGraphics, PointF _objPointOne, PointF _objPointTwo, System.Drawing.Color _objColor, int _intLineThickness)
        {
            using (Pen pen = new Pen(new SolidBrush(_objColor), (float) _intLineThickness))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                _objGraphics.DrawLine(pen, _objPointOne, _objPointTwo);
            }
        }

        private void GenerateColorsPallet()
        {
            this.m_Colors = this.GenerateColorsPallet(this.m_Color, this.Active, this.m_NumberOfSpoke);
        }

        private System.Drawing.Color[] GenerateColorsPallet(System.Drawing.Color _objColor, bool _blnShadeColor, int _intNbSpoke)
        {
            System.Drawing.Color[] colorArray = new System.Drawing.Color[this.NumberSpoke];
            byte num = (byte) (0xff / this.NumberSpoke);
            byte num2 = 0;
            for (int i = 0; i < this.NumberSpoke; i++)
            {
                if (_blnShadeColor)
                {
                    if ((i == 0) || (i < (this.NumberSpoke - _intNbSpoke)))
                    {
                        colorArray[i] = _objColor;
                    }
                    else
                    {
                        num2 = (byte) (num2 + num);
                        if (num2 > 0xff)
                        {
                            num2 = 0xff;
                        }
                        colorArray[i] = this.Darken(_objColor, num2);
                    }
                }
                else
                {
                    colorArray[i] = _objColor;
                }
            }
            return colorArray;
        }

        private void GetControlCenterPoint()
        {
            this.m_CenterPoint = this.GetControlCenterPoint(this);
        }

        private PointF GetControlCenterPoint(Control _objControl) => 
            new PointF((float) (_objControl.Width / 2), (float) ((_objControl.Height / 2) - 1));

        private PointF GetCoordinate(PointF _objCircleCenter, int _intRadius, double _dblAngle)
        {
            double d = (3.1415926535897931 * _dblAngle) / 180.0;
            return new PointF(_objCircleCenter.X + (_intRadius * ((float) Math.Cos(d))), _objCircleCenter.Y + (_intRadius * ((float) Math.Sin(d))));
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            proposedSize.Width = (this.m_OuterCircleRadius + this.m_SpokeThickness) * 2;
            return proposedSize;
        }

        private void GetSpokesAngles()
        {
            this.m_Angles = this.GetSpokesAngles(this.NumberSpoke);
        }

        private double[] GetSpokesAngles(int _intNumberSpoke)
        {
            double[] numArray = new double[_intNumberSpoke];
            double num = 360.0 / ((double) _intNumberSpoke);
            for (int i = 0; i < _intNumberSpoke; i++)
            {
                numArray[i] = (i == 0) ? num : (numArray[i - 1] + num);
            }
            return numArray;
        }

        private void LoadingCircle_Resize(object sender, EventArgs e)
        {
            this.GetControlCenterPoint();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.m_NumberOfSpoke > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                int index = this.Value;
                for (int i = 0; i < this.m_NumberOfSpoke; i++)
                {
                    index = index % this.m_NumberOfSpoke;
                    this.DrawLine(e.Graphics, this.GetCoordinate(this.m_CenterPoint, this.m_InnerCircleRadius, this.m_Angles[index]), this.GetCoordinate(this.m_CenterPoint, this.m_OuterCircleRadius, this.m_Angles[index]), this.m_Colors[i], this.m_SpokeThickness);
                    index++;
                }
            }
            base.OnPaint(e);
        }

        public void SetCircleAppearance(int numberSpoke, int spokeThickness, int innerCircleRadius, int outerCircleRadius)
        {
            this.NumberSpoke = numberSpoke;
            this.SpokeThickness = spokeThickness;
            this.InnerCircleRadius = innerCircleRadius;
            this.OuterCircleRadius = outerCircleRadius;
            base.Invalidate();
        }

        public void SetPosition(int value)
        {
            int num;
            this.Value = value;
            this.Value = num = this.Value + 1;
            this.Value = num % this.m_NumberOfSpoke;
            base.Invalidate();
        }

        [Description("Gets or sets the number of spoke."), Category("LoadingCircle")]
        public bool Active
        {
            get => 
                this.m_IsTimerActive;
            set
            {
                this.m_IsTimerActive = value;
                this.ActiveTimer();
            }
        }

        [TypeConverter("System.Drawing.ColorConverter"), Category("LoadingCircle"), Description("Sets the color of spoke.")]
        public System.Drawing.Color Color
        {
            get => 
                this.m_Color;
            set
            {
                this.m_Color = value;
                this.GenerateColorsPallet();
                base.Invalidate();
            }
        }

        [Description("Gets or sets the radius of inner circle."), Category("LoadingCircle")]
        public int InnerCircleRadius
        {
            get
            {
                if (this.m_InnerCircleRadius == 0)
                {
                    this.m_InnerCircleRadius = 8;
                }
                return this.m_InnerCircleRadius;
            }
            set
            {
                this.m_InnerCircleRadius = value;
                base.Invalidate();
            }
        }

        [Description("Gets or sets the number of spoke."), Category("LoadingCircle")]
        public int NumberSpoke
        {
            get
            {
                if (this.m_NumberOfSpoke == 0)
                {
                    this.m_NumberOfSpoke = 10;
                }
                return this.m_NumberOfSpoke;
            }
            set
            {
                if ((this.m_NumberOfSpoke != value) && (this.m_NumberOfSpoke > 0))
                {
                    this.m_NumberOfSpoke = value;
                    this.GenerateColorsPallet();
                    this.GetSpokesAngles();
                    base.Invalidate();
                }
            }
        }

        [Description("Gets or sets the radius of outer circle."), Category("LoadingCircle")]
        public int OuterCircleRadius
        {
            get
            {
                if (this.m_OuterCircleRadius == 0)
                {
                    this.m_OuterCircleRadius = 10;
                }
                return this.m_OuterCircleRadius;
            }
            set
            {
                this.m_OuterCircleRadius = value;
                base.Invalidate();
            }
        }

        [Description("Gets or sets the rotation speed. Higher the slower."), Category("LoadingCircle")]
        public int RotationSpeed
        {
            get => 
                this.m_Timer.Interval;
            set
            {
                if (value > 0)
                {
                    this.m_Timer.Interval = value;
                }
            }
        }

        [Description("Gets or sets the thickness of a spoke."), Category("LoadingCircle")]
        public int SpokeThickness
        {
            get
            {
                if (this.m_SpokeThickness <= 0)
                {
                    this.m_SpokeThickness = 4;
                }
                return this.m_SpokeThickness;
            }
            set
            {
                this.m_SpokeThickness = value;
                base.Invalidate();
            }
        }

        [Category("LoadingCircle"), DefaultValue(typeof(StylePresets), "Custom"), Description("Quickly sets the style to one of these presets, or a custom style if desired")]
        public StylePresets StylePreset
        {
            get => 
                this.m_StylePreset;
            set
            {
                this.m_StylePreset = value;
                switch (this.m_StylePreset)
                {
                    case StylePresets.MacOSX:
                        this.SetCircleAppearance(12, 2, 5, 11);
                        break;

                    case StylePresets.Firefox:
                        this.SetCircleAppearance(9, 4, 6, 7);
                        break;

                    case StylePresets.IE7:
                        this.SetCircleAppearance(0x18, 4, 8, 9);
                        break;

                    case StylePresets.Custom:
                        this.SetCircleAppearance(10, 4, 8, 10);
                        break;
                }
            }
        }

        public int Value
        {
            get => 
                this.m_ProgressValue;
            set
            {
                this.m_ProgressValue = value;
                base.Invalidate();
            }
        }

        public enum StylePresets
        {
            MacOSX,
            Firefox,
            IE7,
            Custom
        }
    }
}

