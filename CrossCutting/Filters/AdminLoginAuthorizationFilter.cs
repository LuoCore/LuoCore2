using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossCutting.Filters
{
    public class AdminLoginAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AdminLoginAuthorizationFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                System.Security.Claims.ClaimsIdentity claimsIdentity = (System.Security.Claims.ClaimsIdentity)context.HttpContext.User.Identity;
                if (Equals(null, claimsIdentity) || !claimsIdentity.IsAuthenticated || Equals(null, claimsIdentity.Claims) || claimsIdentity.Claims.Count() < 1) 
                {
                    ContentResult Content = new ContentResult();
                    Content.Content = "<script type='text/javascript'>parent.window.location.href='/Admin/User/Login'</script>";
                    Content.ContentType = "text/html";
                    //截断请求
                    context.Result = Content;
                }
            }
            catch (Exception)
            {

                ContentResult Content = new ContentResult();
                Content.Content = "<script type='text/javascript'>parent.window.location.href='/Admin/User/Login'</script>";
                Content.ContentType = "text/html";
                //截断请求
                context.Result = Content;
            }
        }
    }
}
