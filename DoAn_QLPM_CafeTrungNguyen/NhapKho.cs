using DoAn_QLPM_CafeTrungNguyen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class NhapKho : Form
    {
        DbContext db = new DbContext();
        public string Ma { get; set; }
        string datePart = "";
        string query = "";

        public NhapKho(string map)
        {
            InitializeComponent();
            LayDate();
            Ma = map;
            query= "SELECT CHITIETPHIEUNHAP.MaPN,MATHANG.TenMH,MATHANG.MaMH,MATHANG.GiaTien,CHITIETPHIEUNHAP.SoLuong,MATHANG.GiaTien*ChiTietPhieuNhap.SoLuong as 'ThanhTien',MaNV,NgayNhap FROM CHITIETPHIEUNHAP, PHIEUNHAPKHO, MATHANG WHERE PHIEUNHAPKHO.MaPN = '" + Ma + "'  AND PHIEUNHAPKHO.MaPN = CHITIETPHIEUNHAP.MaPN AND MATHANG.MaMH = CHITIETPHIEUNHAP.MaMH ";
        }
        void LayDate()
        {
            string pattern = @"(\d{2}-\d{2}-\d{4})";
            Match match = Regex.Match(query, pattern);

            if (match.Success)
            {
                datePart = match.Groups[1].Value;
            }
           
        }
      
        private void NhapKho_Load(object sender, EventArgs e)
        {
            DataTable dt = db.getDatatable(query);
            dataNhapKho.DataSource = dt;
            dataNhapKho.Columns["MaMH"].Visible = false;
            GenerateQRCodeAndDisplay();

        }
        private void GenerateQRCodeAndDisplay()
        {
            
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            string tenNV = new NhanVienDAO().searchMaNhanVien(dataNhapKho.Rows[0].Cells["MaNV"].Value.ToString()).TenNV;
            string ngaynhap = dataNhapKho.Rows[0].Cells["NgayNhap"].Value.ToString();
            float tong = 0;
            for (int i = 0; i < dataNhapKho.Rows.Count-1; i++)
            {
                
                tong += float.Parse(dataNhapKho.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            string maP = dataNhapKho.Rows[0].Cells["MaPN"].Value.ToString();
            string tonghop = "Mã phiếu nhập: " + Ma + "\nNgày nhập: " + ngaynhap + "\nNhân viên nhập: " + tenNV + "\nTổng tiền: " + tong.ToString();

            // Cài đặt kích thước của mã QR và loại bỏ khoảng trắng xung quanh mã QR
            barcodeWriter.Options = new QrCodeEncodingOptions
            {
                Width = picScan.Width,
                Height = picScan.Height,
                CharacterSet = "UTF-8",
                Margin = 0, // Loại bỏ khoảng trắng xung quanh mã QR
            };

            Bitmap qrCodeBitmap = barcodeWriter.Write(tonghop);
            picScan.BackgroundImage = qrCodeBitmap;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
          
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            frm_Gmail gm = Application.OpenForms["frm_Gmail"] as frm_Gmail;
            if (gm != null)
            {
                return;
            }
            else
            {
                gm = new frm_Gmail();
                gm.Show();
            }

        }

        private void dataNhapKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXuatPhieuNhap_Click(object sender, EventArgs e)
        {
            
        }
    }
}
