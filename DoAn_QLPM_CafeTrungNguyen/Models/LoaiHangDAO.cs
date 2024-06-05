using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class LoaiHangDAO :DbContext
    {
        public List<LoaiHang> getLoaiHang()
        {
            List<LoaiHang> list = new List<LoaiHang>();
            try
            {
                Cmd.CommandText = "select *from LOAIMATHANG";
                Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    LoaiHang lh = new LoaiHang();
                    lh.MaLoaiHang = Reader["MaLoaiHang"].ToString();
                    lh.TenLoaiHang = Reader["TenLoaiHang"].ToString();
                    list.Add(lh);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
          
            return list;
        }
        public LoaiHang getLoaiHang(string ma)
        {
            LoaiHang lh = new LoaiHang();
            try
            {
                Cmd.CommandText = "  select *from LOAIMATHANG where MaLoaiHang=@MaLoaiHang";
                Cmd.Parameters.AddWithValue("@MaLoaiHang", ma);
                Reader = Cmd.ExecuteReader();
                while(Reader.Read())
                {
                    lh.TenLoaiHang = Reader["TenLoaiHang"].ToString();
                    lh.MaLoaiHang = Reader["MaLoaiHang"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lh;
        }
        public LoaiHang getMaLoaiHang(string ten)
        {
            LoaiHang lh = new LoaiHang();
            try
            {
                Cmd.CommandText = "select *from LOAIMATHANG where TenLoaiHang=@TenLoaiHang";
                Cmd.Parameters.AddWithValue("@TenLoaiHang", ten);
                Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    lh.TenLoaiHang = Reader["TenLoaiHang"].ToString();
                    lh.MaLoaiHang = Reader["MaLoaiHang"].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return lh;
        }
    }
}
