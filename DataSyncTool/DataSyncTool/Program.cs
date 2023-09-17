using Hangfire;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using DataSyncTool.Common;
using System.Configuration;
using Autofac;

namespace DataSyncTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ���������ļ�
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // ��������ע������
            var builder = new ContainerBuilder();
            builder.RegisterInstance(configuration).As<IConfiguration>();
            builder.RegisterType<DataSyncService>().AsSelf();

            var container = builder.Build();

            // ����Hangfire
            GlobalConfiguration.Configuration.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));

            // ����WinFormsӦ�ó���
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());


            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var dataSyncService = scope.Resolve<DataSyncService>();

            //    // ���������������������߼�
            //    ApplicationConfiguration.Initialize();
            //    Application.Run(new MainForm());
            //    //Application.Run(new MainForm(dataSyncService));
            //}

            #region ��ʽһ
            //var host = new HostBuilder()
            //    .ConfigureServices((hostContext, services) =>
            //    {
            //        // ����Hangfire����
            //        services.AddHangfire(config =>
            //            config.UseSqlServerStorage(Configuration("HangfireConnection")));

            //        // ע������ͬ������
            //        services.AddTransient<DataSyncService>();
            //    })
            //    .ConfigureAppConfiguration((hostContext, configApp) =>
            //    {
            //        // ����Ӧ�ó���������ļ���appsettings.json�ȣ�
            //        configApp.AddJsonFile("appsettings.json");
            //    })
            //    .ConfigureLogging((hostContext, configLogging) =>
            //    {
            //        // ������־��¼��
            //        configLogging.AddConsole();
            //    })
            //    .Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        // ����Hangfire���
            //        GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(services));
            //        host.Run();
            //    }
            //    catch (Exception ex)
            //    {
            //        // �����쳣
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while running the application.");
            //    }
            //} 
            #endregion


            //ApplicationConfiguration.Initialize();
            //Application.Run(new MainForm());
        }
        

    }

 

    public class HangfireActivator : JobActivator
    {
        private readonly IServiceProvider _container;

        public HangfireActivator(IServiceProvider container)
        {
            _container = container;
        }

        public override object ActivateJob(Type jobType)
        {
            return _container.GetService(jobType);
        }
    }
}