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
	public partial class ChiTietHoaDonBan : Form
	{
        private int soHDB;
        public ChiTietHoaDonBan(int soHDB)
		{
			InitializeComponent();
			this.soHDB = soHDB;
			LoadData();
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
							cthdb.SoHDB, 
							cthdb.MaHang, 
							dh.TenHang, 
							cthdb.SoLuong, 
							cthdb.GiamGia, 
							cthdb.ThanhTien
						FROM 
							ChiTietHoaDonBan cthdb
						JOIN 
							DanhMucHangHoa dh ON cthdb.MaHang = dh.MaHang
						WHERE 
							cthdb.SoHDB = @SoHDB";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SoHDB", this.soHDB);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
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

		private void Quaylai_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ThanhTien")
            {
                if (e.Value != DBNull.Value && e.Value != null)
                {
                    decimal value = Convert.ToDecimal(e.Value);

                    // Kiểm tra nếu số không có phần thập phân khác 0
                    if (value % 1 == 0)
                    {
                        e.Value = value.ToString("0"); // Hiển thị chỉ phần nguyên nếu không có phần thập phân
                    }
                    else
                    {
                        e.Value = value.ToString("0.##");  // Hiển thị tối đa 2 chữ số thập phân nếu có phần lẻ
                    }
                    e.FormattingApplied = true;
                }
            }
        }

		private void exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		
	}
}
