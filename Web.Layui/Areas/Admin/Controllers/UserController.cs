
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModels.Request.User;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
       
        

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public IActionResult ValidateCode()
        {
            var verifCode = new Utility.VerificationCode(4, Utility.VerificationCode.CodeType.数字);
            HttpContext.Session.SetString("SecurityCode", verifCode.CheckCode);
            return File(verifCode.CreateCheckCodeByteArray(), "image/" + System.Drawing.Imaging.ImageFormat.Gif.ToString());
        }



        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginVm req)
        {

            req.VerifiCode = HttpContext.Session.GetString("SecurityCode");
            var result = await _SERVICE.Login(req);

            if (result == null || !result.Status || result.Data == null)
            {
                return Json(new { status = false, msg = result.Messages });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, result.Data.UserId),
                new Claim(ClaimTypes.Name, result.Data.UserName),
                new Claim("UserDataInfo", result.Data.ToJson()),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //应该允许刷新身份验证会话。
                AllowRefresh = false,
                //认证票据过期的时间。
                // 一个value将覆盖ExpireTimeSpan选项
                //CookieAuthenticationOptions设置AddCookie。
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                //身份验证会话是否持久化
                // 多个请求。当与cookie、控件一起使用时
                //是否cookie的生存期是绝对的(匹配
                //认证票据的生命周期)或基于会话的。
                IsPersistent = false,
                //颁发身份验证票据的时间。
                IssuedUtc = DateTimeOffset.UtcNow,
                //作为http的完整路径或绝对URI
                //重定向响应值。
                RedirectUri = "/Admin/User/Login"
            };
            await HttpContext.SignInAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);



            return Json(new { status = true, msg = "登录成功！" });

        }






    }
}
