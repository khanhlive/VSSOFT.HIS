using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Core
{
    public class DanhSachBaocao
    {
        public List<Library_CLS.Lis_His.limenu> _listBC = new List<Library_CLS.Lis_His.limenu>();//FormThamSo.us_menubc.SetDM();
        public int getIDForm(string formName)
        {
            int rs = 0;
            var q = _listBC.ToList().Where(p => p.TenBC == formName).ToList();
            if (q.Count > 0)
                rs = Convert.ToInt32(q.First().ID);
            return rs;
        }
    }
}
