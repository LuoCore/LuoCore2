using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Blog.Controllers
{
    public class ArticleManageController : BaseController<IServices.IBlogService>
    {
        public ArticleManageController(IBlogService service) : base(service)
        {
        }

        public IActionResult ArticleIndex()
        {
            return View();
        }

        public async Task<IActionResult> GetArticleTableAsync(ViewModels.Blog.Request.RequestQueryArticleVm req)
        {
            var res= await _SERVICE.QueryBlogArticlePage(req);
            return Json(res);
        }
        public IActionResult ArticleDialog()
        {
            return View();
        }
    }
}
