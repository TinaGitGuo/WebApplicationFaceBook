using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
namespace WebApplicationMVC.Controllers
{
    public class student
    {
        public int studentid { get; set; }
    }
    public class HomeController : Controller
    {
       
        public void DisplayProducts(System.Data.DataTable table)
        {
            System.Data.DataSet b;

           
            var productNames = from products in table.AsEnumerable() select products.Field<string>("ProductName");
            Console.WriteLine("Product Names: ");
            foreach (string productName in productNames)
            {
                Console.WriteLine(productName);
            }
           
        }

        public ActionResult Index()
        {
            System.Data.DataTable a;
            
            return View();
        }
      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}