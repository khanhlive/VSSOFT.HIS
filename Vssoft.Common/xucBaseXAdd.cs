namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.DXErrorProvider;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucBaseXAdd : xucBase
    {
        protected SimpleButton btnCancel;
        protected SimpleButton btnSave;
        protected SimpleButton btnSaveNew;
        private IContainer components = null;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        protected GroupControl gcInfo;
        protected DevExpress.Utils.ImageCollection imageCollection2;
        protected LabelControl lblId;
        protected LabelControl lblName;
        protected TextEdit txtID;
        protected ComboBoxEdit txtNAME;

        public event ButtonClickEventHander CancelClick;

        public event ButtonClickEventHander SaveClick;

        public xucBaseXAdd()
        {
            this.InitializeComponent();
            this.Init();
        }

        public virtual void Add()
        {
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.RaiseCancelClickEventHander();
        }

        protected virtual void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            this.btnCancel_Click(this.btnCancel, e);
        }

        protected virtual void btnSave_Click(object sender, EventArgs e)
        {
            base.m_CloseOrNew = CloseOrNew.Close;
            this.Save();
        }

        protected virtual void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            this.btnSave_Click(this.btnSave, e);
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            base.m_CloseOrNew = CloseOrNew.New;
            this.txtID.Properties.ReadOnly = false;
            this.Save();
            this.Add();
        }

        public virtual void Change()
        {
        }

        protected virtual bool Check() => 
            true;

        public virtual void Delete()
        {
            this.uc_Delete();
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
            this.ReLoad();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xucBaseXAdd));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            this.gcInfo = new GroupControl();
            this.txtNAME = new ComboBoxEdit();
            this.lblName = new LabelControl();
            this.txtID = new TextEdit();
            this.lblId = new LabelControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btnSave = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.btnSaveNew = new SimpleButton();
            this.gcInfo.BeginInit();
            this.gcInfo.SuspendLayout();
            this.txtNAME.Properties.BeginInit();
            this.txtID.Properties.BeginInit();
            this.imageCollection2.BeginInit();
            ((ISupportInitialize) this.Err).BeginInit();
            base.SuspendLayout();
            this.gcInfo.Controls.Add(this.txtNAME);
            this.gcInfo.Controls.Add(this.lblName);
            this.gcInfo.Controls.Add(this.txtID);
            this.gcInfo.Controls.Add(this.lblId);
            this.gcInfo.Location = new Point(1, 1);
            this.gcInfo.Name = "gcInfo";
            this.gcInfo.Size = new Size(0x17f, 0x37);
            this.gcInfo.TabIndex = 2;
            this.gcInfo.Text = "Th\x00f4ng tin bắt buộc";
            this.txtNAME.AllowHtmlTextInToolTip = DefaultBoolean.True;
            this.txtNAME.Location = new Point(0x9b, 0x1a);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Properties.DropDownRows = 10;
            this.txtNAME.Properties.ImmediatePopup = true;
            this.txtNAME.Properties.PopupSizeable = true;
            this.txtNAME.Size = new Size(0xde, 20);
            this.txtNAME.TabIndex = 3;
            this.txtNAME.EditValueChanged += new EventHandler(this.txtNAME_EditValueChanged);
            this.txtNAME.MouseClick += new MouseEventHandler(this.txtNAME_MouseClick);
            this.txtNAME.Leave += new EventHandler(this.txtNAME_Leave);
            this.lblName.Location = new Point(0x7e, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new Size(0x12, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "T\x00ean";
            this.txtID.Location = new Point(0x1b, 0x1a);
            this.txtID.Name = "txtID";
            this.txtID.Properties.MaxLength = 20;
            this.txtID.Size = new Size(0x5d, 20);
            this.txtID.TabIndex = 1;
            this.txtID.EditValueChanged += new EventHandler(this.txtID_EditValueChanged);
            this.txtID.Leave += new EventHandler(this.txtID_Leave);
            this.txtID.KeyDown += new KeyEventHandler(this.txtID_KeyDown);
            this.lblId.Location = new Point(6, 0x1d);
            this.lblId.Name = "lblId";
            this.lblId.Size = new Size(14, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "M\x00e3";
//            this.imageCollection2.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection2.ImageStream");
            this.Err.ContainerControl = this;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageCollection2;
            this.btnSave.Location = new Point(0x59, 0x4e);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x58, 0x1b);
            item.Text = "Ctrl+S\r\n";
            tip.Items.Add(item);
            this.btnSave.SuperTip = tip;
            this.btnSave.TabIndex = 0x23;
            this.btnSave.Text = "Lưu && Đ\x00f3ng";
            this.btnSave.Visible = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new KeyEventHandler(this.btnSave_KeyDown);
            this.btnCancel.ImageIndex = 6;
            this.btnCancel.ImageList = this.imageCollection2;
            this.btnCancel.Location = new Point(0x114, 0x4e);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x5f, 0x1b);
            this.btnCancel.TabIndex = 0x24;
            this.btnCancel.Text = "Đ\x00f3ng";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new KeyEventHandler(this.btnCancel_KeyDown);
            this.btnSaveNew.ImageIndex = 0;
            this.btnSaveNew.ImageList = this.imageCollection2;
            this.btnSaveNew.Location = new Point(0xb7, 0x4e);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new Size(0x57, 0x1b);
            item2.Text = "Ctrl+Shift +S";
            tip2.Items.Add(item2);
            this.btnSaveNew.SuperTip = tip2;
            this.btnSaveNew.TabIndex = 0x25;
            this.btnSaveNew.Text = "Lưu";
            this.btnSaveNew.Click += new EventHandler(this.btnSaveNew_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.btnSaveNew);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.gcInfo);
            this.DoubleBuffered = true;
            base.Name = "xucBaseXAdd";
            base.Size = new Size(0x182, 0x6c);
            this.gcInfo.EndInit();
            this.gcInfo.ResumeLayout(false);
            this.gcInfo.PerformLayout();
            this.txtNAME.Properties.EndInit();
            this.txtID.Properties.EndInit();
            this.imageCollection2.EndInit();
            ((ISupportInitialize) this.Err).EndInit();
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

        public virtual void ReLoad()
        {
        }

        public virtual void Save()
        {
            if ((this.txtID.ErrorText != string.Empty) | (this.txtID.Text == string.Empty))
            {
                XtraMessageBox.Show((this.txtID.ErrorText.Length == 0) ? "Dữ liệu của \x00f4 n\x00e0y kh\x00f4ng được bỏ trống." : this.txtID.ErrorText, "Th\x00f4ng b\x00e1o");
                this.txtID.Focus();
            }
            else if ((this.txtNAME.ErrorText != string.Empty) | (this.txtNAME.Text == string.Empty))
            {
                XtraMessageBox.Show((this.txtNAME.ErrorText.Length == 0) ? "Dữ liệu của \x00f4 n\x00e0y kh\x00f4ng được bỏ trống." : this.txtNAME.ErrorText, "Th\x00f4ng b\x00e1o");
                this.txtNAME.Focus();
            }
            else if (this.Check())
            {
                if (base.m_Status == Actions.Add)
                {
                    this.uc_Save();
                }
                else if (base.m_Status == Actions.Update)
                {
                    this.uc_Update();
                }
                else if (base.m_Status == Actions.Change)
                {
                    this.uc_Change();
                }
            }
        }

        public virtual void SetData(object item)
        {
        }

        public void SetData(string ID)
        {
            this.txtID.Text = ID;
            this.txtNAME.Focus();
        }

        protected virtual void SetInterface()
        {
        }

        protected virtual void SetValue(DataTable data)
        {
            if ((data != null) && (data.Columns.Count != 0))
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    this.txtNAME.Properties.Items.Add(data.Rows[i][0]);
                }
            }
        }

        protected virtual void SetValue(DataTable data, string FieldName)
        {
            if (data != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    this.txtNAME.Properties.Items.Add(data.Rows[i][FieldName]);
                }
            }
        }

        protected virtual void txtID_EditValueChanged(object sender, EventArgs e)
        {
        }

        protected virtual void txtID_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            TextEdit control = (TextEdit) sender;
            if ((base.m_Status != Actions.None) && (control.Text == string.Empty))
            {
                this.Err.SetError(control, "Vui l\x00f2ng nhập th\x00f4ng tin." + this.Text);
                control.Focus();
            }
        }

        private void txtNAME_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit control = (TextEdit) sender;
            if (base.m_Status != Actions.None)
            {
                if (control.ErrorText != string.Empty)
                {
                    this.Err.SetError(control, string.Empty);
                }
                this.txtNAME.ClosePopup();
            }
        }

        private void txtNAME_Leave(object sender, EventArgs e)
        {
            TextEdit control = (TextEdit) sender;
            if (base.m_Status != Actions.None)
            {
                if (control.Text == string.Empty)
                {
                    this.Err.SetError(control, "Vui l\x00f2ng nhập th\x00f4ng tin." + this.Text);
                    control.Focus();
                }
                if (string.IsNullOrEmpty(this.txtID.Text) && !string.IsNullOrEmpty(this.txtNAME.Text))
                {
                    this.txtID.Text = base.GenerateCode(this.txtNAME.Text);
                }
            }
        }

        protected virtual void txtNAME_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtNAME.ShowPopup();
        }

        protected virtual string uc_Change() => 
            string.Empty;

        protected virtual string uc_Delete() => 
            string.Empty;

        protected virtual string uc_Save() => 
            string.Empty;

        protected virtual string uc_Update() => 
            string.Empty;
    }
}

