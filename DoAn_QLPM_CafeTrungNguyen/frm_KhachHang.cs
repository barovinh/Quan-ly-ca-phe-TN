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
    public partial class frm_KhachHang : Form
    {
        DataColumn[] key = new DataColumn[1];
        DataTable d_KH = new DataTable();
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            new ThemKhachHang_full().ShowDialog();

        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            KhachHangDAO khDAO = new KhachHangDAO();
            string sql = "SELECT*FROM KHACHHANG";
            d_KH = khDAO.getDatatable(sql);
            dataGridView.DataSource = d_KH;
            key[0] = d_KH.Columns["MaKH"];
            d_KH.PrimaryKey = key;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.Text== "Tìm kiếm theo tên,số điện thoại")
            {
                txtSearch.Text = "";

            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Tìm kiếm theo tên,số điện thoại";

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            int max = dataGridView.Rows.Count;
            if(i >= 0 && i != max - 1)
            {
                txtTenKH.Text = dataGridView.Rows[i].Cells[1].Value.ToString();
                txtSDT.Text = dataGridView.Rows[i].Cells[2].Value.ToString();
                txtEmail.Text = dataGridView.Rows[i].Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridView.Rows[i].Cells[4].Value.ToString();
                txtMaKH.Text = dataGridView.Rows[i].Cells[0].Value.ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemKhachHang_full th = new ThemKhachHang_full();
            th.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView.DataSource;
            DataRow dr = dt.Rows.Find(txtMaKH.Text);
            if (dr != null)
            {
                dr["Email"] = txtEmail.Text;
                dr["DiaChi"] = txtDiaChi.Text;
                dr["SDT"] = txtSDT.Text;
                dr["TenKH"] = txtTenKH.Text;
                DbContext db = new DbContext();
                int kt = db.UpdateData("SELECT *FROM KHACHHANG", dt);
                if(kt>0)
                {
                    MessageBox.Show("Sửa thành công");

                }
                else
                {
                    MessageBox.Show("Sửa thất bại");

                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureSearch_Click(object sender, EventArgs e)
        {
            DbContext db = new DbContext();
            DataTable dta = db.getDatatable("SELECT*FROM KHACHHANG WHERE TenKH like '%"+txtSearch.Text+"%' or SDT = '"+txtSearch.Text+"'");
            if(dta.Rows.Count>0)
            {
                dataGridView.DataSource = dta;
            }
            else
            {
                dataGridView.DataSource = d_KH;
            }

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frm_KhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

