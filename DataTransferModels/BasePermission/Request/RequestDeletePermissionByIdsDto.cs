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
            this.UserName = username;
            this.UserInfo = userInfo;
            PermissionIds = permissionIds;

        }
        public List<string> PermissionIds { get;protected set; }
    }
}
