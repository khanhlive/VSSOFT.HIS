using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core.Ado
{
    public class JobProvider : ProviderBase
    {
        public JobProvider():base()
        {
        }
        
        protected List<DIC_NGHENGHIEP> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_NGHENGHIEP> dsnghenghiep = new List<DIC_NGHENGHIEP>();
                while (dataReader.Read())
                {
                    DIC_NGHENGHIEP nghenghiep = new DIC_NGHENGHIEP();
                    nghenghiep.MaNgheNghiep = dataReader["MaNgheNghiep"].ToString();
                    nghenghiep.TenNgheNghiep = dataReader["TenNgheNghiep"].ToString();
                    nghenghiep.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    nghenghiep.MoTa= dataReader["MoTa"].ToString();
                    
                    dsnghenghiep.Add(nghenghiep);
                }
                return dsnghenghiep;
            }
            catch (Exception e)
            {
                log.Error("Generate NGHE NGHIEP", e);
                return null;
            }

        }

        public List<DIC_NGHENGHIEP> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllNgheNghiep");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll NGHE NGHIEP", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_NGHENGHIEP nghenghiep)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[InsertNgheNghiep]",
                    new string[] { "@MaNgheNghiep", "@TenNgheNghiep", "@MoTa" },
                    new object[] { nghenghiep.MaNgheNghiep, nghenghiep.TenNgheNghiep, nghenghiep.MoTa  });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert NGHE NGHIEP", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_NGHENGHIEP nghenghiep)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("[UpdateNgheNghiep]",
                    new string[] { "@MaNgheNghiep", "@TenNgheNghiep", "@MoTa" },
                    new object[] { nghenghiep.MaNgheNghiep, nghenghiep.TenNgheNghiep, nghenghiep.MoTa });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update NGHE NGHIEP", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_NGHENGHIEP nghenghiep)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteNgheNghiep", new string[] { "@MaNgheNghiep" }, new object[] { nghenghiep.MaNgheNghiep });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete NGHE NGHIEP", e);
                return SqlResultType.Exception;
            }
        }
    }
}
