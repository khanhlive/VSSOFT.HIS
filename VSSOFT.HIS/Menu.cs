using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLBV;
using System.IO;
using DevExpress.XtraBars;
using System.Threading;
using QLBV.FormNhap;
using QLBV.FormDanhMuc;

namespace QLBV
{
    public partial class Menu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Menu()
        {
            InitializeComponent();

        }
         public string MaCB = DungChung.Bien.MaCB;
         string LoaiPM = DungChung.Bien.LoaiPM;
         void frm_OnGoBack(object sender)
         {
             this.Close();
             frmDangNhap frm = (frmDangNhap)sender;
             frm.Close();
             frm.Dispose();
         }
         QLBVEntities data = new QLBVEntities(DungChung.Bien.StrCon);
        public void Menu_Load(object sender, EventArgs e)
        {
              
            bool _load = true;
            data = new QLBVEntities(DungChung.Bien.StrCon);
            //if (DungChung.Bien.MaTinh == "12" ||)
                barTTTuDong.Enabled = true;
        CLS.frm_filePath_LIS._getConnect();
            DungChung.Bien.c_chuyenkhoa.f_ChuyenKhoa();
            DateTime ngayhethan = System.DateTime.Now;
            TimeSpan songay = DungChung.Bien.NgayKichHoat - ngayhethan;
            int ngay = songay.Days + 3650;
            if (ngay <= 0)
            {
                MessageBox.Show("Hạn bảo trì đã hết!\n Vui lòng liên hệ 'VSSoft' để tiếp tục sử dụng!\n Điện thoại: 046.672.3636");
                _load = false;
            }
            else
            {
                if (ngay <= 10 && ngay > 0)
                {
                    MessageBox.Show("Số ngày sử dụng của bạn còn: " + ngay + " ngày.\n Liên hệ 'VSSoft' để được trợ giúp.\n Điện thoại: 046.672.3636");
                }
            }
          
                var q = (from Admin in data.ADMINs.Where(p => p.TenDN==DungChung.Bien.TenDN) select Admin).ToList();
                if (q.Count > 0)
                {
                    txtDN.EditValue = "Xin chào: " + q.ToList().First().TenGoi.ToString();
                    //DungChung.Bien.TenDN = q.ToList().First().TenDN;
                }
               
              DungChung.Ham._set_dtBHYT();
            if(_load)
            switch (LoaiPM)
            {
                case "QLBV":
                    CLS.frm_filePath_LIS.GetConnect_LisFolder();
                    this.Text = DungChung.Bien.TenCQ.ToUpper() + " - " + DungChung.Bien.MaBV + " - " + " *** PHẦN MỀM QUẢN LÝ TỔNG THỂ BỆNH VIỆN - VSSOFT.HOSPITAL 2015 ... cập nhật: " + DungChung.Bien.ngayCNhat + DungChung.Bien._test;
                    //frmDangNhap frm = new frmDangNhap();
                    ////frm.OnGoBack += new frmDangNhap.GoBackForm1(frm_OnGoBack);
                    //frm.ShowDialog();
                    //this.Hide();
                    if (DungChung.Bien.CapDo == 9 || DungChung.Bien.CapDo == 8)
                    {
                        ribbonHoTro.Visible = true;
                        ribbonHt.Visible = true;
                        ribbonLinhHCVTYT.Visible = true;
                        barUpdate.Enabled = true;
                        //ribbonHt.Enabled = true;
                        ribbonBHYT.Visible = true;
                        ribbonBcBHYT.Visible = true;
                        ribbonDmHC.Visible = true;//
                        ribbonQLBN.Visible = true;//
                        ribbonBcKhoaDuoc.Visible = true;//
                        ribbonDMDuoc.Visible = true;//
                        ribbonQuanLyDuoc.Visible = true;//
                        ribbonDieuTri.Visible = true;//
                        barBtnDieuTri.Enabled = true;
                        barKhamBenh.Enabled = true;
                        ribbonCanLamSang.Visible = true;//
                        ribbonBcThongKe.Visible = true;//
                        ribbonVienPhi.Visible = true;//
                        ribbonBcVP.Visible = true;//
                        ribbonDmVP.Visible = true;
                        ribbonAdmin.Visible = true;
                        ribbonKhamBenh.Visible = true;
                        ribbonBHYT.Visible = true;
                        ribbonBcBHYT.Visible = true;
                        ribbonKeHoachTongHop.Visible = true;
                    }
                    string ploai = "";
                    var _ploai = (from d in data.KPhongs.Where(p => p.MaKP== (DungChung.Bien.MaKP)) select d).ToList();
                    if (_ploai.Count > 0)
                    {
                        ploai = _ploai.First().PLoai;
                        if(_ploai.First().ChuyenKhoa!=null)
                        DungChung.Bien.ChuyenKhoa = _ploai.First().ChuyenKhoa;
                        int td = 0;
                        if (_ploai.First().TrongBV != null)
                        td = _ploai.First().TrongBV.Value;
                        switch(td){
                            case 0:
                                DungChung.Bien._tuyenduoi = 1;
                                break;
                            case 1:
                                DungChung.Bien._tuyenduoi = 0;
                                break;
                            case 2:
                                DungChung.Bien._tuyenduoi = 2;
                                break;
                                }
                    }
                    DungChung.Bien.PLoaiKP = ploai;
                    
                    ribbonHoTro.Visible = false;
                    switch (ploai)
                    {
                        case "Khoa dược":
                            ribbonHoTro.Visible = true;
                            ribbonBcKhoaDuoc.Visible = true;
                            ribbonDMDuoc.Visible = true;
                            ribbonQuanLyDuoc.Visible = true;
                            ribbonLinhHCVTYT.Visible = true;
                            break;
                        case "Lâm sàng":
                            ribbonHoTro.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonLinhHCVTYT.Visible = true;
                            ribbonDieuTri.Visible = true;
                            //ribbonQLBN.Visible = true;
                            if (DungChung.Bien.CapDo == 2)
                            {
                                ribbonQLBN.Visible = true;
                                //ribbonBcThongKe.Enabled = true;
                            }
                            if (DungChung.Bien.CapDo == 3) 
                            {
                                ribbonQLBN.Visible = true;
                                ribbonKhamBenh.Visible = true;
                            }
                            break;
                        case  "Trực cấp cứu":
                               ribbonHoTro.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonLinhHCVTYT.Visible = true;
                            ribbonDieuTri.Visible = true;
                            //ribbonQLBN.Visible = true;
                         
                            if (DungChung.Bien.CapDo == 3) {
                                ribbonQLBN.Visible = true;
                                ribbonKhamBenh.Visible = true;
                            }
                            break;
                        case "Phòng khám":
                            ribbonHoTro.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonLinhHCVTYT.Visible = true;
                            ribbonKhamBenh.Visible = true;
                            if (DungChung.Bien.CapDo == 2)
                            {
                                ribbonQLBN.Visible = true;
                                //ribbonBcThongKe.Enabled = true;
                            }
                            if (DungChung.Bien.CapDo == 3)
                            {
                                ribbonQLBN.Visible = true;
                                ribbonDieuTri.Visible = true;
                                //ribbonBcThongKe.Enabled = true;
                            }
                            break;
                        case "Cận lâm sàng":
                            ribbonHoTro.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonLinhHCVTYT.Visible = true;
                            ribbonCanLamSang.Visible = true;
                            ribbonBcVP.Visible = true;
                            var PL = data.KPhongs.Where(p => p.MaKP== (DungChung.Bien.MaKP)).Select(p => p.ChuyenKhoa).ToList();
                            if (PL.Count > 0 && PL.First().ToString() == "Xét nghiệm")
                                barCDHA.Enabled = false;
                            else
                                barCanLamSang.Enabled = false;
                            break;
                        case "chức năng":
                            ribbonHoTro.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonDmHC.Visible = true;
                            ribbonKeHoachTongHop.Visible = true;
                            break;
                        case "Hành chính":
                            ribbonHoTro.Visible = true;
                            ribbonQLBN.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonDmHC.Visible = true;
                            //ribbonDmVP.Enabled = true;
                            break;
                        case "Kế toán":
                            ribbonHoTro.Visible = true;
                            ribbonVienPhi.Visible = true;
                            ribbonBcVP.Visible = true;
                            ribbonDmVP.Visible = true;
                            ribbonNhomVPCN.Visible = true;
                            ribbonBcBHYT.Visible = true;
                            ribbonBHYT.Visible = true;
                            if(DungChung.Bien.CapDo==2)
                                 ribbonQLBN.Visible = true;
                            break;
                        case "BHXH":
                            ribbonHoTro.Visible = true;
                            ribbonBHYT.Visible = true;
                            ribbonBcBHYT.Visible = true;
                            break;
                        case "Admin":
                            ribbonLinhHCVTYT.Visible = true;
                            ribbonBHYT.Visible = true;
                            ribbonBcBHYT.Visible = true;
                            ribbonHt.Visible = true;
                            ribbonDmHC.Visible = true;
                            ribbonQLBN.Visible = true;
                            ribbonBcKhoaDuoc.Visible = true;
                            ribbonDMDuoc.Visible = true;
                            ribbonQuanLyDuoc.Visible = true;
                            ribbonDieuTri.Visible = true;
                            ribbonCanLamSang.Visible = true;
                            ribbonBcThongKe.Visible = true;
                            ribbonVienPhi.Visible = true;
                            ribbonBcVP.Visible = true;
                            ribbonDmVP.Visible = true;
                            ribbonNhomVPCN.Visible = true;
                            ribbonHoTro.Visible = true;
                            break;
                    }
                    
                    if (DungChung.Bien.MaCB == "admin")
                    {
                        ribbonHt.Visible = true;
                        //ribbonDmHC.Visible = true;//
                        //ribbonAdmin.Visible = true;
                    }
                   
                    if (DungChung.Bien.MaBV == "06007") 
                    {
                        ribbonBcVP.Visible = true;
                    }
                    QLBVEntities _data=new QLBVEntities(DungChung.Bien.StrCon);
                    var perm = _data.Permissions.Where(p => p.TenDN == DungChung.Bien.TenDN).ToList();
                    if(perm.Where(p=>p.ID == 9041 || p.ID==9042 || p.ID==9043 ).ToList().Count>0){
                        ribbonVienPhi.Visible = true;//
                    }
                    if (perm.Where(p => p.ID == 906).ToList().Count > 0)
                        bar_duyet_gui.Enabled = true;
                    if (perm.Where(p => p.ID == 907).ToList().Count > 0)
                        barDM_DTBN.Enabled = true;
                    if (perm.Where(p => p.ID == 908).ToList().Count > 0)
                        barBenhAn.Enabled = true;
                    if (perm.Where(p => p.ID == 909).ToList().Count > 0)
                    {
                        ribbonDieuTri.Visible = true;
                        barBtnDieuTri.Enabled = true;
                    }
                           panDetail.Controls.Clear();
                    QLBV.FormNhap.UC_dashboard frm1 = new FormNhap.UC_dashboard();
                    frm1.Dock = System.Windows.Forms.DockStyle.Fill;
                    panDetail.Controls.Add(frm1);
                
                    break;
                case "QLDC":

                     this.Text =DungChung.Bien.TenCQ.ToUpper()+ " ***  PHẦN MỀM QUẢN LÝ DƯỢC - VSSOFT.HOSPITAL 2014 ... cập nhật: " + DungChung.Bien.ngayCNhat;
                    //frmDangNhap frm = new frmDangNhap();
                    ////frm.OnGoBack += new frmDangNhap.GoBackForm1(frm_OnGoBack);
                    //frm.ShowDialog();
                    //this.Hide();
                     ribbonHoTro.Visible = true;
                         ribbonBcKhoaDuoc.Visible = true;
                            ribbonDMDuoc.Visible = true;
                            ribbonQuanLyDuoc.Visible = true;
                            ribbonHt.Visible = true;
                            ribbonDmHC.Visible = false;
                            ribbonQLBN.Visible = false;
                            ribbonDieuTri.Visible = false;
                            ribbonCanLamSang.Visible = false;
                            ribbonBcThongKe.Visible = false;
                            ribbonVienPhi.Visible = false;
                            ribbonBcVP.Visible = false;
                            ribbonDmVP.Enabled = true;
                            barDanhMucDV.Enabled = false;
                            barXuatNgoaiTru.Enabled = false;
                            barXuatNoiTru.Enabled = false;
                            ribbonBHYT.Visible = false;
                            ribbonNhomVP.Visible = false;
                            // nhóm hành chính
                            ribbonDmHC.Visible = true;
                            DanhMucICD.Enabled = false;
                            DanhMucDT.Enabled = false;
                            barDTBH.Enabled = false;
                            barDmKP.Enabled = true;
                            barDMBV.Enabled = false;
                                ribbonAdmin.Visible=true;

                    
                    if (DungChung.Bien.CapDo == 9 || DungChung.Bien.CapDo == 8)
                    {
                        // nhóm hành chính
                        ribbonHoTro.Visible = true;
                        ribbonDmHC.Visible = true;
                        DanhMucICD.Enabled=false;
                            DanhMucDT.Enabled=false;
                            barDTBH.Enabled = false;
                        barDmKP.Enabled = true;
                        
                        //ribbonHt.Enabled = true;
                        //ribbonDmHC.Enabled = true;//
                        //ribbonQLBN.Enabled = true;//
                        //ribbonBcKhoaDuoc.Enabled = true;//
                        //ribbonDMDuoc.Enabled = true;//
                        //ribbonQuanLyDuoc.Enabled = true;//
                        //ribbonKhamChuaBenh.Enabled = true;//
                        ////ribbonCanLamSang.Enabled = true;//
                        //ribbonBcThongKe.Enabled = true;//
                        //ribbonVienPhi.Enabled = true;//
                        //ribbonBcVP.Enabled = true;//
                        //ribbonDmVP.Enabled = true;
                        //ribbonAdmin.Enabled = true;
                    }
                    if (DungChung.Bien.MaCB == "admin")
                    {
                        //ribbonHt.Enabled = true;
                        ribbonDmHC.Enabled = true;//
                        ribbonAdmin.Enabled = true;
                    }
                    
                    ////Tạo skin cho giao dien( kiem tra lai)
                    //string fileName = Application.StartupPath + "\\Skins.txt"; // tao file txt de chua thong tin ve viec luu skins

                    //if (File.Exists(fileName) == false) // neu file txt chua ton tai thi tao ra file
                    //    Giaodien.LookAndFeel.SetSkinStyle("Blueprint");
                    //else // nguoc lai, neu co roi thi doc file txt do len
                    //{
                    //    StreamReader sr = new StreamReader(fileName, false);
                    //    Giaodien.LookAndFeel.SetSkinStyle(sr.ReadLine());
                    //    sr.Close();
                    //}
                    //// 
             panDetail.Controls.Clear();
                    QLBV.Giaodien.us_AnhNen frm = new QLBV.Giaodien.us_AnhNen();
                    frm.Dock = System.Windows.Forms.DockStyle.Fill;
                    panDetail.Controls.Add(frm);
                    break;
                case "QLVP":
                    ribbonVienPhi.Visible = true;
                            ribbonBcVP.Visible = true;
                            ribbonDmVP.Visible = true;
                    ribbonNhomVPCN.Visible = true;
                    break;
            }
            Thread t = new Thread(ThreadStart => { DungChung.Ham._openApp("", "QLBV_STT.exe"); });
            t.Start();
            //Point pt = this.Location;
            //pt.Offset(this.Width / 2, this.Height / 2);
            //radialMenu1.ShowPopup(pt);
        }
     

