using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.ERP;

namespace Vssoft.Data.Core.Ado
{
    public class HospitalProvider : ProviderBase
    {
        public HospitalProvider() : base() { }

        public List<DIC_BENHVIEN> GetAllBenhVienByHuyen(string mahuyen)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVienByMaHuyen", new string[] { "@MaHuyen" }, new object[] { mahuyen });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByHuyen DANH MUC DIC BENHVIEN", ex);
                return null;
            }
        }

        public List<DIC_BENHVIEN> GetAllBenhVienByTinh(string matinh)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVienByMaTinh", new string[] { "@MaTinh" }, new object[] {  matinh });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByHuyen DANH MUC DIC BENHVIEN", ex);
                return null;
            }

        }

        public List<DIC_BENHVIEN> GetAllBenhVienByConnect()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVienByConnect");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByHuyen DANH MUC DIC BENHVIEN", ex);
                return null;
            }

        }

        public List<DIC_BENHVIEN> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetBenhVien");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllActive DANH MUC DIC BENHVIEN", ex);
                return null;
            }

        }

        protected List<DIC_BENHVIEN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_BENHVIEN> dsChuyenKhoa = new List<DIC_BENHVIEN>();
                while (dataReader.Read())
                {
                    DIC_BENHVIEN benhvien = new DIC_BENHVIEN();
                    benhvien.ID= DataConverter.StringToInt(dataReader["ID"].ToString());
                    benhvien.MaBenhVien = dataReader["MaBenhVien"].ToString();
                    benhvien.MaHuyen = dataReader["MaHuyen"].ToString();
                    benhvien.TenBenhVien = dataReader["TenBenhVien"].ToString();
                    benhvien.MaChuQuan = dataReader["MaChuQuan"].ToString();
                    benhvien.TenHuyen = dataReader["TenHuyen"].ToString();
                    benhvien.MaTinh = dataReader["MaTinh"].ToString();
                    benhvien.TenTinh = dataReader["TenTinh"].ToString();
                    benhvien.TuyenBenhVien = dataReader["TuyenBenhVien"].ToString();
                    benhvien.HangBenhVien = DataConverter.StringToInt(dataReader["HangBenhVien"].ToString());
                    benhvien.DiaChi = dataReader["DiaChi"].ToString();
                    benhvien.Connect = Convert.ToBoolean(dataReader["Connect"].ToString());
                    benhvien.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(benhvien);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC DIC BENHVIEN", ex);
                return null;
            }
        }

        public List<DIC_BENHVIEN> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllBenhVien");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll DANH MUC DIC BENHVIEN", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_BENHVIEN benhvien)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertBenhVien",
                    new string[] { "@MaBenhVien", "@MaTinh", "@MaHuyen", "@MaChuQuan", "@TenBenhVien", "@TuyenBenhVien", "@HangBenhVien", "@DiaChi", "@Connect", "@Status" },
                    new object[] { benhvien.MaBenhVien, benhvien.MaTinh, benhvien.MaHuyen, benhvien.MaChuQuan, benhvien.TenBenhVien, benhvien.TuyenBenhVien, benhvien.HangBenhVien, benhvien.DiaChi, benhvien.Connect, benhvien.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert BENH VIEN", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_BENHVIEN benhvien)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateBenhVien",
                    new string[] { "@MaBenhVien", "@MaTinh", "@MaHuyen", "@MaChuQuan", "@TenBenhVien", "@TuyenBenhVien", "@HangBenhVien", "@DiaChi", "@Connect", "@Status" },
                    new object[] { benhvien.MaBenhVien, benhvien.MaTinh, benhvien.MaHuyen, benhvien.MaChuQuan, benhvien.TenBenhVien, benhvien.TuyenBenhVien, benhvien.HangBenhVien, benhvien.DiaChi, benhvien.Connect, benhvien.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update BENH VIEN", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_BENHVIEN benhvien)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteBenhVien", new string[] { "@MaBenhVien" }, new object[] { benhvien.MaBenhVien });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete BENH VIEN", e);
                return SqlResultType.Exception;
            }
        }
    }
}
