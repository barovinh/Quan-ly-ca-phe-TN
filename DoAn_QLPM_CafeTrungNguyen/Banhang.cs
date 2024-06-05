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
    public partial class Banhang : Form
    {

        List<ItemMatHang> ListMatHang;
        List<GioHangCho> ListGioHangCho;
        public NhanVien nv;
        public KhachHang khachS;
        public Banhang(string user)
        {
            InitializeComponent();
            ListMatHang = new List<ItemMatHang>();
            ListGioHangCho = new List<GioHangCho>();
            NgayLap.Text = DateTime.Now.ToString();

            // lấy thông tin nhân viên
            TaiKhoanDAO tkDAO = new TaiKhoanDAO();
            nv = tkDAO.getThongTinTK(user);
            txtMaNV.Text = nv.MaNV.ToString();
            txtTenNV.Text = nv.TenNV.ToString();
            // lấy mã hóa đơn tiếp theo
            HoaDonDAO hdDAO = new HoaDonDAO();
            int maHD = hdDAO.getMaHDNext();
            lblMaHD.Text = maHD.ToString();
            // lấy mã chi nhánh
            ChiNhanhDAO cnDAO = new ChiNhanhDAO();
            List<ChiNhanh> listCN = cnDAO.getChiNhanh();
            // Gán danh sách chi nhánh vào ComboBox
            cbChiNhanh.DisplayMember = "TenChiNhanh"; // Hiển thị tên chi nhánh
            cbChiNhanh.ValueMember = "MaChiNhanh"; // Lưu mã chi nhánh
            cbChiNhanh.DataSource = listCN; // Gán dữ liệu danh sách chi nhánh vào ComboBox
        }

        private void itemMatHang_Click(object sender, EventArgs e)
        {
            ItemMatHang ten = (ItemMatHang)sender;
            // Kiểm tra xem mục đã tồn tại trong giỏ hàng chưa
            GioHangCho existingItem = ListGioHangCho.FirstOrDefault(item => item.MaMH == ten.MaMH);
            if (existingItem != null)
            {
                // Nếu đã tồn tại, xóa nó khỏi giỏ hàng và cập nhật giao diện người dùng
                flowPanelHangCho.Controls.Remove(existingItem);
                ListGioHangCho.Remove(existingItem);
            }
            else
            {   // Kiêm tra tình trạng hàng còn hay không
                if (ten.SoLuong == 0)
                {
                    ten.Checked(false);
                    MessageBox.Show("Mặt hàng đã hết hàng, xin vui lòng cật nhật thêm", "Thông báo");
                    return;
                }
                // Nếu chưa tồn tại, thêm nó vào giỏ hàng và cập nhật giao diện người dùng
                GioHangCho gh = new GioHangCho();
                gh.SLTon = ten.SoLuong;
                gh.TenSP = ten.TenSP;
                gh.MaMH = ten.MaMH;
                gh.Gia = ten.Gia;
                gh.SomeChanged += GioHangCho_SomeChanged;
                flowPanelHangCho.Controls.Add(gh);
                ListGioHangCho.Add(gh);
            }
            UpdateTxtThanhTien();
        }
        private void GioHangCho_SomeChanged(object sender, EventArgs e)
        {
            // Gọi phương thức cập nhật txtThanhTien khi có sự thay đổi trong GioHangCho
            UpdateTxtThanhTien();
        }

        private void UpdateTxtThanhTien()
        {
            // Tính toán tổng tiền dựa trên các user control GioHangCho và cập nhật txtThanhTien
            float tong = ListGioHangCho.Sum(gh => gh.TongTien);
            txtThanhTien.Text = string.Format("{0:#,##0}", tong);
        }
        private void Banhang_Load(object sender, EventArgs e)
        {
            MatHangDAO mhDAO = new MatHangDAO();
            List<MatHang> list = mhDAO.getMatHang();
            foreach (var item in list)
            {
                ItemMatHang itemMatHang = new ItemMatHang();
                itemMatHang.TenSP = item.TenMH;
                itemMatHang.Gia = item.GiaTien;
                itemMatHang.MaMH = item.MaMH;
                itemMatHang.Loai = item.Loai;
                itemMatHang.SoLuong = item.SoLuong;
                try
                {
                    itemMatHang.HinhAnh = Image.FromFile(item.DuongDan);
                }
                catch (Exception)
                {

                    throw;
                }

                itemMatHang.Click += new System.EventHandler(this.itemMatHang_Click);
                flowLayoutPanel1.Controls.Add(itemMatHang);
                ListMatHang.Add(itemMatHang);
            }
        }
        void refreshPage()
        {
            flowLayoutPanel1.Controls.Clear();
            ListMatHang.Clear();
            MatHangDAO mhDAO = new MatHangDAO();
            List<MatHang> list = mhDAO.getMatHang();
            foreach (var item in list)
            {
                ItemMatHang itemMatHang = new ItemMatHang();
                itemMatHang.TenSP = item.TenMH;
                itemMatHang.Gia = item.GiaTien;
                itemMatHang.MaMH = item.MaMH;
                itemMatHang.Loai = item.Loai;
                itemMatHang.SoLuong = item.SoLuong;
                try
                {
                    itemMatHang.HinhAnh = Image.FromFile(item.DuongDan);
                }
                catch (Exception)
                {

                    throw;
                }
                // lấy mã hóa đơn tiếp theo
                HoaDonDAO hdDAO = new HoaDonDAO();
                int maHD = hdDAO.getMaHDNext();
                lblMaHD.Text = maHD.ToString();
                itemMatHang.Click += new System.EventHandler(this.itemMatHang_Click);
                flowLayoutPanel1.Controls.Add(itemMatHang);
                ListMatHang.Add(itemMatHang);
            }
        }
        private void flowPanelHangCho_Paint(object sender, PaintEventArgs e)
        {
            List<GioHangCho> Listtemp = ListGioHangCho.Where(t => t.Xoa == true).ToList();
            foreach (var item in ListMatHang)
            {
                foreach (var rem in Listtemp)
                {
                    if (rem.TenSP == item.TenSP && rem.Xoa == true)
                    {
                        item.Check = false;
                        item.Checked(item.Check);
                        ListGioHangCho.Remove(rem);
                    }
                }
            }

            // Ghi log để xác định xem mã đã chạy vào sự kiện này hay không và kết quả là gì.

            UpdateTxtThanhTien();

        }


        private void test_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            float tong = ListGioHangCho.Sum(t => t.Gia * t.SoLuong);
            txtThanhTien.Text = tong.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            this.Refresh();
            if (txtTenKH.Text.Length == 0 || txtSDT.Text.Length == 0)
            {
                MessageBox.Show("Chưa có thông tin của khách hàng", "Thông báo");
                return;
            }
            txtThanhTien.Text = "0";
            HoaDonDAO hdDAO = new HoaDonDAO();
            MHoaDon hd = new MHoaDon();
            hd.MaChiNhanh = cbChiNhanh.SelectedValue.ToString();
            hd.MaHD = lblMaHD.Text;
            KhachHangDAO khDAO = new KhachHangDAO();
            khachS = khDAO.SearchKH(txtSDT.Text);
            hd.MaKH = khachS.MaKH;
            hd.MaNV = txtMaNV.Text;
            UpdateTxtThanhTien();
            hd.TongTien = float.Parse(txtThanhTien.Text);
            string ngayLapText = NgayLap.Text;
            DateTime ngayLap;
            if (DateTime.TryParse(ngayLapText, out ngayLap))
            {
                hd.NgayLap = ngayLap;
            }
            hd.TinhTrang = 1;


            int step1 = hdDAO.ThemHD(hd);
            if (step1 > 0)
            {
                ChiTietHoaDonDAO ctDAO = new ChiTietHoaDonDAO();
                string maHD = lblMaHD.Text;
                foreach (var item in ListGioHangCho)
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.MaHD = maHD;
                    ct.MaMH = item.MaMH;
                    ct.SoLuong = item.SoLuong;
                    ctDAO.ThemChiTietHD(ct);
                }
            }
            ListGioHangCho.Clear();
            flowPanelHangCho.Controls.Clear();
            foreach (var item in ListMatHang)
            {
                item.Checked(false);
            }
            refreshPage();
        }
        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        { // Lưu vị trí con trỏ trước khi thay đổi văn bản
            int selectionStart = txtTienKhachDua.SelectionStart;

            // Xóa các dấu phẩy trong văn bản để có thể chuyển đổi sang số
            string cleanedText = txtTienKhachDua.Text.Replace(",", "");

            // Kiểm tra nếu là số hợp lệ
            if (int.TryParse(cleanedText, out int number))
            {
                // Định dạng số và gán lại vào TextBox
                txtTienKhachDua.Text = number.ToString("#,###");

                // Tính lại vị trí con trỏ
                int newSelectionStart = selectionStart + (txtTienKhachDua.Text.Length - cleanedText.Length);

                // Đảm bảo rằng vị trí con trỏ không vượt quá độ dài của văn bản
                newSelectionStart = Math.Max(0, Math.Min(newSelectionStart, txtTienKhachDua.Text.Length));

                // Đặt lại vị trí con trỏ
                txtTienKhachDua.SelectionStart = newSelectionStart;
            }
            else
            {
                // Xử lý trường hợp không phải số (nếu cần)
            }
            if (txtTienKhachDua.Text.Length > 0)
            {
                
                float tienkhachdua = float.Parse(txtTienKhachDua.Text);
                
                float thanhtien = float.Parse(txtThanhTien.Text);
                if(tienkhachdua>thanhtien)
                {
                    txtTienTraLai.Text = (tienkhachdua - thanhtien).ToString("#,###");

                }
            }
        }


        private void picTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 0)
            {
                MessageBox.Show("Không thể tìm kiếm");

            }
            else
            {
                KhachHangDAO khDAO = new KhachHangDAO();
                khachS = khDAO.SearchKH(txtSDT.Text);
                if (khachS != null)
                {
                    txtTenKH.Text = khachS.TenKH;

                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu khách hàng", "Thông báo");
                    if (MessageBox.Show("Bạn có muốn thêm khách hàng này vào dữ liệu?   ", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        new ThemKhanhHang(txtTenKH.Text, txtSDT.Text).ShowDialog();

                    }
                    else
                    {
                        return;
                    }
                }
            }
        }


        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != 32)
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }
    }
}
