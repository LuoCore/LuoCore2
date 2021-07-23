using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
     public class RequestLinkQueryPageVm
     {
       

          public int ID { get; set; }
          public string LinkName { get;  set; }
          public bool? IsValid { get;  set; }
          public int PageIndex { get;  set; }
          public int PageSize { get;  set; }
     }
}
