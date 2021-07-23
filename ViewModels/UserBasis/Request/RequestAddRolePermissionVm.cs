using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserBasis.Request
{
    public class RequestAddRolePermissionVm : RequestBaseVm
    {
        public List<string> RoleIds { get; set; }
        public  List<string> PermissionIds { get;  set; }
    }
}
