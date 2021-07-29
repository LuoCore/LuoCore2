using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using DataTransferModels;
using EntitysModels;

namespace Repository
{
     public class SystemLanguageRepository : SqlSugarRepository<ISystemLogsRepository>, ISystemLanguageRepository
     {
          public SystemLanguageRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
          {

          }

          public ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguagePageDto> ReadLanguagePage(DataTransferModels.SystemLanguage.Request.RequestReadPageLanguageDto req)
          {
               ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguagePageDto> res = new ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguagePageDto>();
               try
               {


                    _FACTORY.GetDbContext((db) =>
                    {
                         var sqlExecute = db.Queryable<System_Language>();
                         sqlExecute.WhereIF(req != null && req.LanguageID > 0, x => x.LanguageID.Equals(req.LanguageID));
                         sqlExecute.WhereIF(req != null && req.IsValid != null, x => x.IsValid.Equals(req.IsValid));
                         sqlExecute.WhereIF(req != null && !string.IsNullOrWhiteSpace(req.LanguageName), x => x.LanguageName.Contains(x.LanguageName));
                         int pagecount = 0;
                         var sqlResult = sqlExecute.ToPageList(req.PageIndex, req.PageSize, ref pagecount);
                         res.Data = new DataTransferModels.SystemLanguage.Response.ResponseLanguagePageDto(sqlResult, pagecount);
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

        public ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguageDto> ReadLanguageList(DataTransferModels.SystemLanguage.Request.RequestReadLanguageDto req)
        {
            ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguageDto> res = new ResultDto<DataTransferModels.SystemLanguage.Response.ResponseLanguageDto>();
            try
            {


                _FACTORY.GetDbContext((db) =>
                {
                    var sqlExecute = db.Queryable<System_Language>();
                    sqlExecute.WhereIF(req != null && req.LanguageID > 0, x => x.LanguageID.Equals(req.LanguageID));
                    sqlExecute.WhereIF(req != null && req.IsValid != null, x => x.IsValid.Equals(req.IsValid));
                    sqlExecute.WhereIF(req != null && !string.IsNullOrWhiteSpace(req.LanguageName), x => x.LanguageName.Contains(x.LanguageName));

                    res.Data = new DataTransferModels.SystemLanguage.Response.ResponseLanguageDto(sqlExecute.ToList());
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


        public ResultDto Create(DataTransferModels.SystemLanguage.Request.RequestCreateLanguageDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var insetData = new
                         {
                              LanguageName = req.LanguageName,
                              LanguageJson = req.LanguageJson,
                              IsValid = req.IsValid
                         };
                         db.Insertable<System_Language>(insetData).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Language>(EnumHelper.CURDEnum.创建).NowData(insetData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
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


          public ResultDto Update(DataTransferModels.SystemLanguage.Request.RequestUpdateLanguageDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var oldData = db.Queryable<System_Language>().Where(x => x.LanguageID == req.LanguageID).First();
                         var nowData = new
                         {
                              LanguageName = req.LanguageName,
                              LanguageJson = req.LanguageJson,
                              IsValid = req.IsValid
                         };
                         db.Updateable<System_Language>(nowData).Where(x => x.LanguageID == req.LanguageID).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Language>(EnumHelper.CURDEnum.更新).NowData(nowData).OldData(oldData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
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

          public ResultDto Delete(DataTransferModels.SystemLanguage.Request.RequestDeleteLanguageDto req)
          {
               ResultDto res = new ResultDto();
               try
               {
                    _FACTORY.GetDbContextTran((db) =>
                    {
                         var oldData = db.Queryable<System_Language>().Where(x => x.LanguageID == req.LanguageID).First();
                         var nowData = new
                         {
                             
                              IsValid = false
                         };
                         db.Updateable<System_Language>(nowData).Where(x => x.LanguageID == req.LanguageID).ExecuteCommand();

                         _REPOSITORY.SqlTypeCurd<System_Language>(EnumHelper.CURDEnum.删除).NowData(nowData).OldData(oldData).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).BuilderSQL(db);
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
