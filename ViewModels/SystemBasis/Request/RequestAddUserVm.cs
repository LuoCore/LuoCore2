using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestAddUserVm:RequestBaseVm
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserRealName { get; set; }
        public int Sex { get; set; }
        public string Password { get; set; }
        public string PasswordVerify { get; set; }
        public string RoleSelect { get; set; }
        public bool IsValid { get; set; }
    }
}
