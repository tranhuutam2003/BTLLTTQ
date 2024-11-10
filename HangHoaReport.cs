using Microsoft.Reporting.WinForms;
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
    public partial class HangHoaReport : Form
    {
        private string TenNV;
        public HangHoaReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
            LoadSanPham();
        }

        private void HangHoaReport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            // Truy vấn chính để lấy dữ liệu sản phẩm
            string query = @"SELECT dmh.MaHang, dmh.TenHang, lk.TenLoai, gm.TenLoaiGong, hdm.TenDangMat, cl.TenChatLieu, dp.TenDiop, 
                                    cd.TenCongDung, dd.TenDacDiem, ms.TenMau, nsx.TenNuocSX, dmh.SoLuong, dmh.DonGiaNhap, 
                                    dmh.DonGiaBan, dmh.ThoiGianBaoHanh, dmh.GhiChu
                             FROM DanhMucHangHoa dmh
                             JOIN LoaiKinh lk ON dmh.MaLoai = lk.MaLoai
                             JOIN GongMat gm ON dmh.MaLoaiGong = gm.MaLoaiGong
                             JOIN HinhDangMat hdm ON dmh.MaDangMat = hdm.MaDangMat
                             JOIN ChatLieu cl ON dmh.MaChatLieu = cl.MaChatLieu
                             JOIN Diop dp ON dmh.MaDiop = dp.MaDiop
                             JOIN CongDung cd ON dmh.MaCongDung = cd.MaCongDung
                             JOIN DacDiem dd ON dmh.MaDacDiem = dd.MaDacDiem
                             JOIN MauSac ms ON dmh.MaMau = ms.MaMau
                             JOIN NuocSanXuat nsx ON dmh.MaNuocSX = nsx.MaNuocSX";

            string totalRevenueQuery = @"SELECT SUM(cthd.SoLuong * dmh.DonGiaBan) AS TotalRevenue
                                     FROM ChiTietHoaDonBan cthd
                                     JOIN DanhMucHangHoa dmh ON cthd.MaHang = dmh.MaHang";

            // Truy vấn sản phẩm được mua nhiều nhất
            string mostPurchasedProductQuery = @"SELECT TOP 1 dmh.TenHang, SUM(cthd.SoLuong) AS TotalQuantity
                                                 FROM ChiTietHoaDonBan cthd
                                                 JOIN DanhMucHangHoa dmh ON cthd.MaHang = dmh.MaHang
                                                 GROUP BY dmh.TenHang
                                                 ORDER BY TotalQuantity DESC";

            // Truy vấn sản phẩm có tổng tiền bán cao nhất
            string highestRevenueProductQuery = @"SELECT TOP 1 dmh.TenHang, SUM(cthd.SoLuong * dmh.DonGiaBan) AS TotalRevenue
                                                  FROM ChiTietHoaDonBan cthd
                                                  JOIN DanhMucHangHoa dmh ON cthd.MaHang = dmh.MaHang
                                                  GROUP BY dmh.TenHang
                                                  ORDER BY TotalRevenue DESC";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                // Lấy dữ liệu sản phẩm
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                if (!ds.Tables.Contains("HangHoaTable"))
                {
                    ds.Tables.Add("HangHoaTable");
                }
                adapter.Fill(ds.Tables["HangHoaTable"]);
                SqlCommand totalRevenueCommand = new SqlCommand(totalRevenueQuery, conn);
                conn.Open();
                object totalRevenueResult = totalRevenueCommand.ExecuteScalar();
                decimal totalRevenue = totalRevenueResult != DBNull.Value ? Convert.ToDecimal(totalRevenueResult) : 0;
                conn.Close();
                // Lấy dữ liệu sản phẩm mua nhiều nhất
                SqlCommand mostPurchasedProductCommand = new SqlCommand(mostPurchasedProductQuery, conn);
                conn.Open();
                var mostPurchasedProduct = mostPurchasedProductCommand.ExecuteScalar()?.ToString() ?? "Không có";
                conn.Close();

                // Lấy dữ liệu sản phẩm có doanh thu cao nhất
                SqlCommand highestRevenueProductCommand = new SqlCommand(highestRevenueProductQuery, conn);
                conn.Open();
                var highestRevenueProduct = highestRevenueProductCommand.ExecuteScalar()?.ToString() ?? "Không có";
                conn.Close();
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HangHoaReport.rdlc";
                // Thiết lập các tham số cho báo cáo
                ReportParameter[] reportParams = new ReportParameter[]
                {
                    new ReportParameter("NguoiTaoBaoCao", TenNV),
                    new ReportParameter("MostPurchasedProduct", mostPurchasedProduct),
                    new ReportParameter("HighestRevenueProduct", highestRevenueProduct),
                    new ReportParameter("TotalRevenue", totalRevenue.ToString("C"))
                };
                reportViewer1.LocalReport.SetParameters(reportParams);
            }

            // Thiết lập nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("HangHoaDataSet", ds.Tables["HangHoaTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HangHoaReport.rdlc";

            // Làm mới ReportViewer để hiển thị dữ liệu
            this.reportViewer1.RefreshReport();
        }

        private void LoadSanPham()
        {
            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                string query = "SELECT MaHang, TenHang FROM DanhMucHangHoa";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cbbsanpham.DataSource = dt;
                cbbsanpham.DisplayMember = "TenHang"; // Hiển thị tên sản phẩm
                cbbsanpham.ValueMember = "MaHang";    // Giá trị là mã sản phẩm
            }
        }


        private void btnxem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn sản phẩm
            // Kiểm tra nếu chưa chọn sản phẩm
            if (cbbsanpham.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xem doanh thu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã sản phẩm từ ComboBox
            string maSanPham = cbbsanpham.SelectedValue.ToString();

            // Truy vấn tính tổng doanh thu cho sản phẩm đã chọn
            string query = @"SELECT SUM(cthd.SoLuong * dmh.DonGiaBan) AS TotalRevenue
                     FROM ChiTietHoaDonBan cthd
                     JOIN DanhMucHangHoa dmh ON cthd.MaHang = dmh.MaHang
                     WHERE dmh.MaHang = @MaHang";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHang", maSanPham);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    // Kiểm tra nếu kết quả null, đặt tổng doanh thu là 0
                    decimal totalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    // Thiết lập ReportParameter để truyền tổng doanh thu vào báo cáo
                    ReportParameter paramTotalRevenue = new ReportParameter("TotalRevenue", totalRevenue.ToString("C"));

                    // Cập nhật tham số vào báo cáo
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paramTotalRevenue });

                    // Làm mới báo cáo để hiển thị giá trị
                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tính toán doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
