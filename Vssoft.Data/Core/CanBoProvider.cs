using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class CanBoProvider
    {
        public static string GetName(Hospital _data, string _macb)
        {
            string _ten = "";
            var cb = _data.CanBoes.Where(p => p.MaCB == _macb).ToList();
            if (cb.Count > 0)
            {
                if (!string.IsNullOrEmpty(cb.First().CapBac))
                {
                    _ten = cb.First().CapBac + ": " + cb.First().TenCB;
                }
                else
                {
                    _ten = cb.First().TenCB;
                }
            }
            return _ten;
        }
    }
}
