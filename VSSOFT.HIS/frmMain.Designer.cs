using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTabbedMdi;
using System.Windows.Forms;

namespace Vssoft.His
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip13 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip14 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem13 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip15 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip16 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip17 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.rbcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pmAppMain = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.bbiBackup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRestore = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDiagram = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImformation = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLogout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.pccAppMenu = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.pcAppMenuFileLabels = new DevExpress.XtraEditors.PanelControl();
            this.pcAppScroll = new DevExpress.XtraEditors.XtraScrollableControl();
            this.pcRecentList = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ImgSmall = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiWebsite = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRegsiter = new DevExpress.XtraBars.BarButtonItem();
            this.barCompany = new DevExpress.XtraBars.BarStaticItem();
            this.bbiAuthor = new DevExpress.XtraBars.BarButtonItem();
            this.lblInfo = new DevExpress.XtraBars.BarStaticItem();
            this.lblAccount = new DevExpress.XtraBars.BarStaticItem();
            this.lblServer = new DevExpress.XtraBars.BarStaticItem();
            this.lblToday = new DevExpress.XtraBars.BarStaticItem();
            this.lblLink = new DevExpress.XtraBars.BarLinkContainerItem();
            this.lblDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.bbiSysLog = new DevExpress.XtraBars.BarButtonItem();
            this.ISystem = new DevExpress.XtraBars.BarButtonItem();
            this.pmSystem = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiChangepassword = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUsers = new DevExpress.XtraBars.BarButtonItem();
            this.bbSkin = new DevExpress.XtraBars.BarSubItem();
            this.bbiUpdateGroup = new DevExpress.XtraBars.BarSubItem();
            this.bbiCapNhatPhanMem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNangCapDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHelp2 = new DevExpress.XtraBars.BarSubItem();
            this.biiHelpNormal = new DevExpress.XtraBars.BarButtonItem();
            this.biiHelpVideo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBackup1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRestore1 = new DevExpress.XtraBars.BarButtonItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bbiHelp1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBranch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGroup = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.bbiSearch = new DevExpress.XtraBars.BarEditItem();
            this.rpiSearch = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.bbiMinSalary = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPermission = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStyle = new DevExpress.XtraBars.BarEditItem();
            this.repStyle = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bbiTrash = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOverwrite = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNumlock = new DevExpress.XtraBars.BarStaticItem();
            this.bbiWelcome = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCalculator = new DevExpress.XtraBars.BarButtonItem();
            this.bbeMonthDefault = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bbiContact1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpdateOnline1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiActionCenter = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenuReports = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenus = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDashboard = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPatients = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIdentity = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMedicalExamination = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTreatment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImportMedicament = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportMedicament = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXuatNgoaiTru = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXuatDieuTri = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHuHaoDuoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKiemKeDuoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSuDungDuoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDuTru = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNhapTraDuoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDLTuyenDuoi = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSanXuatDuoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPayment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSendData = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuChi = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.bbiNhapBNNgoaiBV = new DevExpress.XtraBars.BarButtonItem();
            this.bbiVP_KhoaDLTheoNgay = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKetNoiXaPhuong = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPhieuLinh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLinh_HCVTYT = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDuyetBenhAn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXetNghiem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCDHA = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDuocKhoaTheoNgay = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXuatTheoNCC = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSanXuatTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQLTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDanhMucTaiSan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDTKSK = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKSK_CanBo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDictionary = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBC_KhoaDuoc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBC_KeToanVienPhi = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKeHoachTongHop = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBC_BHYT = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBC_CanLamSang = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBC_KhamBenhDieuTri = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBN_HuyDon = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuocDaKeDon = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuocTuTruc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBN_BHYTSaiQD = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKhoaChungTu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNhapXuat = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChapNhatKhoaPhong = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCapNhatTrangThai = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCapNhatMaCC = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKiemThu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTuTrucTuDong = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCapNhatDichVu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDoiMaBenhVien = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThamDinh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBHXaPhuong = new DevExpress.XtraBars.BarButtonItem();
            this.bbiContact = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTeamView = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTableOffice = new DevExpress.XtraBars.BarButtonItem();
            this.imgMetro = new DevExpress.Utils.ImageCollection(this.components);
            this.rbpHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpChucNang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpSearch = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgSecurity = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgSearch = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpgHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgInfo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpgSearch2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.rbsMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.imgClassic = new DevExpress.Utils.ImageCollection(this.components);
            this.ppTimekeeperTable = new DevExpress.XtraBars.PopupMenu(this.components);
            this.PPTimekeeper = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ppEmployee = new DevExpress.XtraBars.PopupMenu(this.components);
            this.pmInit = new DevExpress.XtraBars.PopupMenu(this.components);
            this.tabMdi = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.Alert = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rbcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccAppMenu)).BeginInit();
            this.pccAppMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcAppMenuFileLabels)).BeginInit();
            this.pcAppMenuFileLabels.SuspendLayout();
            this.pcAppScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMetro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClassic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppTimekeeperTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPTimekeeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmInit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).BeginInit();
            this.SuspendLayout();
            // 
            // rbcMain
            // 
            this.rbcMain.ApplicationButtonDropDownControl = this.pmAppMain;
            toolTipTitleItem1.Text = "Tùy chọn";
            superToolTip2.Items.Add(toolTipTitleItem1);
            this.rbcMain.ApplicationButtonSuperTip = superToolTip2;
            this.rbcMain.ApplicationCaption = "Phần Mềm Quản Lý Bệnh Viện";
            this.rbcMain.AutoSizeItems = true;
            this.rbcMain.ExpandCollapseItem.Id = 0;
            this.rbcMain.Images = this.ImgSmall;
            this.rbcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbcMain.ExpandCollapseItem,
            this.bbiImformation,
            this.bbiHelp,
            this.bbiWebsite,
            this.bbiRegsiter,
            this.barCompany,
            this.bbiAuthor,
            this.lblInfo,
            this.bbiBackup,
            this.bbiRestore,
            this.lblAccount,
            this.lblServer,
            this.lblToday,
            this.lblLink,
            this.lblDatabase,
            this.bbiSetting,
            this.bbiSysLog,
            this.ISystem,
            this.bbiClose,
            this.bbiLogout,
            this.bbiChangepassword,
            this.bbiUserGroup,
            this.bbiUsers,
            this.bbSkin,
            this.bbiUpdateGroup,
            this.bbiHelp2,
            this.biiHelpNormal,
            this.biiHelpVideo,
            this.bbiBackup1,
            this.bbiRestore1,
            this.barMdiChildrenListItem1,
            this.bbiHelp1,
            this.bbiBranch,
            this.bbiDepartment,
            this.bbiGroup,
            this.barEditItem1,
            this.bbiSearch,
            this.bbiMinSalary,
            this.bbiPermission,
            this.bbiStyle,
            this.bbiTrash,
            this.bbiOverwrite,
            this.bbiNumlock,
            this.bbiWelcome,
            this.bbiDiagram,
            this.bbiCalculator,
            this.bbeMonthDefault,
            this.bbiContact1,
            this.bbiUpdateOnline1,
            this.bbiActionCenter,
            this.bbiMenuReports,
            this.bbiMenus,
            this.bbiDashboard,
            this.bbiPatients,
            this.bbiIdentity,
            this.bbiMedicalExamination,
            this.bbiTreatment,
            this.bbiImportMedicament,
            this.bbiExportMedicament,
            this.bbiXuatNgoaiTru,
            this.bbiXuatDieuTri,
            this.bbiHuHaoDuoc,
            this.bbiKiemKeDuoc,
            this.bbiSuDungDuoc,
            this.bbiDuTru,
            this.bbiNhapTraDuoc,
            this.bbiDLTuyenDuoi,
            this.bbiSanXuatDuoc,
            this.bbiPayment,
            this.bbiSendData,
            this.bbiThuChi,
            this.barSubItem3,
            this.bbiNhapBNNgoaiBV,
            this.bbiVP_KhoaDLTheoNgay,
            this.bbiKetNoiXaPhuong,
            this.bbiPhieuLinh,
            this.bbiLinh_HCVTYT,
            this.bbiDuyetBenhAn,
            this.bbiXetNghiem,
            this.bbiCDHA,
            this.bbiDuocKhoaTheoNgay,
            this.bbiXuatTheoNCC,
            this.bbiSanXuatTaiSan,
            this.bbiQLTaiSan,
            this.bbiDanhMucTaiSan,
            this.bbiDTKSK,
            this.bbiKSK_CanBo,
            this.bbiDictionary,
            this.bbiBC_KhoaDuoc,
            this.bbiBC_KeToanVienPhi,
            this.bbiKeHoachTongHop,
            this.bbiBC_BHYT,
            this.bbiBC_CanLamSang,
            this.bbiBC_KhamBenhDieuTri,
            this.bbiBN_HuyDon,
            this.bbiThuocDaKeDon,
            this.bbiThuocTuTruc,
            this.bbiBN_BHYTSaiQD,
            this.bbiKhoaChungTu,
            this.bbiNhapXuat,
            this.bbiChapNhatKhoaPhong,
            this.bbiCapNhatTrangThai,
            this.bbiCapNhatMaCC,
            this.bbiKiemThu,
            this.bbiTuTrucTuDong,
            this.bbiCapNhatDichVu,
            this.bbiDoiMaBenhVien,
            this.bbiThamDinh,
            this.bbiBHXaPhuong,
            this.bbiContact,
            this.bbiTeamView,
            this.bbiCapNhatPhanMem,
            this.bbiNangCapDuLieu,
            this.bbiTableOffice});
            this.rbcMain.LargeImages = this.imgMetro;
            this.rbcMain.Location = new System.Drawing.Point(0, 0);
            this.rbcMain.MaxItemId = 537;
            this.rbcMain.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.rbcMain.Name = "rbcMain";
            this.rbcMain.PageHeaderItemLinks.Add(this.lblAccount);
            this.rbcMain.PageHeaderItemLinks.Add(this.lblServer);
            this.rbcMain.PageHeaderItemLinks.Add(this.lblDatabase);
            this.rbcMain.PageHeaderItemLinks.Add(this.bbiStyle);
            this.rbcMain.PageHeaderItemLinks.Add(this.bbiContact1);
            this.rbcMain.PageHeaderItemLinks.Add(this.bbiUpdateOnline1);
            this.rbcMain.PageHeaderItemLinks.Add(this.bbiTrash);
            this.rbcMain.PageHeaderItemLinks.Add(this.bbiActionCenter);
            this.rbcMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpHome,
            this.rbpChucNang,
            this.rbpReport,
            this.rbpSearch,
            this.rbpSystem,
            this.rbpHelp});
            this.rbcMain.QuickToolbarItemLinks.Add(this.bbeMonthDefault);
            this.rbcMain.QuickToolbarItemLinks.Add(this.barMdiChildrenListItem1, true);
            this.rbcMain.QuickToolbarItemLinks.Add(this.bbiBackup1, true);
            this.rbcMain.QuickToolbarItemLinks.Add(this.bbiRestore1);
            this.rbcMain.QuickToolbarItemLinks.Add(this.bbiHelp1, true);
            this.rbcMain.QuickToolbarItemLinks.Add(this.bbSkin, true);
            this.rbcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiSearch,
            this.repStyle,
            this.repositoryItemDateEdit1,
            this.repositoryItemPopupContainerEdit1});
            this.rbcMain.ShowCategoryInCaption = false;
            this.rbcMain.Size = new System.Drawing.Size(1025, 147);
            this.rbcMain.StatusBar = this.rbsMain;
            this.rbcMain.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.True;
            // 
            // pmAppMain
            // 
            this.pmAppMain.ItemLinks.Add(this.bbiBackup);
            this.pmAppMain.ItemLinks.Add(this.bbiRestore);
            this.pmAppMain.ItemLinks.Add(this.bbiDiagram, true);
            this.pmAppMain.ItemLinks.Add(this.bbiImformation);
            this.pmAppMain.ItemLinks.Add(this.bbiSetting, true);
            this.pmAppMain.ItemLinks.Add(this.bbiLogout, true);
            this.pmAppMain.ItemLinks.Add(this.bbiClose);
            this.pmAppMain.Name = "pmAppMain";
            this.pmAppMain.Ribbon = this.rbcMain;
            this.pmAppMain.RightPaneControlContainer = this.pccAppMenu;
            this.pmAppMain.ShowRightPane = true;
            // 
            // bbiBackup
            // 
            this.bbiBackup.Caption = "Sao Lưu Dữ Liệu";
            this.bbiBackup.Description = "Sao lưu dữ liệu";
            this.bbiBackup.Hint = "Sao lưu dữ liệu";
            this.bbiBackup.Id = 217;
            this.bbiBackup.ImageOptions.ImageIndex = 2;
            this.bbiBackup.ImageOptions.LargeImageIndex = 8;
            this.bbiBackup.Name = "bbiBackup";
            toolTipItem1.Text = "Sao lưu dữ liệu";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiBackup.SuperTip = superToolTip1;
            // 
            // bbiRestore
            // 
            this.bbiRestore.Caption = "Phục Hồi Dữ Liệu";
            this.bbiRestore.Id = 218;
            this.bbiRestore.ImageOptions.ImageIndex = 35;
            this.bbiRestore.ImageOptions.LargeImageIndex = 9;
            this.bbiRestore.Name = "bbiRestore";
            // 
            // bbiDiagram
            // 
            this.bbiDiagram.Caption = "Sơ Đồ Chức Năng";
            this.bbiDiagram.Id = 431;
            this.bbiDiagram.ImageOptions.ImageIndex = 40;
            this.bbiDiagram.ImageOptions.LargeImageIndex = 3;
            this.bbiDiagram.Name = "bbiDiagram";
            // 
            // bbiImformation
            // 
            this.bbiImformation.Caption = "Thông Tin Bệnh Viện";
            this.bbiImformation.Id = 32;
            this.bbiImformation.ImageOptions.ImageIndex = 43;
            this.bbiImformation.ImageOptions.LargeImageIndex = 2;
            this.bbiImformation.Name = "bbiImformation";
            // 
            // bbiSetting
            // 
            this.bbiSetting.Caption = "Thiết Lập Hệ Thống";
            this.bbiSetting.Id = 238;
            this.bbiSetting.ImageOptions.ImageIndex = 41;
            this.bbiSetting.ImageOptions.LargeImageIndex = 12;
            this.bbiSetting.Name = "bbiSetting";
            // 
            // bbiLogout
            // 
            this.bbiLogout.Caption = "Đăng Xuất";
            this.bbiLogout.Id = 221;
            this.bbiLogout.ImageOptions.ImageIndex = 38;
            this.bbiLogout.ImageOptions.LargeImageIndex = 1;
            this.bbiLogout.Name = "bbiLogout";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Kết Thúc";
            this.bbiClose.Description = "Kết thúc";
            this.bbiClose.Hint = "Kết thúc";
            this.bbiClose.Id = 132;
            this.bbiClose.ImageOptions.ImageIndex = 37;
            this.bbiClose.ImageOptions.LargeImageIndex = 0;
            this.bbiClose.Name = "bbiClose";
            // 
            // pccAppMenu
            // 
            this.pccAppMenu.Appearance.BackColor = System.Drawing.Color.White;
            this.pccAppMenu.Appearance.Options.UseBackColor = true;
            this.pccAppMenu.AutoSize = true;
            this.pccAppMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pccAppMenu.Controls.Add(this.pcAppMenuFileLabels);
            this.pccAppMenu.Controls.Add(this.labelControl1);
            this.pccAppMenu.Location = new System.Drawing.Point(355, 211);
            this.pccAppMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pccAppMenu.Name = "pccAppMenu";
            this.pccAppMenu.Ribbon = this.rbcMain;
            this.pccAppMenu.Size = new System.Drawing.Size(240, 302);
            this.pccAppMenu.TabIndex = 4;
            this.pccAppMenu.Visible = false;
            // 
            // pcAppMenuFileLabels
            // 
            this.pcAppMenuFileLabels.Appearance.BackColor = System.Drawing.Color.White;
            this.pcAppMenuFileLabels.Appearance.Options.UseBackColor = true;
            this.pcAppMenuFileLabels.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcAppMenuFileLabels.Controls.Add(this.pcAppScroll);
            this.pcAppMenuFileLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAppMenuFileLabels.Location = new System.Drawing.Point(0, 19);
            this.pcAppMenuFileLabels.Name = "pcAppMenuFileLabels";
            this.pcAppMenuFileLabels.Size = new System.Drawing.Size(240, 283);
            this.pcAppMenuFileLabels.TabIndex = 2;
            // 
            // pcAppScroll
            // 
            this.pcAppScroll.Controls.Add(this.pcRecentList);
            this.pcAppScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcAppScroll.Location = new System.Drawing.Point(0, 0);
            this.pcAppScroll.Name = "pcAppScroll";
            this.pcAppScroll.Padding = new System.Windows.Forms.Padding(10);
            this.pcAppScroll.Size = new System.Drawing.Size(240, 283);
            this.pcAppScroll.TabIndex = 1;
            // 
            // pcRecentList
            // 
            this.pcRecentList.AutoSize = true;
            this.pcRecentList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcRecentList.Location = new System.Drawing.Point(10, 10);
            this.pcRecentList.Name = "pcRecentList";
            this.pcRecentList.Size = new System.Drawing.Size(220, 0);
            this.pcRecentList.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.labelControl1.Size = new System.Drawing.Size(240, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "    Danh sách chức năng đang hoạt động";
            // 
            // ImgSmall
            // 
            this.ImgSmall.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImgSmall.ImageStream")));
            this.ImgSmall.InsertGalleryImage("morefunctions_16x16.png", "images/function%20library/morefunctions_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/function%20library/morefunctions_16x16.png"), 0);
            this.ImgSmall.Images.SetKeyName(0, "morefunctions_16x16.png");
            this.ImgSmall.InsertGalleryImage("saveas_16x16.png", "images/save/saveas_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/saveas_16x16.png"), 1);
            this.ImgSmall.Images.SetKeyName(1, "saveas_16x16.png");
            this.ImgSmall.InsertGalleryImage("save_16x16.png", "images/save/save_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_16x16.png"), 2);
            this.ImgSmall.Images.SetKeyName(2, "save_16x16.png");
            this.ImgSmall.InsertGalleryImage("index_16x16.png", "images/support/index_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/index_16x16.png"), 3);
            this.ImgSmall.Images.SetKeyName(3, "index_16x16.png");
            this.ImgSmall.InsertGalleryImage("web_16x16.png", "images/function%20library/web_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/function%20library/web_16x16.png"), 4);
            this.ImgSmall.Images.SetKeyName(4, "web_16x16.png");
            this.ImgSmall.InsertGalleryImage("bouser_16x16.png", "images/business%20objects/bouser_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bouser_16x16.png"), 5);
            this.ImgSmall.Images.SetKeyName(5, "bouser_16x16.png");
            this.ImgSmall.InsertGalleryImage("servermode_16x16.png", "images/data/servermode_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/servermode_16x16.png"), 6);
            this.ImgSmall.Images.SetKeyName(6, "servermode_16x16.png");
            this.ImgSmall.InsertGalleryImage("database_16x16.png", "images/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/data/database_16x16.png"), 7);
            this.ImgSmall.Images.SetKeyName(7, "database_16x16.png");
            this.ImgSmall.InsertGalleryImage("bocontact_16x16.png", "images/business%20objects/bocontact_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bocontact_16x16.png"), 8);
            this.ImgSmall.Images.SetKeyName(8, "bocontact_16x16.png");
            this.ImgSmall.InsertGalleryImage("updatetableofcontents_16x16.png", "images/richedit/updatetableofcontents_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/richedit/updatetableofcontents_16x16.png"), 9);
            this.ImgSmall.Images.SetKeyName(9, "updatetableofcontents_16x16.png");
            this.ImgSmall.InsertGalleryImage("trash_16x16.png", "images/actions/trash_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/trash_16x16.png"), 10);
            this.ImgSmall.Images.SetKeyName(10, "trash_16x16.png");
            this.ImgSmall.InsertGalleryImage("status_16x16.png", "images/tasks/status_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/tasks/status_16x16.png"), 11);
            this.ImgSmall.Images.SetKeyName(11, "status_16x16.png");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources._007_32, "_007_32", typeof(global::Vssoft.His.Properties.Resources), 12);
            this.ImgSmall.Images.SetKeyName(12, "_007_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources._03_32, "_03_32", typeof(global::Vssoft.His.Properties.Resources), 13);
            this.ImgSmall.Images.SetKeyName(13, "_03_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources._12_32, "_12_32", typeof(global::Vssoft.His.Properties.Resources), 14);
            this.ImgSmall.Images.SetKeyName(14, "_12_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.bhxh, "bhxh", typeof(global::Vssoft.His.Properties.Resources), 15);
            this.ImgSmall.Images.SetKeyName(15, "bhxh");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.chuyenkhoan, "chuyenkhoan", typeof(global::Vssoft.His.Properties.Resources), 16);
            this.ImgSmall.Images.SetKeyName(16, "chuyenkhoan");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.cloud_upload_data_32, "cloud_upload_data_32", typeof(global::Vssoft.His.Properties.Resources), 17);
            this.ImgSmall.Images.SetKeyName(17, "cloud_upload_data_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.done_32, "done_32", typeof(global::Vssoft.His.Properties.Resources), 18);
            this.ImgSmall.Images.SetKeyName(18, "done_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.ho_so_benh_an, "ho_so_benh_an", typeof(global::Vssoft.His.Properties.Resources), 19);
            this.ImgSmall.Images.SetKeyName(19, "ho_so_benh_an");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.icon4, "icon4", typeof(global::Vssoft.His.Properties.Resources), 20);
            this.ImgSmall.Images.SetKeyName(20, "icon4");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.Lock_32, "Lock_32", typeof(global::Vssoft.His.Properties.Resources), 21);
            this.ImgSmall.Images.SetKeyName(21, "Lock_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.manufacturerpng, "manufacturerpng", typeof(global::Vssoft.His.Properties.Resources), 22);
            this.ImgSmall.Images.SetKeyName(22, "manufacturerpng");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.medical_05_32, "medical_05_32", typeof(global::Vssoft.His.Properties.Resources), 23);
            this.ImgSmall.Images.SetKeyName(23, "medical_05_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.Money_Calculator_icon, "Money_Calculator_icon", typeof(global::Vssoft.His.Properties.Resources), 24);
            this.ImgSmall.Images.SetKeyName(24, "Money_Calculator_icon");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.phieu_linhpng, "phieu_linhpng", typeof(global::Vssoft.His.Properties.Resources), 25);
            this.ImgSmall.Images.SetKeyName(25, "phieu_linhpng");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.sales_audit_32, "sales_audit_32", typeof(global::Vssoft.His.Properties.Resources), 26);
            this.ImgSmall.Images.SetKeyName(26, "sales_audit_32");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.thu_chi, "thu_chi", typeof(global::Vssoft.His.Properties.Resources), 27);
            this.ImgSmall.Images.SetKeyName(27, "thu_chi");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.xet_nghiem, "xet_nghiem", typeof(global::Vssoft.His.Properties.Resources), 28);
            this.ImgSmall.Images.SetKeyName(28, "xet_nghiem");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.currencysvg_16, "currencysvg_16", typeof(global::Vssoft.His.Properties.Resources), 29);
            this.ImgSmall.Images.SetKeyName(29, "currencysvg_16");
            this.ImgSmall.InsertGalleryImage("autosum_16x16.png", "images/function%20library/autosum_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/function%20library/autosum_16x16.png"), 30);
            this.ImgSmall.Images.SetKeyName(30, "autosum_16x16.png");
            this.ImgSmall.InsertGalleryImage("functionsmore_16x16.png", "images/spreadsheet/functionsmore_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/functionsmore_16x16.png"), 31);
            this.ImgSmall.Images.SetKeyName(31, "functionsmore_16x16.png");
            this.ImgSmall.InsertGalleryImage("chartsshowlegend_16x16.png", "images/chart/chartsshowlegend_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/chartsshowlegend_16x16.png"), 32);
            this.ImgSmall.Images.SetKeyName(32, "chartsshowlegend_16x16.png");
            this.ImgSmall.InsertGalleryImage("bodetails_16x16.png", "images/business%20objects/bodetails_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bodetails_16x16.png"), 33);
            this.ImgSmall.Images.SetKeyName(33, "bodetails_16x16.png");
            this.ImgSmall.InsertGalleryImage("number_16x16.png", "images/number%20formats/number_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/number%20formats/number_16x16.png"), 34);
            this.ImgSmall.Images.SetKeyName(34, "number_16x16.png");
            this.ImgSmall.InsertGalleryImage("saveandnew_16x16.png", "images/save/saveandnew_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/saveandnew_16x16.png"), 35);
            this.ImgSmall.Images.SetKeyName(35, "saveandnew_16x16.png");
            this.ImgSmall.InsertGalleryImage("bocustomer_16x16.png", "images/business%20objects/bocustomer_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bocustomer_16x16.png"), 36);
            this.ImgSmall.Images.SetKeyName(36, "bocustomer_16x16.png");
            this.ImgSmall.InsertGalleryImage("close_16x16.png", "images/actions/close_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_16x16.png"), 37);
            this.ImgSmall.Images.SetKeyName(37, "close_16x16.png");
            this.ImgSmall.InsertGalleryImage("pause_16x16.png", "images/arrows/pause_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/pause_16x16.png"), 38);
            this.ImgSmall.Images.SetKeyName(38, "pause_16x16.png");
            this.ImgSmall.InsertGalleryImage("boreport_16x16.png", "images/business%20objects/boreport_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boreport_16x16.png"), 39);
            this.ImgSmall.Images.SetKeyName(39, "boreport_16x16.png");
            this.ImgSmall.InsertGalleryImage("treeview_16x16.png", "images/filter%20elements/treeview_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/filter%20elements/treeview_16x16.png"), 40);
            this.ImgSmall.Images.SetKeyName(40, "treeview_16x16.png");
            this.ImgSmall.InsertGalleryImage("ide_16x16.png", "images/programming/ide_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/ide_16x16.png"), 41);
            this.ImgSmall.Images.SetKeyName(41, "ide_16x16.png");
            this.ImgSmall.InsertGalleryImage("bopermission_16x16.png", "images/business%20objects/bopermission_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bopermission_16x16.png"), 42);
            this.ImgSmall.Images.SetKeyName(42, "bopermission_16x16.png");
            this.ImgSmall.InsertGalleryImage("pageinfo_16x16.png", "images/toolbox%20items/pageinfo_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/toolbox%20items/pageinfo_16x16.png"), 43);
            this.ImgSmall.Images.SetKeyName(43, "pageinfo_16x16.png");
            this.ImgSmall.InsertGalleryImage("lookup&reference_16x16.png", "images/function%20library/lookup&reference_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/function%20library/lookup&reference_16x16.png"), 44);
            this.ImgSmall.Images.SetKeyName(44, "lookup&reference_16x16.png");
            this.ImgSmall.InsertGalleryImage("find_16x16.png", "images/find/find_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/find_16x16.png"), 45);
            this.ImgSmall.Images.SetKeyName(45, "find_16x16.png");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.bhyt_16, "bhyt_16", typeof(global::Vssoft.His.Properties.Resources), 46);
            this.ImgSmall.Images.SetKeyName(46, "bhyt_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.calculator_pencil_16, "calculator_pencil_16", typeof(global::Vssoft.His.Properties.Resources), 47);
            this.ImgSmall.Images.SetKeyName(47, "calculator_pencil_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.Clipboard_Plan_16, "Clipboard_Plan_16", typeof(global::Vssoft.His.Properties.Resources), 48);
            this.ImgSmall.Images.SetKeyName(48, "Clipboard_Plan_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.Health_Insurance_16, "Health_Insurance_16", typeof(global::Vssoft.His.Properties.Resources), 49);
            this.ImgSmall.Images.SetKeyName(49, "Health_Insurance_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.binary_tree_16, "binary_tree_16", typeof(global::Vssoft.His.Properties.Resources), 50);
            this.ImgSmall.Images.SetKeyName(50, "binary_tree_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.bn_huy_16, "bn_huy_16", typeof(global::Vssoft.His.Properties.Resources), 51);
            this.ImgSmall.Images.SetKeyName(51, "bn_huy_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.bn_sai_quy_dinh_16, "bn_sai_quy_dinh_16", typeof(global::Vssoft.His.Properties.Resources), 52);
            this.ImgSmall.Images.SetKeyName(52, "bn_sai_quy_dinh_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.chi_phi_dich_vu_16, "chi_phi_dich_vu_16", typeof(global::Vssoft.His.Properties.Resources), 53);
            this.ImgSmall.Images.SetKeyName(53, "chi_phi_dich_vu_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.contact_16, "contact_16", typeof(global::Vssoft.His.Properties.Resources), 54);
            this.ImgSmall.Images.SetKeyName(54, "contact_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.Import_export, "Import_export", typeof(global::Vssoft.His.Properties.Resources), 55);
            this.ImgSmall.Images.SetKeyName(55, "Import_export");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.Information_16, "Information_16", typeof(global::Vssoft.His.Properties.Resources), 56);
            this.ImgSmall.Images.SetKeyName(56, "Information_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.lock_document_16, "lock_document_16", typeof(global::Vssoft.His.Properties.Resources), 57);
            this.ImgSmall.Images.SetKeyName(57, "lock_document_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.manual_16, "manual_16", typeof(global::Vssoft.His.Properties.Resources), 58);
            this.ImgSmall.Images.SetKeyName(58, "manual_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.number_lock_16, "number_lock_16", typeof(global::Vssoft.His.Properties.Resources), 59);
            this.ImgSmall.Images.SetKeyName(59, "number_lock_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.status_16, "status_16", typeof(global::Vssoft.His.Properties.Resources), 60);
            this.ImgSmall.Images.SetKeyName(60, "status_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.system_software_update_16, "system_software_update_16", typeof(global::Vssoft.His.Properties.Resources), 61);
            this.ImgSmall.Images.SetKeyName(61, "system_software_update_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.TeamViewer_16, "TeamViewer_16", typeof(global::Vssoft.His.Properties.Resources), 62);
            this.ImgSmall.Images.SetKeyName(62, "TeamViewer_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.thuoc_da_ke_16, "thuoc_da_ke_16", typeof(global::Vssoft.His.Properties.Resources), 63);
            this.ImgSmall.Images.SetKeyName(63, "thuoc_da_ke_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.tu_truc_16, "tu_truc_16", typeof(global::Vssoft.His.Properties.Resources), 64);
            this.ImgSmall.Images.SetKeyName(64, "tu_truc_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.unlock_red_16, "unlock_red_16", typeof(global::Vssoft.His.Properties.Resources), 65);
            this.ImgSmall.Images.SetKeyName(65, "unlock_red_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.User_Testing_16, "User_Testing_16", typeof(global::Vssoft.His.Properties.Resources), 66);
            this.ImgSmall.Images.SetKeyName(66, "User_Testing_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.vtyt_16, "vtyt_16", typeof(global::Vssoft.His.Properties.Resources), 67);
            this.ImgSmall.Images.SetKeyName(67, "vtyt_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.welcome_16, "welcome_16", typeof(global::Vssoft.His.Properties.Resources), 68);
            this.ImgSmall.Images.SetKeyName(68, "welcome_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.world_16, "world_16", typeof(global::Vssoft.His.Properties.Resources), 69);
            this.ImgSmall.Images.SetKeyName(69, "world_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.agt_update_misc, "agt_update_misc", typeof(global::Vssoft.His.Properties.Resources), 70);
            this.ImgSmall.Images.SetKeyName(70, "agt_update_misc");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.arrow_top_right_16, "arrow_top_right_16", typeof(global::Vssoft.His.Properties.Resources), 71);
            this.ImgSmall.Images.SetKeyName(71, "arrow_top_right_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.database, "database", typeof(global::Vssoft.His.Properties.Resources), 72);
            this.ImgSmall.Images.SetKeyName(72, "database");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.knetworkconf, "knetworkconf", typeof(global::Vssoft.His.Properties.Resources), 73);
            this.ImgSmall.Images.SetKeyName(73, "knetworkconf");
            this.ImgSmall.InsertGalleryImage("knowledgebasearticle_16x16.png", "images/support/knowledgebasearticle_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/knowledgebasearticle_16x16.png"), 74);
            this.ImgSmall.Images.SetKeyName(74, "knowledgebasearticle_16x16.png");
            this.ImgSmall.InsertGalleryImage("video_16x16.png", "images/miscellaneous/video_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/miscellaneous/video_16x16.png"), 75);
            this.ImgSmall.Images.SetKeyName(75, "video_16x16.png");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.arrow_top_left_16, "arrow_top_left_16", typeof(global::Vssoft.His.Properties.Resources), 76);
            this.ImgSmall.Images.SetKeyName(76, "arrow_top_left_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.medicine_16, "medicine_16", typeof(global::Vssoft.His.Properties.Resources), 77);
            this.ImgSmall.Images.SetKeyName(77, "medicine_16");
            this.ImgSmall.InsertImage(global::Vssoft.His.Properties.Resources.table_office_16, "table_office_16", typeof(global::Vssoft.His.Properties.Resources), 78);
            this.ImgSmall.Images.SetKeyName(78, "table_office_16");
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "Giới Thiệu Sản Phẩm";
            this.bbiHelp.Id = 39;
            this.bbiHelp.ImageOptions.ImageIndex = 56;
            this.bbiHelp.ImageOptions.LargeImageIndex = 46;
            this.bbiHelp.Name = "bbiHelp";
            // 
            // bbiWebsite
            // 
            this.bbiWebsite.Caption = "Trang Chủ Công Ty";
            this.bbiWebsite.Id = 41;
            this.bbiWebsite.ImageOptions.ImageIndex = 69;
            this.bbiWebsite.ImageOptions.LargeImageIndex = 58;
            this.bbiWebsite.Name = "bbiWebsite";
            // 
            // bbiRegsiter
            // 
            this.bbiRegsiter.Caption = "Đăng Ký Sử Dụng";
            this.bbiRegsiter.Id = 42;
            this.bbiRegsiter.ImageOptions.ImageIndex = 65;
            this.bbiRegsiter.ImageOptions.LargeImageIndex = 54;
            this.bbiRegsiter.Name = "bbiRegsiter";
            toolTipItem2.Text = "Đăng ký bản quyền phần mềm, sau khi đăng ký bạn sẽ có được những tính năng đầy đủ" +
    " của phần mềm";
            superToolTip3.Items.Add(toolTipItem2);
            this.bbiRegsiter.SuperTip = superToolTip3;
            // 
            // barCompany
            // 
            this.barCompany.Caption = "© Bản quyền 2011 - 2014 bởi CÔNG TY CỔ PHẦN PHÁT TRIỂN GIẢI PHÁP PHẦN MỀM VIỆT";
            this.barCompany.Id = 207;
            this.barCompany.Name = "barCompany";
            // 
            // bbiAuthor
            // 
            this.bbiAuthor.Caption = "Thông Tin Phần Mềm";
            this.bbiAuthor.Id = 215;
            this.bbiAuthor.ImageOptions.ImageIndex = 56;
            this.bbiAuthor.ImageOptions.LargeImageIndex = 46;
            this.bbiAuthor.Name = "bbiAuthor";
            // 
            // lblInfo
            // 
            this.lblInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.lblInfo.CausesValidation = true;
            this.lblInfo.Id = 216;
            this.lblInfo.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems;
            this.lblInfo.Name = "lblInfo";
            // 
            // lblAccount
            // 
            this.lblAccount.Caption = "Người Sử Dụng: ";
            this.lblAccount.Id = 226;
            this.lblAccount.ImageOptions.ImageIndex = 5;
            this.lblAccount.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAccount.ItemAppearance.Normal.Options.UseFont = true;
            this.lblAccount.Name = "lblAccount";
            toolTipItem3.Text = "Nhấn đúp chuột vào đây để mở quản lý người dùng";
            superToolTip4.Items.Add(toolTipItem3);
            this.lblAccount.SuperTip = superToolTip4;
            // 
            // lblServer
            // 
            this.lblServer.Caption = "Máy Chủ: ";
            this.lblServer.Id = 227;
            this.lblServer.ImageOptions.ImageIndex = 6;
            this.lblServer.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblServer.ItemAppearance.Normal.Options.UseFont = true;
            this.lblServer.Name = "lblServer";
            toolTipItem4.Text = "Nhấn đúp chuột vào để mở phần mềm quản lý cơ sở dữ liệu";
            superToolTip5.Items.Add(toolTipItem4);
            this.lblServer.SuperTip = superToolTip5;
            // 
            // lblToday
            // 
            this.lblToday.Caption = "Thời gian:";
            this.lblToday.Id = 229;
            this.lblToday.Name = "lblToday";
            // 
            // lblLink
            // 
            this.lblLink.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblLink.Caption = "http://www.vssoft.vn";
            this.lblLink.Id = 230;
            this.lblLink.Name = "lblLink";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Caption = "CSDL";
            this.lblDatabase.Id = 237;
            this.lblDatabase.ImageOptions.ImageIndex = 7;
            this.lblDatabase.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDatabase.ItemAppearance.Normal.Options.UseFont = true;
            this.lblDatabase.Name = "lblDatabase";
            // 
            // bbiSysLog
            // 
            this.bbiSysLog.Caption = "Nhật Ký Hệ Thống";
            this.bbiSysLog.Description = "Ghi nhận những thao tác của người dụng";
            this.bbiSysLog.Id = 239;
            this.bbiSysLog.ImageOptions.ImageIndex = 44;
            this.bbiSysLog.ImageOptions.LargeImageIndex = 7;
            this.bbiSysLog.Name = "bbiSysLog";
            // 
            // ISystem
            // 
            this.ISystem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.ISystem.Caption = "Hệ Thống";
            this.ISystem.DropDownControl = this.pmSystem;
            this.ISystem.Id = 255;
            this.ISystem.ImageOptions.ImageIndex = 78;
            this.ISystem.ImageOptions.LargeImageIndex = 40;
            this.ISystem.Name = "ISystem";
            this.ISystem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // pmSystem
            // 
            this.pmSystem.ItemLinks.Add(this.bbiSysLog);
            this.pmSystem.Name = "pmSystem";
            this.pmSystem.Ribbon = this.rbcMain;
            // 
            // bbiChangepassword
            // 
            this.bbiChangepassword.Caption = "&Đổi Mật Khẩu";
            this.bbiChangepassword.Description = "Thay Đổi Mật Khẩu";
            this.bbiChangepassword.Hint = "Thay Đổi Mật Khẩu";
            this.bbiChangepassword.Id = 8;
            this.bbiChangepassword.ImageOptions.ImageIndex = 42;
            this.bbiChangepassword.ImageOptions.LargeImageIndex = 6;
            this.bbiChangepassword.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.C));
            this.bbiChangepassword.Name = "bbiChangepassword";
            toolTipItem5.Text = "Thay đổi mật khẩu người sử dụng";
            superToolTip6.Items.Add(toolTipItem5);
            this.bbiChangepassword.SuperTip = superToolTip6;
            // 
            // bbiUserGroup
            // 
            this.bbiUserGroup.Caption = "Vai Trò && Quyền Hạn";
            this.bbiUserGroup.Id = 295;
            this.bbiUserGroup.ImageOptions.ImageIndex = 2;
            this.bbiUserGroup.ImageOptions.LargeImageIndex = 2;
            this.bbiUserGroup.Name = "bbiUserGroup";
            this.bbiUserGroup.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiUsers
            // 
            this.bbiUsers.Caption = "Danh Sách Người Dùng";
            this.bbiUsers.Id = 296;
            this.bbiUsers.ImageOptions.ImageIndex = 36;
            this.bbiUsers.ImageOptions.LargeImageIndex = 4;
            this.bbiUsers.Name = "bbiUsers";
            // 
            // bbSkin
            // 
            this.bbSkin.Caption = "barSubItem1";
            this.bbSkin.Id = 298;
            this.bbSkin.ImageOptions.ImageIndex = 4;
            this.bbSkin.Name = "bbSkin";
            toolTipItem6.Text = "Giao diện";
            superToolTip7.Items.Add(toolTipItem6);
            this.bbSkin.SuperTip = superToolTip7;
            // 
            // bbiUpdateGroup
            // 
            this.bbiUpdateGroup.Caption = "Cập Nhật Phần Mềm";
            this.bbiUpdateGroup.Id = 299;
            this.bbiUpdateGroup.ImageOptions.ImageIndex = 61;
            this.bbiUpdateGroup.ImageOptions.LargeImageIndex = 50;
            this.bbiUpdateGroup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCapNhatPhanMem),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNangCapDuLieu)});
            this.bbiUpdateGroup.Name = "bbiUpdateGroup";
            toolTipItem7.Text = "Cập nhật cho phần mềm, để phần mềm luôn chạy ổn định";
            superToolTip8.Items.Add(toolTipItem7);
            this.bbiUpdateGroup.SuperTip = superToolTip8;
            // 
            // bbiCapNhatPhanMem
            // 
            this.bbiCapNhatPhanMem.Caption = "Nâng Cấp Phần Mềm";
            this.bbiCapNhatPhanMem.Id = 534;
            this.bbiCapNhatPhanMem.ImageOptions.ImageIndex = 70;
            this.bbiCapNhatPhanMem.Name = "bbiCapNhatPhanMem";
            // 
            // bbiNangCapDuLieu
            // 
            this.bbiNangCapDuLieu.Caption = "Nâng Cấp Dữ Liệu";
            this.bbiNangCapDuLieu.Id = 535;
            this.bbiNangCapDuLieu.ImageOptions.ImageIndex = 72;
            this.bbiNangCapDuLieu.Name = "bbiNangCapDuLieu";
            // 
            // bbiHelp2
            // 
            this.bbiHelp2.Caption = "Hướng Dẫn Sử Dụng";
            this.bbiHelp2.Id = 305;
            this.bbiHelp2.ImageOptions.ImageIndex = 58;
            this.bbiHelp2.ImageOptions.LargeImageIndex = 47;
            this.bbiHelp2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biiHelpNormal),
            new DevExpress.XtraBars.LinkPersistInfo(this.biiHelpVideo)});
            this.bbiHelp2.Name = "bbiHelp2";
            // 
            // biiHelpNormal
            // 
            this.biiHelpNormal.Caption = "Tài Liệu Hướng Dẫn";
            this.biiHelpNormal.Id = 306;
            this.biiHelpNormal.ImageOptions.ImageIndex = 74;
            this.biiHelpNormal.ImageOptions.LargeImageIndex = 89;
            this.biiHelpNormal.Name = "biiHelpNormal";
            // 
            // biiHelpVideo
            // 
            this.biiHelpVideo.Caption = "Video Hướng Dẫn";
            this.biiHelpVideo.Id = 307;
            this.biiHelpVideo.ImageOptions.ImageIndex = 75;
            this.biiHelpVideo.Name = "biiHelpVideo";
            // 
            // bbiBackup1
            // 
            this.bbiBackup1.Caption = "barButtonItem1";
            this.bbiBackup1.Id = 308;
            this.bbiBackup1.ImageOptions.ImageIndex = 2;
            this.bbiBackup1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bbiBackup1.Name = "bbiBackup1";
            toolTipItem8.Text = "Sao lưu dữ liệu (F3)";
            superToolTip9.Items.Add(toolTipItem8);
            this.bbiBackup1.SuperTip = superToolTip9;
            // 
            // bbiRestore1
            // 
            this.bbiRestore1.Caption = "barButtonItem2";
            this.bbiRestore1.Id = 309;
            this.bbiRestore1.ImageOptions.ImageIndex = 35;
            this.bbiRestore1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.bbiRestore1.Name = "bbiRestore1";
            toolTipItem9.Text = "Phục hồi dữ liệu (F4)";
            superToolTip10.Items.Add(toolTipItem9);
            this.bbiRestore1.SuperTip = superToolTip10;
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.Id = 311;
            this.barMdiChildrenListItem1.ImageOptions.ImageIndex = 0;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            toolTipItem10.Text = "Các tab đang mở";
            superToolTip11.Items.Add(toolTipItem10);
            this.barMdiChildrenListItem1.SuperTip = superToolTip11;
            // 
            // bbiHelp1
            // 
            this.bbiHelp1.Caption = "barButtonItem3";
            this.bbiHelp1.Id = 312;
            this.bbiHelp1.ImageOptions.ImageIndex = 3;
            this.bbiHelp1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.bbiHelp1.Name = "bbiHelp1";
            toolTipItem11.Text = "Hướng dẫn sử dụng (F1)";
            superToolTip12.Items.Add(toolTipItem11);
            this.bbiHelp1.SuperTip = superToolTip12;
            // 
            // bbiBranch
            // 
            this.bbiBranch.Id = 354;
            this.bbiBranch.Name = "bbiBranch";
            // 
            // bbiDepartment
            // 
            this.bbiDepartment.Id = 355;
            this.bbiDepartment.Name = "bbiDepartment";
            // 
            // bbiGroup
            // 
            this.bbiGroup.Id = 356;
            this.bbiGroup.Name = "bbiGroup";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "Nhập từ khóa:";
            this.barEditItem1.Edit = null;
            this.barEditItem1.EditWidth = 300;
            this.barEditItem1.Id = 351;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "Tìm Kiếm:";
            this.bbiSearch.Edit = this.rpiSearch;
            this.bbiSearch.EditWidth = 250;
            this.bbiSearch.Id = 352;
            this.bbiSearch.ImageOptions.ImageIndex = 45;
            this.bbiSearch.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.bbiSearch.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiSearch.Name = "bbiSearch";
            // 
            // rpiSearch
            // 
            this.rpiSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.rpiSearch.Appearance.Options.UseFont = true;
            this.rpiSearch.AutoHeight = false;
            this.rpiSearch.Name = "rpiSearch";
            this.rpiSearch.NullText = "[Gõ vào từ khóa cần tìm]";
            // 
            // bbiMinSalary
            // 
            this.bbiMinSalary.Caption = "Mức Lương Tối Thiểu";
            this.bbiMinSalary.Id = 361;
            this.bbiMinSalary.ImageOptions.ImageIndex = 22;
            this.bbiMinSalary.ImageOptions.LargeImageIndex = 24;
            this.bbiMinSalary.Name = "bbiMinSalary";
            // 
            // bbiPermission
            // 
            this.bbiPermission.Caption = "Phân Quyền Người Dùng";
            this.bbiPermission.Id = 380;
            this.bbiPermission.ImageOptions.ImageIndex = 5;
            this.bbiPermission.ImageOptions.LargeImageIndex = 5;
            this.bbiPermission.Name = "bbiPermission";
            // 
            // bbiStyle
            // 
            this.bbiStyle.Edit = this.repStyle;
            this.bbiStyle.EditValue = "Classic";
            this.bbiStyle.EditWidth = 62;
            this.bbiStyle.Id = 390;
            this.bbiStyle.Name = "bbiStyle";
            this.bbiStyle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repStyle
            // 
            this.repStyle.AutoHeight = false;
            this.repStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStyle.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.repStyle.Items.AddRange(new object[] {
            "Classic",
            "Metro"});
            this.repStyle.Name = "repStyle";
            this.repStyle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // bbiTrash
            // 
            this.bbiTrash.Caption = "Thùng Rác";
            this.bbiTrash.Hint = "Thùng Rác";
            this.bbiTrash.Id = 391;
            this.bbiTrash.ImageOptions.ImageIndex = 10;
            this.bbiTrash.Name = "bbiTrash";
            this.bbiTrash.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiTrash.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbiTrash.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiOverwrite
            // 
            this.bbiOverwrite.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiOverwrite.Caption = "INS";
            this.bbiOverwrite.Id = 409;
            this.bbiOverwrite.Name = "bbiOverwrite";
            // 
            // bbiNumlock
            // 
            this.bbiNumlock.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiNumlock.Caption = "NUM";
            this.bbiNumlock.Id = 410;
            this.bbiNumlock.Name = "bbiNumlock";
            // 
            // bbiWelcome
            // 
            this.bbiWelcome.Caption = "Cửa Sổ Chào Mừng!";
            this.bbiWelcome.Id = 430;
            this.bbiWelcome.ImageOptions.ImageIndex = 68;
            this.bbiWelcome.ImageOptions.LargeImageIndex = 57;
            this.bbiWelcome.Name = "bbiWelcome";
            // 
            // bbiCalculator
            // 
            this.bbiCalculator.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiCalculator.Hint = "Calculator";
            this.bbiCalculator.Id = 432;
            this.bbiCalculator.ImageOptions.ImageIndex = 7;
            this.bbiCalculator.Name = "bbiCalculator";
            // 
            // bbeMonthDefault
            // 
            this.bbeMonthDefault.Caption = "Tháng báo cáo";
            this.bbeMonthDefault.Edit = this.repositoryItemDateEdit1;
            this.bbeMonthDefault.EditWidth = 72;
            this.bbeMonthDefault.Id = 443;
            this.bbeMonthDefault.Name = "bbeMonthDefault";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.repositoryItemDateEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEdit1.Mask.EditMask = "MM/yyyy";
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // bbiContact1
            // 
            this.bbiContact1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiContact1.Caption = "Phản Hồi";
            this.bbiContact1.Id = 452;
            this.bbiContact1.ImageOptions.ImageIndex = 8;
            this.bbiContact1.Name = "bbiContact1";
            toolTipItem12.Text = "Phản hồi ý kiến";
            superToolTip13.Items.Add(toolTipItem12);
            this.bbiContact1.SuperTip = superToolTip13;
            // 
            // bbiUpdateOnline1
            // 
            this.bbiUpdateOnline1.Caption = "barButtonItem6";
            this.bbiUpdateOnline1.Id = 454;
            this.bbiUpdateOnline1.ImageOptions.ImageIndex = 9;
            this.bbiUpdateOnline1.Name = "bbiUpdateOnline1";
            toolTipItem13.Text = "Nâng cấp phần mềm";
            superToolTip14.Items.Add(toolTipItem13);
            this.bbiUpdateOnline1.SuperTip = superToolTip14;
            this.bbiUpdateOnline1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiActionCenter
            // 
            this.bbiActionCenter.Caption = "(1)";
            this.bbiActionCenter.Id = 469;
            this.bbiActionCenter.ImageOptions.ImageIndex = 11;
            this.bbiActionCenter.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbiActionCenter.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            this.bbiActionCenter.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiActionCenter.ItemAppearance.Normal.Options.UseForeColor = true;
            this.bbiActionCenter.Name = "bbiActionCenter";
            this.bbiActionCenter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiMenuReports
            // 
            this.bbiMenuReports.Caption = "Danh Sách Báo Cáo";
            this.bbiMenuReports.Id = 471;
            this.bbiMenuReports.ImageOptions.ImageIndex = 39;
            this.bbiMenuReports.ImageOptions.LargeImageIndex = 11;
            this.bbiMenuReports.Name = "bbiMenuReports";
            // 
            // bbiMenus
            // 
            this.bbiMenus.Caption = "Menu";
            this.bbiMenus.Id = 472;
            this.bbiMenus.ImageOptions.ImageIndex = 32;
            this.bbiMenus.ImageOptions.LargeImageIndex = 13;
            this.bbiMenus.Name = "bbiMenus";
            // 
            // bbiDashboard
            // 
            this.bbiDashboard.Caption = "Thống kê";
            this.bbiDashboard.Id = 473;
            this.bbiDashboard.ImageOptions.ImageIndex = 30;
            this.bbiDashboard.ImageOptions.LargeImageIndex = 14;
            this.bbiDashboard.Name = "bbiDashboard";
            toolTipTitleItem2.Text = "Thống kê";
            superToolTip15.Items.Add(toolTipTitleItem2);
            this.bbiDashboard.SuperTip = superToolTip15;
            // 
            // bbiPatients
            // 
            this.bbiPatients.Caption = "Bệnh Nhân";
            this.bbiPatients.Id = 474;
            this.bbiPatients.ImageOptions.ImageIndex = 33;
            this.bbiPatients.ImageOptions.LargeImageIndex = 16;
            this.bbiPatients.Name = "bbiPatients";
            // 
            // bbiIdentity
            // 
            this.bbiIdentity.Caption = "Lấy Số Đăng Ký";
            this.bbiIdentity.Id = 475;
            this.bbiIdentity.ImageOptions.ImageIndex = 34;
            this.bbiIdentity.ImageOptions.LargeImageIndex = 15;
            this.bbiIdentity.Name = "bbiIdentity";
            // 
            // bbiMedicalExamination
            // 
            this.bbiMedicalExamination.Caption = "Khám Bệnh";
            this.bbiMedicalExamination.Id = 476;
            this.bbiMedicalExamination.ImageOptions.ImageIndex = 13;
            this.bbiMedicalExamination.ImageOptions.LargeImageIndex = 18;
            this.bbiMedicalExamination.Name = "bbiMedicalExamination";
            // 
            // bbiTreatment
            // 
            this.bbiTreatment.Caption = "Điều Trị";
            this.bbiTreatment.Id = 477;
            this.bbiTreatment.ImageOptions.ImageIndex = 12;
            this.bbiTreatment.ImageOptions.LargeImageIndex = 17;
            this.bbiTreatment.Name = "bbiTreatment";
            // 
            // bbiImportMedicament
            // 
            this.bbiImportMedicament.Caption = "Nhập Dược";
            this.bbiImportMedicament.Id = 478;
            this.bbiImportMedicament.ImageOptions.ImageIndex = 23;
            this.bbiImportMedicament.ImageOptions.LargeImageIndex = 19;
            this.bbiImportMedicament.Name = "bbiImportMedicament";
            // 
            // bbiExportMedicament
            // 
            this.bbiExportMedicament.Caption = "Xuất Dược";
            this.bbiExportMedicament.Id = 479;
            this.bbiExportMedicament.ImageOptions.ImageIndex = 14;
            this.bbiExportMedicament.ImageOptions.LargeImageIndex = 21;
            this.bbiExportMedicament.Name = "bbiExportMedicament";
            // 
            // bbiXuatNgoaiTru
            // 
            this.bbiXuatNgoaiTru.Caption = "Xuất Ngoại Trú";
            this.bbiXuatNgoaiTru.Id = 481;
            this.bbiXuatNgoaiTru.ImageOptions.ImageIndex = 71;
            this.bbiXuatNgoaiTru.Name = "bbiXuatNgoaiTru";
            // 
            // bbiXuatDieuTri
            // 
            this.bbiXuatDieuTri.Caption = "Xuất Điều Trị";
            this.bbiXuatDieuTri.Id = 482;
            this.bbiXuatDieuTri.ImageOptions.ImageIndex = 71;
            this.bbiXuatDieuTri.Name = "bbiXuatDieuTri";
            // 
            // bbiHuHaoDuoc
            // 
            this.bbiHuHaoDuoc.Caption = "Hư Hao Dược";
            this.bbiHuHaoDuoc.Id = 483;
            this.bbiHuHaoDuoc.ImageOptions.ImageIndex = 77;
            this.bbiHuHaoDuoc.Name = "bbiHuHaoDuoc";
            // 
            // bbiKiemKeDuoc
            // 
            this.bbiKiemKeDuoc.Caption = "Kiểm Kê Dược";
            this.bbiKiemKeDuoc.Id = 484;
            this.bbiKiemKeDuoc.ImageOptions.ImageIndex = 77;
            this.bbiKiemKeDuoc.Name = "bbiKiemKeDuoc";
            // 
            // bbiSuDungDuoc
            // 
            this.bbiSuDungDuoc.Caption = "Sử Dụng Dược";
            this.bbiSuDungDuoc.Id = 485;
            this.bbiSuDungDuoc.ImageOptions.ImageIndex = 77;
            this.bbiSuDungDuoc.Name = "bbiSuDungDuoc";
            // 
            // bbiDuTru
            // 
            this.bbiDuTru.Caption = "Dự Trù - Yêu Cầu Nhập";
            this.bbiDuTru.Id = 486;
            this.bbiDuTru.ImageOptions.ImageIndex = 76;
            this.bbiDuTru.Name = "bbiDuTru";
            // 
            // bbiNhapTraDuoc
            // 
            this.bbiNhapTraDuoc.Caption = "Nhập Trả Dược";
            this.bbiNhapTraDuoc.Id = 487;
            this.bbiNhapTraDuoc.ImageOptions.ImageIndex = 76;
            this.bbiNhapTraDuoc.Name = "bbiNhapTraDuoc";
            // 
            // bbiDLTuyenDuoi
            // 
            this.bbiDLTuyenDuoi.Caption = "Dữ Liệu Tuyến Dưới";
            this.bbiDLTuyenDuoi.Id = 488;
            this.bbiDLTuyenDuoi.ImageOptions.ImageIndex = 7;
            this.bbiDLTuyenDuoi.Name = "bbiDLTuyenDuoi";
            // 
            // bbiSanXuatDuoc
            // 
            this.bbiSanXuatDuoc.Caption = "Sản Xuất Dược";
            this.bbiSanXuatDuoc.Id = 489;
            this.bbiSanXuatDuoc.ImageOptions.ImageIndex = 77;
            this.bbiSanXuatDuoc.Name = "bbiSanXuatDuoc";
            // 
            // bbiPayment
            // 
            this.bbiPayment.Caption = "Thanh Toán";
            this.bbiPayment.Id = 490;
            this.bbiPayment.ImageOptions.ImageIndex = 29;
            this.bbiPayment.ImageOptions.LargeImageIndex = 35;
            this.bbiPayment.Name = "bbiPayment";
            // 
            // bbiSendData
            // 
            this.bbiSendData.Caption = "Duyệt - Gửi Dữ Liệu";
            this.bbiSendData.Id = 491;
            this.bbiSendData.ImageOptions.ImageIndex = 17;
            this.bbiSendData.ImageOptions.LargeImageIndex = 25;
            this.bbiSendData.Name = "bbiSendData";
            // 
            // bbiThuChi
            // 
            this.bbiThuChi.Caption = "Thu-Chi";
            this.bbiThuChi.Id = 492;
            this.bbiThuChi.ImageOptions.ImageIndex = 27;
            this.bbiThuChi.ImageOptions.LargeImageIndex = 30;
            this.bbiThuChi.Name = "bbiThuChi";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Khác";
            this.barSubItem3.Id = 493;
            this.barSubItem3.ImageOptions.ImageIndex = 32;
            this.barSubItem3.ImageOptions.LargeImageIndex = 13;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNhapBNNgoaiBV),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiVP_KhoaDLTheoNgay),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiKetNoiXaPhuong)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // bbiNhapBNNgoaiBV
            // 
            this.bbiNhapBNNgoaiBV.Caption = "Nhập Bệnh Nhân Ngoài BV";
            this.bbiNhapBNNgoaiBV.Id = 494;
            this.bbiNhapBNNgoaiBV.ImageOptions.ImageIndex = 36;
            this.bbiNhapBNNgoaiBV.Name = "bbiNhapBNNgoaiBV";
            // 
            // bbiVP_KhoaDLTheoNgay
            // 
            this.bbiVP_KhoaDLTheoNgay.Caption = "Khóa Dữ Liệu Theo Ngày";
            this.bbiVP_KhoaDLTheoNgay.Id = 495;
            this.bbiVP_KhoaDLTheoNgay.ImageOptions.ImageIndex = 21;
            this.bbiVP_KhoaDLTheoNgay.Name = "bbiVP_KhoaDLTheoNgay";
            // 
            // bbiKetNoiXaPhuong
            // 
            this.bbiKetNoiXaPhuong.Caption = "Kết Nối Xã - Phường";
            this.bbiKetNoiXaPhuong.Id = 496;
            this.bbiKetNoiXaPhuong.ImageOptions.ImageIndex = 73;
            this.bbiKetNoiXaPhuong.Name = "bbiKetNoiXaPhuong";
            // 
            // bbiPhieuLinh
            // 
            this.bbiPhieuLinh.Caption = "Phiếu Lĩnh";
            this.bbiPhieuLinh.Id = 497;
            this.bbiPhieuLinh.ImageOptions.ImageIndex = 25;
            this.bbiPhieuLinh.ImageOptions.LargeImageIndex = 29;
            this.bbiPhieuLinh.Name = "bbiPhieuLinh";
            // 
            // bbiLinh_HCVTYT
            // 
            this.bbiLinh_HCVTYT.Caption = "Lĩnh HC-VTYT";
            this.bbiLinh_HCVTYT.Id = 498;
            this.bbiLinh_HCVTYT.ImageOptions.ImageIndex = 67;
            this.bbiLinh_HCVTYT.ImageOptions.LargeImageIndex = 56;
            this.bbiLinh_HCVTYT.Name = "bbiLinh_HCVTYT";
            // 
            // bbiDuyetBenhAn
            // 
            this.bbiDuyetBenhAn.Caption = "Duyệt Bệnh Án";
            this.bbiDuyetBenhAn.Id = 499;
            this.bbiDuyetBenhAn.ImageOptions.ImageIndex = 19;
            this.bbiDuyetBenhAn.ImageOptions.LargeImageIndex = 26;
            this.bbiDuyetBenhAn.Name = "bbiDuyetBenhAn";
            // 
            // bbiXetNghiem
            // 
            this.bbiXetNghiem.Caption = "Xét Nghiệm";
            this.bbiXetNghiem.Id = 500;
            this.bbiXetNghiem.ImageOptions.ImageIndex = 28;
            this.bbiXetNghiem.ImageOptions.LargeImageIndex = 20;
            this.bbiXetNghiem.Name = "bbiXetNghiem";
            // 
            // bbiCDHA
            // 
            this.bbiCDHA.Caption = "Chuẩn Đoán Hình Ảnh";
            this.bbiCDHA.Id = 501;
            this.bbiCDHA.ImageOptions.ImageIndex = 20;
            this.bbiCDHA.ImageOptions.LargeImageIndex = 22;
            this.bbiCDHA.Name = "bbiCDHA";
            // 
            // bbiDuocKhoaTheoNgay
            // 
            this.bbiDuocKhoaTheoNgay.Caption = "Khóa Dữ Liệu Theo Ngày";
            this.bbiDuocKhoaTheoNgay.Id = 502;
            this.bbiDuocKhoaTheoNgay.ImageOptions.ImageIndex = 21;
            this.bbiDuocKhoaTheoNgay.ImageOptions.LargeImageIndex = 31;
            this.bbiDuocKhoaTheoNgay.Name = "bbiDuocKhoaTheoNgay";
            // 
            // bbiXuatTheoNCC
            // 
            this.bbiXuatTheoNCC.Caption = "Thuốc Xuất Theo NCC";
            this.bbiXuatTheoNCC.Id = 503;
            this.bbiXuatTheoNCC.ImageOptions.ImageIndex = 22;
            this.bbiXuatTheoNCC.ImageOptions.LargeImageIndex = 27;
            this.bbiXuatTheoNCC.Name = "bbiXuatTheoNCC";
            // 
            // bbiSanXuatTaiSan
            // 
            this.bbiSanXuatTaiSan.Caption = "Quá Trình Sản Xuất Tài Sản";
            this.bbiSanXuatTaiSan.Id = 504;
            this.bbiSanXuatTaiSan.ImageOptions.ImageIndex = 24;
            this.bbiSanXuatTaiSan.ImageOptions.LargeImageIndex = 28;
            this.bbiSanXuatTaiSan.Name = "bbiSanXuatTaiSan";
            // 
            // bbiQLTaiSan
            // 
            this.bbiQLTaiSan.Caption = "Quản Lý Tài Sản";
            this.bbiQLTaiSan.Id = 505;
            this.bbiQLTaiSan.ImageOptions.ImageIndex = 24;
            this.bbiQLTaiSan.ImageOptions.LargeImageIndex = 28;
            this.bbiQLTaiSan.Name = "bbiQLTaiSan";
            // 
            // bbiDanhMucTaiSan
            // 
            this.bbiDanhMucTaiSan.Caption = "Danh Mục Tài Sản";
            this.bbiDanhMucTaiSan.Id = 506;
            this.bbiDanhMucTaiSan.ImageOptions.ImageIndex = 24;
            this.bbiDanhMucTaiSan.ImageOptions.LargeImageIndex = 28;
            this.bbiDanhMucTaiSan.Name = "bbiDanhMucTaiSan";
            // 
            // bbiDTKSK
            // 
            this.bbiDTKSK.Caption = "Đối Tượng KSK";
            this.bbiDTKSK.Id = 507;
            this.bbiDTKSK.ImageOptions.ImageIndex = 26;
            this.bbiDTKSK.ImageOptions.LargeImageIndex = 34;
            this.bbiDTKSK.Name = "bbiDTKSK";
            // 
            // bbiKSK_CanBo
            // 
            this.bbiKSK_CanBo.Caption = "Nhập KSK Cán Bộ";
            this.bbiKSK_CanBo.Id = 508;
            this.bbiKSK_CanBo.ImageOptions.ImageIndex = 26;
            this.bbiKSK_CanBo.ImageOptions.LargeImageIndex = 34;
            this.bbiKSK_CanBo.Name = "bbiKSK_CanBo";
            // 
            // bbiDictionary
            // 
            this.bbiDictionary.Caption = "Danh Mục";
            this.bbiDictionary.Id = 509;
            this.bbiDictionary.ImageOptions.ImageIndex = 31;
            this.bbiDictionary.ImageOptions.LargeImageIndex = 23;
            this.bbiDictionary.Name = "bbiDictionary";
            this.bbiDictionary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDictionary_ItemClick);
            // 
            // bbiBC_KhoaDuoc
            // 
            this.bbiBC_KhoaDuoc.Caption = "Khoa Dược";
            this.bbiBC_KhoaDuoc.Id = 510;
            this.bbiBC_KhoaDuoc.ImageOptions.ImageIndex = 14;
            this.bbiBC_KhoaDuoc.ImageOptions.LargeImageIndex = 21;
            this.bbiBC_KhoaDuoc.Name = "bbiBC_KhoaDuoc";
            // 
            // bbiBC_KeToanVienPhi
            // 
            this.bbiBC_KeToanVienPhi.Caption = "Kế Toán - Viện Phí";
            this.bbiBC_KeToanVienPhi.Id = 511;
            this.bbiBC_KeToanVienPhi.ImageOptions.ImageIndex = 47;
            this.bbiBC_KeToanVienPhi.ImageOptions.LargeImageIndex = 37;
            this.bbiBC_KeToanVienPhi.Name = "bbiBC_KeToanVienPhi";
            // 
            // bbiKeHoachTongHop
            // 
            this.bbiKeHoachTongHop.Caption = "Kế Hoạch - Tổng Hợp";
            this.bbiKeHoachTongHop.Id = 512;
            this.bbiKeHoachTongHop.ImageOptions.ImageIndex = 48;
            this.bbiKeHoachTongHop.ImageOptions.LargeImageIndex = 38;
            this.bbiKeHoachTongHop.Name = "bbiKeHoachTongHop";
            // 
            // bbiBC_BHYT
            // 
            this.bbiBC_BHYT.Caption = "Bảo Hiểm Y Tế";
            this.bbiBC_BHYT.Id = 513;
            this.bbiBC_BHYT.ImageOptions.ImageIndex = 49;
            this.bbiBC_BHYT.ImageOptions.LargeImageIndex = 39;
            this.bbiBC_BHYT.Name = "bbiBC_BHYT";
            // 
            // bbiBC_CanLamSang
            // 
            this.bbiBC_CanLamSang.Caption = "Cận Lâm Sàng";
            this.bbiBC_CanLamSang.Id = 514;
            this.bbiBC_CanLamSang.ImageOptions.ImageIndex = 28;
            this.bbiBC_CanLamSang.ImageOptions.LargeImageIndex = 20;
            this.bbiBC_CanLamSang.Name = "bbiBC_CanLamSang";
            // 
            // bbiBC_KhamBenhDieuTri
            // 
            this.bbiBC_KhamBenhDieuTri.Caption = "Khám Bệnh - Điều Trị";
            this.bbiBC_KhamBenhDieuTri.Id = 515;
            this.bbiBC_KhamBenhDieuTri.ImageOptions.ImageIndex = 13;
            this.bbiBC_KhamBenhDieuTri.ImageOptions.LargeImageIndex = 18;
            this.bbiBC_KhamBenhDieuTri.Name = "bbiBC_KhamBenhDieuTri";
            // 
            // bbiBN_HuyDon
            // 
            this.bbiBN_HuyDon.Caption = "Bệnh Nhân Hủy Đơn";
            this.bbiBN_HuyDon.Id = 516;
            this.bbiBN_HuyDon.ImageOptions.ImageIndex = 51;
            this.bbiBN_HuyDon.ImageOptions.LargeImageIndex = 41;
            this.bbiBN_HuyDon.Name = "bbiBN_HuyDon";
            // 
            // bbiThuocDaKeDon
            // 
            this.bbiThuocDaKeDon.Caption = "Thuốc Đã Kê Đơn";
            this.bbiThuocDaKeDon.Id = 517;
            this.bbiThuocDaKeDon.ImageOptions.ImageIndex = 63;
            this.bbiThuocDaKeDon.ImageOptions.LargeImageIndex = 52;
            this.bbiThuocDaKeDon.Name = "bbiThuocDaKeDon";
            // 
            // bbiThuocTuTruc
            // 
            this.bbiThuocTuTruc.Caption = "Thuốc Tủ Trực";
            this.bbiThuocTuTruc.Id = 518;
            this.bbiThuocTuTruc.ImageOptions.ImageIndex = 64;
            this.bbiThuocTuTruc.ImageOptions.LargeImageIndex = 53;
            this.bbiThuocTuTruc.Name = "bbiThuocTuTruc";
            // 
            // bbiBN_BHYTSaiQD
            // 
            this.bbiBN_BHYTSaiQD.Caption = "Bệnh Nhân BHYT Sai QĐ";
            this.bbiBN_BHYTSaiQD.Id = 519;
            this.bbiBN_BHYTSaiQD.ImageOptions.ImageIndex = 52;
            this.bbiBN_BHYTSaiQD.ImageOptions.LargeImageIndex = 42;
            this.bbiBN_BHYTSaiQD.Name = "bbiBN_BHYTSaiQD";
            // 
            // bbiKhoaChungTu
            // 
            this.bbiKhoaChungTu.Caption = "Khóa Chứng Từ";
            this.bbiKhoaChungTu.Id = 520;
            this.bbiKhoaChungTu.ImageOptions.ImageIndex = 21;
            this.bbiKhoaChungTu.ImageOptions.LargeImageIndex = 31;
            this.bbiKhoaChungTu.Name = "bbiKhoaChungTu";
            // 
            // bbiNhapXuat
            // 
            this.bbiNhapXuat.Caption = "Nhập - Xuất";
            this.bbiNhapXuat.Id = 521;
            this.bbiNhapXuat.ImageOptions.ImageIndex = 55;
            this.bbiNhapXuat.ImageOptions.LargeImageIndex = 45;
            this.bbiNhapXuat.Name = "bbiNhapXuat";
            // 
            // bbiChapNhatKhoaPhong
            // 
            this.bbiChapNhatKhoaPhong.Caption = "Cập Nhật Khoa - Phòng";
            this.bbiChapNhatKhoaPhong.Id = 523;
            this.bbiChapNhatKhoaPhong.ImageOptions.ImageIndex = 50;
            this.bbiChapNhatKhoaPhong.ImageOptions.LargeImageIndex = 40;
            this.bbiChapNhatKhoaPhong.Name = "bbiChapNhatKhoaPhong";
            // 
            // bbiCapNhatTrangThai
            // 
            this.bbiCapNhatTrangThai.Caption = "Cập Nhật Trạng Thái";
            this.bbiCapNhatTrangThai.Id = 524;
            this.bbiCapNhatTrangThai.ImageOptions.ImageIndex = 60;
            this.bbiCapNhatTrangThai.ImageOptions.LargeImageIndex = 49;
            this.bbiCapNhatTrangThai.Name = "bbiCapNhatTrangThai";
            // 
            // bbiCapNhatMaCC
            // 
            this.bbiCapNhatMaCC.Caption = "Cập Nhật Mã CC";
            this.bbiCapNhatMaCC.Id = 525;
            this.bbiCapNhatMaCC.ImageOptions.ImageIndex = 22;
            this.bbiCapNhatMaCC.ImageOptions.LargeImageIndex = 27;
            this.bbiCapNhatMaCC.Name = "bbiCapNhatMaCC";
            // 
            // bbiKiemThu
            // 
            this.bbiKiemThu.Caption = "Testing";
            this.bbiKiemThu.Id = 526;
            this.bbiKiemThu.ImageOptions.ImageIndex = 66;
            this.bbiKiemThu.ImageOptions.LargeImageIndex = 55;
            this.bbiKiemThu.Name = "bbiKiemThu";
            // 
            // bbiTuTrucTuDong
            // 
            this.bbiTuTrucTuDong.Caption = "Tủ Trực Tự Động";
            this.bbiTuTrucTuDong.Id = 527;
            this.bbiTuTrucTuDong.ImageOptions.ImageIndex = 64;
            this.bbiTuTrucTuDong.ImageOptions.LargeImageIndex = 53;
            this.bbiTuTrucTuDong.Name = "bbiTuTrucTuDong";
            // 
            // bbiCapNhatDichVu
            // 
            this.bbiCapNhatDichVu.Caption = "Cập Nhật Chi Phí Dịch Vụ";
            this.bbiCapNhatDichVu.Id = 528;
            this.bbiCapNhatDichVu.ImageOptions.ImageIndex = 53;
            this.bbiCapNhatDichVu.ImageOptions.LargeImageIndex = 43;
            this.bbiCapNhatDichVu.Name = "bbiCapNhatDichVu";
            // 
            // bbiDoiMaBenhVien
            // 
            this.bbiDoiMaBenhVien.Caption = "Đổi Mã Bệnh Viện";
            this.bbiDoiMaBenhVien.Id = 529;
            this.bbiDoiMaBenhVien.ImageOptions.ImageIndex = 59;
            this.bbiDoiMaBenhVien.ImageOptions.LargeImageIndex = 48;
            this.bbiDoiMaBenhVien.Name = "bbiDoiMaBenhVien";
            // 
            // bbiThamDinh
            // 
            this.bbiThamDinh.Caption = "Thẩm Định";
            this.bbiThamDinh.Id = 530;
            this.bbiThamDinh.ImageOptions.ImageIndex = 18;
            this.bbiThamDinh.ImageOptions.LargeImageIndex = 33;
            this.bbiThamDinh.Name = "bbiThamDinh";
            // 
            // bbiBHXaPhuong
            // 
            this.bbiBHXaPhuong.Caption = "Bảo Hiểm Xã - Phường";
            this.bbiBHXaPhuong.Id = 531;
            this.bbiBHXaPhuong.ImageOptions.ImageIndex = 15;
            this.bbiBHXaPhuong.ImageOptions.LargeImageIndex = 32;
            this.bbiBHXaPhuong.Name = "bbiBHXaPhuong";
            // 
            // bbiContact
            // 
            this.bbiContact.Caption = "Liên Hệ";
            this.bbiContact.Id = 532;
            this.bbiContact.ImageOptions.ImageIndex = 54;
            this.bbiContact.ImageOptions.LargeImageIndex = 44;
            this.bbiContact.Name = "bbiContact";
            // 
            // bbiTeamView
            // 
            this.bbiTeamView.Caption = "TeamViewer";
            this.bbiTeamView.Id = 533;
            this.bbiTeamView.ImageOptions.ImageIndex = 62;
            this.bbiTeamView.ImageOptions.LargeImageIndex = 51;
            this.bbiTeamView.Name = "bbiTeamView";
            // 
            // bbiTableOffice
            // 
            this.bbiTableOffice.Caption = "Bàn Làm Việc";
            this.bbiTableOffice.Id = 536;
            this.bbiTableOffice.ImageOptions.ImageIndex = 78;
            this.bbiTableOffice.ImageOptions.LargeImageIndex = 59;
            this.bbiTableOffice.Name = "bbiTableOffice";
            // 
            // imgMetro
            // 
            this.imgMetro.ImageSize = new System.Drawing.Size(32, 32);
            this.imgMetro.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgMetro.ImageStream")));
            this.imgMetro.InsertGalleryImage("close_32x32.png", "images/actions/close_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_32x32.png"), 0);
            this.imgMetro.Images.SetKeyName(0, "close_32x32.png");
            this.imgMetro.InsertGalleryImage("pause_32x32.png", "images/arrows/pause_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/pause_32x32.png"), 1);
            this.imgMetro.Images.SetKeyName(1, "pause_32x32.png");
            this.imgMetro.InsertGalleryImage("pageinfo_32x32.png", "images/toolbox%20items/pageinfo_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/toolbox%20items/pageinfo_32x32.png"), 2);
            this.imgMetro.Images.SetKeyName(2, "pageinfo_32x32.png");
            this.imgMetro.InsertGalleryImage("treeview_32x32.png", "images/filter%20elements/treeview_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/filter%20elements/treeview_32x32.png"), 3);
            this.imgMetro.Images.SetKeyName(3, "treeview_32x32.png");
            this.imgMetro.InsertGalleryImage("bocustomer_32x32.png", "images/business%20objects/bocustomer_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bocustomer_32x32.png"), 4);
            this.imgMetro.Images.SetKeyName(4, "bocustomer_32x32.png");
            this.imgMetro.InsertGalleryImage("bouser_32x32.png", "images/business%20objects/bouser_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bouser_32x32.png"), 5);
            this.imgMetro.Images.SetKeyName(5, "bouser_32x32.png");
            this.imgMetro.InsertGalleryImage("bopermission_32x32.png", "images/business%20objects/bopermission_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bopermission_32x32.png"), 6);
            this.imgMetro.Images.SetKeyName(6, "bopermission_32x32.png");
            this.imgMetro.InsertGalleryImage("lookup&reference_32x32.png", "images/function%20library/lookup&reference_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/function%20library/lookup&reference_32x32.png"), 7);
            this.imgMetro.Images.SetKeyName(7, "lookup&reference_32x32.png");
            this.imgMetro.InsertGalleryImage("save_32x32.png", "images/save/save_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_32x32.png"), 8);
            this.imgMetro.Images.SetKeyName(8, "save_32x32.png");
            this.imgMetro.InsertGalleryImage("saveandnew_32x32.png", "images/save/saveandnew_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/saveandnew_32x32.png"), 9);
            this.imgMetro.Images.SetKeyName(9, "saveandnew_32x32.png");
            this.imgMetro.InsertGalleryImage("customization_32x32.png", "images/edit/customization_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/customization_32x32.png"), 10);
            this.imgMetro.Images.SetKeyName(10, "customization_32x32.png");
            this.imgMetro.InsertGalleryImage("report_32x32.png", "images/reports/report_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/reports/report_32x32.png"), 11);
            this.imgMetro.Images.SetKeyName(11, "report_32x32.png");
            this.imgMetro.InsertGalleryImage("ide_32x32.png", "images/programming/ide_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/ide_32x32.png"), 12);
            this.imgMetro.Images.SetKeyName(12, "ide_32x32.png");
            this.imgMetro.InsertGalleryImage("chartsshowlegend_32x32.png", "images/chart/chartsshowlegend_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/chart/chartsshowlegend_32x32.png"), 13);
            this.imgMetro.Images.SetKeyName(13, "chartsshowlegend_32x32.png");
            this.imgMetro.InsertGalleryImage("functionsum_32x32.png", "images/spreadsheet/functionsum_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/functionsum_32x32.png"), 14);
            this.imgMetro.Images.SetKeyName(14, "functionsum_32x32.png");
            this.imgMetro.InsertGalleryImage("number_32x32.png", "images/number%20formats/number_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/number%20formats/number_32x32.png"), 15);
            this.imgMetro.Images.SetKeyName(15, "number_32x32.png");
            this.imgMetro.InsertGalleryImage("bodetails_32x32.png", "images/business%20objects/bodetails_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bodetails_32x32.png"), 16);
            this.imgMetro.Images.SetKeyName(16, "bodetails_32x32.png");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources._007_32, "_007_32", typeof(global::Vssoft.His.Properties.Resources), 17);
            this.imgMetro.Images.SetKeyName(17, "_007_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources._03_32, "_03_32", typeof(global::Vssoft.His.Properties.Resources), 18);
            this.imgMetro.Images.SetKeyName(18, "_03_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.medical_05_32, "medical_05_32", typeof(global::Vssoft.His.Properties.Resources), 19);
            this.imgMetro.Images.SetKeyName(19, "medical_05_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.xet_nghiem, "xet_nghiem", typeof(global::Vssoft.His.Properties.Resources), 20);
            this.imgMetro.Images.SetKeyName(20, "xet_nghiem");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources._12_32, "_12_32", typeof(global::Vssoft.His.Properties.Resources), 21);
            this.imgMetro.Images.SetKeyName(21, "_12_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.icon4, "icon4", typeof(global::Vssoft.His.Properties.Resources), 22);
            this.imgMetro.Images.SetKeyName(22, "icon4");
            this.imgMetro.InsertGalleryImage("functionsmore_32x32.png", "images/spreadsheet/functionsmore_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/spreadsheet/functionsmore_32x32.png"), 23);
            this.imgMetro.Images.SetKeyName(23, "functionsmore_32x32.png");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.chuyenkhoan, "chuyenkhoan", typeof(global::Vssoft.His.Properties.Resources), 24);
            this.imgMetro.Images.SetKeyName(24, "chuyenkhoan");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.cloud_upload_data_32, "cloud_upload_data_32", typeof(global::Vssoft.His.Properties.Resources), 25);
            this.imgMetro.Images.SetKeyName(25, "cloud_upload_data_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.ho_so_benh_an, "ho_so_benh_an", typeof(global::Vssoft.His.Properties.Resources), 26);
            this.imgMetro.Images.SetKeyName(26, "ho_so_benh_an");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.manufacturerpng, "manufacturerpng", typeof(global::Vssoft.His.Properties.Resources), 27);
            this.imgMetro.Images.SetKeyName(27, "manufacturerpng");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.Money_Calculator_icon, "Money_Calculator_icon", typeof(global::Vssoft.His.Properties.Resources), 28);
            this.imgMetro.Images.SetKeyName(28, "Money_Calculator_icon");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.phieu_linhpng, "phieu_linhpng", typeof(global::Vssoft.His.Properties.Resources), 29);
            this.imgMetro.Images.SetKeyName(29, "phieu_linhpng");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.thu_chi, "thu_chi", typeof(global::Vssoft.His.Properties.Resources), 30);
            this.imgMetro.Images.SetKeyName(30, "thu_chi");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.Lock_32, "Lock_32", typeof(global::Vssoft.His.Properties.Resources), 31);
            this.imgMetro.Images.SetKeyName(31, "Lock_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.bhxh, "bhxh", typeof(global::Vssoft.His.Properties.Resources), 32);
            this.imgMetro.Images.SetKeyName(32, "bhxh");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.done_32, "done_32", typeof(global::Vssoft.His.Properties.Resources), 33);
            this.imgMetro.Images.SetKeyName(33, "done_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.sales_audit_32, "sales_audit_32", typeof(global::Vssoft.His.Properties.Resources), 34);
            this.imgMetro.Images.SetKeyName(34, "sales_audit_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.currencysvg_32, "currencysvg_32", typeof(global::Vssoft.His.Properties.Resources), 35);
            this.imgMetro.Images.SetKeyName(35, "currencysvg_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.bhyt_32, "bhyt_32", typeof(global::Vssoft.His.Properties.Resources), 36);
            this.imgMetro.Images.SetKeyName(36, "bhyt_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.calculator_pencil_32, "calculator_pencil_32", typeof(global::Vssoft.His.Properties.Resources), 37);
            this.imgMetro.Images.SetKeyName(37, "calculator_pencil_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.Clipboard_Plan_32, "Clipboard_Plan_32", typeof(global::Vssoft.His.Properties.Resources), 38);
            this.imgMetro.Images.SetKeyName(38, "Clipboard_Plan_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.Health_Insurance_32, "Health_Insurance_32", typeof(global::Vssoft.His.Properties.Resources), 39);
            this.imgMetro.Images.SetKeyName(39, "Health_Insurance_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.binary_tree_32, "binary_tree_32", typeof(global::Vssoft.His.Properties.Resources), 40);
            this.imgMetro.Images.SetKeyName(40, "binary_tree_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.bn_huy_32, "bn_huy_32", typeof(global::Vssoft.His.Properties.Resources), 41);
            this.imgMetro.Images.SetKeyName(41, "bn_huy_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.bn_sai_quy_dinh_32, "bn_sai_quy_dinh_32", typeof(global::Vssoft.His.Properties.Resources), 42);
            this.imgMetro.Images.SetKeyName(42, "bn_sai_quy_dinh_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.chi_phi_dich_vu_32, "chi_phi_dich_vu_32", typeof(global::Vssoft.His.Properties.Resources), 43);
            this.imgMetro.Images.SetKeyName(43, "chi_phi_dich_vu_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.contact_32, "contact_32", typeof(global::Vssoft.His.Properties.Resources), 44);
            this.imgMetro.Images.SetKeyName(44, "contact_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.Import_export, "Import_export", typeof(global::Vssoft.His.Properties.Resources), 45);
            this.imgMetro.Images.SetKeyName(45, "Import_export");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.Information_32, "Information_32", typeof(global::Vssoft.His.Properties.Resources), 46);
            this.imgMetro.Images.SetKeyName(46, "Information_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.manual_32, "manual_32", typeof(global::Vssoft.His.Properties.Resources), 47);
            this.imgMetro.Images.SetKeyName(47, "manual_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.number_lock_32, "number_lock_32", typeof(global::Vssoft.His.Properties.Resources), 48);
            this.imgMetro.Images.SetKeyName(48, "number_lock_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.status_32, "status_32", typeof(global::Vssoft.His.Properties.Resources), 49);
            this.imgMetro.Images.SetKeyName(49, "status_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.system_software_update_32, "system_software_update_32", typeof(global::Vssoft.His.Properties.Resources), 50);
            this.imgMetro.Images.SetKeyName(50, "system_software_update_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.TeamViewer_32, "TeamViewer_32", typeof(global::Vssoft.His.Properties.Resources), 51);
            this.imgMetro.Images.SetKeyName(51, "TeamViewer_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.thuoc_da_ke_32, "thuoc_da_ke_32", typeof(global::Vssoft.His.Properties.Resources), 52);
            this.imgMetro.Images.SetKeyName(52, "thuoc_da_ke_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.tu_truc32, "tu_truc32", typeof(global::Vssoft.His.Properties.Resources), 53);
            this.imgMetro.Images.SetKeyName(53, "tu_truc32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.unlock_red_32, "unlock_red_32", typeof(global::Vssoft.His.Properties.Resources), 54);
            this.imgMetro.Images.SetKeyName(54, "unlock_red_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.User_Testing_32, "User_Testing_32", typeof(global::Vssoft.His.Properties.Resources), 55);
            this.imgMetro.Images.SetKeyName(55, "User_Testing_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.vtyt_32, "vtyt_32", typeof(global::Vssoft.His.Properties.Resources), 56);
            this.imgMetro.Images.SetKeyName(56, "vtyt_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.welcome_32, "welcome_32", typeof(global::Vssoft.His.Properties.Resources), 57);
            this.imgMetro.Images.SetKeyName(57, "welcome_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.world_32, "world_32", typeof(global::Vssoft.His.Properties.Resources), 58);
            this.imgMetro.Images.SetKeyName(58, "world_32");
            this.imgMetro.InsertImage(global::Vssoft.His.Properties.Resources.table_office_32, "table_office_32", typeof(global::Vssoft.His.Properties.Resources), 59);
            this.imgMetro.Images.SetKeyName(59, "table_office_32");
            // 
            // rbpHome
            // 
            this.rbpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9,
            this.ribbonPageGroup13});
            this.rbpHome.Name = "rbpHome";
            this.rbpHome.Text = "Trang chủ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiDashboard);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiTableOffice);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            toolTipTitleItem3.Text = "Tổng Hợp";
            superToolTip16.Items.Add(toolTipTitleItem3);
            this.ribbonPageGroup3.SuperTip = superToolTip16;
            this.ribbonPageGroup3.Text = "Tổng Hợp";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiPatients);
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiIdentity);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            toolTipTitleItem4.Text = "Hành Chính";
            superToolTip17.Items.Add(toolTipTitleItem4);
            this.ribbonPageGroup7.SuperTip = superToolTip17;
            this.ribbonPageGroup7.Text = "Hành Chính";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.bbiMedicalExamination);
            this.ribbonPageGroup8.ItemLinks.Add(this.bbiTreatment);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Khám Bệnh";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.bbiImportMedicament);
            this.ribbonPageGroup9.ItemLinks.Add(this.bbiExportMedicament);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "Quản Lý Dược";
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.ItemLinks.Add(this.bbiXetNghiem);
            this.ribbonPageGroup13.ItemLinks.Add(this.bbiCDHA);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            this.ribbonPageGroup13.Text = "Cận Lâm Sàng";
            // 
            // rbpChucNang
            // 
            this.rbpChucNang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup10,
            this.ribbonPageGroup11,
            this.ribbonPageGroup12,
            this.ribbonPageGroup14,
            this.ribbonPageGroup15,
            this.ribbonPageGroup16});
            this.rbpChucNang.Name = "rbpChucNang";
            this.rbpChucNang.Text = "Chức năng";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bbiPayment);
            this.ribbonPageGroup5.ItemLinks.Add(this.bbiSendData);
            this.ribbonPageGroup5.ItemLinks.Add(this.bbiThuChi);
            this.ribbonPageGroup5.ItemLinks.Add(this.barSubItem3);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Viện Phí";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.bbiPhieuLinh);
            this.ribbonPageGroup10.ItemLinks.Add(this.bbiLinh_HCVTYT);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "Hóa chất - VTYT";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.bbiDuyetBenhAn);
            this.ribbonPageGroup11.ItemLinks.Add(this.bbiDictionary);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.Text = "Tổng Hợp";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.bbiDuocKhoaTheoNgay);
            this.ribbonPageGroup12.ItemLinks.Add(this.bbiXuatTheoNCC);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "Nhóm Dược";
            // 
            // ribbonPageGroup14
            // 
            this.ribbonPageGroup14.ItemLinks.Add(this.bbiSanXuatTaiSan);
            this.ribbonPageGroup14.ItemLinks.Add(this.bbiQLTaiSan);
            this.ribbonPageGroup14.ItemLinks.Add(this.bbiDanhMucTaiSan);
            this.ribbonPageGroup14.Name = "ribbonPageGroup14";
            this.ribbonPageGroup14.Text = "Quản Lý Tài Sản";
            // 
            // ribbonPageGroup15
            // 
            this.ribbonPageGroup15.ItemLinks.Add(this.bbiDTKSK);
            this.ribbonPageGroup15.ItemLinks.Add(this.bbiKSK_CanBo);
            this.ribbonPageGroup15.Name = "ribbonPageGroup15";
            this.ribbonPageGroup15.Text = "Khám Sức Khỏe";
            // 
            // ribbonPageGroup16
            // 
            this.ribbonPageGroup16.ItemLinks.Add(this.bbiThamDinh);
            this.ribbonPageGroup16.ItemLinks.Add(this.bbiBHXaPhuong);
            this.ribbonPageGroup16.Name = "ribbonPageGroup16";
            this.ribbonPageGroup16.Text = "BHYT";
            // 
            // rbpReport
            // 
            this.rbpReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.rbpReport.Name = "rbpReport";
            this.rbpReport.Text = "Báo cáo";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiBC_KhoaDuoc);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiBC_KeToanVienPhi);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiKeHoachTongHop);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiBC_BHYT);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiBC_CanLamSang);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbiBC_KhamBenhDieuTri);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Danh Sách Báo Cáo";
            // 
            // rbpSearch
            // 
            this.rbpSearch.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup17,
            this.ribbonPageGroup18});
            this.rbpSearch.Name = "rbpSearch";
            this.rbpSearch.Text = "Tra cứu";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiBN_HuyDon);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiThuocDaKeDon);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiThuocTuTruc);
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiBN_BHYTSaiQD);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Viện Phí";
            // 
            // ribbonPageGroup17
            // 
            this.ribbonPageGroup17.ItemLinks.Add(this.bbiKhoaChungTu);
            this.ribbonPageGroup17.ItemLinks.Add(this.bbiNhapXuat);
            this.ribbonPageGroup17.Name = "ribbonPageGroup17";
            this.ribbonPageGroup17.Text = "Dược";
            // 
            // ribbonPageGroup18
            // 
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiChapNhatKhoaPhong);
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiCapNhatTrangThai);
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiCapNhatMaCC);
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiKiemThu);
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiTuTrucTuDong);
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiCapNhatDichVu);
            this.ribbonPageGroup18.ItemLinks.Add(this.bbiDoiMaBenhVien);
            this.ribbonPageGroup18.Name = "ribbonPageGroup18";
            this.ribbonPageGroup18.Text = "Công Cụ";
            // 
            // rbpSystem
            // 
            this.rbpSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgClose,
            this.rbpgSecurity,
            this.rbpgDatabase,
            this.ribbonPageGroup2,
            this.rbpgSearch});
            this.rbpSystem.Name = "rbpSystem";
            this.rbpSystem.Text = "Hệ Thống";
            // 
            // rbpgClose
            // 
            this.rbpgClose.ItemLinks.Add(this.bbiClose, true);
            this.rbpgClose.ItemLinks.Add(this.bbiLogout);
            this.rbpgClose.ItemLinks.Add(this.bbiImformation, true);
            this.rbpgClose.ItemLinks.Add(this.bbiDiagram);
            this.rbpgClose.KeyTip = "KE";
            this.rbpgClose.Name = "rbpgClose";
            this.rbpgClose.ShowCaptionButton = false;
            this.rbpgClose.Text = "Hệ Thống";
            // 
            // rbpgSecurity
            // 
            this.rbpgSecurity.ItemLinks.Add(this.bbiUsers);
            this.rbpgSecurity.ItemLinks.Add(this.bbiPermission);
            this.rbpgSecurity.ItemLinks.Add(this.bbiChangepassword);
            this.rbpgSecurity.ItemLinks.Add(this.bbiSysLog);
            this.rbpgSecurity.Name = "rbpgSecurity";
            this.rbpgSecurity.ShowCaptionButton = false;
            this.rbpgSecurity.Text = "Bảo Mật";
            // 
            // rbpgDatabase
            // 
            this.rbpgDatabase.ItemLinks.Add(this.bbiBackup);
            this.rbpgDatabase.ItemLinks.Add(this.bbiRestore);
            this.rbpgDatabase.Name = "rbpgDatabase";
            this.rbpgDatabase.ShowCaptionButton = false;
            this.rbpgDatabase.Text = "Dữ Liệu";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiSetting);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiMenuReports);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiMenus);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Tùy chọn";
            // 
            // rbpgSearch
            // 
            this.rbpgSearch.ItemLinks.Add(this.bbiSearch);
            this.rbpgSearch.Name = "rbpgSearch";
            this.rbpgSearch.ShowCaptionButton = false;
            this.rbpgSearch.Text = "Tìm Kiếm";
            // 
            // rbpHelp
            // 
            this.rbpHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbpgHelp,
            this.rbpgInfo,
            this.rbpgSearch2});
            this.rbpHelp.Name = "rbpHelp";
            this.rbpHelp.Text = "Trợ Giúp";
            // 
            // rbpgHelp
            // 
            this.rbpgHelp.ItemLinks.Add(this.bbiWelcome);
            this.rbpgHelp.ItemLinks.Add(this.bbiHelp, true);
            this.rbpgHelp.ItemLinks.Add(this.bbiHelp2);
            this.rbpgHelp.ItemLinks.Add(this.bbiWebsite);
            this.rbpgHelp.ItemLinks.Add(this.bbiContact);
            this.rbpgHelp.ItemLinks.Add(this.bbiTeamView);
            this.rbpgHelp.Name = "rbpgHelp";
            this.rbpgHelp.ShowCaptionButton = false;
            this.rbpgHelp.Text = "Trợ Giúp";
            // 
            // rbpgInfo
            // 
            this.rbpgInfo.ItemLinks.Add(this.bbiRegsiter);
            this.rbpgInfo.ItemLinks.Add(this.bbiAuthor);
            this.rbpgInfo.ItemLinks.Add(this.bbiUpdateGroup);
            this.rbpgInfo.Name = "rbpgInfo";
            this.rbpgInfo.ShowCaptionButton = false;
            this.rbpgInfo.Text = "Thông Tin";
            // 
            // rbpgSearch2
            // 
            this.rbpgSearch2.ItemLinks.Add(this.bbiSearch);
            this.rbpgSearch2.Name = "rbpgSearch2";
            this.rbpgSearch2.ShowCaptionButton = false;
            this.rbpgSearch2.Text = "Tìm Kiếm";
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // rbsMain
            // 
            this.rbsMain.ItemLinks.Add(this.barCompany);
            this.rbsMain.ItemLinks.Add(this.lblToday, true);
            this.rbsMain.ItemLinks.Add(this.lblInfo, true, "", "", true);
            this.rbsMain.ItemLinks.Add(this.lblLink);
            this.rbsMain.ItemLinks.Add(this.bbiOverwrite, true);
            this.rbsMain.ItemLinks.Add(this.bbiNumlock, true);
            this.rbsMain.ItemLinks.Add(this.bbiCalculator);
            this.rbsMain.Location = new System.Drawing.Point(0, 619);
            this.rbsMain.Name = "rbsMain";
            this.rbsMain.Ribbon = this.rbcMain;
            this.rbsMain.Size = new System.Drawing.Size(1025, 23);
            // 
            // imgClassic
            // 
            this.imgClassic.ImageSize = new System.Drawing.Size(32, 32);
            this.imgClassic.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgClassic.ImageStream")));
            // 
            // ppTimekeeperTable
            // 
            this.ppTimekeeperTable.Name = "ppTimekeeperTable";
            this.ppTimekeeperTable.Ribbon = this.rbcMain;
            // 
            // PPTimekeeper
            // 
            this.PPTimekeeper.Name = "PPTimekeeper";
            this.PPTimekeeper.Ribbon = this.rbcMain;
            // 
            // ppEmployee
            // 
            this.ppEmployee.Name = "ppEmployee";
            this.ppEmployee.Ribbon = this.rbcMain;
            // 
            // pmInit
            // 
            this.pmInit.Name = "pmInit";
            this.pmInit.Ribbon = this.rbcMain;
            // 
            // tabMdi
            // 
            this.tabMdi.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.tabMdi.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.tabMdi.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.tabMdi.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabMdi.MdiParent = this;
            this.tabMdi.SetNextMdiChildMode = DevExpress.XtraTabbedMdi.SetNextMdiChildMode.Windows;
            this.tabMdi.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            this.tabMdi.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "barButtonItem4";
            this.barButtonItem12.Id = 313;
            this.barButtonItem12.ImageOptions.LargeImageIndex = 17;
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "barButtonItem4";
            this.barButtonItem13.Id = 313;
            this.barButtonItem13.ImageOptions.LargeImageIndex = 17;
            this.barButtonItem13.Name = "barButtonItem13";
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "barButtonItem4";
            this.barButtonItem14.Id = 313;
            this.barButtonItem14.ImageOptions.LargeImageIndex = 17;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "barButtonItem4";
            this.barButtonItem15.Id = 313;
            this.barButtonItem15.ImageOptions.LargeImageIndex = 17;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSearch);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tìm Kiếm";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "Tìm Kiếm:";
            this.barEditItem2.Edit = this.rpiSearch;
            this.barEditItem2.EditWidth = 300;
            this.barEditItem2.Id = 352;
            this.barEditItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barEditItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // Alert
            // 
            this.Alert.AutoFormDelay = 30000;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 642);
            this.Controls.Add(this.pccAppMenu);
            this.Controls.Add(this.rbsMain);
            this.Controls.Add(this.rbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "frmMain";
            this.Ribbon = this.rbcMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.rbsMain;
            this.Text = "Phần Mềm Quản Lý Bệnh Viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pccAppMenu)).EndInit();
            this.pccAppMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcAppMenuFileLabels)).EndInit();
            this.pcAppMenuFileLabels.ResumeLayout(false);
            this.pcAppScroll.ResumeLayout(false);
            this.pcAppScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMetro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgClassic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppTimekeeperTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPTimekeeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmInit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Timer timer;
        private AlertControl Alert;
        private BarButtonItem barButtonItem12;
        private BarButtonItem barButtonItem13;
        private BarButtonItem barButtonItem14;
        private BarButtonItem barButtonItem15;
        private BarStaticItem barCompany;
        private BarEditItem barEditItem1;
        private BarEditItem barEditItem2;
        private BarMdiChildrenListItem barMdiChildrenListItem1;
        private BarEditItem bbeMonthDefault;
        private BarButtonItem bbiActionCenter;
        private BarButtonItem bbiBackup;
        private BarButtonItem bbiBackup1;
        private BarButtonItem bbiBranch;
        private BarButtonItem bbiCalculator;
        private BarButtonItem bbiChangepassword;
        private BarButtonItem bbiClose;
        private BarButtonItem bbiContact1;
        private BarButtonItem bbiDepartment;
        private BarButtonItem bbiDiagram;
        private BarButtonItem bbiSetting;
        private BarButtonItem bbiGroup;
        private BarButtonItem bbiHelp;
        private BarButtonItem bbiHelp1;
        private BarSubItem bbiHelp2;
        private BarButtonItem bbiLogout;
        private BarButtonItem bbiMinSalary;
        private BarStaticItem bbiNumlock;
        private BarButtonItem bbiImformation;
        private BarStaticItem bbiOverwrite;
        private BarButtonItem bbiPermission;
        private BarButtonItem bbiRegsiter;
        private BarButtonItem bbiRestore;
        private BarButtonItem bbiRestore1;
        private BarEditItem bbiSearch;
        private BarEditItem bbiStyle;
        private BarButtonItem bbiSysLog;
        private BarButtonItem bbiTrash;
        private BarSubItem bbiUpdateGroup;
        private BarButtonItem bbiUpdateOnline1;
        private BarButtonItem bbiUserGroup;
        private BarButtonItem bbiUsers;
        private BarButtonItem bbiWebsite;
        private BarButtonItem bbiWelcome;
        private BarSubItem bbSkin;
        private BarButtonItem biiHelpNormal;
        private BarButtonItem biiHelpVideo;
        private BarButtonItem bbiAuthor;
        private DevExpress.Utils.ImageCollection imgClassic;
        private DevExpress.Utils.ImageCollection imgMetro;
        private DevExpress.Utils.ImageCollection ImgSmall;
        private BarButtonItem ISystem;
        private LabelControl labelControl1;
        private BarStaticItem lblAccount;
        private BarStaticItem lblDatabase;
        private BarStaticItem lblInfo;
        private BarLinkContainerItem lblLink;
        private BarStaticItem lblServer;
        private BarStaticItem lblToday;
        private PanelControl pcAppMenuFileLabels;
        private XtraScrollableControl pcAppScroll;
        private PopupControlContainer pccAppMenu;
        private FlowLayoutPanel pcRecentList;
        private ApplicationMenu pmAppMain;
        private PopupMenu pmInit;
        private PopupMenu pmSystem;
        private PopupMenu ppEmployee;
        private PopupMenu PPTimekeeper;
        private PopupMenu ppTimekeeperTable;
        private RibbonControl rbcMain;
        private RibbonPageGroup rbpgClose;
        private RibbonPageGroup rbpgDatabase;
        private RibbonPageGroup rbpgHelp;
        private RibbonPageGroup rbpgInfo;
        private RibbonPageGroup rbpgSearch;
        private RibbonPageGroup rbpgSearch2;
        private RibbonPageGroup rbpgSecurity;
        private RibbonPage rbpHelp;
        private RibbonPage rbpSystem;
        private RibbonStatusBar rbsMain;
        private RepositoryItemDateEdit repositoryItemDateEdit1;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private RepositoryItemComboBox repStyle;
        private RibbonPageGroup ribbonPageGroup1;
        private RibbonPageGroup ribbonPageGroup2;
        private RepositoryItemButtonEdit rpiSearch;
        private XtraTabbedMdiManager tabMdi;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private RibbonPage rbpHome;
        private RibbonPageGroup ribbonPageGroup3;
        private RibbonPage rbpSearch;
        private RibbonPageGroup ribbonPageGroup4;
        private RibbonPage rbpChucNang;
        private RibbonPageGroup ribbonPageGroup5;
        private RibbonPage rbpReport;
        private RibbonPageGroup ribbonPageGroup6;
        private BarButtonItem bbiMenuReports;
        private BarButtonItem bbiMenus;
        private BarButtonItem bbiDashboard;
        private BarButtonItem bbiPatients;
        private BarButtonItem bbiIdentity;
        private BarButtonItem bbiMedicalExamination;
        private BarButtonItem bbiTreatment;
        private RibbonPageGroup ribbonPageGroup7;
        private RibbonPageGroup ribbonPageGroup8;
        private RibbonPageGroup ribbonPageGroup9;
        private BarButtonItem bbiImportMedicament;
        private BarButtonItem bbiExportMedicament;
        private BarButtonItem bbiXuatNgoaiTru;
        private BarButtonItem bbiXuatDieuTri;
        private BarButtonItem bbiHuHaoDuoc;
        private BarButtonItem bbiKiemKeDuoc;
        private BarButtonItem bbiSuDungDuoc;
        private BarButtonItem bbiDuTru;
        private BarButtonItem bbiNhapTraDuoc;
        private BarButtonItem bbiDLTuyenDuoi;
        private BarButtonItem bbiSanXuatDuoc;
        private BarButtonItem bbiPayment;
        private BarButtonItem bbiSendData;
        private BarButtonItem bbiThuChi;
        private BarSubItem barSubItem3;
        private BarButtonItem bbiNhapBNNgoaiBV;
        private BarButtonItem bbiVP_KhoaDLTheoNgay;
        private BarButtonItem bbiKetNoiXaPhuong;
        private RibbonPageGroup ribbonPageGroup10;
        private BarButtonItem bbiPhieuLinh;
        private BarButtonItem bbiLinh_HCVTYT;
        private BarButtonItem bbiDuyetBenhAn;
        private RibbonPageGroup ribbonPageGroup11;
        private RibbonPageGroup ribbonPageGroup12;
        private BarButtonItem bbiXetNghiem;
        private BarButtonItem bbiCDHA;
        private RibbonPageGroup ribbonPageGroup13;
        private BarButtonItem bbiDuocKhoaTheoNgay;
        private BarButtonItem bbiXuatTheoNCC;
        private BarButtonItem bbiSanXuatTaiSan;
        private BarButtonItem bbiQLTaiSan;
        private BarButtonItem bbiDanhMucTaiSan;
        private BarButtonItem bbiDTKSK;
        private BarButtonItem bbiKSK_CanBo;
        private RibbonPageGroup ribbonPageGroup14;
        private RibbonPageGroup ribbonPageGroup15;
        private BarButtonItem bbiDictionary;
        private RibbonPageGroup ribbonPageGroup16;
        private BarButtonItem bbiBC_KhoaDuoc;
        private BarButtonItem bbiBC_KeToanVienPhi;
        private BarButtonItem bbiKeHoachTongHop;
        private BarButtonItem bbiBC_BHYT;
        private BarButtonItem bbiBC_CanLamSang;
        private BarButtonItem bbiBC_KhamBenhDieuTri;
        private BarButtonItem bbiBN_HuyDon;
        private BarButtonItem bbiThuocDaKeDon;
        private BarButtonItem bbiThuocTuTruc;
        private BarButtonItem bbiBN_BHYTSaiQD;
        private BarButtonItem bbiKhoaChungTu;
        private BarButtonItem bbiNhapXuat;
        private BarButtonItem bbiChapNhatKhoaPhong;
        private BarButtonItem bbiCapNhatTrangThai;
        private BarButtonItem bbiCapNhatMaCC;
        private BarButtonItem bbiKiemThu;
        private BarButtonItem bbiTuTrucTuDong;
        private BarButtonItem bbiCapNhatDichVu;
        private BarButtonItem bbiDoiMaBenhVien;
        private RibbonPageGroup ribbonPageGroup17;
        private RibbonPageGroup ribbonPageGroup18;
        private BarButtonItem bbiThamDinh;
        private BarButtonItem bbiBHXaPhuong;
        private BarButtonItem bbiCapNhatPhanMem;
        private BarButtonItem bbiNangCapDuLieu;
        private BarButtonItem bbiContact;
        private BarButtonItem bbiTeamView;
        private BarButtonItem bbiTableOffice;
    }
}