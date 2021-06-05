using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Factory
{
    public interface ISqlSugarFactory
    {

        SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent);
        SqlSugarClient GetDbContext(Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent);
        SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent = null, Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent = null, Action<Exception> onErrorEvent = null);
        void GetDbContext(Action<SqlSugarClient> Func);
        void GetDbContextTran(Action<SqlSugarClient> Func);
        public T GetDbContext<T>(Func<SqlSugarClient, T> Func);
    }
}
