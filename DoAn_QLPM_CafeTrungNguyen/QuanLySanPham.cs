using DoAn_QLPM_CafeTrungNguyen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class QuanLySanPham : Form
    {
        List<ItemMatHang> dsSP;
        List<LoaiHang> dsLH;
        public NhanVien NV { get; set; }
        public QuanLySanPham(NhanVien nv)
        {
            InitializeComponent();
            dsSP = new List<ItemMatHang>();
            NV = nv;
            if(int.Parse(nv.ChucVu)==2)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void HienThiSanPham_Load(object sender, EventArgs e)
        {
            MatHangDAO mhDAO = new MatHangDAO();
            List<MatHang> list = mhDAO.getMatHang();
            dsLH = new LoaiHangDAO().getLoaiHang();
            if (list == null)
            {
                Console.WriteLine("-1");
            }
           
            foreach (var item in list)
            {
                ItemMatHang itemMatHang = new ItemMatHang();
                itemMatHang.TenSP = item.TenMH;
                itemMatHang.Gia = item.GiaTien;
                itemMatHang.MaMH = item.MaMH;
                itemMatHang.Loai = item.Loai;
                itemMatHang.SoLuong = item.SoLuong;
                itemMatHang.HinhAnh = Image.FromFile(item.DuongDan);
                itemMatHang.DuongDan = item.DuongDan;
                itemMatHang.Click += ItemMatHang_Click;

                dsSP.Add(itemMatHang);
                flowShowItem.Controls.Add(itemMatHang);     
            }
            dsLH.ForEach(t => cbBoxLoai.Items.Add(t.TenLoaiHang));
          
        }

        private void ItemMatHang_Click(object sender, EventArgs e)
        {
            ItemMatHang itemMH = (ItemMatHang)sender;
         // tổng duyệt bật tắt các item hiển thị lên panel
            ItemMatHang mh = dsSP.FirstOrDefault(t => t.MaMH == itemMH.MaMH);
            foreach (var item in dsSP)
            {
             if(item.MaMH!=mh.MaMH)
                {
                    item.Checked(false);
                }
                else
                {
                    item.Checked(true);
                }
            }

            // xu ly hien thi len panel
            txtGia.Text = itemMH.Gia.ToString();
            txtTenMatHang.Text = itemMH.TenSP.ToString();
            txtMaHang.Text = itemMH.MaMH.ToString();
            txtDuongDan.Text = itemMH.DuongDan;
            string temp = new LoaiHangDAO().getLoaiHang(itemMH.Loai.ToString()).TenLoaiHang.ToString();
            cbBoxLoai.SelectedItem = temp;

            pictureItem.BackgroundImage = itemMH.HinhAnh;
         
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            MatHangDAO mhDAO = new MatHangDAO();
            try
            {
               if(cbBoxLoai.SelectedIndex>=0)
                {
                    if(txtGia.Text.Length==0)
                    {
                        MessageBox.Show("Không được bỏ trống giá");
                        return;
                    }    
                    if(txtDuongDan.Text.Length==0)
                    {
                        MessageBox.Show("Không được bỏ trống đường dẫn ảnh");
                        return;
                    }
                    if (mhDAO.CheckName(txtTenMatHang.Text) > 0)
                    {
                        MessageBox.Show("Thêm thất bại do trùng trên sản phẩm!");
                    }
                    else
                    {
                        //   string maMH = txtMaHang.Text;
                        string tenMH = txtTenMatHang.Text;
                        float gia = float.Parse(txtGia.Text);
                        string loai = new LoaiHangDAO().getMaLoaiHang(cbBoxLoai.SelectedItem.ToString()).MaLoaiHang.ToString();
                        string duongdan = txtDuongDan.Text;
                        int kt = mhDAO.Insert(tenMH, gia, loai, ConvertImageToByes(pictureItem.BackgroundImage), duongdan);
                        if (kt > 0)
                        {
                            MessageBox.Show("THEM THANH CONG");
                            RefreshPage();
                        }
                        else
                        {
                            MessageBox.Show("THEM THAT BAI VUI LÒNG LIÊN HỆ DEV");

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không được bỏ trống loại");

                }


            }
            catch (Exception )
            {
                //throw;
                MessageBox.Show("THEM THAT BAI VUI LÒNG LIÊN HỆ DEV");
              //  MessageBox.Show("LỖI");
            }
       //     flowShowItem.Refresh();
          //  this.Refresh();
        }
       
        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png" })
            {
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    pictureItem.BackgroundImage = Image.FromFile(ofd.FileName);
                    txtDuongDan.Text = ofd.FileName;
                }
            }
            txtTenMatHang.Focus();
        }
        byte[] ConvertImageToByes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void RefreshPage()
        {
           
            // Xóa tất cả các mục hiển thị trong flowLayoutPanel
            flowShowItem.Controls.Clear();

            // Tải lại danh sách sản phẩm và hiển thị chúng
            MatHangDAO mhDAO = new MatHangDAO();
            List<MatHang> list = mhDAO.getMatHang();

            if (list == null)
            {
                Console.WriteLine("-1");
            }

            foreach (var item in list)
            {
                ItemMatHang itemMatHang = new ItemMatHang();
                itemMatHang.TenSP = item.TenMH;
                itemMatHang.Gia = item.GiaTien;
                itemMatHang.MaMH = item.MaMH;
                itemMatHang.Loai = item.Loai;
                itemMatHang.SoLuong = item.SoLuong;
                Console.WriteLine(item.DuongDan);
                itemMatHang.HinhAnh = Image.FromFile(item.DuongDan);
                itemMatHang.DuongDan = item.DuongDan;
                itemMatHang.Click += ItemMatHang_Click;

                dsSP.Add(itemMatHang);
                flowShowItem.Controls.Add(itemMatHang);
         //       cbBoxLoai.SelectedIndex = 2;
                txtTenMatHang.Focus();
            }

            // Đặt lại dữ liệu trong các controls khác nếu cần
            txtMaHang.Clear();
            txtTenMatHang.Clear();
            txtGia.Clear();
            txtDuongDan.Clear();
            txtTimKiem.Clear();
          //  cbBoxLoai.SelectedIndex = -1;
            pictureItem.BackgroundImage = default;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này không?","Xác nhận",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                MatHangDAO mhDAO = new MatHangDAO();
                try
                {
                    if (mhDAO.Delete(txtMaHang.Text) > 0)
                    {
                        MessageBox.Show("XÓA THÀNH CÔNG");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi");

                }

                RefreshPage();
            }    
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string maMH = txtMaHang.Text;
                string tenMH = txtTenMatHang.Text;
                float gia = float.Parse(txtGia.Text);
                string loai = new LoaiHangDAO().getMaLoaiHang(cbBoxLoai.SelectedItem.ToString()).MaLoaiHang.ToString();
                string duongdan = txtDuongDan.Text;
                MatHangDAO mhDAO = new MatHangDAO();
                int kt = mhDAO.Update(tenMH,maMH,gia,loai,ConvertImageToByes(pictureItem.BackgroundImage),duongdan);
                if(kt>0)
                {
                    MessageBox.Show("Cật nhật thành công");
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                RefreshPage();
            }
            catch (Exception)
            {
                return; 
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

            if (txtTimKiem.Text.Length == 0 || txtTimKiem.Text == "")
            {
                RefreshPage();
            }
            else
            {
                dsSP.Clear();
                flowShowItem.Controls.Clear();
                MatHangDAO mhDAO = new MatHangDAO();
                List<MatHang> ls = mhDAO.dsSearch(txtTimKiem.Text);
                if(ls.Count!=0)
                {
                    foreach (var item in ls)
                    {
                        ItemMatHang itemMatHang = new ItemMatHang();
                        itemMatHang.TenSP = item.TenMH;
                        itemMatHang.Gia = item.GiaTien;
                        itemMatHang.MaMH = item.MaMH;
                        itemMatHang.Loai = item.Loai;

                        itemMatHang.HinhAnh = Image.FromFile(item.DuongDan);
                        itemMatHang.DuongDan = item.DuongDan;
                        itemMatHang.Click += ItemMatHang_Click;

                        dsSP.Add(itemMatHang);
                        flowShowItem.Controls.Add(itemMatHang);
                    }
                }
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 32)
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
           
        }

        private void cbBoxLoai_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void QuanLySanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true; // Hủy việc đóng cửa sổ nếu người dùng chọn No
                }
                else
                {
                    Application.Exit(); // Đóng chương trình khi người dùng chọn Yes
                }
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            // Lưu vị trí con trỏ trước khi thay đổi văn bản
            int selectionStart = txtGia.SelectionStart;

            // Xóa các dấu phẩy trong văn bản để có thể chuyển đổi sang số
            string cleanedText = txtGia.Text.Replace(",", "");

            // Kiểm tra nếu là số hợp lệ
            if (int.TryParse(cleanedText, out int number))
            {
                // Định dạng số và gán lại vào TextBox
                txtGia.Text = number.ToString("#,###");

                // Tính lại vị trí con trỏ
                int newSelectionStart = selectionStart + (txtGia.Text.Length - cleanedText.Length);

                // Đảm bảo rằng vị trí con trỏ không vượt quá độ dài của văn bản
                newSelectionStart = Math.Max(0, Math.Min(newSelectionStart, txtGia.Text.Length));

                // Đặt lại vị trí con trỏ
                txtGia.SelectionStart = newSelectionStart;
            }
            else
            {
                // Xử lý trường hợp không phải số (nếu cần)
            }
        }


    }
}
