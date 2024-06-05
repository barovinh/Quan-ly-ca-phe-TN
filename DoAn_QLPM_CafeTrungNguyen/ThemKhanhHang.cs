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
    public partial class ThemKhanhHang : Form
    {
        public ThemKhanhHang(string ten,string sdt)
        {

            InitializeComponent();
            txtSoDienThoai.Text = sdt;
            txtTenKhachHang.Text = ten;
        }

        private void ThemKhanhHang_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHangDAO khDAO = new KhachHangDAO();
            KhachHang a = new KhachHang();
            a.TenKH = txtTenKhachHang.Text;
            a.SDT = txtSoDienThoai.Text;
            a.Diem = 0;
         
             int kt = khDAO.insertKH(a);
                if(kt>0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            
          
            this.Close();
        }
    }
}
