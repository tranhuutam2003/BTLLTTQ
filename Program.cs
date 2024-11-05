using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public static class databaselink
    {
        public static string ConnectionString = "Data Source=LAPTOP-7NSHMMSK ;Initial Catalog=quanlybankinh;Integrated Security=True";
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Account());
        }
    }
}
