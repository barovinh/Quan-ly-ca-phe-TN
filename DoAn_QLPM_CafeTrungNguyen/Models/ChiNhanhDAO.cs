using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class ChiNhanhDAO :DbContext 
    {
        public List<ChiNhanh> getChiNhanh()
        {
            List<ChiNhanh> list = new List<ChiNhanh>();
            Cmd.CommandText = "SELECT*FROM CHINHANH";
            Reader = Cmd.ExecuteReader();
            while (Reader.Read())
            {
                ChiNhanh cn = new ChiNhanh();
                cn.DiaChi = Reader["DiaChi"].ToString();
                cn.TenChiNhanh = Reader["TenChiNhanh"].ToString();
                cn.MaChiNhanh = int.Parse(Reader["MaChiNhanh"].ToString());
                list.Add(cn);

            }
            return list;
        }
    }
}
