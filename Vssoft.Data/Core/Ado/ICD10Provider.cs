using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;
using Dapper;
using System.Linq;

namespace Vssoft.Data.Core.Ado
{
    public class ICD10Provider : ProviderBase
    {
        public ICD10Provider() : base() { }

        public List<DIC_ICD10> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetICD10");
                List<DIC_ICD10> data = this.DataReaderToList(dt);
                return data;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive ICD10", e);
                return null;
            }
        }

        public List<DIC_ICD10> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllICD10");
                List<DIC_ICD10> dsdoituong = this.DataReaderToList(dt);
                return dsdoituong;
            }
            catch (Exception e)
            {
                log.Error("GetAll ICD10", e);
                return null;
            }
        }

        protected List<DIC_ICD10> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_ICD10> data = new List<DIC_ICD10>();
                while (dataReader.Read())
                {
                    DIC_ICD10 icd10 = new DIC_ICD10();
                    icd10.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    icd10.MaICD = dataReader["MaICD"].ToString();
                    icd10.TenICD = dataReader["TenICD"].ToString();
                    icd10.MaChuongBenh = (dataReader["MaChuongBenh"].ToString());
                    icd10.TenChuongBenh = (dataReader["TenChuongBenh"].ToString());
                    icd10.TenWHO = dataReader["TenWHO"].ToString();
                    icd10.TenWHOe = dataReader["TenWHOe"].ToString();
                    icd10.Status = DataConverter.StringToInt(dataReader["Status"].ToString());

                    data.Add(icd10);
                }
                return data;
            }
            catch (Exception e)
            {
                log.Error("Generate ICD10", e);
                return null;
            }

        }

        public SqlResultType Insert(DIC_ICD10 icd10)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertICD10",
                    new string[] { "@MaICD", "@TenICD", "@Status", "@MaChuongBenh", "@TenChuongBenh", "@TenWHO", "@TenWHOe" },
                    new object[] { icd10.MaICD, icd10.TenICD, icd10.Status, icd10.MaChuongBenh, icd10.TenChuongBenh, icd10.TenWHO, icd10.TenWHOe });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert ICD10", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_ICD10 icd10)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateICD10",
                    new string[] { "@MaICD", "@TenICD", "@Status", "@MaChuongBenh", "@TenChuongBenh", "@TenWHO", "@TenWHOe" },
                    new object[] { icd10.MaICD, icd10.TenICD, icd10.Status, icd10.MaChuongBenh, icd10.TenChuongBenh, icd10.TenWHO, icd10.TenWHOe });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update ICD10", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_ICD10 icd10)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteICD10", new string[] { "@ID" }, new object[] { icd10.ID });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete ICD10", e);
                return SqlResultType.Exception;
            }
        }

        public DataTable GetList()
        {
            return this.sqlHelper.ExecuteDataTable("GetAllICD10");
        }
        public IEnumerable<DIC_ICD10> GetByDapper()
        {
            using (IDbConnection dbConnection=new SqlConnection(this.sqlHelper.ConnectionString))
            {
                IEnumerable<DIC_ICD10> icds = dbConnection.Query<DIC_ICD10>("GetAllICD10", commandType: CommandType.StoredProcedure).ToList();
                return icds;
            }
        }

        ~ICD10Provider()
        {
            this.sqlHelper = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
