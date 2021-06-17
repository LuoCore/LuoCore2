using Common;
using CrossCutting.Filters;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.SystemBasis.Request;

namespace Web.Layui.Areas.Admin.Controllers
{

    [TypeFilter(typeof(AdminLoginAuthorizationFilter))]
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
            ViewModels.Layui.SelectBoxVm selectbox = new ViewModels.Layui.SelectBoxVm() { Name = "顶级", value = "" };
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
        [HttpPost]
        public async Task<IActionResult> PermissionCreateAsync(ViewModels.SystemBasis.Request.RequestAddPermissionVm req)
        {

            req.UserInfo = User.FindFirst("UserDataInfo").Value;
            req.UserName = User.Identity.Name;
            ResultVm res = await _SERVICE.AddPermission(req);
            return Json(res);
        }
        [HttpPut]
        public async Task<IActionResult> PermissionUpdateByIdAsync(ViewModels.SystemBasis.Request.RequestUpdatePermissionVm req)
        {
            req.UserInfo = User.FindFirst("UserDataInfo").Value;
            req.UserName = User.Identity.Name;
            ResultVm res = await _SERVICE.UpdatePermissionById(req);
            return Json(res);
        }

        [HttpDelete]
        public async Task<IActionResult> PermissionDeleteByIdsAsync(ViewModels.SystemBasis.Request.RequestDeletePermissionVm req)
        {
            req.UserInfo = User.FindFirst("UserDataInfo").Value;
            req.UserName = User.Identity.Name;
            ResultVm res = await _SERVICE.DeletePermissionByIds(req);
            return Json(res);
        }

        public IActionResult Role()
        {
            return View();
        }

        public async Task<IActionResult> RoleTableAsync(ViewModels.SystemBasis.Request.RequestGetRoleVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            res = await _SERVICE.GetRoleTable(req);
            return Json(res);
        }


        public IActionResult RoleDialog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RequestAddRoleVm req)
        {
            req.UserInfo = User.FindFirst("UserDataInfo").Value;
            req.UserName = User.Identity.Name;
            ResultVm res = await _SERVICE.AddRole(req);
            return Json(res);
        }

        public IActionResult RolePermissionDialog() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RolePermissionCreate(RequestAddRolePermissionVm req)
        {
            req.UserInfo = User.FindFirst("UserDataInfo").Value;
            req.UserName = User.Identity.Name;
            ResultVm res = await _SERVICE.AddRolePermission(req);
            return Json(res);
        }


        public async Task<IActionResult> PermissionTreeAsync(string userId)
        {
            List<ViewModels.Layui.TreeVm> res = new List<ViewModels.Layui.TreeVm>();
            ViewModels.Layui.TreeVm treeData = new ViewModels.Layui.TreeVm() { title = "顶级", id = "" };
            var result = await _SERVICE.GetPermissionTreeBoxAsync("");
            if (result.Status && !Equals(null, result.Data))
            {
                treeData.children = result.Data;
            }
            res.Add(treeData);
            return Json(res);
        }
    }
}
