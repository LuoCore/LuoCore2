using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
     public class RequestLanguageQueryPageVm:RequestLanguageQueryVm
     {
      
          public int PageIndex { get;  set; }
          public int PageSize { get;  set; }
     }
}
