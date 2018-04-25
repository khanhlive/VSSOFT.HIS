using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.ERP.ERP;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core.Ado
{
    public class ProvinceProvider : ProviderBase
    {
        public ProvinceProvider():base()
        {
        }
        public List<DIC_TINH> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetTinhThanh");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAllActive DANH MUC TINH THANH", ex);
                return null;
            }

        }

        protected List<DIC_TINH> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_TINH> dsChuyenKhoa = new List<DIC_TINH>();
                while (dataReader.Read())
                {
                    DIC_TINH tinhthanh = new DIC_TINH();
                    tinhthanh.MaTinh = dataReader["MaTinh"].ToString();
                    tinhthanh.TenTinh = dataReader["TenTinh"].ToString();
                    tinhthanh.Status = DataConverter.StringToInt(dataReader["Status"].ToString());
                    dsChuyenKhoa.Add(tinhthanh);
                }
                return dsChuyenKhoa;
            }
            catch (Exception ex)
            {
                log.Error("Generate DANH MUC TINH THANH", ex);
                return null;
            }
        }

        public List<DIC_TINH> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllTinhThanh");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll DANH MUC TINH THANH", ex);
                return null;
            }
        }

        public SqlResultType Insert(DIC_TINH chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertTinhThanh",
                    new string[] { "@MaTinh", "@TenTinh", "@Status" },
                    new object[] { chuyenKhoa.MaTinh, chuyenKhoa.TenTinh, chuyenKhoa.Status }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Insert DANH MUC TINH THANH", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Update(DIC_TINH chuyenKhoa)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateTinhThanh",
                    new string[] { "@MaTinh", "@TenTinh", "@Status" },
                    new object[] { chuyenKhoa.MaTinh, chuyenKhoa.TenTinh, chuyenKhoa.Status }
                    );
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Update DANH MUC TINH THANH", ex);
                return SqlResultType.Exception;
            }
        }

        public SqlResultType Delete(DIC_TINH tinhthanh)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("DeleteTinhThanh", new string[] { "@MaTinh" }, new object[] { tinhthanh.MaTinh });
                int kq = Convert.ToInt32(result);
                return this.GetResult(kq);
            }
            catch (Exception ex)
            {
                log.Error("Delete DANH MUC TINH THANH", ex);
                return SqlResultType.Exception;
            }
        }
    }
}
