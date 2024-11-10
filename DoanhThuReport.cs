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
    public partial class DoanhThuReport : Form
    {
        private string TenNV;
        public DoanhThuReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
        }

        private void DoanhThuReport_Load(object sender, EventArgs e)
        {
            dtpdenngay.Value = DateTime.Now;
            dtptungay.Value = DateTime.Now.AddDays(-30);

            // Load report với khoảng thời gian mặc định
            LoadReport(dtptungay.Value, dtpdenngay.Value);
        }
        private void LoadReport(DateTime startDate, DateTime endDate)
        {
            DataSet rp = new DataSet();
            string query = @"SELECT NgayThang, DoanhThuBan, DoanhThuNhap, DoanhThuThuần
                            FROM DoanhThu
                            WHERE NgayThang BETWEEN @StartDate AND @EndDate;";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);

                // Tạo DataTable trong DataSet nếu chưa có
                if (!rp.Tables.Contains("DoanhThuTable"))
                {
                    rp.Tables.Add("DoanhThuTable");
                }

                // Điền dữ liệu vào DataTable
                adapter.Fill(rp.Tables["DoanhThuTable"]);
            }

            ReportDataSource rds = new ReportDataSource("DoanhThuDataSet", rp.Tables["DoanhThuTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Đường dẫn đến file RDLC của bạn
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\DoanhThuReport.rdlc";

            ReportParameter paramNguoiTao = new ReportParameter("NguoiTaoBaoCao", TenNV);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paramNguoiTao });

            // Làm mới ReportViewer để hiển thị dữ liệu
            reportViewer1.RefreshReport();
        }
        private void btnxem_Click(object sender, EventArgs e)
        {
            // Lấy khoảng ngày từ dtptungay và dtpdenngay
            DateTime startDate = dtptungay.Value;
            DateTime endDate = dtpdenngay.Value;

            // Kiểm tra nếu ngày bắt đầu lớn hơn ngày kết thúc
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tải báo cáo theo khoảng ngày đã chọn
            LoadReport(startDate, endDate);
        }
    }
}
