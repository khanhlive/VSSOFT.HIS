using Vssoft.Common;

namespace Vssoft.Dictionary.UI.Core.Actions
{
    public class ucAddDIC_DICHVU : xucBaseAddH
    {
        public ucAddDIC_DICHVU()
        {
            InitializeComponent();
        }
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtMaNoiBo;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtTenNoiBo;
        private DevExpress.XtraEditors.TextEdit txtSoTTQD;
        private DevExpress.XtraEditors.TextEdit txtSoQDTT37;
        private DevExpress.XtraEditors.TextEdit txtMaQD_BYT;
        private DevExpress.XtraEditors.TextEdit txtGiaGioiHan;
        private DevExpress.XtraEditors.TextEdit textEdit9;
        private DevExpress.XtraEditors.TextEdit txtGiaTT37_d2;
        private DevExpress.XtraEditors.TextEdit txtGiaDichvu;
        private DevExpress.XtraEditors.TextEdit txtGiaDichvu_d2;
        private DevExpress.XtraEditors.TextEdit txtGiaPhuThu;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDonvitinh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem txtGiaTT37_d1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraEditors.ComboBoxEdit cmbLoai;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPhanLoai;
        private DevExpress.XtraEditors.CheckEdit ckbTrongDM;
        private DevExpress.XtraEditors.CheckEdit ckbStatus;
        private DevExpress.XtraEditors.CheckEdit ckbDichvuKTC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraEditors.LookUpEdit lookupTieunhom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.LookUpEdit lookupNhomdichVu1;
        private DevExpress.XtraEditors.LookUpEdit lookupNhomDichvu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.CheckedListBoxControl ckblDoiTuongBenhNhan;
        private DevExpress.XtraEditors.CheckedListBoxControl ckblPhongbanSudung;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraEditors.SpinEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddDIC_DICHVU));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ckblDoiTuongBenhNhan = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.ckblPhongbanSudung = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNoiBo = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtTenNoiBo = new DevExpress.XtraEditors.TextEdit();
            this.txtSoTTQD = new DevExpress.XtraEditors.TextEdit();
            this.txtSoQDTT37 = new DevExpress.XtraEditors.TextEdit();
            this.txtMaQD_BYT = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaGioiHan = new DevExpress.XtraEditors.TextEdit();
            this.textEdit9 = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaTT37_d2 = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaDichvu = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaDichvu_d2 = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaPhuThu = new DevExpress.XtraEditors.TextEdit();
            this.cmbDonvitinh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbLoai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbPhanLoai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ckbTrongDM = new DevExpress.XtraEditors.CheckEdit();
            this.ckbStatus = new DevExpress.XtraEditors.CheckEdit();
            this.ckbDichvuKTC = new DevExpress.XtraEditors.CheckEdit();
            this.lookupTieunhom = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupNhomdichVu1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupNhomDichvu = new DevExpress.XtraEditors.LookUpEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtGiaTT37_d1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.Err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckblDoiTuongBenhNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckblPhongbanSudung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNoiBo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNoiBo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTTQD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoQDTT37.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQD_BYT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaGioiHan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTT37_d2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaDichvu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaDichvu_d2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaPhuThu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonvitinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhanLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTrongDM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbDichvuKTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTieunhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhomdichVu1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhomDichvu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTT37_d1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
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
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(989, 508);
            this.panelControl2.TabIndex = 39;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ckblDoiTuongBenhNhan);
            this.layoutControl1.Controls.Add(this.ckblPhongbanSudung);
            this.layoutControl1.Controls.Add(this.txtID);
            this.layoutControl1.Controls.Add(this.txtMaNoiBo);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtTenNoiBo);
            this.layoutControl1.Controls.Add(this.txtSoTTQD);
            this.layoutControl1.Controls.Add(this.txtSoQDTT37);
            this.layoutControl1.Controls.Add(this.txtMaQD_BYT);
            this.layoutControl1.Controls.Add(this.txtGiaGioiHan);
            this.layoutControl1.Controls.Add(this.textEdit9);
            this.layoutControl1.Controls.Add(this.txtGiaTT37_d2);
            this.layoutControl1.Controls.Add(this.txtGiaDichvu);
            this.layoutControl1.Controls.Add(this.txtGiaDichvu_d2);
            this.layoutControl1.Controls.Add(this.txtGiaPhuThu);
            this.layoutControl1.Controls.Add(this.cmbDonvitinh);
            this.layoutControl1.Controls.Add(this.cmbLoai);
            this.layoutControl1.Controls.Add(this.cmbPhanLoai);
            this.layoutControl1.Controls.Add(this.ckbTrongDM);
            this.layoutControl1.Controls.Add(this.ckbStatus);
            this.layoutControl1.Controls.Add(this.ckbDichvuKTC);
            this.layoutControl1.Controls.Add(this.lookupTieunhom);
            this.layoutControl1.Controls.Add(this.lookupNhomdichVu1);
            this.layoutControl1.Controls.Add(this.lookupNhomDichvu);
            this.layoutControl1.Controls.Add(this.spinEdit1);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem16,
            this.layoutControlItem24});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(728, 385, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(989, 508);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ckblDoiTuongBenhNhan
            // 
            this.ckblDoiTuongBenhNhan.Cursor = System.Windows.Forms.Cursors.Default;
            this.ckblDoiTuongBenhNhan.Location = new System.Drawing.Point(24, 294);
            this.ckblDoiTuongBenhNhan.Name = "ckblDoiTuongBenhNhan";
            this.ckblDoiTuongBenhNhan.Size = new System.Drawing.Size(429, 190);
            this.ckblDoiTuongBenhNhan.StyleController = this.layoutControl1;
            this.ckblDoiTuongBenhNhan.TabIndex = 13;
            // 
            // ckblPhongbanSudung
            // 
            this.ckblPhongbanSudung.Cursor = System.Windows.Forms.Cursors.Default;
            this.ckblPhongbanSudung.Location = new System.Drawing.Point(481, 180);
            this.ckblPhongbanSudung.Name = "ckblPhongbanSudung";
            this.ckblPhongbanSudung.Size = new System.Drawing.Size(484, 304);
            this.ckblPhongbanSudung.StyleController = this.layoutControl1;
            this.ckblPhongbanSudung.TabIndex = 12;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(118, 42);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(89, 20);
            this.txtID.StyleController = this.layoutControl1;
            this.txtID.TabIndex = 4;
            // 
            // txtMaNoiBo
            // 
            this.txtMaNoiBo.Location = new System.Drawing.Point(305, 42);
            this.txtMaNoiBo.Name = "txtMaNoiBo";
            this.txtMaNoiBo.Properties.Mask.EditMask = "[0-9A-Z]{0,20}";
            this.txtMaNoiBo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtMaNoiBo.Properties.Mask.ShowPlaceHolders = false;
            this.txtMaNoiBo.Size = new System.Drawing.Size(104, 20);
            this.txtMaNoiBo.StyleController = this.layoutControl1;
            this.txtMaNoiBo.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(507, 42);
            this.txtName.Name = "txtName";
            this.txtName.Properties.MaxLength = 350;
            this.txtName.Size = new System.Drawing.Size(272, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 4;
            // 
            // txtTenNoiBo
            // 
            this.txtTenNoiBo.Location = new System.Drawing.Point(507, 66);
            this.txtTenNoiBo.Name = "txtTenNoiBo";
            this.txtTenNoiBo.Properties.MaxLength = 300;
            this.txtTenNoiBo.Size = new System.Drawing.Size(272, 20);
            this.txtTenNoiBo.StyleController = this.layoutControl1;
            this.txtTenNoiBo.TabIndex = 4;
            // 
            // txtSoTTQD
            // 
            this.txtSoTTQD.Location = new System.Drawing.Point(877, 42);
            this.txtSoTTQD.Name = "txtSoTTQD";
            this.txtSoTTQD.Properties.Mask.EditMask = "([0-9A-Z]|\\.){0,10}";
            this.txtSoTTQD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoTTQD.Properties.Mask.ShowPlaceHolders = false;
            this.txtSoTTQD.Size = new System.Drawing.Size(88, 20);
            this.txtSoTTQD.StyleController = this.layoutControl1;
            this.txtSoTTQD.TabIndex = 4;
            // 
            // txtSoQDTT37
            // 
            this.txtSoQDTT37.Location = new System.Drawing.Point(118, 66);
            this.txtSoQDTT37.Name = "txtSoQDTT37";
            this.txtSoQDTT37.Properties.Mask.EditMask = "([0-9A-Z]|\\.){0,10}";
            this.txtSoQDTT37.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSoQDTT37.Properties.Mask.ShowPlaceHolders = false;
            this.txtSoQDTT37.Size = new System.Drawing.Size(89, 20);
            this.txtSoQDTT37.StyleController = this.layoutControl1;
            this.txtSoQDTT37.TabIndex = 4;
            // 
            // txtMaQD_BYT
            // 
            this.txtMaQD_BYT.Location = new System.Drawing.Point(305, 66);
            this.txtMaQD_BYT.Name = "txtMaQD_BYT";
            this.txtMaQD_BYT.Properties.Mask.EditMask = "([0-9A-Z]|\\.){0,10}";
            this.txtMaQD_BYT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtMaQD_BYT.Properties.Mask.ShowPlaceHolders = false;
            this.txtMaQD_BYT.Size = new System.Drawing.Size(104, 20);
            this.txtMaQD_BYT.StyleController = this.layoutControl1;
            this.txtMaQD_BYT.TabIndex = 4;
            // 
            // txtGiaGioiHan
            // 
            this.txtGiaGioiHan.Location = new System.Drawing.Point(118, 228);
            this.txtGiaGioiHan.Name = "txtGiaGioiHan";
            this.txtGiaGioiHan.Properties.Mask.EditMask = "n0";
            this.txtGiaGioiHan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaGioiHan.Size = new System.Drawing.Size(115, 20);
            this.txtGiaGioiHan.StyleController = this.layoutControl1;
            this.txtGiaGioiHan.TabIndex = 4;
            // 
            // textEdit9
            // 
            this.textEdit9.Location = new System.Drawing.Point(118, 180);
            this.textEdit9.Name = "textEdit9";
            this.textEdit9.Properties.Mask.EditMask = "n0";
            this.textEdit9.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit9.Size = new System.Drawing.Size(115, 20);
            this.textEdit9.StyleController = this.layoutControl1;
            this.textEdit9.TabIndex = 4;
            // 
            // txtGiaTT37_d2
            // 
            this.txtGiaTT37_d2.Location = new System.Drawing.Point(331, 180);
            this.txtGiaTT37_d2.Name = "txtGiaTT37_d2";
            this.txtGiaTT37_d2.Properties.Mask.EditMask = "n0";
            this.txtGiaTT37_d2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaTT37_d2.Size = new System.Drawing.Size(122, 20);
            this.txtGiaTT37_d2.StyleController = this.layoutControl1;
            this.txtGiaTT37_d2.TabIndex = 4;
            // 
            // txtGiaDichvu
            // 
            this.txtGiaDichvu.Location = new System.Drawing.Point(118, 204);
            this.txtGiaDichvu.Name = "txtGiaDichvu";
            this.txtGiaDichvu.Properties.Mask.EditMask = "n0";
            this.txtGiaDichvu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaDichvu.Size = new System.Drawing.Size(115, 20);
            this.txtGiaDichvu.StyleController = this.layoutControl1;
            this.txtGiaDichvu.TabIndex = 4;
            // 
            // txtGiaDichvu_d2
            // 
            this.txtGiaDichvu_d2.Location = new System.Drawing.Point(331, 204);
            this.txtGiaDichvu_d2.Name = "txtGiaDichvu_d2";
            this.txtGiaDichvu_d2.Properties.Mask.EditMask = "n0";
            this.txtGiaDichvu_d2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaDichvu_d2.Size = new System.Drawing.Size(122, 20);
            this.txtGiaDichvu_d2.StyleController = this.layoutControl1;
            this.txtGiaDichvu_d2.TabIndex = 4;
            // 
            // txtGiaPhuThu
            // 
            this.txtGiaPhuThu.Location = new System.Drawing.Point(331, 228);
            this.txtGiaPhuThu.Name = "txtGiaPhuThu";
            this.txtGiaPhuThu.Properties.Mask.EditMask = "n0";
            this.txtGiaPhuThu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGiaPhuThu.Size = new System.Drawing.Size(122, 20);
            this.txtGiaPhuThu.StyleController = this.layoutControl1;
            this.txtGiaPhuThu.TabIndex = 4;
            // 
            // cmbDonvitinh
            // 
            this.cmbDonvitinh.Location = new System.Drawing.Point(118, 90);
            this.cmbDonvitinh.Name = "cmbDonvitinh";
            this.cmbDonvitinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDonvitinh.Size = new System.Drawing.Size(89, 20);
            this.cmbDonvitinh.StyleController = this.layoutControl1;
            this.cmbDonvitinh.TabIndex = 5;
            // 
            // cmbLoai
            // 
            this.cmbLoai.Location = new System.Drawing.Point(305, 114);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbLoai.Size = new System.Drawing.Size(104, 20);
            this.cmbLoai.StyleController = this.layoutControl1;
            this.cmbLoai.TabIndex = 5;
            // 
            // cmbPhanLoai
            // 
            this.cmbPhanLoai.Location = new System.Drawing.Point(305, 90);
            this.cmbPhanLoai.Name = "cmbPhanLoai";
            this.cmbPhanLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPhanLoai.Size = new System.Drawing.Size(104, 20);
            this.cmbPhanLoai.StyleController = this.layoutControl1;
            this.cmbPhanLoai.TabIndex = 5;
            // 
            // ckbTrongDM
            // 
            this.ckbTrongDM.Location = new System.Drawing.Point(783, 114);
            this.ckbTrongDM.Name = "ckbTrongDM";
            this.ckbTrongDM.Properties.Caption = "Trong danh mục";
            this.ckbTrongDM.Size = new System.Drawing.Size(109, 19);
            this.ckbTrongDM.StyleController = this.layoutControl1;
            this.ckbTrongDM.TabIndex = 6;
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(896, 114);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Properties.Caption = "Sử dụng";
            this.ckbStatus.Size = new System.Drawing.Size(69, 19);
            this.ckbStatus.StyleController = this.layoutControl1;
            this.ckbStatus.TabIndex = 7;
            // 
            // ckbDichvuKTC
            // 
            this.ckbDichvuKTC.Location = new System.Drawing.Point(783, 90);
            this.ckbDichvuKTC.Name = "ckbDichvuKTC";
            this.ckbDichvuKTC.Properties.Caption = "Dịch vụ kỹ thuật cao";
            this.ckbDichvuKTC.Size = new System.Drawing.Size(182, 19);
            this.ckbDichvuKTC.StyleController = this.layoutControl1;
            this.ckbDichvuKTC.TabIndex = 8;
            // 
            // lookupTieunhom
            // 
            this.lookupTieunhom.Location = new System.Drawing.Point(507, 114);
            this.lookupTieunhom.Name = "lookupTieunhom";
            this.lookupTieunhom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupTieunhom.Properties.NullText = "";
            this.lookupTieunhom.Properties.PopupSizeable = false;
            this.lookupTieunhom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupTieunhom.Size = new System.Drawing.Size(272, 20);
            this.lookupTieunhom.StyleController = this.layoutControl1;
            this.lookupTieunhom.TabIndex = 9;
            // 
            // lookupNhomdichVu1
            // 
            this.lookupNhomdichVu1.Location = new System.Drawing.Point(115, 537);
            this.lookupNhomdichVu1.Name = "lookupNhomdichVu1";
            this.lookupNhomdichVu1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupNhomdichVu1.Properties.NullText = "";
            this.lookupNhomdichVu1.Properties.PopupSizeable = false;
            this.lookupNhomdichVu1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupNhomdichVu1.Size = new System.Drawing.Size(554, 20);
            this.lookupNhomdichVu1.StyleController = this.layoutControl1;
            this.lookupNhomdichVu1.TabIndex = 5;
            // 
            // lookupNhomDichvu
            // 
            this.lookupNhomDichvu.Location = new System.Drawing.Point(507, 90);
            this.lookupNhomDichvu.Name = "lookupNhomDichvu";
            this.lookupNhomDichvu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupNhomDichvu.Properties.NullText = "";
            this.lookupNhomDichvu.Properties.PopupSizeable = false;
            this.lookupNhomDichvu.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupNhomDichvu.Size = new System.Drawing.Size(272, 20);
            this.lookupNhomDichvu.StyleController = this.layoutControl1;
            this.lookupNhomDichvu.TabIndex = 5;
            // 
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(118, 114);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Size = new System.Drawing.Size(89, 20);
            this.spinEdit1.StyleController = this.layoutControl1;
            this.spinEdit1.TabIndex = 10;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(115, 294);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(986, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 11;
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textEdit2.Location = new System.Drawing.Point(877, 66);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEdit2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.textEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.textEdit2.Size = new System.Drawing.Size(88, 20);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 4;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.lookupNhomdichVu1;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 525);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(661, 119);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.textEdit1;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 282);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(1093, 24);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup5,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(989, 508);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.txtGiaTT37_d1,
            this.layoutControlItem12,
            this.layoutControlItem8,
            this.layoutControlItem10,
            this.layoutControlItem13,
            this.layoutControlItem14});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 138);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(457, 114);
            this.layoutControlGroup2.Text = "Giá dịch vụ";
            // 
            // txtGiaTT37_d1
            // 
            this.txtGiaTT37_d1.Control = this.textEdit9;
            this.txtGiaTT37_d1.CustomizationFormText = "layoutControlItem1";
            this.txtGiaTT37_d1.Location = new System.Drawing.Point(0, 0);
            this.txtGiaTT37_d1.Name = "txtGiaTT37_d1";
            this.txtGiaTT37_d1.Size = new System.Drawing.Size(213, 24);
            this.txtGiaTT37_d1.Text = "Giá TT37(đ1):";
            this.txtGiaTT37_d1.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtGiaDichvu;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(213, 24);
            this.layoutControlItem12.Text = "Giá dịch vụ:";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtGiaGioiHan;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(213, 24);
            this.layoutControlItem8.Text = "Giá giới hạn(TT04):";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtGiaTT37_d2;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem10.Location = new System.Drawing.Point(213, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(220, 24);
            this.layoutControlItem10.Text = "Giá TT37(đ2):";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtGiaDichvu_d2;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem13.Location = new System.Drawing.Point(213, 24);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(220, 24);
            this.layoutControlItem13.Text = "Giá dịch vụ(đ2):";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtGiaPhuThu;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem14.Location = new System.Drawing.Point(213, 48);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(220, 24);
            this.layoutControlItem14.Text = "Giá phụ thu:";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25});
            this.layoutControlGroup3.Location = new System.Drawing.Point(457, 138);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(512, 350);
            this.layoutControlGroup3.Text = "Danh sách phòng ban sử dụng";
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.ckblPhongbanSudung;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(488, 308);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem17,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem19,
            this.layoutControlItem18,
            this.layoutControlItem23,
            this.layoutControlItem15,
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem11,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem20,
            this.layoutControlItem4});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(969, 138);
            this.layoutControlGroup5.Text = "Thông tin dịch vụ";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lookupTieunhom;
            this.layoutControlItem9.Location = new System.Drawing.Point(389, 72);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(370, 24);
            this.layoutControlItem9.Text = "Tiểu nhóm*:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.lookupNhomDichvu;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem17.Location = new System.Drawing.Point(389, 48);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(370, 24);
            this.layoutControlItem17.Text = "Nhóm*:";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtName;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem3.Location = new System.Drawing.Point(389, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(370, 24);
            this.layoutControlItem3.Text = "Tên dịch vụ*:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMaNoiBo;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem2.Location = new System.Drawing.Point(187, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(202, 24);
            this.layoutControlItem2.Text = "Mã nội bộ*:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtMaQD_BYT;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem7.Location = new System.Drawing.Point(187, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(202, 24);
            this.layoutControlItem7.Text = "Mã QĐ BYT:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.cmbPhanLoai;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem19.Location = new System.Drawing.Point(187, 48);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(202, 24);
            this.layoutControlItem19.Text = "Phân loại:";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.cmbLoai;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem18.Location = new System.Drawing.Point(187, 72);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(202, 24);
            this.layoutControlItem18.Text = "Loại:";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.spinEdit1;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(187, 24);
            this.layoutControlItem23.Text = "Tỷ lệ BHTT(%):";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.cmbDonvitinh;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(187, 24);
            this.layoutControlItem15.Text = "Đơn vị:";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtSoQDTT37;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(187, 24);
            this.layoutControlItem6.Text = "Số QĐ(T.Tư 37)*:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(187, 24);
            this.layoutControlItem1.Text = "Mã:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtSoTTQD;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem5.Location = new System.Drawing.Point(759, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem5.Text = "Số TT QĐ*:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.textEdit2;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem11.Location = new System.Drawing.Point(759, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem11.Text = "Số thứ tự:";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.ckbStatus;
            this.layoutControlItem21.Location = new System.Drawing.Point(872, 72);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(73, 24);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.ckbDichvuKTC;
            this.layoutControlItem22.Location = new System.Drawing.Point(759, 48);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.ckbTrongDM;
            this.layoutControlItem20.Location = new System.Drawing.Point(759, 72);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(113, 24);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtTenNoiBo;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem4.Location = new System.Drawing.Point(389, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(370, 24);
            this.layoutControlItem4.Text = "Tên nội bộ*:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(91, 13);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem26});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 252);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(457, 236);
            this.layoutControlGroup4.Text = "Danh sách đối tượng bệnh nhân";
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.ckblDoiTuongBenhNhan;
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(433, 194);
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // ucAddDIC_DICHVU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.panelControl2);
            this.Name = "ucAddDIC_DICHVU";
            this.Size = new System.Drawing.Size(989, 546);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckblDoiTuongBenhNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckblPhongbanSudung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNoiBo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNoiBo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTTQD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoQDTT37.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaQD_BYT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaGioiHan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTT37_d2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaDichvu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaDichvu_d2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaPhuThu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDonvitinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhanLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTrongDM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbDichvuKTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTieunhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhomdichVu1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhomDichvu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTT37_d1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
