using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BsaeRole.Request
{
    public class RequestQueryRoleDto
    {

        public RequestQueryRoleDto(string roleId, string roleName, bool? isValid, DateTime? startTime, DateTime? endTime, int pageIndex, int pageSize)
        {
            RoleId = roleId;
            RoleName = roleName;
            IsValid = isValid;
            StartTime = startTime;
            EndTime = endTime;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public string RoleId { get;protected set; }
        public string RoleName { get; protected set; }
        public bool? IsValid { get; protected set; }
        public DateTime? StartTime { get; protected set; }
        public DateTime? EndTime { get; protected set; }
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
    }
}
