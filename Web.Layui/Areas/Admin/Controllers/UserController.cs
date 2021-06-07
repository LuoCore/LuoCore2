
using Common;
using IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Utility;
using ViewModels.User.Request;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class UserController : BaseController<IUserServices>
    {
        public UserController(IUserServices service) : base(service)
        {
        }

        public IActionResult Login()
        {
            return View();
        }

        

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult LoginValidateCode()
        {
            var verifCode = new Utility.VerificationCode(4, Utility.VerificationCode.CodeType.数字);
            HttpContext.Session.SetString("LoginSecurityCode", verifCode.CheckCode);
            return File(verifCode.CreateCheckCodeByteArray(), "image/" + System.Drawing.Imaging.ImageFormat.Gif.ToString());
        }



        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(RequestUserLoginVm req)
        {

            req.SecurityCode = HttpContext.Session.GetString("LoginSecurityCode");
            var result = await _SERVICE.LoginUser(req);

            if (Equals(null, result)||Equals(null, result.Data))
            {
                return Json(result);
            }
            EntitysModels.Base_User user = result.Data;
            HttpContext.CookieAuthenticationUserIdentity(user.UserId, user.UserName, user.ToJson(), "");
            return Json(result);
        }


        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult RegisterValidateCode()
        {
            var verifCode = new Utility.VerificationCode(4, Utility.VerificationCode.CodeType.数字);
            HttpContext.Session.SetString("RegisterSecurityCode", verifCode.CheckCode);
            return File(verifCode.CreateCheckCodeByteArray(), "image/" + System.Drawing.Imaging.ImageFormat.Gif.ToString());
        }
        /// <summary>
        /// User.FindFirst
        ///AuthenticateResult authInfo = await HttpContext.AuthenticateAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
        ///req.CreateName = authInfo.Principal.FindFirstValue(ClaimTypes.Name);
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RequestRegisteredUserVm req)
        {
            req.CreateName = Environment.UserName;
            req.SecurityCode = HttpContext.Session.GetString("RegisterSecurityCode");
            var res= await _SERVICE.RegisteredUser(req);
          
            return Json(res);
        }



    }
}
