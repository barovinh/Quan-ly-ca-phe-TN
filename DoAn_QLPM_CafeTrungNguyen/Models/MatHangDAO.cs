using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class MatHangDAO : DbContext
    {
        public List<MatHang> getMatHang()
        {
            List<MatHang> list = new List<MatHang>();
            try
            {
                Cmd.CommandText = "SELECT*FROM MATHANG";
                Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    MatHang mh = new MatHang();
                    mh.TenMH = Reader["TenMH"].ToString();
                    mh.MaMH = Reader["MaMH"].ToString();
                    mh.Loai = Reader["Loai"].ToString();
                    mh.GiaTien = float.Parse(Reader["GiaTien"].ToString());
                    mh.HinhAnh = Reader["HinhAnh"].ToString();
                    mh.DuongDan = Reader["DuongDanAnh"].ToString();
                    try
                    {
                        mh.SoLuong = int.Parse(Reader["SoLuong"].ToString());

                    }
                    catch (Exception)
                    {

                        mh.SoLuong = 0;
                    }
              
                    list.Add(mh);
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
          
            return list;
        }
        public int CheckName(string tenMatHang)
        {
            Cmd.Parameters.Clear();
            try
            {
                Cmd.CommandText = "SELECT*FROM MATHANG WHERE TenMH = @TenMH";
                Cmd.Parameters.AddWithValue("@TenMH", tenMatHang);
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Insert(string tenMatHang, float giaTien, string loai, byte[] hinhAnh, string duongDanAnh)
        {
            Cmd.Parameters.Clear();
            try
            {
                Cmd.CommandText = "INSERT INTO MATHANG (TenMH,GiaTien, Loai, HinhAnh, DuongDanAnh,SoLuong) " +
                           "VALUES (@TenMH,@GiaTien, @Loai, @HinhAnh, @DuongDanAnh,'0')";
                Cmd.Parameters.AddWithValue("@TenMH", tenMatHang);
                Cmd.Parameters.AddWithValue("@GiaTien", giaTien);
                Cmd.Parameters.AddWithValue("@Loai", loai);
                Cmd.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                Cmd.Parameters.AddWithValue("@DuongDanAnh", duongDanAnh);
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
       public int Delete(string maMH)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "DELETE FROM MATHANG WHERE MaMH = @MaMH";
            Cmd.Parameters.AddWithValue("@MaMH", maMH);
            return Cmd.ExecuteNonQuery();
        }
        public int Update(string tenMatHang, string maMH, float giaTien, string loai, byte[] hinhAnh, string duongDanAnh)
        {
            Cmd.Parameters.Clear();
            Cmd.CommandText = "UPDATE MATHANG set TenMH=@TenMH,GiaTien=@GiaTien,Loai=@Loai,HinhAnh=@HinhAnh,DuongDanAnh=@DuongDanAnh where MaMH=@MaMH";
            Cmd.Parameters.AddWithValue("@TenMH", tenMatHang);
            Cmd.Parameters.AddWithValue("@MaMH", maMH);
            Cmd.Parameters.AddWithValue("@GiaTien", giaTien);
            Cmd.Parameters.AddWithValue("@Loai", loai);
            Cmd.Parameters.AddWithValue("@HinhAnh", hinhAnh);
            Cmd.Parameters.AddWithValue("@DuongDanAnh", duongDanAnh);
            return Cmd.ExecuteNonQuery();

        }

        public List<MatHang> dsSearch(string ten)
        {
            List<MatHang> list = new List<MatHang>();
            try
            {
                Cmd.Parameters.Clear();
                //    Cmd.CommandText = "SELECT * FROM BAIHAT WHERE TenBH like N'%' + @TenBH + '%'";

                Cmd.CommandText = "SELECT*FROM MATHANG WHERE TenMH like N'%' + @TenMH +'%'";
                Cmd.Parameters.AddWithValue("@TenMH", ten);
                Reader = Cmd.ExecuteReader();
                while(Reader.Read())
                {
                    MatHang mh = new MatHang();
                    mh.TenMH = Reader["TenMH"].ToString();
                    mh.MaMH = Reader["MaMH"].ToString();
                    mh.Loai = Reader["Loai"].ToString();
                    mh.GiaTien = float.Parse(Reader["GiaTien"].ToString());
                    mh.HinhAnh = Reader["HinhAnh"].ToString();
                    mh.DuongDan = Reader["DuongDanAnh"].ToString();
                    list.Add(mh);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
        public MatHang MaMatHang(string mha)
        {
          MatHang mh = new MatHang();
            try
            {
                Cmd.Parameters.Clear();
                //    Cmd.CommandText = "SELECT * FROM BAIHAT WHERE TenBH like N'%' + @TenBH + '%'";

                Cmd.CommandText = "SELECT*FROM MATHANG WHERE MaMH=@MaMH";
                Cmd.Parameters.AddWithValue("@MaMH", mha);
                Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                   
                    mh.TenMH = Reader["TenMH"].ToString();
                    mh.MaMH = Reader["MaMH"].ToString();
                    mh.Loai = Reader["Loai"].ToString();
                    mh.GiaTien = float.Parse(Reader["GiaTien"].ToString());
                    mh.HinhAnh = Reader["HinhAnh"].ToString();
                    mh.DuongDan = Reader["DuongDanAnh"].ToString();
                  
                }

            }
            catch (Exception)
            {

                throw;
            }
            return mh;
        }
    }
}
