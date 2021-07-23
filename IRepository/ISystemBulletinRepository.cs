using DataTransferModels;
using DataTransferModels.SystemBulletin.Request;
using DataTransferModels.SystemBulletin.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
     public interface ISystemBulletinRepository : Utility.Repository.ISqlSugarRepository
     {
          public ResultDto<ResponsePageDto> ReadPage(RequestReadPageDto req);

          public ResultDto Create(RequestCreateDto req);


          public ResultDto Update(RequestUpdateDto req);

          public ResultDto Delete(RequestDeleteDto req);
     }
}
