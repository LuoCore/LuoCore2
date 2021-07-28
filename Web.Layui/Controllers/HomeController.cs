using CrossCutting.Filters;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Layui.Models;

namespace Web.Layui.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISystemBasisService _SystemService;

        public HomeController(ILogger<HomeController> logger, ISystemBasisService SystemService)
        {
            _logger = logger;
            _SystemService = SystemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BulletinIndex(int bulletinId)
        {
            var result =  _SystemService.QueryBulletinList(new ViewModels.SystemBasis.Request.RequestBulletinQueryVm() { ID = bulletinId });
            return View(result.Result);
        }
        [CustomerAuthorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
