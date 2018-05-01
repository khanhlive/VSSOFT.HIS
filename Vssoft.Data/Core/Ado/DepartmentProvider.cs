using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class DepartmentProvider : ProviderBase
    {
        
        public DepartmentProvider() : base() { }

        public List<DIC_PHONGBAN> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetPhongBan");
                return this.DataReaderToList(dt);
            }
            catch (Exception e)
            {
                this.sqlHelper.Close();
                log.Error("GetAllActive", e);
                return null;
            }
        }

        protected List<DIC_PHONGBAN> DataReaderToList(SqlDataReader dataReader)
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

        public List<DIC_PHONGBAN> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllPhongBan");
                
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                this.sqlHelper.Close();
                log.Error("GetAll PHONG BAN", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_PHONGBAN phongban)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertPhongBan",
                    new string[] { "@TenPhongBan", "@NhomPhongBan", "@QuanLy", "@BuongGiuong", "@PhanLoai_ID", "@MaQuyetDinh", "@MaPhongBanCu", "@MaChuyenKhoa", "@TuTruc", "@TrongBenhVien", "@PhuongPhapXuatDuoc", "@PhuongPhapHuHaoDongY", "@DiaChi", "@MaBenhVien", "@Status" },
                    new object[] { phongban.TenPhongBan, phongban.NhomPhongBan, phongban.QuanLy, phongban.BuongGiuong, phongban.PhanLoai_ID, phongban.MaQuyetDinh, "'NULL'", phongban.MaChuyenKhoa, phongban.TuTruc, phongban.TrongBenhVien, phongban.PhuongPhapXuatDuoc, phongban.PhuongPhapHuHaoDongY, phongban.DiaChi, phongban.MaBenhVien, phongban.Status });
                int kq = Convert.ToInt32(result);
                this.sqlHelper.Close();
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                this.sqlHelper.Close();
                log.Error("Insert PHONG BAN", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_PHONGBAN phongban)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdatePhongBan",
                    new string[] { "@MaPhongBan", "@TenPhongBan", "@NhomPhongBan", "@QuanLy", "@BuongGiuong", "@PhanLoai_ID", "@MaQuyetDinh", "@MaPhongBanCu", "@MaChuyenKhoa", "@TuTruc", "@TrongBenhVien", "@PhuongPhapXuatDuoc", "@PhuongPhapHuHaoDongY", "@DiaChi", "@MaBenhVien", "@Status" },
                    new object[] { phongban.MaPhongBan,phongban.TenPhongBan, phongban.NhomPhongBan, phongban.QuanLy, phongban.BuongGiuong, phongban.PhanLoai_ID, phongban.MaQuyetDinh, "'NULL'", phongban.MaChuyenKhoa, phongban.TuTruc, phongban.TrongBenhVien, phongban.PhuongPhapXuatDuoc, phongban.PhuongPhapHuHaoDongY, phongban.DiaChi, phongban.MaBenhVien, phongban.Status });
                int kq = Convert.ToInt32(result);
                this.sqlHelper.Close();
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                this.sqlHelper.Close();
                log.Error("Update PHONG BAN", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_PHONGBAN phongban)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeletePhongBan", new string[] { "@MaPhongBan" }, new object[] { phongban.MaPhongBan });
                int kq = Convert.ToInt32(result);
                this.sqlHelper.Close();
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                this.sqlHelper.Close();
                log.Error("Delete PHONG BAN", e);
                return SqlResultType.Exception;
            }
        }

        public DataTable GetList()
        {
            try
            {
                return this.sqlHelper.ExecuteDataTable("GetAllPhongBan");
            }
            catch (Exception e)
            {
                log.Error("Get PHONG Ban: ", e);
                return null;
            }
            finally
            {
                this.sqlHelper.Close();
            }
        }
    }
}
