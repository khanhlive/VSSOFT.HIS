using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    /// <summary>
    /// ĐỐI TƯỢNG TRUY XUẤT DỮ LIỆU CHO CHUYEN KHOA
    /// </summary>
    public class SpecialtyProvider : ProviderBase
    {
        public SpecialtyProvider() : base() { }

        public List<DIC_CHUYENKHOA> GetAllActive()
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

        protected List<DIC_CHUYENKHOA> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_CHUYENKHOA> dsChuyenKhoa = new List<DIC_CHUYENKHOA>();
                while (dataReader.Read())
                {
                    DIC_CHUYENKHOA chuyenKhoa = new DIC_CHUYENKHOA();
                    chuyenKhoa.MaChuyenKhoa = Convert.ToInt32(dataReader["MaChuyenKhoa"].ToString());
                    chuyenKhoa.TenChuyenKhoa = dataReader["TenChuyenKhoa"].ToString();
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

        public List<DIC_CHUYENKHOA> GetAll()
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

        public SqlResultType Insert(DIC_CHUYENKHOA chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertChuyenKhoa",
                    new string[] { "@MaChuyenKhoa", "@TenChuyenKhoa", "@TenChiTiet", "@Status", "@MaQuyetDinh" },
                    new object[] { chuyenKhoa.MaChuyenKhoa, chuyenKhoa.TenChuyenKhoa, chuyenKhoa.TenChiTiet, chuyenKhoa.Status, chuyenKhoa.MaQuyetDinh }
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

        public SqlResultType Update(DIC_CHUYENKHOA chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateChuyenKhoa",
                    new string[] { "@MaChuyenKhoa", "@TenChuyenKhoa", "@TenChiTiet", "@Status", "@MaQuyetDinh" },
                    new object[] { chuyenKhoa.MaChuyenKhoa, chuyenKhoa.TenChuyenKhoa, chuyenKhoa.TenChiTiet, chuyenKhoa.Status, chuyenKhoa.MaQuyetDinh }
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

        public SqlResultType Delete(DIC_CHUYENKHOA chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteChuyenKhoa", new string[] { "@MaChuyenKhoa" }, new object[] { chuyenKhoa.MaChuyenKhoa });
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
