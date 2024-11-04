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
    public partial class ChiTietDoanhThu : Form
    {
        private DateTime fromDate;
        private DateTime toDate;
        public ChiTietDoanhThu()
        {
            InitializeComponent();
        }

        public ChiTietDoanhThu(DateTime from, DateTime to)
        {
            InitializeComponent();
            fromDate = from;
            toDate = to;
        }

        private void ChiTietDoanhThu_Load(object sender, EventArgs e)
        {
            // Hiển thị khoảng thời gian đã chọn trên Label
            labelThoiGian.Text = $"Doanh thu từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}";

            string query = @"
                SELECT 
                    NgayThang,
                    DoanhThuBan,
                    DoanhThuNhap,
                    DoanhThuThuần
                FROM 
                    DoanhThu
                WHERE 
                    NgayThang BETWEEN @fromDate AND @toDate
                ORDER BY 
                    NgayThang;";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chartChiTietDoanhThu.Series["DoanhThuBan"].Name = "Doanh Thu";
                chartChiTietDoanhThu.Series["DoanhThuNhap"].Name = "Chi Phí Nhập";
                chartChiTietDoanhThu.Series["DoanhThuThuần"].Name = "Lợi Nhuận";

                chartChiTietDoanhThu.Series["Doanh Thu"].Points.Clear();
                chartChiTietDoanhThu.Series["Chi Phí Nhập"].Points.Clear();
                chartChiTietDoanhThu.Series["Lợi Nhuận"].Points.Clear();

                decimal totalDoanhThuBan = 0, totalDoanhThuNhap = 0, totalDoanhThuThuan = 0;

                while (reader.Read())
                {
                    DateTime ngay = (DateTime)reader["NgayThang"];
                    decimal doanhThuBan = (decimal)reader["DoanhThuBan"];
                    decimal doanhThuNhap = (decimal)reader["DoanhThuNhap"];
                    decimal doanhThuThuan = (decimal)reader["DoanhThuThuần"];

                    // Cộng dồn tổng doanh thu
                    totalDoanhThuBan += doanhThuBan;
                    totalDoanhThuNhap += doanhThuNhap;
                    totalDoanhThuThuan += doanhThuThuan;

                    // Thêm điểm vào biểu đồ
                    chartChiTietDoanhThu.Series["Doanh Thu"].Points.AddXY(ngay, doanhThuBan);
                    chartChiTietDoanhThu.Series["Chi Phí Nhập"].Points.AddXY(ngay, doanhThuNhap);
                    chartChiTietDoanhThu.Series["Lợi Nhuận"].Points.AddXY(ngay, doanhThuThuan);
                }

                // Đóng reader
                reader.Close();

                // Cập nhật giá trị cho Label
                labelDoanhThuBan.Text = $"Doanh Thu: {totalDoanhThuBan:C}";
                labelDoanhThuNhap.Text = $"Chi Phí Nhập: {totalDoanhThuNhap:C}";
                labelDoanhThuThuan.Text = $"Lợi Nhuận: {totalDoanhThuThuan:C}";

                chartChiTietDoanhThu.ChartAreas[0].AxisX.Minimum = fromDate.ToOADate();
                chartChiTietDoanhThu.ChartAreas[0].AxisX.Maximum = toDate.ToOADate();

            }
        }

        private void chartChiTietDoanhThu_Click(object sender, EventArgs e)
        {

        }
    }
}
