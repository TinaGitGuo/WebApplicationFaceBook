using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVCCore.Controllers
{
    public class HomeController : Controller
    {
        WebApplicationMVCCore14.Data.ApplicationDbContext db;
        public IActionResult Index()
        {



            return View();
        }

        public IActionResult About()
        {
            var c = from b in db.Students.AsEnumerable() select b;

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
