using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public static class databaselink
    {
        public static string ConnectionString = "Data Source=THUCVIVO;Initial Catalog=quanlybankinh;Integrated Security=True";
    }
    public static class reportlink
    {
        public static string doanhthureportlink = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\DoanhThuReport.rdlc";
        public static string nhanvienreportlink = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\NhanVienReport.rdlc";
        public static string hoadonbanreportlink = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\HoaDonBanReport.rdlc";
        public static string khachhangreportlink = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\KhachHangReport.rdlc";
        public static string nhacungcapreportlink= "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\NhaCungCapReport.rdlc";
        public static string hoadonnhapreportlink = "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\HoaDonNhapReport.rdlc";
        public static string hanghoareportlink= "E:\\LTTQ\\BTLLTTQ\\BTLLTTQ\\HangHoaReport.rdlc";
    }
    internal static class Program
    {
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Account());
        }
    }
}
