using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core.Ado
{
    public class EthnicProvider : ProviderBase
    {
        public EthnicProvider() : base() { }

        public List<DanToc> GetAllActive()
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

        protected List<DanToc> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DanToc> dsdantoc = new List<DanToc>();
                while (dataReader.Read())
                {
                    DanToc danToc = new DanToc();
                    danToc.MaDT = dataReader["MaDanToc"].ToString();
                    danToc.TenDT = dataReader["TenDanToc"].ToString();
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

        public List<DanToc> GetAll()
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

        public SqlResultType Insert(DanToc danToc)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDanToc", new string[] { "@MaDanToc", "@TenDanToc", "@MoTa", "@Status" }, new object[] { danToc.MaDT, danToc.TenDT, danToc.MoTa, danToc.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert dan toc", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DanToc danToc)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDanToc", new string[] { "@MaDanToc", "@TenDanToc", "@MoTa", "@Status" }, new object[] { danToc.MaDT, danToc.TenDT, danToc.MoTa, danToc.Status });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DAN TOC", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DanToc danToc)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDanToc", new string[] { "@MaDanToc" }, new object[] { danToc.MaDT });
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
