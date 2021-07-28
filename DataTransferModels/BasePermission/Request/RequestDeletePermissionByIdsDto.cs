using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BasePermission.Request
{
    public class RequestDeletePermissionByIdsDto : RequestBaseDto
    {
        public RequestDeletePermissionByIdsDto(string actionUserName, string actionUserInfo, List<string> permissionIds) : base(actionUserName, actionUserInfo)
        {

            PermissionIds = permissionIds;

        }
        public List<string> PermissionIds { get;protected set; }
    }
}
