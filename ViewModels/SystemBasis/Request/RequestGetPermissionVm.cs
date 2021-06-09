using EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestGetPermissionVm
    {
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public PermissionTypeEnum? PermissionType { get; set; }
        public string PermissionAction { get; set; }
        public string PermissionParentId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string CreateName { get; set; }
        public bool? IsValid { get; set; }

   
    }
}
