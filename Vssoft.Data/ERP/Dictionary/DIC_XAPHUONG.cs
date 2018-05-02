namespace Vssoft.Data.ERP.Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Vssoft.Data.Enum;
    using Vssoft.Data.Extension;
    public class DIC_XAPHUONG : EntityBase<DIC_XAPHUONG>
    {
        public DIC_XAPHUONG()
        {
            this.StoreGetAll = "GetAllXaPhuong";
            this.StoreGetAllActive = "GetXaPhuong";
        }
        [ValueMember]
        public string MaXa { get; set; }
        [DisplayMember]
        public string MaHuyen { get; set; }
        public string TenXa { get; set; }
        public string TenHuyen { get; set; }
        public string MaTinh { get; set; }
        public string TenTinh { get; set; }
        public int Status { get; set; }

        public override SqlResultType Delete()
        {
            return this.Delete(this);
        }

        public override SqlResultType Delete(DIC_XAPHUONG xa)
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
            return this.Insert(this);
        }

        public override SqlResultType Insert(DIC_XAPHUONG xa)
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

        public override SqlResultType Update()
        {
            return this.Update(this);
        }

        public override SqlResultType Update(DIC_XAPHUONG xa)
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

        protected override IEnumerable<DIC_XAPHUONG> DataReaderToList(SqlDataReader dataReader)
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
                    xaphuong.TenTinh = dataReader["TenTinh"].ToString();
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
    }
}
