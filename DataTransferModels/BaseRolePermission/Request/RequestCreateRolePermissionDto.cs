using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BaseRolePermission.Request
{
    public class RequestCreateRolePermissionDto:RequestBaseDto
    {
        public RequestCreateRolePermissionDto(List<string> permissionIds, List<string> roleIds, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            PermissionIds = permissionIds;
            RoleIds = roleIds;
        }

        public List<string> PermissionIds { get; protected set; }
        public List<string> RoleIds { get; protected set; }
    }
}
