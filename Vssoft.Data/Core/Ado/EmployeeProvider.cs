using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core.Ado
{
    public class EmployeeProvider : ProviderBase
    {
        
        public EmployeeProvider():base()
        {
        }

        public List<CanBo> GetAll()
        {
            this.sqlHelper.CommandType = CommandType.StoredProcedure;
            SqlDataReader dt = this.sqlHelper.ExecuteReader("GetAllCanBo");
            List<CanBo> dscanbo = new List<CanBo>();
            while (dt.Read())
            {
                CanBo cb = new CanBo();
                cb.BangCap = dt["BangCap"].ToString();
                cb.CapBac = dt["CapBac"].ToString();
                cb.ChucVu = dt["ChucVu"].ToString();
                cb.DiaChi = dt["DiaChi"].ToString();
                cb.FileAnh = dt["Image"].ToString();
                cb.GioiTinh = Convert.ToInt32(dt["GioiTinh"].ToString());
                cb.Khoa = Convert.ToBoolean(dt["KhoaChungTu"].ToString())?1:0;
                cb.KhoaChungTu = Convert.ToBoolean(dt["KhoaChungTu"].ToString());
                cb.MaCB = dt["MaCanBo"].ToString();
                cb.MaKP= Convert.ToInt32(dt["MaPhongBan"].ToString());
                cb.MaDT = dt["MaDanToc"].ToString();
                cb.SoDT = dt["SoDienThoai"].ToString();
                cb.TenCB = dt["TenCanBo"].ToString();
                cb.TenKP = dt["TenPhongBan"].ToString();
                cb.TenDT = dt["TenDanToc"].ToString();
                dscanbo.Add(cb);
            }
            return dscanbo;
        }
    }
}
