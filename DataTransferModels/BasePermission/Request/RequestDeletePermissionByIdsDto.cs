using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BasePermission.Request
{
    public class RequestDeletePermissionByIdsDto : RequestBaseDto
    {
        public RequestDeletePermissionByIdsDto(string username,string userInfo,List<string> permissionIds)
        {
            this.ActionUserName = username;
            this.ActionUserInfo = userInfo;
            PermissionIds = permissionIds;

        }
        public List<string> PermissionIds { get;protected set; }
    }
}
