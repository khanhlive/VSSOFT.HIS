using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class EmployeeProvider : ProviderBase
    {
        public EmployeeProvider():base()
        {
        }

        public List<DIC_CANBO> GetByMaPhongBan(int maphongban)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetCanBoByMaPhongBan", new string[] { "@MaPhongBan" }, new object[] { maphongban });
                List<DIC_CANBO> dscanbo = this.DataReaderToList(dt);
                return dscanbo;
            }
            catch (Exception e)
            {
                log.Error("GetCANBO by Phongban", e);
                return null;
            }
        }

        protected List<DIC_CANBO> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_CANBO> dscanbo = new List<DIC_CANBO>();
                while (dataReader.Read())
                {
                    DIC_CANBO canbo = new DIC_CANBO();
                    canbo.BangCap = dataReader["BangCap"].ToString();
                    canbo.CapBac = dataReader["CapBac"].ToString();
                    canbo.ChucVu = dataReader["ChucVu"].ToString();
                    canbo.DiaChi = dataReader["DiaChi"].ToString();
                    canbo.Image = dataReader["Image"].ToString();
                    canbo.GioiTinh = Convert.ToInt32(dataReader["GioiTinh"].ToString());
                    canbo.KhoaChungTu = Convert.ToBoolean(dataReader["KhoaChungTu"].ToString());
                    canbo.MaCanBo = dataReader["MaCanBo"].ToString();
                    canbo.MaPhongBan = Convert.ToInt32(dataReader["MaPhongBan"].ToString());
                    canbo.MaDanToc = dataReader["MaDanToc"].ToString();
                    canbo.SoDienThoai = dataReader["SoDienThoai"].ToString();
                    canbo.TenCanBo = dataReader["TenCanBo"].ToString();
                    canbo.TenPhongBan = dataReader["TenPhongBan"].ToString();
                    canbo.TenDanToc = dataReader["TenDanToc"].ToString();
                    dscanbo.Add(canbo);
                }
                return dscanbo;
            }
            catch (Exception e)
            {
                log.Error("Generate CAN BO", e);
                return null;
            }

        }

        public List<DIC_CANBO> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllCanBo");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll CAN BO", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_CANBO canbo)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertCanBo",
                    new string[] { "@MaCanBo", "@TenCanBo", "@NgaySinh", "@GioiTinh", "@ChucVu", "@CapBac", "@BangCap", "@MaDanToc", "@MaPhongBan", "@Image", "@DiaChi", "@SoDienThoai", "@KhoaChungTu" },
                    new object[] { canbo.MaCanBo, canbo.TenCanBo, canbo.NgaySinh, canbo.GioiTinh, canbo.ChucVu, canbo.CapBac, canbo.BangCap, canbo.MaDanToc, canbo.MaPhongBan, canbo.Image, canbo.DiaChi, canbo.SoDienThoai, canbo.KhoaChungTu });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert CAN BO", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_CANBO canbo)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateCanBo",
                    new string[] { "@MaCanBo", "@TenCanBo", "@NgaySinh", "@GioiTinh", "@ChucVu", "@CapBac", "@BangCap", "@MaDanToc", "@MaPhongBan", "@Image", "@DiaChi", "@SoDienThoai", "@KhoaChungTu" },
                    new object[] { canbo.MaCanBo, canbo.TenCanBo, canbo.NgaySinh, canbo.GioiTinh, canbo.ChucVu, canbo.CapBac, canbo.BangCap, canbo.MaDanToc, canbo.MaPhongBan, canbo.Image, canbo.DiaChi, canbo.SoDienThoai, canbo.KhoaChungTu });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update CAN BO", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_CANBO canbo)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteCanBo", new string[] { "@MaCanBo" }, new object[] { canbo.MaCanBo });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete CAN BO", e);
                return SqlResultType.Exception;
            }
        }
    }
}
