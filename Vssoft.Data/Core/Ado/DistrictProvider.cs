using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class DistrictProvider : ProviderBase
    {
        public List<DIC_HUYEN> GetAllHuyenbyTinh(string matinh)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetHuyenByTinh", new string[] { "@MaTinh" }, new object[] { matinh });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByTinh DANH MUC HUYEN/THI XA", ex);
                return null;
            }

        }

        public List<DIC_HUYEN> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetHuyen");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllActive DANH MUC HUYEN/THI XA", ex);
                return null;
            }

        }

        protected List<DIC_HUYEN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_HUYEN> dsChuyenKhoa = new List<DIC_HUYEN>();
                while (dataReader.Read())
                {
                    DIC_HUYEN huyen = new DIC_HUYEN();
                    huyen.MaHuyen = dataReader["MaHuyen"].ToString();
                    huyen.TenHuyen = dataReader["TenHuyen"].ToString();
                    huyen.MaTinh = dataReader["MaTinh"].ToString();
                    huyen.TenTinh= dataReader["TenTinh"].ToString();
                    huyen.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(huyen);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC HUYEN/THI XA", ex);
                return null;
            }
        }

        public List<DIC_HUYEN> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllHuyen");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll DANH MUC HUYEN/THI XA", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_HUYEN huyen)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertHuyen",
                    new string[] { "@MaHuyen", "@MaTinh", "@TenHuyen", "@Status" },
                    new object[] { huyen.MaHuyen, huyen.MaTinh, huyen.TenHuyen, huyen.Status }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH MUC HUYEN/THI XA", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Update(DIC_HUYEN huyen)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateHuyen",
                    new string[] { "@MaHuyen", "@MaTinh", "@TenHuyen", "@Status" },
                    new object[] { huyen.MaHuyen, huyen.MaTinh, huyen.TenHuyen, huyen.Status }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update DANH MUC HUYEN/THI XA", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Delete(DIC_HUYEN huyen)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteHuyen", new string[] { "@MaHuyen" }, new object[] { huyen.MaHuyen });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete DANH MUC HUYEN/THI XA", ex);
                return SqlResultType.Exception;
            }
        }
    }
}
