using SqlSugar;
using System;
using Utility.Factory;

namespace Utility.Repository
{
    //创建（Create）、更新（Update、PUT、Write）、读取（Retrieve、SELECT、GET 、Read）  和删除（Delete、dispose ）操作。
    public class SqlSugarRepository : ISqlSugarRepository
    {
        protected readonly ISqlSugarFactory _FACTORY;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory) => _FACTORY = factory;
    }

    public class SqlSugarRepository<TIRepository> : ISqlSugarRepository
        where TIRepository : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
    public class SqlSugarRepository<TIRepository, TIRepository2> : ISqlSugarRepository
        where TIRepository : ISqlSugarRepository
        where TIRepository2 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3> : ISqlSugarRepository
        where TIRepository : ISqlSugarRepository
        where TIRepository2 : ISqlSugarRepository
        where TIRepository3 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4> : ISqlSugarRepository
       where TIRepository : ISqlSugarRepository
       where TIRepository2 : ISqlSugarRepository
       where TIRepository3 : ISqlSugarRepository
       where TIRepository4 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository3 _REPOSITORY4;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository3 repository4)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }


}
