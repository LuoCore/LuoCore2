using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.UserBasis.Request
{
    public class RequestUpdateRoleVm:RequestBaseVm
    {
        public string RoleId { get;  set; }
        public string RoleName { get;  set; }
        public string RoleDescription { get;  set; }
        public bool IsValid { get;  set; }
    }
}
