using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class DoiMatKhau : Form
    {
        private readonly string userEmail;

        

        public DoiMatKhau(string email)
        {
            InitializeComponent();
            userEmail = email;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Xác minh mật khẩu hiện tại và cập nhật mật khẩu mới
                    string query = "UPDATE NhanVien SET MkNV = @NewPassword WHERE emailNV = @Email AND MkNV = @CurrentPassword";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@CurrentPassword", currentPassword);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu hiện tại không đúng hoặc lỗi trong quá trình đổi mật khẩu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đổi mật khẩu: {ex.Message}");
                }
            }
        }
    }
}
