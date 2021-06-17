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
        protected readonly TIRepository4 _REPOSITORY4;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4)
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


    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4, TIRepository5> : ISqlSugarRepository
      where TIRepository : ISqlSugarRepository
      where TIRepository2 : ISqlSugarRepository
      where TIRepository3 : ISqlSugarRepository
      where TIRepository4 : ISqlSugarRepository
        where TIRepository5 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository4 _REPOSITORY4;
        protected readonly TIRepository5 _REPOSITORY5;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4, TIRepository5 repository5)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
            _REPOSITORY5 = repository5;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }



    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4, TIRepository5, TIRepository6> : ISqlSugarRepository
      where TIRepository : ISqlSugarRepository
      where TIRepository2 : ISqlSugarRepository
      where TIRepository3 : ISqlSugarRepository
      where TIRepository4 : ISqlSugarRepository
      where TIRepository5 : ISqlSugarRepository
      where TIRepository6 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository4 _REPOSITORY4;
        protected readonly TIRepository5 _REPOSITORY5;
        protected readonly TIRepository6 _REPOSITORY6;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4, TIRepository5 repository5, TIRepository6 repository6)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
            _REPOSITORY5 = repository5;
            _REPOSITORY6 = repository6;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4, TIRepository5, TIRepository6, TIRepository7> : ISqlSugarRepository
      where TIRepository : ISqlSugarRepository
      where TIRepository2 : ISqlSugarRepository
      where TIRepository3 : ISqlSugarRepository
      where TIRepository4 : ISqlSugarRepository
      where TIRepository5 : ISqlSugarRepository
      where TIRepository6 : ISqlSugarRepository
      where TIRepository7 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository4 _REPOSITORY4;
        protected readonly TIRepository5 _REPOSITORY5;
        protected readonly TIRepository6 _REPOSITORY6;
        protected readonly TIRepository7 _REPOSITORY7;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4, TIRepository5 repository5, TIRepository6 repository6, TIRepository7 repository7)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
            _REPOSITORY5 = repository5;
            _REPOSITORY6 = repository6;
            _REPOSITORY7 = repository7;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }


    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4, TIRepository5, TIRepository6, TIRepository7, TIRepository8> : ISqlSugarRepository
      where TIRepository : ISqlSugarRepository
      where TIRepository2 : ISqlSugarRepository
      where TIRepository3 : ISqlSugarRepository
      where TIRepository4 : ISqlSugarRepository
      where TIRepository5 : ISqlSugarRepository
      where TIRepository6 : ISqlSugarRepository
      where TIRepository7 : ISqlSugarRepository
      where TIRepository8 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository4 _REPOSITORY4;
        protected readonly TIRepository5 _REPOSITORY5;
        protected readonly TIRepository6 _REPOSITORY6;
        protected readonly TIRepository7 _REPOSITORY7;
        protected readonly TIRepository8 _REPOSITORY8;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4, TIRepository5 repository5, TIRepository6 repository6, TIRepository7 repository7, TIRepository8 repository8)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
            _REPOSITORY5 = repository5;
            _REPOSITORY6 = repository6;
            _REPOSITORY7 = repository7;
            _REPOSITORY8 = repository8;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }


    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4, TIRepository5, TIRepository6, TIRepository7, TIRepository8, TIRepository9> : ISqlSugarRepository
      where TIRepository : ISqlSugarRepository
      where TIRepository2 : ISqlSugarRepository
      where TIRepository3 : ISqlSugarRepository
      where TIRepository4 : ISqlSugarRepository
      where TIRepository5 : ISqlSugarRepository
      where TIRepository6 : ISqlSugarRepository
      where TIRepository7 : ISqlSugarRepository
      where TIRepository8 : ISqlSugarRepository
      where TIRepository9 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository4 _REPOSITORY4;
        protected readonly TIRepository5 _REPOSITORY5;
        protected readonly TIRepository6 _REPOSITORY6;
        protected readonly TIRepository7 _REPOSITORY7;
        protected readonly TIRepository8 _REPOSITORY8;
        protected readonly TIRepository9 _REPOSITORY9;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4, TIRepository5 repository5, TIRepository6 repository6, TIRepository7 repository7, TIRepository8 repository8, TIRepository9 repository9)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
            _REPOSITORY5 = repository5;
            _REPOSITORY6 = repository6;
            _REPOSITORY7 = repository7;
            _REPOSITORY8 = repository8;
            _REPOSITORY9 = repository9;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public class SqlSugarRepository<TIRepository, TIRepository2, TIRepository3, TIRepository4, TIRepository5, TIRepository6, TIRepository7, TIRepository8, TIRepository9, TIRepository10> : ISqlSugarRepository
      where TIRepository : ISqlSugarRepository
      where TIRepository2 : ISqlSugarRepository
      where TIRepository3 : ISqlSugarRepository
      where TIRepository4 : ISqlSugarRepository
      where TIRepository5 : ISqlSugarRepository
      where TIRepository6 : ISqlSugarRepository
      where TIRepository7 : ISqlSugarRepository
      where TIRepository8 : ISqlSugarRepository
      where TIRepository9 : ISqlSugarRepository
      where TIRepository10 : ISqlSugarRepository
    {

        protected readonly ISqlSugarFactory _FACTORY;
        protected readonly TIRepository _REPOSITORY;
        protected readonly TIRepository2 _REPOSITORY2;
        protected readonly TIRepository3 _REPOSITORY3;
        protected readonly TIRepository4 _REPOSITORY4;
        protected readonly TIRepository5 _REPOSITORY5;
        protected readonly TIRepository6 _REPOSITORY6;
        protected readonly TIRepository7 _REPOSITORY7;
        protected readonly TIRepository8 _REPOSITORY8;
        protected readonly TIRepository9 _REPOSITORY9;
        protected readonly TIRepository10 _REPOSITORY10;
        protected SqlSugarClient DbContext => this._FACTORY.GetDbContext();
        public SqlSugarRepository(ISqlSugarFactory factory, TIRepository repository, TIRepository2 repository2, TIRepository3 repository3, TIRepository4 repository4, TIRepository5 repository5, TIRepository6 repository6, TIRepository7 repository7, TIRepository8 repository8, TIRepository9 repository9, TIRepository10 repository10)
        {
            _FACTORY = factory;
            _REPOSITORY = repository;
            _REPOSITORY2 = repository2;
            _REPOSITORY3 = repository3;
            _REPOSITORY4 = repository4;
            _REPOSITORY5 = repository5;
            _REPOSITORY6 = repository6;
            _REPOSITORY7 = repository7;
            _REPOSITORY8 = repository8;
            _REPOSITORY9 = repository9;
            _REPOSITORY10 = repository10;
        }
        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
