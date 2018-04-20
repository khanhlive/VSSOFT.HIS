namespace Vssoft.Common
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.DXErrorProvider;
    using Vssoft.Common.Common.Class;
    //using Vssoft.Utils;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class xucBaseAddH : xucBase
    {
        protected SimpleButton btnCancel;
        protected SimpleButton btnSave;
        protected SimpleButton btnSaveNew;
        private IContainer components = null;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        protected DevExpress.Utils.ImageCollection imageCollection2;

        public event ButtonClickEventHander CancelClick;

        public event ButtonClickEventHander SaveClick;

        public xucBaseAddH()
        {
            this.InitializeComponent();
            this.InitMultiLanguages();
            this.Init();
        }

        protected virtual void Add()
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
            this.Save();
            base.m_Status = Actions.Add;
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(xucBaseAddH));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.btnSave = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.btnSaveNew = new SimpleButton();
            this.imageCollection2.BeginInit();
            ((ISupportInitialize) this.Err).BeginInit();
            base.SuspendLayout();
            this.imageCollection2.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection2.ImageStream");
            this.Err.ContainerControl = this;
            this.btnSave.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.imageCollection2;
            this.btnSave.Location = new Point(0x167, 0x1b6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x5c, 0x1b);
            item.Text = "Ctrl+S\r\n";
            tip.Items.Add(item);
            this.btnSave.SuperTip = tip;
            this.btnSave.TabIndex = 0x23;
            this.btnSave.Text = "Lưu && Đ\x00f3ng";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new KeyEventHandler(this.btnSave_KeyDown);
            this.btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnCancel.ImageIndex = 6;
            this.btnCancel.ImageList = this.imageCollection2;
            this.btnCancel.Location = new Point(0x22e, 0x1b6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x5f, 0x1b);
            this.btnCancel.TabIndex = 0x24;
            this.btnCancel.Text = "Đ\x00f3ng";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new KeyEventHandler(this.btnCancel_KeyDown);
            this.btnSaveNew.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnSaveNew.ImageIndex = 0;
            this.btnSaveNew.ImageList = this.imageCollection2;
            this.btnSaveNew.Location = new Point(0x1c9, 0x1b6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new Size(0x5f, 0x1b);
            item2.Text = "Ctrl+Shift +S";
            tip2.Items.Add(item2);
            this.btnSaveNew.SuperTip = tip2;
            this.btnSaveNew.TabIndex = 0x25;
            this.btnSaveNew.Text = "Lưu && Th\x00eam";
            this.btnSaveNew.Click += new EventHandler(this.btnSaveNew_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.btnSaveNew);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnCancel);
            base.Name = "xucBaseAddH";
            base.Size = new Size(0x2a9, 0x1db);
            this.imageCollection2.EndInit();
            ((ISupportInitialize) this.Err).EndInit();
            base.ResumeLayout(false);
        }

        private void InitMultiLanguages()
        {
            //this.btnSave.Text = MultiLanguages.GetString("tbl_ToolBar", "SaveAndClose", this.btnSave.Text);
            //this.btnSaveNew.Text = MultiLanguages.GetString("tbl_ToolBar", "SaveAndNew", this.btnSaveNew.Text);
            //this.btnCancel.Text = MultiLanguages.GetString("tbl_ToolBar", "Close", this.btnCancel.Text);
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
            if (this.Check())
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

        public void SetData(string id)
        {
            this.Add();
        }

        public void SetDataByGuid(Guid id)
        {
            this.Add();
        }

        protected virtual void SetInterface()
        {
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

