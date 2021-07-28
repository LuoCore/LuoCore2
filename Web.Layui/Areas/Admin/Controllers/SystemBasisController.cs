using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Hosting;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class SystemBasisController : BaseAuthorizeController<IServices.ISystemBasisService>
    {
        protected override string _ACTIONUSERINFO => User.FindFirst("UserDataInfo").Value;

        protected override string _ACTIONUSERNAME => User.Identity.Name;

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

        public async Task<IActionResult> CreateLinkAsync(ViewModels.SystemBasis.Request.RequestLinkCreateVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.CreateLink(req);
            return Json(res);
        }

        public async Task<IActionResult> UpdateLinkAsync(ViewModels.SystemBasis.Request.RequestLinkUpdateVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.UpdateLink(req);
            return Json(res);
        }

        public async Task<IActionResult> DeleteLinkAsync(ViewModels.SystemBasis.Request.RequestLinkDeleteVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.DeleteLink(req);
            return Json(res);
        }


        public IActionResult SystemLanguage()
        {
            return View();
        }

        public IActionResult SystemLanguageDialog()
        {
            return View();
        }

        public IActionResult GetLanguageJsonToDateTableAsync(string jsonValue)
        {
            ViewModels.Layui.TableVm resTable = new ViewModels.Layui.TableVm();
            List<ViewModels.SystemBasis.Response.ResponseLanguageTableVm> result = jsonValue.ToObject<List<ViewModels.SystemBasis.Response.ResponseLanguageTableVm>>();
            resTable.code = 0;
            if (result != null)
            {
               
                resTable.count = result.Count;
                resTable.data = result;
            }
          


            return Json(resTable);
        }

        public async Task<IActionResult> GetLanguagePageAsync(ViewModels.SystemBasis.Request.RequestLanguageQueryPageVm req)
        {
            var res = await _SERVICE.QueryLanguagePage(req);
            return Json(res);
        }


        public async Task<IActionResult> CreateLanguageAsync(ViewModels.SystemBasis.Request.RequestLanguageCreateVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.CreateLanguage(req);
            return Json(res);
        }

        public async Task<IActionResult> UpdateLanguageAsync(ViewModels.SystemBasis.Request.RequestLanguageUpdateVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.UpdateLanguage(req);
            return Json(res);
        }

        public async Task<IActionResult> DeleteLanguageAsync(ViewModels.SystemBasis.Request.RequestLanguageDeleteVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.DeleteLanguage(req);
            return Json(res);
        }

        public IActionResult BulletinIndex() 
        {
            return View();
        }
        public IActionResult BulletinDialog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImageAsync([FromServices] IWebHostEnvironment environment)
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


        public async Task<IActionResult> GetBulletinPageAsync(ViewModels.SystemBasis.Request.RequestBulletinQueryPageVm req)
        {
            var res = await _SERVICE.QueryBulletinPage(req);
            return Json(res);
        }


        public async Task<IActionResult> CreateBulletinAsync(ViewModels.SystemBasis.Request.RequestBulletinCreateVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.CreateBulletin(req);
            return Json(res);
        }

        public async Task<IActionResult> UpdateBulletinAsync(ViewModels.SystemBasis.Request.RequestBulletinUpdateVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.UpdateBulletin(req);
            return Json(res);
        }

        public async Task<IActionResult> DeleteBulletinAsync(ViewModels.SystemBasis.Request.RequestBulletinDeleteVm req)
        {
            req.ActionUserInfo = this._ACTIONUSERINFO;
            req.ActionUserName = this._ACTIONUSERNAME;
            var res = await _SERVICE.DeleteBulletin(req);
            return Json(res);
        }
    }
}
