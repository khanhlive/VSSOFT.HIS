using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Enum
{
    public class LoaiPhongBan
    {
        public static string[] PhongBan = new string[] { "Cận lâm sàng", "Chức năng", "Lâm sàng", "Phòng khám", "Khoa dược", "Admin", "Kế toán", "Hành chính", "Tủ trực", "PK khu vực", "Xã phường", "BHXH " };
    }
    public class HinhThucThanhToan
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public List<HinhThucThanhToan> GetList()
        {
            List<HinhThucThanhToan> list = new List<HinhThucThanhToan>();
            list.Add(new HinhThucThanhToan { Name = "Miễn", Value = 0 });
            list.Add(new HinhThucThanhToan { Name = "BHYT", Value = 1 });
            list.Add(new HinhThucThanhToan { Name = "Thanh toán toàn bộ", Value = 2 });
            list.Add(new HinhThucThanhToan { Name = "Khám sức khỏe", Value = 3 });
            return list;
        }

    }
    public class LookUpEditItem
    {
        public LookUpEditItem()
        {
        }
        public LookUpEditItem(object value,object text)
        {
            this.Value = value;
            this.Text = text;
        }

        public object Value { get; set; }
        public object Text { get; set; }
    }
}
