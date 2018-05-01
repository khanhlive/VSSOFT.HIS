namespace Vssoft.Dictionary.UI.Core.Actions
{
    partial class ucAddDIC_NHACUNGCAP
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
            this.txtNguoiDaiDien = new DevExpress.XtraEditors.TextEdit();
            this.txtDienthoai = new DevExpress.XtraEditors.TextEdit();
            this.txtDiachi = new DevExpress.XtraEditors.TextEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiDaiDien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienthoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtNguoiDaiDien);
            this.layoutControl1.Controls.Add(this.txtDienthoai);
            this.layoutControl1.Controls.Add(this.txtDiachi);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(946, 70);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(118, 12);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Mask.EditMask = "[0-9A-Z]{4,10}";
            this.txtID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtID.Properties.Mask.ShowPlaceHolders = false;
            this.txtID.Size = new System.Drawing.Size(117, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            this.txtID.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtID.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(345, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 250;
            this.txtName.Size = new System.Drawing.Size(357, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtNguoiDaiDien
            // 
            this.txtNguoiDaiDien.Location = new System.Drawing.Point(812, 12);
            this.txtNguoiDaiDien.Name = "txtNguoiDaiDien";
            this.txtNguoiDaiDien.Properties.MaxLength = 50;
            this.txtNguoiDaiDien.Size = new System.Drawing.Size(122, 20);
            this.txtNguoiDaiDien.StyleController = this.layoutControl1;
            this.txtNguoiDaiDien.TabIndex = 6;
            this.txtNguoiDaiDien.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtDienthoai
            // 
            this.txtDienthoai.Location = new System.Drawing.Point(118, 36);
            this.txtDienthoai.Name = "txtDienthoai";
            this.txtDienthoai.Properties.Mask.EditMask = "[0-9]{10,11}";
            this.txtDienthoai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDienthoai.Properties.Mask.ShowPlaceHolders = false;
            this.txtDienthoai.Properties.MaxLength = 12;
            this.txtDienthoai.Size = new System.Drawing.Size(117, 20);
            this.txtDienthoai.StyleController = this.layoutControl1;
            this.txtDienthoai.TabIndex = 7;
            this.txtDienthoai.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(345, 36);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Properties.MaxLength = 250;
            this.txtDiachi.Size = new System.Drawing.Size(357, 20);
            this.txtDiachi.StyleController = this.layoutControl1;
            this.txtDiachi.TabIndex = 8;
            this.txtDiachi.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(706, 36);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(228, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 9;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(946, 70);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 24);
            this.layoutControlItem1.Text = "Mã(*):";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtDienthoai;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem4.Text = "Điện thoại:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(227, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem2.Text = "Tên nhà cung cấp(*):";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtNguoiDaiDien;
            this.layoutControlItem3.Location = new System.Drawing.Point(694, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(232, 24);
            this.layoutControlItem3.Text = "Người đại diện:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtDiachi;
            this.layoutControlItem5.Location = new System.Drawing.Point(227, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(467, 26);
            this.layoutControlItem5.Text = "Địa chỉ:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ckbStatus;
            this.layoutControlItem6.Location = new System.Drawing.Point(694, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(232, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // ucAddDIC_NHACUNGCAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAddDIC_NHACUNGCAP";
            this.Size = new System.Drawing.Size(946, 70);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiDaiDien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienthoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtNguoiDaiDien;
        private DevExpress.XtraEditors.TextEdit txtDienthoai;
        private DevExpress.XtraEditors.TextEdit txtDiachi;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
