using IRepository;
using System;
using Utility.Factory;
using Utility.Repository;
using DataTransferModels.CreateEntity.Request;

namespace Repository
{
    public class CreateEntityRepository : SqlSugarRepository, ICreateEntityRepository
    {
        public CreateEntityRepository(ISqlSugarFactory factory) : base(factory)
        {
        }
        /// <summary>
        /// 生成实体带有默认值
        /// </summary>
        public bool CreateDefaultValue(CreateEntityDto req)
        {
            return _FACTORY.GetDbContext((db) =>
             {
                 try
                 {
                     db.DbFirst.IsCreateDefaultValue().CreateClassFile(req.DirectoryPath, req.NameSpace);
                     return true;
                 }
                 catch (Exception)
                 {

                     return false;
                 }

             });

        }

        /// <summary>
        /// 生成带有SqlSugar特性的实体
        /// </summary>
        public bool CreateAttribute(CreateEntityDto req)
        {
            return _FACTORY.GetDbContext((db) =>
            {
                try
                {
                    db.DbFirst.IsCreateAttribute().CreateClassFile(req.DirectoryPath, req.NameSpace);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            });

        }
    }
}
