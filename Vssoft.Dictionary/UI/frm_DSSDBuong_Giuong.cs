using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vssoft.ERP.Models;
using Vssoft.Data.Extension.Class;
using Vssoft.Data.Extension;
//using System.Web.UI.WebControls;

namespace QLBV.FormThamSo
{
    public partial class frm_DSSDBuong_Giuong : DevExpress.XtraEditors.XtraForm
    {
        public frm_DSSDBuong_Giuong()
        {
            InitializeComponent();
        }
        public frm_DSSDBuong_Giuong(int _makp,string nam)
        {
            InitializeComponent();
        }
        Hospital data = new Hospital();
        //List<QLBV.FormThamSo.frm_NhapBuongGiuongKeKoach.dsBuongGiuong> _da = new List<QLBV.FormThamSo.frm_NhapBuongGiuongKeKoach.dsBuongGiuong>();
        private void frm_DSSDBuong_Giuong_Load(object sender, EventArgs e)
        {
             
            lupngayden.DateTime = System.DateTime.Now;
            lupNgaytu.DateTime = System.DateTime.Now.AddMonths(-1);
            List<KPhong> _lkp = new List<KPhong>();
            _lkp = data.KPhongs.Where(p => p.PLoai == KhoaPhongPL.LamSang || p.PLoai == KhoaPhongPL.PhongKham).ToList();
            lupKhoaphong.Properties.DataSource = _lkp;
            
        }

        private void addrow()
        {
            //gridView1.Columns.Clear();
            //DateTime ngayden = FormatHelper.BeginDate(lupngayden.DateTime);
            //DateTime ngaytu = FormatHelper.EndDate(lupNgaytu.DateTime);
            //int makp = 0;
            //if(lupKhoaphong.EditValue != null)
            //{
            //    makp = Convert.ToInt32(lupKhoaphong.EditValue);
            //}
            //string nam = lupngayden.DateTime.Year.ToString();
            //_da = QLBV.FormThamSo.frm_NhapBuongGiuongKeKoach.getBuongGiuong(data, makp, nam);
            //DataTable dt = new DataTable();
            //DataRow dr = null;
            //dt.Clear();
            //int sob = _da.GroupBy(p => p.buong).Count();
            //var buong = _da.GroupBy(p => p.buong).ToList();
            //var giuong = _da.GroupBy(p => p.giuongTT).ToList();
            //var dsa1 = (from b in data.BNKBs.Where(p => p.NgayKham <= ngayden)
            //               join a in data.BenhNhans.Where(p => p.NoiTru == 1)  on b.MaBNhan equals a.MaBNhan
            //               join c in data.RaViens on b.MaBNhan equals c.MaBNhan into k
            //               from k1 in k.DefaultIfEmpty()
            //                   select new {    
            //                       a.TenBNhan,
            //                       a.MaBNhan,
            //                       b.IDKB,
            //                       k1.NgayRa
            //                   }).ToList();
            //var dsa = (from a in dsa1.Where(p => p.NgayRa > ngayden || p.NgayRa == null)
            //       group a by new { a.TenBNhan, a.MaBNhan } into kq
            //       select new
            //       {
            //           kq.Key.TenBNhan,
            //           kq.Key.MaBNhan,
            //           IDKB = kq.Max(p => p.IDKB)
            //       }).ToList();
            //var ds = (from a in dsa
            //          join b in data.BNKBs.Where(p => p.MaKP == makp) on a.IDKB equals b.IDKB
            //          select new {
            //            a.MaBNhan,
            //            a.TenBNhan,
            //            b.Buong,
            //            b.Giuong,
            //          }).ToList();
            //dt.Columns.Add(new DataColumn("Buồng", typeof(string)));
            //foreach (var item in giuong)
            //{
            //    dt.Columns.Add(new DataColumn("Giường " + item.Key.ToString(), typeof(string))); 
            //    //dt.Columns.Add(new DataColumn("Bệnh nhân " + item.Key.ToString(), typeof(string)));
            //}
            //    var da = (from a in _da.Where(p => p.buong != "" && p.giuongTT != "")
            //              join b in ds on new { buong = a.buong, giuongTT = a.giuongTT } equals new { buong = b.Buong, giuongTT = b.Giuong } into k
            //              from k1 in k.DefaultIfEmpty()
            //              select new
            //              {
            //                  a.buong,
            //                  a.giuongTT,
            //                  MaBNhan = (k1 != null) ? Convert.ToString(k1.MaBNhan) : null,
            //                  TenBN = (k1 != null) ? k1.TenBNhan : null
            //              }).ToList();
                
            //    foreach (var item2 in buong)
            //    {
            //        dr = dt.NewRow();
            //        dr["Buồng"] = item2.Key.ToString();
            //        foreach(var item1 in da.Where(p => p.buong == item2.Key.ToString()))
            //        {                        
            //            if (item1.MaBNhan == null)
            //                dr["Giường " + item1.giuongTT.ToString()] = " ";
            //            else
            //            {
            //                dr["Giường " + item1.giuongTT.ToString()] += item1.MaBNhan + "_" + item1.TenBN + "  ";
            //            }                       
            //        }
            //        dt.Rows.Add(dr);
            //    }              
            //bindingSource1.DataSource = dt;
            //gridControl1.RefreshDataSource();
            //gridControl1.DataSource = bindingSource1;

        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            addrow();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //var buong = _da.GroupBy(p => p.buong).ToList();
            //var giuong = _da.GroupBy(p => p.giuongTT).ToList();
            //foreach (var item in giuong)
            //{
            //    var da = _da.Where(p => p.giuongTT == item.Key.ToString()).ToList();
            //    //var n = (from a in buong
            //    //         join b in da on a.Key.ToString() equals b.buong into k
            //    //         from k1 in k.DefaultIfEmpty()
            //    //         select new { a.Key, giuongTT = k1 != null?k1.giuongTT:"" }).ToList();
            //    if (e.Column.FieldName == "Giường " + item.Key.ToString())
            //    {
            //        String celVL = gridView1.GetRowCellValue(e.RowHandle, "Giường " + item.Key.ToString()).ToString();
            //        if (celVL != " " && celVL != null)
            //        {
            //            e.Appearance.BackColor = Color.FromArgb(255, 224, 192);
            //        }
            //        if (celVL == "")
            //            e.Appearance.BackColor = Color.FromArgb(211, 211, 211);
            //    }
            //}           
        }
    }
}