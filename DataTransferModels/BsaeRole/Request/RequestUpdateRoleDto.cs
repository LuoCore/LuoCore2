using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BsaeRole.Request
{
    public class RequestUpdateRoleDto:RequestBaseDto
    {
        public RequestUpdateRoleDto(string roleId, string roleName, string roleDescription, bool isValid, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
            IsValid = isValid;
        }

        public string RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public string RoleDescription { get; protected set; }
        public bool IsValid { get; protected set; }
    }
}
