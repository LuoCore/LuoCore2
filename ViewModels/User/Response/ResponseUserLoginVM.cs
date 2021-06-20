using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitysModels;

namespace ViewModels.User.Response
{
    public class ResponseUserLoginVM
    {
        public Base_User UserInfo { get; set; }
        public List<Base_Permission> PermissionInfo { get; set; }
    }
}
