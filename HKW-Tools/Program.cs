using System;
using System.Windows.Forms;
using ToolsNT_API;

namespace HKW_Tools
{
    internal static class Program
    {
        public static void InitCheck()
        {
            System.Threading.Mutex _ = new System.Threading.Mutex(true, "MutexName", out bool isNotRunning);
            if (!isNotRunning)
            {
                MessageBox.Show("HKW工具箱已在运行,为避免错误,禁用了重复开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            if (!ADB.ExistsADBItems())
            {
                MessageBox.Show("HKW工具箱找不到ADB组件", "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(2);
            }
            if (!ADB.ExistsToolsNT())
            {
                MessageBox.Show("HKW工具箱找不到ToolsNT", "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(2);
            }
            return;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitCheck();
            ADB.Server.Start();
            Application.Run(new MainFrm());
        }
    }
}
