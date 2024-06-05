using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int Diem { get; set; }

        public KhachHang()
        {
            TenKH = "";
            SDT = "";
            Email = "";
            DiaChi = "";
            Diem = 0;
        }


    }
}
