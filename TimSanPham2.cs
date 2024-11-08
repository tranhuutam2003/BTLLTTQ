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
    public partial class TimSanPham2 : Form
    {
        public TimSanPham2()
        {
            InitializeComponent();
            LoadData();
        }
        private DataTable GetData(string column, string table)
        {
            string query = $"SELECT {column} FROM {table}";
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
            }

            return data;
        }
        private void LoadData()
        {
            // Giả định rằng bạn đã có phương thức GetData cho từng comboBox
            cmbTen.DataSource = GetData("TenHang", "DanhMucHangHoa");
            cmbTen.DisplayMember = "TenHang";
            cmbTen.Visible = false;

            cmbMauSac.DataSource = GetData("TenMau", "MauSac");
            cmbMauSac.DisplayMember = "TenMau";
            cmbMauSac.Visible = false;

            cmbChatLieu.DataSource = GetData("TenChatLieu", "ChatLieu");
            cmbChatLieu.DisplayMember = "TenChatLieu";
            cmbChatLieu.Visible = false;

            cmbHinhDang.DataSource = GetData("TenDangMat", "HinhDangMat");
            cmbHinhDang.DisplayMember = "TenDangMat";
            cmbHinhDang.Visible = false;
        }
        private void TimSanPham2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo câu truy vấn cơ bản với các bảng liên kết
            string query = @"
        SELECT 
            h.TenHang AS 'Tên Hàng',
            l.TenLoai AS 'Loại Kính',
            g.TenLoaiGong AS 'Loại Gọng',
            d.TenDangMat AS 'Hình Dạng',
            c.TenChatLieu AS 'Chất Liệu',
            ms.TenMau AS 'Màu Sắc',
            di.TenDiop AS 'Độ Diop',
            cd.TenCongDung AS 'Công Dụng',
            dd.TenDacDiem AS 'Đặc Điểm',
            nsx.TenNuocSX AS 'Nước Sản Xuất',
            h.SoLuong AS 'Số Lượng',
            h.DonGiaNhap AS 'Đơn Giá Nhập',
            h.DonGiaBan AS 'Đơn Giá Bán',
            h.ThoiGianBaoHanh AS 'Thời Gian Bảo Hành',
            h.GhiChu AS 'Ghi Chú'
        FROM DanhMucHangHoa h
        INNER JOIN LoaiKinh l ON h.MaLoai = l.MaLoai
        INNER JOIN GongMat g ON h.MaLoaiGong = g.MaLoaiGong
        INNER JOIN HinhDangMat d ON h.MaDangMat = d.MaDangMat
        INNER JOIN ChatLieu c ON h.MaChatLieu = c.MaChatLieu
        INNER JOIN MauSac ms ON h.MaMau = ms.MaMau
        INNER JOIN Diop di ON h.MaDiop = di.MaDiop
        INNER JOIN CongDung cd ON h.MaCongDung = cd.MaCongDung
        INNER JOIN DacDiem dd ON h.MaDacDiem = dd.MaDacDiem
        INNER JOIN NuocSanXuat nsx ON h.MaNuocSX = nsx.MaNuocSX
        WHERE 1=1";

            // Thêm điều kiện vào truy vấn nếu các CheckBox tương ứng được chọn
            if (chkTen.Checked && !string.IsNullOrEmpty(cmbTen.Text))
            {
                query += $" AND h.TenHang = N'{cmbTen.Text}'";
            }
            if (chkMauSac.Checked && !string.IsNullOrEmpty(cmbMauSac.Text))
            {
                query += $" AND ms.TenMau = N'{cmbMauSac.Text}'";
            }
            if (chkChatLieu.Checked && !string.IsNullOrEmpty(cmbChatLieu.Text))
            {
                query += $" AND c.TenChatLieu = N'{cmbChatLieu.Text}'";
            }
            if (chkHinhDang.Checked && !string.IsNullOrEmpty(cmbHinhDang.Text))
            {
                query += $" AND d.TenDangMat = N'{cmbHinhDang.Text}'";
            }

            // Tạo kết nối và thực thi truy vấn
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);

                // Kiểm tra nếu không có kết quả thì xóa DataSource của DataGridView
                if (data.Rows.Count == 0)
                {
                    dataGridViewKQ.DataSource = null;
                    MessageBox.Show("Không tìm thấy sản phẩm phù hợp với tiêu chí tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridViewKQ.DataSource = data;
                }
            }
        }

        private void chkTen_CheckedChanged(object sender, EventArgs e)
        {
            cmbTen.Visible = chkTen.Checked;
        }

        private void cmbMauSac_CursorChanged(object sender, EventArgs e)
        {

        }

        private void chkMauSac_CheckedChanged(object sender, EventArgs e)
        {
            cmbMauSac.Visible = chkMauSac.Checked;
        }

        private void chkChatLieu_CheckedChanged(object sender, EventArgs e)
        {
            cmbChatLieu.Visible = chkChatLieu.Checked;
        }

        private void chkHinhDang_CheckedChanged(object sender, EventArgs e)
        {
            cmbHinhDang.Visible = chkHinhDang.Checked;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //Home home = new Home();
            this.Close();
        }
    }
}
