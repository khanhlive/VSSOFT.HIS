using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class PermissionProvider
    {
        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_macb">mã cán bộ trong dữ liệu</param>
        /// <param name="_macbxoa">mã cán bộ muốn thực hiện sửa-xóa</param>
        /// <returns></returns>
        public static bool isSuaXoa(Hospital _data, string _macb, string _macbxoa)
        {
            if (_macb == _macbxoa)
            {
                return true;
            }
            else
            {
                if (Common.PLoaiKP == "Admin" && Common.CapDo == 9)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        public static bool[] CheckQuyenHan(string formReportName)
        {
            Hospital data = new Hospital();
            int idForm = new DanhSachBaocao().getIDForm(formReportName);
            List<Permission> list = data.Permissions.ToList();
            var q = (from l in list select l).Where(p => p.ID == idForm).Where(p => p.TenDN == Common.TenDN).ToList();
            if (q.Count <= 0)
            {
                if (idForm == 910)
                    return new bool[] { false, false, false, false, false };
                else
                    return new bool[] { true, true, true, true, true };
            }
            // return new bool[] { false, false, false, false };
            return new bool[] { q.First().C_New, q.First().C_Edit, q.First().C_Delete, q.First().C_View, q.First().C_Print };

        }

        public static bool[] CheckQuyenFalse(string tenform_Bc)
        {
            Hospital data = new Hospital();
            int idForm = new DanhSachBaocao().getIDForm(tenform_Bc);
            List<Permission> list = data.Permissions.ToList();
            var q = (from l in list select l).Where(p => p.ID == idForm).Where(p => p.TenDN == Common.TenDN).ToList();
            if (q.Count <= 0)
            {
                return new bool[] { false, false, false, false, false };
            }
            return new bool[] { q.First().C_New, q.First().C_Edit, q.First().C_Delete, q.First().C_View, q.First().C_Print };

        }
    }
}
