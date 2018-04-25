using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.ERP;


namespace Vssoft.Data.Core.Ado
{
    public class RuralCommuneProvider : ProviderBase
    {
        public List<DIC_XAPHUONG> GetAllXaByHuyen(string mahuyen)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetXaPhuongByMaHuyen", new string[] { "@MaHuyen" }, new object[] { mahuyen });
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllHuyenByTinh DANH MUC XA/PHUONG", ex);
                return null;
            }

        }

        public List<DIC_XAPHUONG> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetXaPhuong");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllActive DANH MUC XA/PHUONG", ex);
                return null;
            }

        }

        protected List<DIC_XAPHUONG> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_XAPHUONG> dsChuyenKhoa = new List<DIC_XAPHUONG>();
                while (dataReader.Read())
                {
                    DIC_XAPHUONG xaphuong = new DIC_XAPHUONG();
                    xaphuong.MaXa = dataReader["MaXa"].ToString();
                    xaphuong.MaHuyen = dataReader["MaHuyen"].ToString();
                    xaphuong.TenXa = dataReader["TenXa"].ToString();
                    xaphuong.TenHuyen = dataReader["TenHuyen"].ToString();
                    xaphuong.MaTinh = dataReader["MaTinh"].ToString();
                    xaphuong.TenTinh= dataReader["TenTinh"].ToString();
                    xaphuong.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(xaphuong);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC XA/PHUONG", ex);
                return null;
            }
        }

        public List<DIC_XAPHUONG> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllXaPhuong");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll DANH MUC XA/PHUONG", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_XAPHUONG xa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertXaPhuong",
                    new string[] { "@MaXa", "@MaHuyen", "@TenXa", "@Status" },
                    new object[] { xa.MaXa, xa.MaHuyen, xa.TenXa, xa.Status }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH MUC XA/PHUONG", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Update(DIC_XAPHUONG xa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateXaPhuong",
                     new string[] { "@MaXa", "@MaHuyen", "@TenXa", "@Status" },
                    new object[] { xa.MaXa, xa.MaHuyen, xa.TenXa, xa.Status }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update DANH MUC XA/PHUONG", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Delete(DIC_XAPHUONG xa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteXaPhuong", new string[] { "@MaXa" }, new object[] { xa.MaXa });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete DANH MUC XA/PHUONG", ex);
                return SqlResultType.Exception;
            }
        }
    }
}
