namespace Vssoft.Dictionary
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraNavBar;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Vssoft.Common;
    using Vssoft.Data.Enum;


    public class frmDictionary : Form
    {
        #region Controls
        private NavBarItem bbiAllowance;
        private NavBarItem bbiNhaCungCap;
        private NavBarItem bbiDegree;
        private NavBarItem bbiDepartment;
        private NavBarItem bbiEducation;
        private NavBarItem bbiEthnic;
        private NavBarItem bbiGroup;
        private NavBarItem bbiGroupRate;
        private NavBarItem bbiHoliday;
        private NavBarItem bbiJob;
        private NavBarItem bbiTieuNhomDichvu;
        private NavBarItem bbiPatientObject;
        private NavBarItem bbiPosition;
        private NavBarItem bbiProduct;
        private NavBarItem bbiProductGroup;
        private NavBarItem bbiDIC_Hospital;
        private NavBarItem bbiRank;
        private NavBarItem bbiRate;
        private NavBarItem bbiICD10;
        private NavBarItem bbiDoiTuongBHYT;
        private NavBarItem bbiSalaryIncome;
        private NavBarItem bbiDichvu;
        private NavBarItem bbiState;
        private NavBarItem bbiStep;
        private NavBarItem bbiDUOC;
        private NavBarItem bbiNhomDichVu;
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
        private NavBarItem bbiSpecialty;
        private NavBarItem navBarItem3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiOpenNewTab;
        private ToolStripMenuItem tsmiThuNho;
        private NavBarItem ppiDIC_Province;
        private NavBarItem bbiDIC_Huyen;
        private NavBarItem bbiDIC_XaPhuong;
        private UI.Core.ucDIC_CANBO dic_canbo;
        private UI.Core.ucDIC_BENHVIEN dic_benhvien;
        private UI.Core.ucDIC_DANTOC dic_dantoc;
        private UI.Core.ucDIC_CHUYENKHOA dic_chuyenkhoa;
        private UI.Core.ucDIC_PHONGBAN dic_phongban;
        private UI.Core.ucDIC_DOITUONGBAOHIEM dic_doituongbhyt;
        private UI.Core.ucDIC_DTBN dic_doituongbenhnhan;
        //private UI.Core.duo dic_duongdung;
        private UI.Core.ucDIC_HUYEN dic_huyen;
        private UI.Core.ucDIC_TINHTHANH dic_tinhthanh;
        private UI.Core.ucDIC_XAPHUONG dic_xaphuong;
        private UI.Core.ucDIC_NGHENGHIEP dic_nghenghiep;
        private UI.Core.ucDIC_NHACUNGCAP dic_nhacungcap;
        private UI.Core.ucDIC_NHOMDICHVU dic_nhomdichvu;
        private UI.Core.ucDIC_TIEUNHOMDICHVU dic_tieunhomdichvu;
        private UI.Core.ucDIC_ICD10 dic_icd10;
        private UI.Core.ucDIC_DICHVU dic_dichvu;
        private UI.Core.ucDIC_DUOC dic_duoc;
        #endregion
        public frmDictionary()
        {
            this.InitializeComponent();
            this.InitMultiLanguages();
            base.Load += new EventHandler(this.xfmDictionary_Load);
        }

        private void bbiAllowance_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucAllowance", "");
        }

        private void bbiNhaCungCap_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_NHACUNGCAP, ((NavBarItem)sender).Caption);
        }

        private void bbiDegree_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_PHONGBAN, ((NavBarItem)sender).Caption);
        }

        private void bbiDepartment_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucDepartment", "");
        }

        private void bbiEducation_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            
        }

        private void bbiEthnic_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DANTOC, ((NavBarItem)sender).Caption);
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
            this.Execute(DictionaryModuleType.DIC_NGHENGHIEP, ((NavBarItem)sender).Caption);
        }

        private void bbiLanguage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucLanguage", "");
        }

        private void bbiTieuNhomDichvu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_TIEUNHOMDICHVU, ((NavBarItem)sender).Caption);
        }

        private void bbiPatientObject_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DOITUONGBENHNHAN, ((NavBarItem)sender).Caption);
        }

        private void bbiPosition_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_CANBO, ((NavBarItem)sender).Caption);
        }

        private void bbiProduct_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucProduct", "");
        }

        private void bbiProductGroup_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucProductGroup", "");
        }

        private void bbiDIC_Hospital_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_BENHVIEN, ((NavBarItem)sender).Caption);
        }

        private void bbiRank_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucRank", "");
        }

        private void bbiRate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute("xucRate", "");
        }

        private void bbiICD10_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_ICD10, ((NavBarItem)sender).Caption);
        }

        private void bbiDoiTuongBHYT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DOITUONGBHYT, ((NavBarItem)sender).Caption);
        }

        private void bbiDichvu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DICHVU, ((NavBarItem)sender).Caption);
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

        private void bbiDUOC_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_DUOC, ((NavBarItem)sender).Caption);
        }

        private void bbiNhomDichVu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_NHOMDICHVU, ((NavBarItem)sender).Caption);
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

            //this.gcControl.Text = "Demo";// this.bbiLanguage.Caption;
            //if (this.xucPosition != null)
            //{
            //    this.xucPosition.BringToFront();
            //}
            //this.xucPosition = new Perfect.Dictionary.xucPosition();
            //this.xucPosition.Dock = DockStyle.Fill;
            //this.gcControl.Controls.Add(this.xucPosition);
            //this.xucPosition.BringToFront();
        }

        private void Execute(DictionaryModuleType id, string caption)
        {
            this.gcControl.Parent.SuspendLayout();
            this.gcControl.SuspendLayout();
            this.gcControl.Text = caption;
            switch (id)
            {
                case DictionaryModuleType.DIC_CANBO:
                    if (this.dic_canbo != null)
                    {
                        this.dic_canbo.BringToFront();
                        break;
                    }
                    this.dic_canbo = new UI.Core.ucDIC_CANBO();
                    this.dic_canbo.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_canbo);
                    this.dic_canbo.BringToFront();
                    break;
                case DictionaryModuleType.DIC_DANTOC:
                    if (this.dic_dantoc != null)
                    {
                        this.dic_dantoc.BringToFront();
                        break;
                    }
                    this.dic_dantoc = new UI.Core.ucDIC_DANTOC();
                    this.dic_dantoc.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_dantoc);
                    this.dic_dantoc.BringToFront();
                    break;
                case DictionaryModuleType.DIC_CHUYENKHOA:
                    if (this.dic_chuyenkhoa != null)
                    {
                        this.dic_chuyenkhoa.BringToFront();
                        break;
                    }
                    this.dic_chuyenkhoa = new UI.Core.ucDIC_CHUYENKHOA();
                    this.dic_chuyenkhoa.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_chuyenkhoa);
                    this.dic_chuyenkhoa.BringToFront();
                    break;
                case DictionaryModuleType.DIC_PHONGBAN:
                    if (this.dic_phongban != null)
                    {
                        this.dic_phongban.BringToFront();
                        break;
                    }
                    this.dic_phongban = new UI.Core.ucDIC_PHONGBAN();
                    this.dic_phongban.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_phongban);
                    this.dic_phongban.BringToFront();
                    break;
                case DictionaryModuleType.DIC_DOITUONGBHYT:
                    if (this.dic_doituongbhyt != null)
                    {
                        this.dic_doituongbhyt.BringToFront();
                        break;
                    }
                    this.dic_doituongbhyt = new UI.Core.ucDIC_DOITUONGBAOHIEM();
                    this.dic_doituongbhyt.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_doituongbhyt);
                    this.dic_doituongbhyt.BringToFront();
                    break;
                case DictionaryModuleType.DIC_DOITUONGBENHNHAN:
                    if (this.dic_doituongbenhnhan != null)
                    {
                        this.dic_doituongbenhnhan.BringToFront();
                        break;
                    }
                    this.dic_doituongbenhnhan = new UI.Core.ucDIC_DTBN();
                    this.dic_doituongbenhnhan.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_doituongbenhnhan);
                    this.dic_doituongbenhnhan.BringToFront();
                    break;
                case DictionaryModuleType.DIC_DUONGDUNG:
                    break;
                case DictionaryModuleType.DIC_HUYEN:
                    if (this.dic_huyen != null)
                    {
                        this.dic_huyen.BringToFront();
                        break;
                    }
                    this.dic_huyen = new UI.Core.ucDIC_HUYEN();
                    this.dic_huyen.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_huyen);
                    this.dic_huyen.BringToFront();
                    break;
                case DictionaryModuleType.DIC_TINHTHANH:
                    if (this.dic_tinhthanh != null)
                    {
                        this.dic_tinhthanh.BringToFront();
                        break;
                    }
                    this.dic_tinhthanh = new UI.Core.ucDIC_TINHTHANH();
                    this.dic_tinhthanh.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_tinhthanh);
                    this.dic_tinhthanh.BringToFront();
                    break;
                case DictionaryModuleType.DIC_XAPHUONG:
                    if (this.dic_xaphuong != null)
                    {
                        this.dic_xaphuong.BringToFront();
                        break;
                    }
                    this.dic_xaphuong = new UI.Core.ucDIC_XAPHUONG();
                    this.dic_xaphuong.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_xaphuong);
                    this.dic_xaphuong.BringToFront();
                    break;
                case DictionaryModuleType.DIC_NGHENGHIEP:
                    if (this.dic_nghenghiep != null)
                    {
                        this.dic_nghenghiep.BringToFront();
                        break;
                    }
                    this.dic_nghenghiep = new UI.Core.ucDIC_NGHENGHIEP();
                    this.dic_nghenghiep.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_nghenghiep);
                    this.dic_nghenghiep.BringToFront();
                    break;
                case DictionaryModuleType.DIC_NHACUNGCAP:
                    if (this.dic_nhacungcap != null)
                    {
                        this.dic_nhacungcap.BringToFront();
                        break;
                    }
                    this.dic_nhacungcap = new UI.Core.ucDIC_NHACUNGCAP();
                    this.dic_nhacungcap.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_nhacungcap);
                    this.dic_nhacungcap.BringToFront();
                    break;
                case DictionaryModuleType.DIC_NHOMDICHVU:
                    if (this.dic_nhomdichvu != null)
                    {
                        this.dic_nhomdichvu.BringToFront();
                        break;
                    }
                    this.dic_nhomdichvu = new UI.Core.ucDIC_NHOMDICHVU();
                    this.dic_nhomdichvu.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_nhomdichvu);
                    this.dic_nhomdichvu.BringToFront();
                    break;
                case DictionaryModuleType.DIC_TIEUNHOMDICHVU:
                    if (this.dic_tieunhomdichvu != null)
                    {
                        this.dic_tieunhomdichvu.BringToFront();
                        break;
                    }
                    this.dic_tieunhomdichvu = new UI.Core.ucDIC_TIEUNHOMDICHVU();
                    this.dic_tieunhomdichvu.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_tieunhomdichvu);
                    this.dic_tieunhomdichvu.BringToFront();
                    break;
                case DictionaryModuleType.DIC_BENHVIEN:
                    if (this.dic_benhvien != null)
                    {
                        this.dic_benhvien.BringToFront();
                        break;
                    }
                    this.dic_benhvien = new UI.Core.ucDIC_BENHVIEN();
                    this.dic_benhvien.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_benhvien);
                    this.dic_benhvien.BringToFront();
                    break;
                case DictionaryModuleType.DIC_ICD10:
                    if (this.dic_icd10 != null)
                    {
                        this.dic_icd10.BringToFront();
                        break;
                    }
                    this.dic_icd10 = new UI.Core.ucDIC_ICD10();
                    this.dic_icd10.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_icd10);
                    this.dic_icd10.BringToFront();
                    break;
                case DictionaryModuleType.DIC_DICHVU:
                    if (this.dic_dichvu != null)
                    {
                        this.dic_dichvu.BringToFront();
                        break;
                    }
                    this.dic_dichvu = new UI.Core.ucDIC_DICHVU();
                    this.dic_dichvu.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_dichvu);
                    this.dic_dichvu.BringToFront();
                    break;
                case DictionaryModuleType.DIC_DUOC:
                    if (this.dic_duoc != null)
                    {
                        this.dic_duoc.BringToFront();
                        break;
                    }
                    this.dic_duoc = new UI.Core.ucDIC_DUOC();
                    this.dic_duoc.Dock = DockStyle.Fill;
                    this.gcControl.Controls.Add(this.dic_duoc);
                    this.dic_duoc.BringToFront();
                    break;
                default:
                    break;
            }
            this.gcControl.Parent.ResumeLayout();
            this.gcControl.ResumeLayout();
            MainFormHelper.CompactCurrentProcessWorkingSet();

        }
        private void ExecuteNewTab(DictionaryModuleType id, string caption)
        {
            //Form frmNewTab = new Form();
            //ucBaseBasicView view;
            //switch (id)
            //{
            //    case DictionaryModuleType.DIC_CANBO:
            //        view = new UI.Core.ucDIC_CANBO();
            //        break;
            //    case DictionaryModuleType.DIC_DANTOC:
            //        view = new UI.Core.ucDIC_DANTOC();
            //        break;
            //    case DictionaryModuleType.DIC_CHUYENKHOA:
            //        view = new UI.Core.ucDIC_CHUYENKHOA();
            //        break;
            //    case DictionaryModuleType.DIC_PHONGBAN:
            //        view = new UI.Core.ucDIC_PHONGBAN();
            //        break;
            //    default:view = new ucBaseBasicView();
            //        break;
            //}
            //view.Dock = DockStyle.Fill;
            //frmNewTab.Controls.Add(this.dic_ModuleControl);
            //view.BringToFront();
            //frmNewTab.WindowState = FormWindowState.Maximized;
            //IFormMain ribbonForm = (IFormMain)this.MdiParent;
            //ribbonForm.OpenFormNewTab(frmNewTab);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDictionary));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navTimekeeping = new DevExpress.XtraNavBar.NavBarGroup();
            this.bbiDichvu = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiNhomDichVu = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiTieuNhomDichvu = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiHoliday = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navEmployee = new DevExpress.XtraNavBar.NavBarGroup();
            this.bbiPosition = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDIC_Hospital = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDegree = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiJob = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiPatientObject = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiEthnic = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDoiTuongBHYT = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiICD10 = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiEducation = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiSpecialty = new DevExpress.XtraNavBar.NavBarItem();
            this.ppiDIC_Province = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDIC_Huyen = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDIC_XaPhuong = new DevExpress.XtraNavBar.NavBarItem();
            this.navOrganization = new DevExpress.XtraNavBar.NavBarGroup();
            this.bbiDUOC = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiNhaCungCap = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiDepartment = new DevExpress.XtraNavBar.NavBarItem();
            this.bbiGroup = new DevExpress.XtraNavBar.NavBarItem();
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
            this.navBarControl1.ActiveGroup = this.navOrganization;
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
            this.bbiDIC_Hospital,
            this.bbiEthnic,
            this.bbiEducation,
            this.bbiPatientObject,
            this.bbiDoiTuongBHYT,
            this.bbiJob,
            this.bbiDichvu,
            this.bbiDegree,
            this.bbiICD10,
            this.bbiRank,
            this.bbiStep,
            this.bbiNhaCungCap,
            this.bbiDepartment,
            this.bbiGroup,
            this.bbiAllowance,
            this.bbiNhomDichVu,
            this.bbiTieuNhomDichvu,
            this.bbiRate,
            this.bbiGroupRate,
            this.bbiUnit,
            this.bbiProductGroup,
            this.bbiProduct,
            this.bbiState,
            this.bbiHoliday,
            this.bbiDUOC,
            this.bbiSalaryIncome,
            this.navBarItem1,
            this.navBarItem2,
            this.bbiSpecialty,
            this.ppiDIC_Province,
            this.bbiDIC_Huyen,
            this.bbiDIC_XaPhuong});
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
            // navTimekeeping
            // 
            this.navTimekeeping.Caption = "Nhóm Dịch Vụ";
            this.navTimekeeping.ImageOptions.LargeImageIndex = 2;
            this.navTimekeeping.ImageOptions.SmallImageIndex = 1;
            this.navTimekeeping.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDichvu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiNhomDichVu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiTieuNhomDichvu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiHoliday),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navTimekeeping.Name = "navTimekeeping";
            // 
            // bbiDichvu
            // 
            this.bbiDichvu.Caption = "Dịch Vụ";
            this.bbiDichvu.ImageOptions.SmallImageIndex = 5;
            this.bbiDichvu.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDichvu.Name = "bbiDichvu";
            this.bbiDichvu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDichvu_LinkClicked);
            // 
            // bbiNhomDichVu
            // 
            this.bbiNhomDichVu.Caption = "Nhóm Dịch Vụ";
            this.bbiNhomDichVu.ImageOptions.SmallImageIndex = 5;
            this.bbiNhomDichVu.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiNhomDichVu.Name = "bbiNhomDichVu";
            this.bbiNhomDichVu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiNhomDichVu_LinkClicked);
            // 
            // bbiTieuNhomDichvu
            // 
            this.bbiTieuNhomDichvu.Caption = "Tiểu Nhóm Dịch Vụ";
            this.bbiTieuNhomDichvu.ImageOptions.SmallImageIndex = 5;
            this.bbiTieuNhomDichvu.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiTieuNhomDichvu.Name = "bbiTieuNhomDichvu";
            this.bbiTieuNhomDichvu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiTieuNhomDichvu_LinkClicked);
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
            // navEmployee
            // 
            this.navEmployee.Caption = "Danh Mục Hành Chính";
            this.navEmployee.ImageOptions.LargeImageIndex = 0;
            this.navEmployee.ImageOptions.LargeImageSize = new System.Drawing.Size(32, 32);
            this.navEmployee.ImageOptions.SmallImageIndex = 0;
            this.navEmployee.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiPosition),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDIC_Hospital),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDegree),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiJob),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiPatientObject),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiEthnic),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDoiTuongBHYT),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiICD10),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiEducation),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiSpecialty),
            new DevExpress.XtraNavBar.NavBarItemLink(this.ppiDIC_Province),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDIC_Huyen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDIC_XaPhuong)});
            this.navEmployee.Name = "navEmployee";
            this.navEmployee.TopVisibleLinkIndex = 3;
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
            // bbiDIC_Hospital
            // 
            this.bbiDIC_Hospital.Caption = "Bệnh Viện";
            this.bbiDIC_Hospital.ImageOptions.SmallImageIndex = 3;
            this.bbiDIC_Hospital.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDIC_Hospital.Name = "bbiDIC_Hospital";
            this.bbiDIC_Hospital.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDIC_Hospital_LinkClicked);
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
            // bbiICD10
            // 
            this.bbiICD10.Caption = "Mã ICD";
            this.bbiICD10.ImageOptions.SmallImageIndex = 3;
            this.bbiICD10.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiICD10.Name = "bbiICD10";
            this.bbiICD10.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiICD10_LinkClicked);
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
            // ppiDIC_Province
            // 
            this.ppiDIC_Province.Caption = "Tỉnh/Thành";
            this.ppiDIC_Province.ImageOptions.SmallImageIndex = 3;
            this.ppiDIC_Province.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.ppiDIC_Province.Name = "ppiDIC_Province";
            toolTipTitleItem1.Text = "Danh Mục Tỉnh Thành";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.ppiDIC_Province.SuperTip = superToolTip1;
            this.ppiDIC_Province.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ppiDIC_Province_LinkClicked);
            // 
            // bbiDIC_Huyen
            // 
            this.bbiDIC_Huyen.Caption = "Huyện/Thị Xã";
            this.bbiDIC_Huyen.ImageOptions.SmallImageIndex = 3;
            this.bbiDIC_Huyen.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDIC_Huyen.Name = "bbiDIC_Huyen";
            this.bbiDIC_Huyen.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDIC_Huyen_LinkClicked);
            // 
            // bbiDIC_XaPhuong
            // 
            this.bbiDIC_XaPhuong.Caption = "Xã/Phường";
            this.bbiDIC_XaPhuong.ImageOptions.SmallImageIndex = 3;
            this.bbiDIC_XaPhuong.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDIC_XaPhuong.Name = "bbiDIC_XaPhuong";
            this.bbiDIC_XaPhuong.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDIC_XaPhuong_LinkClicked);
            // 
            // navOrganization
            // 
            this.navOrganization.Caption = "Nhóm Dược";
            this.navOrganization.Expanded = true;
            this.navOrganization.ImageOptions.LargeImageIndex = 1;
            this.navOrganization.ImageOptions.SmallImageIndex = 2;
            this.navOrganization.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDUOC),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiNhaCungCap),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiDepartment),
            new DevExpress.XtraNavBar.NavBarItemLink(this.bbiGroup)});
            this.navOrganization.Name = "navOrganization";
            // 
            // bbiDUOC
            // 
            this.bbiDUOC.Caption = "Dược";
            this.bbiDUOC.ImageOptions.SmallImageIndex = 4;
            this.bbiDUOC.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiDUOC.Name = "bbiDUOC";
            this.bbiDUOC.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiDUOC_LinkClicked);
            // 
            // bbiNhaCungCap
            // 
            this.bbiNhaCungCap.Caption = "Nhà Cung Cấp";
            this.bbiNhaCungCap.ImageOptions.SmallImageIndex = 4;
            this.bbiNhaCungCap.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.bbiNhaCungCap.Name = "bbiNhaCungCap";
            this.bbiNhaCungCap.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bbiNhaCungCap_LinkClicked);
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
            this.gcControl.Text = "Danh mục hệ thống";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "Danh Sách Thẻ Hết Hạn";
            this.navBarItem3.ImageOptions.SmallImageIndex = 3;
            this.navBarItem3.ImageOptions.SmallImageSize = new System.Drawing.Size(24, 24);
            this.navBarItem3.Name = "navBarItem3";
            // 
            // frmDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 628);
            this.Controls.Add(this.gcControl);
            this.Controls.Add(this.navBarControl1);
            this.Name = "frmDictionary";
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
            this.Execute(DictionaryModuleType.DIC_CHUYENKHOA, ((NavBarItem)sender).Caption);
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

        private void ppiDIC_Province_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_TINHTHANH, ((NavBarItem)sender).Caption);
        }

        private void bbiDIC_Huyen_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_HUYEN, ((NavBarItem)sender).Caption);
        }

        private void bbiDIC_XaPhuong_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.Execute(DictionaryModuleType.DIC_XAPHUONG, ((NavBarItem)sender).Caption);
        }
    }
}

