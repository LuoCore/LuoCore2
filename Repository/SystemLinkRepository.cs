using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using DataTransferModels;
using DataTransferModels.SystemLink.Request;
using DataTransferModels.SystemLink.Response;
using EntitysModels;

namespace Repository
{
     public class SystemLinkRepository : SqlSugarRepository<ISystemLogsRepository>, ISystemLinkRepository
     {
          public SystemLinkRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
          {

          }

          public ResultDto<ResponsePageDto> ReadPage(RequestReadPageDto req)
          {
               ResultDto<ResponsePageDto> res = new ResultDto<ResponsePageDto>();
               try
               {


                    _FACTORY.GetDbContext((db) =>
                    {
                         var sqlExecute = db.Queryable<System_Link>();
                         sqlExecute.WhereIF(req != null && req.ID > 0, x => x.ID.Equals(req.ID));
                         sqlExecute.WhereIF(req != null && req.IsValid != null, x => x.IsValid.Equals(req.IsValid));
                         sqlExecute.WhereIF(req != null && !string.IsNullOrWhiteSpace(req.LinkName), x => x.LinkName.Contains(x.LinkName));
                         int pagecount = 0;
                         var sqlResult = sqlExecute.ToPageList(req.PageIndex, req.PageSize, ref pagecount);
                         res.Data = new ResponsePageDto(sqlResult, pagecount);
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

          public ResultDto<ResponseLinksDto> ReadList(RequestReadLinkDto req)
          {
               ResultDto<ResponseLinksDto> res = new ResultDto<ResponseLinksDto>();
               try
               {


                    _FACTORY.GetDbContext((db) =>
                    {
                         var sqlExecute = db.Queryable<System_Link>().Where(x=>x.IsValid==true);
                         sqlExecute.WhereIF(req != null && req.ID > 0, x => x.ID.Equals(req.ID));
                         sqlExecute.WhereIF(req != null && !string.IsNullOrWhiteSpace(req.LinkName), x => x.LinkName.Contains(x.LinkName));

                         res.Data = new ResponseLinksDto(sqlExecute.ToList());
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

          public ResultDto Create(RequestCreateDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var insetData = new
                         {
                              LinkName = req.LinkName,
                              LinkUrl = req.LinkUrl,
                              LinkIco = req.LinkIco,
                              IsValid = req.IsValid
                         };
                         db.Insertable<System_Link>(insetData).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Link>(EnumHelper.CURDEnum.创建).NowData(insetData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
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


          public ResultDto Update(RequestUpdateDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var oldData = db.Queryable<System_Link>().Where(x => x.ID == req.ID).First();
                         var nowData = new
                         {
                              LinkName = req.LinkName,
                              LinkUrl = req.LinkUrl,
                              LinkIco = req.LinkIco,
                              IsValid = req.IsValid
                         };
                         db.Updateable<System_Link>(nowData).Where(x => x.ID == req.ID).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Link>(EnumHelper.CURDEnum.更新).NowData(nowData).OldData(oldData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
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

          public ResultDto Delete(RequestDeleteDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var oldData = db.Queryable<System_Link>().Where(x => x.ID == req.ID).First();
                         var nowData = new
                         {
                             
                              IsValid = false
                         };
                         db.Updateable<System_Link>(nowData).Where(x => x.ID == req.ID).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Link>(EnumHelper.CURDEnum.删除).NowData(nowData).OldData(oldData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
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
