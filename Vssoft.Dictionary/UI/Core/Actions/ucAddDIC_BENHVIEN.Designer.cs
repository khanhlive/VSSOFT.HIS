namespace Vssoft.Dictionary.UI.Core.Actions
{
    partial class ucAddDIC_BENHVIEN
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
            this.txtMaso = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtDiachi = new DevExpress.XtraEditors.TextEdit();
            this.txtChuquan = new DevExpress.XtraEditors.TextEdit();
            this.ckbConnect = new DevExpress.XtraEditors.CheckEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.cmbHuyen = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbTinh = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTuyen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChuquan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbConnect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtMaso);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtDiachi);
            this.layoutControl1.Controls.Add(this.txtChuquan);
            this.layoutControl1.Controls.Add(this.ckbConnect);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Controls.Add(this.cmbHuyen);
            this.layoutControl1.Controls.Add(this.cmbTinh);
            this.layoutControl1.Controls.Add(this.txtTuyen);
            this.layoutControl1.Controls.Add(this.txtLevel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(912, 95);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtMaso
            // 
            this.txtMaso.Location = new System.Drawing.Point(65, 12);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.Properties.Mask.EditMask = "[0-9A-Z]{3,10}";
            this.txtMaso.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtMaso.Size = new System.Drawing.Size(133, 20);
            this.txtMaso.StyleController = this.layoutControl1;
            this.txtMaso.TabIndex = 0;
            this.txtMaso.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtMaso.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(255, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 150;
            this.txtName.Size = new System.Drawing.Size(327, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 1;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(639, 12);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Properties.MaxLength = 250;
            this.txtDiachi.Size = new System.Drawing.Size(261, 20);
            this.txtDiachi.StyleController = this.layoutControl1;
            this.txtDiachi.TabIndex = 2;
            this.txtDiachi.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtDiachi.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtChuquan
            // 
            this.txtChuquan.EditValue = "";
            this.txtChuquan.Location = new System.Drawing.Point(65, 36);
            this.txtChuquan.Name = "txtChuquan";
            this.txtChuquan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtChuquan.Properties.Mask.EditMask = "[0-9A-Z]{2,10}";
            this.txtChuquan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtChuquan.Properties.NullText = "10";
            this.txtChuquan.Size = new System.Drawing.Size(133, 20);
            this.txtChuquan.StyleController = this.layoutControl1;
            this.txtChuquan.TabIndex = 3;
            this.txtChuquan.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtChuquan.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // ckbConnect
            // 
            this.ckbConnect.Location = new System.Drawing.Point(586, 36);
            this.ckbConnect.Name = "ckbConnect";
            this.ckbConnect.Properties.Caption = "Đã kết nối";
            this.ckbConnect.Size = new System.Drawing.Size(162, 19);
            this.ckbConnect.StyleController = this.layoutControl1;
            this.ckbConnect.TabIndex = 6;
            this.ckbConnect.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.ckbConnect.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(752, 36);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(148, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 7;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.ckbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // cmbHuyen
            // 
            this.cmbHuyen.Location = new System.Drawing.Point(455, 36);
            this.cmbHuyen.Name = "cmbHuyen";
            this.cmbHuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHuyen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHuyen", "Tên huyện")});
            this.cmbHuyen.Properties.DisplayMember = "TenHuyen";
            this.cmbHuyen.Properties.DropDownRows = 12;
            this.cmbHuyen.Properties.NullText = "";
            this.cmbHuyen.Properties.PopupSizeable = false;
            this.cmbHuyen.Properties.ShowHeader = false;
            this.cmbHuyen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbHuyen.Properties.ValueMember = "MaHuyen";
            this.cmbHuyen.Size = new System.Drawing.Size(127, 20);
            this.cmbHuyen.StyleController = this.layoutControl1;
            this.cmbHuyen.TabIndex = 5;
            this.cmbHuyen.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.cmbHuyen.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // cmbTinh
            // 
            this.cmbTinh.Location = new System.Drawing.Point(255, 36);
            this.cmbTinh.Name = "cmbTinh";
            this.cmbTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTinh.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTinh", "Tên tỉnh")});
            this.cmbTinh.Properties.DisplayMember = "TenTinh";
            this.cmbTinh.Properties.DropDownRows = 12;
            this.cmbTinh.Properties.NullText = "";
            this.cmbTinh.Properties.PopupSizeable = false;
            this.cmbTinh.Properties.ShowHeader = false;
            this.cmbTinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbTinh.Properties.ValueMember = "MaTinh";
            this.cmbTinh.Size = new System.Drawing.Size(143, 20);
            this.cmbTinh.StyleController = this.layoutControl1;
            this.cmbTinh.TabIndex = 4;
            this.cmbTinh.EditValueChanged += new System.EventHandler(this.cmbTinh_EditValueChanged);
            this.cmbTinh.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtTuyen
            // 
            this.txtTuyen.Location = new System.Drawing.Point(65, 60);
            this.txtTuyen.Name = "txtTuyen";
            this.txtTuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuyen.Properties.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.txtTuyen.Size = new System.Drawing.Size(133, 20);
            this.txtTuyen.StyleController = this.layoutControl1;
            this.txtTuyen.TabIndex = 8;
            this.txtTuyen.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtTuyen.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(255, 60);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLevel.Properties.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.txtLevel.Size = new System.Drawing.Size(143, 20);
            this.txtLevel.StyleController = this.layoutControl1;
            this.txtLevel.TabIndex = 9;
            this.txtLevel.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtLevel.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(912, 95);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMaso;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(190, 24);
            this.layoutControlItem1.Text = "Mã(*):";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtTuyen;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(190, 27);
            this.layoutControlItem7.Text = "Tuyến(*):";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(190, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(384, 24);
            this.layoutControlItem2.Text = "Tên(*):";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDiachi;
            this.layoutControlItem3.Location = new System.Drawing.Point(574, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(318, 24);
            this.layoutControlItem3.Text = "Địa chỉ:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmbHuyen;
            this.layoutControlItem5.Location = new System.Drawing.Point(390, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(184, 24);
            this.layoutControlItem5.Text = "Huyện(*):";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtLevel;
            this.layoutControlItem8.Location = new System.Drawing.Point(190, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(200, 27);
            this.layoutControlItem8.Text = "Hạng(*):";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.ckbConnect;
            this.layoutControlItem9.Location = new System.Drawing.Point(574, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(166, 51);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.ckbStatus;
            this.layoutControlItem10.Location = new System.Drawing.Point(740, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(152, 51);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtChuquan;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(190, 24);
            this.layoutControlItem6.Text = "Chủ quản:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cmbTinh;
            this.layoutControlItem4.Location = new System.Drawing.Point(190, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(200, 24);
            this.layoutControlItem4.Text = "Tỉnh(*):";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(390, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(184, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ucAddDIC_BENHVIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAddDIC_BENHVIEN";
            this.Size = new System.Drawing.Size(912, 95);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChuquan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbConnect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtMaso;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtDiachi;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtChuquan;
        private DevExpress.XtraEditors.CheckEdit ckbConnect;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.LookUpEdit cmbHuyen;
        private DevExpress.XtraEditors.LookUpEdit cmbTinh;
        private DevExpress.XtraEditors.ComboBoxEdit txtTuyen;
        private DevExpress.XtraEditors.ComboBoxEdit txtLevel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
