using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestDeletePermissionVm : RequestBaseVm
    {
        public List<string> PermissionIds { get; set; }
    }
}
