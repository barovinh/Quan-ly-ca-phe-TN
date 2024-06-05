
namespace DoAn_QLPM_CafeTrungNguyen
{
    partial class ItemMatHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.PictureBox();
            this.panelHetHang = new System.Windows.Forms.Panel();
            this.SoLuongTon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.GreenYellow;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 138);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(191, 53);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Cà phê Trung Nguyên";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Chartreuse;
            this.btnCheck.BackgroundImage = global::DoAn_QLPM_CafeTrungNguyen.Properties.Resources.check_removebg_preview;
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheck.Location = new System.Drawing.Point(198, 146);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(37, 47);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.TabStop = false;
            this.btnCheck.Visible = false;
            // 
            // panelHetHang
            // 
            this.panelHetHang.BackgroundImage = global::DoAn_QLPM_CafeTrungNguyen.Properties.Resources.hethang_removebg_preview;
            this.panelHetHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHetHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHetHang.Location = new System.Drawing.Point(0, 0);
            this.panelHetHang.Name = "panelHetHang";
            this.panelHetHang.Size = new System.Drawing.Size(235, 140);
            this.panelHetHang.TabIndex = 3;
            this.panelHetHang.Visible = false;
            this.panelHetHang.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHetHang_Paint);
            // 
            // SoLuongTon
            // 
            this.SoLuongTon.AutoSize = true;
            this.SoLuongTon.BackColor = System.Drawing.Color.GreenYellow;
            this.SoLuongTon.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoLuongTon.Location = new System.Drawing.Point(55, 166);
            this.SoLuongTon.Name = "SoLuongTon";
            this.SoLuongTon.Size = new System.Drawing.Size(90, 19);
            this.SoLuongTon.TabIndex = 4;
            this.SoLuongTon.Text = "Số lượng tồn:";
            // 
            // ItemMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoAn_QLPM_CafeTrungNguyen.Properties.Resources.ca_phe_sp_trung_bay;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelHetHang);
            this.Controls.Add(this.SoLuongTon);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtName);
            this.DoubleBuffered = true;
            this.Name = "ItemMatHang";
            this.Size = new System.Drawing.Size(235, 191);
            this.Load += new System.EventHandler(this.ItemMatHang_Load);
            this.Click += new System.EventHandler(this.ItemMatHang_Click);
            ((System.ComponentModel.ISupportInitialize)(this.btnCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox btnCheck;
        private System.Windows.Forms.Panel panelHetHang;
        private System.Windows.Forms.Label SoLuongTon;
    }
}
