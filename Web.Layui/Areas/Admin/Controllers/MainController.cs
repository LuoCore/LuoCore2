using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices;
using ViewModels;
using ViewModels.SystemBasis.Request;

namespace Web.Layui.Areas.Admin.Controllers
{
    [Authorize]
    public class MainController : BaseController<ICreateEntityService>
    {
        public MainController(ICreateEntityService service) : base(service)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome() 
        {
            return View();
        }

      

        public async Task<IActionResult> CreateEntityDefaultValueAsync(RequestCreateEntityVm req)
        {
            ResultVm res = new ResultVm();
            res.Status=await _SERVICE.CreateDefaultValue(req);
            return Json(res);
        }

        public async Task<IActionResult> CreateEntityAttributeAsync(RequestCreateEntityVm req)
        {
            ResultVm res = new ResultVm();
            res.Status = await _SERVICE.CreateDefaultValue(req);
            return Json(res);
        }

    }
}
