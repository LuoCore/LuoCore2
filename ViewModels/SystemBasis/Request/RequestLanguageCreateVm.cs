using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
     public class RequestLanguageCreateVm : RequestBaseVm
     {
          public string LanguageName { get;  set; }
        public List<ViewModels.SystemBasis.Response.ResponseLanguageTableVm> LanguageValue { get;  set; }
          public bool IsValid { get;  set; }
     }
}
