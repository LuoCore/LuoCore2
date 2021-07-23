using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserBasis.Request
{
    public class RequestUpdatePermissionVm : RequestBaseVm
    {
        public string PermissionId { get; set; }
        public string PermissionName { get; set; }
        public int PermissionType { get;  set; }
        public string PermissionAction { get;  set; }
        public string PermissionParentId { get;  set; }
        public bool IsValid { get;  set; }
    }
}
