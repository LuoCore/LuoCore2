using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Admin.Controllers
{
     public class SystemBasisController : BaseAuthorizeController<IServices.ISystemBasisService>
     {
          public SystemBasisController(ISystemBasisService service) : base(service)
          {
          }

          public IActionResult SystemLink()
          {
               return View();
          }

          public IActionResult SystemLinkDialog()
          {
               return View();
          }

          public async Task<IActionResult> GetLinkPageAsync(ViewModels.SystemBasis.Request.RequestLinkQueryPageVm req)
          {
               var res = await _SERVICE.QueryLinkPage(req);
               return Json(res);
          }
     }
}
