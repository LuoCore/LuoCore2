using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestUpdateDto : RequestBaseDto
     {
          public RequestUpdateDto(int linkID, string linkName, string linkUrl, string linkIco, bool isValid,string actionUserName,string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            LinkID = linkID;
               LinkName = linkName;
               LinkUrl = linkUrl;
               LinkIco = linkIco;
               IsValid = isValid;
          }

          public int LinkID { get; protected set; }
          public string LinkName { get; protected set; }
          public string LinkUrl { get; protected set; }
          public string LinkIco { get; protected set; }
          public bool IsValid { get; protected set; }

     }
}
