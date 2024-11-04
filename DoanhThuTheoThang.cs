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
    public partial class DoanhThuTheoThang : Form
    {
        public DoanhThuTheoThang()
        {
            InitializeComponent();
        }

        private void doanhthu_Click(object sender, EventArgs e)
        {

        }

        private void DoanhThuTheoThang_Load(object sender, EventArgs e)
        {
            string query = @"
                WITH ThangNam AS (
                    SELECT DATEFROMPARTS(YEAR(GETDATE()), Thang, 1) AS ThangNam
                    FROM (VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12)) AS Thang(Thang)
                )
                SELECT 
                    YEAR(TN.ThangNam) AS Nam,
                    MONTH(TN.ThangNam) AS Thang,
                    ISNULL(SUM(DT.DoanhThuBan), 0) AS DoanhThuBan,
                    ISNULL(SUM(DT.DoanhThuNhap), 0) AS DoanhThuNhap,
                    ISNULL(SUM(DT.DoanhThuBan - DT.DoanhThuNhap), 0) AS DoanhThuThuần
                FROM 
                    ThangNam TN
                LEFT JOIN 
                    DoanhThu DT ON YEAR(DT.NgayThang) = YEAR(TN.ThangNam) AND MONTH(DT.NgayThang) = MONTH(TN.ThangNam)
                GROUP BY 
                    YEAR(TN.ThangNam), MONTH(TN.ThangNam)
                ORDER BY 
                    Nam, Thang;";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chartdoanhthu.Series["DoanhThuBan"].Name = "Doanh Thu";
                chartdoanhthu.Series["DoanhThuNhap"].Name = "Chi Phí Nhập";
                chartdoanhthu.Series["DoanhThuThuần"].Name = "Lợi Nhuận";
                // Xóa dữ liệu cũ trong các series
                chartdoanhthu.Series["Doanh Thu"].Points.Clear();
                chartdoanhthu.Series["Chi Phí Nhập"].Points.Clear();
                chartdoanhthu.Series["Lợi Nhuận"].Points.Clear();

                while (reader.Read())
                {
                    string month = $"{reader["Thang"]}/{reader["Nam"]}";
                    decimal doanhThuBan = (decimal)reader["DoanhThuBan"];
                    decimal doanhThuNhap = (decimal)reader["DoanhThuNhap"];
                    decimal doanhThuThuan = (decimal)reader["DoanhThuThuần"];

                    // Thêm điểm dữ liệu vào biểu đồ cho từng loại doanh thu
                    chartdoanhthu.Series["Doanh Thu"].Points.AddXY(month, doanhThuBan);
                    chartdoanhthu.Series["Chi Phí Nhập"].Points.AddXY(month, doanhThuNhap);
                    chartdoanhthu.Series["Lợi Nhuận"].Points.AddXY(month, doanhThuThuan);
                }
                reader.Close();
            }
        }
    }
}
