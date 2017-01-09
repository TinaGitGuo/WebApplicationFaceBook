using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationwithidenty.Controllers
{
    public class HomeController : Controller
    {
        Data.ApplicationDbContext db;
        public HomeController(Data.ApplicationDbContext Db)
        {
            db = Db;
        }
       
        public IActionResult Index()
        {
            IEnumerable<Models.Students> c = from b in db.Students.AsEnumerable() select b;
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
