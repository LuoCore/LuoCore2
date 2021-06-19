using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BaseUserRole.Request
{
    public class RequestCreateUserRoleDto:RequestBaseDto
    {
        public RequestCreateUserRoleDto(string userId, List<string> roleIds,string actionUserName,string actionUserInfo)
        {
            UserId = userId;
            RoleIds = roleIds;
            this.ActionUserName = actionUserName;
            this.ActionUserInfo = actionUserInfo;
        }

        public string UserId { get;protected set; }
        public List<string> RoleIds { get; protected set; }
    }
}
