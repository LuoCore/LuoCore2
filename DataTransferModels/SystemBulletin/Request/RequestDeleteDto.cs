using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestDeleteDto : RequestBaseDto
     {
          public RequestDeleteDto(int id,string actionUserName, string actionUserInfo)
          {
               ID = id;
               this.ActionUserInfo = actionUserInfo;
               this.ActionUserName = actionUserName;
          }

          public int ID { get;protected set; }
        
     }
}
