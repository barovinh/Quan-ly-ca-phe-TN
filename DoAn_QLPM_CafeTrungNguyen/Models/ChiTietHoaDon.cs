using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class ChiTietHoaDon
    {
        public string MaHD { get; set; } 
        public DateTime dateTime { get; set; }
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public int MaChiNhanh { get; set; }
        public string TenChiNhanh { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public double SoLuong { get; set; }
        public double GiaTien { get; set; }
        public double TongTien { get; set; }
     
        public ChiTietHoaDon()
        {
            MaHD = "";
            MaMH = "";
            SoLuong = 0;
        }
        

    }
}
