using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Request
{
     public class RequestReadPageBulletinDto
     {
          public RequestReadPageBulletinDto(int iD, string bulletinName, bool? isValid, int pageIndex, int pageSize)
          {
               ID = iD;
               BulletinName = bulletinName;
               IsValid = isValid;
               PageIndex = pageIndex;
               PageSize = pageSize;
          }

          public int ID { get;protected set; }
          public string BulletinName { get; protected set; }
          public bool? IsValid { get; protected set; }
          public int PageIndex { get; protected set; }
          public int PageSize { get; protected set; }
     }
}
