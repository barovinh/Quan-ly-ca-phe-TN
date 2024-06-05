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
    public partial class ThemKhachHang_full : Form
    {
        public ThemKhachHang_full()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHangDAO khDAO = new KhachHangDAO();
            KhachHang kh = new KhachHang();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.Email = txtEmail.Text.Trim();
            kh.TenKH = txtTenKhachHang.Text.Trim();
            kh.SDT = txtSoDienThoai.Text.Trim();
            if(khDAO.insertKH(kh)>0)
            {
                MessageBox.Show("Thêm thành công");

            }
            else
            {
                MessageBox.Show("Thêm thất bại");

            }
        }

        private void ThemKhachHang_full_Load(object sender, EventArgs e)
        {

        }
    }
}
