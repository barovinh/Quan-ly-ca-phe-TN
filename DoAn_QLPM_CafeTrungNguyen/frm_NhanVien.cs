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
    public partial class frm_NhanVien : Form
    {
        DataColumn[] key = new DataColumn[1];
        DataTable d_nhanvien = new DataTable();
        public NhanVien NV { get; set; }
        public frm_NhanVien(NhanVien nv)
        {
            InitializeComponent();
            NV = nv;
            if (int.Parse(nv.ChucVu) == 2)
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
            loadData();

        }
        void loadData()
        {
            this.Refresh();
            NhanVienDAO nvDAO = new NhanVienDAO();
            DataTable dt = nvDAO.getDatatable("select*from NHANVIEN");
            d_nhanvien = dt;
            key[0] = d_nhanvien.Columns["MaNV"];
            dataGridView.DataSource = d_nhanvien;
            d_nhanvien.PrimaryKey = key;
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            int max = dataGridView.Rows.Count;
            if (i >= 0 && i != max - 1)
            {
                string chucvu = dataGridView.Rows[i].Cells["ChucVu"].Value.ToString();
                if(chucvu=="2")
                {
                    comboBox1.SelectedItem = "Quản lý";

                }
                else
                {
                    comboBox1.SelectedItem = "Nhân viên bán hàng";
                }
                txtGioiTinh.Text = dataGridView.Rows[i].Cells["GioiTinh"].Value.ToString();
                txtMaNV.Text = dataGridView.Rows[i].Cells["MaNV"].Value.ToString();
               maskedTextBox1.Text = dataGridView.Rows[i].Cells["NgaySinh"].Value.ToString();
                txtSDT.Text = dataGridView.Rows[i].Cells["SDT"].Value.ToString();
                txtTenNhanVien.Text = dataGridView.Rows[i].Cells["TenNV"].Value.ToString();
            }

            else
            {
                comboBox1.SelectedIndex = 0;
                txtGioiTinh.Clear();
                txtMaNV.Clear();
                maskedTextBox1.Clear();
                txtSDT.Clear();
                txtTenNhanVien.Clear();
                txtTimKiem.Clear();
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int targetColum = 4;
            if (e.ColumnIndex == targetColum && e.Value != null && e.Value is int)
            {
                if ((int)e.Value == 2)
                {
                    e.Value = string.Format("{0:Quản lý}", e.Value);
                }
                else
                {
                    e.Value = string.Format("{0:Nhân viên}", e.Value);
                }
            }
        }

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt =d_nhanvien;
            DataRow dr = dt.Rows.Find(txtMaNV.Text);
            if (dr != null)
            {
                dr["TenNV"] = txtTenNhanVien.Text;
                dr["NgaySinh"] = maskedTextBox1.Text;
                dr["SDT"] = txtSDT.Text;
                DbContext Db = new DbContext();
                    int kt = Db.UpdateData("select *from NHANVIEN", dt);
                    if (kt > 0)
                    {
                        MessageBox.Show("Sửa thành công");

                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }

            }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frm_ThemNhanVien().ShowDialog();
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = "Tìm kiếm theo tên";

            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm theo tên")
            {
                txtTimKiem.Text = "";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DbContext db = new DbContext();
            DataTable dta = db.getDatatable("SELECT*FROM NHANVIEN WHERE TenNV like '%" + txtTimKiem.Text + "%'");
            if (dta.Rows.Count > 0)
            {
                dataGridView.DataSource = dta;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn ", "Thông báo");

                dataGridView.DataSource = d_nhanvien;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DbContext db = new DbContext();
            db.Cmd.CommandText = "delete TAIKHOAN where MaNV='" + txtMaNV.Text + "'";
            if(db.ExcuteNonQuery(db.Cmd.CommandText)>0)
            {
                MessageBox.Show("Xóa thành công");

            }
            else
            {
                MessageBox.Show("Xóa thất bại");

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void frm_NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        
    }
}
