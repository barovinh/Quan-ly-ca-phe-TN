using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class NhanVienDAO : DbContext
    {
        public List<NhanVien> getDSKH()
        {
            List<NhanVien> list = new List<NhanVien>();

            Cmd.Parameters.Clear();
            Cmd.CommandText = "SELECT*FROM NHANVIEN";
            Reader = Cmd.ExecuteReader();
            while(Reader.Read())
            {
                NhanVien kh = new NhanVien();
                kh.ChucVu = Reader["ChucVu"].ToString();
                kh.TenNV = Reader["TenNV"].ToString();
                kh.SDT = Reader["SDT"].ToString();
                kh.GioiTinh = Reader["GioiTinh"].ToString();
                kh.MaNV = Reader["MaNV"].ToString();
                DateTime ngaySinh;

                if (DateTime.TryParse(Reader["NgaySinh"].ToString(), out ngaySinh))
                {
                    kh.NgaySinh = ngaySinh;
                }
                list.Add(kh);
            }
            return list;
        }
        public NhanVien searchNhanVien(string ten)
        {
            NhanVien kh = new NhanVien();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "select NHANVIEN.MaNV,TenNV,GioiTinh,ChucVu,NgaySinh,SDT from NHANVIEN,TaiKhoan where nhanvien.MaNV = TaiKhoan.MaNV and TaiKhoan.TenDangNhap = @TenDangNhap";
            Cmd.Parameters.AddWithValue("@TenDangNhap", ten);
            Reader = Cmd.ExecuteReader();
            if(Reader.Read())
            {
                kh.ChucVu = Reader["ChucVu"].ToString();
                kh.TenNV = Reader["TenNV"].ToString();
                kh.SDT = Reader["SDT"].ToString();
                kh.GioiTinh = Reader["GioiTinh"].ToString();
                kh.MaNV = Reader["MaNV"].ToString();
                DateTime ngaySinh;

                if (DateTime.TryParse(Reader["NgaySinh"].ToString(), out ngaySinh))
                {
                    kh.NgaySinh = ngaySinh;
                }
                return kh;
            }
            return null;
        }
        public NhanVien searchMaNhanVien(string ma)
        {
            open();
            NhanVien kh = new NhanVien();
            Cmd.Parameters.Clear();
            Cmd.CommandText = "SELECT*FROM NHANVIEN WHERE MANV=@MANV";
            Cmd.Parameters.AddWithValue("@MANV", ma);
            Reader = Cmd.ExecuteReader();
            if (Reader.Read())
            {
                kh.ChucVu = Reader["ChucVu"].ToString();
                kh.TenNV = Reader["TenNV"].ToString();
                kh.SDT = Reader["SDT"].ToString();
                kh.GioiTinh = Reader["GioiTinh"].ToString();
                kh.MaNV = Reader["MaNV"].ToString();
                DateTime ngaySinh;

                if (DateTime.TryParse(Reader["NgaySinh"].ToString(), out ngaySinh))
                {
                    kh.NgaySinh = ngaySinh;
                }
                close();
                return kh;
            }
            return null;
        }
        public int ThemNhanVien(NhanVien nv)
        {
            open();
            try
            {
                string sql = "INSERT INTO NHANVIEN VALUES(@TenNV,@GioiTinh,@NgaySinh,@ChucVu,@SDT)";
                Cmd.CommandText = sql;
                Cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                Cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                Cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                Cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                Cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                close();
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
           
     
        }
        // LẤY MÃ NHÂN VIÊN TIẾP THEO
        public int getNextID()
        {
            open();
            Cmd.Parameters.Clear();
            Cmd.CommandText = " DECLARE @NextInvoiceID INT;SET @NextInvoiceID = ISNULL((SELECT MAX(MaNV) FROM NHANVIEN), 0) +1; SELECT @NextInvoiceID AS MANV; ";
            int kq = 0;
            Reader = Cmd.ExecuteReader();
            if (Reader.Read())
            {
                kq = int.Parse(Reader["MANV"].ToString());
            }
            close(); 
            return kq;
        }
    }
}
