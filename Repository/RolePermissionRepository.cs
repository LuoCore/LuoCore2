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
                        var rolePermissionList= db.Queryable<Base_RolePermission>().Where(x => x.RoleId.Equals(roleid)).ToList();
                        db.Deleteable<Base_RolePermission>().Where(x => x.RoleId.Equals(roleid)).ExecuteCommand();
                        _REPOSITORY.LogSave<Base_RolePermission>(db, EnumHelper.CURDEnum.删除, null, rolePermissionList, req.ActionUserName, req.ActionUserInfo).ExecuteCommand();

                        foreach (var permissionid in req.PermissionIds)
                        {
                            var insetData = new
                            {
                                PermissionId = permissionid,
                                RoleId = roleid,
                                RolePermissionId = Guid.NewGuid()
                            };
                            db.Insertable<Base_RolePermission>(insetData).ExecuteCommand();
                            _REPOSITORY.LogSave<Base_RolePermission>(db, EnumHelper.CURDEnum.创建, insetData, null, req.ActionUserName, req.ActionUserInfo).ExecuteCommand();
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

        public List<Base_RolePermission> ReadRolePermissionAll()
        {
            List<Base_RolePermission> res = new List<Base_RolePermission>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res = db.Queryable<Base_RolePermission>().ToList();
                });

            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;

        }

        public List<Base_RolePermission> ReadRolePermissionByRoleId(string roleId)
        {
            List<Base_RolePermission> res = new List<Base_RolePermission>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res= db.Queryable<Base_RolePermission>().Where(x => x.RoleId.Equals(roleId)).ToList();

                });
               
            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;

        }


        public List<Base_RolePermission> ReadRolePermissionByRoleIds(List<string> roleIds)
        {
            List<Base_RolePermission> res = new List<Base_RolePermission>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    res = db.Queryable<Base_RolePermission>().Where(x => roleIds.Contains(x.RoleId)).ToList();

                });

            }
            catch (Exception ex)
            {
                res = null;
            }
            return res;
        }

    }
}
