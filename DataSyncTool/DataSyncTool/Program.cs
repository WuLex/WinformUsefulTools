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
            // ���������ļ�
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();
            //configuration.GetConnectionString("HangfireConnection")

            // ����WinFormsӦ�ó���
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}