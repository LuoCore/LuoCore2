using SqlSugar;
using System;
using Utility.Factory;

namespace Utility.Repository
{
    public class SqlSugarRepository<TFactory, TIRepository> : ISqlSugarRepository
        where TFactory : ISqlSugarFactory
        where TIRepository : ISqlSugarRepository
    {

        protected readonly TFactory Factory;
        protected readonly TIRepository DbRepository;
        protected SqlSugarClient DbContext
        {
            get
            {
                return this.Factory.GetDbContext();
            }
        }

        public SqlSugarRepository(TFactory factory)
        {
            Factory = factory;
        }

        public SqlSugarRepository(TFactory factory, TIRepository repository) : this(factory)
        {
            DbRepository = repository;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class SqlSugarRepository<TFactory> : ISqlSugarRepository where TFactory : ISqlSugarFactory
    {

        protected readonly TFactory Factory;
        protected SqlSugarClient DbContext
        {
            get
            {
                return this.Factory.GetDbContext();
            }
        }

        public SqlSugarRepository(TFactory factory)
        {
            Factory = factory;
        }
    }
}
