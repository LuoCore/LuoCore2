using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestReadBulletinDto
    {
          public RequestReadBulletinDto(int iD, string bulletinName, bool? isValid)
          {
               ID = iD;
               BulletinName = bulletinName;
               IsValid = isValid;
          }

          public int ID { get;protected set; }
          public string BulletinName { get; protected set; }
          public bool? IsValid { get; protected set; }
     }
}
