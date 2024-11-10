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
    public partial class DoanhThu : Form
    {
        private string TenNV;
        private string CongViec;
        private int MaNV;
        public DoanhThu()
        {
            InitializeComponent();
        }

        public DoanhThu(string tenNV, string congViec, int maNV)
        {
            InitializeComponent();
            TenNV = tenNV;   // Set user information
            CongViec = congViec;
            MaNV = maNV;
        }
        private void btnxemdoanhthu_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpngaybatdau.Value;
            DateTime denNgay = dtpngayketthuc.Value;

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                conn.Open();
                string query = @"SELECT NgayThang, DoanhThuBan, DoanhThuNhap, DoanhThuThuần
                                 FROM DoanhThu
                                 WHERE NgayThang BETWEEN @TuNgay AND @DenNgay";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["NgayThang"].HeaderText = "Ngày Tháng";
                dataGridView1.Columns["DoanhThuBan"].HeaderText = "Doanh Thu";
                dataGridView1.Columns["DoanhThuNhap"].HeaderText = "Chi Phí Nhập";
                dataGridView1.Columns["DoanhThuThuần"].HeaderText = "Lợi Nhuận";

                // Tính tổng
                decimal totalDoanhThuBan = 0;
                decimal totalDoanhThuNhap = 0;
                decimal totalDoanhThuThuan = 0;

                foreach (DataRow row in dt.Rows)
                {
                    totalDoanhThuBan += Convert.ToDecimal(row["DoanhThuBan"]);
                    totalDoanhThuNhap += Convert.ToDecimal(row["DoanhThuNhap"]);
                    totalDoanhThuThuan += Convert.ToDecimal(row["DoanhThuThuần"]);
                }

                lblTongDoanhThuBan.Text = "Tổng Doanh Thu Bán: " + totalDoanhThuBan.ToString("N2");
                lblTongDoanhThuNhap.Text = "Tổng Chi Phí Nhập: " + totalDoanhThuNhap.ToString("N2");
                lblTongDoanhThuThuan.Text = "Doanh Thu Thuần: " + totalDoanhThuThuan.ToString("N2");
            }
            ChiTietDoanhThu ctdt = new ChiTietDoanhThu(tuNgay, denNgay);
            ctdt.Show();

        }

        private void btnexit_Click(object sender, EventArgs e)
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

        private void btnxemdoanhthutheothang_Click(object sender, EventArgs e)
        {
            DoanhThuTheoThang dttt = new DoanhThuTheoThang();
            dttt.Show();
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void dtpngayketthuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTongDoanhThuBan_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoanhThuReport dtrp = new DoanhThuReport(TenNV);
            dtrp.Show();   
        }
    }
}
