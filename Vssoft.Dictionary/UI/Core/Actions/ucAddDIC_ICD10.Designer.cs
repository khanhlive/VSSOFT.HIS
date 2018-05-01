namespace Vssoft.Dictionary.UI.Core.Actions
{
    partial class ucAddDIC_ICD10
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
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtMaChuongBenh = new DevExpress.XtraEditors.TextEdit();
            this.txtTenChuongBenh = new DevExpress.XtraEditors.TextEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.txtTenWHO = new DevExpress.XtraEditors.MemoEdit();
            this.txtTenWHOe = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChuongBenh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuongBenh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenWHO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenWHOe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtMaChuongBenh);
            this.layoutControl1.Controls.Add(this.txtTenChuongBenh);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Controls.Add(this.txtTenWHO);
            this.layoutControl1.Controls.Add(this.txtTenWHOe);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(968, 129);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(121, 12);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Mask.EditMask = "[0-9A-Z\\.]{2,10}";
            this.txtID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtID.Properties.Mask.ShowPlaceHolders = false;
            this.txtID.Size = new System.Drawing.Size(130, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            this.txtID.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtID.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(364, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 250;
            this.txtName.Size = new System.Drawing.Size(592, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtMaChuongBenh
            // 
            this.txtMaChuongBenh.Location = new System.Drawing.Point(121, 36);
            this.txtMaChuongBenh.Name = "txtMaChuongBenh";
            this.txtMaChuongBenh.Properties.Mask.EditMask = "[0-9A-Z\\.]{2,10}";
            this.txtMaChuongBenh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtMaChuongBenh.Properties.Mask.ShowPlaceHolders = false;
            this.txtMaChuongBenh.Size = new System.Drawing.Size(130, 20);
            this.txtMaChuongBenh.StyleController = this.layoutControl1;
            this.txtMaChuongBenh.TabIndex = 6;
            this.txtMaChuongBenh.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtTenChuongBenh
            // 
            this.txtTenChuongBenh.Location = new System.Drawing.Point(364, 36);
            this.txtTenChuongBenh.Name = "txtTenChuongBenh";
            this.txtTenChuongBenh.Properties.MaxLength = 250;
            this.txtTenChuongBenh.Size = new System.Drawing.Size(592, 20);
            this.txtTenChuongBenh.StyleController = this.layoutControl1;
            this.txtTenChuongBenh.TabIndex = 7;
            this.txtTenChuongBenh.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(859, 60);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(97, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 10;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtTenWHO
            // 
            this.txtTenWHO.Location = new System.Drawing.Point(121, 60);
            this.txtTenWHO.Name = "txtTenWHO";
            this.txtTenWHO.Properties.MaxLength = 500;
            this.txtTenWHO.Size = new System.Drawing.Size(325, 57);
            this.txtTenWHO.StyleController = this.layoutControl1;
            this.txtTenWHO.TabIndex = 8;
            this.txtTenWHO.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtTenWHOe
            // 
            this.txtTenWHOe.Location = new System.Drawing.Point(559, 60);
            this.txtTenWHOe.Name = "txtTenWHOe";
            this.txtTenWHOe.Properties.MaxLength = 500;
            this.txtTenWHOe.Size = new System.Drawing.Size(296, 57);
            this.txtTenWHOe.StyleController = this.layoutControl1;
            this.txtTenWHOe.TabIndex = 9;
            this.txtTenWHOe.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(968, 129);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem1.Text = "Mã ICD(*):";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(106, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMaChuongBenh;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(243, 24);
            this.layoutControlItem3.Text = "Mã chương bệnh:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(106, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtTenWHO;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(438, 61);
            this.layoutControlItem5.Text = "Tên WHO:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(106, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(243, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(705, 24);
            this.layoutControlItem2.Text = "Tên ICD(*):";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(106, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtTenChuongBenh;
            this.layoutControlItem4.Location = new System.Drawing.Point(243, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(705, 24);
            this.layoutControlItem4.Text = "Tên chương bệnh:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(106, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtTenWHOe;
            this.layoutControlItem6.Location = new System.Drawing.Point(438, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(409, 61);
            this.layoutControlItem6.Text = "Tên WHO(Tiếng Anh):";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(106, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ckbStatus;
            this.layoutControlItem7.Location = new System.Drawing.Point(847, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(101, 61);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // ucAddDIC_ICD10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAddDIC_ICD10";
            this.Size = new System.Drawing.Size(968, 129);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChuongBenh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuongBenh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenWHO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenWHOe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtMaChuongBenh;
        private DevExpress.XtraEditors.TextEdit txtTenChuongBenh;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.MemoEdit txtTenWHO;
        private DevExpress.XtraEditors.MemoEdit txtTenWHOe;
    }
}
