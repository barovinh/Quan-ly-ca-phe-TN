using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class TaiKhoanDAO : DbContext
    {
      
        public TaiKhoan getTK(TaiKhoan a)
        {
            TaiKhoan tk = new TaiKhoan();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "SELECT*FROM TaiKhoan where TenDangNhap = @TenDangNhap";
            Cmd.Parameters.AddWithValue("@TenDangNhap", a.TenDangNhap);
            Reader = Cmd.ExecuteReader();
            if(Reader.Read())
            {
                tk.TenDangNhap = Reader["TenDangNhap"].ToString();
                tk.MatKhau = Reader["MatKhau"].ToString();
                tk.nv.ChucVu = Reader["MaCV"].ToString();
                tk.nv.MaNV = (Reader["MaNV"].ToString());
                return tk;
            }
            return null;
        }
        public NhanVien getThongTinTK(string user)
        {
            NhanVien kh = new NhanVien();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "  select * from NHANVIEN, TAIKHOAN  WHERE NHANVIEN.MaNV = TaiKhoan.MaNV and TaiKhoan.TenDangNhap = @TenDangNhap";
            Cmd.Parameters.AddWithValue("@TenDangNhap", user);
            Reader = Cmd.ExecuteReader();
            if (Reader.Read())
            {
                kh.ChucVu = Reader["ChucVu"].ToString();
                kh.TenNV = Reader["TenNV"].ToString();
                kh.SDT = Reader["SDT"].ToString();
                kh.GioiTinh = Reader["GioiTinh"].ToString();
                kh.MaNV = Reader["MaNV"].ToString();
                return kh;
            }
            return null;
        }
    }
}

