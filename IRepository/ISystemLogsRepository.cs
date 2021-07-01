using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface ISystemLogsRepository : ISqlSugarRepository
    {
       
        public SqlSugar.IInsertable<System_Logs> LogSave<T>(SqlSugar.SqlSugarClient dbclient, EnumHelper.CURDEnum typeValue, dynamic nowData, dynamic oldData, string username, string userinfoJson)where T : class, new();
      
        public DateTime GetNowDateTime();
       
        public ISystemLogsRepository SqlTypeCurd<T>(EnumHelper.CURDEnum typeEnum) where T : class, new();
        public ISystemLogsRepository OperationUserInfo(string username, string userinfoJson);
        public ISystemLogsRepository NowData(dynamic nowData);
        public ISystemLogsRepository OldData(dynamic oldData);
        public void BuilderSQL(SqlSugar.SqlSugarClient dbClient);
    }
}
