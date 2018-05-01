using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;

namespace Vssoft.Data.ERP.Dictionary
{
    public class DIC_PHONGBAN :EntityBase<DIC_PHONGBAN>
    {
        public DIC_PHONGBAN() : base()
        {
            this.StoreGetAll = "GetAllPhongBan";
            this.StoreGetAllActive = "GetPhongBan";
        }

        #region Properties
        [ValueMember]
        public int MaPhongBan { get; set; }
        [DisplayMember]
        public string TenPhongBan { get; set; }
        public Nullable<int> NhomPhongBan { get; set; }
        public string ChuyenKhoa { get; set; }
        public Nullable<int> QuanLy { get; set; }
        public string BuongGiuong { get; set; }
        public string PhanLoai { get; set; }
        public int PhanLoai_ID { get; set; }
        public string MaQuyetDinh { get; set; }
        public string MaPhongBanCu { get; set; }
        public int MaChuyenKhoa { get; set; }
        public bool TuTruc { get; set; }
        public int TrongBenhVien { get; set; }
        public int PhuongPhapXuatDuoc { get; set; }
        public byte PhuongPhapHuHaoDongY { get; set; }
        public string DiaChi { get; set; }
        public string MaBenhVien { get; set; }
        public Nullable<int> Status { get; set; }
        #endregion

        public override SqlResultType Delete()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Delete(DIC_PHONGBAN entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert(DIC_PHONGBAN entity)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update()
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Update(DIC_PHONGBAN entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<DIC_PHONGBAN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_PHONGBAN> dsphongban = new List<DIC_PHONGBAN>();
                while (dataReader.Read())
                {
                    DIC_PHONGBAN phongban = new DIC_PHONGBAN();
                    phongban.MaPhongBan = DataConverter.StringToInt(dataReader["MaPhongBan"].ToString());
                    phongban.TenPhongBan = dataReader["TenPhongBan"].ToString();
                    phongban.NhomPhongBan = DataConverter.ToInt(dataReader["NhomPhongBan"].ToString());
                    phongban.ChuyenKhoa = dataReader["ChuyenKhoa"].ToString();
                    phongban.QuanLy = DataConverter.ToInt(dataReader["QuanLy"].ToString());
                    phongban.BuongGiuong = dataReader["BuongGiuong"].ToString();
                    phongban.PhanLoai = dataReader["PhanLoai"].ToString();
                    phongban.MaQuyetDinh = dataReader["MaQuyetDinh"].ToString();
                    phongban.MaPhongBanCu = dataReader["MaPhongBanCu"].ToString();
                    phongban.MaChuyenKhoa = DataConverter.StringToInt(dataReader["MaChuyenKhoa"].ToString());
                    phongban.TuTruc = Convert.ToBoolean(dataReader["TuTruc"].ToString());
                    phongban.TrongBenhVien = DataConverter.StringToInt(dataReader["TrongBenhVien"].ToString());
                    phongban.PhuongPhapXuatDuoc = DataConverter.StringToInt(dataReader["PhuongPhapXuatDuoc"].ToString());
                    phongban.PhuongPhapHuHaoDongY = Convert.ToByte(dataReader["PhuongPhapHuHaoDongY"].ToString());
                    phongban.DiaChi = dataReader["DiaChi"].ToString();
                    phongban.MaBenhVien = dataReader["MaBenhVien"].ToString();
                    phongban.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    phongban.PhanLoai_ID = DataConverter.StringToInt(dataReader["PhanLoai_ID"].ToString());
                    dsphongban.Add(phongban);
                }
                dataReader.Close();
                this.sqlHelper.Close();
                return dsphongban;
            }
            catch (Exception e)
            {
                log.Error("Generate PHONG BAN", e);
                return null;
            }
        }
       
    }
}
