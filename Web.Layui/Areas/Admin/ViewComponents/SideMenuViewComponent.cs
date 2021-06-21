using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common;

namespace Web.Layui.Areas.Admin.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        /// <summary>
        ///  如果需要构造函数的话，你就创建 构造函数
        /// </summary>
        public SideMenuViewComponent()
        {

        }
        /// <summary>
        /// 异步调用
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AuthenticateResult authInfo = await HttpContext.AuthenticateAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            string roleJson = authInfo.Principal.FindFirstValue(ClaimTypes.Role);
            List<EntitysModels.Base_Permission> permissionModel= new List<EntitysModels.Base_Permission>();
            permissionModel = roleJson.ToObject<List<EntitysModels.Base_Permission>>();
            return View(permissionModel);
        }
    }
}
