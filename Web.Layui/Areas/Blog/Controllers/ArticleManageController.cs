using IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Blog.Controllers
{
     public class ArticleManageController : BaseController<IServices.IBlogService>
     {
          protected override string _ACTIONUSERINFO { get => User.FindFirst("UserDataInfo").Value; }
          protected override string _ACTIONUSERNAME { get => User.Identity.Name; }

          public ArticleManageController(IBlogService service) : base(service)
          {


          }

          public IActionResult ArticleIndex()
          {
               return View();
          }

          public async Task<IActionResult> GetArticleTableAsync(ViewModels.Blog.Request.RequestQueryArticleVm req)
          {
               var res = await _SERVICE.QueryBlogArticlePage(req);
               return Json(res);
          }
          public IActionResult ArticleDialog()
          {
               return View();
          }

          public async Task<IActionResult> GetBlogLabelsSelectBox(ViewModels.Blog.Request.RequestQueryBlogLabelsSelectBox req)
          {
               var res = await _SERVICE.QueryBlogLabelsSelectBox(req);
               return Json(res);
          }

          [HttpPost]
          public async Task<IActionResult> UploadImage([FromServices] IWebHostEnvironment environment)
          {

               ViewModels.WangEditor.ResponseUpLoadImageVm res = new ViewModels.WangEditor.ResponseUpLoadImageVm();
               res.Data = new List<ViewModels.WangEditor.ResponseUpLoadImageVm.ImageData>();
               var files = Request.Form.Files;

               string webRootPath = environment.WebRootPath;
               string contentRootPath = environment.ContentRootPath;

               foreach (var formFile in files)
               {
                    if (formFile.Length > 0)
                    {


                         string strImg = await Utility.ImageHelper.UpLoadImage(webRootPath, formFile);
                         if (!string.IsNullOrWhiteSpace(strImg))
                         {
                              res.Data.Add(new ViewModels.WangEditor.ResponseUpLoadImageVm.ImageData() { Url = Request.Scheme + "://" + Request.Host.Value + "//" + strImg });
                         }
                    }
               }
               res.Errno = 0;
               return new JsonResult(res);
          }

          public async Task<IActionResult> CreateArticleAsync(ViewModels.Blog.Request.RequestCreateBlogArticleVm req)
          {
               req.ActionUserName = this._ACTIONUSERNAME;
               req.ActionUserInfo = this._ACTIONUSERINFO;

               var res = await _SERVICE.CreateBlogArticle(req);
               return Json(res);
          }

          public async Task<IActionResult> UpdateArticleAsync(ViewModels.Blog.Request.RequestUpdateBlogArticleVm req)
          {
               req.ActionUserName = this._ACTIONUSERNAME;
               req.ActionUserInfo = this._ACTIONUSERINFO;
               var res = await _SERVICE.UpdateBlogArticle(req);
               return Json(res);
          }
          [HttpDelete]
          public async Task<IActionResult> DeleteArticleAsync(ViewModels.Blog.Request.RequestDeleteBlogArticleVm req)
          {
               req.ActionUserName = this._ACTIONUSERNAME;
               req.ActionUserInfo = this._ACTIONUSERINFO;
               var res = await _SERVICE.DeleteBlogArticle(req);
               return Json(res);
          }
     }
}
