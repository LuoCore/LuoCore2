using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;

namespace Repository
{
   public class BaseRepository : SqlSugarRepository<ISqlSugarFactory>
    {
        protected readonly ISystemLogsRepository _LOGS_REPOSITORY;
        protected BaseRepository(ISqlSugarFactory factory, ISystemLogsRepository logsRepository) : base(factory)
        {
            _LOGS_REPOSITORY = logsRepository;
        }
    }
}
