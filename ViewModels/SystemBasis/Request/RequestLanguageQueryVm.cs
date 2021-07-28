using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.SystemBasis.Request
{
     public class RequestLanguageQueryVm
    {
          public int ID { get;  set; }
          public string LanguageName { get;  set; }
          public string LanguageJson { get;  set; }
          public bool? IsValid { get;  set; }
     }
}
