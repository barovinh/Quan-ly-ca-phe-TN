using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class KhachHangDAO : DbContext
    {


        public List<KhachHang> getDS()
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                open();
            
                Cmd.CommandText = "SELECT*FROM KHACHHANG";
                Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    KhachHang kh = new KhachHang();

                    kh.DiaChi = Reader["DiaChi"].ToString();
                    kh.Email = Reader["Email"].ToString();
                    kh.TenKH = Reader["TenKH"].ToString();
                    kh.MaKH = Reader["MaKH"].ToString();
                    kh.Diem = int.Parse(Reader["Diem"].ToString());
                    kh.SDT = Reader["SDT"].ToString();
                    list.Add(kh);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
        public int insertKH(KhachHang a)
        {
            try
            {
                open();
             
                Cmd.CommandText = "INSERT INTO KHACHHANG(TenKH,SDT,DiaChi,Email,Diem) values(@TenKH,@SDT,@DiaChi,@Email,@Diem)";
                Cmd.Parameters.AddWithValue("@TenKH", a.TenKH);
                Cmd.Parameters.AddWithValue("@SDT", a.SDT);
                Cmd.Parameters.AddWithValue("@DiaChi", a.DiaChi);
                Cmd.Parameters.AddWithValue("@Email", a.Email);
                Cmd.Parameters.AddWithValue("@Diem", a.Diem);
                return Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public KhachHang SearchKH(string input)
        {
            try
            {
                KhachHang kh = new KhachHang();
           
                Cmd.CommandText = "SELECT*FROM KHACHHANG WHERE SDT = @input or MaKH = @input";
                Cmd.Parameters.AddWithValue("@input",input );
                Reader = Cmd.ExecuteReader();
                  if(Reader.Read())
                {             
                    kh.DiaChi = Reader["DiaChi"].ToString();
                    kh.Email = Reader["Email"].ToString();
                    kh.TenKH = Reader["TenKH"].ToString();
                    kh.MaKH = Reader["MaKH"].ToString();
                    kh.Diem = int.Parse(Reader["Diem"].ToString());
                    kh.SDT = Reader["SDT"].ToString(); return kh;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
