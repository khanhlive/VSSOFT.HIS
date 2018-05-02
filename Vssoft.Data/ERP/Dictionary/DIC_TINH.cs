using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vssoft.Data.Enum;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;
namespace Vssoft.Data.ERP.Dictionary
{

    public class DIC_TINH : EntityBase<DIC_TINH>
    {
        
        public DIC_TINH()
        {
            this.StoreGetAllActive = "GetTinhThanh";
            this.StoreGetAll = "GetAllTinhThanh";
        }
        [ValueMember]
        public string MaTinh { get; set; }
        [DisplayMember]
        public string TenTinh { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_TINH tinhthanh)
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

        public override SqlResultType Exsist(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Get(object key)
        {
            throw new NotImplementedException();
        }

        public override SqlResultType Insert()
        {
            return this.Delete(this);
        }

        public override SqlResultType Insert(DIC_TINH tinhthanh)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("InsertTinhThanh",
                    new string[] { "@MaTinh", "@TenTinh", "@Status" },
                    new object[] { tinhthanh.MaTinh, tinhthanh.TenTinh, tinhthanh.Status }
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

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_TINH tinhthanh)
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                object result = this.sqlHelper.ExecuteScalar("UpdateTinhThanh",
                    new string[] { "@MaTinh", "@TenTinh", "@Status" },
                    new object[] { tinhthanh.MaTinh, tinhthanh.TenTinh, tinhthanh.Status }
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

        protected override IEnumerable<DIC_TINH> DataReaderToList(SqlDataReader dataReader)
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
    }
}
