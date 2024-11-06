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
    public partial class ThemCongDung : Form
    {
        public ThemCongDung()
        {
            InitializeComponent();
        }

        private void xacnhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO CongDung (MaCongDung, TenCongDung) " +
                                   "VALUES (@MaCongDung, @TenCongDung)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@MaCongDung", Ma.Text);
                        command.Parameters.AddWithValue("@TenCongDung", Ten.Text);
                        // Thực thi câu lệnh
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm công dụng thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm công dụng: " + ex.Message);
                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemCongDung_Load(object sender, EventArgs e)
        {

        }
    }
}
