using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Request
{
     public class RequestDeleteLanguageDto : RequestBaseDto
     {
          public RequestDeleteLanguageDto(int languageId, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            LanguageID = languageId;
          }

          public int LanguageID { get;protected set; }
        
     }
}
