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
            // ��ȡ�û�ѡ���Դ���ݿ⡢Ŀ�����ݿ�ͱ�
            string sourceDb = comboBoxSourceDb.SelectedItem.ToString();
            string targetDb = comboBoxTargetDb.SelectedItem.ToString();
            string sourceTable = comboBoxSourceTable.SelectedItem.ToString();
            string targetTable = comboBoxTargetTable.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(sourceDb)&& !string.IsNullOrEmpty(targetDb) && !string.IsNullOrEmpty(sourceTable) && !string.IsNullOrEmpty(targetTable))
            {
                // ���û����ͬ����ťʱ��ִ������ͬ������
                //DataSyncService dataSyncService = new DataSyncService();

                Hangfire.BackgroundJob.Enqueue(()=>DataSyncService.PerformDataSync());
                // ִ������ͬ������
                //string syncResult = dataSyncService.PerformDataSync(sourceDb, targetDb, sourceTable, targetTable);

                //// ��ͬ�������ʾ�ڱ�ǩ��
                //resultRichTextBox.Text = syncResult;
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

        private void UpdateSourceConnection()
        {
            // ����Դ���ݿ������ַ���
            string sourceServer = sourceServerTextBox.Text;
            string sourceUsername = sourceUsernameTextBox.Text;
            string sourcePassword = sourcePasswordTextBox.Text;
            sourceConnectionString = BuildConnectionString(sourceServer, sourceUsername, sourcePassword);
        }

        private void UpdateTargetConnection()
        {
            // ����Ŀ�����ݿ������ַ���
            string targetServer = targetServerTextBox.Text;
            string targetUsername = targetUsernameTextBox.Text;
            string targetPassword = targetPasswordTextBox.Text;
            targetConnectionString = BuildConnectionString(targetServer, targetUsername, targetPassword);
        }

        private string BuildConnectionString(string server, string username, string password)
        {
            // �������ݿ������ַ���
            // �����������ݿ����ͣ�����SQL Server�����������ý�������
            // ʾ����ʹ����SQL Server�������ַ���
            //Data Source=.;Initial Catalog=BlogDB;Persist Security Info=True;User ID=sa;Password=***********
            return $"Server={server};Database=master;User Id={username};Password={password};Encrypt=True;TrustServerCertificate=True;";
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
                MessageBox.Show("�������ݿ�ʱ����" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("�������ݿ�ʱ����" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("�������ݿ�ʱ����" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("�������ݿ�ʱ����" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void comboBoxTargetDb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}