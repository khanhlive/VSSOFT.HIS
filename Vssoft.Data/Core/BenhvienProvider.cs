using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class BenhvienProvider
    {
        public static int GetHangBenhVien(string mabv)
        {
            try
            {
                int hang = 3;
                Hospital _dataContext = new Hospital();
                string tuyen = "";
                var hangBV = _dataContext.BenhViens.Where(p => p.MaBV == mabv).ToList();
                if (hangBV.Count > 0 && hangBV.First().HangBV != null)
                {
                    hang = hangBV.First().HangBV.Value;
                    tuyen = hangBV.First().TuyenBV.Trim();
                }
                //  Common.MaTinh = "12";
                if ((Common.MaTinh == "12" && (Common.MaBV != "12128" && Common.MaBV != "12038")) || Common.MaBV == "27022" || Common.MaBV == "27021" || Common.MaBV == "20001")
                {
                    switch (tuyen)
                    {
                        case "A":
                            hang = 1;
                            break;
                        case "B":
                            hang = 2;
                            break;
                        case "C":
                            hang = 3;
                            break;
                        case "D":
                            hang = 4;
                            break;

                    }

                }
                return hang;
            }
            catch (Exception)
            {

                return 3;
            }
        }

        public static int GetHangBVCK(string mabv)
        {
            try
            {
                int hang = 3;
                Hospital _dataContext = new Hospital();
                string tuyen = "";
                var hangBV = _dataContext.BenhViens.Where(p => p.MaBV == mabv).ToList();
                if (hangBV.Count > 0 && hangBV.First().HangBV != null)
                {
                    hang = hangBV.First().HangBV.Value;
                    tuyen = hangBV.First().TuyenBV.Trim();
                }
                if (Common.MaBV == "04247" || Common.MaBV == "12128" || Common.MaBV == "12038" || Common.MaBV == "30280" || Common.MaBV == "27001" || Common.MaBV == "30340" || Common.MaBV == "27183" || Common.MaBV == "04256")
                {
                    switch (tuyen)
                    {
                        case "A":
                            hang = 1;
                            break;
                        case "B":
                            hang = 2;
                            break;
                        case "C":
                            hang = 3;
                            break;
                        case "D":
                            hang = 4;
                            break;

                    }

                }
                return hang;
            }
            catch (Exception)
            {

                return 3;
            }
        }
    }
}
