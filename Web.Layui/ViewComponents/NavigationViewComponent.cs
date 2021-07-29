using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IServices.IWebSiteService _WebSiteService;
        /// <summary>
        ///  如果需要构造函数的话，你就创建 构造函数
        /// </summary>
        public NavigationViewComponent(IServices.IWebSiteService webSiteService)
        {
            _WebSiteService = webSiteService;
        }
        /// <summary>
        /// 异步调用
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
          var result= await _WebSiteService.MenuQueryList(new ViewModels.WebSite.Request.RequestMenuQueryVm()
            {
                IsValid = true
            });
            return View(result);
        }
    }
}
