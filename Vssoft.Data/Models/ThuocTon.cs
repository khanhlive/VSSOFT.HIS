using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vssoft.Data.Models
{
    public class ThuocTon
    {
        private string tendv;
        int makho;
        private int madv;
        private double soluong;
        private double dongia;
        public int MaKho
        {
            set { makho = value; }
            get { return makho; }
        }
        public string TenDV
        {
            set { tendv = value; }
            get { return tendv; }
        }
        public int MaDV
        {
            set { madv = value; }
            get { return madv; }
        }
        public double DonGia
        {
            set { dongia = value; }
            get { return dongia; }
        }
        public double SoLuong
        {
            set { soluong = value; }
            get { return soluong; }
        }
    }
}
