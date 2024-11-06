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
    
    public partial class TimKhachHang : Form
    {
        private BindingSource bindingSourceMaKH = new BindingSource();
    private BindingSource bindingSourceTenKH = new BindingSource();
        public TimKhachHang()
        {
            InitializeComponent();
            LoadComboBoxDataKH();

            // Thiết lập ListView cho khách hàng
            listViewKetQuaKH.View = View.Details;
            listViewKetQuaKH.Columns.Add("Mã KH", 80);
            listViewKetQuaKH.Columns.Add("Tên KH", 150);
            listViewKetQuaKH.Columns.Add("Địa Chỉ", 80);
            listViewKetQuaKH.Columns.Add("Điện Thoại", 100);
            listViewKetQuaKH.Columns.Add("Tổng Tiền Đã Mua", 120);

            // Thiết lập ListView cho lịch sử mua hàng
            listViewLichSuMua.View = View.Details;
            listViewLichSuMua.Columns.Add("Tên Sản Phẩm", 150);
            listViewLichSuMua.Columns.Add("Số Lượng", 80);
            listViewLichSuMua.Columns.Add("Ngày Mua", 100);
            listViewLichSuMua.Columns.Add("Tổng Tiền", 100);
        }
        private void LoadLichSuMuaHang(string maKhach)
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();

                // Câu truy vấn để lấy lịch sử mua hàng
                string query = @"
                    SELECT 
                        dmh.TenHang AS TenSanPham,
                        cthdb.SoLuong,
                        hdb.NgayBan AS NgayMua,
                        cthdb.ThanhTien AS TongTien
                    FROM 
                        ChiTietHoaDonBan cthdb
                    JOIN 
                        HoaDonBan hdb ON cthdb.SoHDB = hdb.SoHDB
                    JOIN 
                        DanhMucHangHoa dmh ON cthdb.MaHang = dmh.MaHang
                    WHERE 
                        hdb.MaKhach = @MaKhach
                    ORDER BY 
                        hdb.NgayBan DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", maKhach);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Xóa dữ liệu cũ trong ListView
                    listViewLichSuMua.Items.Clear();

                    // Thêm dữ liệu mới vào ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TenSanPham"].ToString());
                        item.SubItems.Add(reader["SoLuong"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["NgayMua"]).ToString("dd/MM/yyyy"));
                        //item.SubItems.Add(reader["TongTien"].ToString());
                        decimal tongtien = Convert.ToDecimal(reader["TongTien"]);
                        item.SubItems.Add(tongtien % 1 == 0 ? tongtien.ToString("0") : tongtien.ToString("0.##"));
                        listViewLichSuMua.Items.Add(item);
                    }

                    reader.Close();
                }
            }
        }

        private void LoadComboBoxDataKH()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT MaKhach, TenKhach FROM KhachHang", conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Tạo BindingSource cho ComboBox của khách hàng
                    bindingSourceMaKH.DataSource = dt;
                    bindingSourceTenKH.DataSource = dt.Copy();

                    comboBoxMaKH.DataSource = bindingSourceMaKH;
                    comboBoxMaKH.DisplayMember = "MaKhach";
                    comboBoxMaKH.ValueMember = "MaKhach";

                    comboBoxTenKH.DataSource = bindingSourceTenKH;
                    comboBoxTenKH.DisplayMember = "TenKhach";
                    comboBoxTenKH.ValueMember = "MaKhach";
                }
            }
            comboBoxMaKH.SelectedIndexChanged += comboBoxMaKH_SelectedIndexChanged;
            comboBoxTenKH.SelectedIndexChanged += comboBoxTenKH_SelectedIndexChanged;
        }


            private void buttonTimKH_Click(object sender, EventArgs e)
        {

            string maKH = comboBoxMaKH.SelectedValue?.ToString();
            string tenKH = comboBoxTenKH.Text;

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        kh.MaKhach, 
                        kh.TenKhach, 
                        kh.DiaChi, 
                        kh.DienThoai,
                        ISNULL(SUM(cthdb.ThanhTien), 0) AS TongTienDaMua
                    FROM 
                        KhachHang kh
                    LEFT JOIN 
                        HoaDonBan hdb ON kh.MaKhach = hdb.MaKhach
                    LEFT JOIN 
                        ChiTietHoaDonBan cthdb ON hdb.SoHDB = cthdb.SoHDB
                    WHERE 
                        1=1";

                if (!string.IsNullOrEmpty(maKH))
                    query += " AND kh.MaKhach = @MaKhach";
                if (!string.IsNullOrEmpty(tenKH))
                    query += " AND kh.TenKhach LIKE '%' + @TenKhach + '%'";

                query += " GROUP BY kh.MaKhach, kh.TenKhach, kh.DiaChi, kh.DienThoai";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maKH))
                        cmd.Parameters.AddWithValue("@MaKhach", maKH);
                    if (!string.IsNullOrEmpty(tenKH))
                        cmd.Parameters.AddWithValue("@TenKhach", tenKH);

                    SqlDataReader reader = cmd.ExecuteReader();

                    listViewKetQuaKH.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaKhach"].ToString());
                        item.SubItems.Add(reader["TenKhach"].ToString());
                        item.SubItems.Add(reader["DiaChi"].ToString());
                        item.SubItems.Add(reader["DienThoai"].ToString());
                        decimal tongTiendamua = Convert.ToDecimal(reader["TongTienDaMua"]);
                        item.SubItems.Add(tongTiendamua % 1 == 0 ? tongTiendamua.ToString("0") : tongTiendamua.ToString("0.##"));
                        listViewKetQuaKH.Items.Add(item);
                    }

                    reader.Close();
                }
            }

            if (!string.IsNullOrEmpty(maKH))
            {
                LoadLichSuMuaHang(maKH);
            }
        }

        private void comboBoxMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaKH.SelectedValue != null)
            {
                string selectedMaKH = comboBoxMaKH.SelectedValue.ToString();
                DataTable dtTenKH = ((DataTable)bindingSourceTenKH.DataSource);
                for (int i = 0; i < dtTenKH.Rows.Count; i++)
                {
                    if (dtTenKH.Rows[i]["MaKhach"].ToString() == selectedMaKH)
                    {
                        comboBoxTenKH.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void comboBoxTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenKH.SelectedValue != null)
            {
                string selectedMaKH = comboBoxTenKH.SelectedValue.ToString();
                DataTable dtMaKH = ((DataTable)bindingSourceMaKH.DataSource);
                for (int i = 0; i < dtMaKH.Rows.Count; i++)
                {
                    if (dtMaKH.Rows[i]["MaKhach"].ToString() == selectedMaKH)
                    {
                        comboBoxMaKH.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listViewKetQuaKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewLichSuMua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
