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

namespace Services
{
     public class SystemBasisService : SqlSugarRepository<ISystemLogsRepository, ISystemLinkRepository, ISystemBulletinRepository>, ISystemBasisService

     {
          public SystemBasisService(ISqlSugarFactory factory, ISystemLogsRepository repository, ISystemLinkRepository repository2, ISystemBulletinRepository repository3) : base(factory, repository, repository2, repository3)
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


          public ResultVm CreateLink(RequestLinkCreateVm req) 
          {
               ResultVm res = new ResultVm();
             var result=  _REPOSITORY2.Create(new DataTransferModels.SystemLink.Request.RequestCreateDto(req.LinkName, req.LinkUrl, req.LinkIco, req.IsValid, req.ActionUserName, req.ActionUserInfo));
               res.Status = result.Status;
               res.Messages = result.Messages;
               return res;
          }
          public ResultVm UpdateLink(RequestLinkUpdateVm req)
          {
               ResultVm res = new ResultVm();
               var result = _REPOSITORY2.Update(new DataTransferModels.SystemLink.Request.RequestUpdateDto(req.ID,req.LinkName, req.LinkUrl, req.LinkIco, req.IsValid, req.ActionUserName, req.ActionUserInfo));
               res.Status = result.Status;
               res.Messages = result.Messages;
               return res;
          }
          public ResultVm DeleteLink(RequestLinkDeleteVm req)
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
               return res;
          }
     }
}
