using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class QuanLyNhanVien : Form
    {
        public string TenNV { get; set; }
        public string CongViec { get; set; }
        private int MaNV;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        public QuanLyNhanVien(string tenNV, string congViec, int maNV)
        {
            InitializeComponent();
            TenNV = tenNV;   // Set user information
            CongViec = congViec;
            LoadData();
            MaNV = maNV;
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM NhanVien";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi click vào cell nếu cần
        }

        private void ThemNV_Click(object sender, EventArgs e)
        {
            ThemNV themNV = new ThemNV();

            themNV.Show();
        }


        private void SuaNV_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                string tenNV = selectedRow.Cells["TenNV"].Value.ToString();
                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                string dienThoai = selectedRow.Cells["DienThoai"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string maCV = selectedRow.Cells["MaCV"].Value.ToString();

                // Mở form ThongTinNV với các thông tin cần sửa
                SuaNV suaNV = new SuaNV(maNV, tenNV, gioiTinh, ngaySinh, dienThoai, diaChi, maCV);
                suaNV.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
            }
        }


        private void XoaNV_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy mã nhân viên từ hàng được chọn
                string maNV = dataGridView1.SelectedRows[0].Cells["MaNV"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            // Sử dụng câu lệnh UPDATE để thực hiện soft delete
                            string query = "delete NhanVien WHERE MaNV = @MaNV";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaNV", maNV);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Nhân viên đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Cập nhật lại DataGridView
                                    LoadData();
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitNV_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home
            {
                TenNV = TenNV,
                CongViec = CongViec,
                MaNV = MaNV
            };
            homeForm.Show();
            this.Close();
        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            NhanVienReport nvrp = new NhanVienReport(TenNV);
            nvrp.Show();
        }
    }
}
