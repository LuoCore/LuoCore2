using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Utility
{
    public static class CookieHelper
    {

        public static void CookieAuthenticationUserIdentity(this HttpContext httpContext,string nameIdentifier,string nameValue,string datainfoJson,string roleJson) 
        {
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Name, nameValue),
                new Claim("UserDataInfo", datainfoJson),
                new Claim(ClaimTypes.Role, roleJson),
            };

            var claimsIdentity = new ClaimsIdentity(claims, Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties
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
             httpContext.SignInAsync(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }


        /// <summary>
        /// 设置本地cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值  </param>
        /// <param name="minutes">过期时长，单位：分钟   </param>
        public static bool SetCookies(this HttpContext httpContext, string key, string value, int minutes = 30)
        {
            try
            {
                httpContext.Response.Cookies.Append(key, value, new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(minutes)
                });
                return true;
            }
            catch { return false; }
        }






        /// <summary>
        ///  删除指定的cookie
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool DeleteCookies(this HttpContext httpContext, string key)
        {
            try
            {
                httpContext.Response.Cookies.Delete(key);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetCookies(this HttpContext httpContext, string key)
        {
            httpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

    }
}
