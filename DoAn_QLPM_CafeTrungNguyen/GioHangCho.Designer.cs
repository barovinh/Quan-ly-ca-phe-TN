
namespace DoAn_QLPM_CafeTrungNguyen
{
    partial class GioHangCho
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblGia = new System.Windows.Forms.Label();
            this.BtnXoa = new System.Windows.Forms.Button();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lebal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.BurlyWood;
            this.numericUpDown1.Location = new System.Drawing.Point(332, 32);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 26);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(440, 38);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(34, 20);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá";
            this.lblGia.Click += new System.EventHandler(this.lblGia_Click);
            // 
            // BtnXoa
            // 
            this.BtnXoa.BackColor = System.Drawing.Color.Cornsilk;
            this.BtnXoa.BackgroundImage = global::DoAn_QLPM_CafeTrungNguyen.Properties.Resources.xoa_icon_removebg_preview;
            this.BtnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnXoa.Location = new System.Drawing.Point(7, 24);
            this.BtnXoa.Name = "BtnXoa";
            this.BtnXoa.Size = new System.Drawing.Size(44, 27);
            this.BtnXoa.TabIndex = 3;
            this.BtnXoa.UseVisualStyleBackColor = false;
            this.BtnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // txtTenSP
            // 
            this.txtTenSP.BackColor = System.Drawing.Color.Turquoise;
            this.txtTenSP.Enabled = false;
            this.txtTenSP.Location = new System.Drawing.Point(64, 13);
            this.txtTenSP.Multiline = true;
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(252, 51);
            this.txtTenSP.TabIndex = 4;
            // 
            // lebal
            // 
            this.lebal.AutoSize = true;
            this.lebal.Location = new System.Drawing.Point(440, 8);
            this.lebal.Name = "lebal";
            this.lebal.Size = new System.Drawing.Size(34, 20);
            this.lebal.TabIndex = 5;
            this.lebal.Text = "Giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tổng";
            // 
            // labelTong
            // 
            this.labelTong.AutoSize = true;
            this.labelTong.Location = new System.Drawing.Point(505, 38);
            this.labelTong.Name = "labelTong";
            this.labelTong.Size = new System.Drawing.Size(0, 20);
            this.labelTong.TabIndex = 7;
            // 
            // GioHangCho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.labelTong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lebal);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.BtnXoa);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "GioHangCho";
            this.Size = new System.Drawing.Size(618, 78);
            this.Load += new System.EventHandler(this.GioHangCho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Button BtnXoa;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lebal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTong;
    }
}
