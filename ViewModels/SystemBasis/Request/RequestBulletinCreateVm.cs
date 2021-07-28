using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestBulletinCreateVm:RequestBaseVm
    {
        public string BulletinName { get; set; }
        public string BulletinConten { get; set; }
        public bool IsValid { get; set; }
    }
}
