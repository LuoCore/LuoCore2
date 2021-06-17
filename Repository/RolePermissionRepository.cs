using DataTransferModels;
using DataTransferModels.BaseRolePermission.Request;
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
    public class RolePermissionRepository : SqlSugarRepository<ISystemLogsRepository>, IRolePermissionRepository
    {
        public RolePermissionRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }

        public ResultDto CreateRolePermission(RequestCreateRolePermissionDto req) 
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    foreach (var roleid in req.RoleIds)
                    {
                        foreach (var permissionid in req.PermissionIds)
                        {
                            var insetData = new
                            {
                                PermissionId = permissionid,
                                RoleId = roleid,
                                RolePermissionId = Guid.NewGuid()
                            };
                            db.Insertable<Base_RolePermission>(insetData).ExecuteCommand();
                            _REPOSITORY.LogSave<Base_RolePermission>(db, EnumHelper.CURDEnum.创建, insetData, null, req.UserName, req.UserInfo).ExecuteCommand();
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


        public List<Base_RolePermission> ReadRolePermissionByRoleId(string roleId)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    db.Queryable<Base_RolePermission>().Where(x => x.RoleId.Equals(roleId)).ToList();

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
