using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestReadLinkDto
     {
          public RequestReadLinkDto(int iD, string linkName)
          {
               ID = iD;
               LinkName = linkName;
          }

          public int ID { get;protected set; }
          public string LinkName { get; protected set; }
     }
}
