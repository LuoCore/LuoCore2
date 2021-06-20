using DataTransferModels;
using DataTransferModels.BaseRolePermission.Request;
using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
    public interface IRolePermissionRepository : ISqlSugarRepository
    {
        public ResultDto CreateRolePermission(RequestCreateRolePermissionDto req);
        public List<Base_RolePermission> ReadRolePermissionByRoleId(string roleId);
        public List<Base_RolePermission> ReadRolePermissionAll();
        public List<Base_RolePermission> ReadRolePermissionByRoleIds(List<string> roleIds);
    }
}
