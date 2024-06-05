
namespace DoAn_QLPM_CafeTrungNguyen
{
    partial class NhapKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataNhapKho = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.picScan = new System.Windows.Forms.PictureBox();
            this.MaPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhapKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataNhapKho
            // 
            this.dataNhapKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataNhapKho.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataNhapKho.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataNhapKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataNhapKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPN,
            this.TenMH,
            this.GiaTien,
            this.SoLuong,
            this.ThanhTien,
            this.MaNV,
            this.NgayNhap});
            this.dataNhapKho.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNhapKho.Location = new System.Drawing.Point(0, 612);
            this.dataNhapKho.Name = "dataNhapKho";
            this.dataNhapKho.RowHeadersWidth = 62;
            this.dataNhapKho.RowTemplate.Height = 28;
            this.dataNhapKho.Size = new System.Drawing.Size(1405, 279);
            this.dataNhapKho.TabIndex = 1;
            this.dataNhapKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataNhapKho_CellClick);
            this.dataNhapKho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataNhapKho_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(560, 532);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(326, 57);
            this.label7.TabIndex = 25;
            this.label7.Text = "Quét mã Scan";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(458, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(590, 58);
            this.label11.TabIndex = 32;
            this.label11.Text = "THÔNG TIN NHẬP KHO";
            // 
            // picScan
            // 
            this.picScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picScan.Location = new System.Drawing.Point(532, 98);
            this.picScan.Name = "picScan";
            this.picScan.Size = new System.Drawing.Size(384, 421);
            this.picScan.TabIndex = 2;
            this.picScan.TabStop = false;
            // 
            // MaPN
            // 
            this.MaPN.DataPropertyName = "MaPN";
            this.MaPN.HeaderText = "Mã phiếu nhập";
            this.MaPN.MinimumWidth = 8;
            this.MaPN.Name = "MaPN";
            // 
            // TenMH
            // 
            this.TenMH.DataPropertyName = "TenMH";
            this.TenMH.HeaderText = "Tên mặt hàng";
            this.TenMH.MinimumWidth = 8;
            this.TenMH.Name = "TenMH";
            // 
            // GiaTien
            // 
            this.GiaTien.DataPropertyName = "GiaTien";
            this.GiaTien.HeaderText = "Giá tiền";
            this.GiaTien.MinimumWidth = 8;
            this.GiaTien.Name = "GiaTien";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.MinimumWidth = 8;
            this.ThanhTien.Name = "ThanhTien";
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 8;
            this.MaNV.Name = "MaNV";
            // 
            // NgayNhap
            // 
            this.NgayNhap.DataPropertyName = "NgayNhap";
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.MinimumWidth = 8;
            this.NgayNhap.Name = "NgayNhap";
            // 
            // NhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1405, 891);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picScan);
            this.Controls.Add(this.dataNhapKho);
            this.Name = "NhapKho";
            this.Text = "NhapKho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataNhapKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataNhapKho;
        private System.Windows.Forms.PictureBox picScan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
    }
}