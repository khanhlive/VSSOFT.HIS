using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.ERP;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public class ucAdd_Doituong : Common.ucBaseView
    {
        #region Private control Items
        
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraLayout.LayoutControlItem layoutcontrolitem1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtCurrentLevel;
        private DevExpress.XtraEditors.TextEdit txtOldLevel;
        private DevExpress.XtraEditors.CheckEdit ckbMoving;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        #endregion

        public ucAdd_Doituong():base()
        {
            InitializeComponent();
        }

        public override void SetModel(object model)
        {
            this.Model = model;
            if (this.Model == null)
            {
                this.ClearModel();
            }
            else
            {
                BindingModel();
            }
            this.Update();
        }

        public override void UpdateModel()
        {
            base.UpdateModel();
            this.txtID.ReadOnly = true;
        }

        public override void DisabledLayout(bool readOnly)
        {
            txtID.ReadOnly = readOnly;
            txtName.ReadOnly = readOnly;
            ckbMoving.ReadOnly = readOnly;
            txtOldLevel.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
            txtCurrentLevel.ReadOnly = readOnly;
            txtGroup.ReadOnly = readOnly;
        }

        private void BindingModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            DIC_DOITUONG doituong = (DIC_DOITUONG)this.Model;
            txtID.Text = doituong.MaDoiTuong.ToString();
            txtName.Text = doituong.TenDoiTuong;
            ckbMoving.CheckState = doituong.VanChuyen == null ? System.Windows.Forms.CheckState.Indeterminate : doituong.VanChuyen == 1 ? System.Windows.Forms.CheckState.Checked : System.Windows.Forms.CheckState.Unchecked;
            txtGroup.Text = doituong.NhomDoiTuong;
            txtOldLevel.Text = doituong.MucCu==null?"":doituong.MucCu.Value.ToString();
            txtCurrentLevel.Text = doituong.MaMuc == null ? "" : doituong.MaMuc.Value.ToString();
            ckbStatus.Checked = doituong.Status == 1;
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override bool DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_DOITUONG doituong = (DIC_DOITUONG)this.Model;
                    SqlResultType resultType = new ObjectProvider().Delete(doituong);
                    if (resultType == SqlResultType.OK)
                    {
                        this.ClearModel();
                        this.DisabledLayout(true);
                    }
                    return resultType == SqlResultType.OK;
                }
                
            }
            return false;
        }

        public override void AddNew()
        {
            base.AddNew();
            txtID.ReadOnly = false;
        }

        public override object GetModel()
        {
            DIC_DOITUONG doituong = new DIC_DOITUONG();
            doituong.MaDoiTuong = txtID.EditValue.ToString();
            doituong.TenDoiTuong= txtName.Text;
            doituong.NhomDoiTuong = txtGroup.Text;
            doituong.MaMuc = DataConverter.ToInt(txtCurrentLevel.Text);
            doituong.MucCu = DataConverter.ToInt(txtOldLevel.Text);
            doituong.VanChuyen = ckbMoving.Checked ? 1 : 0;
            doituong.Status = ckbStatus.Checked ? 1 : 0;
            return doituong;
        }

        public override void ClearModel()
        {
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            ckbMoving.CheckState = CheckState.Unchecked;
            txtGroup.Text = string.Empty;
            txtOldLevel.Text = string.Empty;
            txtCurrentLevel.Text = string.Empty;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_DOITUONG doituong = (DIC_DOITUONG)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new ObjectProvider().Insert(doituong);
                else flag = new ObjectProvider().Update(doituong);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = doituong;
                args.Message = "Không lưu được thông tin đối tượng";
                this.SaveCompleteSuccess(doituong, args);
            }
            else
            {
                XtraMessageBox.Show("Thông tin chưa hợp lệ kiểm tra lại thông tin.");
            }
        }

        public override bool Validation()
        {
            this.isValidModel = true;
            this.Validate_EmptyStringRule(this.txtID);
            bool flag = this.txtID.DoValidate();
            if (!flag) this.isValidModel = false;
            this.Validate_EmptyStringRule(txtName);
            //this.Validate_EmptyStringRule(txt);
            //bool flag2 = this.txtCode.DoValidate();
            //if (!flag2) this.isValidModel = false;
            return this.isValidModel;
        }
        private void control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Validate_EmptyStringRule((BaseEdit)sender);
        }

        private void control_EditValueChanged(object sender, EventArgs e)
        {
            if (this.isUpdated && !this.isEdited)
            {
                this.isEdited = true;
            }
        }

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtGroup = new DevExpress.XtraEditors.TextEdit();
            this.txtCurrentLevel = new DevExpress.XtraEditors.TextEdit();
            this.txtOldLevel = new DevExpress.XtraEditors.TextEdit();
            this.ckbMoving = new DevExpress.XtraEditors.CheckEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutcontrolitem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbMoving.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutcontrolitem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtGroup);
            this.layoutControl1.Controls.Add(this.txtCurrentLevel);
            this.layoutControl1.Controls.Add(this.txtOldLevel);
            this.layoutControl1.Controls.Add(this.ckbMoving);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(942, 71);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(86, 12);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Mask.EditMask = "[0-9A-Z]{2}";
            this.txtID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtID.Size = new System.Drawing.Size(138, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            this.txtID.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtID.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(302, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(86, 36);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(138, 20);
            this.txtGroup.StyleController = this.layoutControl1;
            this.txtGroup.TabIndex = 6;
            this.txtGroup.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtGroup.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtCurrentLevel
            // 
            this.txtCurrentLevel.Location = new System.Drawing.Point(302, 36);
            this.txtCurrentLevel.Name = "txtCurrentLevel";
            this.txtCurrentLevel.Size = new System.Drawing.Size(129, 20);
            this.txtCurrentLevel.StyleController = this.layoutControl1;
            this.txtCurrentLevel.TabIndex = 7;
            this.txtCurrentLevel.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtCurrentLevel.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // txtOldLevel
            // 
            this.txtOldLevel.Location = new System.Drawing.Point(509, 36);
            this.txtOldLevel.Name = "txtOldLevel";
            this.txtOldLevel.Size = new System.Drawing.Size(129, 20);
            this.txtOldLevel.StyleController = this.layoutControl1;
            this.txtOldLevel.TabIndex = 8;
            this.txtOldLevel.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtOldLevel.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // ckbMoving
            // 
            this.ckbMoving.Location = new System.Drawing.Point(680, 12);
            this.ckbMoving.Name = "ckbMoving";
            this.ckbMoving.Properties.Caption = "Hưởng vận chuyển";
            this.ckbMoving.Size = new System.Drawing.Size(250, 19);
            this.ckbMoving.StyleController = this.layoutControl1;
            this.ckbMoving.TabIndex = 9;
            this.ckbMoving.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.ckbMoving.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(680, 36);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(250, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 10;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.ckbStatus.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutcontrolitem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(942, 71);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutcontrolitem1
            // 
            this.layoutcontrolitem1.Control = this.txtID;
            this.layoutcontrolitem1.Location = new System.Drawing.Point(0, 0);
            this.layoutcontrolitem1.Name = "layoutcontrolitem1";
            this.layoutcontrolitem1.Size = new System.Drawing.Size(216, 24);
            this.layoutcontrolitem1.Text = "Mã:";
            this.layoutcontrolitem1.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtGroup;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(216, 27);
            this.layoutControlItem3.Text = "Nhóm";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(216, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(414, 24);
            this.layoutControlItem2.Text = "Tên đối tượng:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ckbMoving;
            this.layoutControlItem6.Location = new System.Drawing.Point(630, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 2, 2, 2);
            this.layoutControlItem6.Size = new System.Drawing.Size(292, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCurrentLevel;
            this.layoutControlItem4.Location = new System.Drawing.Point(216, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(207, 27);
            this.layoutControlItem4.Text = "Mức hiện tại:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtOldLevel;
            this.layoutControlItem5.Location = new System.Drawing.Point(423, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(207, 27);
            this.layoutControlItem5.Text = "Mức cũ:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(71, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ckbStatus;
            this.layoutControlItem7.Location = new System.Drawing.Point(630, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(40, 2, 2, 2);
            this.layoutControlItem7.Size = new System.Drawing.Size(292, 27);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // ucAdd_Doituong
            // 
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAdd_Doituong";
            this.Size = new System.Drawing.Size(942, 71);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbMoving.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutcontrolitem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
