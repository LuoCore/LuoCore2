using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class WebSiteController : BaseAuthorizeController<IWebSiteService>
    {
       
        public WebSiteController(IWebSiteService service) : base(service)
        {

        }

       

        public IActionResult MenuIndex()
        {
            return View();
        }

        public IActionResult MenuDialog()
        {
            return View();
        }
        public async Task<IActionResult> MenuGetTreeTableAsync(ViewModels.WebSite.Request.RequestMenuQueryPageVm req)
        {
           var res=await _SERVICE.MenuQueryTreeTable(req);
            return Json(res);
        }

        

        public async Task<IActionResult> MenuGetSelectBoxAsync(int parentID)
        {
            List<ViewModels.Layui.SelectBoxVm> res = new List<ViewModels.Layui.SelectBoxVm>();
            ViewModels.Layui.SelectBoxVm selectbox = new ViewModels.Layui.SelectBoxVm() { Name = "顶级", value = "0" };
            var result = await _SERVICE.MenuQuerySelectBoxAsync(selectbox.value.ObjToInt());
            if (result.Status && !Equals(null, result.Data))
            {
                selectbox.children = result.Data;
            }
            res.Add(selectbox);
            return Json(res);
           
        }
        public async Task<IActionResult> MenuCreateAsync(ViewModels.WebSite.Request.RequestMenuCreateVm req)
        {
            req.ActionUserName = this._ACTIONUSERNAME;
            req.ActionUserInfo = this._ACTIONUSERINFO;
            var res = await _SERVICE.MenuCreate(req);
            return Json(res);
        }

        public async Task<IActionResult> MenuUpdateAsync(ViewModels.WebSite.Request.RequestMenuUpdateVm req)
        {
            req.ActionUserName = this._ACTIONUSERNAME;
            req.ActionUserInfo = this._ACTIONUSERINFO;
            var res = await _SERVICE.MenuUpdate(req);
            return Json(res);
        }

        public async Task<IActionResult> MenuDeleteAsync(ViewModels.WebSite.Request.RequestMenuDeleteVm req)
        {
            req.ActionUserName = this._ACTIONUSERNAME;
            req.ActionUserInfo = this._ACTIONUSERINFO;
            var res = await _SERVICE.MenuDelete(req);
            return Json(res);
        }
    }
}
