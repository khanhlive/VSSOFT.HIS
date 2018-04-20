namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.DXErrorProvider;
    using DevExpress.XtraLayout;
    using DevExpress.XtraLayout.Utils;
    using Vssoft.Common.Common.Class;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucBaseAdd26 : xucBase
    {
        protected SimpleButton btnCancel;
        protected SimpleButton btnSave;
        protected SimpleButton btnSaveNew;
        private IContainer components = null;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        protected DevExpress.Utils.ImageCollection imageCollection2;
        protected LayoutControl lcMain;
        protected LayoutControlGroup lgMain;
        protected LayoutControlItem liCancel;
        protected LayoutControlItem liId;
        protected LayoutControlItem liName;
        protected LayoutControlItem liSave;
        protected LayoutControlItem liSaveNew;
        protected TextEdit txtID;
        protected TextEdit txtNAME;

        public event ButtonClickEventHander CancelClick;

        public event ButtonClickEventHander SaveClick;

        public xucBaseAdd26()
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
            base.m_Status = Actions.Add;
            this.txtID.Focus();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xucBaseAdd26));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            this.txtNAME = new TextEdit();
            this.lcMain = new LayoutControl();
            this.btnCancel = new SimpleButton();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSaveNew = new SimpleButton();
            this.txtID = new TextEdit();
            this.btnSave = new SimpleButton();
            this.lgMain = new LayoutControlGroup();
            this.liId = new LayoutControlItem();
            this.liName = new LayoutControlItem();
            this.liSave = new LayoutControlItem();
            this.liSaveNew = new LayoutControlItem();
            this.liCancel = new LayoutControlItem();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.txtNAME.Properties.BeginInit();
            this.lcMain.BeginInit();
            this.lcMain.SuspendLayout();
            this.imageCollection2.BeginInit();
            this.txtID.Properties.BeginInit();
            this.lgMain.BeginInit();
            this.liId.BeginInit();
            this.liName.BeginInit();
            this.liSave.BeginInit();
            this.liSaveNew.BeginInit();
            this.liCancel.BeginInit();
            ((ISupportInitialize) this.Err).BeginInit();
            base.SuspendLayout();
            this.txtNAME.Location = new Point(60, 0x1f);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new Size(0x13f, 20);
            this.txtNAME.StyleController = this.lcMain;
            this.txtNAME.TabIndex = 3;
            this.txtNAME.EditValueChanged += new EventHandler(this.txtNAME_EditValueChanged);
            this.txtNAME.Leave += new EventHandler(this.txtNAME_Leave);
            this.lcMain.Controls.Add(this.txtNAME);
            this.lcMain.Controls.Add(this.btnCancel);
            this.lcMain.Controls.Add(this.btnSaveNew);
            this.lcMain.Controls.Add(this.txtID);
            this.lcMain.Controls.Add(this.btnSave);
            this.lcMain.Dock = DockStyle.Fill;
            this.lcMain.Location = new Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lgMain;
            this.lcMain.Size = new Size(0x182, 0x1c4);
            this.lcMain.TabIndex = 0x26;
            this.lcMain.Text = "layoutControl1";
            this.btnCancel.ImageIndex = 6;
            this.btnCancel.ImageList = this.imageCollection2;
            this.btnCancel.Location = new Point(60, 0x6b);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x13f, 0x16);
            this.btnCancel.StyleController = this.lcMain;
            this.btnCancel.TabIndex = 0x24;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new KeyEventHandler(this.btnCancel_KeyDown);
            this.imageCollection2.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection2.ImageStream");
            this.btnSaveNew.ImageIndex = 0;
            this.btnSaveNew.ImageList = this.imageCollection2;
            this.btnSaveNew.Location = new Point(60, 0x51);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new Size(0x13f, 0x16);
            this.btnSaveNew.StyleController = this.lcMain;
            item.Text = "Ctrl+Shift +S";
            tip.Items.Add(item);
            this.btnSaveNew.SuperTip = tip;
            this.btnSaveNew.TabIndex = 0x25;
            this.btnSaveNew.Text = "Lưu && Th\x00eam";
            this.btnSaveNew.Click += new EventHandler(this.btnSaveNew_Click);
            this.txtID.Location = new Point(60, 7);
            this.txtID.Name = "txtID";
            this.txtID.Size = new Size(0x13f, 20);
            this.txtID.StyleController = this.lcMain;
            this.txtID.TabIndex = 1;
            this.txtID.EditValueChanged += new EventHandler(this.txtID_EditValueChanged);
            this.txtID.Leave += new EventHandler(this.txtID_Leave);
            this.txtID.KeyDown += new KeyEventHandler(this.txtID_KeyDown);
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageCollection2;
            this.btnSave.Location = new Point(60, 0x37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x13f, 0x16);
            this.btnSave.StyleController = this.lcMain;
            item2.Text = "Ctrl+S\r\n";
            tip2.Items.Add(item2);
            this.btnSave.SuperTip = tip2;
            this.btnSave.TabIndex = 0x23;
            this.btnSave.Text = "Lưu && Đ\x00f3ng";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new KeyEventHandler(this.btnSave_KeyDown);
            this.lgMain.CustomizationFormText = "lgMain";
            this.lgMain.EnableIndentsWithoutBorders = DefaultBoolean.True;
            this.lgMain.GroupBordersVisible = false;
            this.lgMain.Items.AddRange(new BaseLayoutItem[] { this.liId, this.liName, this.liSave, this.liSaveNew, this.liCancel });
            this.lgMain.Location = new Point(0, 0);
            this.lgMain.Name = "lgMain";
            this.lgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lgMain.Size = new Size(0x182, 0x1c4);
            this.lgMain.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lgMain.Text = "lgMain";
            this.lgMain.TextVisible = false;
            this.liId.Control = this.txtID;
            this.liId.CustomizationFormText = "M\x00e3:";
            this.liId.Location = new Point(0, 0);
            this.liId.Name = "liId";
            this.liId.Size = new Size(0x178, 0x18);
            this.liId.Text = "M\x00e3:";
            this.liId.TextSize = new Size(0x31, 13);
            this.liName.Control = this.txtNAME;
            this.liName.CustomizationFormText = "T\x00ean:";
            this.liName.Location = new Point(0, 0x18);
            this.liName.Name = "liName";
            this.liName.Size = new Size(0x178, 0x18);
            this.liName.Text = "T\x00ean:";
            this.liName.TextSize = new Size(0x31, 13);
            this.liSave.Control = this.btnSave;
            this.liSave.CustomizationFormText = "layoutControlItem1";
            this.liSave.Location = new Point(0, 0x30);
            this.liSave.Name = "liSave";
            this.liSave.Size = new Size(0x178, 0x1a);
            this.liSave.Text = "liSave";
            this.liSave.TextSize = new Size(0x31, 13);
            this.liSaveNew.Control = this.btnSaveNew;
            this.liSaveNew.CustomizationFormText = "layoutControlItem2";
            this.liSaveNew.Location = new Point(0, 0x4a);
            this.liSaveNew.Name = "liSaveNew";
            this.liSaveNew.Size = new Size(0x178, 0x1a);
            this.liSaveNew.Text = "liSaveNew";
            this.liSaveNew.TextSize = new Size(0x31, 13);
            this.liCancel.Control = this.btnCancel;
            this.liCancel.CustomizationFormText = "layoutControlItem3";
            this.liCancel.Location = new Point(0, 100);
            this.liCancel.Name = "liCancel";
            this.liCancel.Size = new Size(0x178, 0x156);
            this.liCancel.Text = "liCancel";
            this.liCancel.TextSize = new Size(0x31, 13);
            this.Err.ContainerControl = this;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.lcMain);
            base.Name = "xucBaseAdd26";
            base.Size = new Size(0x182, 0x1c4);
            this.txtNAME.Properties.EndInit();
            this.lcMain.EndInit();
            this.lcMain.ResumeLayout(false);
            this.imageCollection2.EndInit();
            this.txtID.Properties.EndInit();
            this.lgMain.EndInit();
            this.liId.EndInit();
            this.liName.EndInit();
            this.liSave.EndInit();
            this.liSaveNew.EndInit();
            this.liCancel.EndInit();
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
                XtraMessageBox.Show((this.txtID.ErrorText.Length == 0) ? "Dữ liệu của \x00f4 n\x00e0y kh\x00f4ng được bỏ trống." : this.txtID.ErrorText, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtID.Focus();
            }
            else if ((this.txtNAME.ErrorText != string.Empty) | (this.txtNAME.Text == string.Empty))
            {
                XtraMessageBox.Show((this.txtNAME.ErrorText.Length == 0) ? "Dữ liệu của \x00f4 n\x00e0y kh\x00f4ng được bỏ trống." : this.txtNAME.ErrorText, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            this.Add();
        }

        protected virtual void SetInterface()
        {
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
            }
        }

        private void txtNAME_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit control = (TextEdit) sender;
            if ((base.m_Status != Actions.None) && (control.ErrorText != string.Empty))
            {
                this.Err.SetError(control, string.Empty);
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
                }
                if (string.IsNullOrEmpty(this.txtID.Text) && !string.IsNullOrEmpty(this.txtNAME.Text))
                {
                    this.txtID.Text = base.GenerateCode(this.txtNAME.Text);
                }
            }
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

