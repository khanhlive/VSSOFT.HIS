using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class TieuNhomDichVuProvider : ProviderBase
    {
        public TieuNhomDichVuProvider():base()
        {
        }

        public List<DIC_TIEUNHOMDICHVU> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetTieuNhomDichVu");
                List<DIC_TIEUNHOMDICHVU> dstieunhom = this.DataReaderToList(dt);
                return dstieunhom;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive TIEU NHOM DICH VU", e);
                return null;
            }
        }

        public List<DIC_TIEUNHOMDICHVU> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllTieuNhomDichVu");
                List<DIC_TIEUNHOMDICHVU> dstieunhom = this.DataReaderToList(dt);
                return dstieunhom;
            }
            catch (Exception e)
            {
                log.Error("GetAll TIEU NHOM DICH VU", e);
                return null;
            }
        }

        protected List<DIC_TIEUNHOMDICHVU> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_TIEUNHOMDICHVU> dstieunhom = new List<DIC_TIEUNHOMDICHVU>();
                while (dataReader.Read())
                {
                    DIC_TIEUNHOMDICHVU tieunhom = new DIC_TIEUNHOMDICHVU();
                    tieunhom.MaTieuNhom = DataConverter.StringToInt(dataReader["MaTieuNhom"].ToString());
                    tieunhom.TenTieuNhom = dataReader["TenTieuNhom"].ToString();
                    tieunhom.TenNhom = dataReader["TenNhom"].ToString();
                    tieunhom.MaNhom = DataConverter.StringToInt(dataReader["MaNhom"].ToString());
                    tieunhom.TenRutGon = (dataReader["TenRutGon"].ToString());
                    tieunhom.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    tieunhom.BHYT = DataConverter.ToInt(dataReader["BHYT"].ToString());
                    tieunhom.STT = DataConverter.ToByte(dataReader["STT"].ToString());

                    dstieunhom.Add(tieunhom);
                }
                return dstieunhom;
            }
            catch (Exception e)
            {
                log.Error("Generate TIEU NHOM DICH VU", e);
                return null;
            }

        }

        public SqlResultType Insert(DIC_TIEUNHOMDICHVU tieunhom)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertTieuNhomDichVu]",
                    new string[] { "@TenTieuNhom", "@MaNhom", "@TenRutGon", "@Stt", "@Status" },
                    new object[] { tieunhom.TenTieuNhom, tieunhom.MaNhom, tieunhom.TenRutGon, tieunhom.STT, tieunhom.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert TIEU NHOM DICH VU", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_TIEUNHOMDICHVU tieunhom)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[UpdateTieuNhomDichVu]",
                    new string[] { "@MaTieuNhom", "@TenTieuNhom", "@MaNhom", "@TenRutGon", "@Stt", "@Status" },
                    new object[] { tieunhom.MaTieuNhom, tieunhom.TenTieuNhom, tieunhom.MaNhom, tieunhom.TenRutGon, tieunhom.STT, tieunhom.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update TIEU NHOM DICH VU", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_TIEUNHOMDICHVU tieunhom)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteTieuNhomDichVu", new string[] { "@MaTieuNhom" }, new object[] { tieunhom.MaTieuNhom });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete TIEU NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }
    }
}
