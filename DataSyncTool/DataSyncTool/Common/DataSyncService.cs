using Hangfire;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncTool.Common
{
    public class DataSyncService
    {
        private  string sourceconnectionString = ""; // 替换为您的源SQL Server连接字符串
        private  string targetconnectionString = ""; // 替换为您的目标SQL Server连接字符串
        private  string sourceTableName = ""; // 替换为源表名称
        private  string targetTableName = ""; // 替换为目标表名称

        public DataSyncService(string sourceConnectionString, string destinationConnectionString,string sourceTableName ,string targetTableName)
        {
            this.sourceconnectionString = sourceConnectionString;
            this.targetconnectionString = destinationConnectionString;
            this.sourceTableName = sourceTableName;
            this.targetTableName = targetTableName;
        }

        public void StartDataSync()
        {
            // 在此编写差量同步逻辑，将需要同步的数据从源数据库同步到目标数据库
            // 可以使用Hangfire的RecurringJob来定期执行同步任务
            //RecurringJob.AddOrUpdate(() => PerformDataSync(), Cron.Daily);
        }

        /// <summary>
        /// 执行数据同步
        /// </summary>
        public static void PerformDataSync()
        {
           
        }

        [Obsolete]
        public  void PerformDataaSync()
        {  
            // 在这里编写数据同步逻辑，例如使用SQLDataAdapter同步数据
            // 你可以使用Hangfire创建定时任务来定期执行数据同步操作
            //try
            //{
            //    using (var connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        // 获取源表中最后同步的时间戳或标记，以便只同步更新的数据
            //        DateTime lastSyncTime = GetLastSyncTimeFromTargetTable(connection);

            //        // 构建 SQL 查询，仅选择源表中在最后同步时间之后有变化的数据
            //        string query = $"SELECT * FROM {sourceTableName} WHERE UpdateTimestamp > @LastSyncTime";

            //        using (var command = new SqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@LastSyncTime", lastSyncTime);

            //            using (var reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    // 从源表中读取数据行
            //                    // 在这里可以进行数据映射和转换操作，然后插入或更新到目标表
            //                    // 以下是示例操作，您需要根据实际表结构和需求进行修改
            //                    int id = reader.GetInt32(reader.GetOrdinal("ID"));
            //                    string name = reader.GetString(reader.GetOrdinal("Name"));
            //                    DateTime updateTimestamp = reader.GetDateTime(reader.GetOrdinal("UpdateTimestamp"));

            //                    // 将数据插入或更新到目标表
            //                    InsertOrUpdateDataIntoTargetTable(connection, id, name, updateTimestamp);
            //                }
            //            }
            //        }

            //        // 更新最后同步时间戳或标记到目标表
            //        UpdateLastSyncTimeInTargetTable(connection, DateTime.Now);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // 处理同步过程中的异常，记录日志等
            //    Console.WriteLine($"同步出错：{ex.Message}");
            //}
        }

        private DateTime GetLastSyncTimeFromTargetTable(SqlConnection connection)
        {
            // 查询目标表中的最后同步时间戳或标记
            // 如果是首次同步，可以返回一个默认值或最早的时间戳
            // 请根据您的实际需求来实现此方法
            // 示例中使用了默认的最早时间戳
            return DateTime.MinValue;
        }

        private void InsertOrUpdateDataIntoTargetTable(SqlConnection connection, int id, string name, DateTime updateTimestamp)
        {
            // 插入或更新数据到目标表
            // 请根据您的实际需求来实现此方法
            // 示例中使用了简单的插入操作
            string query = $"INSERT INTO {targetTableName} (ID, Name, UpdateTimestamp) VALUES (@ID, @Name, @UpdateTimestamp)";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@UpdateTimestamp", updateTimestamp);

                command.ExecuteNonQuery();
            }
        }

        private void UpdateLastSyncTimeInTargetTable(SqlConnection connection, DateTime lastSyncTime)
        {
            // 更新目标表中的最后同步时间戳或标记
            // 请根据您的实际需求来实现此方法
            // 示例中仅打印一条消息
            Console.WriteLine($"已更新最后同步时间：{lastSyncTime}");
        }
    }
}
