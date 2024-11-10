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
    public partial class NhaCungCapReport : Form
    {
        private string TenNV;
        public NhaCungCapReport(string tenNV)
        {
            InitializeComponent();
            TenNV = tenNV;
        }

        private void NhaCungCapReport_Load(object sender, EventArgs e)
        { 
            dtpdenngay.Value = DateTime.Now;
            dtptungay.Value = DateTime.Now.AddDays(-30);

            // Load report với khoảng thời gian mặc định
            LoadReport(dtptungay.Value, dtpdenngay.Value);
        }

        private void LoadReport(DateTime startDate, DateTime endDate)
        {
            DataSet ds = new DataSet();
            string query = @"SELECT 
                        ncc.MaNCC, 
                        ncc.TenNCC, 
                        ncc.DiaChi, 
                        ncc.DienThoai, 
                        hdn.SoHDN, 
                        hdn.NgayNhap, 
                        hdn.TongTien,
                        nv.TenNV as NguoiTao,
                        cthdn.MaHang,
                        mh.TenHang,
                        cthdn.SoLuong,
                        cthdn.DonGia,
                        cthdn.ThanhTien
                    FROM NhaCungCap ncc
                    LEFT JOIN HoaDonNhap hdn ON ncc.MaNCC = hdn.MaNCC
                    LEFT JOIN NhanVien nv ON hdn.MaNV = nv.MaNV
                    LEFT JOIN ChiTietHoaDonNhap cthdn ON hdn.SoHDN = cthdn.SoHDN
                    LEFT JOIN DanhMucHangHoa mh ON cthdn.MaHang = mh.MaHang
                    WHERE hdn.NgayNhap BETWEEN @StartDate AND @EndDate
                    ORDER BY hdn.NgayNhap DESC";

            using (SqlConnection conn = new SqlConnection(databaselink.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);

                // Xóa DataTable có tên 'NhaCungCapTable' nếu đã tồn tại trong DataSet
                //if (ds.Tables.Contains("NhaCungCapTable"))
                //{
                //    ds.Tables.Remove("NhaCungCapTable");
                //}

                // Tạo và thêm DataTable mới
                adapter.Fill(ds.Tables["NhaCungCapTable"]);
            }

            // Thiết lập nguồn dữ liệu cho báo cáo
            ReportDataSource rds = new ReportDataSource("NhaCungCapDataSet", ds.Tables["NhaCungCapTable"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Chỉ định đường dẫn đến file báo cáo RDLC
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\NhaCungCapReport.rdlc";

            ReportParameter paramNguoiTao = new ReportParameter("NguoiTaoBaoCao", TenNV);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { paramNguoiTao });

            // Làm mới ReportViewer
            reportViewer1.RefreshReport();
        }


        private void btnxem_Click(object sender, EventArgs e)
        {
            if (dtptungay.Value > dtpdenngay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadReport(dtptungay.Value, dtpdenngay.Value);
        }
    }
}
