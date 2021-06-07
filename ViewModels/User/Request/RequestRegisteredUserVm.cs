using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.User.Request
{
    public class RequestRegisteredUserVm
    {
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string Vercode { get; set; }
        public string SecurityCode { get; set; }
        public int Sex { get; set; }
        public string Password { get; set; }
        public string PasswordVerify { get; set; }

        public string CreateName { get; set; }
    }
}
