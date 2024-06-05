using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_QLPM_CafeTrungNguyen
{
    public partial class frm_Gmail : Form
    {
        public frm_Gmail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTepDinhKem.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Báo cáo không được bỏ trống file!");
                return;
            }
            string from, to, content;

            from = "caphetrungnguyen1996@gmail.com";
            to = txtNguoiNhan.Text.Trim();
            content = txtNoiDung.Text;

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = txtChuDe.Text.Trim();
            mail.Body = content;

            string attachmentPath = txtTepDinhKem.Text.Trim();
           
            if (!string.IsNullOrEmpty(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath, MediaTypeNames.Application.Octet);
                mail.Attachments.Add(attachment);
            }

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            // Sử dụng mật khẩu ứng dụng hoặc mật khẩu tài khoản Gmail
            string password = "bytj nkve ukzd ypuh";

            smtp.Credentials = new NetworkCredential(from, password);

            try
            {
                smtp.Send(mail);
                MessageBox.Show("Gửi thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            reset();
        }

        void reset()
        {
            txtTepDinhKem.Text = "";
            txtChuDe.Text = "";
            txtNguoiNhan.Text = "";
            txtNoiDung.Text = "";
            txtTepDinhKem.Enabled = false; 
        }
        private void btnTepDinhKem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel files (*.xlsx, *.xls)|*.xlsx;*.xls" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {                
                   txtTepDinhKem.Text = ofd.FileName;
                }
            }
            txtTepDinhKem.Enabled = true;
        }
    }
}
