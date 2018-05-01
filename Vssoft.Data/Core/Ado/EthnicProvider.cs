using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class EthnicProvider : ProviderBase
    {
        public EthnicProvider() : base() { }

        public List<DIC_DANTOC> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetDanToc");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllActive DAN TOC", ex);
                return null;
            }
        }

        protected List<DIC_DANTOC> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_DANTOC> dsdantoc = new List<DIC_DANTOC>();
                while (dataReader.Read())
                {
                    DIC_DANTOC danToc = new DIC_DANTOC();
                    danToc.MaDanToc = dataReader["MaDanToc"].ToString();
                    danToc.TenDanToc = dataReader["TenDanToc"].ToString();
                    danToc.MoTa = dataReader["MoTa"].ToString();
                    danToc.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsdantoc.Add(danToc);
                }
                return dsdantoc;
            }
            catch (Exception e)
            {
                log.Error("Generate DAN TOC", e);
                return null;
            }
            
        }

        public List<DIC_DANTOC> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllDanToc");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll DAN TOC", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_DANTOC danToc)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDanToc", new string[] { "@MaDanToc", "@TenDanToc", "@MoTa", "@Status" }, new object[] { danToc.MaDanToc, danToc.TenDanToc, danToc.MoTa, danToc.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert dan toc", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_DANTOC danToc)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDanToc", new string[] { "@MaDanToc", "@TenDanToc", "@MoTa", "@Status" }, new object[] { danToc.MaDanToc, danToc.TenDanToc, danToc.MoTa, danToc.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DAN TOC", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_DANTOC danToc)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDanToc", new string[] { "@MaDanToc" }, new object[] { danToc.MaDanToc });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DAN TOC", e);
                return SqlResultType.Exception;
            }
        }
    }
}
