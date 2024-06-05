using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public NhanVien nv { get; set; }
        public TaiKhoan()
        {
            TenDangNhap = "";
            MatKhau = "";
            nv = new NhanVien();
        }
    }
}
