using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_LTTQ_VIP
{
    public partial class ResetPassword : Form
    {
        private string verificationCode;
        private string email;
        public ResetPassword()
        {
            InitializeComponent();
        }
        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); 
        }

        private void SendVerificationEmail(string email, string code)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("thucxitrum18@gmail.com", "bziuvhxhqrhylubx"), 
                    EnableSsl = true,
                };

                smtpClient.Send("thucxitrum18@gmail.com", email, "Mã xác nhận", $"Mã xác nhận của bạn là: {code}");
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show($"Lỗi SMTP: {smtpEx.Message}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi gửi email: {ex.Message}");
            }
        }
        private void sendemailcode_Click(object sender, EventArgs e)
        {
            email = Email.Text;
            verificationCode = GenerateVerificationCode();

            // Gửi mã xác nhận
            SendVerificationEmail(email, verificationCode);

            MessageBox.Show("Mã xác nhận đã được gửi tới email của bạn.");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        private void xacnhan_Click(object sender, EventArgs e)
        {
            string enteredCode = MaXacNhan.Text;
            string newPassword = MKMoi.Text;
            string confirmPassword = NLMKMoi.Text;

            // Kiểm tra mã xác nhận
            if (enteredCode == verificationCode) // Kiểm tra với mã đã gửi
            {
                if (newPassword == confirmPassword)
                {
                    // Cập nhật mật khẩu trong cơ sở dữ liệu
                    UpdatePassword(email, newPassword);
                    MessageBox.Show("Mật khẩu đã được thay đổi thành công!");
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp.");
                }
            }
            else
            {
                MessageBox.Show("Mã xác nhận không đúng.");
            }
        }
        private void UpdatePassword(string email, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE NhanVien SET MkNV = @NewPassword WHERE emailNV = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", newPassword); 
                        command.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Mật khẩu đã được cập nhật thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên với email này.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật mật khẩu: {ex.Message}");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void exit_Click(object sender, EventArgs e)
        {
            //Account account = new Account();
            this.Close();
        }
    }
}
