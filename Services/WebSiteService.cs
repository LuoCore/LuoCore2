using Common;
using EntitysModels;
using IRepository;
using IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using ViewModels;
using ViewModels.WebSite.Request;
namespace Services
{
    public class WebSiteService : SqlSugarRepository<ISystemLogsRepository, IWebSiteMenuRepository>, IWebSiteService
    {
        public WebSiteService(ISqlSugarFactory factory, ISystemLogsRepository repository, IWebSiteMenuRepository repository2) : base(factory, repository, repository2)
        {
        }

        public Task<ViewModels.Layui.TableVm> MenuQueryTreeTable(RequestMenuQueryVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();


            var result = _REPOSITORY2.ReadWebSiteMenuList(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadDto(req.MenuID,req.MenuName,req.MenuPid,req.IsValid));
            if (!result.Status || Equals(null, result.Datas))
            {
                res.code = -1;
                res.msg = "无数据！";
                return Task.FromResult(res);
            }
            var resultParend = _REPOSITORY2.ReadWebSiteMenuList(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadDto(0, "",null, true));

            List<ViewModels.WebSite.Response.ResponseMenuTreeTableVm> resData = new List<ViewModels.WebSite.Response.ResponseMenuTreeTableVm>();
            foreach (var m in result.Datas)
            {
                var vmData = new ViewModels.WebSite.Response.ResponseMenuTreeTableVm()
                {
                    MenuID = m.MenuID,
                    MenuName = m.MenuName,
                    MenuPid = m.MenuPid,
                    MenuUrl = m.MenuUrl,
                    IsValid = m.IsValid
                };
              

                if (resultParend != null && resultParend.Datas != null && resultParend.Datas.Count > 0) 
                {
                   var pidName= resultParend.Datas.Where(x => x.MenuID == vmData.MenuPid);
                    if (pidName != null && pidName.FirstOrDefault() != null) 
                    {
                        vmData.MenuParendName = pidName.FirstOrDefault().MenuName;
                    }   
                }
                resData.Add(vmData);

            }
            res.code = 0;
            res.data = resData;
            res.count = resData.Count;
            return Task.FromResult(res);
        }

        public Task<ViewModels.Layui.TableVm> MenuQueryPage(RequestMenuQueryPageVm req) 
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
          var result=  _REPOSITORY2.ReadWebSiteMenuPage(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadPageDto(req.MenuID, req.MenuName, req.MenuPid, req.IsValid, req.PageIndex, req.PageSize));
            if (result != null && result.Status) 
            {
                res.code = 0;
                res.data = result.Datas;
                res.count = result.DatasCount;
            }
            else
            {
                res.code = -1;
                res.msg = result.Messages;
            }
            return Task.FromResult(res);
        }

        public Task<ResultListVm<WebSite_Menu>> MenuQueryList(RequestMenuQueryVm req)
        {
            ResultListVm<WebSite_Menu> res = new ResultListVm<WebSite_Menu>();
            var result = _REPOSITORY2.ReadWebSiteMenuList(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadDto(req.MenuID,req.MenuName,req.MenuPid,req.IsValid));
            res.Status = result.Status;
            res.Messages = result.Messages;
            res.Datas = result.Datas;
            return Task.FromResult(res);
        }


        public async Task<ResultVm<List<ViewModels.Layui.SelectBoxVm>>> MenuQuerySelectBoxAsync(int parentId)
        {
            ResultVm<List<ViewModels.Layui.SelectBoxVm>> resSelects = new ResultVm<List<ViewModels.Layui.SelectBoxVm>>();

            var result = _REPOSITORY2.ReadWebSiteMenuList(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuReadDto(0,null, parentId, null));
            if (!result.Status || Equals(null, result.Datas))
            {
                return resSelects;
            }
            resSelects.Data = new List<ViewModels.Layui.SelectBoxVm>();
            foreach (var item in result.Datas)
            {
                var resData = new ViewModels.Layui.SelectBoxVm()
                {
                    disabled = !item.IsValid,
                    Name = item.MenuName,
                    value = item.MenuID.ObjToString()
                };
                var resultChildren = await MenuQuerySelectBoxAsync(item.MenuID);
                if (resultChildren.Status && !Equals(null, resultChildren.Data))
                {
                    resData.children = resultChildren.Data;
                }

                resSelects.Data.Add(resData);
            }
            resSelects.Status = true;
            return resSelects;
        }

        public Task<ResultVm> MenuCreate(RequestMenuCreateVm req) 
        {
            ResultVm res = new ResultVm();
          var result=  _REPOSITORY2.CreateWebSiteMenu(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuCreateDto(req.MenuName, req.MenuUrl, req.MenuPid, req.IsValid, req.ActionUserName, req.ActionUserInfo));
            res.Status = result.Status;
            res.Messages = result.Messages;
            return Task.FromResult(res);
        }

        public Task<ResultVm> MenuUpdate(RequestMenuUpdateVm req)
        {
            ResultVm res = new ResultVm();
            var result = _REPOSITORY2.UpdateWebSiteMenu(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuUpdateDto(req.MenuID,req.MenuName,req.MenuUrl,req.MenuPid,req.IsValid,req.ActionUserName,req.ActionUserInfo));
            res.Status = result.Status;
            res.Messages = result.Messages;
            return Task.FromResult(res);
        }
        public Task<ResultVm> MenuDelete(RequestMenuDeleteVm req)
        {
            ResultVm res = new ResultVm();
            int executeIndex = 0;
            foreach (var mid in req.MenuIDs)
            {
                var result = _REPOSITORY2.DeleteWebSiteMenu(new DataTransferModels.WebSiteMenu.Request.RequestWebSiteMenuDeleteDto(mid, req.ActionUserName, req.ActionUserInfo));
                if (result != null && result.Status) 
                {
                    executeIndex +=1;
                }
            }
            res.Status = true;
            res.Messages = "成功删除："+executeIndex+"条!";
            return Task.FromResult(res);
        }
    }
}
