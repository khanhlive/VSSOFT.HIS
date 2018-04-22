using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.ERP;

namespace Vssoft.Data.Core.Ado
{
    public class ObjectProvider : ProviderBase
    {
        public ObjectProvider() : base() { }

        public List<DIC_DOITUONG> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetDoiTuong");
                List<DIC_DOITUONG> dsdoituong = this.DataReaderToList(dt);
                return dsdoituong;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive DOI TUONG", e);
                return null;
            }
        }

        public List<DIC_DOITUONG> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllDoiTuong");
                List<DIC_DOITUONG> dsdoituong = this.DataReaderToList(dt);
                return dsdoituong;
            }
            catch (Exception e)
            {
                log.Error("GetAll DOI TUONG", e);
                return null;
            }
        }

        protected List<DIC_DOITUONG> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_DOITUONG> dsdoituong = new List<DIC_DOITUONG>();
                while (dataReader.Read())
                {
                    DIC_DOITUONG doituong = new DIC_DOITUONG();
                    doituong.MaDoiTuong = dataReader["MaDoiTuong"].ToString();
                    doituong.TenDoiTuong = dataReader["TenDoiTuong"].ToString();
                    doituong.NhomDoiTuong = dataReader["NhomDoiTuong"].ToString();
                    doituong.MaMuc = DataConverter.StringToInt(dataReader["MaMuc"].ToString());
                    doituong.MucCu= DataConverter.ToInt(dataReader["MucCu"].ToString());
                    doituong.Status= DataConverter.StringToInt(dataReader["Status"].ToString());
                    doituong.VanChuyen = DataConverter.StringToInt(dataReader["VanChuyen"].ToString());
                    
                    dsdoituong.Add(doituong);
                }
                return dsdoituong;
            }
            catch (Exception e)
            {
                log.Error("Generate DOI TUONG", e);
                return null;
            }

        }

        public SqlResultType Insert(DIC_DOITUONG doituong)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertDoiTuong",
                    new string[] { "@MaDoiTuong", "@TenDoiTuong", "@NhomDoiTuong", "@MaMuc", "@MucCu", "@Status", "@VanChuyen" },
                    new object[] { doituong.MaDoiTuong, doituong.TenDoiTuong, doituong.NhomDoiTuong, doituong.MaMuc, doituong.MucCu, doituong.Status, doituong.VanChuyen });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Insert DOI TUONG", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Update(DIC_DOITUONG doituong)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateDoiTuong",
                    new string[] { "@MaDoiTuong", "@TenDoiTuong", "@NhomDoiTuong", "@MaMuc", "@MucCu", "@Status", "@VanChuyen" },
                    new object[] { doituong.MaDoiTuong, doituong.TenDoiTuong, doituong.NhomDoiTuong, doituong.MaMuc, doituong.MucCu, doituong.Status, doituong.VanChuyen });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Update DOI TUONG", e);
                return SqlResultType.Exception;
            }


        }

        public SqlResultType Delete(DIC_DOITUONG doituong)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteDoiTuong", new string[] { "@MaDoiTuong" }, new object[] { doituong.MaDoiTuong });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception e)
            {
                log.Error("Delete DOI TUONG", e);
                return SqlResultType.Exception;
            }
        }
    }
}
