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
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
       
          //  string query = "SELECT CAST(NgayLap AS DATE) AS NgayLap, SUM(TongTien) AS TongTienTongCong" +
          //" FROM HOADON" +
          //" WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE) AND TinhTrang = 1 " +
          //"GROUP BY CAST(NgayLap AS DATE) " +
          //"ORDER BY CAST(NgayLap AS DATE) ASC; ";
          //  loadChart(query);
           
        }
        void loadData()
        {
            loadSoTienTrongNgay();
            loadDonHangTrongNgay();
            loadDonHuy();
            loadTongDoanhThu();
            TopSanPham();
            TonKho();
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        // mặc định khi load lên sẽ là hoom nay
        private void ThongKe_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            cbDate.SelectedIndex = 1;
            loadData();
        }
        void TopSanPham()
        {
            string query = "SELECT MATHANG.TenMH, SUM(CHITIETHOADON.SoLuong) AS SoLuong " +
                "FROM HOADON INNER JOIN CHITIETHOADON ON HOADON.MaHD = CHITIETHOADON.MaHD " +
                "INNER JOIN MATHANG ON CHITIETHOADON.MaMH = MATHANG.MaMH WHERE HOADON.TinhTrang = 1 GROUP BY MATHANG.MaMH, MATHANG.TenMH " +
                "ORDER BY SUM(CHITIETHOADON.SoLuong) DESC;";
            DataTable dt = new DbContext().getDatatable(query);
            for(int i = 0; i < dt.Rows.Count;i++)
            {
                SanPhamLabel sp = new SanPhamLabel();
                sp.SoLuong = (int)dt.Rows[i]["SoLuong"];
                sp.TenSP = dt.Rows[i]["TenMH"].ToString();
              flowLayoutPanelTopSP.Controls.Add(sp);
            }
        }
        void TonKho()
        {
            string sql = "SELECT*FROM MATHANG";
            DataTable dt = new DbContext().getDatatable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SanPhamLabel sp = new SanPhamLabel();
                sp.SoLuong = (int)dt.Rows[i]["SoLuong"];
                sp.TenSP = dt.Rows[i]["TenMH"].ToString();
                
                flowLayoutPanelTonKho.Controls.Add(sp);
            }
        }
        //     // load ra số đơn bị hủy trong ngày
        void loadDonHuy()
        {
            HoaDonDAO hdDAO = new HoaDonDAO();
            DataTable dt = hdDAO.getDatatable("select count(MaHD) as DonHangHuy " +
                "from HOADON " +
                "where CAST(ngaylap as date) = cast(getdate() as date) and TinhTrang=0");

            string temp = "";
            if (dt.Rows.Count > 0)
            {
                temp = dt.Rows[0]["DonHangHuy"].ToString();
            }
            DonHuy.Text = temp;
        }
        // truyền dữ liệu vào combo box
        
        // tải chard theo câu lệnh query
        void loadChart(string query)
        {
            HoaDonDAO hdDAO = new HoaDonDAO();
            DataTable dt = hdDAO.getDatatable(query);
            if(dt.Rows.Count>0)
            {
                chart.Series["Doanh thu"].XValueType = ChartValueType.Auto;
                chart.ChartAreas["ChartArea1"].AxisX.Title = "Ngày";
                if (cbDate.SelectedItem.ToString() == "Năm nay")
                {
                    chart.Series["Doanh thu"].XValueType = ChartValueType.String;

                    chart.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                }
           
                    
                chart.ChartAreas["ChartArea1"].AxisY.Title = "Số tiền";
                chart.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart.Series["Doanh thu"]["DrawingStyle"] = "Cylinder";
                chart.Series["Doanh thu"].LabelFormat = "{0:0,0} VNĐ";            
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chart.Series["Doanh thu"].Points.AddXY(dt.Rows[i]["NgayLap"], dt.Rows[i]["TongTienTongCong"]);
                }
                loadTongDoanhThu();
            }
           
        }

        void clearChart()
        {
            chart.Series["Doanh thu"].Points.Clear();

        }
        // load ra các số tiền trong ngày
        void loadSoTienTrongNgay()
        {
            HoaDonDAO hdDAO = new HoaDonDAO();
            DataTable dt = hdDAO.getDatatable("SELECT ISNULL(SUM(TongTien), 0) AS TongTienTongCong " +
                "FROM HOADON " +
                "WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE) and TinhTrang=1");
            string temp = "";

            if (dt.Rows.Count > 0)
            {
                decimal tongTien = Convert.ToDecimal(dt.Rows[0]["TongTienTongCong"]);
                temp = string.Format("{0:N0} VNĐ", tongTien);
            }
            lblSoTienTrongNgay.Text = temp.ToString();
        }
        // load ra các đơn hàng trong ngày
        void loadDonHangTrongNgay()
        {
            HoaDonDAO hdDAO = new HoaDonDAO();
            DataTable dt = hdDAO.getDatatable("select count(MaHD) as DonHangMoi " +
                "from HOADON " +
                "where CAST(ngaylap as date) = cast(getdate() as date) and TinhTrang=1");

            string temp = "";
            if (dt.Rows.Count > 0)
            {
                temp = dt.Rows[0]["DonHangMoi"].ToString();
            }
            DonHangMoi.Text = temp;
        }
        void loadTongDoanhThu()
        {
            double tong = 0;

            // Tạo DataTable
            // doanh thu được tính theo biểu đồ chart
            foreach (var item in chart.Series["Doanh thu"].Points)
            {
                double value = item.YValues[0];
                tong += value;
            }
            string temp = string.Format("{0:N0} VNĐ", tong);
            tongDoanhThu.Text = temp;
        }

        private void cbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearChart(); string query = "";

            if (cbDate.SelectedItem.ToString() == "7 ngày qua")
            {
                query = "SELECT CAST(NgayLap AS DATE) AS NgayLap, SUM(TongTien) AS TongTienTongCong" +
                    " FROM HOADON " +
                    "WHERE NgayLap >= DATEADD(DAY, -7, GETDATE()) AND NgayLap <= GETDATE() and TinhTrang=1" +
                    " GROUP BY CAST(NgayLap AS DATE)" +
                    "ORDER BY CAST(NgayLap AS DATE) ASC; ";

            }
            if (cbDate.SelectedItem.ToString() == "Hôm nay")
            {
                query = "SELECT CAST(NgayLap AS DATE) AS NgayLap, SUM(TongTien) AS TongTienTongCong" +
                     " FROM HOADON" +
                     " WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE) AND TinhTrang = 1 " +
                     "GROUP BY CAST(NgayLap AS DATE) " +
                     "ORDER BY CAST(NgayLap AS DATE) ASC; ";
            }
            if (cbDate.SelectedItem.ToString() == "Hôm qua")
            {
                query = "SELECT CAST(NgayLap AS DATE) AS NgayLap, SUM(TongTien) AS TongTienTongCong" +
                   " FROM HOADON" +
                   " WHERE CAST(NgayLap AS DATE) = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE) AND TinhTrang = 1 " +
                   "GROUP BY CAST(NgayLap AS DATE) " +
                   "ORDER BY CAST(NgayLap AS DATE) ASC; ";
            }
            if (cbDate.SelectedItem.ToString() == "Tháng trước")
            {
                query = "SELECT CAST(NgayLap AS DATE) AS NgayLap, SUM(TongTien) AS TongTienTongCong" +
                    " FROM HOADON" +
                    " WHERE DATEPART(YEAR, NgayLap) = DATEPART(YEAR, DATEADD(MONTH, -1, GETDATE()))" +
                    " AND DATEPART(MONTH, NgayLap) = DATEPART(MONTH, DATEADD(MONTH, -1, GETDATE()))" +
                    " AND TinhTrang = 1 " +
                    "GROUP BY CAST(NgayLap AS DATE) " +
                    "ORDER BY CAST(NgayLap AS DATE) ASC; ";
            }
            if (cbDate.SelectedItem.ToString() == "Tháng này")
            {
                query = "SELECT CAST(NgayLap AS DATE) AS NgayLap, SUM(TongTien) AS TongTienTongCong" +
        " FROM HOADON" +
        " WHERE DATEPART(YEAR, NgayLap) = DATEPART(YEAR, GETDATE())" +
        " AND DATEPART(MONTH, NgayLap) = DATEPART(MONTH, GETDATE())" +
        " AND TinhTrang = 1 " +
        "GROUP BY CAST(NgayLap AS DATE) " +
        "ORDER BY CAST(NgayLap AS DATE) ASC; ";
            }
            if(cbDate.SelectedItem.ToString()=="Năm nay")
            {
                query = "SELECT MONTH(HOADON.NgayLap) AS NgayLap, SUM(TongTien) as TongTienTongCong" +
                    " FROM HOADON" +
                    " WHERE YEAR(HOADON.NgayLap) = DATEPART(YEAR, GETDATE()) AND TinhTrang = 1 GROUP BY MONTH(HOADON.NgayLap) " +
                    "ORDER BY  MONTH(HOADON.NgayLap)";
            }    
            loadChart(query);

        }

        private void cbDate_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void flowLayoutPanelTopSP_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
