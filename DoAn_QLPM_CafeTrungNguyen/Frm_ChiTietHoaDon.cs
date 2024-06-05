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
using static DoAn_QLPM_CafeTrungNguyen.dtHoaDon;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class Frm_ChiTietHoaDon : Form
    {
        DataTable dt;
        public Frm_ChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            ChiTietHoaDonDAO ctDAO = new ChiTietHoaDonDAO();
            string query = @"
    SELECT 
    HOADON.MaHD,
    HOADON.NgayLap,
    HOADON.MaNV,
    NHANVIEN.TenNV,
    HOADON.MaKH,HOADON.TINHTRANG,
    KHACHHANG.TenKH,
    HOADON.MaChiNhanh, 
    CHINHANH.TenChiNhanh,
    CHITIETHOADON.MaMH,
    MATHANG.TenMH,
    MATHANG.GiaTien,
    CHITIETHOADON.SoLuong,
    (CHITIETHOADON.SoLuong * MATHANG.GiaTien) AS ThanhTien, -- Tính toán Thành tiền
    HOADON.TongTien
FROM HOADON
JOIN NHANVIEN ON HOADON.MaNV = NHANVIEN.MaNV
JOIN KHACHHANG ON HOADON.MaKH = KHACHHANG.MaKH
JOIN CHINHANH ON HOADON.MaChiNhanh = CHINHANH.MaChiNhanh
JOIN CHITIETHOADON ON HOADON.MaHD = CHITIETHOADON.MaHD
JOIN MATHANG ON CHITIETHOADON.MaMH = MATHANG.MaMH
WHERE HOADON.MaHD = " + maHD;
            dt = ctDAO.getDatatable(query);
            //CTHoaDonDataTable ct = new CTHoaDonDataTable();
            //ct.DataSet.Tables.Add(dt);
        }

        private void Frm_ChiTietHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            ReportHoaDon r = new ReportHoaDon();
            r.SetDataSource(dt);
            crystalReportViewer1.ReportSource = r;
        }
    }
}
