using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class NhomDichVuProvider : ProviderBase
    {
        public NhomDichVuProvider():base()
        {
        }

        public List<DIC_NHOMDICHVU> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetNhomDichVu");
                List<DIC_NHOMDICHVU> dsnhom = this.DataReaderToList(dt);
                return dsnhom;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive NHOM DICH VU", e);
                return null;
            }
        }

        public List<DIC_NHOMDICHVU> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllNhomDichVu");
                List<DIC_NHOMDICHVU> dsnhom = this.DataReaderToList(dt);
                return dsnhom;
            }
            catch (Exception e)
            {
                log.Error("GetAll NHOM DICH VU", e);
                return null;
            }
        }

        protected List<DIC_NHOMDICHVU> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_NHOMDICHVU> dstieunhom = new List<DIC_NHOMDICHVU>();
                while (dataReader.Read())
                {
                    DIC_NHOMDICHVU dsnhom = new DIC_NHOMDICHVU();
                    dsnhom.TenNhom = dataReader["TenNhom"].ToString();
                    dsnhom.MaNhom = DataConverter.StringToInt(dataReader["MaNhom"].ToString());
                    dsnhom.TenNhomChiTiet = (dataReader["TenNhomChiTiet"].ToString());
                    dsnhom.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsnhom.BHYT = DataConverter.ToInt(dataReader["BHYT"].ToString());
                    dsnhom.STT = DataConverter.ToByte(dataReader["STT"].ToString());

                    dstieunhom.Add(dsnhom);
                }
                return dstieunhom;
            }
            catch (Exception e)
            {
                log.Error("Generate NHOM DICH VU", e);
                return null;
            }

        }

        public SqlResultType Insert(DIC_NHOMDICHVU nhom)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertNhomDichVu]",
                    new string[] { "@MaNhom", "@TenNhom", "@Status", "@Stt", "@TenNhomChiTiet", "@Bhyt" },
                    new object[] { nhom.MaNhom, nhom.TenNhom, nhom.Status, nhom.STT, nhom.TenNhomChiTiet, nhom.BHYT??-1 });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert NHOM DICH VU", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_NHOMDICHVU nhom)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[UpdateNhomDichVu]",
                    new string[] { "@MaNhom", "@TenNhom", "@Status", "@Stt", "@TenNhomChiTiet", "@Bhyt" },
                    new object[] { nhom.MaNhom, nhom.TenNhom, nhom.Status, nhom.STT, nhom.TenNhomChiTiet, nhom.BHYT??-1 });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update NHOM DICH VU", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_NHOMDICHVU nhom)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteNhomDichVu", new string[] { "@MaNhom" }, new object[] { nhom.MaNhom });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete NHOM DICH VU", e);
                return SqlResultType.Exception;
            }
        }
    }
}
