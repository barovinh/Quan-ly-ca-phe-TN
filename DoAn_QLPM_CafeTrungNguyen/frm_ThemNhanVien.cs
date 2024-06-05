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
    public partial class frm_ThemNhanVien : Form
    {
        public frm_ThemNhanVien()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(txtTenNhanVien.Text.Length==0 || txtSDT.Text.Length==0 || maskNgaySinh.Text.Length==0 || cbChucVu.SelectedItem.ToString()==string.Empty || cbGioiTinh.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show("Không được bỏ trống các trường thông tin");
            }
            else
            {
                NhanVienDAO nvDAO = new NhanVienDAO();
                NhanVien nv = new NhanVien();
                nv.TenNV = txtTenNhanVien.Text;
                nv.SDT = txtSDT.Text;
                // Kiểm tra xem chuỗi ngày tháng có hợp lệ hay không
                if (DateTime.TryParse(maskNgaySinh.Text, out DateTime ngaySinh))
                {
                    // Nếu chuỗi hợp lệ, gán giá trị cho thuộc tính NgaySinh
                    nv.NgaySinh = ngaySinh;
                }
                if (cbChucVu.SelectedItem.ToString() == "Nhân viên bán hàng")
                nv.ChucVu = "1";
                nv.GioiTinh = cbGioiTinh.SelectedItem.ToString();
                int kt = nvDAO.ThemNhanVien(nv);
               if (kt>0)
                {
                    MessageBox.Show("Thêm thành công");
                    this.Close();

                }
                else if(kt==0)
                {
                    MessageBox.Show("Thêm thất bại");

                }
                else
                {
                    MessageBox.Show("Liên hệ DEV");

                }
            }          
            this.Close(); 
        }

        private void frm_ThemNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
