using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class WebSiteController : Controller
    {
        public IActionResult MenuIndex()
        {
            return View();
        }
    }
}
