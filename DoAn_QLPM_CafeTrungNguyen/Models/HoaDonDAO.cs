using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class HoaDonDAO : DbContext
    {
        public List<MHoaDon> getDS()
        {
            List<MHoaDon> list = new List<MHoaDon>();
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "SELECT *FROM HOADON";
                Reader = Cmd.ExecuteReader();
                while(Reader.Read())
                {
                    MHoaDon hd = new MHoaDon();
                    hd.MaChiNhanh = Reader["MaChiNhanh"].ToString();
                    hd.MaHD = Reader["MaHD"].ToString();
                    hd.MaKH = Reader["MaKH"].ToString();
                    hd.MaNV = Reader["MaNV"].ToString();
                    DateTime ngayLap;

                    if (DateTime.TryParse(Reader["NgayLap"].ToString(), out ngayLap))
                    {
                        hd.NgayLap = ngayLap;
                    }
                    hd.TinhTrang = int.Parse(Reader["TinhTrang"].ToString());
                    hd.TongTien = float.Parse(Reader["TongTien"].ToString());

                    list.Add(hd);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;

        }
     

        public int getMaHDNext()
        {

//            DBCC CHECKIDENT('KhachHang', RESEED, 0)

            Cmd.Parameters.Clear();
            Cmd.CommandText = " DECLARE @NextInvoiceID INT;SET @NextInvoiceID = ISNULL((SELECT MAX(MaHD) FROM HOADON), 0) +1; SELECT @NextInvoiceID AS MaHoaDonTiepTheo; ";
            int kq = 0;
            Reader = Cmd.ExecuteReader();
            if(Reader.Read())
            {
                kq =int.Parse( Reader["MaHoaDonTiepTheo"].ToString());
            }
            return kq;
        }
        public int ThemHD(MHoaDon a)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "INSERT INTO HOADON VALUES(@NgayLap,@MaNV,@MaKH,@MaChiNhanh,@TongTien,@TinhTrang)" ;
            Cmd.Parameters.AddWithValue("@NgayLap",a.NgayLap);
            Cmd.Parameters.AddWithValue("@MaNV",a.MaNV);
            Cmd.Parameters.AddWithValue("@MaKH",a.MaKH);
            Cmd.Parameters.AddWithValue("@MaChiNhanh",a.MaChiNhanh);
            Cmd.Parameters.AddWithValue("@TongTien",a.TongTien);
            Cmd.Parameters.AddWithValue("@TinhTrang", a.TinhTrang);

            return Cmd.ExecuteNonQuery();
        }
     
    }
}
