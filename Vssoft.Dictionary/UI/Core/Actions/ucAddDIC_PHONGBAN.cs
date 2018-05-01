using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vssoft.Common;
using Vssoft.Common.Common.Class;
using Vssoft.Data.Core.Ado;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    /// <summary>
    /// DANH MỤC PHÒNG BAN
    /// </summary>
    public class ucAddDIC_PHONGBAN : Common.ucBaseView
    {
        public ucAddDIC_PHONGBAN() : base()
        {
            InitializeComponent();
        }

        protected override void Init()
        {
            using (DepartmentProvider departmentProvider = new DepartmentProvider())
            {
                List<DIC_PHONGBAN> phongban = departmentProvider.GetAllActive().Where(p => p.PhanLoai == LoaiPhongBan.PhongBan[0] || p.PhanLoai == LoaiPhongBan.PhongBan[3]).ToList();
                lupNhomPB.Properties.DataSource = phongban;
            }
            using (SpecialtyProvider provider = new SpecialtyProvider())
            {
                lookupChuyenKhoa.Properties.DataSource = provider.GetAllActive();
            }
            using (HospitalProvider provider = new HospitalProvider())
            {
                lookupBenhvien.Properties.DataSource = provider.GetAllActive();
            }
            cmbPPXuatduoc.Properties.Items.AddRange(Vssoft.Data.CommonVariable.PhuongPhapXuatDuoc);
            cmbPPHuHao.Properties.Items.AddRange(Vssoft.Data.CommonVariable.PhuongPhapHuHao);

            using (PhanLoaiPhongBanProvider provider = new PhanLoaiPhongBanProvider())
            {
                lookupPhanLoai.Properties.DataSource = provider.GetAllActive();
            }
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
            lookupPhanLoai.ReadOnly = readOnly;
            lupNhomPB.ReadOnly = readOnly;
            txtMaCV9324.ReadOnly = readOnly;
            lookupChuyenKhoa.ReadOnly = readOnly;
            lookupBenhvien.ReadOnly = readOnly;
            ckbStatus.ReadOnly = readOnly;
            cmbPPXuatduoc.ReadOnly = readOnly;
            cmbPPHuHao.ReadOnly = readOnly;
            ckbQuanlyNhaThau.ReadOnly = readOnly;
            ckbTrongBenhvien.ReadOnly = readOnly;
            ckbTrucCapCuu.ReadOnly = readOnly;
            ckbTuTruc.ReadOnly = readOnly;
            txtDiaChi.ReadOnly = readOnly;
            txtBuongGiuong.ReadOnly = readOnly;
            
        }

        protected override void BindingModel()
        {
            this.actions = Common.Common.Class.Actions.None;
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            DIC_PHONGBAN phongban = (DIC_PHONGBAN)this.Model;
            txtID.Text = phongban.MaPhongBan.ToString() ;
            txtName.Text = phongban.TenPhongBan;
            lookupPhanLoai.EditValue= phongban.PhanLoai_ID;
            lupNhomPB.EditValue = phongban.NhomPhongBan;
            txtMaCV9324.Text = phongban.MaQuyetDinh;
            lookupChuyenKhoa.EditValue = phongban.MaChuyenKhoa;
            lookupBenhvien.EditValue = phongban.MaBenhVien;
            ckbStatus.Checked = phongban.Status==1;
            cmbPPXuatduoc.SelectedIndex = phongban.PhuongPhapXuatDuoc;
            cmbPPHuHao.SelectedIndex = phongban.PhuongPhapHuHaoDongY;
            ckbQuanlyNhaThau.Checked = phongban.QuanLy==1;
            ckbTrongBenhvien.Checked = phongban.TrongBenhVien==1;
            ckbTrucCapCuu.CheckState = CheckState.Indeterminate;
            ckbTuTruc.Checked = phongban.TuTruc;
            txtDiaChi.Text = phongban.DiaChi;
            txtBuongGiuong.Text = phongban.BuongGiuong;
            ChangePhanLoaiPhongban();
            txtID.ReadOnly = true;
            this.isUpdated = true;
        }

        public override UserActionType DeleteModel()
        {
            if (this.Model != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Xóa bản ghi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    DIC_PHONGBAN phongban = (DIC_PHONGBAN)this.Model;
                    SqlResultType resultType = new DepartmentProvider().Delete(phongban);
                    if (resultType == SqlResultType.OK)
                    {
                        this.ClearModel();
                        this.DisabledLayout(true);
                    }
                    return resultType == SqlResultType.OK ? UserActionType.Success : UserActionType.Failed;
                }
                else return UserActionType.None;
            }
            return UserActionType.None;
        }

        public override void AddNew()
        {
            base.AddNew();
            txtID.ReadOnly = true;
        }

        public override object GetModel()
        {
            DIC_PHONGBAN phongban = new DIC_PHONGBAN();
            try
            {
                if (this.actions == Common.Common.Class.Actions.Update)
                {
                    phongban.MaPhongBan = DataConverter.StringToInt(txtID.EditValue.ToString());
                }
                else phongban.MaPhongBan = 0;

                phongban.TenPhongBan = txtName.Text;
                phongban.PhanLoai_ID = DataConverter.StringToInt(lookupPhanLoai.EditValue.ToString());
                if (lupNhomPB.EditValue != null)
                {
                    phongban.NhomPhongBan = DataConverter.ToInt(lupNhomPB.EditValue.ToString());
                }
                else phongban.NhomPhongBan = 0;
                switch (DataConverter.ToUpper(lookupPhanLoai.Text))
                {
                    case "KHOA DƯỢC":
                    case "TỦ TRỰC":
                        phongban.PhuongPhapXuatDuoc = cmbPPXuatduoc.SelectedIndex;
                        phongban.QuanLy = ckbQuanlyNhaThau.Checked ? 1 : 0;
                        break;
                    case "PHÒNG KHÁM":
                        phongban.PhuongPhapXuatDuoc = -1;
                        phongban.QuanLy = 1;
                        break;
                    case "LÂM SÀNG":
                        phongban.PhuongPhapXuatDuoc = cmbPPXuatduoc.SelectedIndex;
                        phongban.QuanLy = 1;
                        break;
                    default:
                        phongban.PhuongPhapXuatDuoc = -1;
                        phongban.QuanLy = -1;
                        break;
                }
                phongban.MaQuyetDinh = txtMaCV9324.Text;
                phongban.MaChuyenKhoa = lookupChuyenKhoa.EditValue == null ? 0 : DataConverter.StringToInt(lookupChuyenKhoa.EditValue.ToString());
                phongban.MaBenhVien = lookupBenhvien.EditValue as string;
                phongban.Status = ckbStatus.Checked ? 1 : 0;
                phongban.PhuongPhapHuHaoDongY = cmbPPHuHao.SelectedIndex == -1 ? (byte)0 : Convert.ToByte(cmbPPHuHao.SelectedIndex);
                phongban.TrongBenhVien = ckbTrongBenhvien.Checked ? 1 : 0;
                phongban.TuTruc = ckbTuTruc.Checked;
                phongban.DiaChi = txtDiaChi.Text;
                phongban.BuongGiuong = txtBuongGiuong.Text;
            }
            catch (Exception e)
            {
                Data.CommonVariable.log.Error("GetModel Phong ban:", e);
                throw;
            }
            
            
            return phongban;
        }

        public override void ClearModel()
        {
            this.actions = Common.Common.Class.Actions.None;
            this.dxErrorProviderModel.ClearErrors();
            this.isUpdated = false;
            this.isEdited = false;
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            lookupPhanLoai.EditValue = null; //phongban.MaPhongBan
            lupNhomPB.EditValue = null;
            txtMaCV9324.Text = string.Empty;
            lookupChuyenKhoa.EditValue = null;
            lookupBenhvien.EditValue = null;
            ckbStatus.Checked = false;
            cmbPPXuatduoc.SelectedIndex = -1;
            cmbPPHuHao.SelectedIndex = -1;
            ckbQuanlyNhaThau.Checked = false;
            ckbTrongBenhvien.Checked = false;
            ckbTrucCapCuu.CheckState = CheckState.Indeterminate;
            ckbTuTruc.Checked = false;
            txtDiaChi.Text = string.Empty;
            txtBuongGiuong.Text = string.Empty;
            ckbStatus.CheckState = CheckState.Unchecked;
            this.isUpdated = true;
            ChangePhanLoaiPhongban();
        }

        public override void SaveModel()
        {
            if (this.Validation())
            {
                DIC_PHONGBAN phongban = (DIC_PHONGBAN)this.GetModel();
                SqlResultType flag;
                if (this.actions == Common.Common.Class.Actions.AddNew) flag = new DepartmentProvider().Insert(phongban);
                else flag = new DepartmentProvider().Update(phongban);
                SaveCompleteEventArgs args = new SaveCompleteEventArgs();
                args.Result = flag == SqlResultType.OK;
                args.Model = phongban;
                args.Message = "Không lưu được thông tin phòng ban";
                this.SaveCompleteSuccess(phongban, args);
            }
            else
            {
                XtraMessageBox.Show("Thông tin chưa hợp lệ kiểm tra lại thông tin.");
            }
        }

        public override bool Validation()
        {
            this.isValidModel = true;
            this.Validate_EmptyStringRule(txtName);
            this.Validate_EmptyStringRule(lookupPhanLoai);
            this.Validate_EmptyStringRule(lookupBenhvien);
            this.Validate_EmptyStringRule(txtMaCV9324);
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

        #region Init


        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lupNhomPB;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lookupChuyenKhoa;
        private DevExpress.XtraEditors.CheckEdit ckbTrongBenhvien;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.CheckEdit ckbQuanlyNhaThau;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPPXuatduoc;
        private DevExpress.XtraEditors.TextEdit txtBuongGiuong;
        private DevExpress.XtraEditors.CheckEdit ckbTrucCapCuu;
        private DevExpress.XtraEditors.CheckEdit ckbTuTruc;
        private DevExpress.XtraEditors.TextEdit txtMaCV9324;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPPHuHao;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.LookUpEdit lookupBenhvien;
        private LookUpEdit lookupPhanLoai;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lupNhomPB = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupChuyenKhoa = new DevExpress.XtraEditors.LookUpEdit();
            this.ckbTrongBenhvien = new DevExpress.XtraEditors.CheckEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.ckbQuanlyNhaThau = new DevExpress.XtraEditors.CheckEdit();
            this.cmbPPXuatduoc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtBuongGiuong = new DevExpress.XtraEditors.TextEdit();
            this.ckbTrucCapCuu = new DevExpress.XtraEditors.CheckEdit();
            this.ckbTuTruc = new DevExpress.XtraEditors.CheckEdit();
            this.txtMaCV9324 = new DevExpress.XtraEditors.TextEdit();
            this.cmbPPHuHao = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.lookupBenhvien = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupPhanLoai = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNhomPB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupChuyenKhoa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTrongBenhvien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbQuanlyNhaThau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPPXuatduoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuongGiuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTrucCapCuu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTuTruc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaCV9324.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPPHuHao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBenhvien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupPhanLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.lupNhomPB);
            this.layoutControl1.Controls.Add(this.lookupChuyenKhoa);
            this.layoutControl1.Controls.Add(this.ckbTrongBenhvien);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Controls.Add(this.ckbQuanlyNhaThau);
            this.layoutControl1.Controls.Add(this.cmbPPXuatduoc);
            this.layoutControl1.Controls.Add(this.txtBuongGiuong);
            this.layoutControl1.Controls.Add(this.ckbTrucCapCuu);
            this.layoutControl1.Controls.Add(this.ckbTuTruc);
            this.layoutControl1.Controls.Add(this.txtMaCV9324);
            this.layoutControl1.Controls.Add(this.cmbPPHuHao);
            this.layoutControl1.Controls.Add(this.txtDiaChi);
            this.layoutControl1.Controls.Add(this.lookupBenhvien);
            this.layoutControl1.Controls.Add(this.lookupPhanLoai);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(283, 89, 1273, 761);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1174, 119);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(96, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(124, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            this.txtID.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(308, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Size = new System.Drawing.Size(277, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            this.txtName.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // lupNhomPB
            // 
            this.lupNhomPB.Location = new System.Drawing.Point(961, 12);
            this.lupNhomPB.Name = "lupNhomPB";
            this.lupNhomPB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lupNhomPB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNhomPB.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenPhongBan", "Tên phòng ban")});
            this.lupNhomPB.Properties.DisplayMember = "TenPhongBan";
            this.lupNhomPB.Properties.NullText = "";
            this.lupNhomPB.Properties.PopupSizeable = false;
            this.lupNhomPB.Properties.ShowFooter = false;
            this.lupNhomPB.Properties.ShowHeader = false;
            this.lupNhomPB.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lupNhomPB.Properties.ValueMember = "MaPhongBan";
            this.lupNhomPB.Size = new System.Drawing.Size(201, 20);
            this.lupNhomPB.StyleController = this.layoutControl1;
            this.lupNhomPB.TabIndex = 7;
            this.lupNhomPB.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.lupNhomPB.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lupNhomPB_EditValueChanging);
            // 
            // lookupChuyenKhoa
            // 
            this.lookupChuyenKhoa.Location = new System.Drawing.Point(308, 36);
            this.lookupChuyenKhoa.Name = "lookupChuyenKhoa";
            this.lookupChuyenKhoa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupChuyenKhoa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChuyenKhoa", "Tên chuyên khoa")});
            this.lookupChuyenKhoa.Properties.DisplayMember = "TenChuyenKhoa";
            this.lookupChuyenKhoa.Properties.DropDownRows = 12;
            this.lookupChuyenKhoa.Properties.NullText = "";
            this.lookupChuyenKhoa.Properties.PopupSizeable = false;
            this.lookupChuyenKhoa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupChuyenKhoa.Properties.ValueMember = "MaChuyenKhoa";
            this.lookupChuyenKhoa.Size = new System.Drawing.Size(277, 20);
            this.lookupChuyenKhoa.StyleController = this.layoutControl1;
            this.lookupChuyenKhoa.TabIndex = 8;
            this.lookupChuyenKhoa.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbTrongBenhvien
            // 
            this.ckbTrongBenhvien.Location = new System.Drawing.Point(739, 60);
            this.ckbTrongBenhvien.Name = "ckbTrongBenhvien";
            this.ckbTrongBenhvien.Properties.Caption = "Trong bệnh viện";
            this.ckbTrongBenhvien.Size = new System.Drawing.Size(162, 19);
            this.ckbTrongBenhvien.StyleController = this.layoutControl1;
            this.ckbTrongBenhvien.TabIndex = 10;
            this.ckbTrongBenhvien.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(1059, 36);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(103, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 11;
            this.ckbStatus.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbQuanlyNhaThau
            // 
            this.ckbQuanlyNhaThau.Location = new System.Drawing.Point(589, 60);
            this.ckbQuanlyNhaThau.Name = "ckbQuanlyNhaThau";
            this.ckbQuanlyNhaThau.Properties.Caption = "Quản lý nhà thầu";
            this.ckbQuanlyNhaThau.Size = new System.Drawing.Size(146, 19);
            this.ckbQuanlyNhaThau.StyleController = this.layoutControl1;
            this.ckbQuanlyNhaThau.TabIndex = 12;
            this.ckbQuanlyNhaThau.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // cmbPPXuatduoc
            // 
            this.cmbPPXuatduoc.Location = new System.Drawing.Point(96, 60);
            this.cmbPPXuatduoc.Name = "cmbPPXuatduoc";
            this.cmbPPXuatduoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPPXuatduoc.Size = new System.Drawing.Size(199, 20);
            this.cmbPPXuatduoc.StyleController = this.layoutControl1;
            this.cmbPPXuatduoc.TabIndex = 13;
            this.cmbPPXuatduoc.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtBuongGiuong
            // 
            this.txtBuongGiuong.Location = new System.Drawing.Point(673, 84);
            this.txtBuongGiuong.Name = "txtBuongGiuong";
            this.txtBuongGiuong.Properties.MaxLength = 500;
            this.txtBuongGiuong.Size = new System.Drawing.Size(489, 20);
            this.txtBuongGiuong.StyleController = this.layoutControl1;
            this.txtBuongGiuong.TabIndex = 14;
            this.txtBuongGiuong.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbTrucCapCuu
            // 
            this.ckbTrucCapCuu.Location = new System.Drawing.Point(905, 60);
            this.ckbTrucCapCuu.Name = "ckbTrucCapCuu";
            this.ckbTrucCapCuu.Properties.Caption = "Trực cấp cứu";
            this.ckbTrucCapCuu.Size = new System.Drawing.Size(150, 19);
            this.ckbTrucCapCuu.StyleController = this.layoutControl1;
            this.ckbTrucCapCuu.TabIndex = 15;
            this.ckbTrucCapCuu.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // ckbTuTruc
            // 
            this.ckbTuTruc.Location = new System.Drawing.Point(1059, 60);
            this.ckbTuTruc.Name = "ckbTuTruc";
            this.ckbTuTruc.Properties.Caption = "Tủ trực";
            this.ckbTuTruc.Size = new System.Drawing.Size(103, 19);
            this.ckbTuTruc.StyleController = this.layoutControl1;
            this.ckbTuTruc.TabIndex = 16;
            this.ckbTuTruc.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtMaCV9324
            // 
            this.txtMaCV9324.Location = new System.Drawing.Point(96, 36);
            this.txtMaCV9324.Name = "txtMaCV9324";
            this.txtMaCV9324.Properties.Mask.EditMask = "[0-9A-Z]{1,10}";
            this.txtMaCV9324.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtMaCV9324.Properties.Mask.ShowPlaceHolders = false;
            this.txtMaCV9324.Size = new System.Drawing.Size(124, 20);
            this.txtMaCV9324.StyleController = this.layoutControl1;
            this.txtMaCV9324.TabIndex = 17;
            this.txtMaCV9324.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.txtMaCV9324.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // cmbPPHuHao
            // 
            this.cmbPPHuHao.Location = new System.Drawing.Point(383, 60);
            this.cmbPPHuHao.Name = "cmbPPHuHao";
            this.cmbPPHuHao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPPHuHao.Size = new System.Drawing.Size(202, 20);
            this.cmbPPHuHao.StyleController = this.layoutControl1;
            this.cmbPPHuHao.TabIndex = 18;
            this.cmbPPHuHao.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(96, 84);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.MaxLength = 250;
            this.txtDiaChi.Size = new System.Drawing.Size(489, 20);
            this.txtDiaChi.StyleController = this.layoutControl1;
            this.txtDiaChi.TabIndex = 19;
            this.txtDiaChi.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            // 
            // lookupBenhvien
            // 
            this.lookupBenhvien.Location = new System.Drawing.Point(673, 36);
            this.lookupBenhvien.Name = "lookupBenhvien";
            this.lookupBenhvien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupBenhvien.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenBenhVien", "Tên bệnh viện")});
            this.lookupBenhvien.Properties.DisplayMember = "TenBenhVien";
            this.lookupBenhvien.Properties.DropDownRows = 12;
            this.lookupBenhvien.Properties.NullText = "";
            this.lookupBenhvien.Properties.ValueMember = "MaBenhVien";
            this.lookupBenhvien.Size = new System.Drawing.Size(382, 20);
            this.lookupBenhvien.StyleController = this.layoutControl1;
            this.lookupBenhvien.TabIndex = 9;
            this.lookupBenhvien.EditValueChanged += new System.EventHandler(this.control_EditValueChanged);
            this.lookupBenhvien.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // lookupPhanLoai
            // 
            this.lookupPhanLoai.Location = new System.Drawing.Point(673, 12);
            this.lookupPhanLoai.Name = "lookupPhanLoai";
            this.lookupPhanLoai.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookupPhanLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupPhanLoai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PhanLoai", "Phân loại")});
            this.lookupPhanLoai.Properties.DisplayMember = "PhanLoai";
            this.lookupPhanLoai.Properties.DropDownRows = 12;
            this.lookupPhanLoai.Properties.NullText = "";
            this.lookupPhanLoai.Properties.PopupSizeable = false;
            this.lookupPhanLoai.Properties.ShowFooter = false;
            this.lookupPhanLoai.Properties.ShowHeader = false;
            this.lookupPhanLoai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupPhanLoai.Properties.ValueMember = "ID";
            this.lookupPhanLoai.Size = new System.Drawing.Size(200, 20);
            this.lookupPhanLoai.StyleController = this.layoutControl1;
            this.lookupPhanLoai.TabIndex = 6;
            this.lookupPhanLoai.EditValueChanged += new System.EventHandler(this.lookupPhanLoai_EditValueChanged);
            this.lookupPhanLoai.Validating += new System.ComponentModel.CancelEventHandler(this.control_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem10,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem14,
            this.layoutControlItem13,
            this.layoutControlItem8,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem12,
            this.layoutControlItem11,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1174, 119);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem1.Text = "Mã(*):";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lookupChuyenKhoa;
            this.layoutControlItem5.Location = new System.Drawing.Point(212, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem5.Text = "Chuyên khoa(*):";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.ckbQuanlyNhaThau;
            this.layoutControlItem9.Location = new System.Drawing.Point(577, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(150, 24);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(212, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem2.Text = "Tên(*):";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lupNhomPB;
            this.layoutControlItem4.Location = new System.Drawing.Point(865, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(289, 24);
            this.layoutControlItem4.Text = "Nhóm:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.cmbPPXuatduoc;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(287, 24);
            this.layoutControlItem10.Text = "PP Xuất dược:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.cmbPPHuHao;
            this.layoutControlItem15.Location = new System.Drawing.Point(287, 48);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(290, 24);
            this.layoutControlItem15.Text = "PP Hư hao:";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtDiaChi;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(577, 27);
            this.layoutControlItem16.Text = "Địa chỉ:";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtMaCV9324;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem14.Text = "Mã CV9324(*):";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.ckbTuTruc;
            this.layoutControlItem13.Location = new System.Drawing.Point(1047, 48);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(107, 24);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.ckbStatus;
            this.layoutControlItem8.Location = new System.Drawing.Point(1047, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(107, 24);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookupBenhvien;
            this.layoutControlItem6.Location = new System.Drawing.Point(577, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(470, 24);
            this.layoutControlItem6.Text = "Bệnh viện(*):";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ckbTrongBenhvien;
            this.layoutControlItem7.Location = new System.Drawing.Point(727, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(166, 24);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.ckbTrucCapCuu;
            this.layoutControlItem12.Location = new System.Drawing.Point(893, 48);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(154, 24);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtBuongGiuong;
            this.layoutControlItem11.Location = new System.Drawing.Point(577, 72);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(577, 27);
            this.layoutControlItem11.Text = "Buồng giường:";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookupPhanLoai;
            this.layoutControlItem3.Location = new System.Drawing.Point(577, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(288, 24);
            this.layoutControlItem3.Text = "Phân loại(*):";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(81, 13);
            // 
            // ucAddDIC_PHONGBAN
            // 
            this.Controls.Add(this.layoutControl1);
            this.Name = "ucAddDIC_PHONGBAN";
            this.Size = new System.Drawing.Size(1174, 119);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNhomPB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupChuyenKhoa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTrongBenhvien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbQuanlyNhaThau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPPXuatduoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuongGiuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTrucCapCuu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTuTruc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaCV9324.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPPHuHao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupBenhvien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupPhanLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void lupNhomPB_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.actions != Common.Common.Class.Actions.None)
            {
                if (lookupPhanLoai.EditValue != null)
                {
                    if (DataConverter.ToUpper(lookupPhanLoai.Text) != "TỦ TRỰC" && DataConverter.ToUpper(lookupChuyenKhoa.Text) != "TRỰC CẤP CỨU")
                    {
                        XtraMessageBox.Show("Những khoa phòng có phân loại là 'TỦ TRỰC' hoặc chuyên khoa 'TRỰC CẤP CỨU' mới có nhóm khoa phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn phân loại phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void ChangePhanLoaiPhongban()
        {
            string phanloai = DataConverter.ToUpper(lookupPhanLoai.Text);
            bool _visible = false;
            if (phanloai == "KHOA DƯỢC" || phanloai == "TỦ TRỰC")
            {
                _visible = true;
            }
            else
            {
                ckbTuTruc.CheckState = CheckState.Indeterminate;
                cmbPPXuatduoc.EditValue = null;
                ckbQuanlyNhaThau.CheckState = CheckState.Indeterminate;
                cmbPPHuHao.EditValue = null;
            }
            ckbTuTruc.Enabled = _visible;
            cmbPPXuatduoc.Enabled = _visible;
            ckbQuanlyNhaThau.Enabled = _visible;
            cmbPPHuHao.Enabled = _visible;

            
            if (phanloai == "LÂM SÀNG" || phanloai == "PHÒNG KHÁM")
            {
                ckbTrucCapCuu.Enabled = true;
                if (DataConverter.ToUpper(lookupPhanLoai.Text) == "LÂM SÀNG")
                {
                    cmbPPXuatduoc.Enabled = true;
                }
            }
            else
            {
                ckbTrucCapCuu.Enabled = false;
                ckbTrucCapCuu.CheckState = CheckState.Indeterminate;
            }
            switch (phanloai)
            {
                case "PHÒNG KHÁM":
                case "LÂM SÀNG":
                case "CẬN LÂM SÀNG":
                case "KHOA DƯỢC":
                case "TỦ TRỰC":
                case "XÃ PHƯỜNG":
                    lookupChuyenKhoa.Enabled = true;
                    break;
                default:
                    lookupChuyenKhoa.Enabled = false;
                    lookupChuyenKhoa.EditValue = null;
                    break;
            }
        }

        private void lookupPhanLoai_EditValueChanged(object sender, EventArgs e)
        {
            if (this.actions != Common.Common.Class.Actions.None)
            {
                ChangePhanLoaiPhongban();
            }
        }
    }
}
