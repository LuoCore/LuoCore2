using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Layui.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUsIndex()
        {
            return View();
        }

        public IActionResult ContactUS() 
        {
            return View();
        }
    }
}
