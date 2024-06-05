using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class MatHang
    {
        public string MaMH { get; set; }
        public string TenMH{ get; set; }
        public float GiaTien { get; set; }
        public string Loai { get; set; }
        public string HinhAnh { get; set; }
        public string DuongDan { get; set; }
        public int SoLuong { get; set; }
        public MatHang()
        {
            HinhAnh = "";
        }
    }
}
