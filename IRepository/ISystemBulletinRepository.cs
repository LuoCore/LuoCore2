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
          public ResultDto<ResponsePageBulletinDto> ReadBulletinPage(RequestReadPageBulletinDto req);
        public ResultListDto<EntitysModels.System_Bulletin> ReadBulletinList(RequestReadBulletinDto req);

          public ResultDto CreateBulletin(RequestCreateBulletinDto req);


          public ResultDto UpdateBulletin(RequestUpdateBulletinDto req);

          public ResultDto DeleteBulletin(RequestDeleteBulletinDto req);
     }
}
