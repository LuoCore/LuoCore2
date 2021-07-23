using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
     public class RequestLinkCreateVm :RequestBaseVm
     {
          public string LinkName { get;  set; }
          public string LinkUrl { get;  set; }
          public string LinkIco { get;  set; }
          public bool IsValid { get;  set; }
     }
}
