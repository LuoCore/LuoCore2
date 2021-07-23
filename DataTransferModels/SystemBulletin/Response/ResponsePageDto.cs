using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemBulletin.Response
{
     public class ResponsePageDto
     {
          public ResponsePageDto(List<System_Bulletin> pageDatas, int pageCount)
          {
               PageDatas = pageDatas;
               PageCount = pageCount;
          }

          public List<System_Bulletin> PageDatas { get; protected set; }
          public int PageCount { get; protected set; }
     }
}
