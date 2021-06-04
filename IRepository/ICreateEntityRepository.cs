using DataTransferModels.CreateEntity.Request;
using System;
using Utility.Repository;

namespace IRepository
{
    public interface ICreateEntityRepository : ISqlSugarRepository
    {
        /// <summary>
        /// 生成实体带有默认值
        /// </summary>
        public bool CreateDefaultValue(CreateEntityDto req);
        /// <summary>
        /// 生成带有SqlSugar特性的实体
        /// </summary>
        public bool CreateAttribute(CreateEntityDto req);
    }
}
