using DoAn_QLPM_CafeTrungNguyen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class frm_PhieuNhapKho : Form
    {
        DataTable dt;
        public frm_PhieuNhapKho(string pn)
        {
            InitializeComponent();
            DbContext db = new DbContext();
            string sql = "SELECT CHITIETPHIEUNHAP.MaPN,MATHANG.TenMH,MATHANG.MaMH,MATHANG.GiaTien,SoLuong,MATHANG.GiaTien*SoLuong as 'ThanhTien',MaNV,NgayNhap FROM CHITIETPHIEUNHAP, PHIEUNHAPKHO, MATHANG WHERE PHIEUNHAPKHO.MaPN = '" + pn + "'AND PHIEUNHAPKHO.MaPN = CHITIETPHIEUNHAP.MaPN AND MATHANG.MaMH = CHITIETPHIEUNHAP.MaMH ";
           dt= db.getDatatable(sql); 
        }

        private void frm_PhieuNhapKho_Load(object sender, EventArgs e)
        {
            ReportNhapKho r = new ReportNhapKho();
            r.SetDatabaseLogon("sa", "123456", "MSI\\SQLEXPRESS", "DB_CAFETRUNGNGUYEN");
            r.SetDataSource(dt);
            crystalReportViewer1.ReportSource = r;
        }
    }
}
