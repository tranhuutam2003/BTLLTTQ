using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BTL_LTTQ_VIP
{
    public partial class QuanLyHoaDonBan : Form
    {
        private string TenNV;
        private string CongViec;
        private int MaNV;


        public QuanLyHoaDonBan()
        {
            InitializeComponent();
			LoadData();
        }

        public QuanLyHoaDonBan(string tenNV, string congViec, int maNV)
        {
            InitializeComponent();
            TenNV = tenNV;
            MaNV = maNV;// Set user information
            CongViec = congViec;
            LoadData();
        }

        private void LoadData()
		{
			using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
			{
				try
				{
					conn.Open();

					//string query = @"SELECT hdb.SoHDB, hdb.MaNV, hdb.NgayBan, hdb.MaKhach, 
					//                               cthdb.MaHang, cthdb.SoLuong, cthdb.GiamGia, cthdb.ThanhTien
					//                           FROM HoaDonBan hdb
					//                           INNER JOIN ChiTietHoaDonBan cthdb ON hdb.SoHDB = cthdb.SoHDB";

					string query = @"SELECT 
    hdb.SoHDB,
    hdb.MaNV,
    hdb.NgayBan,
    hdb.MaKhach,
    SUM(ct.Soluong) AS TongSoLuongSanPham,
    hdb.TongTien AS ThanhTien
FROM 
    HoaDonBan hdb
JOIN 
    ChiTietHoaDonBan ct ON hdb.SoHDB = ct.SoHDB
GROUP BY 
    hdb.SoHDB, hdb.MaNV, hdb.NgayBan, hdb.MaKhach, hdb.TongTien;
";


					// Tạo một SqlDataAdapter để lấy dữ liệu
					SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

					// Tạo một DataTable để chứa dữ liệu
					DataTable dt = new DataTable();

					// Điền dữ liệu vào DataTable
					adapter.Fill(dt);

					// Gán dữ liệu cho DataGridView
					dataGridView1.DataSource = dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
				}
			}
		}

		private void exit_Click(object sender, EventArgs e)
		{
            Home homeForm = new Home
            {
                TenNV = TenNV,
                CongViec = CongViec
            };
            homeForm.Show();
            this.Close();

        }

        //Xem chi tiet hoa don ban
        private void btnXemChiTiet_Click(object sender, EventArgs e)
		{
            //ChiTietHoaDonBan chiTietHoaDon= new ChiTietHoaDonBan();
            //chiTietHoaDon.StartPosition = FormStartPosition.Manual;
            //chiTietHoaDon.Location = this.Location;
            //chiTietHoaDon.Show();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy SoHDB từ hàng được chọn trong DataGridView
                int soHDB = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SoHDB"].Value);

                // Mở form ChiTietHoaDonBan với SoHDB đã chọn
                ChiTietHoaDonBan chiTietHoaDon = new ChiTietHoaDonBan(soHDB);
                chiTietHoaDon.StartPosition = FormStartPosition.CenterScreen;
                chiTietHoaDon.ShowDialog();  // Sử dụng ShowDialog để form hiện lên ở chế độ hộp thoại
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.");
            }
        }

	

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridView1.Columns[e.ColumnIndex].Name == "TongTien")
			{
				if (e.Value != DBNull.Value && e.Value != null)
				{
					decimal value = Convert.ToDecimal(e.Value);

					if (value % 1 == 0)
					{
						e.Value = value.ToString("0"); 
					}
					else
					{
						e.Value = value.ToString("0.##");  
					}
					e.FormattingApplied = true;
				}
			}
		}

		private void btnThemHD_Click(object sender, EventArgs e)
		{
            HoaDonBan hoaDonBan = new HoaDonBan(TenNV, MaNV);
            hoaDonBan.Show();
        }

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnXoaHD_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
				string soHDB = selectedRow.Cells["SoHDB"].Value.ToString(); // "SoHDB" là tên cột chứa mã hóa đơn
				DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
					{
						try
						{
							connection.Open();
							SqlTransaction transaction = connection.BeginTransaction(); // Bắt đầu giao dịch

							string deleteChiTietQuery = "DELETE FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB";
							SqlCommand deleteChiTietCommand = new SqlCommand(deleteChiTietQuery, connection, transaction);
							deleteChiTietCommand.Parameters.AddWithValue("@SoHDB", soHDB);
							deleteChiTietCommand.ExecuteNonQuery();

							string deleteHoaDonQuery = "DELETE FROM HoaDonBan WHERE SoHDB = @SoHDB";
							SqlCommand deleteHoaDonCommand = new SqlCommand(deleteHoaDonQuery, connection, transaction);
							deleteHoaDonCommand.Parameters.AddWithValue("@SoHDB", soHDB);
							int result = deleteHoaDonCommand.ExecuteNonQuery();

							if (result > 0)
							{
								transaction.Commit(); // Xác nhận giao dịch
								MessageBox.Show("Xóa hóa đơn thành công.");
								LoadData(); // Tải lại dữ liệu sau khi xóa
							}
							else
							{
								transaction.Rollback(); // Hủy giao dịch nếu không thành công
								MessageBox.Show("Xóa hóa đơn thất bại.");
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
				MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.");
			}
		}

		private void QuanLyHoaDonBan_Load(object sender, EventArgs e)
		{

		}

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string soHDB = selectedRow.Cells["SoHDB"].Value.ToString();

                string query = @"
        SELECT 
            hdb.NgayBan, 
            kh.TenKhach, 
            nv.TenNV, 
            dh.TenHang, 
            cthdb.SoLuong, 
            cthdb.ThanhTien,
            hdb.TongTien
        FROM 
            HoaDonBan hdb
        JOIN 
            KhachHang kh ON hdb.MaKhach = kh.MaKhach
        JOIN 
            ChiTietHoaDonBan cthdb ON hdb.SoHDB = cthdb.SoHDB
        JOIN 
            DanhMucHangHoa dh ON cthdb.MaHang = dh.MaHang
        JOIN 
            NhanVien nv ON hdb.MaNV = nv.MaNV
        WHERE 
            hdb.SoHDB = @SoHDB";

                using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoHDB", soHDB);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        PrintDocument printDocument = new PrintDocument();
                        printDocument.PrintPage += (s, ev) =>
                        {
                            float yPosition = ev.MarginBounds.Top;
                            float lineHeight = ev.Graphics.MeasureString("Test", new Font("Arial", 12)).Height;

                            // Vị trí x-axis cho các cột
                            float xTenHang = ev.MarginBounds.Left;
                            float xSoLuong = xTenHang + 200; // Đặt cột "Số Lượng" cách cột "Tên Hàng" 200 pixel
                            float xThanhTien = xSoLuong + 100; // Đặt cột "Thành Tiền" cách cột "Số Lượng" 100 pixel

                            // Tiêu đề hóa đơn
                            ev.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight * 2;

                            ev.Graphics.DrawString($"Mã Hóa Đơn: {soHDB}", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            ev.Graphics.DrawString($"Tên Khách Hàng: {dt.Rows[0]["TenKhach"]}", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            ev.Graphics.DrawString($"Ngày Bán: {Convert.ToDateTime(dt.Rows[0]["NgayBan"]).ToString("dd/MM/yyyy")}", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            ev.Graphics.DrawString($"Nhân Viên Bán Hàng: {dt.Rows[0]["TenNV"]}", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            ev.Graphics.DrawString("--------------------------------------------------", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            // Tiêu đề cột
                            ev.Graphics.DrawString("Tên Hàng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, xTenHang, yPosition);
                            ev.Graphics.DrawString("Số Lượng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, xSoLuong, yPosition);
                            ev.Graphics.DrawString("Thành Tiền", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, xThanhTien, yPosition);
                            yPosition += lineHeight;

                            ev.Graphics.DrawString("--------------------------------------------------", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            // Hiển thị từng sản phẩm trong hóa đơn
                            foreach (DataRow row in dt.Rows)
                            {
                                string tenHang = row["TenHang"].ToString();
                                string soLuong = row["SoLuong"].ToString();
                                string thanhTien = Convert.ToDecimal(row["ThanhTien"]).ToString("C");

                                ev.Graphics.DrawString(tenHang, new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                                ev.Graphics.DrawString(soLuong, new Font("Arial", 12), Brushes.Black, xSoLuong, yPosition);
                                ev.Graphics.DrawString(thanhTien, new Font("Arial", 12), Brushes.Black, xThanhTien, yPosition);

                                yPosition += lineHeight;
                            }

                            ev.Graphics.DrawString("--------------------------------------------------", new Font("Arial", 12), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight;

                            // Tổng tiền của hóa đơn
                            decimal tongTienHoaDon = Convert.ToDecimal(dt.Rows[0]["TongTien"]);
                            ev.Graphics.DrawString($"Tổng Tiền Hóa Đơn: {tongTienHoaDon:C}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, xTenHang, yPosition);
                            yPosition += lineHeight * 2;

                            // Dòng cảm ơn
                            ev.Graphics.DrawString("Cảm ơn quý khách đã mua hàng!", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, xTenHang, yPosition);
                        };

                        // Hiển thị hộp thoại in
                        PrintDialog printDialog = new PrintDialog();
                        printDialog.Document = printDocument;

                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            printDocument.Print();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy chi tiết hóa đơn.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in.");
            }

        }
    }
}
