using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
	public partial class QuanLyHoaDonNhap : Form
	{
        private string TenNV;
        private string CongViec;
		private int MaNV;
        public QuanLyHoaDonNhap()
		{
			InitializeComponent();
			LoadData();
            this.Activated += QuanLyHoaDonNhap_Activated;
        }

        public QuanLyHoaDonNhap(string tenNV, string congViec, int maNV)
        {
            InitializeComponent();
            TenNV = tenNV;   
            CongViec = congViec;
            LoadData();
            MaNV = maNV;
            this.Activated += QuanLyHoaDonNhap_Activated;
        }

        private void LoadData()
		{
			using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
			{
				try
				{
					connection.Open();
                    string query = @"
                SELECT 
                    hdn.SoHDN,
                    hdn.NgayNhap AS NgayTao, -- Thêm cột Ngày tạo hóa đơn
                    hdn.MaNV,
                    hdn.MaNCC,
                    COUNT(cthn.MaHang) AS LoaiMatHang, 
                    SUM(cthn.SoLuong) AS TongSoLuong, 
                    SUM(cthn.ThanhTien) AS TongTien 
                FROM 
                    HoaDonNhap hdn
                INNER JOIN 
                    ChiTietHoaDonNhap cthn ON hdn.SoHDN = cthn.SoHDN
                GROUP BY 
                    hdn.SoHDN, hdn.NgayNhap, hdn.MaNV, hdn.MaNCC
                ORDER BY 
                    hdn.NgayNhap DESC;";
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

		private void button1_Click(object sender, EventArgs e)
		{
			ThemChiTietHoaDonNhap2 themChiTietHoaDonNhap2 = new ThemChiTietHoaDonNhap2(TenNV,MaNV);
			themChiTietHoaDonNhap2.Show();
		}


		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
				string soHDN = selectedRow.Cells["SoHDN"].Value.ToString(); 
				DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn nhập này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
					{
						try
						{
							connection.Open();
							SqlTransaction transaction = connection.BeginTransaction(); 

							string deleteChiTietQuery = "DELETE FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN";
							SqlCommand deleteChiTietCommand = new SqlCommand(deleteChiTietQuery, connection, transaction);
							deleteChiTietCommand.Parameters.AddWithValue("@SoHDN", soHDN);
							deleteChiTietCommand.ExecuteNonQuery();

							string deleteHoaDonQuery = "DELETE FROM HoaDonNhap WHERE SoHDN = @SoHDN";
							SqlCommand deleteHoaDonCommand = new SqlCommand(deleteHoaDonQuery, connection, transaction);
							deleteHoaDonCommand.Parameters.AddWithValue("@SoHDN", soHDN);
							int result = deleteHoaDonCommand.ExecuteNonQuery();

							if (result > 0)
							{
								transaction.Commit(); 
								MessageBox.Show("Xóa hóa đơn nhập thành công.");
								LoadData();
							}
							else
							{
								transaction.Rollback(); 
								MessageBox.Show("Xóa hóa đơn nhập thất bại.");
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn hóa đơn nhập cần xóa.");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{


            if (dataGridView1.SelectedRows.Count > 0)
            {
                string soHDN = dataGridView1.SelectedRows[0].Cells["SoHDN"].Value.ToString();

                ChiTietHoaDonNhap chiTietHoaDonNhap = new ChiTietHoaDonNhap(soHDN);
                chiTietHoaDonNhap.StartPosition = FormStartPosition.Manual;
                chiTietHoaDonNhap.Location = this.Location;
                chiTietHoaDonNhap.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn nhập cần xem chi tiết.");
            }
        }

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "TongTien")
			{
				if (e.Value != DBNull.Value && e.Value != null)
				{
					decimal value = Convert.ToDecimal(e.Value);

					e.Value = value % 1 == 0 ? value.ToString("0") : value.ToString("0.##");
					e.FormattingApplied = true;
				}
			}
			if (dataGridView1.Columns[e.ColumnIndex].Name == "DonGia")
			{
				if (e.Value != DBNull.Value && e.Value != null)
				{
					decimal value = Convert.ToDecimal(e.Value);

					e.Value = value % 1 == 0 ? value.ToString("0") : value.ToString("0.##");
					e.FormattingApplied = true;
				}
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
        private void QuanLyHoaDonNhap_Activated(object sender, EventArgs e)
        {
            LoadData(); 
        }
        private void QuanLyHoaDonNhap_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
			HoaDonNhapReport hdnrp = new HoaDonNhapReport(TenNV);
			hdnrp.Show();
        }
    }
}
