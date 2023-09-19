using DataSyncTool.Common;
using DataSyncTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using Quartz;
using Sunny.UI;
using System.Data;

namespace DataSyncTool
{
    public partial class MainForm : UIForm
    {
        private string sourceConnectionString;
        private string targetConnectionString;
        private IScheduler _scheduler;

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
           
            //初始化
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result; // 使用 .Result 获取 IScheduler 实例
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 应用程序关闭时关闭 Quartz.NET 调度程序
            await _scheduler.Shutdown();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            // 获取用户选择的源数据库、目标数据库和表
            //string sourceDb = comboBoxSourceDb.SelectedItem.ToString();
            //string targetDb = comboBoxTargetDb.SelectedItem.ToString();
            string sourceTable = comboBoxSourceTable.SelectedItem.ToString();
            string targetTable = comboBoxTargetTable.SelectedItem.ToString();
          
            if (!string.IsNullOrEmpty(sourceTable) && !string.IsNullOrEmpty(targetTable))
            {
                var dataSyncService = new DataSyncService();
                dataSyncService.PerformDataSync(sourceConnectionString, targetConnectionString, sourceTable, targetTable);
                resultRichTextBox.AppendText($"手动同步数据库成功: {DateTime.Now} \r\n");
                resultRichTextBox.AppendText("------------------------------\r\n");
            }
            else
            {
                UIMessageBox.ShowWarning("请选择正确的源数据库、目标数据库和表");
            } 
        }

