using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core.Ado
{
    /// <summary>
    /// ĐỐI TƯỢNG TRUY XUẤT DỮ LIỆU CHO CHUYEN KHOA
    /// </summary>
    public class SpecialtyProvider : ProviderBase
    {
        public SpecialtyProvider() : base() { }
        public List<ChuyenKhoa> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetChuyenKhoa");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllActive CHUYEN KHOA", ex);
                return null;
            }
            
        }

        protected List<ChuyenKhoa> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<ChuyenKhoa> dsChuyenKhoa = new List<ChuyenKhoa>();
                while (dataReader.Read())
                {
                    ChuyenKhoa chuyenKhoa = new ChuyenKhoa();
                    chuyenKhoa.MaCK = Convert.ToInt32(dataReader["MaChuyenKhoa"].ToString());
                    chuyenKhoa.TenCK = dataReader["TenChuyenKhoa"].ToString();
                    chuyenKhoa.TenChiTiet = dataReader["TenChiTiet"].ToString();
                    chuyenKhoa.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    chuyenKhoa.MaQuyetDinh = dataReader["MaQuyetDinh"].ToString();
                    dsChuyenKhoa.Add(chuyenKhoa);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate CHUYEN KHOA", ex);
                return null;
            }
        }

        public List<ChuyenKhoa> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllChuyenKhoa");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll CHUYEN KHOA", ex);
                return null;
            }
        }

        public SqlResultType Insert(ChuyenKhoa chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertChuyenKhoa",
                    new string[] { "@MaChuyenKhoa", "@TenChuyenKhoa", "@TenChiTiet", "@Status", "@MaQuyetDinh" },
                    new object[] { chuyenKhoa.MaCK, chuyenKhoa.TenCK, chuyenKhoa.TenChiTiet, chuyenKhoa.Status, chuyenKhoa.MaQuyetDinh }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert CHUYEN KHOA", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Update(ChuyenKhoa chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateChuyenKhoa",
                    new string[] { "@MaChuyenKhoa", "@TenChuyenKhoa", "@TenChiTiet", "@Status", "@MaQuyetDinh" },
                    new object[] { chuyenKhoa.MaCK, chuyenKhoa.TenCK, chuyenKhoa.TenChiTiet, chuyenKhoa.Status, chuyenKhoa.MaQuyetDinh }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update CHUYEN KHOA", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Delete(ChuyenKhoa ChuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteChuyenKhoa", new string[] { "@MaChuyenKhoa" }, new object[] { ChuyenKhoa.MaCK });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete CHUYEN KHOA", ex);
                return SqlResultType.Exception;
            }
        }
    }
}
