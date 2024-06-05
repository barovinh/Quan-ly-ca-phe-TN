using DoAn_QLPM_CafeTrungNguyen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class TonKho : Form
    {
        DbContext db = new DbContext();
        NhanVien nv = new NhanVien();
        bool roi = false;
        public TonKho(NhanVien nv)
        {
            InitializeComponent();
            this.nv = nv;
            numericUpDown1.Minimum = 1;
        }
        //private void GenerateQRCodeAndDisplay()
        //{
        //    if (roi)
        //    {
               
        //            BarcodeWriter barcodeWriter = new BarcodeWriter();
        //            barcodeWriter.Format = BarcodeFormat.QR_CODE;

        //            // Cài đặt kích thước cố định cho mã QR (ví dụ: 200x200 pixels)
        //            barcodeWriter.Options = new QrCodeEncodingOptions
        //            {
        //                Width = 150,
        //                Height = 150,
        //                CharacterSet = "UTF-8",
        //                Margin = 0, // Loại bỏ khoảng trắng xung quanh mã QR
        //            };

        //            Bitmap qrCodeBitmap = barcodeWriter.Write("123");
        //            picScan.BackgroundImage = qrCodeBitmap;

        //            //    Cài đặt kích thước cố định cho control picScan
        //            picScan.Width = 150;
        //            picScan.Height = 150;
                

        //    }

        //}

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frm_Gmail gm = Application.OpenForms["frm_Gmail"] as frm_Gmail;
            if (gm != null)
            {
                return;
            }
            else
            {
                gm = new frm_Gmail();
                gm.Show();
            }
        }

        private void TonKho_Load(object sender, EventArgs e)
        {

            loadPN();
            txtMaNV.Text = nv.MaNV;
            string sql = "DECLARE @NextInvoiceID INT;SET @NextInvoiceID = ISNULL((SELECT MAX(MaPN) FROM PHIEUNHAPKHO), 0) +1; SELECT @NextInvoiceID AS MaHoaDonTiepTheo; ";
            int maPN = (int)db.ExcuteScalar(sql);
            txtMaPN.Text = maPN.ToString();
            loadMH();
            roi = true;
            if (cbPN.Items.Count > 0)
            {
                cbPN.SelectedIndex = 0;
            
            }

            if(cbTenSP.Items.Count>0)
            {
                MatHangDAO mhDAO = new MatHangDAO();
                MatHang mathang = mhDAO.MaMatHang(cbTenSP.SelectedValue.ToString());
                if (mathang != null)
                {
                    txtMaMH.Text = mathang.MaMH;
                    txtDonGia.Text = mathang.GiaTien.ToString();
                 
                    tinhTien();
                }
            }
            loadDataGridView();

        }
        void tinhTien()
        {
            float donGia = float.Parse(txtDonGia.Text);
            float tien = donGia * (float)numericUpDown1.Value;
            txtTongTien.Text = tien.ToString("#,###,###");

        }
        // THÊM PHIẾU NHẬP VÀ CHUYỂN SANG LOAD COMBOBOX
        private void button1_Click(object sender, EventArgs e)
        {
            db.Cmd.CommandText = "INSERT INTO PHIEUNHAPKHO VALUES('" + txtMaNV.Text + "','" + dataTimeNgayVaoKho.Text + "')";
            try
            {
                int kt = db.ExcuteNonQuery(db.Cmd.CommandText);
                if (kt > 0)
                {
                    MessageBox.Show("Thêm phiếu nhập thành công");

                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }

            loadPN();
        }
        void loadPN()
        {
            db.Cmd.CommandText = "SELECT*FROM PHIEUNHAPKHO";
            DataTable dt = db.getDatatable(db.Cmd.CommandText);
            cbPN.DataSource = dt;
            cbPN.DisplayMember = "MaPN";
            cbPN.ValueMember = "MaPN";

        }
        void loadMH()
        {
            db.Cmd.CommandText = "SELECT*FROM MATHANG";
            DataTable dt = db.getDatatable(db.Cmd.CommandText);
            cbTenSP.DataSource = dt;
            cbTenSP.DisplayMember = "TenMH";
            cbTenSP.ValueMember = "MaMH";
            cbTenSP.Enabled = true;
        }

        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roi)
            {
                MatHangDAO mhDAO = new MatHangDAO();
                MatHang mathang = mhDAO.MaMatHang(cbTenSP.SelectedValue.ToString());
                if (mathang != null)
                {
                    txtMaMH.Text = mathang.MaMH;
                    txtDonGia.Text = mathang.GiaTien.ToString();

                }
            }

        }
        void loadDataGridView()
        {
            if (roi)
            {
                db.Cmd.CommandText = "SELECT CHITIETPHIEUNHAP.MaPN,MATHANG.TenMH,MATHANG.MaMH,MATHANG.GiaTien,CHITIETPHIEUNHAP.SoLuong,MATHANG.GiaTien*ChiTietPhieuNhap.SoLuong as 'ThanhTien',MaNV,NgayNhap FROM CHITIETPHIEUNHAP, PHIEUNHAPKHO, MATHANG WHERE PHIEUNHAPKHO.MaPN = '" + cbPN.SelectedValue + "'  AND PHIEUNHAPKHO.MaPN = CHITIETPHIEUNHAP.MaPN AND MATHANG.MaMH = CHITIETPHIEUNHAP.MaMH ";
                DataTable dt = db.getDatatable(db.Cmd.CommandText);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["MaPN"].Visible = false;
                dataGridView1.Columns["MaNV"].Visible = false;
                dataGridView1.Columns["NgayNhap"].Visible = false;
            }

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float donGia = float.Parse(txtDonGia.Text);
            float tien = donGia * (float)numericUpDown1.Value;
            txtTongTien.Text = tien.ToString();
        }

        private void cbPN_SelectedIndexChanged(object sender, EventArgs e)
        {
           // GenerateQRCodeAndDisplay();
            loadDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            int max = dataGridView1.Rows.Count;
            if (i >= 0 && i != max - 1)
            {
                txtMaMH.Enabled = false;             
                txtDonGia.Enabled = false;
                txtMaNV.Text = dataGridView1.Rows[i].Cells["MaNV"].Value.ToString();
                txtMaPN.Text = dataGridView1.Rows[i].Cells["MaPN"].Value.ToString();
                txtMaMH.Text = dataGridView1.Rows[i].Cells["MaMH"].Value.ToString();
                string giaTienString = dataGridView1.Rows[i].Cells["GiaTien"].Value.ToString();
                if (decimal.TryParse(giaTienString, out decimal giaTien))
                {                   
                    string formattedGiaTien = giaTien.ToString("#,###,###");
                    txtDonGia.Text = formattedGiaTien;
                }
                cbTenSP.SelectedValue = txtMaMH.Text;
                numericUpDown1.Value = int.Parse(dataGridView1.Rows[i].Cells["SoLuong"].Value.ToString());
                tinhTien();
                object ngayNhapCellValue = dataGridView1.Rows[i].Cells["NgayNhap"].Value;

                if (ngayNhapCellValue != null && ngayNhapCellValue != DBNull.Value)
                {
                    DateTime ngayNhapDateTime = (DateTime)ngayNhapCellValue;

                    // Gán giá trị của DateTimePicker
                    dataTimeNgayVaoKho.Value = ngayNhapDateTime;
                }
                 
            }
            else if(i==max-1)
            {           
                txtMaMH.Text = "";
                txtDonGia.Text = "0";
                numericUpDown1.Value = 1;
                tinhTien();
                txtMaMH.Enabled = true;         
                txtDonGia.Enabled = true;
            }

        }



        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string sql = "";
            int flag = 0;
            int temp=0;
            if(dataGridView1.Rows.Count>1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["MaMH"].Value.ToString() == txtMaMH.Text )
                    {
                        flag = 1;
                        temp = (int)dataGridView1.Rows[i].Cells["SoLuong"].Value;
                        break;
                    }
                }
            }
            
            if(flag==1)
            {
                temp += (int)numericUpDown1.Value;
                sql = "update CHITIETPHIEUNHAP set SoLuong = '"+temp+"'  where MaMH = '"+txtMaMH.Text+"' and MaPN = '"+cbPN.SelectedValue.ToString()+"'";
                if (db.ExcuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
            }
            else
            {
                temp = (int)numericUpDown1.Value;
                sql = "INSERT INTO CHITIETPHIEUNHAP VALUES(" + cbPN.SelectedValue.ToString() + "," + txtMaMH.Text + "," + temp + ")";
                if(db.ExcuteNonQuery(sql)>0)
                {
                    MessageBox.Show("Thêm thành công");

                }
           }

            loadDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE CHITIETPHIEUNHAP " +
                "SET SOLUONG = '" + numericUpDown1.Value.ToString() + "'" +
                "WHERE MAMH = '" + txtMaMH.Text + "' and MAPN='" + txtMaPN.Text + "'";
            int kt = db.ExcuteNonQuery(sql);
            if(kt>0)
            {
                MessageBox.Show("Sửa thành công");

            }
            else
            {
                MessageBox.Show("Sửa thất bại");

            }
            loadDataGridView();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string mamh = dataGridView1.Rows[i].Cells["MaMH"].Value.ToString();
            string mapn = dataGridView1.Rows[i].Cells["MaPN"].Value.ToString();
            string sql = "DELETE CHITIETPHIEUNHAP WHERE MAMH = '" + mamh + "' and MAPN = ' " + mapn + "'";
            int kt = db.ExcuteNonQuery(sql);
            if(kt>0)
            {
                MessageBox.Show("Xóa thành công");

            }
            else
            {
                MessageBox.Show("Xóa thất bại");
                
            }
            loadDataGridView(); 
        }

        private void btnXuatPhieuNhap_Click(object sender, EventArgs e)
        {
            new frm_PhieuNhapKho(cbPN.SelectedValue.ToString()).ShowDialog();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int targetColumnIndex =3; // Thay 5 bằng chỉ mục của cột bạn muốn định dạng là tiền.
            if (e.ColumnIndex == targetColumnIndex && e.Value != null && e.Value is decimal)
            {

                e.Value = string.Format("{0:0,0} VNĐ", e.Value);
                e.FormattingApplied = true;

            }
            int targetColumnIndexx = 5; // Thay 5 bằng chỉ mục của cột bạn muốn định dạng là tiền.
            if (e.ColumnIndex == targetColumnIndexx && e.Value != null && e.Value is decimal )
            {

                e.Value = string.Format("{0:0,0} VNĐ", e.Value);
                e.FormattingApplied = true;

            }
        }

        private void cbTenSP_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

      

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new NhapKho(cbPN.SelectedValue.ToString()).Show();
        }
    }
}
