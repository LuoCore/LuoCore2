using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Blog.Controllers
{
    public class LabelsManageController : BaseController<IServices.IBlogService>
    {
        public LabelsManageController(IBlogService service) : base(service)
        {
        }

        public IActionResult LabelsIndex()
        {
            return View();
        }

        public IActionResult LabelsDialog()
        {
            return View();
        }

        public async Task<IActionResult> CreateLabelsAsync(ViewModels.Blog.Request.RequestCreateBlogLabelVm req)
        {
            req.ActionUserName = this._ACTIONUSERNAME;
            req.ActionUserInfo = this._ACTIONUSERINFO;
            var res = await _SERVICE.CreateBlogLabels(req);
            return Json(res);
        }
    }
}
