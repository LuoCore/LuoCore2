using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BasePermission.Request
{
    public class RequestPermissionDto : BasePermissionDto
    {


        public RequestPermissionDto(string permissionId, string permissionName, int? permissionType, string permissionAction, string permissionParentId, DateTime? startTime, DateTime? endTime, string createName, bool? isValid)
        {
            PermissionId = permissionId;
            PermissionName = permissionName;
            PermissionType = permissionType;
            PermissionAction = permissionAction;
            PermissionParentId = permissionParentId;
            StartTime = startTime;
            EndTime = endTime;
            CreateName = createName;
            IsValid = isValid;
        }
        public DateTime? StartTime { get;protected set; }
        public DateTime? EndTime { get; protected set; }
        //private int pageIndex = 1;
        //public int PageIndex { get => pageIndex; protected set => pageIndex = value; }
        //private int pageSize = 20;
        //public int PageSize { get => pageSize; protected set => pageSize = value; }
    }
}
