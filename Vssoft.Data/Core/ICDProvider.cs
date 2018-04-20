using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssoft.ERP.Models;

namespace Vssoft.Data.Core
{
    public class ICDProvider
    {
        public static string GetICDstr(string maBenh)
        {
            for (int i = 0; i < maBenh.Length; i++)
            {
                int index = maBenh.LastIndexOf(';');
                if (maBenh.Length > 1 && maBenh.Length - 1 == index)
                    maBenh = maBenh.Substring(0, maBenh.Length - 1);
                if (i >= maBenh.Length)
                    break;
            }
            string _strIcdKhac = "";
            if (maBenh != "")
            {
                string[] _arr = maBenh.Split(';');

                for (int i = 0; i < _arr.Length; i++)
                {
                    if (_arr[i].Length > 1)
                    {

                        if (i == _arr.Length - 1)
                        {
                            _strIcdKhac += _arr[i];
                        }
                        else
                        {
                            _strIcdKhac += _arr[i] + ";";
                        }
                    }
                }
            }
            return _strIcdKhac;
        }

        public static string[] getMaICDarr(Hospital _data, int _mabn, int _kieu)
        {
            string[] maicd = new string[6] { "", "", "", "", "", "0" };

            var a = _data.BNKBs.Where(p => p.MaBNhan == _mabn).OrderByDescending(p => p.IDKB).ToList();
            if (a.Count > 0)
            {
                List<string> l_ICD = new List<string>();
                List<string> l_chandoan = new List<string>();
                string makp = "", mack = "0", ngaykham = "";

                switch (_kieu)
                {
                    case 0:
                        int idmax = a.Max(p => p.IDKB);
                        foreach (var b in a.Where(p => p.IDKB == idmax))
                        {
                            if (!string.IsNullOrEmpty(b.MaICD))
                                l_ICD.Add(b.MaICD);
                            if (!string.IsNullOrEmpty(b.MaICD2))
                                l_ICD.Add(b.MaICD2);
                            if (!string.IsNullOrEmpty(b.ChanDoan))
                                l_chandoan.Add(b.ChanDoan);
                            if (!string.IsNullOrEmpty(b.BenhKhac))
                                l_chandoan.Add(b.BenhKhac);
                            makp = b.MaKP.ToString();
                            mack = b.MaCK.ToString();
                            ngaykham = b.NgayKham.ToString();
                        }
                        l_ICD = l_ICD.Distinct().ToList();
                        l_chandoan = l_chandoan.Distinct().ToList();

                        maicd[0] = string.Join(";", l_ICD);
                        maicd[1] = string.Join(";", l_chandoan);
                        maicd[2] = makp;
                        maicd[3] = ngaykham;
                        maicd[4] = "";
                        maicd[5] = mack;
                        break;
                    case 1:
                        int idmin = a.Min(p => p.IDKB);
                        foreach (var b in a.Where(p => p.IDKB == idmin))
                        {
                            if (!string.IsNullOrEmpty(b.MaICD))
                                l_ICD.Add(b.MaICD);
                            if (!string.IsNullOrEmpty(b.MaICD2))
                                l_ICD.Add(b.MaICD2);
                            if (!string.IsNullOrEmpty(b.ChanDoan))
                                l_chandoan.Add(b.ChanDoan);
                            if (!string.IsNullOrEmpty(b.BenhKhac))
                                l_chandoan.Add(b.BenhKhac);
                            makp = b.MaKP.ToString();
                            mack = b.MaCK.ToString();
                            ngaykham = b.NgayKham.ToString();
                        }
                        l_ICD = l_ICD.Distinct().ToList();
                        l_chandoan = l_chandoan.Distinct().ToList();
                        maicd[0] = string.Join(";", l_ICD);
                        maicd[1] = string.Join(";", l_chandoan);

                        break;
                    case 2:
                        int idmaxfull = a.Max(p => p.IDKB);

                        foreach (var b in a.Where(p => p.IDKB == idmaxfull))
                        {
                            if (!string.IsNullOrEmpty(b.MaICD))
                                l_ICD.Add(b.MaICD);
                            if (!string.IsNullOrEmpty(b.MaICD2))
                                l_ICD.Add(b.MaICD2);
                            makp = b.MaKP.ToString();
                            mack = b.MaCK.ToString();
                            ngaykham = b.NgayKham.ToString();
                        }
                        foreach (var b in a)
                        {

                            if (!string.IsNullOrEmpty(b.ChanDoan))
                                l_chandoan.Add(b.ChanDoan);
                            if (!string.IsNullOrEmpty(b.BenhKhac))
                                l_chandoan.Add(b.BenhKhac);
                        }
                        l_ICD = l_ICD.Distinct().ToList();
                        l_chandoan = l_chandoan.Distinct().ToList();
                        maicd[0] = string.Join(";", l_ICD);
                        maicd[1] = string.Join(";", l_chandoan);

                        break;
                    case 3:
                        int idminfull = a.Min(p => p.IDKB);

                        foreach (var b in a.Where(p => p.IDKB == idminfull))
                        {
                            if (!string.IsNullOrEmpty(b.MaICD))
                                l_ICD.Add(b.MaICD);
                            if (!string.IsNullOrEmpty(b.MaICD2))
                                l_ICD.Add(b.MaICD2);
                            makp = b.MaKP.ToString();
                            mack = b.MaCK.ToString();
                            ngaykham = b.NgayKham.ToString();
                        }
                        a = a.OrderBy(p => p.IDKB).ToList();
                        foreach (var b in a)
                        {

                            if (!string.IsNullOrEmpty(b.ChanDoan))
                                l_chandoan.Add(b.ChanDoan);
                            if (!string.IsNullOrEmpty(b.BenhKhac))
                                l_chandoan.Add(b.BenhKhac);
                        }
                        l_ICD = l_ICD.Distinct().ToList();
                        l_chandoan = l_chandoan.Distinct().ToList();
                        maicd[0] = string.Join(";", l_ICD);
                        maicd[1] = string.Join(";", l_chandoan);

                        break;
                    case 4:

                        List<string> ICDfull = new List<string>();
                        List<string> _chandoanfull = new List<string>();
                        foreach (var b in a)
                        {
                            if (!string.IsNullOrEmpty(b.MaICD))
                                ICDfull.Add(b.MaICD);
                            if (!string.IsNullOrEmpty(b.MaICD2))
                            {
                                List<string> lmaICD2 = b.MaICD2.Split(';').ToList();
                                foreach (string maicd2 in lmaICD2)
                                {
                                    ICDfull.Add(maicd2.Trim());
                                }
                            }
                            // ICDfull.Add(b.MaICD2);
                            if (!string.IsNullOrEmpty(b.ChanDoan))
                                _chandoanfull.Add(b.ChanDoan);
                            if (!string.IsNullOrEmpty(b.BenhKhac))
                            {
                                List<string> lchandoan2 = b.BenhKhac.Split(';').ToList();
                                foreach (string chandoan2 in lchandoan2)
                                {
                                    _chandoanfull.Add(chandoan2.Trim());
                                }

                            }
                            //if (!string.IsNullOrEmpty(b.BenhKhac))
                            //    _chandoanfull.Add(b.BenhKhac);
                        }
                        ICDfull = ICDfull.Distinct().ToList();
                        mack = a.First().MaCK.ToString();
                        _chandoanfull = _chandoanfull.Distinct().ToList();
                        maicd[0] = string.Join(";", ICDfull);
                        maicd[1] = string.Join(";", _chandoanfull);
                        makp = a.First().MaKP.ToString();
                        ngaykham = a.First().NgayKham.Value.ToString();
                        mack = a.First().MaCK.ToString();
                        break;
                    case 5: // lấy tất cả các ICD, Chẩn đoán cuối cùng làm chính

                        List<string> ICDfull5 = new List<string>();
                        List<string> _chandoanfull5 = new List<string>();
                        foreach (var b in a)
                        {
                            if (!string.IsNullOrEmpty(b.MaICD))
                                ICDfull5.Add(b.MaICD);
                            if (!string.IsNullOrEmpty(b.MaICD2))
                            {
                                List<string> lmaICD2 = b.MaICD2.Split(';').ToList();
                                foreach (string maicd2 in lmaICD2)
                                {
                                    ICDfull5.Add(maicd2.Trim());
                                }
                                // ICDfull5.Add(b.MaICD2);
                            }
                        }
                        _chandoanfull5.Add(a.First().ChanDoan);
                        _chandoanfull5.Add(a.First().BenhKhac);
                        ICDfull5 = ICDfull5.Distinct().ToList();
                        _chandoanfull5 = _chandoanfull5.Distinct().ToList();
                        maicd[0] = string.Join(";", ICDfull5);
                        maicd[1] = string.Join(";", _chandoanfull5);
                        makp = a.First().MaKP.ToString();
                        ngaykham = a.First().NgayKham.Value.ToString();
                        mack = a.First().MaCK.ToString();
                        break;
                }
                maicd[0] = ICDProvider.GetICDstr(maicd[0]);
                maicd[1] = ICDProvider.GetICDstr(maicd[1]);
                maicd[2] = makp;
                maicd[3] = ngaykham;
                maicd[4] = "";
                maicd[5] = mack;
            }
            return maicd;
        }

        public static string[] SplitICD(string arr)
        {
            string[] maicd = new string[20];
            for (int i = 0; i < 20; i++)
            {
                maicd[i] = "";
            }
            if (!string.IsNullOrEmpty(arr))
            {
                string[] icd2 = arr.Split(';');
                for (int i = 0; i < icd2.Length; i++)
                {
                    if (icd2[i] != null)
                        maicd[i] = icd2[i];
                }
            }
            return maicd;
        }
    }
}
