using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLanguage.Request
{
     public class RequestDeleteLanguageDto : RequestBaseDto
     {
          public RequestDeleteLanguageDto(int linkId,string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            LinkID = linkId;
          }

          public int LinkID { get;protected set; }
        
     }
}
