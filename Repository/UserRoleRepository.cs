using DataTransferModels;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using DataTransferModels.BaseUserRole.Request;
using EntitysModels;

namespace Repository
{
    public class UserRoleRepository : SqlSugarRepository<ISystemLogsRepository>, IUserRoleRepository
    {
        public UserRoleRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }

        public ResultDto CreateUserRole(RequestCreateUserRoleDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var userRoleInfos= db.Queryable<Base_UserRole>().Where(x => x.UserId.Equals(req.UserId)).ToList();
                    foreach (var roleid in req.RoleIds)
                    {
                        if (!userRoleInfos.Where(x => x.RoleId.Equals(roleid)).Any())
                        {
                            var insetData = new
                            {
                               UserId=req.UserId,
                               RoleId=roleid,
                               UserRoleId=Guid.NewGuid()
                            };
                            db.Insertable<Base_UserRole>(insetData).ExecuteCommand();
                            _REPOSITORY.LogSave<Base_UserRole>(db, EnumHelper.CURDEnum.创建, insetData, null, req.ActionUserName, req.ActionUserInfo).ExecuteCommand();
                        }
                    }
                });
                res.Status = true;
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;
        }

        public ResultDto<List<Base_UserRole>> ReadUserRoleByUserId(string userId)
        {
            ResultDto<List<Base_UserRole>> res = new ResultDto<List<Base_UserRole>>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res.Data = db.Queryable<Base_UserRole>().Where(x => x.UserId.Equals(userId)).ToList();
                });
                res.Status = true;
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
