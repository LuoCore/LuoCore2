using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Repository;
using IServices;
using Utility.Factory;
using ViewModels;
using ViewModels.SystemBasis.Request;
using ViewModels.SystemBasis.Response;
using Common;

namespace Services
{
     public class SystemBasisService : SqlSugarRepository<ISystemLogsRepository, ISystemLinkRepository, ISystemBulletinRepository,ISystemLanguageRepository>, ISystemBasisService

     {
          public SystemBasisService(ISqlSugarFactory factory, ISystemLogsRepository repository, ISystemLinkRepository repository2, ISystemBulletinRepository repository3, ISystemLanguageRepository repository4) : base(factory, repository, repository2, repository3, repository4)
          {
          }

          public Task<ViewModels.Layui.TableVm>  QueryLinkPage(RequestLinkQueryPageVm req)
          {
               ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
              var result= _REPOSITORY2.ReadPage(new DataTransferModels.SystemLink.Request.RequestReadPageDto(req.ID, req.LinkName, req.IsValid, req.PageIndex, req.PageSize));

               if (result != null)
               {
                    res.code = result.Status ? 0 : -1;
                    res.msg = result.Messages;
                    if (result.Data != null) 
                    {
                         res.data = result.Data.PageDatas;
                         res.count = result.Data.PageCount;
                    }
                   
               }
               else 
               {
                    res.code = -1;
                    res.msg = "无数据！";
               }
              
               return Task.FromResult(res);
          }
          public Task<ResultListVm<EntitysModels.System_Link>> QueryLinks(RequestQueryLinkVm req)
          {
               ResultListVm<EntitysModels.System_Link> res = new ResultListVm<EntitysModels.System_Link>();
               var result = _REPOSITORY2.ReadList(new DataTransferModels.SystemLink.Request.RequestReadLinkDto(req.ID,req.LinkName));

               if (result != null)
               {
                    res.Status = result.Status;
                    res.Messages = result.Messages;
                    if (result.Data != null)
                    {
                         res.Datas = new List<EntitysModels.System_Link>();
                         res.Datas = result.Data.Links;
                    }

               }
               else
               {
                    res.Status = false;
                    res.Messages = "无数据";
               }

               return Task.FromResult(res);
          }

          public Task<ResultVm> CreateLink(RequestLinkCreateVm req) 
          {
               ResultVm res = new ResultVm();
             var result=  _REPOSITORY2.Create(new DataTransferModels.SystemLink.Request.RequestCreateDto(req.LinkName, req.LinkUrl, req.LinkIco, req.IsValid, req.ActionUserName, req.ActionUserInfo));
               res.Status = result.Status;
               res.Messages = result.Messages;
               return Task.FromResult(res);
          }
          public Task<ResultVm> UpdateLink(RequestLinkUpdateVm req)
          {
               ResultVm res = new ResultVm();
               var result = _REPOSITORY2.Update(new DataTransferModels.SystemLink.Request.RequestUpdateDto(req.ID,req.LinkName, req.LinkUrl, req.LinkIco, req.IsValid, req.ActionUserName, req.ActionUserInfo));
               res.Status = result.Status;
               res.Messages = result.Messages;
               return Task.FromResult(res);
          }
          public Task<ResultVm> DeleteLink(RequestLinkDeleteVm req)
          {
               ResultVm res = new ResultVm();
               int executeCount = 0;
               if (req != null && req.IDs.Length > 0) 
               {
                    foreach (int linkId in req.IDs)
                    {
                         var result = _REPOSITORY2.Delete(new DataTransferModels.SystemLink.Request.RequestDeleteDto(linkId, req.ActionUserName, req.ActionUserInfo));
                         if (result.Status)
                         {
                              executeCount += 1;
                         }
                    }
               }
               res.Status = true;
               res.Messages ="成功删除："+executeCount+",条记录！";
               return Task.FromResult(res);
          }

          public Task<ViewModels.Layui.TableVm> QueryLanguagePage(RequestLanguageQueryPageVm req)
          {
               ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
               var result = _REPOSITORY4.ReadLanguagePage(new DataTransferModels.SystemLanguage.Request.RequestReadPageLanguageDto(req.ID,req.LanguageName,req.LanguageJson,req.IsValid,req.PageIndex,req.PageSize));

               if (result != null)
               {
                    res.code = result.Status ? 0 : -1;
                    res.msg = result.Messages;
                    if (result.Data != null)
                    {
                         res.data = result.Data.PageDatas;
                         res.count = result.Data.PageCount;
                    }

               }
               else
               {
                    res.code = -1;
                    res.msg = "无数据！";
               }

               return Task.FromResult(res);
          }


