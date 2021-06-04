using IRepository;
using Utility.Factory;
using Utility.Repository;

namespace Services
{
    public class BaseService<T> : SqlSugarRepository<ISqlSugarFactory, T> where T : ISqlSugarRepository
    {
       protected readonly  ISystemLogsRepository  _LOGS_REPOSITORY;
        public BaseService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, T repository) : base(factory, repository)
        {
            _LOGS_REPOSITORY = logsRepository;
        }
    }

    public class BaseService<T,T2> : SqlSugarRepository<ISqlSugarFactory, T> 
        where T : ISqlSugarRepository
        where T2 : ISqlSugarRepository
    {
        protected readonly ISystemLogsRepository _LOGS_REPOSITORY;
        protected readonly T2 _REPOSITORY2;
        public BaseService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, T repository,T2 repository2) : base(factory, repository)
        {
            _LOGS_REPOSITORY = logsRepository;
            _REPOSITORY2 = repository2;
        }
    }

    public class BaseService<T, T2,T3> : SqlSugarRepository<ISqlSugarFactory, T>
        where T : ISqlSugarRepository
        where T2 : ISqlSugarRepository
        where T3 : ISqlSugarRepository
    {
        protected readonly ISystemLogsRepository _LOGS_REPOSITORY;
        protected readonly T2 _REPOSITORY2;
        protected readonly T3 _REPOSITORY3;
        public BaseService(ISqlSugarFactory factory, ISystemLogsRepository logsRepository, T repository, T2 repository2, T3 repository3) : base(factory, repository)
        {
            _LOGS_REPOSITORY = logsRepository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
        }
    }
}
