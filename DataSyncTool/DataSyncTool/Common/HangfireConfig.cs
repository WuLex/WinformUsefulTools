using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using System;

namespace DataSyncTool.Common
{
    public class HangfireConfig
    {
        public static void ConfigureHangfire(string connectionString)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

            // 添加定时任务，例如每天凌晨执行一次数据同步
            RecurringJob.AddOrUpdate(() => DataSyncService.PerformDataSync(), Cron.Daily);
        }

        //public static void PerformDataSync()
        //{
        //    // 在这里调用数据同步操作
        //    var dataSyncService = new DataSyncService("", "","", "");
        //    dataSyncService.PerformDataSync();
        //}
    }
}
