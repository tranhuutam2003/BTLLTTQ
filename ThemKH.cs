using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemKH : Form
    {
        public ThemKH()
        {
            InitializeComponent();
        }

        private void Xacnhan_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(SDTKH.Text, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai) " +
                                   "VALUES (@MaKH, @TenKH, @DiaChi, @DienThoai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKH", MaKH.Text);
                        command.Parameters.AddWithValue("@TenKH", TenKH.Text);
                        command.Parameters.AddWithValue("@DienThoai", SDTKH.Text);
                        command.Parameters.AddWithValue("@DiaChi", DiaChiKH.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm khách hàng thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                }
            }
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private int GenerateNewID()
        {
            int newID = 1;

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(MaKhach) FROM KhachHang";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            newID = Convert.ToInt32(result) + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo mã hàng mới: " + ex.Message);
                }
            }

            return newID;
        }
        private void ThemKH_Load(object sender, EventArgs e)
        {
            MaKH.Text = GenerateNewID().ToString();
        }
    }
}
