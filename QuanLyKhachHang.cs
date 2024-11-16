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
    public partial class QuanLyKhachHang : Form
    {
        private string TenNV;
        private string CongViec;
        private int MaNV;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            LoadData();
            this.Activated += QuanLykhachhnag_Activated;
        }
        private void QuanLykhachhnag_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
        public QuanLyKhachHang(string tenNV, string congViec, int maNV)
        {
            InitializeComponent();
            TenNV = tenNV;  
            CongViec = congViec;
            LoadData();
            MaNV = maNV;
            this.Activated += QuanLykhachhnag_Activated;
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaKhach,TenKhach,DiaChi,DienThoai FROM KhachHang";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }

        private void themKH_Click(object sender, EventArgs e)
        {
            ThemKH themkh = new ThemKH();
            themkh.Show();
        }

        private void suaKH_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maKH = selectedRow.Cells["MaKhach"].Value.ToString();
                string tenKH = selectedRow.Cells["TenKhach"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string dienThoai = selectedRow.Cells["DienThoai"].Value.ToString();

                // Mở form ThongTinNV với các thông tin cần sửa
                SuaKH suaKH = new SuaKH(maKH, tenKH, diaChi, dienThoai);
                suaKH.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
            }
        }

        private void exit_Click(object sender, EventArgs e)
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

        private void xoaKH_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maKhach = dataGridView1.SelectedRows[0].Cells["MaKhach"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MaKhach", maKhach);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Khách hàng đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Mã khách hàng này đã tồn tại trong hóa đơn! Không thể xóa.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            KhachHangReport khrp = new KhachHangReport(TenNV);
            khrp.Show();
        }
    }
}
