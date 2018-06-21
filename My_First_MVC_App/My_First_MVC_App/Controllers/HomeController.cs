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

        /// <summary>
        /// Index - Retruns the default IActionResult View
        /// </summary>
        /// <returns> IActionResult - Index.cshtml </returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Index - Retrieves beginning year and end year from index page
        /// </summary>
        /// <param name="begYear"> int - User's entered value in beginning year box </param>
        /// <param name="endYear"> int - User's entered value in ending year box </param>
        /// <returns>IActionResult - Results Page</returns>
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Results", new { begYear, endYear });
        }


        /// <summary>
        /// Results - Handle's Index redirection
        /// </summary>
        /// <param name="begYear"> int - User's entered value in beginning year box </param>
        /// <param name="endYear"> int - User's entered value in ending year box </param>
        /// <returns>IActionReuslt - Results View </returns>
        public IActionResult Results(int begYear, int endYear)
        {
            Recipient recipients = new Recipient();

            return View(recipients.RetrieveRecipients(begYear, endYear));
        }


    }
}
