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
    public partial class QuanLyNhaCungCap : Form
    {
        private string TenNV;
        private string CongViec;
        private int MaNV;
        public QuanLyNhaCungCap()
        {
            InitializeComponent();
            LoadData();
        }

        public QuanLyNhaCungCap(string tenNV, string congViec,int maNV)
        {
            InitializeComponent();
            TenNV = tenNV; 
            CongViec = congViec;
            MaNV = maNV;
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * from NhaCungCap";
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
        private void ThemNCC_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.Mode = "Them";
            if (nhaCungCap.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Tải lại dữ liệu sau khi thêm
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maNCC = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaNCC"].Value);

                NhaCungCap nhaCungCap = new NhaCungCap();
                nhaCungCap.Mode = "Sua";
                nhaCungCap.MaNCC = maNCC;
                if (nhaCungCap.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Tải lại dữ liệu sau khi sửa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để sửa.");
            }
        }

        private void XoaNhaCungCap(int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNCC", maNCC);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhà cung cấp thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maNCC = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaNCC"].Value);
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    XoaNhaCungCap(maNCC);
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhaCungCapReport nccrp = new NhaCungCapReport();
            nccrp.Show();
        }
    }
}
