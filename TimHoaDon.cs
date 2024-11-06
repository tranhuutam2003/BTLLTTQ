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
            listViewHoaDon.Columns.Add("Mã Hóa Đơn", 75);
            listViewHoaDon.Columns.Add("Tên Khách", 109);
            listViewHoaDon.Columns.Add("Mã Khách", 70);
            
            listViewHoaDon.Columns.Add("Tên Nhân Viên", 109);
            listViewHoaDon.Columns.Add("Mã Nhân Viên", 88);
            listViewHoaDon.Columns.Add("Ngày Bán", 80);
            
            listViewHoaDon.Columns.Add("Tên Hàng", 134);
            listViewHoaDon.Columns.Add("Số Lượng", 65);
            listViewHoaDon.Columns.Add("Tổng Tiền", 79);
            listViewHoaDon.Columns.Add("Giảm Giá%", 70);
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
                string query = @"
            SELECT 
                hdb.SoHDB AS MaHD,
                nv.TenNV AS TenNhanVien,
                hdb.MaNV AS MaNVB,
                hdb.NgayBan AS Ngay,
                kh.MaKhach AS MaKhach,
                kh.TenKhach AS TenKhach,
                dm.TenHang AS TenHang,
                cthdb.SoLuong,
                cthdb.ThanhTien AS TongTienTungMon,
                cthdb.GiamGia
            FROM 
                HoaDonBan hdb
            INNER JOIN 
                ChiTietHoaDonBan cthdb ON hdb.SoHDB = cthdb.SoHDB
            INNER JOIN 
                NhanVien nv ON hdb.MaNV = nv.MaNV
            INNER JOIN 
                KhachHang kh ON hdb.MaKhach = kh.MaKhach
            INNER JOIN 
                DanhMucHangHoa dm ON cthdb.MaHang = dm.MaHang
            WHERE 
                (@MaHD IS NULL OR hdb.SoHDB = @MaHD)
            ORDER BY 
                hdb.SoHDB";

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
                    item.SubItems.Add(row["TenKhach"].ToString());
                    item.SubItems.Add(row["MaKhach"].ToString());
                    item.SubItems.Add(row["TenNhanVien"].ToString());
                    item.SubItems.Add(row["MaNVB"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy"));
                    
                    
                    item.SubItems.Add(row["TenHang"].ToString());
                    item.SubItems.Add(row["SoLuong"].ToString());
                    decimal tongTien = Convert.ToDecimal(row["TongTienTungMon"]);
                    decimal giamGia = Convert.ToDecimal(row["GiamGia"]);

                    item.SubItems.Add(tongTien % 1 == 0 ? tongTien.ToString("0") : tongTien.ToString("0.##"));
                    item.SubItems.Add(giamGia % 1 == 0 ? giamGia.ToString("0") : giamGia.ToString("0.##"));

                    listViewHoaDon.Items.Add(item);

                }
            }
        }

        private void TimHoaDon_Load(object sender, EventArgs e)
        {
            cbMaHD.SelectedIndex = -1;
        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
