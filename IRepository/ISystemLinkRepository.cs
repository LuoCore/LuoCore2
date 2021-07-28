using DataTransferModels;
using DataTransferModels.SystemLink.Request;
using DataTransferModels.SystemLink.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;

namespace IRepository
{
     public interface ISystemLinkRepository : ISqlSugarRepository
     {
          public ResultDto<ResponsePageDto> ReadPage(RequestReadPageDto req);
          public ResultDto<ResponseLinksDto> ReadList(RequestReadLinkDto req);

          public ResultDto Create(RequestCreateDto req);


          public ResultDto Update(RequestUpdateDto req);

          public ResultDto Delete(RequestDeleteDto req);
     }
}
