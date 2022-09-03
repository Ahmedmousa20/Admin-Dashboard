using Demo.BL.Helper;
using Demo.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailVM model)
        {
            TempData["Msg"] = MailSender.SendMail(model);
            return View();
        }


    }
}
