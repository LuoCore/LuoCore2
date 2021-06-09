using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BasePermission.Request
{
    public class RequestCreatePermissionDto
    {
        public RequestCreatePermissionDto(Guid permissionId, string permissionName, int permissionType, string permissionAction, string permissionParentId, string createName, bool isValid)
        {
            PermissionId = permissionId;
            PermissionName = permissionName;
            PermissionType = permissionType;
            PermissionAction = permissionAction;
            PermissionParentId = permissionParentId;
            CreateName = createName;
            IsValid = isValid;
        }

        public Guid PermissionId { get; protected set; }
        public string PermissionName { get; protected set; }
        public int PermissionType { get; protected set; }
        public string PermissionAction { get; protected set; }
        public string PermissionParentId { get; protected set; }
        public string CreateName { get; protected set; }
        public bool IsValid { get; protected set; }
    }
}
