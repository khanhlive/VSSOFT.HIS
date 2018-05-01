using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    /// <summary>
    /// TRUY CẬP DỮ LIỆU NHÀ CUNG CẤP
    /// </summary>
    public class PupplierProvider : ProviderBase
    {
        public PupplierProvider():base()
        {
        }
        public List<DIC_NHACUNGCAP> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetNhaCungCap");
                List<DIC_NHACUNGCAP> dsdoituong = this.DataReaderToList(dt);
                return dsdoituong;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive NHA CUNG CAP", e);
                return null;
            }
        }

        public List<DIC_NHACUNGCAP> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllNhaCungCap");
                List<DIC_NHACUNGCAP> dsnhacungcap = this.DataReaderToList(dt);
                return dsnhacungcap;
            }
            catch (Exception e)
            {
                log.Error("GetAll NHA CUNG CAP", e);
                return null;
            }
        }

        protected List<DIC_NHACUNGCAP> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_NHACUNGCAP> dsnhacungcap = new List<DIC_NHACUNGCAP>();
                while (dataReader.Read())
                {
                    DIC_NHACUNGCAP nhacungcap = new DIC_NHACUNGCAP();
                    nhacungcap.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    nhacungcap.MaNhaCungCap = dataReader["MaNhaCungCap"].ToString();
                    nhacungcap.TenNhaCungCap = dataReader["TenNhaCungCap"].ToString();
                    nhacungcap.DiaChi = dataReader["DiaChi"].ToString();
                    nhacungcap.DienThoai = dataReader["DienThoai"].ToString();
                    nhacungcap.NguoiDaiDien = dataReader["NguoiDaiDien"].ToString();
                    nhacungcap.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsnhacungcap.Add(nhacungcap);
                }
                return dsnhacungcap;
            }
            catch (Exception e)
            {
                log.Error("Generate NHA CUNG CAP", e);
                return null;
            }

        }

        public SqlResultType Insert(DIC_NHACUNGCAP nhacungcap)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertNhaCungCap]",
                    new string[] { "@MaNhaCungCap", "@TenNhaCungCap", "@DiaChi", "@DienThoai", "@NguoiDaiDien", "@Status" },
                    new object[] { nhacungcap.MaNhaCungCap, nhacungcap.TenNhaCungCap, nhacungcap.DiaChi, nhacungcap.DienThoai, nhacungcap.NguoiDaiDien, nhacungcap.Status});
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert NHA CUNG CAP", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_NHACUNGCAP nhacungcap)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateNhaCungCap",
                    new string[] { "@MaNhaCungCap", "@TenNhaCungCap", "@DiaChi", "@DienThoai", "@NguoiDaiDien", "@Status" },
                    new object[] { nhacungcap.MaNhaCungCap, nhacungcap.TenNhaCungCap, nhacungcap.DiaChi, nhacungcap.DienThoai, nhacungcap.NguoiDaiDien, nhacungcap.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update NHA CUNG CAP", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_NHACUNGCAP nhacungcap)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteNhaCungCap", new string[] { "@MaNhaCungCap" }, new object[] { nhacungcap.MaNhaCungCap });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete NHA CUNG CAP", e);
                return SqlResultType.Exception;
            }
        }
    }
}
