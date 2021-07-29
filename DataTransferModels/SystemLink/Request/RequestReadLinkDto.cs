using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestReadLinkDto
     {
          public RequestReadLinkDto(int linkID, string linkName)
          {
            LinkID = linkID;
               LinkName = linkName;
          }

          public int LinkID { get;protected set; }
          public string LinkName { get; protected set; }
     }
}
