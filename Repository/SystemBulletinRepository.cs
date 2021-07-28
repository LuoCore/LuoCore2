using DataTransferModels;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using DataTransferModels.SystemBulletin.Request;
using DataTransferModels.SystemBulletin.Response;
using EntitysModels;

namespace Repository
{
     public class SystemBulletinRepository : Utility.Repository.SqlSugarRepository<ISystemLogsRepository>, ISystemBulletinRepository
     {
          public SystemBulletinRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
          {
          }



          public ResultDto<ResponsePageBulletinDto> ReadBulletinPage(RequestReadPageBulletinDto req)
          {
               ResultDto<ResponsePageBulletinDto> res = new ResultDto<ResponsePageBulletinDto>();
               try
               {


                    _FACTORY.GetDbContext((db) =>
                    {
                         var sqlExecute = db.Queryable<System_Bulletin>();
                         sqlExecute.WhereIF(req != null && req.ID > 0, x => x.ID.Equals(req.ID));
                         sqlExecute.WhereIF(req != null && req.IsValid != null, x => x.IsValid.Equals(req.IsValid));
                         sqlExecute.WhereIF(req != null && !string.IsNullOrWhiteSpace(req.BulletinName), x => x.BulletinName.Contains(x.BulletinName));
                         int pagecount = 0;
                         var sqlResult = sqlExecute.ToPageList(req.PageIndex, req.PageSize, ref pagecount);
                         res.Data = new ResponsePageBulletinDto(sqlResult, pagecount);
                         res.Status = true;
                    });
               }
               catch (Exception ex)
               {

                    res.Status = false;
                    res.Messages = ex.Message;
               }
               return res;

          }

        public ResultListDto<EntitysModels.System_Bulletin> ReadBulletinList(RequestReadBulletinDto req)
        {
            ResultListDto<EntitysModels.System_Bulletin> res = new ResultListDto<EntitysModels.System_Bulletin>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    var sqlExecute = db.Queryable<System_Bulletin>();
                    sqlExecute.WhereIF(req != null && req.ID > 0, x => x.ID.Equals(req.ID));
                    sqlExecute.WhereIF(req != null && req.IsValid != null, x => x.IsValid.Equals(req.IsValid));
                    sqlExecute.WhereIF(req != null && !string.IsNullOrWhiteSpace(req.BulletinName), x => x.BulletinName.Contains(x.BulletinName));
                    res.Datas = new List<System_Bulletin>();
                    res.Datas = sqlExecute.ToList();
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Messages = ex.Message;
            }
            return res;

        }

        public ResultDto CreateBulletin(RequestCreateBulletinDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var insetData = new
                         {
                              BulletinName = req.BulletinName,
                              BulletinConten = req.BulletinConten,
                              IsValid = req.IsValid
                         };
                         db.Insertable<System_Bulletin>(insetData).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Bulletin>(EnumHelper.CURDEnum.创建).NowData(insetData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
                         res.Status = true;
                    });
               }
               catch (Exception ex)
               {

                    res.Status = false;
                    res.Messages = ex.Message;
               }
               return res;

          }


          public ResultDto UpdateBulletin(RequestUpdateBulletinDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var oldData = db.Queryable<System_Bulletin>().Where(x => x.ID == req.ID).First();
                         var nowData = new
                         {
                             BulletinName = req.BulletinName,
                             BulletinConten = req.BulletinConten,
                              IsValid = req.IsValid
                         };
                         db.Updateable<System_Bulletin>(nowData).Where(x => x.ID == req.ID).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Bulletin>(EnumHelper.CURDEnum.更新).NowData(nowData).OldData(oldData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
                         res.Status = true;
                    });
               }
               catch (Exception ex)
               {

                    res.Status = false;
                    res.Messages = ex.Message;
               }
               return res;

          }

          public ResultDto DeleteBulletin(RequestDeleteBulletinDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var oldData = db.Queryable<System_Bulletin>().Where(x => x.ID == req.ID).First();
                         var nowData = new
                         {

                              IsValid = false
                         };
                         db.Updateable<System_Bulletin>(nowData).Where(x => x.ID == req.ID).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Bulletin>(EnumHelper.CURDEnum.删除).NowData(nowData).OldData(oldData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
                         res.Status = true;
                    });
               }
               catch (Exception ex)
               {

                    res.Status = false;
                    res.Messages = ex.Message;
               }
               return res;

          }
     }
}
