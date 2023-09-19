using DataSyncTool.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataSyncTool
{
    internal static class Program
    {
        /// <summary>
        ///  
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // 加载配置文件
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();
            //configuration.GetConnectionString("HangfireConnection")

            // 启动WinForms应用程序
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}