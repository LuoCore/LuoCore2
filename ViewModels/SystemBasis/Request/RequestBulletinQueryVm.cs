using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
    public class RequestBulletinQueryVm
    {
        public int ID { get;  set; }
        public string BulletinName { get;  set; }
        public bool? IsValid { get;  set; }
     
    }

}
