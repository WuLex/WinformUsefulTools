using DataSyncTool.Common;
using DataSyncTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sunny.UI;
using Sunny.UI.Win32;
using System.Data;

namespace DataSyncTool
{
    public partial class MainForm : UIForm
    {
        private string sourceConnectionString;
        private string targetConnectionString;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            // 获取用户选择的源数据库、目标数据库和表
            string sourceDb = comboBoxSourceDb.SelectedItem.ToString();
            string targetDb = comboBoxTargetDb.SelectedItem.ToString();
            string sourceTable = comboBoxSourceTable.SelectedItem.ToString();
            string targetTable = comboBoxTargetTable.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(sourceDb)&& !string.IsNullOrEmpty(targetDb) && !string.IsNullOrEmpty(sourceTable) && !string.IsNullOrEmpty(targetTable))
            {
                // 当用户点击同步按钮时，执行数据同步操作
                //DataSyncService dataSyncService = new DataSyncService();

                Hangfire.BackgroundJob.Enqueue(()=>DataSyncService.PerformDataSync());
                // 执行数据同步操作
                //string syncResult = dataSyncService.PerformDataSync(sourceDb, targetDb, sourceTable, targetTable);

                //// 将同步结果显示在标签中
                //resultRichTextBox.Text = syncResult;
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

        private void UpdateSourceConnection()
        {
            // 更新源数据库连接字符串
            string sourceServer = sourceServerTextBox.Text;
            string sourceUsername = sourceUsernameTextBox.Text;
            string sourcePassword = sourcePasswordTextBox.Text;
            sourceConnectionString = BuildConnectionString(sourceServer, sourceUsername, sourcePassword);
        }

        private void UpdateTargetConnection()
        {
            // 更新目标数据库连接字符串
            string targetServer = targetServerTextBox.Text;
            string targetUsername = targetUsernameTextBox.Text;
            string targetPassword = targetPasswordTextBox.Text;
            targetConnectionString = BuildConnectionString(targetServer, targetUsername, targetPassword);
        }

        private string BuildConnectionString(string server, string username, string password)
        {
            // 构建数据库连接字符串
            // 根据您的数据库类型（例如SQL Server）和其他设置进行配置
            // 示例中使用了SQL Server的连接字符串
            //Data Source=.;Initial Catalog=BlogDB;Persist Security Info=True;User ID=sa;Password=***********
            return $"Server={server};Database=master;User Id={username};Password={password};Encrypt=True;TrustServerCertificate=True;";
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
                MessageBox.Show("连接数据库时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("连接数据库时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("连接数据库时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("连接数据库时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void comboBoxTargetDb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}