using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestAddPermissionVm
    {
        public string PermissionName { get;  set; }
        public EnumHelper.PermissionTypeEnum PermissionType { get;  set; }
        public string PermissionAction { get;  set; }
        public string PermissionParentId { get;  set; }
        public string CreateName { get;  set; }
        public bool IsValid { get;  set; }
    }
}
