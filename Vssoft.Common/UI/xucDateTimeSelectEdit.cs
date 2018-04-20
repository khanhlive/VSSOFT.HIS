namespace Vssoft.Common.UI
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using Microsoft.VisualBasic;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucDateTimeSelectEdit : ComboBoxEdit
    {
        private DateTime _begin;
        private string _defaultText;
        private DateTime _to;
        private IContainer components = null;
        private RepositoryItemComboBox fProperties;

        public event DataTimeChangedEventHander DataTimeChanged;

        public xucDateTimeSelectEdit()
        {
            this.InitializeComponent();
            base.ForeColor = Color.DarkGray;
            base.Text = this._defaultText;
            base.ForeColor = Color.DarkGray;
            base.Properties.Items.Clear();
            base.Properties.Items.AddRange(new object[] { 
                "H\x00f4m nay", "Tuần n\x00e0y", "Th\x00e1ng n\x00e0y", "Qu\x00fd n\x00e0y", "Năm nay", "Th\x00e1ng 1", "Th\x00e1ng 2", "Th\x00e1ng 3", "Th\x00e1ng 4", "Th\x00e1ng 5", "Th\x00e1ng 6", "Th\x00e1ng 7", "Th\x00e1ng 9", "Th\x00e1ng 10", "Th\x00e1ng 11", "Th\x00e1ng 12",
                "Qu\x00fd 1", "Qu\x00fd 2", "Qu\x00fd 3", "Qu\x00fd 4"
            });
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
            this.fProperties = new RepositoryItemComboBox();
            this.fProperties.BeginInit();
            base.SuspendLayout();
            this.fProperties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.fProperties.Name = "fProperties";
            this.EditValue = "H\x00f4m nay";
            this.fProperties.EndInit();
            base.ResumeLayout(false);
        }

        protected override void OnClick(EventArgs e)
        {
            if (base.Text == this._defaultText)
            {
                base.Text = "";
            }
            base.ForeColor = Color.Black;
        }

        protected override void OnLeave(EventArgs e)
        {
            if (base.Text.Length == 0)
            {
                base.Text = this._defaultText;
                base.ForeColor = Color.DarkGray;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (base.Text.Length == 0)
            {
                base.Text = this._defaultText;
                base.ForeColor = Color.DarkGray;
            }
            else
            {
                base.ForeColor = Color.Black;
            }
        }

        private void RaiseDataTimeChangedEventHander(DateTime Begin, DateTime To)
        {
            if (this.DataTimeChanged != null)
            {
                this.DataTimeChanged(this, Begin, To);
            }
        }

        private void SetDateTime(string text)
        {
            if (text == "H\x00f4m nay")
            {
                this.From = DateTime.Now;
                this.To = DateTime.Now;
            }
            else if (text == "Tuần n\x00e0y")
            {
                this.From = DateAndTime.DateAdd(DateInterval.Day, (double) -DateAndTime.Weekday(DateTime.Now, FirstDayOfWeek.Monday), DateTime.Now);
                this.To = DateAndTime.DateAdd(DateInterval.Day, (double) DateAndTime.Weekday(DateTime.Now, FirstDayOfWeek.Monday), DateTime.Now);
            }
            else if (text == "Th\x00e1ng n\x00e0y")
            {
                this.From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd n\x00e0y")
            {
                if ((DateTime.Now.Month >= 1) & (DateTime.Now.Month <= 3))
                {
                    this.From = new DateTime(DateTime.Now.Year, 1, 1);
                    this.To = this.From.AddMonths(4).AddDays(-1.0);
                }
                else if ((DateTime.Now.Month >= 4) & (DateTime.Now.Month <= 6))
                {
                    this.From = new DateTime(DateTime.Now.Year, 4, 1);
                    this.To = this.From.AddMonths(4).AddDays(-1.0);
                }
                else if ((DateTime.Now.Month >= 7) & (DateTime.Now.Month <= 9))
                {
                    this.From = new DateTime(DateTime.Now.Year, 9, 1);
                    this.To = this.From.AddMonths(4).AddDays(-1.0);
                }
                else
                {
                    this.From = new DateTime(DateTime.Now.Year, 10, 1);
                    this.To = this.From.AddMonths(4).AddDays(-1.0);
                }
            }
            else if (text == "Năm nay")
            {
                this.From = new DateTime(DateTime.Now.Year, 1, 1);
                this.To = this.From.AddMonths(12).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 1")
            {
                this.From = new DateTime(DateTime.Now.Year, 1, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 2")
            {
                this.From = new DateTime(DateTime.Now.Year, 2, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 3")
            {
                this.From = new DateTime(DateTime.Now.Year, 3, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 4")
            {
                this.From = new DateTime(DateTime.Now.Year, 4, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 5")
            {
                this.From = new DateTime(DateTime.Now.Year, 5, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 6")
            {
                this.From = new DateTime(DateTime.Now.Year, 6, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 7")
            {
                this.From = new DateTime(DateTime.Now.Year, 7, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 8")
            {
                this.From = new DateTime(DateTime.Now.Year, 8, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 9")
            {
                this.From = new DateTime(DateTime.Now.Year, 9, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 10")
            {
                this.From = new DateTime(DateTime.Now.Year, 10, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 11")
            {
                this.From = new DateTime(DateTime.Now.Year, 11, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Th\x00e1ng 12")
            {
                this.From = new DateTime(DateTime.Now.Year, 12, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 1")
            {
                this.From = new DateTime(DateTime.Now.Year, 1, 1);
                this.To = this.From.AddMonths(3).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 2")
            {
                this.From = new DateTime(DateTime.Now.Year, 4, 1);
                this.To = this.From.AddMonths(3).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 3")
            {
                this.From = new DateTime(DateTime.Now.Year, 7, 1);
                this.To = this.From.AddMonths(3).AddDays(-1.0);
            }
            else if (text == "Qu\x00fd 4")
            {
                this.From = new DateTime(DateTime.Now.Year, 10, 1);
                this.To = this.From.AddMonths(3).AddDays(-1.0);
            }
            else
            {
                this.From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                this.To = this.From.AddMonths(1).AddDays(-1.0);
            }
            this.RaiseDataTimeChangedEventHander(this._begin, this._to);
        }

        public string DefaultText
        {
            get => 
                this._defaultText;
            set
            {
                this._defaultText = value;
                base.Text = this._defaultText;
                base.Properties.NullText = this._defaultText;
                base.Properties.NullValuePrompt = this._defaultText;
            }
        }

        public DateTime From
        {
            get => 
                this._begin;
            set
            {
                this._begin = value;
            }
        }

        public override int SelectedIndex
        {
            get
            {
                this.SetDateTime(base.Text);
                return base.SelectedIndex;
            }
            set
            {
                base.SelectedIndex = value;
                this.SetDateTime(base.Text);
            }
        }

        public sealed override string Text
        {
            get => 
                ((base.Text == this._defaultText) ? "" : base.Text);
            set
            {
                if (value != this._defaultText)
                {
                    base.Text = value;
                }
            }
        }

        public DateTime To
        {
            get => 
                this._to;
            set
            {
                this._to = value;
            }
        }

        public delegate void DataTimeChangedEventHander(object sender, DateTime Begin, DateTime To);
    }
}

