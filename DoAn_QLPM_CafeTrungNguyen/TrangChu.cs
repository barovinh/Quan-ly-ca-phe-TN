using DoAn_QLPM_CafeTrungNguyen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class TrangChu : Form
    {
        bool sildebarExpand = true;
        private Form currentFormChild;
        NhanVien nv = new NhanVien(); 
        public string User { get; set; }
        public TrangChu(string user)
        {
            InitializeComponent();
            getNhanVien();
            lblTest.Text = user;
            User = user;
        }
        public TrangChu()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;

            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void SlidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sildebarExpand)
            {
                // Đặt kích thước của cột đầu tiên (Column 0) của tableLayoutPanel1 thành 100 pixel
                tableLayoutPanel1.ColumnStyles[0].Width -= 10;
                if (tableLayoutPanel1.ColumnStyles[0].Width == 40)
                {
                    sildebarExpand = false;

                    SlidebarTimer.Stop();

                }

            }
            else
            {
                tableLayoutPanel1.ColumnStyles[0].Width += 10;
                if (tableLayoutPanel1.ColumnStyles[0].Width == 210)
                {
                    sildebarExpand = true;
                    SlidebarTimer.Stop();
                }
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            SlidebarTimer.Start();

        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            SlidebarTimer.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }
     
        private void btnBanHang_Click(object sender, EventArgs e)
        {

            getNhanVien();
            Banhang bh = new Banhang(User);
            OpenChildForm(bh);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frm_DangNhap dn = new frm_DangNhap();
                dn.Show();
                this.Visible = false;
            }
        }
        void getNhanVien()
        {
            NhanVienDAO nvDAO = new NhanVienDAO();
           nv = nvDAO.searchNhanVien(lblTest.Text);
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            getNhanVien();
            QuanLySanPham ql = new QuanLySanPham(nv);
            OpenChildForm(ql);
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            GenerateQRCodeAndDisplay();
        }
        private void GenerateQRCodeAndDisplay()
        {
            string url = "https://trungnguyenlegend.com/";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            // Cài đặt kích thước của mã QR và hiển thị nó trong PictureBox
            barcodeWriter.Options = new QrCodeEncodingOptions
            {
                Width = qrLink.Width,
                Height = qrLink.Height
            };

            Bitmap qrCodeBitmap = barcodeWriter.Write(url);
            qrLink.Image = qrCodeBitmap;
        }


        private void button2_Click_2(object sender, EventArgs e)
        {
     
            OpenChildForm(new ThongKe());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            getNhanVien();

            OpenChildForm(new FrmHoaDon(nv));
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_KhachHang());
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            getNhanVien();
            OpenChildForm(new frm_NhanVien(nv));
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            getNhanVien();
            OpenChildForm(new TonKho(nv)
            {

            });
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}

