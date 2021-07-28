using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.ViewComponents
{
     public class TopBarViewComponent : ViewComponent
     {
          private readonly ISystemBasisService _SystemService;
          /// <summary>
          ///  如果需要构造函数的话，你就创建 构造函数
          /// </summary>
          public TopBarViewComponent(ISystemBasisService service)
          {
               _SystemService = service;
          }
          /// <summary>
          /// 异步调用
          /// </summary>
          /// <returns></returns>
          public async Task<IViewComponentResult> InvokeAsync()
          {
            Models.TopBarViewModel res = new Models.TopBarViewModel();
            res.SystemLink =  await _SystemService.QueryLinks(new ViewModels.SystemBasis.Request.RequestQueryLinkVm());

           res.SystemBulletin = await _SystemService.QueryBulletinList(new ViewModels.SystemBasis.Request.RequestBulletinQueryVm());
            res.SystemLanguage  = await _SystemService.QueryLanguageList(new ViewModels.SystemBasis.Request.RequestLanguageQueryVm());

            return View(res);
          }
     }
}
