using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestCreateBulletinDto:RequestBaseDto
     {
   

        public RequestCreateBulletinDto(string bulletinName, string bulletinConten,bool isValid, string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
              
               IsValid = isValid;
               BulletinName = bulletinName;
               BulletinConten = bulletinConten;
          }

          public string BulletinName { get;protected set; }
          public string BulletinConten { get; protected set; }
          public bool IsValid { get; protected set; }
     }
}
