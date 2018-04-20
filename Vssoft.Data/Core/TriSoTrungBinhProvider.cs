using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class TriSoTrungBinhProvider
    {
        public static string[] GetTriSoBinhThuong(Hospital DataContect, string strTimkiem, List<string> TenTNRG, int ploaiTKiem)
        {
            string[] arrTSBT = new string[5] { "", "", "", "", "" };
            List<DichVuct> q = new List<DichVuct>();
            if (ploaiTKiem == 0)
            {
                int STT = Convert.ToInt32(strTimkiem);
                q = (from tenrg in TenTNRG
                     join tnhomdv in DataContect.TieuNhomDVs on tenrg equals tnhomdv.TenRG
                     join dv in DataContect.DichVus on tnhomdv.IdTieuNhom equals dv.IdTieuNhom
                     join dvct in DataContect.DichVucts.Where(p => p.STT == STT) on dv.MaDV equals dvct.MaDV
                     select dvct).ToList();
            }
            else
            {
                q = (from dvct in DataContect.DichVucts.Where(p => p.MaDVct == strTimkiem)
                     select dvct).ToList();
            }
            foreach (var item in q)
            {
                string _nam = "", _nu = "";
                if (!string.IsNullOrEmpty(item.TSBTnu))
                {
                    if (string.IsNullOrEmpty(item.TSnuTu))
                    {
                        _nu += item.TSBTnu + item.TSnuDen;
                    }
                    else if (string.IsNullOrEmpty(item.TSnuDen))
                    {
                        _nu += item.TSBTnu + item.TSnuTu;
                    }
                    else
                    {
                        _nu += item.TSBTnu + "(" + item.TSnuTu + " - " + item.TSnuDen + ")";
                    }
                }

                if (!string.IsNullOrEmpty(item.TSBTn))
                {
                    if (string.IsNullOrEmpty(item.TSnTu))
                    {
                        _nam += item.TSBTn + item.TSnDen;
                    }
                    else if (string.IsNullOrEmpty(item.TSnDen))
                    {
                        _nam += item.TSBTn + item.TSnTu;
                    }
                    else
                    {
                        _nam += item.TSBTn + "(" + item.TSnTu + " - " + item.TSnDen + ")";
                    }
                }
                arrTSBT[0] = item.TenDVct;
                arrTSBT[1] = item.DonVi;
                arrTSBT[2] = item.TSBT;
                arrTSBT[3] = _nam;
                arrTSBT[4] = _nu;
                break;
            }
            return arrTSBT;
        }
    }
}
