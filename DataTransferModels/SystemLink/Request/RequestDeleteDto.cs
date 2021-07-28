using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestDeleteDto : RequestBaseDto
     {
          public RequestDeleteDto(int linkId,string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            LinkID = linkId;
          }

          public int LinkID { get;protected set; }
        
     }
}
