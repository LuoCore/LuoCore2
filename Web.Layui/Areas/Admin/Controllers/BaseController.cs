using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Admin.Controllers
{

    [Area("Admin")]
    public abstract class BaseController : Controller
    {
        protected readonly dynamic _SERVICE;

        public BaseController(dynamic service)
        {
            _SERVICE = service;
        }
        public BaseController()
        {
          
        }

    }

    [Area("Admin")]
    public abstract class BaseController<T> : Controller
    {
        protected readonly T _SERVICE;
       
        public BaseController(T service)
        {
            _SERVICE = service;
        }

    }

}
