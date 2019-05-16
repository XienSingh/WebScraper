using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScraper.Models;
using WebScraper.ScraperLogic;

namespace WebScraper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           var valueR =  WebScraper.ScraperLogic.WebScraper.Scrape("http://www.ix.co.za","HeadScript");
            ViewBag.DOMreturned = valueR;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

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
