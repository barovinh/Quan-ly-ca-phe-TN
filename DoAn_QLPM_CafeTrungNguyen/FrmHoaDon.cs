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
    public partial class FrmHoaDon : Form
    {
        DbContext Db = new DbContext();
        DataColumn[] key = new DataColumn[1];
        DataTable d_hoadon = new DataTable();
        public NhanVien NV { get; set; }
        public FrmHoaDon(NhanVien nv)
        {
            InitializeComponent();
            NV = nv;
            if (int.Parse(nv.ChucVu) == 2)
            {
              btnSua.Enabled = true;
              btnXoa.Enabled = true;
                xoaToolStripMenuItem.Visible= true;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                xoaToolStripMenuItem.Visible = false;
            }
            string sql = "SELECT*FROM HOADON";
            d_hoadon = Db.getDatatable(sql);
            key[0] = d_hoadon.Columns["MaHD"];
            d_hoadon.PrimaryKey = key;
            loadCBNV();
            cbMaNV.SelectedItem = string.Empty;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
                
            dataGridView.DataSource = d_hoadon;
        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            string mahd = dataGridView.Rows[i].Cells[0].Value.ToString();
            HoaDonDAO hdDAO = new HoaDonDAO();
            string query = "UPDATE HOADON SET TinhTrang = 0 WHERE MAHD = '"+mahd+"'";
           if( hdDAO.ExcuteNonQuery(query)>0)
            {
                MessageBox.Show("Xóa thành công");

            }
            else
            {
                MessageBox.Show("Xóa thất bại");

            }
            HoaDon_Load(sender,e);
        }
        void loadCBNV()
        {
            DataTable dt = Db.getDatatable("SELECT * FROM NHANVIEN");

            // Tạo một DataRow mới với giá trị rỗng
            DataRow emptyRow = dt.NewRow();
            emptyRow["MaNV"] = DBNull.Value; // hoặc có thể gán giá trị rỗng khác
            emptyRow["TenNV"] = DBNull.Value; // hoặc có thể gán giá trị rỗng khác

            // Thêm DataRow rỗng vào DataTable tại vị trí đầu tiên
            dt.Rows.InsertAt(emptyRow, 0);
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";
            cbMaNV.ValueMember = "MaNV";
         //   cbMaNV.selected
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void xemChiTietToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            string mahd = dataGridView.Rows[i].Cells[0].Value.ToString();
            new Frm_ChiTietHoaDon(mahd).ShowDialog();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            int max = dataGridView.Rows.Count;
            if (i >= 0 && i != max - 1)
            {
                txtMaHD.Text = dataGridView.Rows[i].Cells[0].Value.ToString();
                maskNgayLap.Text = dataGridView.Rows[i].Cells[1].Value.ToString();
                string maNV = dataGridView.Rows[i].Cells[2].Value.ToString();
                cbMaNV.SelectedValue = maNV;
                NhanVienDAO nvDAO = new NhanVienDAO();
                NhanVien nv = nvDAO.searchMaNhanVien(maNV);
                txtHoTen.Text = nv.TenNV;
                string makh = dataGridView.Rows[i].Cells[3].Value.ToString();
                KhachHangDAO khDAO = new KhachHangDAO();
                KhachHang kh = khDAO.SearchKH(makh);
                txtTenKhachHang.Text = kh.TenKH;
                txtSDT.Text = kh.SDT;
                txtMaHD.Enabled = false;
                txtHoTen.Enabled = false;
            }
            else
            {
                txtHoTen.Enabled = true;
                txtMaHD.Enabled = true;
                maskNgayLap.Clear();
                txtMaHD.Clear();
                txtHoTen.Clear();
             //   txtMaNV.Clear();
                txtSDT.Clear();
                txtTenKhachHang.Clear();
                cbMaNV.SelectedIndex = 0;
            }

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int targetColumnIndex = 5; // Thay 5 bằng chỉ mục của cột bạn muốn định dạng là tiền.
            if (e.ColumnIndex == targetColumnIndex && e.Value != null && e.Value is decimal)
            {
                
                    e.Value = string.Format("{0:0,0} VNĐ", e.Value);
                    e.FormattingApplied = true;
                
            }
            int targetTinhTrang = 6;
            if(e.ColumnIndex == targetTinhTrang && e.Value !=null && e.Value is int)
            {
               if((int)e.Value ==1)
                {
                    e.Value = string.Format("{0:Hoàn thành}", e.Value);
                }
                else
                {
                    e.Value = string.Format("{0:Đã hủy}", e.Value);
                }
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            string mahd = dataGridView.Rows[i].Cells[0].Value.ToString();
            HoaDonDAO hdDAO = new HoaDonDAO();
            string query = "UPDATE HOADON SET TinhTrang = 0 WHERE MAHD = '" + mahd + "'";
            if (hdDAO.ExcuteNonQuery(query) > 0)
            {
                MessageBox.Show("Xóa thành công");

            }
            else
            {
                MessageBox.Show("Xóa thất bại");

            }
            HoaDon_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView.DataSource;
            DataRow dr = dt.Rows.Find(txtMaHD.Text);
            if (dr != null)
            {
                if (cbMaNV.SelectedValue.ToString() == string.Empty)
                {               
                    MessageBox.Show("Không được để trống mã nhân viên khi sửa");
                    return;
                }
                else
                {
                    dr["MaNV"] = int.Parse(cbMaNV.SelectedValue.ToString());
                    dr["NgayLap"] = maskNgayLap.Text;
                    int kt = Db.UpdateData("select *from HOADON", dt);
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
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = Db.getDatatable("SELECT *FROM HOADON WHERE MaHD='" + txtNoiDungTimKiem.Text + "'");
           if (dt.Rows.Count>0)
            {
                dataGridView.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn ", "Thông báo");

                dataGridView.DataSource = d_hoadon;
            }
        }

        private void FrmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

