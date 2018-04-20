namespace Vssoft.Common.Base
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class xucDateEdit : UserControl
    {
        private ComboBoxEdit cboDay;
        private ComboBoxEdit cboMonth;
        private ComboBoxEdit cboYear;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private int m_Day = 1;
        private int m_Month = 1;
        private bool m_ReadOnly = false;
        private int m_Year = DateTime.Now.Year;

        public xucDateEdit()
        {
            this.InitializeComponent();
            this.CreateYearItems();
            this.CreateMonthItems();
            this.CreateDayItems(this.m_Month, this.m_Year);
        }

        private void cboDay_SelectedValueChanged(object sender, EventArgs e)
        {
            this.m_Day = Convert.ToInt32(this.cboDay.Text);
        }

        private void cboMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            this.m_Month = Convert.ToInt32(this.cboMonth.Text);
            this.CreateDayItems(this.m_Month, this.m_Year);
        }

        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            this.m_Year = Convert.ToInt32(this.cboYear.Text);
            this.CreateDayItems(this.m_Month, this.m_Year);
        }

        private void CreateDayItems(int Month, int Year)
        {
            if (Month == 0)
            {
                this.cboDay.Properties.Items.Clear();
                this.cboDay.Properties.Items.AddRange(new object[] { "0" });
                this.cboDay.Text = "0";
            }
            else
            {
                int num = DateTime.DaysInMonth(Year, Month);
                if ((num + 1) != this.cboDay.Properties.Items.Count)
                {
                    this.cboDay.Properties.Items.Clear();
                    for (int i = 0; i <= num; i++)
                    {
                        this.cboDay.Properties.Items.Add(i.ToString());
                    }
                    this.cboDay.Text = this.m_Day.ToString();
                    if ((num == 0x1c) && (this.m_Day > 0x1c))
                    {
                        this.cboDay.Text = "28";
                    }
                    else if ((num == 0x1d) && (this.m_Day > 0x1d))
                    {
                        this.cboDay.Text = "29";
                    }
                    else if ((num == 30) && (this.m_Day > 30))
                    {
                        this.cboDay.Text = "30";
                    }
                }
                this.cboDay.Text = this.m_Day.ToString();
            }
        }

        private void CreateMonthItems()
        {
            this.cboMonth.Properties.Items.Clear();
            for (int i = 0; i <= 12; i++)
            {
                this.cboMonth.Properties.Items.Add(i.ToString());
            }
            this.cboMonth.Text = this.m_Month.ToString();
        }

        private void CreateYearItems()
        {
            this.cboYear.Properties.Items.Clear();
            for (int i = 0x794; i <= 0x833; i++)
            {
                this.cboYear.Properties.Items.Add(i.ToString());
            }
            this.cboYear.Text = this.m_Year.ToString();
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
            this.cboDay = new ComboBoxEdit();
            this.cboMonth = new ComboBoxEdit();
            this.cboYear = new ComboBoxEdit();
            this.label1 = new Label();
            this.label2 = new Label();
            this.cboDay.Properties.BeginInit();
            this.cboMonth.Properties.BeginInit();
            this.cboYear.Properties.BeginInit();
            base.SuspendLayout();
            this.cboDay.EditValue = "";
            this.cboDay.Location = new Point(0, 0);
            this.cboDay.Name = "cboDay";
            this.cboDay.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboDay.Properties.Items.AddRange(new object[] { 
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"
            });
            this.cboDay.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cboDay.Size = new Size(40, 20);
            this.cboDay.TabIndex = 0;
            this.cboDay.SelectedValueChanged += new EventHandler(this.cboDay_SelectedValueChanged);
            this.cboMonth.Location = new Point(60, 0);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboMonth.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cboMonth.Size = new Size(40, 20);
            this.cboMonth.TabIndex = 1;
            this.cboMonth.SelectedValueChanged += new EventHandler(this.cboMonth_SelectedValueChanged);
            this.cboYear.Location = new Point(120, 0);
            this.cboYear.Name = "cboYear";
            this.cboYear.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.cboYear.Properties.Items.AddRange(new object[] { 
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"
            });
            this.cboYear.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.cboYear.Size = new Size(60, 20);
            this.cboYear.TabIndex = 2;
            this.cboYear.SelectedValueChanged += new EventHandler(this.cboYear_SelectedValueChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x2d, 4);
            this.label1.Name = "label1";
            this.label1.Size = new Size(12, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "/";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x69, 4);
            this.label2.Name = "label2";
            this.label2.Size = new Size(12, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "/";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cboYear);
            base.Controls.Add(this.cboMonth);
            base.Controls.Add(this.cboDay);
            base.Name = "xucDateEdit";
            base.Size = new Size(180, 20);
            this.cboDay.Properties.EndInit();
            this.cboMonth.Properties.EndInit();
            this.cboYear.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public int Day
        {
            get => 
                this.m_Day;
            set
            {
                this.m_Day = value;
            }
        }

        public int Month
        {
            get => 
                this.m_Month;
            set
            {
                this.m_Month = value;
                this.cboMonth.Text = this.m_Month.ToString();
                this.CreateDayItems(this.m_Month, this.m_Year);
            }
        }

        public bool ReadOnly
        {
            get => 
                this.m_ReadOnly;
            set
            {
                this.m_ReadOnly = value;
                this.cboDay.Properties.ReadOnly = this.m_ReadOnly;
                this.cboMonth.Properties.ReadOnly = this.m_ReadOnly;
                this.cboYear.Properties.ReadOnly = this.m_ReadOnly;
            }
        }

        public int Year
        {
            get => 
                this.m_Year;
            set
            {
                this.m_Year = value;
                this.cboYear.Text = this.m_Year.ToString();
                this.CreateDayItems(this.m_Month, this.m_Year);
            }
        }
    }
}

