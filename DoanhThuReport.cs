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

                if (!rp.Tables.Contains("DoanhThuTable"))
                {
                    rp.Tables.Add("DoanhThuTable");
                }

                adapter.Fill(rp.Tables["DoanhThuTable"]);
            }

            ReportDataSource rds = new ReportDataSource("DoanhThuDataSet", rp.Tables["DoanhThuTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = reportlink.doanhthureportlink;

            ReportParameter paramNguoiTao = new ReportParameter("NguoiTaoBaoCao", TenNV);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paramNguoiTao });

            reportViewer1.RefreshReport();
        }
        private void btnxem_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtptungay.Value;
            DateTime endDate = dtpdenngay.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadReport(startDate, endDate);
        }
    }
}
