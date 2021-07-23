using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Blog.Controllers
{
   
    [Area("Blog")]
    public abstract class BaseController : Controller
    {
        protected readonly dynamic _SERVICE;
        protected readonly string _ACTIONUSERINFO;
        protected readonly string _ACTIONUSERNAME;

        public BaseController(dynamic service)
        {
            _SERVICE = service;
            _ACTIONUSERINFO = User.FindFirst("UserDataInfo").Value;
            _ACTIONUSERNAME = User.Identity.Name;
        }
        public BaseController()
        {
          
        }

    }

    [Area("Blog")]
    public abstract class BaseController<T> : Controller
    {
        protected readonly T _SERVICE;
        protected abstract string _ACTIONUSERINFO {  get; }
        protected abstract string _ACTIONUSERNAME {  get; }

        public BaseController(T service)
        {
            _SERVICE = service;
           
        }

    }

}
