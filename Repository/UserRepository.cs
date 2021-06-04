using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using EntitysModels;
using DataTransferModels;
using DataTransferModels.BaseUser.Request;

namespace Repository
{
    /// <summary>
    /// 
    /// create/read/update/delate
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        protected UserRepository(ISqlSugarFactory factory, ISystemLogsRepository logsRepository) : base(factory, logsRepository)
        {
        }

        public ResultDto ReadFirstByLogin(LoginDto req)
        {
            ResultDto res = new ResultDto();
            Factory.GetDbContext((db) =>
            {
                res.Data = db.Queryable<Base_User>()
               .Where(x => x.UserName.Equals(req.UserName))
               .Where(x => x.Password.Equals(req.Password))
                .First();
                res.Status = true;
            });
            return res;
        }
    }
}
