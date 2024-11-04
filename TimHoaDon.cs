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
    public partial class TimHoaDon : Form
    {
        public TimHoaDon()
        {
            InitializeComponent();
            InitializeListView();
            LoadComboBoxMaHD();
        }

        private void InitializeListView()
        {
            listViewHoaDon.View = View.Details;
            listViewHoaDon.Columns.Add("Mã Hóa Đơn", 100);
            listViewHoaDon.Columns.Add("Mã NV", 100);
            listViewHoaDon.Columns.Add("Ngày", 120);
            listViewHoaDon.Columns.Add("Mã Khách/NCC", 120);
            listViewHoaDon.Columns.Add("Tổng Tiền", 150);
        }
        private void LoadComboBoxMaHD()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                string query = "SELECT SoHDB FROM HoaDonBan UNION SELECT SoHDN FROM HoaDonNhap";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbMaHD.Items.Add(reader["SoHDB"]); // Hoặc reader["SoHDN"] nếu cần
                }

                reader.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT SoHDB AS MaHD, MaNV, NgayBan AS Ngay, MaKhach AS MaKhachNCC, TongTien
                                 FROM HoaDonBan
                                 WHERE (@MaHD IS NULL OR SoHDB = @MaHD)
                                 UNION ALL
                                 SELECT SoHDN AS MaHD, MaNV, NgayNhap AS Ngay, MaNCC AS MaKhachNCC, TongTien
                                 FROM HoaDonNhap
                                 WHERE (@MaHD IS NULL OR SoHDN = @MaHD)";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Thêm điều kiện tìm kiếm cho mã hóa đơn
                if (cbMaHD.SelectedItem != null)
                {
                    cmd.Parameters.AddWithValue("@MaHD", cbMaHD.SelectedItem.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaHD", DBNull.Value);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                listViewHoaDon.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["MaHD"].ToString());
                    item.SubItems.Add(row["MaNV"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["MaKhachNCC"].ToString());
                    item.SubItems.Add(Convert.ToDecimal(row["TongTien"]).ToString("N2"));

                    listViewHoaDon.Items.Add(item);
                }
            }
        }

        private void TimHoaDon_Load(object sender, EventArgs e)
        {
            cbMaHD.SelectedIndex = -1;
        }
    }
}
