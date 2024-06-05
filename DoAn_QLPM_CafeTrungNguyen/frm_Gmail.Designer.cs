
namespace DoAn_QLPM_CafeTrungNguyen
{
    partial class frm_Gmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Gmail));
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNguoiNhan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChuDe = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTepDinhKem = new System.Windows.Forms.Button();
            this.txtTepDinhKem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(220, 183);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(732, 176);
            this.txtNoiDung.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nội dung";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Người nhận";
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.Location = new System.Drawing.Point(220, 33);
            this.txtNguoiNhan.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Size = new System.Drawing.Size(732, 42);
            this.txtNguoiNhan.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "Chủ đề";
            // 
            // txtChuDe
            // 
            this.txtChuDe.Location = new System.Drawing.Point(220, 105);
            this.txtChuDe.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtChuDe.Name = "txtChuDe";
            this.txtChuDe.Size = new System.Drawing.Size(732, 42);
            this.txtChuDe.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(220, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "Gửi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTepDinhKem
            // 
            this.btnTepDinhKem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTepDinhKem.Location = new System.Drawing.Point(586, 367);
            this.btnTepDinhKem.Name = "btnTepDinhKem";
            this.btnTepDinhKem.Size = new System.Drawing.Size(159, 50);
            this.btnTepDinhKem.TabIndex = 7;
            this.btnTepDinhKem.Text = "Tệp đính kèm";
            this.btnTepDinhKem.UseVisualStyleBackColor = true;
            this.btnTepDinhKem.Click += new System.EventHandler(this.btnTepDinhKem_Click);
            // 
            // txtTepDinhKem
            // 
            this.txtTepDinhKem.Enabled = false;
            this.txtTepDinhKem.Location = new System.Drawing.Point(220, 375);
            this.txtTepDinhKem.Name = "txtTepDinhKem";
            this.txtTepDinhKem.Size = new System.Drawing.Size(346, 42);
            this.txtTepDinhKem.TabIndex = 8;
            // 
            // frm_Gmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(991, 580);
            this.Controls.Add(this.txtTepDinhKem);
            this.Controls.Add(this.btnTepDinhKem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtChuDe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNguoiNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDung);
            this.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frm_Gmail";
            this.Text = "frm_Gmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNguoiNhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChuDe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTepDinhKem;
        private System.Windows.Forms.TextBox txtTepDinhKem;
    }
}