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
using EntitysModels;
using ViewModels.WebSite.Request;

namespace Services
{
    public class WebSiteService : SqlSugarRepository<ISystemLogsRepository, IWebSiteMenuRepository>, IWebSiteService
    {
        public WebSiteService(ISqlSugarFactory factory, ISystemLogsRepository repository, IWebSiteMenuRepository repository2) : base(factory, repository, repository2)
        {
        }

        public ResultListVm<WebSite_Menu> MenuQueryPage(RequestMuneQueryPageVm req) 
        {
            ResultListVm<WebSite_Menu> res = new ResultListVm<WebSite_Menu>();
          var result=  _REPOSITORY2.ReadWebSiteMenuPage(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadPageDto(req.MenuID, req.MenuName, req.MenuPid, req.IsValid, req.PageIndex, req.PageSize));
            res.Status = result.Status;
            res.Messages = result.Messages;
            res.Datas = result.Datas;
            return res;
        }

        public ResultListVm<WebSite_Menu> MenuQueryList(RequestMuneQueryVm req)
        {
            ResultListVm<WebSite_Menu> res = new ResultListVm<WebSite_Menu>();
            var result = _REPOSITORY2.ReadWebSiteMenuList(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadDto(req.MenuID,req.MenuName,req.MenuPid,req.IsValid));
            res.Status = result.Status;
            res.Messages = result.Messages;
            res.Datas = result.Datas;
            return res;
        }

        public ResultVm MenuCreate(RequestMenuCreateVm req) 
        {
            ResultVm res = new ResultVm();
          var result=  _REPOSITORY2.CreateWebSiteMenu(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuCreateDto(req.MenuName, req.MenuUrl, req.MenuPid, req.IsValid, req.ActionUserName, req.ActionUserInfo));
            res.Status = res.Status;
            res.Messages = res.Messages;
            return res;
        }

        public ResultVm MenuUpdate(RequestMenuUpdateVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY2.UpdateWebSiteMenu(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuUpdateDto(req.MenuID,req.MenuName,req.MenuUrl,req.MenuPid,req.IsValid,req.ActionUserName,req.ActionUserInfo));
            res.Status = res.Status;
            res.Messages = res.Messages;
            return res;
        }
        public ResultVm MenuDelete(RequestMenuDeleteVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY2.DeleteWebSiteMenu(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuDeleteDto(req.MenuID,req.ActionUserName,req.ActionUserInfo));
            res.Status = res.Status;
            res.Messages = res.Messages;
            return res;
        }
    }
}
