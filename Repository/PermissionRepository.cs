using DataTransferModels;
using EntitysModels;
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
    public class PermissionRepository : SqlSugarRepository<ISystemLogsRepository>, IPermissionRepository
    {
        public PermissionRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }
        /// <summary>
        /// 按父级ID查询
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public ResultDto<List<Base_Permission>> ReadPermissionByParentId(string parentId) 
        {
            ResultDto<List<Base_Permission>> res = new ResultDto<List<Base_Permission>>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res.Status = true;
                    res.Data = new List<Base_Permission>();
                    res.Data = db.Queryable<Base_Permission>()
                    .Where(x => x.PermissionParentId.Equals(parentId))
                    .ToList();
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
        }
    }
}
