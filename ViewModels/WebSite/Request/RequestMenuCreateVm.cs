using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.WebSite.Request
{
    public class RequestMenuCreateVm:RequestBaseVm
    {
        public string MenuName { get;  set; }
        public string MenuUrl { get;  set; }
        public int MenuPid { get;  set; }
        public bool IsValid { get;  set; }
    }
}
