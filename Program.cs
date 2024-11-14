using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public static class databaselink
    {
        public static string ConnectionString = "Data Source=LAPTOP-7NSHMMSK;Initial Catalog=quanlybankinh;Integrated Security=True";
    }
    public static class reportlink
    {
        public static string nhanvienreportlink = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\NhanVienReport.rdlc";
        public static string hoadonbanreportlink = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HoaDonBanReport.rdlc";
        public static string khachhangreportlink = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\KhachHangReport.rdlc";
        public static string nhacungcapreportlink= "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\NhaCungCapReport.rdlc";
        public static string hoadonnhapreportlink = "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HoaDonNhapReport.rdlc";
        public static string hanghoareportlink= "C:\\Users\\tam tran\\source\\repos\\BTLLTTQ2\\BTLLTTQ\\HangHoaReport.rdlc";
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
