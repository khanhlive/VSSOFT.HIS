namespace Vssoft.Dictionary.UI.Core.Actions
{
    partial class ucAddDIC_XAPHUONG
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmbDistrict = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmbProvince = new DevExpress.XtraEditors.LookUpEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.cmbDistrict);
            this.layoutControl1.Controls.Add(this.cmbProvince);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(936, 47);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(936, 47);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(53, 12);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Mask.EditMask = "[0-9A-Z]{1,2}";
            this.txtID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            this.txtID.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtID.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(95, 27);
            this.layoutControlItem1.Text = "Mã xã:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(37, 13);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 100;
            this.txtName.Size = new System.Drawing.Size(238, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(95, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(283, 27);
            this.layoutControlItem2.Text = "Tên xã:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmbDistrict;
            this.layoutControlItem3.Location = new System.Drawing.Point(378, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(238, 27);
            this.layoutControlItem3.Text = "Huyện:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(37, 13);
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.Location = new System.Drawing.Point(431, 12);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDistrict.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHuyen", "Tên huyện")});
            this.cmbDistrict.Properties.DisplayMember = "TenHuyen";
            this.cmbDistrict.Properties.NullText = "";
            this.cmbDistrict.Properties.PopupSizeable = false;
            this.cmbDistrict.Properties.ShowHeader = false;
            this.cmbDistrict.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbDistrict.Properties.ValueMember = "MaHuyen";
            this.cmbDistrict.Size = new System.Drawing.Size(193, 20);
            this.cmbDistrict.StyleController = this.layoutControl1;
            this.cmbDistrict.TabIndex = 6;
            this.cmbDistrict.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.cmbDistrict.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cmbProvince;
            this.layoutControlItem4.Location = new System.Drawing.Point(616, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(222, 27);
            this.layoutControlItem4.Text = "Tỉnh:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(37, 13);
            // 
            // cmbProvince
            // 
            this.cmbProvince.Location = new System.Drawing.Point(669, 12);
            this.cmbProvince.Name = "cmbProvince";
            this.cmbProvince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProvince.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTinh", "Tên tỉnh")});
            this.cmbProvince.Properties.DisplayMember = "TenTinh";
            this.cmbProvince.Properties.NullText = "";
            this.cmbProvince.Properties.PopupSizeable = false;
            this.cmbProvince.Properties.ShowHeader = false;
            this.cmbProvince.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProvince.Properties.ValueMember = "MaTinh";
            this.cmbProvince.Size = new System.Drawing.Size(177, 20);
            this.cmbProvince.StyleController = this.layoutControl1;
            this.cmbProvince.TabIndex = 7;
            this.cmbProvince.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.cmbProvince.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(850, 12);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(74, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 8;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.ckbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ckbStatus;
            this.layoutControlItem5.Location = new System.Drawing.Point(838, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(78, 27);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // ucAddDIC_XAPHUONG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAddDIC_XAPHUONG";
            this.Size = new System.Drawing.Size(936, 47);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDistrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LookUpEdit cmbDistrict;
        private DevExpress.XtraEditors.LookUpEdit cmbProvince;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
