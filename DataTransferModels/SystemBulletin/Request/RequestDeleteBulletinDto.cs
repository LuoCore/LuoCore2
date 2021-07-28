using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestDeleteBulletinDto : RequestBaseDto
     {
          public RequestDeleteBulletinDto(int bulletinID, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            BulletinID = bulletinID;
          }

          public int BulletinID { get;protected set; }
        
     }
}
