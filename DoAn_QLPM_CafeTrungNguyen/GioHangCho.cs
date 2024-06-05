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
    public partial class GioHangCho : UserControl
    {
        public string MaMH { get; set; }
        public string TenSP { get; set; }
        public float Gia { get; set; }
        public int SLTon { get; set; }
        public bool Xoa { get; set; }
        public int TongTien { get; set; }
        public int SoLuong
        {
            get
            {
                return (int)numericUpDown1.Value; 
            }
            set
            {

            }
        }
        public GioHangCho()
        {        
            InitializeComponent();
        }
        private void GioHangCho_Load(object sender, EventArgs e)
        {
            txtTenSP.Text = TenSP;
            lblGia.Text = string.Format("{0:#,##0}", Gia);
            TongTien = (int)(SoLuong * Gia);
            labelTong.Text = string.Format("{0:#,##0} VNĐ", TongTien);
        }

        public event EventHandler SomeChanged;
        public void numericUpDown1_ValueChanged(object sendaer, EventArgs e)
        {
            
            SoLuong = (int)numericUpDown1.Value;
            if(SoLuong>SLTon)
            {
                MessageBox.Show("Không đủ mặt hàng");
                numericUpDown1.Value = SLTon;
                return;
            }
            TongTien = (int)(SoLuong * Gia);
            labelTong.Text = TongTien.ToString();
            // Khi giá trị thay đổi, gọi sự kiện SomeChanged để thông báo về sự thay đổi.
            SomeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void lblGia_Click(object sender, EventArgs e)
        {

        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            Xoa = true;
            this.Dispose();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
