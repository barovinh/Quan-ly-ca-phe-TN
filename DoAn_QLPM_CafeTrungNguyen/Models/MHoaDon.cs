using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QLPM_CafeTrungNguyen.Models
{
    class MHoaDon
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public string MaChiNhanh { get; set; }
        public float TongTien { get; set; }
        public int TinhTrang { get; set; }


        public MHoaDon()
        {

        }

    }
}
