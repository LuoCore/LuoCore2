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
            System_Logs _Logs = new System_Logs()
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
            SqlSugar.IInsertable<System_Logs> inserLogs = dbclient.Insertable<System_Logs>(_Logs).IgnoreColumns(ignoreNullColumn: true);
            return inserLogs;
        }
        public DateTime GetNowDateTime()
        {
            return DbContext.GetDate();
        }


    }
}