        private void sourceServerTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSourceConnection();
        }

        private void sourceUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSourceConnection();
        }

        private void sourcePasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSourceConnection();
        }
       
        private void targetServerTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTargetConnection();
        }

        private void targetUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTargetConnection();
        }

        private void targetPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTargetConnection();
        }

        private void UpdateSourceConnection(string database="master")
        {
            // 更新源数据库连接字符串
            string sourceServer = sourceServerTextBox.Text;
            string sourceUsername = sourceUsernameTextBox.Text;
            string sourcePassword = sourcePasswordTextBox.Text;
            sourceConnectionString = BuildConnectionString(sourceServer, sourceUsername, sourcePassword, database);
        }

        private void UpdateTargetConnection(string database = "master")
        {
            // 更新目标数据库连接字符串
            string targetServer = targetServerTextBox.Text;
            string targetUsername = targetUsernameTextBox.Text;
            string targetPassword = targetPasswordTextBox.Text;
            targetConnectionString = BuildConnectionString(targetServer, targetUsername, targetPassword, database);
        }

        private string BuildConnectionString(string server, string username, string password,string databsae)
        {
            // 构建数据库连接字符串
            // 根据您的数据库类型（例如SQL Server）和其他设置进行配置
            // 示例中使用了SQL Server的连接字符串
            //Data Source=.;Initial Catalog=BlogDB;Persist Security Info=True;User ID=sa;Password=***********
            return $"Server={server};Database={databsae};User Id={username};Password={password};Encrypt=True;TrustServerCertificate=True;";
        }

        private void LoadSourceDatabases()
        {
            // 在这里加载数据库和表到comboBoxSourceDb和comboBoxTargetDb
            // 使用sourceConnectionString和targetConnectionString连接数据库
            // 然后查询数据库和表信息，并将它们加载到下拉框中
            // 清空现有下拉框内容
            comboBoxSourceDb.Items.Clear();
            try
            {
                // 使用 EF Core 连接到源数据库
                using (var sourceContext = new GlobalDbContext(sourceConnectionString))
                {
                    using (var sourceConnection = sourceContext.Database.GetDbConnection())
                    {
                        // 打开连接
                        sourceConnection.Open();
                       
                        // 查询可用的数据库列表，获取所有数据库的信息
                        var sourceDatabases = sourceConnection.GetSchema("Databases");

                        // 将数据库名称加载到 comboBoxSourceDb 中
                        foreach (DataRow database in sourceDatabases.Rows)
                        {
                            string databaseName = database.Field<string>("database_name") ?? "";
                            comboBoxSourceDb.Items.Add(databaseName);
                            // 打印数据库名称或执行其他操作
                            //Console.WriteLine(databaseName);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况，例如连接失败或查询失败
                UIMessageBox.ShowError("连接数据库时出错：" + ex.Message);
            }
        }
        private void LoadTargetDatabases()
        {
            comboBoxTargetDb.Items.Clear();
            try
            {
                // 使用 EF Core 连接到目标数据库
                using (var targetContext = new GlobalDbContext(targetConnectionString))
                {
                    using (var targetConnection = targetContext.Database.GetDbConnection())
                    {
                        // 打开连接
                        targetConnection.Open();
                        // 查询可用的数据库列表
                        var targetDatabases = targetConnection.GetSchema("Databases");

                        // 将数据库名称加载到 comboBoxTargetDb 中
                        foreach (DataRow database in targetDatabases.Rows)
                        {
                            string databaseName = database.Field<string>("database_name") ?? "";
                            comboBoxTargetDb.Items.Add(databaseName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况，例如连接失败或查询失败
                UIMessageBox.ShowError("连接数据库时出错：" + ex.Message);
            }
        }
        private void LoadSourceTables(string sourcedbname)
        {
            comboBoxSourceTable.Items.Clear();
            try
            {
                // 使用 EF Core 连接到源数据库
                using (var sourceContext = new GlobalDbContext(sourceConnectionString))
                {
                    using (var sourceConnection = sourceContext.Database.GetDbConnection())
                    {
                        // 打开连接
                        sourceConnection.Open();
                        // 加载数据库中的所有表名
                        var tableNames = sourceConnection.GetSchema("Tables");

                        // 将表名称加载到 comboBoxSourceTable 中
                        foreach (DataRow row in tableNames.Rows)
                        {
                            string tableName = row.Field<string>("TABLE_NAME") ?? "";
                            comboBoxSourceTable.Items.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况，例如连接失败或查询失败
                UIMessageBox.ShowError("连接数据库时出错：" + ex.Message);
            }
        }
        private void LoadTargetTables(string targetdbname)
        {
            comboBoxTargetTable.Items.Clear();

            try
            {
                // 使用 EF Core 连接到目标数据库
                using (var targetContext = new GlobalDbContext(targetConnectionString))
                {
                    using (var targetConnection = targetContext.Database.GetDbConnection())
                    {
                        // 打开连接
                        targetConnection.Open();
                        // 查询可用的表列表
                        var targetTables = targetConnection.GetSchema("Tables");

                        // 将表名称加载到 comboBoxTargetTable 中
                        foreach (DataRow row in targetTables.Rows)
                        {
                            string tableName = row.Field<string>("TABLE_NAME") ?? "";
                            comboBoxTargetTable.Items.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况，例如连接失败或查询失败
                UIMessageBox.ShowError("连接数据库时出错：" + ex.Message);
            }
        }
     
        private void sourceConnectButton_Click(object sender, EventArgs e)
        {
            // 当用户点击“连接源数据库”按钮时，执行源数据库连接操作
            UpdateSourceConnection();
            LoadSourceDatabases();
            // 可以在这里添加连接源数据库的逻辑，例如测试连接或加载数据库信息
            // 请根据实际情况进行处理
        }

        private void targetConnectButton_Click(object sender, EventArgs e)
        {
            // 当用户点击“连接目标数据库”按钮时，执行目标数据库连接操作
            UpdateTargetConnection();
            LoadTargetDatabases();
            // 可以在这里添加连接目标数据库的逻辑，例如测试连接或加载数据库信息
            // 请根据实际情况进行处理
        }

        private void comboBoxSourceDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSourceDb.SelectedIndex != -1)
            {
                var sourceDbName= this.comboBoxSourceDb.SelectedItem.ToString();
                UpdateSourceConnection(sourceDbName);
                LoadSourceTables(sourceDbName);
            }
        }

        private void comboBoxTargetDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTargetDb.SelectedIndex != -1)
            {
                var targetDbName = this.comboBoxTargetDb.SelectedItem.ToString();
                UpdateTargetConnection(targetDbName);
                LoadTargetTables(targetDbName);
            }
        }
         
        private void uiStartSchedulerButton_Click(object sender, EventArgs e)
        {
            string sourceTableName = comboBoxSourceTable.SelectedItem?.ToString();
            string targetTableName = comboBoxTargetTable.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(sourceTableName) && !string.IsNullOrEmpty(targetTableName))
            {
                try
                {

                    #region  传递引用，单例委托
                    MySingleton.Instance.Initialize(resultRichTextBox);
                    #endregion

                    //var job = JobBuilder.Create<DatabaseSyncJob>()
                    //    .WithIdentity("databaseSyncJob", "databaseSyncGroup")
                    //    .Build();

                    //使用 DatabaseSyncJob 实例安排作业
                    IJobDetail job = JobBuilder.Create(typeof(DatabaseSyncJob))
                        .WithIdentity("databaseSyncJob", "databaseSyncGroup")
                         .UsingJobData("sourceConnectionString", sourceConnectionString)
                        .UsingJobData("targetConnectionString", targetConnectionString)
                        .UsingJobData("sourceTableName", sourceTableName)
                        .UsingJobData("targetTableName", targetTableName)
                        .Build();

                    //设置作业的数据映射，将必要的参数传递给作业
                    //job.JobDataMap.Put("sourceConnectionString", sourceConnectionString);
                    //job.JobDataMap.Put("targetConnectionString", targetConnectionString);
                    //job.JobDataMap.Put("sourceTableName", sourceTableName);
                    //job.JobDataMap.Put("targetTableName", targetTableName);

                    var trigger = TriggerBuilder.Create()
                        .WithIdentity("databaseSyncTrigger", "databaseSyncGroup")
                        .StartNow()
                        .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(60) // 每一分钟执行一次
                            .RepeatForever())
                        .Build();

                    _scheduler.ScheduleJob(job, trigger).Wait();  // 使用 .Wait() 启动作业调度
                    _scheduler.Start().Wait(); // 使用 .Wait() 启动调度器
                    UIMessageBox.ShowInfo("开启调度器成功");
                }
                catch (Exception ex)
                {
                    // 处理异常
                    UIMessageBox.ShowError(ex.Message);
                }
            }
            else
            {
                UIMessageBox.ShowWarning("请选择正确的源数据库、目标数据库和表");
            }
        }

        private void uiStopSchedulerButton_Click(object sender, EventArgs e)
        {
            if (_scheduler != null && !_scheduler.IsShutdown)
            {
                _scheduler.Shutdown().Wait(); // 使用 .Wait() 停止调度器

                UIMessageBox.ShowInfo("停止调度器成功");
            }
        }


        //private void UpdateResultTextBox(string logMessage)
        //{
        //    if (resultRichTextBox.InvokeRequired)
        //    {
        //        // 如果不在 UI 线程上，使用 Invoke 调用自身
        //        resultRichTextBox.Invoke(new Action<string>(UpdateResultTextBox), logMessage);
        //    }
        //    else
        //    {
        //        // 在 UI 线程上执行更新操作
        //        resultRichTextBox.AppendText($"UpdateResultEvent执行时间: {DateTime.Now} - {logMessage}\r\n");
        //        resultRichTextBox.AppendText("------------------------------\r\n");
        //    }
        //}
        //// 在主线程上的消息处理程序，用于更新界面
        //private void UpdateUI(string message)
        //{
        //    // 确保在主线程上执行界面更新操作
        //    if (InvokeRequired)
        //    {
        //        // 如果不在主线程上，则通过委托调用在主线程上执行
        //        BeginInvoke((Action)(() => UpdateUI(message)));
        //    }
        //    else
        //    {
        //        // 在主线程上更新界面元素

        //        resultRichTextBox.AppendText("--------message---------\r\n");
        //        resultRichTextBox.Text = message;
        //    }
        //}
    }
}