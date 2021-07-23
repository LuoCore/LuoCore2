using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestDeleteDto : RequestBaseDto
     {
          public RequestDeleteDto(int linkId,string actionUserName, string actionUserInfo)
          {
               ID = linkId;
               this.ActionUserInfo = actionUserInfo;
               this.ActionUserName = actionUserName;
          }

          public int ID { get;protected set; }
        
     }
}
