using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class ChiTietHoaDonDAO :DbContext
    {
        public int ThemChiTietHD(ChiTietHoaDon a)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "insert into CHITIETHOADON values(@MaHD,@MaMH,@SoLuong)";
            Cmd.Parameters.AddWithValue("@MaHD", a.MaHD);
            Cmd.Parameters.AddWithValue("@MaMH", a.MaMH);
            Cmd.Parameters.AddWithValue("@SoLuong", a.SoLuong);
            return Cmd.ExecuteNonQuery();
        }

    }
}
