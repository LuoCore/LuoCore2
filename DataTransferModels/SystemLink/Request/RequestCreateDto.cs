using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestCreateDto:RequestBaseDto
     {
          public RequestCreateDto(string linkName, string linkUrl, string linkIco, bool isValid,string actionUserName, string actionUserInfo)
          {
               LinkName = linkName;
               LinkUrl = linkUrl;
               LinkIco = linkIco;
               IsValid = isValid;
               this.ActionUserInfo = actionUserInfo;
               this.ActionUserName = actionUserName;
          }

          public string LinkName { get;protected set; }
          public string LinkUrl { get; protected set; }
          public string LinkIco { get; protected set; }
          public bool IsValid { get; protected set; }
     }
}
