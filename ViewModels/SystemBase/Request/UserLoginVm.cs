using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBase.Request
{
    public class UserLoginVm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VerifiCode { get; set; }
    }
}
