using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.User.Request
{
    public class RequestUserLoginVm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VerifiCode { get; set; }
        public string SecurityCode { get; set; }
    }
}
