namespace Vssoft.Common
{
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Vssoft.Common.Common.Class;

    public class xucBaseAddH : xucBase
    {
        protected SimpleButton btnCancel;
        protected SimpleButton btnSave;
        protected SimpleButton btnSaveNew;
        private IContainer components = null;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Err;
        public PanelControl panelControl1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xucBaseAddH));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection();
            this.Err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.InsertGalleryImage("saveandclose_16x16.png", "images/save/saveandclose_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/saveandclose_16x16.png"), 0);
            this.imageCollection2.Images.SetKeyName(0, "saveandclose_16x16.png");
            this.imageCollection2.InsertGalleryImage("export_16x16.png", "images/export/export_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/export_16x16.png"), 1);
            this.imageCollection2.Images.SetKeyName(1, "export_16x16.png");
            this.imageCollection2.InsertGalleryImage("close_16x16.png", "images/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_16x16.png"), 2);
            this.imageCollection2.Images.SetKeyName(2, "close_16x16.png");
            // 
            // Err
            // 
            this.Err.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageOptions.ImageIndex = 0;
            this.btnSave.ImageOptions.ImageList = this.imageCollection2;
            this.btnSave.Location = new System.Drawing.Point(375, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 27);
            toolTipItem2.Text = "Ctrl+S\r\n";
            superToolTip2.Items.Add(toolTipItem2);
            this.btnSave.SuperTip = superToolTip2;
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Lưu && Đóng";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageOptions.ImageIndex = 2;
            this.btnCancel.ImageOptions.ImageList = this.imageCollection2;
            this.btnCancel.Location = new System.Drawing.Point(574, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 27);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNew.ImageOptions.ImageIndex = 1;
            this.btnSaveNew.ImageOptions.ImageList = this.imageCollection2;
            this.btnSaveNew.Location = new System.Drawing.Point(473, 6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(95, 27);
            toolTipItem1.Text = "Ctrl+Shift +S";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnSaveNew.SuperTip = superToolTip1;
            this.btnSaveNew.TabIndex = 37;
            this.btnSaveNew.Text = "Lưu && Thêm";
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSaveNew);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 437);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(681, 38);
            this.panelControl1.TabIndex = 38;
            // 
            // xucBaseAddH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "xucBaseAddH";
            this.Size = new System.Drawing.Size(681, 475);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

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