        public Task<ResultListVm<EntitysModels.System_Language>> QueryLanguageList(RequestLanguageQueryVm req)
        {
            ResultListVm<EntitysModels.System_Language> res = new ResultListVm<EntitysModels.System_Language>();

            var result = _REPOSITORY4.ReadLanguageList(new DataTransferModels.SystemLanguage.Request.RequestReadLanguageDto(req.ID,req.LanguageName,req.LanguageJson,req.IsValid));

            res.Status = result.Status;
            res.Messages = result.Messages;
            if (result != null&& result.Data != null && result.Data.PageDatas != null)
            {
                res.Datas = result.Data.PageDatas;
            }
            

            return Task.FromResult(res);
        }
        public Task<ResultVm> CreateLanguage(RequestLanguageCreateVm req)
          {
               ResultVm res = new ResultVm();
               var result = _REPOSITORY4.Create(new DataTransferModels.SystemLanguage.Request.RequestCreateLanguageDto(req.LanguageName,req.LanguageValue.ToJson(),req.IsValid,req.ActionUserInfo,req.ActionUserName));
               res.Status = result.Status;
               res.Messages = result.Messages;
               return Task.FromResult(res);
          }
          public Task<ResultVm> UpdateLanguage(RequestLanguageUpdateVm req)
          {
               ResultVm res = new ResultVm();
               var result = _REPOSITORY4.Update(new DataTransferModels.SystemLanguage.Request.RequestUpdateLanguageDto(req.ID,req.LanguageName,req.LanguageValue.ToJson(),req.IsValid,req.ActionUserInfo,req.LanguageName));
               res.Status = result.Status;
               res.Messages = result.Messages;
               return Task.FromResult(res);
          }
          public Task<ResultVm> DeleteLanguage(RequestLanguageDeleteVm req)
          {
               ResultVm res = new ResultVm();
               int executeCount = 0;
               if (req != null && req.IDs.Length > 0)
               {
                    foreach (int id in req.IDs)
                    {
                         var result = _REPOSITORY4.Delete(new DataTransferModels.SystemLanguage.Request.RequestDeleteLanguageDto(id,req.ActionUserName,req.ActionUserInfo));
                         if (result.Status)
                         {
                              executeCount += 1;
                         }
                    }
               }
               res.Status = true;
               res.Messages = "成功删除：" + executeCount + ",条记录！";
               return Task.FromResult(res);
          }


        public Task<ViewModels.Layui.TableVm> QueryBulletinPage(RequestBulletinQueryPageVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            var result = _REPOSITORY3.ReadBulletinPage(new DataTransferModels.SystemBulletin.Request.RequestReadPageBulletinDto(req.ID,req.BulletinName,req.IsValid,req.PageIndex,req.PageSize));

            if (result != null)
            {
                res.code = result.Status ? 0 : -1;
                res.msg = result.Messages;
                if (result.Data != null)
                {
                    res.data = result.Data.PageDatas;
                    res.count = result.Data.PageCount;
                }

            }
            else
            {
                res.code = -1;
                res.msg = "无数据！";
            }

            return Task.FromResult(res);
        }

        public Task<ResultListVm<EntitysModels.System_Bulletin>> QueryBulletinList(RequestBulletinQueryVm req)
        {
            ResultListVm<EntitysModels.System_Bulletin> res = new ResultListVm<EntitysModels.System_Bulletin>();
            var result = _REPOSITORY3.ReadBulletinList(new DataTransferModels.SystemBulletin.Request.RequestReadBulletinDto(req.ID,req.BulletinName,req.IsValid));

            if (result != null)
            {
                res.Status = true;
                res.Datas = result.Datas;

            }
            else
            {
                res.Status =false;
                res.Messages = "无数据！";
            }

            return Task.FromResult(res);
        }
        public Task<ResultVm> CreateBulletin(RequestBulletinCreateVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY3.CreateBulletin(new DataTransferModels.SystemBulletin.Request.RequestCreateBulletinDto(req.BulletinName,req.BulletinConten,req.IsValid,req.ActionUserName,req.ActionUserInfo));
            res.Status = result.Status;
            res.Messages = result.Messages;
            return Task.FromResult(res);
        }
        public Task<ResultVm> UpdateBulletin(RequestBulletinUpdateVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY3.UpdateBulletin(new DataTransferModels.SystemBulletin.Request.RequestUpdateBulletinDto(req.ID, req.BulletinName, req.BulletinConten, req.IsValid, req.ActionUserName, req.ActionUserInfo));
            res.Status = result.Status;
            res.Messages = result.Messages;
            return Task.FromResult(res);
        }
        public Task<ResultVm> DeleteBulletin(RequestBulletinDeleteVm req)
        {
            ResultVm res = new ResultVm();
            int executeCount = 0;
            if (req != null && req.IDs.Length > 0)
            {
                foreach (int id in req.IDs)
                {
                    var result = _REPOSITORY3.DeleteBulletin(new DataTransferModels.SystemBulletin.Request.RequestDeleteBulletinDto(id,req.ActionUserName,req.ActionUserInfo));
                    if (result.Status)
                    {
                        executeCount += 1;
                    }
                }
            }
            res.Status = true;
            res.Messages = "成功删除：" + executeCount + ",条记录！";
            return Task.FromResult(res);
        }
    }
}
