using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Response
{
     public class ResponseLinksDto
     {
          public ResponseLinksDto(List<System_Link> links)
          {
               Links = links;
          }

          public List<System_Link> Links { get; protected set; }
     }
}
