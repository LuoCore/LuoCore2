using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestUpdateDto : RequestBaseDto
     {
          public RequestUpdateDto(int iD, string bulletinName, string bulletinConten, bool isValid, string actionUserName, string actionUserInfo)
          {
               ID = iD;
               BulletinName = bulletinName;
               BulletinConten = bulletinConten;
               IsValid = isValid;
               ActionUserName = actionUserName;
               ActionUserInfo = actionUserInfo;
          }

          public int ID { get; protected set; }
          public string BulletinName { get; protected set; }
          public string BulletinConten { get; protected set; }
          public bool IsValid { get; protected set; }

     }
}
