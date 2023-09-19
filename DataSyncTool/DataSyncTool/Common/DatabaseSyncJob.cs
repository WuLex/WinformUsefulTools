using Quartz;

namespace DataSyncTool.Common
{
    public class DatabaseSyncJob : IJob
    {
        // 声明事件
        //public event Action<string> LogMessage;

        //回写界面控件方式二 定义委托
        //public delegate void UpdateResultRichTextBoxDelegate(string logMessage);
        //public event UpdateResultRichTextBoxDelegate UpdateResultEvent;

        //回写界面控件方式三 定义委托
        //public event Action<string> DataSyncCompletedAction;

        //private readonly string sourceConnectionString;
        //private readonly string targetConnectionString;
        //private readonly string sourceTableName;
        //private readonly string targetTableName;

        //public DatabaseSyncJob(string sourceConnectionString, string targetConnectionString, string sourceTableName, string targetTableName)
        //{
        //    this.sourceConnectionString = sourceConnectionString;
        //    this.targetConnectionString = targetConnectionString;
        //    this.sourceTableName = sourceTableName;
        //    this.targetTableName = targetTableName;
        //}

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                // 从作业数据映射中检索参数
                string sourceConnectionString = context.JobDetail.JobDataMap.GetString("sourceConnectionString");
                string targetConnectionString = context.JobDetail.JobDataMap.GetString("targetConnectionString");
                string sourceTableName = context.JobDetail.JobDataMap.GetString("sourceTableName");
                string targetTableName = context.JobDetail.JobDataMap.GetString("targetTableName");

                //创建 DataSyncService 的实例并调用 PerformDataSync 方法。
                var dataSyncService = new DataSyncService();
                dataSyncService.PerformDataSync(sourceConnectionString, targetConnectionString, sourceTableName, targetTableName);

                //在数据同步完成后触发事件，传递执行记录消息给界面
                MySingleton.Instance.OnSendMessage($"定时任务数据同步成功完成{DateTime.Now}\n");
            }
            catch (Exception ex)
            {
                // 处理任何异常并在必要时记录它们
                MySingleton.Instance.OnSendMessage($"{ex.Message}---------------{DateTime.Now}\n");
            }
        }

        // 触发事件的方法
        //protected virtual void OnLogMessage(string message)
        //{
        //    LogMessage?.Invoke(message);
        //}
    }
}