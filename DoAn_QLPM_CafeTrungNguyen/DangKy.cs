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
    public partial class DangKy : Form
    {


        public DangKy()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Length == 0 || txtTenDangNhap.Text.Length == 0 || txtMatKhau.Text.Length==0 || txtXacNhanMatKhau.Text.Length==0)
            {
                MessageBox.Show("Không được bỏ trống các trường thông tin"); return;
            }
            if(check18t.Checked==true)
            {
                if (txtMatKhau.Text == txtXacNhanMatKhau.Text)
                {
                    try
                    {
                        DbContext db = new DbContext();
                        NhanVienDAO nvDAO = new NhanVienDAO();
                        NhanVien nv = new NhanVien();
                        int MANV = nvDAO.getNextID();
                        Console.WriteLine(MANV);
                        nv.TenNV = txtHoTen.Text;
                        nv.ChucVu = "1";
                        db.Cmd.CommandText = "INSERT INTO NHANVIEN VALUES(N'" + txtHoTen.Text + "',N'Nam','2000-01-01','1','00000000')";
                   
                        if (db.ExcuteNonQuery(db.Cmd.CommandText) > 0)
                        {
                            // tiếp theo đi tìm mã nhân viên đó :D vì đã được thêm db rồi
                            nv = nvDAO.searchMaNhanVien(MANV.ToString());
                            if (nv != null)
                            {
                                                             
                                db.Cmd.CommandText = "INSERT INTO TAIKHOAN VALUES('" + txtTenDangNhap.Text + "','" + txtMatKhau.Text + "','" + nv.MaNV + "','" + nv.ChucVu + "')";
                                string sql = "  select count(*) as 'TrungTen'" +
                                  "from TaiKhoan " +
                                  "where TenDangNhap =  '" + txtTenDangNhap.Text + "'";
                                if ((int)db.ExcuteScalar(sql) > 0)
                                {
                                    MessageBox.Show("Tên tài khoản đã tồn tại!");
                                    return;
                                }
                                else
                                {
                                    if (db.ExcuteNonQuery(db.Cmd.CommandText) > 0)
                                    {
                                        MessageBox.Show("Chúc mừng bạn đã đăng ký thành công");
                                        frm_DangNhap dn = new frm_DangNhap();
                                        dn.Show();
                                        Visible = false;
                                        return;
                                    }
                                }
                               
                            }
                            else
                            {
                                MessageBox.Show("DEBUG ĐI");
                            }
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

                else
                {
                    MessageBox.Show("Mật khẩu xác nhận không trùng nhau");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đảm bảo mình trên 18 tuổi");

            }

        }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
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

        private void nut_back_Click(object sender, EventArgs e)
        {
            frm_DangNhap dn = new frm_DangNhap();
            dn.Show();
            Visible = false;
        }

        private void nut_back_MouseHover(object sender, EventArgs e)
        {
            nut_back.BackColor = Color.PaleVioletRed;
        }

        private void nut_back_MouseLeave(object sender, EventArgs e)
        {
            nut_back.BackColor = default;
        }

        private void DangKy_Load(object sender, EventArgs e)
        {

        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true; // Chặn số và ký tự đặc biệt
            }


        }
    }
}
