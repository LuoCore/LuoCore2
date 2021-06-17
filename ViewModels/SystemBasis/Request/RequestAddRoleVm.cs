using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestAddRoleVm:RequestBaseVm
    {
        public string RoleName { get;  set; }
        public string RoleDescription { get;  set; }
        public bool IsValid { get;  set; }
    }
}
