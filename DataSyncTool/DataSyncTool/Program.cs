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
            // 加载配置文件
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 配置依赖注入容器
            var builder = new ContainerBuilder();
            builder.RegisterInstance(configuration).As<IConfiguration>();
            builder.RegisterType<DataSyncService>().AsSelf();

            var container = builder.Build();

            // 配置Hangfire
            GlobalConfiguration.Configuration.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));

            // 启动WinForms应用程序
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());


            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var dataSyncService = scope.Resolve<DataSyncService>();

            //    // 在这里可以添加其他启动逻辑
            //    ApplicationConfiguration.Initialize();
            //    Application.Run(new MainForm());
            //    //Application.Run(new MainForm(dataSyncService));
            //}

            #region 方式一
            //var host = new HostBuilder()
            //    .ConfigureServices((hostContext, services) =>
            //    {
            //        // 配置Hangfire服务
            //        services.AddHangfire(config =>
            //            config.UseSqlServerStorage(Configuration("HangfireConnection")));

            //        // 注册数据同步服务
            //        services.AddTransient<DataSyncService>();
            //    })
            //    .ConfigureAppConfiguration((hostContext, configApp) =>
            //    {
            //        // 配置应用程序的配置文件（appsettings.json等）
            //        configApp.AddJsonFile("appsettings.json");
            //    })
            //    .ConfigureLogging((hostContext, configLogging) =>
            //    {
            //        // 配置日志记录器
            //        configLogging.AddConsole();
            //    })
            //    .Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        // 启动Hangfire面板
            //        GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(services));
            //        host.Run();
            //    }
            //    catch (Exception ex)
            //    {
            //        // 处理异常
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