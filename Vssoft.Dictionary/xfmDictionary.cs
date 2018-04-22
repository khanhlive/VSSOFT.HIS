namespace Vssoft.Dictionary
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraNavBar.ViewInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Vssoft.Common;
    using Vssoft.Data.Enum;

    public class xfmDictionary : Form
    {
        #region Controls
        private NavBarItem bbiAllowance;
        private NavBarItem bbiBranch;
        private NavBarItem bbiDegree;
        private NavBarItem bbiDepartment;
        private NavBarItem bbiEducation;
        private NavBarItem bbiEthnic;
        private NavBarItem bbiGroup;
        private NavBarItem bbiGroupRate;
        private NavBarItem bbiHoliday;
        private NavBarItem bbiJob;
        private NavBarItem bbiMachine;
        private NavBarItem bbiPatientObject;
        private NavBarItem bbiPosition;
        private NavBarItem bbiProduct;
        private NavBarItem bbiProductGroup;
        private NavBarItem bbiProfessional;
        private NavBarItem bbiRank;
        private NavBarItem bbiRate;
        private NavBarItem bbiRelative;
        private NavBarItem bbiDoiTuongBHYT;
        private NavBarItem bbiSalaryIncome;
        private NavBarItem bbiShift;
        private NavBarItem bbiState;
        private NavBarItem bbiStep;
        private NavBarItem bbiSubsidiary;
        private NavBarItem bbiSymbol;
        private NavBarItem bbiUnit;
        private IContainer components = null;
        private GroupControl gcControl;
        private NavBarControl navBarControl1;
        private NavBarGroup navEmployee;
        private NavBarGroup navOrganization;
        private NavBarGroup navTimekeeping;
        private NavBarItem navBarItem1;
        private NavBarItem navBarItem2;
        
        private ImageCollection imageCollection1;

        //private Perfect.Dictionary.xucAllowance xucAllowance;
        //private Perfect.Dictionary.xucBranch xucBranch;
        //private Perfect.Dictionary.xucDegree xucDegree;
        //private Perfect.Dictionary.xucDepartment xucDepartment;
        //private Perfect.Dictionary.xucEducation xucEducation;
        //private Perfect.Dictionary.xucEthnic xucEthnic;
        //private Perfect.Dictionary.xucGroup xucGroup;
        //private Perfect.Dictionary.xucGroupRate xucGroupRate;
        //private Perfect.Dictionary.xucHoliday xucHoliday;
        //private Perfect.Dictionary.xucInformatic xucInformatic;
        //private Perfect.Dictionary.xucJob xucJob;
        //private Perfect.Dictionary.xucLanguage xucLanguage;
        //private Perfect.Dictionary.xucMachine xucMachine;
        //private Perfect.Dictionary.xucNationality xucNationality;
        private Perfect.Dictionary.xucPosition xucPosition;
        private NavBarItem bbiSpecialty;
        private NavBarItem navBarItem3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiOpenNewTab;
        private ToolStripMenuItem tsmiThuNho;
        private Common.xucBase dic_ModuleControl;
        //private Perfect.Dictionary.xucProduct xucProduct;
        //private Perfect.Dictionary.xucProductGroup xucProductGroup;
        //private Perfect.Dictionary.xucProfessional xucProfessional;
        //private Perfect.Dictionary.xucRank xucRank;
        //private Perfect.Dictionary.xucRate xucRate;
        //private Perfect.Dictionary.xucRelative xucRelative;
        //private Perfect.Dictionary.xucReligion xucReligion;
        //private Perfect.Dictionary.xucShift xucShift;
        //private Perfect.Dictionary.xucSkill xucSkill;
        //private Perfect.Dictionary.xucState xucState;
        //private Perfect.Dictionary.xucStep xucStep;
        //private Perfect.Dictionary.xucSubsidiary xucSubsidiary;
        //private Perfect.Dictionary.xucSymbol xucSymbol;
        //private Perfect.Dictionary.xucUnit xucUnit;
        #endregion
        public xfmDictionary()
        {
            this.InitializeComponent();
            this.InitMultiLanguages();
            base.Load += new EventHandler(this.xfmDictionary_Load);
        }

        private void bbiAllowance_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucAllowance", "");
        }

        private void bbiBranch_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucBranch", "");
        }

        private void bbiDegree_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_PhongBan, ((NavBarItem)sender).Caption);
        }

        private void bbiDepartment_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucDepartment", "");
        }

        private void bbiEducation_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucEducation", "");
        }

        private void bbiEthnic_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DanToc, ((NavBarItem)sender).Caption);
        }

        private void bbiGroup_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucGroup", "");
        }

        private void bbiGroupRate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucGroupRate", "");
        }

        private void bbiHoliday_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucHoliday", "");
        }

        private void bbiInformatic_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucInformatic", "");
        }

        private void bbiJob_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucJob", "");
        }

        private void bbiLanguage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucLanguage", "");
        }

        private void bbiMachine_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucMachine", "");
        }

        private void bbiPatientObject_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DOITUONGBENHNHAN, ((NavBarItem)sender).Caption);
        }

        private void bbiPosition_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_CanBo, ((NavBarItem)sender).Caption);
        }

        private void bbiProduct_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucProduct", "");
        }

        private void bbiProductGroup_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucProductGroup", "");
        }

        private void bbiProfessional_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucProfessional", "");
        }

        private void bbiRank_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucRank", "");
        }

        private void bbiRate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucRate", "");
        }

        private void bbiRelative_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucRelative", "");
        }

        private void bbiDoiTuongBHYT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DoiTuongBHYT, ((NavBarItem)sender).Caption);
        }

        private void bbiShift_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucShift", "");
        }

        private void bbiSkill_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucSkill", "");
        }

        private void bbiState_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucState", "");
        }

        private void bbiStep_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucStep", "");
        }

        private void bbiSubsidiary_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucSubsidiary", "");
        }

        private void bbiSymbol_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucSymbol", "");
        }

        private void bbiUnit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucUnit", "");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Execute(string id, string @ref)
        {

            this.gcControl.Text = "Demo";// this.bbiLanguage.Caption;
            if (this.xucPosition != null)
            {
                this.xucPosition.BringToFront();
            }
            this.xucPosition = new Perfect.Dictionary.xucPosition();
            this.xucPosition.Dock = DockStyle.Fill;
            this.gcControl.Controls.Add(this.xucPosition);
            this.xucPosition.BringToFront();
        }

        private void Execute(DictionaryModuleType id, string caption)
        { 
            this.gcControl.Text = caption;
            if (this.dic_ModuleControl != null)
            {
                this.dic_ModuleControl.BringToFront();
            }
            switch (id)
            {
                case DictionaryModuleType.DIC_CanBo:
                    this.dic_ModuleControl = new UI.Core.ucCanBo();
                    break;
                case DictionaryModuleType.DIC_DanToc:
                    this.dic_ModuleControl = new UI.Core.ucDanToc();
                    break;
                case DictionaryModuleType.DIC_ChuyenKhoa:
                    this.dic_ModuleControl = new UI.Core.ucDIC_Specialty();
                    break;
                case DictionaryModuleType.DIC_PhongBan:
                    this.dic_ModuleControl = new UI.Core.ucDIC_Department();
                    break;
                case DictionaryModuleType.DIC_DoiTuongBHYT:
                    this.dic_ModuleControl = new UI.Core.ucDIC_DoiTuong();
                    break;
                case DictionaryModuleType.DIC_DOITUONGBENHNHAN:
                    this.dic_ModuleControl = new UI.Core.ucDIC_DTBN();
                    break;
                case DictionaryModuleType.DIC_DUONGDUNG:
                    break;
                case DictionaryModuleType.DIC_HUYEN:
                    break;
                case DictionaryModuleType.DIC_TINHTHANH:
                    break;
                case DictionaryModuleType.DIC_XAPHUONG:
                    break;
                case DictionaryModuleType.DIC_NGHENGHIEP:
                    break;
                case DictionaryModuleType.DIC_NHACUNGCAP:
                    break;
                case DictionaryModuleType.DIC_NHOMDICHVU:
                    break;
                case DictionaryModuleType.DIC_TIEUNHOMDICHVU:
                    break;
                default:
                    break;
            }
            this.dic_ModuleControl.Dock = DockStyle.Fill;
            this.gcControl.Controls.Add(this.dic_ModuleControl);
            this.dic_ModuleControl.BringToFront();
        }
        private void ExecuteNewTab(DictionaryModuleType id, string caption)
        {
            Form frmNewTab = new Form();
            ucBaseBasicView view;
            switch (id)
            {
                case DictionaryModuleType.DIC_CanBo:
                    view = new UI.Core.ucCanBo();
                    break;
                case DictionaryModuleType.DIC_DanToc:
                    view = new UI.Core.ucDanToc();
                    break;
                case DictionaryModuleType.DIC_ChuyenKhoa:
                    view = new UI.Core.ucDIC_Specialty();
                    break;
                case DictionaryModuleType.DIC_PhongBan:
                    view = new UI.Core.ucDIC_Department();
                    break;
                default:view = new ucBaseBasicView();
                    break;
            }
            view.Dock = DockStyle.Fill;
            frmNewTab.Controls.Add(this.dic_ModuleControl);
            view.BringToFront();
            frmNewTab.WindowState = FormWindowState.Maximized;
            IFormMain ribbonForm = (IFormMain)this.MdiParent;
            ribbonForm.OpenFormNewTab(frmNewTab);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfmDictionary));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navEmployee = new DevExpress.XtraNavBar.NavBarGroup();
            this.bbiPosition = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiProfessional = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDegree = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiJob = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiPatientObject = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiEthnic = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDoiTuongBHYT = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiRelative = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiEducation = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiSpecialty = new DevExpress.XtraNavBar.NavBarItem();
            this.navOrganization = new DevExpress.XtraNavBar.NavBarGroup();
            this.bbiSubsidiary = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiBranch = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDepartment = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.navTimekeeping = new DevExpress.XtraNavBar.NavBarGroup();
            this.bbiShift = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiSymbol = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiMachine = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiHoliday = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiRank = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiStep = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiAllowance = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiRate = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiGroupRate = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiUnit = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiProductGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiProduct = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiState = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiSalaryIncome = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenNewTab = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiThuNho = new System.Windows.Forms.ToolStripMenuItem();
            this.gcControl = new DevExpress.XtraEditors.GroupControl();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcControl)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navEmployee;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.DragDropFlags = ((DevExpress.XtraNavBar.NavBarDragDrop)((((DevExpress.XtraNavBar.NavBarDragDrop.Default | DevExpress.XtraNavBar.NavBarDragDrop.AllowDrag) 
            | DevExpress.XtraNavBar.NavBarDragDrop.AllowDrop) 
            | DevExpress.XtraNavBar.NavBarDragDrop.AllowOuterDrop)));
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navEmployee,
            this.navOrganization,
            this.navTimekeeping});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.bbiPosition,
            this.bbiProfessional,
            this.bbiEthnic,
            this.bbiEducation,
            this.bbiPatientObject,
            this.bbiDoiTuongBHYT,
            this.bbiJob,
            this.bbiShift,
            this.bbiDegree,
            this.bbiRelative,
            this.bbiRank,
            this.bbiStep,
            this.bbiBranch,
            this.bbiDepartment,
            this.bbiGroup,
            this.bbiAllowance,
            this.bbiSymbol,
            this.bbiMachine,
            this.bbiRate,
            this.bbiGroupRate,
            this.bbiUnit,
            this.bbiProductGroup,
            this.bbiProduct,
            this.bbiState,
            this.bbiHoliday,
            this.bbiSubsidiary,
            this.bbiSalaryIncome,
            this.navBarItem1,
            this.navBarItem2,
            this.bbiSpecialty});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.NavigationPaneMaxVisibleGroups = 5;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 190;
            this.navBarControl1.Size = new System.Drawing.Size(190, 628);
            this.navBarControl1.SmallImages = this.imageCollection1;
            this.navBarControl1.TabIndex = 3;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            this.navBarControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navBarControl1_MouseDown);
            // 
            // navEmployee
            // 
            this.navEmployee.Caption = "Danh Mục Hành Chính";
            this.navEmployee.Expanded = true;
            this.navEmployee.ImageOptions.LargeImageIndex = 0;
            this.navEmployee.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.navEmployee.ImageOptions.SmallImageIndex = 0;
            this.navEmployee.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiPosition),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiProfessional),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDegree),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiJob),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiPatientObject),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiEthnic),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDoiTuongBHYT),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiRelative),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiEducation),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiSpecialty)});
            this.navEmployee.Name = "navEmployee";
            // 
            // bbiPosition
            // 
            this.bbiPosition.Caption = "Cán Bộ";
            this.bbiPosition.ImageOptions.LargeImageIndex = 3;
            this.bbiPosition.ImageOptions.SmallImageIndex = 3;
            this.bbiPosition.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiPosition.Name = "bbiPosition";
            this.bbiPosition.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiPosition_LinkClicked);
            // 
            // bbiProfessional
            // 
            this.bbiProfessional.Caption = "Bệnh Viện";
            this.bbiProfessional.ImageOptions.SmallImageIndex = 3;
            this.bbiProfessional.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiProfessional.Name = "bbiProfessional";
            this.bbiProfessional.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiProfessional_LinkClicked);
            // 
            // bbiDegree
            // 
            this.bbiDegree.Caption = "Phòng ban";
            this.bbiDegree.ImageOptions.SmallImageIndex = 3;
            this.bbiDegree.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDegree.Name = "bbiDegree";
            this.bbiDegree.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDegree_LinkClicked);
            // 
            // bbiJob
            // 
            this.bbiJob.Caption = "Nghề Nghiệp";
            this.bbiJob.ImageOptions.SmallImageIndex = 3;
            this.bbiJob.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiJob.Name = "bbiJob";
            this.bbiJob.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiJob_LinkClicked);
            // 
            // bbiPatientObject
            // 
            this.bbiPatientObject.Caption = "Đối Tượng Bệnh Nhân";
            this.bbiPatientObject.ImageOptions.SmallImageIndex = 3;
            this.bbiPatientObject.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiPatientObject.Name = "bbiPatientObject";
            this.bbiPatientObject.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiPatientObject_LinkClicked);
            // 
            // bbiEthnic
            // 
            this.bbiEthnic.Caption = "Dân Tộc";
            this.bbiEthnic.ImageOptions.SmallImageIndex = 3;
            this.bbiEthnic.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiEthnic.Name = "bbiEthnic";
            this.bbiEthnic.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiEthnic_LinkClicked);
            // 
            // bbiDoiTuongBHYT
            // 
            this.bbiDoiTuongBHYT.Caption = "Đối Tượng Bảo Hiểm";
            this.bbiDoiTuongBHYT.ImageOptions.SmallImageIndex = 3;
            this.bbiDoiTuongBHYT.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDoiTuongBHYT.Name = "bbiDoiTuongBHYT";
            this.bbiDoiTuongBHYT.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDoiTuongBHYT_LinkClicked);
            // 
            // bbiRelative
            // 
            this.bbiRelative.Caption = "Mã ICD";
            this.bbiRelative.ImageOptions.SmallImageIndex = 3;
            this.bbiRelative.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiRelative.Name = "bbiRelative";
            this.bbiRelative.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiRelative_LinkClicked);
            // 
            // bbiEducation
            // 
            this.bbiEducation.Caption = "Danh Sách Thẻ Hết Hạn";
            this.bbiEducation.ImageOptions.SmallImageIndex = 3;
            this.bbiEducation.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiEducation.Name = "bbiEducation";
            this.bbiEducation.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiEducation_LinkClicked);
            // 
            // bbiSpecialty
            // 
            this.bbiSpecialty.Caption = "Chuyên Khoa";
            this.bbiSpecialty.ImageOptions.SmallImageIndex = 3;
            this.bbiSpecialty.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiSpecialty.Name = "bbiSpecialty";
            this.bbiSpecialty.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiSpecialty_LinkClicked);
            // 
            // navOrganization
            // 
            this.navOrganization.Caption = "Nhóm Dược";
            this.navOrganization.ImageOptions.LargeImageIndex = 1;
            this.navOrganization.ImageOptions.SmallImageIndex = 2;
            this.navOrganization.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiSubsidiary),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiBranch),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDepartment),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiGroup)});
            this.navOrganization.Name = "navOrganization";
            // 
            // bbiSubsidiary
            // 
            this.bbiSubsidiary.Caption = "Dược";
            this.bbiSubsidiary.ImageOptions.SmallImageIndex = 4;
            this.bbiSubsidiary.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiSubsidiary.Name = "bbiSubsidiary";
            this.bbiSubsidiary.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiSubsidiary_LinkClicked);
            // 
            // bbiBranch
            // 
            this.bbiBranch.Caption = "Nhà Cung Cấp";
            this.bbiBranch.ImageOptions.SmallImageIndex = 4;
            this.bbiBranch.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiBranch.Name = "bbiBranch";
            this.bbiBranch.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiBranch_LinkClicked);
            // 
            // bbiDepartment
            // 
            this.bbiDepartment.Caption = "Giá Thuốc Ưu Tiên";
            this.bbiDepartment.ImageOptions.SmallImageIndex = 4;
            this.bbiDepartment.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDepartment.Name = "bbiDepartment";
            this.bbiDepartment.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDepartment_LinkClicked);
            // 
            // bbiGroup
            // 
            this.bbiGroup.Caption = "Đơn Thuốc Mẫu";
            this.bbiGroup.ImageOptions.SmallImageIndex = 4;
            this.bbiGroup.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiGroup.Name = "bbiGroup";
            this.bbiGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiGroup_LinkClicked);
            // 
            // navTimekeeping
            // 
            this.navTimekeeping.Caption = "Nhóm Dịch Vụ";
            this.navTimekeeping.ImageOptions.LargeImageIndex = 2;
            this.navTimekeeping.ImageOptions.SmallImageIndex = 1;
            this.navTimekeeping.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiShift),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiSymbol),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiMachine),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiHoliday),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navTimekeeping.Name = "navTimekeeping";
            // 
            // bbiShift
            // 
            this.bbiShift.Caption = "Dịch Vụ";
            this.bbiShift.ImageOptions.SmallImageIndex = 5;
            this.bbiShift.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiShift.Name = "bbiShift";
            this.bbiShift.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiShift_LinkClicked);
            // 
            // bbiSymbol
            // 
            this.bbiSymbol.Caption = "Nhóm Dịch Vụ";
            this.bbiSymbol.ImageOptions.SmallImageIndex = 5;
            this.bbiSymbol.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiSymbol.Name = "bbiSymbol";
            this.bbiSymbol.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiSymbol_LinkClicked);
            // 
            // bbiMachine
            // 
            this.bbiMachine.Caption = "Tiểu Nhóm Dịch Vụ";
            this.bbiMachine.ImageOptions.SmallImageIndex = 5;
            this.bbiMachine.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiMachine.Name = "bbiMachine";
            this.bbiMachine.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiMachine_LinkClicked);
            // 
            // bbiHoliday
            // 
            this.bbiHoliday.Caption = "Kết Quả Mẫu";
            this.bbiHoliday.ImageOptions.SmallImageIndex = 5;
            this.bbiHoliday.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiHoliday.Name = "bbiHoliday";
            this.bbiHoliday.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiHoliday_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Dịch Vụ Chi Tiết";
            this.navBarItem1.ImageOptions.SmallImageIndex = 5;
            this.navBarItem1.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Biên Lai";
            this.navBarItem2.ImageOptions.SmallImageIndex = 5;
            this.navBarItem2.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.navBarItem2.Name = "navBarItem2";
            // 
            // bbiRank
            // 
            this.bbiRank.Caption = "Ngạch Lương";
            this.bbiRank.ImageOptions.LargeImageIndex = 66;
            this.bbiRank.ImageOptions.SmallImageIndex = 23;
            this.bbiRank.Name = "bbiRank";
            this.bbiRank.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiRank_LinkClicked);
            // 
            // bbiStep
            // 
            this.bbiStep.Caption = "Bậc Lương";
            this.bbiStep.ImageOptions.LargeImageIndex = 67;
            this.bbiStep.ImageOptions.SmallImageIndex = 24;
            this.bbiStep.Name = "bbiStep";
            this.bbiStep.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiStep_LinkClicked);
            // 
            // bbiAllowance
            // 
            this.bbiAllowance.Caption = "Phụ Cấp";
            this.bbiAllowance.ImageOptions.SmallImageIndex = 25;
            this.bbiAllowance.Name = "bbiAllowance";
            this.bbiAllowance.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiAllowance_LinkClicked);
            // 
            // bbiRate
            // 
            this.bbiRate.Caption = "Tiêu Chí Đánh Giá";
            this.bbiRate.ImageOptions.SmallImageIndex = 14;
            this.bbiRate.Name = "bbiRate";
            this.bbiRate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiRate_LinkClicked);
            // 
            // bbiGroupRate
            // 
            this.bbiGroupRate.Caption = "Nhóm Tiêu Chí";
            this.bbiGroupRate.ImageOptions.SmallImageIndex = 14;
            this.bbiGroupRate.Name = "bbiGroupRate";
            this.bbiGroupRate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiGroupRate_LinkClicked);
            // 
            // bbiUnit
            // 
            this.bbiUnit.Caption = "Đơn Vị Tính";
            this.bbiUnit.ImageOptions.SmallImageIndex = 29;
            this.bbiUnit.Name = "bbiUnit";
            this.bbiUnit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiUnit_LinkClicked);
            // 
            // bbiProductGroup
            // 
            this.bbiProductGroup.Caption = "Nhóm Sản Phẩm";
            this.bbiProductGroup.ImageOptions.SmallImageIndex = 30;
            this.bbiProductGroup.Name = "bbiProductGroup";
            this.bbiProductGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiProductGroup_LinkClicked);
            // 
            // bbiProduct
            // 
            this.bbiProduct.Caption = "Sản Phẩm";
            this.bbiProduct.ImageOptions.SmallImageIndex = 31;
            this.bbiProduct.Name = "bbiProduct";
            this.bbiProduct.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiProduct_LinkClicked);
            // 
            // bbiState
            // 
            this.bbiState.Caption = "Công Đoạn Sản Xuất";
            this.bbiState.ImageOptions.SmallImageIndex = 32;
            this.bbiState.Name = "bbiState";
            this.bbiState.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiState_LinkClicked);
            // 
            // bbiSalaryIncome
            // 
            this.bbiSalaryIncome.Caption = "bbiSalaryIncome";
            this.bbiSalaryIncome.Name = "bbiSalaryIncome";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::Vssoft.Dictionary.Properties.Resource.hanh_chinh_32, "hanh_chinh_32", typeof(global::Vssoft.Dictionary.Properties.Resource), 0);
            this.imageCollection1.Images.SetKeyName(0, "hanh_chinh_32");
            this.imageCollection1.InsertImage(global::Vssoft.Dictionary.Properties.Resource.medical_test_stethoscope_32, "medical_test_stethoscope_32", typeof(global::Vssoft.Dictionary.Properties.Resource), 1);
            this.imageCollection1.Images.SetKeyName(1, "medical_test_stethoscope_32");
            this.imageCollection1.InsertImage(global::Vssoft.Dictionary.Properties.Resource.pill_drugs_32, "pill_drugs_32", typeof(global::Vssoft.Dictionary.Properties.Resource), 2);
            this.imageCollection1.Images.SetKeyName(2, "pill_drugs_32");
            this.imageCollection1.InsertGalleryImage("bofileattachment_32x32.png", "images/business%20objects/bofileattachment_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bofileattachment_32x32.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "bofileattachment_32x32.png");
            this.imageCollection1.InsertGalleryImage("boreport_32x32.png", "images/business%20objects/boreport_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/boreport_32x32.png"), 4);
            this.imageCollection1.Images.SetKeyName(4, "boreport_32x32.png");
            this.imageCollection1.InsertGalleryImage("bosale_32x32.png", "images/business%20objects/bosale_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/business%20objects/bosale_32x32.png"), 5);
            this.imageCollection1.Images.SetKeyName(5, "bosale_32x32.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenNewTab,
            this.tsmiThuNho});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmiOpenNewTab
            // 
            this.tsmiOpenNewTab.Name = "tsmiOpenNewTab";
            this.tsmiOpenNewTab.Size = new System.Drawing.Size(179, 22);
            this.tsmiOpenNewTab.Text = "Mở trong trang mới";
            this.tsmiOpenNewTab.Click += new System.EventHandler(this.tsmiOpenNewTab_Click);
            // 
            // tsmiThuNho
            // 
            this.tsmiThuNho.Name = "tsmiThuNho";
            this.tsmiThuNho.Size = new System.Drawing.Size(179, 22);
            this.tsmiThuNho.Text = "Thu nhỏ";
            this.tsmiThuNho.Click += new System.EventHandler(this.tsmiThuNho_Click);
            // 
            // gcControl
            // 
            this.gcControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gcControl.AppearanceCaption.Options.UseFont = true;
            this.gcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcControl.Location = new System.Drawing.Point(190, 0);
            this.gcControl.Name = "gcControl";
            this.gcControl.Size = new System.Drawing.Size(714, 628);
            this.gcControl.TabIndex = 4;
            this.gcControl.Text = "groupControl1";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Danh Sách Thẻ Hết Hạn";
            this.navBarItem3.ImageOptions.SmallImageIndex = 3;
            this.navBarItem3.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.navBarItem3.Name = "navBarItem3";
            // 
            // xfmDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 628);
            this.Controls.Add(this.gcControl);
            this.Controls.Add(this.navBarControl1);
            this.Name = "xfmDictionary";
            this.Text = "Quản lý danh mục";
            this.Load += new System.EventHandler(this.xfmDictionary_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcControl)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitMultiLanguages()
        {
            //this.Text = MultiLanguages.GetString("tbl_Dictionary", "Dictionary", this.Text);
            //this.navEmployee.Caption = MultiLanguages.GetString("tbl_Dictionary", "DictionaryOfPersonnel", this.navEmployee.Caption);
            //this.navOrganization.Caption = MultiLanguages.GetString("tbl_Dictionary", "OrganizationalStructure", this.navOrganization.Caption);
            //this.navTimekeeping.Caption = MultiLanguages.GetString("tbl_Dictionary", "DictionaryOfTimekeeping", this.navTimekeeping.Caption);
            //this.navSalary.Caption = MultiLanguages.GetString("tbl_Dictionary", "DictionaryOfSalary", this.navSalary.Caption);
            //this.bbiPosition.Caption = MultiLanguages.GetString("tbl_Dictionary", "Position", this.bbiPosition.Caption);
            //this.bbiProfessional.Caption = MultiLanguages.GetString("tbl_Dictionary", "Profesional", this.bbiProfessional.Caption);
            //this.bbiDegree.Caption = MultiLanguages.GetString("tbl_Dictionary", "Degree", this.bbiDegree.Caption);
            //this.bbiJob.Caption = MultiLanguages.GetString("tbl_Dictionary", "Job", this.bbiJob.Caption);
            //this.bbiNationality.Caption = MultiLanguages.GetString("tbl_Dictionary", "Nationality", this.bbiNationality.Caption);
            //this.bbiEthnic.Caption = MultiLanguages.GetString("tbl_Dictionary", "Ethnic", this.bbiEthnic.Caption);
            //this.bbiReligion.Caption = MultiLanguages.GetString("tbl_Dictionary", "Religion", this.bbiReligion.Caption);
            //this.bbiRelative.Caption = MultiLanguages.GetString("tbl_Dictionary", "FamilyRelationships", this.bbiRelative.Caption);
            //this.bbiEducation.Caption = MultiLanguages.GetString("tbl_Dictionary", "Education", this.bbiEducation.Caption);
            //this.bbiLanguage.Caption = MultiLanguages.GetString("tbl_Dictionary", "Language", this.bbiLanguage.Caption);
            //this.bbiInformatic.Caption = MultiLanguages.GetString("tbl_Dictionary", "Informatic", this.bbiInformatic.Caption);
            //this.bbiSkill.Caption = MultiLanguages.GetString("tbl_Dictionary", "Skills", this.bbiSkill.Caption);
            //this.bbiSubsidiary.Caption = MultiLanguages.GetString("tbl_Dictionary", "Subsidiary", this.bbiSubsidiary.Caption);
            //this.bbiBranch.Caption = MultiLanguages.GetString("tbl_Dictionary", "Branch", this.bbiBranch.Caption);
            //this.bbiDepartment.Caption = MultiLanguages.GetString("tbl_Dictionary", "Department", this.bbiDepartment.Caption);
            //this.bbiGroup.Caption = MultiLanguages.GetString("tbl_Dictionary", "Group", this.bbiGroup.Caption);
            //this.bbiShift.Caption = MultiLanguages.GetString("tbl_Dictionary", "Shift", this.bbiShift.Caption);
            //this.bbiSymbol.Caption = MultiLanguages.GetString("tbl_Dictionary", "Symbol", this.bbiSymbol.Caption);
            //this.bbiMachine.Caption = MultiLanguages.GetString("tbl_Dictionary", "Machine", this.bbiMachine.Caption);
            //this.bbiRank.Caption = MultiLanguages.GetString("tbl_Dictionary", "Rank", this.bbiRank.Caption);
            //this.bbiStep.Caption = MultiLanguages.GetString("tbl_Dictionary", "Step", this.bbiStep.Caption);
            //this.bbiAllowance.Caption = MultiLanguages.GetString("tbl_Dictionary", "Allowance", this.bbiAllowance.Caption);
        }

        //private static string LoadStyle()
        //{
        //    DataSet set = new DataSet();
        //    set.ReadXml(Application.StartupPath + @"\Layout\Theme.xml");
        //    return set.Tables[0].Rows[0][1].ToString();
        //}

        public void SetStyle(string Style)
        {
            if (Style == "Classic")
            {
                //this.navBarControl1.SmallImages = this.imgClassic;
            }
            else
            {
                //this.navBarControl1.SmallImages = this.imgMetro;
            }
        }

        private void xfmDictionary_Load(object sender, EventArgs e)
        {
            //this.SetStyle(LoadStyle());
            this.Execute("xucPosition", "");
        }

        private void xfmDictionary_Load_1(object sender, EventArgs e)
        {
        }

        private void bbiSpecialty_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_ChuyenKhoa, ((NavBarItem)sender).Caption);
        }

        private void navBarControl1_MouseDown(object sender, MouseEventArgs e)
        {
            NavBarHitInfo info = this.navBarControl1.CalcHitInfo(new Point(e.X, e.Y));
            if (info.InLink)
                tsmiOpenNewTab.Enabled = true;
            else
                tsmiOpenNewTab.Enabled = false;
            
        }

        private void tsmiOpenNewTab_Click(object sender, EventArgs e)
        {
            //ExecuteNewTab(DictionaryModuleType.DIC_PhongBan, "");
        }

        private void tsmiThuNho_Click(object sender, EventArgs e)
        {
            if (navBarControl1.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
                navBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
            else
                navBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (navBarControl1.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
                tsmiThuNho.Text = "Phóng to";
            else
                tsmiThuNho.Text = "Thu nhỏ";
        }
    }
}

