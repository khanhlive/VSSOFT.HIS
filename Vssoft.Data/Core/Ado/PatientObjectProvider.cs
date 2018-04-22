using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.ERP;

namespace Vssoft.Data.Core.Ado
{
    public class PatientObjectProvider : ProviderBase
    {
        public PatientObjectProvider() : base() { }

        public List<DIC_DTBN> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetDoiTuongBenhNhan");
                List<DIC_DTBN> dsdoituongbenhnhan = this.DataReaderToList(dt);
                return dsdoituongbenhnhan;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive DOI TUONG BENH NHAN", e);
                return null;
            }
        }

        public List<DIC_DTBN> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllDoiTuongBenhNhan");
                List<DIC_DTBN> dsdoituongbenhnhan = this.DataReaderToList(dt);
                return dsdoituongbenhnhan;
            }
            catch (Exception e)
            {
                log.Error("GetAll DOI TUONG BENH NHAN", e);
                return null;
            }
        }

        protected List<DIC_DTBN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_DTBN> dsdoituongbenhnhan = new List<DIC_DTBN>();
                while (dataReader.Read())
                {
                    DIC_DTBN doituongbenhnhan = new DIC_DTBN();
                    doituongbenhnhan.IDDTBN = Convert.ToByte(dataReader["IDDTBN"].ToString());
                    doituongbenhnhan.TenDTBN = dataReader["TenDTBN"].ToString();
                    doituongbenhnhan.MoTa = dataReader["MoTa"].ToString();
                    doituongbenhnhan.HinhThucThanhToan = Convert.ToByte(dataReader["HinhThucThanhToan"].ToString());
                    doituongbenhnhan.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsdoituongbenhnhan.Add(doituongbenhnhan);
                }
                dataReader.Close();
                return dsdoituongbenhnhan;
            }
            catch (Exception e)
            {
                log.Error("Generate DOI TUONG BENH NHAN", e);
                return null;
            }

        }

        public SqlResultType Insert(DIC_DTBN doituongbenhnhan)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDoiTuongBenhNhan",
                    new string[] { "@IDDTBN", "@TenDTBN", "@MoTa", "@Status", "@HinhThucThanhToan" },
                    new object[] { doituongbenhnhan.IDDTBN, doituongbenhnhan.TenDTBN, doituongbenhnhan.MoTa, doituongbenhnhan.Status, doituongbenhnhan.HinhThucThanhToan });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert DOI TUONG BENH NHAN", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_DTBN doituongbenhnhan)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDoiTuongBenhNhan",
                    new string[] { "@IDDTBN", "@TenDTBN", "@MoTa", "@Status", "@HinhThucThanhToan" },
                    new object[] { doituongbenhnhan.IDDTBN, doituongbenhnhan.TenDTBN, doituongbenhnhan.MoTa, doituongbenhnhan.Status, doituongbenhnhan.HinhThucThanhToan });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DOI TUONG BENH NHAN", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_DTBN doituongbenhnhan)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDoiTuongBenhNhan", new string[] { "@IDDTBN" }, new object[] { doituongbenhnhan.IDDTBN });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DOI TUONG BENH NHAN", e);
                return SqlResultType.Exception;
            }
        }
        
    }

}
