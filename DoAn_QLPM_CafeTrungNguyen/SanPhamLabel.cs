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
    public partial class SanPhamLabel : UserControl
    {
        public string TenSP { get; set; }
        public int SoLuong { get; set; }

        public SanPhamLabel()
        {
            InitializeComponent();
         

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void SanPhamLabel_Load(object sender, EventArgs e)
        {
            lblTenSP.Text = TenSP;
            lblSoLuong.Text = SoLuong.ToString();
        }
    }
}
