
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
        protected override string _ACTIONUSERINFO => User.FindFirst("UserDataInfo").Value;

        protected override string _ACTIONUSERNAME => User.Identity.Name;

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
        public async Task<IActionResult> GetLabelsPageAsync(ViewModels.Blog.Request.RequestQueryBlogLabelPageVm req)
        {
            var res = await _SERVICE.QueryBlogLabelsPage(req);
            return Json(res);
        }
        
        public async Task<IActionResult> CreateLabelsAsync(ViewModels.Blog.Request.RequestCreateBlogLabelVm req)
        {
            req.ActionUserName = this._ACTIONUSERNAME;
            req.ActionUserInfo = this._ACTIONUSERINFO;
            var res = await _SERVICE.CreateBlogLabels(req);
            return Json(res);
        }
        public async Task<IActionResult> UpdateLabelsAsync(ViewModels.Blog.Request.RequestUpdateBlogLabelVm req)
        {
            req.ActionUserName = this._ACTIONUSERNAME;
            req.ActionUserInfo = this._ACTIONUSERINFO;
            var res = await _SERVICE.UpdateBlogLabels(req);
            return Json(res);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLabelsAsync(string[] ids)
        {
            var res = await _SERVICE.DeleteBlogLabels(ids, this._ACTIONUSERNAME, this._ACTIONUSERINFO);
            return Json(res);
        }
    }
}
