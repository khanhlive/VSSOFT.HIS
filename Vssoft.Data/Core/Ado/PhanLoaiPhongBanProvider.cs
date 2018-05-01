using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.Data.Extension;
using Vssoft.Data.ERP.Dictionary;

namespace Vssoft.Data.Core.Ado
{
    public class PhanLoaiPhongBanProvider : ProviderBase
    {
        public PhanLoaiPhongBanProvider():base()
        {
        }
        public List<DIC_PHANLOAIPHONGBAN> GetAllActive()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetPhanLoaiPhongBan");
                List<DIC_PHANLOAIPHONGBAN> dsphanloaiphongban = this.DataReaderToList(dt);
                return dsphanloaiphongban;
            }
            catch (Exception e)
            {
                log.Error("GetAllActive PHAN LOAI PHONG BAN", e);
                return null;
            }
        }

        protected List<DIC_PHANLOAIPHONGBAN> DataReaderToList(SqlDataReader dataReader)
        {
            try
            {
                List<DIC_PHANLOAIPHONGBAN> dsphanloaiphongban = new List<DIC_PHANLOAIPHONGBAN>();
                while (dataReader.Read())
                {
                    DIC_PHANLOAIPHONGBAN phanloaiphongban = new DIC_PHANLOAIPHONGBAN();
                    phanloaiphongban.ID = DataConverter.StringToInt(dataReader["ID"].ToString());
                    phanloaiphongban.PhanLoai = dataReader["PhanLoai"].ToString();
                    phanloaiphongban.Status = Convert.ToBoolean(dataReader["Status"].ToString());
                    
                    dsphanloaiphongban.Add(phanloaiphongban);
                }
                return dsphanloaiphongban;
            }
            catch (Exception e)
            {
                log.Error("Generate PHAN LOAI PHONG BAN", e);
                return null;
            }

        }

        public List<DIC_PHANLOAIPHONGBAN> GetAll()
        {
            try
            {
                this.sqlHelper.CommandType = CommandType.StoredProcedure;
                SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllPhanLoaiPhongBan");
                return this.DataReaderToList(dt);
            }
            catch (Exception ex)
            {
                log.Error("GetAll PHAN LOAI PHONG BAN", ex);
                return null;
            }
        }
    }
}
