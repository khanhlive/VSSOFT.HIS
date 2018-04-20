namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class xucComboEdit : ComboBoxEdit
    {
        private string _defaultText;
        private IContainer components = null;
        private RepositoryItemComboBox fProperties;

        public xucComboEdit()
        {
            this.InitializeComponent();
            base.ForeColor = Color.DarkGray;
            base.Text = this._defaultText;
            base.ForeColor = Color.DarkGray;
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
    }
}

