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
	public partial class ChiTietHoaDonNhap : Form
	{
        private string soHDN;
        public ChiTietHoaDonNhap()
		{
			InitializeComponent();
			LoadData();
		}
        public ChiTietHoaDonNhap(string soHDN) : this() // Gọi constructor mặc định
        {
            this.soHDN = soHDN;
            LoadData(); // Gọi lại LoadData để hiển thị chi tiết hóa đơn được chọn
        }
        private void LoadData()
		{
            //using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            //{
            //	try
            //	{
            //		connection.Open();
            //		string query = "SELECT hdn.SoHDN, hdn.MaNV, hdn.NgayNhap, hdn.MaNCC, \r\n cthn.MaHang, cthn.SoLuong, cthn.DonGia, cthn.GiamGia, \r\n                                    cthn.ThanhTien\r\n                             FROM HoaDonNhap hdn\r\n                             INNER JOIN ChiTietHoaDonNhap cthn ON hdn.SoHDN = cthn.SoHDN\r\n";
            //		SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            //		DataTable dataTable = new DataTable();
            //		dataAdapter.Fill(dataTable);

            //		dataGridView1.DataSource = dataTable;
            //	}
            //	catch (Exception ex)
            //	{
            //		MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            //	}
            //}

            using (SqlConnection connection = new SqlConnection(databaselink.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Nếu có soHDN, chỉ lấy chi tiết của hóa đơn nhập đó
                    string query = string.IsNullOrEmpty(soHDN)
                        ? @"SELECT hdn.SoHDN, hdn.MaNV, hdn.NgayNhap, hdn.MaNCC, 
                                   cthn.MaHang, cthn.SoLuong, cthn.DonGia, cthn.GiamGia, 
                                   cthn.ThanhTien
                             FROM HoaDonNhap hdn
                             INNER JOIN ChiTietHoaDonNhap cthn ON hdn.SoHDN = cthn.SoHDN"
                        : @"SELECT hdn.SoHDN, hdn.MaNV, hdn.NgayNhap, hdn.MaNCC, 
                                   cthn.MaHang, cthn.SoLuong, cthn.DonGia, cthn.GiamGia, 
                                   cthn.ThanhTien
                             FROM HoaDonNhap hdn
                             INNER JOIN ChiTietHoaDonNhap cthn ON hdn.SoHDN = cthn.SoHDN
                             WHERE hdn.SoHDN = @SoHDN";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    if (!string.IsNullOrEmpty(soHDN))
                    {
                        // Thêm tham số nếu có soHDN
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@SoHDN", soHDN);
                    }

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
			ThemChiTietHoaDonNhap themChiTietHoaDonNhap= new ThemChiTietHoaDonNhap();
			themChiTietHoaDonNhap.ShowDialog();
			

		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			
		}
	}
}
