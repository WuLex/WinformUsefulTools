using System.Data.SqlClient;

namespace DataSyncTool.Common
{
    public  class DataSyncService
    {
        //private string sourceconnectionString = ""; // 替换为您的源SQL Server连接字符串
        //private string targetconnectionString = ""; // 替换为您的目标SQL Server连接字符串
        //private string sourceTableName = ""; // 替换为源表名称
        //private string targetTableName = ""; // 替换为目标表名称

        //public DataSyncService(string sourceConnectionString, string destinationConnectionString,string sourceTableName ,string targetTableName)
        //{
        //    this.sourceconnectionString = sourceConnectionString;
        //    this.targetconnectionString = destinationConnectionString;
        //    this.sourceTableName = sourceTableName;
        //    this.targetTableName = targetTableName;
        //}

        public DataSyncService() 
        {
        }

        /// <summary>
        /// 执行数据同步
        /// </summary>
        /// <param name="sourceConnectionString"></param>
        /// <param name="targetConnectionString"></param>
        /// <param name="sourceTableName"></param>
        /// <param name="targetTableName"></param>
        /// <param name="timestampColumn">时间戳列的名称</param>
        public void PerformDataSync(string sourceConnectionString, string targetConnectionString, string sourceTableName, string targetTableName)
        {
            DateTime lastSyncTime = GetLastSyncTime(); //DateTime.Parse("2023-01-01 00:00:00"); // 上次同步的时间
            string timestampColumn = "UpdateTimestamp"; //时间戳列的名称
            string[] keyColumns = new string[] { "ID" }; // 指定关键列的名称

            using (SqlConnection sourceConnection = new SqlConnection(sourceConnectionString))
            using (SqlConnection targetConnection = new SqlConnection(targetConnectionString))
            {
                sourceConnection.Open();
                targetConnection.Open();

                // 获取源表的所有列名
                string sourceColumnList = GetColumnList(sourceTableName, sourceConnection);

                // 获取目标表的所有列名
                string targetColumnList = GetColumnList(targetTableName, targetConnection);

                // 构建MERGE语句，使用时间戳进行筛选
                string mergeSql = GenerateMergeSql(sourceTableName, targetTableName, sourceColumnList, targetColumnList, timestampColumn, keyColumns);

                using (SqlCommand mergeCommand = new SqlCommand(mergeSql, targetConnection))
                {
                    // 为@LastSyncTime参数赋值
                    mergeCommand.Parameters.AddWithValue("@LastSyncTime", lastSyncTime);
                    mergeCommand.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// 差量同步，需要设置时间
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="targetTable"></param>
        /// <param name="timestampColumn"></param>
        /// <param name="lastSyncTime"></param>
        /// <returns></returns>
        private string GenerateMergeSql(string sourceTable, string targetTable, string sourceColumnList, string targetColumnList, string timestampColumn, string[] keyColumns)
        {
            string mergeSql = $@"
            MERGE INTO {targetTable} AS target
            USING (
                SELECT {sourceColumnList} FROM {sourceTable}
                WHERE {timestampColumn} > @LastSyncTime
            ) AS source
            ON {GenerateKeyConditions(keyColumns)}
            WHEN MATCHED THEN
                UPDATE SET {GenerateUpdateColumns(sourceColumnList, targetColumnList)}
            WHEN NOT MATCHED BY TARGET THEN
                INSERT ({GenerateTargetColumns(targetColumnList)})
                VALUES ({GenerateSourceColumns(sourceColumnList)});
            ";

            return mergeSql;
        }

        /// <summary>
        /// 全量同步，需要配置主键
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="targetTable"></param>
        /// <param name="keyColumns"></param>
        /// <returns></returns>

        private string GenerateMergeSql(string sourceTable, string targetTable, string sourceColumnList, string targetColumnList, string[] keyColumns)
        {
            string mergeSql = $@"
            MERGE INTO {targetTable} AS target
            USING {sourceTable} AS source
            ON {GenerateKeyConditions(keyColumns)}
            WHEN MATCHED THEN
                UPDATE SET {GenerateUpdateColumns(sourceColumnList, targetColumnList)}
            WHEN NOT MATCHED BY TARGET THEN
                INSERT ({GenerateTargetColumns(targetColumnList)})
                VALUES ({GenerateSourceColumns(sourceColumnList)});
            ";
            return mergeSql;
        }

        private string GenerateKeyConditions(string[] keyColumns, string targetAlias = "target", string sourceAlias = "source")
        {
            return string.Join(" AND ", keyColumns.Select(col => $"{targetAlias}.{col} = {sourceAlias}.{col}"));
        }

        private string GetColumnList(string tableName, SqlConnection connection)
        {
            // 查询表的列名，并将它们以逗号分隔返回
            // 这里需要根据数据库系统和库来执行查询
            // 以下示例仅为演示目的，实际应根据数据库系统和库来查询列名
            // 请使用适当的查询方式获取列名
            // 例如：SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'tableName'
            //return "Column1, Column2, Column3"; // 替换为实际列名

            // 查询表的列名，并将它们以逗号分隔返回
            using (SqlCommand command = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                var columnNames = new List<string>();
                while (reader.Read())
                {
                    string columnName = reader.GetString(0);
                    columnNames.Add(columnName);
                    //// 排除主键列 "id"
                    //if (!string.Equals(columnName, "id", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    columnNames.Add(columnName);
                    //}
                }
                return string.Join(",", columnNames);
            }
        }

        private string GenerateUpdateColumns(string sourceColumnList, string targetColumnList, string targetAlias = "target", string sourceAlias = "source")
        {
            // 将源列列表和目标列列表拆分为列数组
            string[] sourceColumns = sourceColumnList.Split(',').Where(x => x.ToUpper() != "ID").Select(col => col.Trim()).ToArray();
            string[] targetColumns = targetColumnList.Split(',').Where(x => x.ToUpper() != "ID").Select(col => col.Trim()).ToArray();

            // 生成需要更新的列，排除主键列
            // 这里假设除主键外的所有列都需要更新
            List<string> updateColumns = new List<string>();

            for (int i = 0; i < sourceColumns.Length; i++)
            {
                string sourceCol = sourceColumns[i];
                string targetCol = targetColumns[i];

                // 生成 SET 子句，例如：target.Column1 = source.Column1, target.Column2 = source.Column2
                // 这里假设 keyColumns 是主键列的名称数组
                //if (!keyColumns.Contains(targetCol))
                //{
                string updateClause = $"{targetAlias}.{targetCol} = {sourceAlias}.{sourceCol}";
                updateColumns.Add(updateClause);
                //}
            }

            return string.Join(", ", updateColumns);

            //return string.Join(", ", sourceColumnList.Split(',').Select(col => $"{targetAlias}.{col} = {sourceAlias}.{col}"));
        }

        private string GenerateTargetColumns(string targetColumnList, string targetAlias = "target")
        {
            // 生成目标表的列列表
            // string[] columns = targetColumnList.Split(',').Select(col => $"{targetAlias}.{col.Trim()}").ToArray();
            // return string.Join(", ", columns);

            string[] columns = targetColumnList.Split(',').Where(x => x.ToUpper() != "ID").ToArray();
            return string.Join(", ", columns);
        }

        private string GenerateSourceColumns(string sourceColumnList, string sourceAlias = "source")
        {
            // 生成源表的列列表
            //return sourceColumnList.Replace(",", $", {sourceAlias}.");
            string[] columns = sourceColumnList.Split(',').Where(x => x.ToUpper() != "ID").Select(col => $"{sourceAlias}.{col.Trim()}").ToArray();
            return string.Join(", ", columns);
        }

        private DateTime GetLastSyncTime()
        {
            // 查询目标表中的最后同步时间戳或标记
            // 如果是首次同步，可以返回一个默认值或最早的时间戳
            // 请根据您的实际需求来实现此方法
            // 示例中使用了默认的最早时间戳
            DateTime oneWeekAgo = DateTime.Now.AddDays(-7);
            return oneWeekAgo;
            // return DateTime.MinValue;
        }
    }
}