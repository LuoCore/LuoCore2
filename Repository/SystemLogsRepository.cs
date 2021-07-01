using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using EntitysModels;
using Common;
using SqlSugar;
using EnumHelper;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Repository
{
    public class SystemLogsRepository : SqlSugarRepository, ISystemLogsRepository
    {
        public SystemLogsRepository(ISqlSugarFactory factory) : base(factory)
        {
        }

        public SqlSugar.IInsertable<System_Logs> LogSave<T>(SqlSugar.SqlSugarClient dbclient, EnumHelper.CURDEnum typeValue, dynamic nowData, dynamic oldData, string username, string userinfoJson)
          where T : class, new()
        {
            DateTime dateTime = GetNowDateTime();
            var tableName = typeof(T);

            if (string.IsNullOrWhiteSpace(username))
            {
                username = System.Environment.UserName;
            }
            var InstanceData = new
            {
                LogId = Guid.NewGuid().ToString(),
                LogName = tableName.Name,
                LogType = typeValue.EnumToString(),
                LogNewData = Newtonsoft.Json.JsonConvert.SerializeObject(nowData),
                LogOldData = Newtonsoft.Json.JsonConvert.SerializeObject(oldData),
                OperationUserInfo = userinfoJson,
                CreateTime = dateTime,
                CreateName = username,
                IsValid = true
            };

            SqlSugar.IInsertable<System_Logs> inserLogs = dbclient.Insertable<System_Logs>(InstanceData).IgnoreColumns(ignoreNullColumn: true);
            return inserLogs;
        }
        public DateTime GetNowDateTime()
        {
            return DbContext.GetDate();
        }

        #region 建造者



        System_Logs _LOGSMODEL =new System_Logs();
        List<string> _COLUMNS = new List<string>();
      
        public ISystemLogsRepository SqlTypeCurd<T>(EnumHelper.CURDEnum typeEnum) where T : class, new()
        {
           
            Type tableType = typeof(T);
            _LOGSMODEL.LogId = Guid.NewGuid().ToString();
            _LOGSMODEL.LogName = tableType.Name;
            _LOGSMODEL.LogType = typeEnum.EnumToString();
            _LOGSMODEL.IsValid = true;
            _COLUMNS.AddRange(new string[] { "LogId", "LogName", "LogType", "IsValid" });
            return this;
        }
        public ISystemLogsRepository OperationUserInfo(string username, string userinfoJson)
        {
            _LOGSMODEL.CreateName = username;
            _LOGSMODEL.OperationUserInfo = username;
            _COLUMNS.AddRange(new string[] { "CreateName", "OperationUserInfo"});
          
            return this;
        }
        public ISystemLogsRepository NowData(dynamic nowData)
        {
            _LOGSMODEL.LogNewData = Newtonsoft.Json.JsonConvert.SerializeObject(nowData);
            _COLUMNS.Add("LogNewData");
            return this;
        }

        public ISystemLogsRepository OldData(dynamic oldData)
        {
            _LOGSMODEL.LogOldData = Newtonsoft.Json.JsonConvert.SerializeObject(oldData);
            _COLUMNS.Add("LogOldData");
            return this;
        }

        public void BuilderSQL(SqlSugar.SqlSugarClient dbClient)
        {
            _LOGSMODEL.CreateTime = dbClient.GetDate();
            _COLUMNS.Add("CreateTime");
            dbClient.Insertable<System_Logs>(_LOGSMODEL).InsertColumns(_COLUMNS.ToArray()).IgnoreColumns(ignoreNullColumn: true).ExecuteCommand();
        }
        #endregion 建造者

    }
}
