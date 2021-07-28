using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestUpdateBulletinDto : RequestBaseDto
     {
          public RequestUpdateBulletinDto(int bulletinID, string bulletinName, string bulletinConten, bool isValid, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            BulletinID = bulletinID;
               BulletinName = bulletinName;
               BulletinConten = bulletinConten;
               IsValid = isValid;
          }

          public int BulletinID { get; protected set; }
          public string BulletinName { get; protected set; }
          public string BulletinConten { get; protected set; }
          public bool IsValid { get; protected set; }

     }
}
