using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BasePermission.Request
{
    public class RequestUpdatePermissionByIdDto:RequestBaseDto
    {
        public RequestUpdatePermissionByIdDto(string userName,string userInfo, string permissionName, int permissionType, string permissionAction, string permissionParentId, bool isValid)
        {
            UserName = userName;
            UserInfo = userInfo;
            PermissionName = permissionName;
            PermissionType = permissionType;
            PermissionAction = permissionAction;
            PermissionParentId = permissionParentId;
            IsValid = isValid;

        }
     
        public string PermissionName { get; protected set; }
        public int PermissionType { get; protected set; }
        public string PermissionAction { get; protected set; }
        public string PermissionParentId { get; protected set; }
        public bool IsValid { get; protected set; }
    }
}
