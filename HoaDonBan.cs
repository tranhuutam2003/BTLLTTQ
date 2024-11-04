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
	public partial class HoaDonBan : Form
	{
		public HoaDonBan()
		{
			InitializeComponent();
			LoadItemsToListView();
			GenerateNewSoHDB();
			this.Load += new EventHandler(HoaDonBan_Load);
		}

		private void LoadItemsToListView()
		{
			using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
			{
				string query = "SELECT MaHang, TenHang, DonGiaBan FROM DanhMucHangHoa";
				SqlCommand cmd = new SqlCommand(query, conn);

				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader();

					listView1.Items.Clear();

					while (reader.Read())
					{
						ListViewItem item = new ListViewItem(reader["MaHang"].ToString());
						item.SubItems.Add(reader["TenHang"].ToString());
						item.SubItems.Add("0"); // Số lượng
						item.SubItems.Add("0"); // Giảm giá
						item.SubItems.Add(reader["DonGiaBan"].ToString()); // Đơn giá
						item.SubItems.Add("0"); // Thành tiền

						listView1.Items.Add(item);
					}

					reader.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
				}
			}
		}

		private void GenerateNewSoHDB()
		{
			using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
			{
				string query = "SELECT ISNULL(MAX(SoHDB), 0) + 1 FROM HoaDonBan";
				SqlCommand cmd = new SqlCommand(query, conn);

				try
				{
					conn.Open();
					int newSoHDB = (int)cmd.ExecuteScalar();
					txtSoHDB.Text = newSoHDB.ToString();
					txtSoHDB.Enabled = false; // Chỉ nhập 1 lần
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi tạo số hóa đơn: " + ex.Message);
				}
			}
		}

		

		private void txtSoLuong_TextChanged(object sender, EventArgs e)
		{
			UpdateThanhTien();
		}
		private void CalculateThanhTien()
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ListViewItem item = listView1.SelectedItems[0];
				decimal donGia = Convert.ToDecimal(item.SubItems[2].Text); // Đơn giá
				int soLuong = int.Parse(txtSoLuong.Text); // Số lượng
				decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);

				decimal thanhTien = (donGia * soLuong) * (1 - (giamGia / 100));
				item.SubItems[4].Text = thanhTien.ToString("N2"); // Cập nhật Thanh Tiền
			}
		}

		private void txtGiamGia_TextChanged(object sender, EventArgs e)
		{
			UpdateThanhTien();
		}
		private decimal CalculateTongTien()
		{
			decimal tongTien = 0;
			foreach (ListViewItem item in listView1.Items)
			{
				tongTien += decimal.Parse(item.SubItems[5].Text); // Cột Thành Tiền
			}
			return tongTien;
		}
		private void btnXacNhan_Click(object sender, EventArgs e)
		{
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    // Kiểm tra các tham số bắt buộc
                    if (cbMaKhach.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng trước khi xác nhận hóa đơn.");
                        return;
                    }

                    if (cbMaNV.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên trước khi xác nhận hóa đơn.");
                        return;
                    }

                    bool hasValidItem = false;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        int soLuong = string.IsNullOrEmpty(item.SubItems[2].Text) ? 0 : int.Parse(item.SubItems[2].Text);
                        if (soLuong > 0)
                        {
                            hasValidItem = true;
                            break;
                        }
                    }

                    if (!hasValidItem)
                    {
                        MessageBox.Show("Chưa chọn mặt hàng nào! Vui lòng chọn trước khi xác nhận.");
                        return;
                    }

                    string insertHDBQuery = "INSERT INTO HoaDonBan (SoHDB, MaNV, NgayBan, MaKhach, TongTien) " +
                                            "VALUES (@SoHDB, @MaNV, @NgayBan, @MaKhach, @TongTien)";
                    SqlCommand cmdHDB = new SqlCommand(insertHDBQuery, conn, transaction);
                    cmdHDB.Parameters.AddWithValue("@SoHDB", int.Parse(txtSoHDB.Text));
                    cmdHDB.Parameters.AddWithValue("@MaNV", cbMaNV.SelectedValue);
                    cmdHDB.Parameters.AddWithValue("@NgayBan", dateTimePicker1.Value);
                    cmdHDB.Parameters.AddWithValue("@MaKhach", cbMaKhach.SelectedValue);
                    cmdHDB.Parameters.AddWithValue("@TongTien", CalculateTongTien());

                    cmdHDB.ExecuteNonQuery();

                    foreach (ListViewItem item in listView1.Items)
                    {
                        int soLuong = string.IsNullOrEmpty(item.SubItems[2].Text) ? 0 : int.Parse(item.SubItems[2].Text);

                        if (soLuong > 0)
                        {
                            decimal giamGia = string.IsNullOrEmpty(item.SubItems[3].Text) ? 0 : decimal.Parse(item.SubItems[3].Text);
                            decimal thanhTien = string.IsNullOrEmpty(item.SubItems[5].Text) ? 0 : decimal.Parse(item.SubItems[5].Text);

                            string insertCTHDBQuery = "INSERT INTO ChiTietHoaDonBan (SoHDB, MaHang, SoLuong, GiamGia, ThanhTien) " +
                                                      "VALUES (@SoHDB, @MaHang, @SoLuong, @GiamGia, @ThanhTien)";
                            SqlCommand cmdCTHDB = new SqlCommand(insertCTHDBQuery, conn, transaction);
                            cmdCTHDB.Parameters.AddWithValue("@SoHDB", int.Parse(txtSoHDB.Text));
                            cmdCTHDB.Parameters.AddWithValue("@MaHang", item.SubItems[0].Text);
                            cmdCTHDB.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdCTHDB.Parameters.AddWithValue("@GiamGia", giamGia);
                            cmdCTHDB.Parameters.AddWithValue("@ThanhTien", thanhTien);
                            cmdCTHDB.ExecuteNonQuery();

                            // Cập nhật số lượng hàng tồn trong kho
                            string updateSoLuongQuery = "UPDATE DanhMucHangHoa SET SoLuong = SoLuong - @SoLuong WHERE MaHang = @MaHang";
                            SqlCommand cmdUpdateSoLuong = new SqlCommand(updateSoLuongQuery, conn, transaction);
                            cmdUpdateSoLuong.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdUpdateSoLuong.Parameters.AddWithValue("@MaHang", item.SubItems[0].Text);
                            cmdUpdateSoLuong.ExecuteNonQuery();
                        }
                    }

                    // Commit transaction
                    transaction.Commit();

                    AddNotification(cbMaNV.SelectedValue.ToString(), "hóa đơn bán");

                    MessageBox.Show("Hóa đơn đã được cập nhật thành công và số lượng tồn kho đã được điều chỉnh!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                }
            }


        }
		private void UpdateThanhTien()
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ListViewItem item = listView1.SelectedItems[0];
				int soLuong = string.IsNullOrEmpty(txtSoLuong.Text) ? 0 : int.Parse(txtSoLuong.Text);
				decimal donGia = decimal.Parse(item.SubItems[4].Text); // Đơn giá không chỉnh sửa, lấy từ cột Đơn Giá
				decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);


				item.SubItems[2].Text = soLuong.ToString(); // Cập nhật Số Lượng
				item.SubItems[3].Text = giamGia.ToString(); // Cập nhật Giảm Giá


				decimal thanhTien = (donGia * soLuong) * (1 - giamGia / 100);

				item.SubItems[5].Text = thanhTien % 1 == 0 ? thanhTien.ToString("0") : thanhTien.ToString("0.##");
			}


		}

		private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ListViewItem item = listView1.SelectedItems[0];
				txtSoLuong.Text = item.SubItems[2].Text; // Hiển thị số lượng
				txtGiamGia.Text = item.SubItems[3].Text; // Hiển thị giảm giá
			}
		}
		private void LoadKhachHangToComboBox()
		{
			using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
			{
				string query = "SELECT MaKhach, TenKhach FROM KhachHang";  // Lấy mã khách và tên khách từ bảng KhachHang
				SqlDataAdapter da = new SqlDataAdapter(query, conn);
				DataTable dt = new DataTable();
				da.Fill(dt);

				cbMaKhach.DataSource = dt;
				cbMaKhach.DisplayMember = "TenKhach";  // Hiển thị tên khách hàng
				cbMaKhach.ValueMember = "MaKhach";     // Giá trị là mã khách hàng
			}
		}

		private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		private void LoadNhanVienToComboBox()
		{
			using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
			{
				string query = "SELECT MaNV, TenNV FROM NhanVien"; // Chỉ chọn nhân viên đang hoạt động
				SqlDataAdapter da = new SqlDataAdapter(query, conn);
				DataTable dt = new DataTable();
				da.Fill(dt);

				cbMaNV.DataSource = dt;
				cbMaNV.DisplayMember = "TenNV";  // Hiển thị tên nhân viên
				cbMaNV.ValueMember = "MaNV";     // Giá trị là mã nhân viên

				if (cbMaNV.SelectedValue != null)
				{
					//MessageBox.Show("SelectedValue của ComboBox MaNV: " + cbMaNV.SelectedValue.ToString());
				}
			}
		}

		private void HoaDonBan_Load(object sender, EventArgs e)
		{
			LoadKhachHangToComboBox();
			LoadNhanVienToComboBox();
		}

        private void AddNotification(string maNV, string action)
        {
            string query = "INSERT INTO ThongBao (NguoiNhan, NoiDung, NgayTao) VALUES (@NguoiNhan, @NoiDung, @NgayTao)";
            string noiDung = $"{maNV} đã tạo {action} vào ngày {DateTime.Now:dd/MM/yyyy HH:mm}";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NguoiNhan", maNV);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@NgayTao", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
