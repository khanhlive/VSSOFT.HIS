namespace Vssoft.Dictionary.UI.Core.Actions
{
    partial class ucAddDIC_DTBN
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
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmbFormPayment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.cmbFormPayment);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(769, 71);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(769, 71);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(122, 12);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Mask.EditMask = "\\d{1,2}";
            this.txtID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtID.Size = new System.Drawing.Size(64, 20);
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
            this.layoutControlItem1.Size = new System.Drawing.Size(178, 24);
            this.layoutControlItem1.Text = "Mã số:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(300, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 250;
            this.txtName.Size = new System.Drawing.Size(169, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(178, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(283, 24);
            this.layoutControlItem2.Text = "Tên đối tượng:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(106, 13);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(122, 36);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 250;
            this.txtDescription.Size = new System.Drawing.Size(347, 20);
            this.txtDescription.StyleController = this.layoutControl1;
            this.txtDescription.TabIndex = 6;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDescription;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(461, 27);
            this.layoutControlItem3.Text = "Mô tả:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(106, 13);
            // 
            // cmbFormPayment
            // 
            this.cmbFormPayment.Location = new System.Drawing.Point(583, 12);
            this.cmbFormPayment.Name = "cmbFormPayment";
            this.cmbFormPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFormPayment.Size = new System.Drawing.Size(174, 20);
            this.cmbFormPayment.StyleController = this.layoutControl1;
            this.cmbFormPayment.TabIndex = 7;
            this.cmbFormPayment.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.cmbFormPayment.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cmbFormPayment;
            this.layoutControlItem4.Location = new System.Drawing.Point(461, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(288, 24);
            this.layoutControlItem4.Text = "Hình thức thanh toán:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(106, 13);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(511, 36);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(246, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 8;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.ckbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ckbStatus;
            this.layoutControlItem5.Location = new System.Drawing.Point(461, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 2, 2, 2);
            this.layoutControlItem5.Size = new System.Drawing.Size(288, 27);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // ucAddDIC_DTBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAddDIC_DTBN";
            this.Size = new System.Drawing.Size(769, 71);
            this.Load += new System.EventHandler(this.ucAddDIC_DTBN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFormPayment;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
