using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestCreateDto:RequestBaseDto
     {
          public RequestCreateDto(string bulletinName, string bulletinConten,bool isValid, string actionUserName, string actionUserInfo)
          {
              
               IsValid = isValid;
               this.ActionUserInfo = actionUserInfo;
               this.ActionUserName = actionUserName;
               BulletinName = bulletinName;
               BulletinConten = bulletinConten;
          }

          public string BulletinName { get;protected set; }
          public string BulletinConten { get; protected set; }
          public bool IsValid { get; protected set; }
     }
}
