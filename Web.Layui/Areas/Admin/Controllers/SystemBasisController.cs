using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class SystemBasisController : BaseController<ISystemBasisService>
    {
        public SystemBasisController(ISystemBasisService service) : base(service)
        {
        }

        public IActionResult Permission()
        {
            return View();
        }

        public async Task<IActionResult> PermissionSelectBoxAsync()
        {
            List<ViewModels.Layui.SelectBoxVm> res = new List<ViewModels.Layui.SelectBoxVm>();
            ViewModels.Layui.SelectBoxVm selectbox = new ViewModels.Layui.SelectBoxVm() { Name = "顶级", value = "",selected = true };
            var result = await _SERVICE.GetPermissionSelectBoxAsync(selectbox.value);
            if (result.Status && !Equals(null, result.Data))
            {
                selectbox.children = result.Data;
            }
            res.Add(selectbox);
            return Json(res);
        }

        public async Task<IActionResult> PermissionTableAsync(ViewModels.SystemBasis.Request.RequestGetPermissionVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            res = await _SERVICE.GetPermissionTable(req);
            return Json(res);
        }

        public IActionResult PermissionDialog()
        {
            return View();
        }

        public async Task<IActionResult> PermissionCreateAsync(ViewModels.SystemBasis.Request.RequestGetPermissionVm req)
        {
            
            res = await _SERVICE.GetPermissionTable(req);
            return Json(res);
        }
    }
}