        void MoFormLen<T>() where T : UserControl ,new ()
        {
           T frm = new T();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void HSBN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (DungChung.Bien.CoTheChuyen ==  true)
            //{
                panDetail.Controls.Clear();
                QLBV.FormNhap.frmHSBN frm = new FormNhap.frmHSBN();
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                panDetail.Controls.Add(frm);
               
            //}                                                                                                                                                                                                                                                                                                                                                                       
            
        }

        private void ThietLapHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormThamSo.us_hethong frm = new QLBV.FormThamSo.us_hethong();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barKhamBenh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.usKhamBenh frm = new FormNhap.usKhamBenh();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void DanhMucDuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool kt = true;
            if (DungChung.Bien.MaBV == "12001")
            {
                kt = DungChung.Ham.checkQuyenFalse("us_dmDuoc")[3];
                if (kt)
                {
                    panDetail.Controls.Clear();
                    QLBV.FormDanhMuc.us_dmDuoc frm = new FormDanhMuc.us_dmDuoc();
                    frm.Dock = System.Windows.Forms.DockStyle.Fill;
                    panDetail.Controls.Add(frm);
                }
                else
                    MessageBox.Show("Bạn chưa được cấp quyền vào danh mục dược ! \nLiên hệ với admin để được cấp quyền");
            }
            else
            {
                panDetail.Controls.Clear();
                QLBV.FormDanhMuc.us_dmDuoc frm = new FormDanhMuc.us_dmDuoc();
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                panDetail.Controls.Add(frm);
            }
           
        }

        private void barDSCB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.NhapCanBo frm = new FormDanhMuc.NhapCanBo();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (DungChung.Bien.CoTheChuyen == true)
            //{
            //    panDetail.Controls.Clear();

            //    MoFormLen<QLBV.FormNhap.usNhapDuoc>();
            //}
            //else 
            //{

            //    MessageBox.Show("Bạn còn dữ liệu chưa lưu");
            //}
                panDetail.Controls.Clear();

                MoFormLen<QLBV.FormNhap.usNhapDuoc>();
          
        }

        private void DanhMucDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool kt = true;
            if (DungChung.Bien.MaBV == "12001")
            {
                kt = DungChung.Ham.checkQuyenFalse("usDichVu")[3];
                if(kt)
                {
                    panDetail.Controls.Clear();
                    MoFormLen<QLBV.FormDanhMuc.usDichVu>();
                }
                else
                    MessageBox.Show("Bạn chưa được cấp quyền vào danh mục dịch vụ ! \nLiên hệ với admin để được cấp quyền");      
            }
            else
            {
                panDetail.Controls.Clear();
                MoFormLen<QLBV.FormDanhMuc.usDichVu>();
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //string skins = Giaodien.LookAndFeel.SkinName;
            //string fileName = Application.StartupPath + "\\Skins.txt";
            //StreamWriter sw = new StreamWriter(fileName, false);
            //sw.WriteLine(skins);
            //sw.Close();
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
                DungChung.Ham._closeApp("QLBV_STT");

    


        }

        private void barBtnDieuTri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.usDieuTri frm = new FormNhap.usDieuTri();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.usXuatNgoaiTru frm = new FormNhap.usXuatNgoaiTru();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            panDetail.Controls.Clear();
            QLBV.FormNhap.usTamThu_TToan frm = new FormNhap.usTamThu_TToan();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barTToan_TThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.usTamThu_TToan frm = new FormNhap.usTamThu_TToan();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void DanhMucKP_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.usDSKhoaPhong frm = new FormDanhMuc.usDSKhoaPhong();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.usAdmin frm = new FormDanhMuc.usAdmin();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barCanLamSang_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormThamSo.frm_kqcls frm = new FormThamSo.frm_kqcls();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void bar79act_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frm_rep79aCT frm = new FormThamSo.frm_rep79aCT();
            frm.ShowDialog();
        }

      

        private void bar14a_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FormThamSo.frm_14a frm = new FormThamSo.frm_14a();
            //frm.ShowDialog();
        }

        private void bar14b_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("Viện phí");
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }


        private void bar20BHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBcMau20 frm = new FormThamSo.frmTsBcMau20();
            frm.ShowDialog();
        }

        private void bar21BHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBcMau21BHYT frm = new FormThamSo.frmTsBcMau21BHYT();
            frm.ShowDialog();
        }

        private void DanhMucDT_ItemClick(object sender, ItemClickEventArgs e)
        {

            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.us_dmDanToc frm = new FormDanhMuc.us_dmDanToc();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void DanhMucNhaCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.us_dmNhaCungCap frm = new FormDanhMuc.us_dmNhaCungCap();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
        public void closeForm()
        {
            this.Dispose();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barXuatDuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.usXuatDuoc frm = new FormNhap.usXuatDuoc();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barNXT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBCNXT frm = new FormThamSo.frmTsBCNXT();
            frm.ShowDialog();
        }

        private void bar79b_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frm_rep79aTH frm = new FormThamSo.frm_rep79aTH();
            frm.ShowDialog();
        }


        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frm_thongkecanbophongkham frm = new FormThamSo.frm_thongkecanbophongkham();
            frm.ShowDialog();
        }

        private void barNhomDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormDanhMuc.us_dmNhomDV frm = new FormDanhMuc.us_dmNhomDV();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void DanhMucICD_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormDanhMuc.us_dmICD10 frm = new FormDanhMuc.us_dmICD10();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barDsBNxuatduoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("Khoa dược");
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barGiaThuocUTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_chonxuatduoc frm = new FormThamSo.us_chonxuatduoc();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barHuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormNhap.us_HuHao frm = new FormNhap.us_HuHao();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barKiemKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormNhap.us_KiemKe frm = new FormNhap.us_KiemKe();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barBcXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBcNXTXuat frm = new FormThamSo.frmTsBcNXTXuat();
            frm.ShowDialog();
        }

        private void barTkBNtheoChuyenKhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barTkBNtheothang_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBcNoiTruThangth frm = new FormThamSo.frmTsBcNoiTruThangth();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBcNoiTruThangct frm = new FormThamSo.frmTsBcNoiTruThangct();
            frm.ShowDialog();
        }

        private void barBcNXTrutgon_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBcNXTrutgon frm = new FormThamSo.frmTsBcNXTrutgon();
            frm.ShowDialog();
        }

        private void barSuDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormNhap.us_SuDung frm = new FormNhap.us_SuDung();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

   

        private void barBcSDthuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            //cauvithao
            //FormThamSo.frmTsBcSuDungThuoc frm = new FormThamSo.frmTsBcSuDungThuoc();
            //frm.ShowDialog();
        }

        private void barthuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frmTsBbKKThuoc frm = new FormThamSo.frmTsBbKKThuoc();
            frm.ShowDialog();
        }

      

        private void barXuatNoiTru_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormNhap.usXuatNoiTru frm = new FormNhap.usXuatNoiTru();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("Tổng hợp");
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormNhap.frm_LinhKhoa_new frm = new FormNhap.frm_LinhKhoa_new();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem5_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            FormNhap.frm_XemSoPL frm = new FormNhap.frm_XemSoPL();
            frm.ShowDialog();
        }

        private void bardmtieunhom_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormDanhMuc.us_dmTieuNhomDV frm = new FormDanhMuc.us_dmTieuNhomDV();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barDMBV_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormDanhMuc.us_DmBenhVien frm = new FormDanhMuc.us_DmBenhVien();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barBN_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            TraCuu.us_BNhuydon frm = new TraCuu.us_BNhuydon();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barThamDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.BHYT.us_ThamDinh frm = new QLBV.BHYT.us_ThamDinh();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barTCthuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.TraCuu.us_TCThuocKD frm = new QLBV.TraCuu.us_TCThuocKD();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barTCKhoaCT_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.TraCuu.us_TCKhoaCT frm = new QLBV.TraCuu.us_TCKhoaCT();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barBHXP_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.BHYT.us_BHXaPhuong frm = new QLBV.BHYT.us_BHXaPhuong();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barBaocaoBHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("BHYT");
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barYCNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.frm_LinhKhoa_Moi frm = new FormThamSo.frm_LinhKhoa_Moi();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barSieuAm_ItemClick(object sender, ItemClickEventArgs e)
        {
            //panDetail.Controls.Clear();
            //QLBV.FormThamSo.frm_kqCDHA frm = new FormThamSo.frm_kqCDHA();
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            //panDetail.Controls.Add(frm);
        }

        private void barLienHe_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormNhap.us_HoTro frm = new  FormNhap.us_HoTro();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barDVct_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.us_DmDichVuCLS frm = new FormDanhMuc.us_DmDichVuCLS();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barLinhDuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            //FormNhap.frm_LinhKhoa_new frm = new FormNhap.frm_LinhKhoa_new();
            FormThamSo.frm_LinhKhoa_Moi frm = new FormThamSo.frm_LinhKhoa_Moi();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonKQMau_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormDanhMuc.us_DmKQMau frm = new FormDanhMuc.us_DmKQMau();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChucNang.frm_update frm = new ChucNang.frm_update();
            frm.ShowDialog();
        }

        private void barKhoaNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TraCuu.us_KhoaNgay frm = new TraCuu.us_KhoaNgay();
            //panDetail.Controls.Clear();
            //frm.Dock = System.Windows.Forms.DockStyle.Fill;
            //panDetail.Controls.Add(frm);
        }

        private void barDMNN_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormDanhMuc.Frm_Dm_NgheNghiep frm = new FormDanhMuc.Frm_Dm_NgheNghiep();
            frm.ShowDialog();
        }

        private void barNhapNgoaiBV_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.Frm_NhapBNNgoaiBV frm = new FormNhap.Frm_NhapBNNgoaiBV();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barQLTS_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.Frm_SuDungTS frm = new FormNhap.Frm_SuDungTS();
            frm.ShowDialog();
        }

        private void barUpdateMaCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChucNang.frm_UpdateMaCC frm = new ChucNang.frm_UpdateMaCC();
            frm.ShowDialog();
        }

        private void barCDHA_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.Frm_CDHA_Moi frm = new FormThamSo.Frm_CDHA_Moi();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barKhoaDLTheoNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            TraCuu.us_KhoaNgay frm = new TraCuu.us_KhoaNgay();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem1_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            TraCuu.us_KhoaNgay frm = new TraCuu.us_KhoaNgay();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barQLTS_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FormNhap.US_TaiSan frm = new FormNhap.US_TaiSan();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barChonThuocXuatTheoNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.Frm_ChonXuatThuoc frm = new FormThamSo.Frm_ChonXuatThuoc();
            frm.ShowDialog();
        }

        private void barUpdateStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            QLBVEntities _db=new QLBVEntities(DungChung.Bien.StrCon);
            var dtctupdate = (from a in _db.DThuoccts.Where(p => p.SoLo != null && p.SoLo.ToLower().Contains("\r\n"))
                        select a).ToList();
            foreach (var item in dtctupdate)
            {
                item.SoLo = item.SoLo.Replace("\r\n", "");
                _db.SaveChanges();
            }
            var ndctupdate = (from a in _db.NhapDcts.Where(p => p.SoLo != null && p.SoLo.ToLower().Contains("\r\n"))
                              select a).ToList();
            foreach (var item2 in ndctupdate)
            {
                item2.SoLo = item2.SoLo.Replace("\r\n", "");
                _db.SaveChanges();
            }
        }

        private void barQLKSK_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.us_KhamSucKhoe frm = new FormNhap.us_KhamSucKhoe();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barDMTS_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormDanhMuc.Frm_DmTaiSan frm = new FormDanhMuc.Frm_DmTaiSan();
            frm.ShowDialog();
        }

        private void barBcCLS_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("CLS");
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region update gia vào dsgia trong dịch vụ
            QLBVEntities _data = new QLBVEntities(DungChung.Bien.StrCon);
            var dsdv = (from nd in _data.NhapDs.Where(p => p.PLoai == 1)
                        join ndct in _data.NhapDcts on nd.IDNhap equals ndct.IDNhap
                        select new { ndct.MaDV, ndct.DonGia }).Distinct().ToList();
            List<DichVu> _ldv = _data.DichVus.ToList();
            foreach (var item in _ldv)
            {
                foreach (var item2 in dsdv)
                {
                    if (item.MaDV == item2.MaDV)
                    {
                        if(item.DSDonGia.Length>1)
                        item.DSDonGia += ";"+item2.DonGia.ToString();
                        else
                            item.DSDonGia = item2.DonGia.ToString();
                        _data.SaveChanges();
                    }

                }

            }
            #endregion
        }

        private void baTraCuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormTraCuu.FrmTC_NhapXuatTon frm = new FormTraCuu.FrmTC_NhapXuatTon();
            frm.ShowDialog();
        }

        private void barBcHangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("Khoa dược","Nhap","",true);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

      

        private void barBcNXT_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("Khoa dược", "NXT", "", true);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barBcTruocTD_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("BHYT", "TTD", "", true);
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barTTTuDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChucNang.frm_ThanhToanLai frm = new ChucNang.frm_ThanhToanLai();
            frm.ShowDialog();
        }

        private void barChiPhiDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frm_UpdateChiPhiDV frm = new FormThamSo.frm_UpdateChiPhiDV();
            frm.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormDanhMuc.frmAdmin frm = new FormDanhMuc.frmAdmin(DungChung.Bien.TenDN,2);
            frm.ShowDialog();
        }

        private void barTCThuocTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormTraCuu.Frm_TCThuocTTchuaXuat frm = new FormTraCuu.Frm_TCThuocTTchuaXuat();
            frm.ShowDialog();
        }

        private void barNCPM_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barNCDL_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barMenuBC_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.Frm_SetMenu frm = new FormThamSo.Frm_SetMenu();
            frm.ShowDialog();
        }

        private void barButtonItem8_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.us_menubc frm = new FormThamSo.us_menubc("Khám bệnh|Điều trị");
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barDoiMaBV_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChucNang.frm_DoiMaBV frm = new ChucNang.frm_DoiMaBV();
            frm.ShowDialog();
        }

        private void barBNNT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.Frm_KTNB frm = new FormThamSo.Frm_KTNB();
            frm.ShowDialog();
        }

        private void barPermisson_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.frm_CapQuyen frm = new FormNhap.frm_CapQuyen();
            frm.ShowDialog();
        }

        private void barKSKNoiBo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.frm_NhapThongTinKSK_CB frm = new FormNhap.frm_NhapThongTinKSK_CB();
            frm.ShowDialog();
        }

        private void barDM_DTBN_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.frm_DmDTBN frm = new FormNhap.frm_DmDTBN();
            frm.ShowDialog();
        }

        private void barNhapTraDuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FormNhap.frm_TraDuoc frm = new FormNhap.frm_TraDuoc();
            //frm.ShowDialog();
            FormNhap.us_TraDuoc frm = new FormNhap.us_TraDuoc();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void bar_duyet_gui_ItemClick(object sender, ItemClickEventArgs e)
        {
            BHYT.us_Export_XML_2348 frm = new QLBV.BHYT.us_Export_XML_2348();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barTeamViewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string _app = "TeamViewer.exe";
                DirectoryInfo di = new DirectoryInfo("C:\\Program Files\\");
                FileInfo[] fi = di.GetFiles(_app, SearchOption.AllDirectories);
                if (fi.Count() <= 0)
                {
                    di = new DirectoryInfo("C:\\Program Files (x86)\\");
                    fi = di.GetFiles("TeamViewer.exe", SearchOption.AllDirectories);
                }
                string path = "";
                foreach (FileInfo file in fi)
                {
                    path = file.DirectoryName + "\\" + _app;

                }
                if (!string.IsNullOrEmpty(path))
                {
                    System.Diagnostics.Process.Start(path);
                    //
                    System.Diagnostics.Process pr = new System.Diagnostics.Process();
                    pr.StartInfo.FileName = path;
                    pr.StartInfo.Arguments = path;
                    pr.Start();
                }
            }
            catch (Exception) {
                MessageBox.Show("lỗi");
            }
        }

        private void SaoLuuDuLieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.Frm_SaoCSDN frm = new FormNhap.Frm_SaoCSDN();
            frm.ShowDialog();
        }

        private void barBenhAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormNhap.uc_DuyetBenhAn frm = new FormNhap.uc_DuyetBenhAn();
            if (DungChung.Ham.checkQuyen(frm.Name)[3])
            {
                panDetail.Controls.Clear();
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                panDetail.Controls.Add(frm);
            }
        }

        private void barMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barKNXP_ItemClick(object sender, ItemClickEventArgs e)
        {

            FormThamSo.frm_NhanVienPhiXP_SA frm = new FormThamSo.frm_NhanVienPhiXP_SA();
            frm.ShowDialog();

        }

        private void barNangCapSQL_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.Frm_NangcapSQL frm = new FormThamSo.Frm_NangcapSQL();
            frm.ShowDialog();
        }

        private void btnNCGD_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.Frm_Download frm = new FormThamSo.Frm_Download();
            frm.ShowDialog();
        }

        private void barDSTCTT_ItemClick(object sender, ItemClickEventArgs e)
        {

            ChucNang.us_DSTamUng_TCTT frm = new ChucNang.us_DSTamUng_TCTT();
            panDetail.Controls.Clear();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void btn_DLTD_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormThamSo.frm_LoadDuocXP frm = new FormThamSo.frm_LoadDuocXP();
            frm.ShowDialog();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void barDMbiênlai_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormDanhMuc.frm_DmSoBL frm = new FormDanhMuc.frm_DmSoBL();
            frm.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.UC_dashboard frm1 = new FormNhap.UC_dashboard();
            frm1.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm1);
        }

        private void barGetSKB_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormNhap.getSoKB frm1 = new FormNhap.getSoKB();
            frm1.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm1);
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            MoFormLen<QLBV.FormNhap.us_SanXuatThuoc>();
        }

        private void barDTBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            QLBV.FormDanhMuc.dmDoiTuongcs frm1 = new FormDanhMuc.dmDoiTuongcs();
            frm1.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm1);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnDSTheHetHan_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            frm_nhappersion frm = new frm_nhappersion();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panDetail.Controls.Add(frm);
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            panDetail.Controls.Clear();
            FormThamSo.frm_KeDonThuocMau frm = new FormThamSo.frm_KeDonThuocMau();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            //panDetail.Controls.Add(frm);
            frm.ShowDialog();
        }

       


    }
}
