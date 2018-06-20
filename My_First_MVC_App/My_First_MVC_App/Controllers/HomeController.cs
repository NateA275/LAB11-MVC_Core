using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_First_MVC_App.Models;

namespace My_First_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string name, int number)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Results", new { begYear, endYear });
        }

        public IActionResult Results(int begYear, int endYear)
        {
            Recipient recipients = new Recipient();

            return View(recipients.RetrieveRecipients(begYear, endYear));
        }


    }
}
