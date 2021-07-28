using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Factory;
using Utility.Repository;
using DataTransferModels;
using DataTransferModels.WebSiteMenu.Request;

using EntitysModels;

namespace Repository
{
    public class WebSiteMenuRepository : SqlSugarRepository<ISystemLogsRepository>, IWebSiteMenuRepository
    {
        public WebSiteMenuRepository(ISqlSugarFactory factory, ISystemLogsRepository repository) : base(factory, repository)
        {
        }

        public ResultListDto<WebSite_Menu> ReadWebSiteMenuPage(RequestWebSiteMenuReadPageDto req) 
        {
            ResultListDto<WebSite_Menu> res = new ResultListDto<WebSite_Menu>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    var sqlExecute = db.Queryable<WebSite_Menu>();
                    sqlExecute.WhereIF(req.MenuID > 0, x => x.MenuID == req.MenuID);
                    sqlExecute.WhereIF(!string.IsNullOrWhiteSpace(req.MenuName), x => x.MenuName == req.MenuName);
                    sqlExecute.WhereIF(req.MenuPid > 0, x => x.MenuPid == req.MenuPid);
                    sqlExecute.WhereIF(req.IsValid != null, x => x.IsValid == req.IsValid);
                    res.Datas = new List<WebSite_Menu>();
                    int pagecount = 0;
                    res.Datas = sqlExecute.ToPageList(req.PageIndex, req.PageSize, ref pagecount);
                    res.DatasCount = pagecount;
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

        public ResultListDto<WebSite_Menu> ReadWebSiteMenuList(RequestWebSiteMenuReadDto req)
        {
            ResultListDto<WebSite_Menu> res = new ResultListDto<WebSite_Menu>();
            try
            {
                _FACTORY.GetDbContext((db) =>
                {
                    var sqlExecute = db.Queryable<WebSite_Menu>();
                    sqlExecute.WhereIF(req.MenuID > 0, x => x.MenuID == req.MenuID);
                    sqlExecute.WhereIF(!string.IsNullOrWhiteSpace(req.MenuName), x => x.MenuName == req.MenuName);
                    sqlExecute.WhereIF(req.MenuPid > 0, x => x.MenuPid == req.MenuPid);
                    sqlExecute.WhereIF(req.IsValid != null, x => x.IsValid == req.IsValid);
                    res.Datas = new List<WebSite_Menu>();
                    res.Datas = sqlExecute.ToList();
                    res.DatasCount = res.Datas.Count;
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

        public ResultDto CreateWebSiteMenu(RequestWebSiteMenuCreateDto req) 
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var nowData = new
                    {
                        MenuName=req.MenuName,
                        MenuUrl=req.MenuUrl,
                        MenuPid=req.MenuPid,
                        IsValid=req.IsValid
                    };
                    db.Insertable<WebSite_Menu>(nowData).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<WebSite_Menu>(EnumHelper.CURDEnum.创建).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).NowData(nowData).BuilderSQL(db);
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }

        public ResultDto UpdateWebSiteMenu(RequestWebSiteMenuUpdateDto req)
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                  var oldData=  db.Queryable<WebSite_Menu>().Where(x => x.MenuID == req.MenuID).First();
                    var nowData = new
                    {
                        MenuName = req.MenuName,
                        MenuUrl = req.MenuUrl,
                        MenuPid = req.MenuPid,
                        IsValid = req.IsValid
                    };
                    db.Updateable<WebSite_Menu>(nowData).Where(x=>x.MenuID == req.MenuID).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<WebSite_Menu>(EnumHelper.CURDEnum.更新).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).NowData(nowData).OldData(oldData).BuilderSQL(db);
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }

        public ResultDto DeleteWebSiteMenu(RequestWebSiteMenuDeleteDto req) 
        {
            ResultDto res = new ResultDto();
            try
            {
                _FACTORY.GetDbContextTran((db) =>
                {
                    var oldData = db.Queryable<WebSite_Menu>().Where(x => x.MenuID == req.MenuID).First();
                    var nowData = new
                    {
                        IsValid = false
                    };
                    db.Updateable<WebSite_Menu>(nowData).Where(x => x.MenuID == req.MenuID).ExecuteCommand();
                    _REPOSITORY.SqlTypeCurd<WebSite_Menu>(EnumHelper.CURDEnum.删除).OperationUserInfo(req.ActionUserName, req.ActionUserInfo).OldData(oldData).BuilderSQL(db);
                    res.Status = true;
                });
            }
            catch (Exception ex)
            {
                res.Messages = ex.Message;
                res.Status = false;
            }
            return res;
        }

    }
}
