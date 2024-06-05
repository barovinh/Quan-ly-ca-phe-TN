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
    public partial class ItemMatHang : UserControl
    {
        public string Loai { get; set; }
        public string MaMH { get; set; }
        public string TenSP { get; set; }
        public bool Check { get; set; }
        public float Gia { get; set; }
        public Image HinhAnh { get; set; }
        public string DuongDan { get; set; }
        public int SoLuong { get; set; }
        // Property công khai để đọc giá trị Check từ bên ngoài
        public Action<object, EventArgs> CheckChanged { get; internal set; }

        public ItemMatHang()
        {
            InitializeComponent();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ItemMatHang_Click(object sender, EventArgs e)
        {
            if(Check)
            {
                btnCheck.Visible = false;
                Check = false;
            }
            else
            {
                btnCheck.Visible = true;
                Check = true;
            }
           
        }

        private void ItemMatHang_Load(object sender, EventArgs e)
        {
            txtName.Text = TenSP;
            SoLuongTon.Text += " " + SoLuong.ToString();
            this.BackgroundImage = HinhAnh;
            if (SoLuong == 0)
            {
                panelHetHang.Visible = true;
                panelHetHang.BackColor = Color.FromArgb(12, Color.Black);
            }
            else
            {
                panelHetHang.Visible = false;
            }
            

        }
        public void Checked(bool check)
        {
            if(check)
            {
                btnCheck.Visible = true;
                Check = true;
            }
            else
            {
                btnCheck.Visible = false;
                Check = false;
            }
        }

        private void panelHetHang_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
