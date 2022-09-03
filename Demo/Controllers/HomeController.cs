using Demo.Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> localizer;

        public HomeController(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }
        public IActionResult Index()
        {
            ViewBag.Msg = localizer["DASHBOARD"];
            return View();
        }

    }
}
