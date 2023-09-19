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
           
            //��ʼ��
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result; // ʹ�� .Result ��ȡ IScheduler ʵ��
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ӧ�ó���ر�ʱ�ر� Quartz.NET ���ȳ���
            await _scheduler.Shutdown();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            // ��ȡ�û�ѡ���Դ���ݿ⡢Ŀ�����ݿ�ͱ�
            //string sourceDb = comboBoxSourceDb.SelectedItem.ToString();
            //string targetDb = comboBoxTargetDb.SelectedItem.ToString();
            string sourceTable = comboBoxSourceTable.SelectedItem.ToString();
            string targetTable = comboBoxTargetTable.SelectedItem.ToString();
          
            if (!string.IsNullOrEmpty(sourceTable) && !string.IsNullOrEmpty(targetTable))
            {
                var dataSyncService = new DataSyncService();
                dataSyncService.PerformDataSync(sourceConnectionString, targetConnectionString, sourceTable, targetTable);
                resultRichTextBox.AppendText($"�ֶ�ͬ�����ݿ�ɹ�: {DateTime.Now} \r\n");
                resultRichTextBox.AppendText("------------------------------\r\n");
            }
            else
            {
                UIMessageBox.ShowWarning("��ѡ����ȷ��Դ���ݿ⡢Ŀ�����ݿ�ͱ�");
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
            // ����Դ���ݿ������ַ���
            string sourceServer = sourceServerTextBox.Text;
            string sourceUsername = sourceUsernameTextBox.Text;
            string sourcePassword = sourcePasswordTextBox.Text;
            sourceConnectionString = BuildConnectionString(sourceServer, sourceUsername, sourcePassword, database);
        }

        private void UpdateTargetConnection(string database = "master")
        {
            // ����Ŀ�����ݿ������ַ���
            string targetServer = targetServerTextBox.Text;
            string targetUsername = targetUsernameTextBox.Text;
            string targetPassword = targetPasswordTextBox.Text;
            targetConnectionString = BuildConnectionString(targetServer, targetUsername, targetPassword, database);
        }

        private string BuildConnectionString(string server, string username, string password,string databsae)
        {
            // �������ݿ������ַ���
            // �����������ݿ����ͣ�����SQL Server�����������ý�������
            // ʾ����ʹ����SQL Server�������ַ���
            //Data Source=.;Initial Catalog=BlogDB;Persist Security Info=True;User ID=sa;Password=***********
            return $"Server={server};Database={databsae};User Id={username};Password={password};Encrypt=True;TrustServerCertificate=True;";
        }

        private void LoadSourceDatabases()
        {
            // ������������ݿ�ͱ�comboBoxSourceDb��comboBoxTargetDb
            // ʹ��sourceConnectionString��targetConnectionString�������ݿ�
            // Ȼ���ѯ���ݿ�ͱ���Ϣ���������Ǽ��ص���������
            // �����������������
            comboBoxSourceDb.Items.Clear();
            try
            {
                // ʹ�� EF Core ���ӵ�Դ���ݿ�
                using (var sourceContext = new GlobalDbContext(sourceConnectionString))
                {
                    using (var sourceConnection = sourceContext.Database.GetDbConnection())
                    {
                        // ������
                        sourceConnection.Open();
                       
                        // ��ѯ���õ����ݿ��б���ȡ�������ݿ����Ϣ
                        var sourceDatabases = sourceConnection.GetSchema("Databases");

                        // �����ݿ����Ƽ��ص� comboBoxSourceDb ��
                        foreach (DataRow database in sourceDatabases.Rows)
                        {
                            string databaseName = database.Field<string>("database_name") ?? "";
                            comboBoxSourceDb.Items.Add(databaseName);
                            // ��ӡ���ݿ����ƻ�ִ����������
                            //Console.WriteLine(databaseName);
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                // �����쳣�������������ʧ�ܻ��ѯʧ��
                UIMessageBox.ShowError("�������ݿ�ʱ����" + ex.Message);
            }
        }
        private void LoadTargetDatabases()
        {
            comboBoxTargetDb.Items.Clear();
            try
            {
                // ʹ�� EF Core ���ӵ�Ŀ�����ݿ�
                using (var targetContext = new GlobalDbContext(targetConnectionString))
                {
                    using (var targetConnection = targetContext.Database.GetDbConnection())
                    {
                        // ������
                        targetConnection.Open();
                        // ��ѯ���õ����ݿ��б�
                        var targetDatabases = targetConnection.GetSchema("Databases");

                        // �����ݿ����Ƽ��ص� comboBoxTargetDb ��
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
                // �����쳣�������������ʧ�ܻ��ѯʧ��
                UIMessageBox.ShowError("�������ݿ�ʱ����" + ex.Message);
            }
        }
        private void LoadSourceTables(string sourcedbname)
        {
            comboBoxSourceTable.Items.Clear();
            try
            {
                // ʹ�� EF Core ���ӵ�Դ���ݿ�
                using (var sourceContext = new GlobalDbContext(sourceConnectionString))
                {
                    using (var sourceConnection = sourceContext.Database.GetDbConnection())
                    {
                        // ������
                        sourceConnection.Open();
                        // �������ݿ��е����б���
                        var tableNames = sourceConnection.GetSchema("Tables");

                        // �������Ƽ��ص� comboBoxSourceTable ��
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
                // �����쳣�������������ʧ�ܻ��ѯʧ��
                UIMessageBox.ShowError("�������ݿ�ʱ����" + ex.Message);
            }
        }
        private void LoadTargetTables(string targetdbname)
        {
            comboBoxTargetTable.Items.Clear();

            try
            {
                // ʹ�� EF Core ���ӵ�Ŀ�����ݿ�
                using (var targetContext = new GlobalDbContext(targetConnectionString))
                {
                    using (var targetConnection = targetContext.Database.GetDbConnection())
                    {
                        // ������
                        targetConnection.Open();
                        // ��ѯ���õı��б�
                        var targetTables = targetConnection.GetSchema("Tables");

                        // �������Ƽ��ص� comboBoxTargetTable ��
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
                // �����쳣�������������ʧ�ܻ��ѯʧ��
                UIMessageBox.ShowError("�������ݿ�ʱ����" + ex.Message);
            }
        }
     
        private void sourceConnectButton_Click(object sender, EventArgs e)
        {
            // ���û����������Դ���ݿ⡱��ťʱ��ִ��Դ���ݿ����Ӳ���
            UpdateSourceConnection();
            LoadSourceDatabases();
            // �����������������Դ���ݿ���߼�������������ӻ�������ݿ���Ϣ
            // �����ʵ��������д���
        }

        private void targetConnectButton_Click(object sender, EventArgs e)
        {
            // ���û����������Ŀ�����ݿ⡱��ťʱ��ִ��Ŀ�����ݿ����Ӳ���
            UpdateTargetConnection();
            LoadTargetDatabases();
            // �����������������Ŀ�����ݿ���߼�������������ӻ�������ݿ���Ϣ
            // �����ʵ��������д���
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

                    #region  �������ã�����ί��
                    MySingleton.Instance.Initialize(resultRichTextBox);
                    #endregion

                    //var job = JobBuilder.Create<DatabaseSyncJob>()
                    //    .WithIdentity("databaseSyncJob", "databaseSyncGroup")
                    //    .Build();

                    //ʹ�� DatabaseSyncJob ʵ��������ҵ
                    IJobDetail job = JobBuilder.Create(typeof(DatabaseSyncJob))
                        .WithIdentity("databaseSyncJob", "databaseSyncGroup")
                         .UsingJobData("sourceConnectionString", sourceConnectionString)
                        .UsingJobData("targetConnectionString", targetConnectionString)
                        .UsingJobData("sourceTableName", sourceTableName)
                        .UsingJobData("targetTableName", targetTableName)
                        .Build();

                    //������ҵ������ӳ�䣬����Ҫ�Ĳ������ݸ���ҵ
                    //job.JobDataMap.Put("sourceConnectionString", sourceConnectionString);
                    //job.JobDataMap.Put("targetConnectionString", targetConnectionString);
                    //job.JobDataMap.Put("sourceTableName", sourceTableName);
                    //job.JobDataMap.Put("targetTableName", targetTableName);

                    var trigger = TriggerBuilder.Create()
                        .WithIdentity("databaseSyncTrigger", "databaseSyncGroup")
                        .StartNow()
                        .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(60) // ÿһ����ִ��һ��
                            .RepeatForever())
                        .Build();

                    _scheduler.ScheduleJob(job, trigger).Wait();  // ʹ�� .Wait() ������ҵ����
                    _scheduler.Start().Wait(); // ʹ�� .Wait() ����������
                    UIMessageBox.ShowInfo("�����������ɹ�");
                }
                catch (Exception ex)
                {
                    // �����쳣
                    UIMessageBox.ShowError(ex.Message);
                }
            }
            else
            {
                UIMessageBox.ShowWarning("��ѡ����ȷ��Դ���ݿ⡢Ŀ�����ݿ�ͱ�");
            }
        }

        private void uiStopSchedulerButton_Click(object sender, EventArgs e)
        {
            if (_scheduler != null && !_scheduler.IsShutdown)
            {
                _scheduler.Shutdown().Wait(); // ʹ�� .Wait() ֹͣ������

                UIMessageBox.ShowInfo("ֹͣ�������ɹ�");
            }
        }


        //private void UpdateResultTextBox(string logMessage)
        //{
        //    if (resultRichTextBox.InvokeRequired)
        //    {
        //        // ������� UI �߳��ϣ�ʹ�� Invoke ��������
        //        resultRichTextBox.Invoke(new Action<string>(UpdateResultTextBox), logMessage);
        //    }
        //    else
        //    {
        //        // �� UI �߳���ִ�и��²���
        //        resultRichTextBox.AppendText($"UpdateResultEventִ��ʱ��: {DateTime.Now} - {logMessage}\r\n");
        //        resultRichTextBox.AppendText("------------------------------\r\n");
        //    }
        //}
        //// �����߳��ϵ���Ϣ����������ڸ��½���
        //private void UpdateUI(string message)
        //{
        //    // ȷ�������߳���ִ�н�����²���
        //    if (InvokeRequired)
        //    {
        //        // ����������߳��ϣ���ͨ��ί�е��������߳���ִ��
        //        BeginInvoke((Action)(() => UpdateUI(message)));
        //    }
        //    else
        //    {
        //        // �����߳��ϸ��½���Ԫ��

        //        resultRichTextBox.AppendText("--------message---------\r\n");
        //        resultRichTextBox.Text = message;
        //    }
        //}
    }
}