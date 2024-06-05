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
        public partial class frm_DangNhap : Form
        {
       public static NhanVien nv;
        // public TaiKhoan tk1;
        public frm_DangNhap()
            {
                InitializeComponent();
           
                //   tk1 = new TaiKhoan();
                this.AcceptButton = btnDangNhap;
          
            }


            private void DangNhap_Load(object sender, EventArgs e)
            {

            }

            private void btnDangNhap_Click(object sender, EventArgs e)
            {
                if(txtTenDN.Text.Length==0 ||txtMatKhau.Text.Length==0)
                {
                    MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN");
                }
                else
                {
                    TaiKhoanDAO tkDAO = new TaiKhoanDAO();
                    TaiKhoan tk = new TaiKhoan();
                    tk.TenDangNhap = txtTenDN.Text;
                    tk.MatKhau = txtMatKhau.Text;
                    TaiKhoan rs = tkDAO.getTK(tk);
                    if(rs!=null)
                    {
                        if(tk.TenDangNhap == rs.TenDangNhap && tk.MatKhau == rs.MatKhau)
                    {
                      
                        TrangChu tc = new TrangChu(tk.TenDangNhap);
                    
                        tc.Show();
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tên đăng nhập");
                    }
                }
           
            }

            private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                DangKy dk = new DangKy();
                dk.Show();
                this.Visible = false;

            }
            private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
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

       
            private void txtTenDN_Leave(object sender, EventArgs e)
            {
                if(txtTenDN.Text.Length==0)
                {
                    errorProvider1.SetError(txtTenDN, "VUI LÒNG NHẬP THÔNG TIN");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }

            private void txtMatKhau_Leave(object sender, EventArgs e)
            {
                if(txtMatKhau.Text.Length==0)
                {
                    errorProvider1.SetError(txtMatKhau, "VUI LÒNG NHẬP THÔNG TIN");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }
    }
