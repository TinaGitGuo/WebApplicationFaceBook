using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCCore注入16.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using iTextSharp.LGPLv2;
using iTextSharp.text;
using System.IO;
using System.Data;

using System.Drawing;
namespace WebApplicationMVCCore注入16.Controllers
{
    public class HomeController : Controller
    {

        public readonly INotifier _INotifier;
        public readonly ISMSNotifier _ISMSNotifier;
        public HomeController(INotifier iNotifier, ISMSNotifier iSMSNotifier)
        {
            _INotifier = iNotifier;
            _ISMSNotifier = iSMSNotifier;
        }
        public IActionResult Index()
        {
            var Configurations = Startup.Configuration;
            string str = Configurations["YOU"];
            return View();
        }
        public class Car
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public static List<Car> GetCars()
            {
                    return new List<Car>{
                new Car{Id=1, Name="Volvo", Category="Swedish Cars"},
                new Car{Id=2, Name="Mercedes-Benz", Category="German Cars"},
                new Car{Id=3, Name="Saab", Category="Swedish Cars"},
                new Car{Id=4, Name="Audi", Category="German Cars"},
                new Car{Id=5, Name="Audi", Category="German Cars"}
                };
            }
        }
        public static List<SelectListItem> GetSelectListItems()
        {
            SelectListGroup slgroup1 = new SelectListGroup() { Name = "German Cars" };
            SelectListGroup slgroup2 = new SelectListGroup() { Name = "Swedish Cars" };
            return new List<SelectListItem>() {
                new SelectListItem() { Group=slgroup1, Text="Volvo",Value ="1" },
                new SelectListItem() { Group=slgroup1, Text="Mercedes-Benz",Value ="2" },
                new SelectListItem() { Group=slgroup2, Text="Saab",Value ="3" },
                 new SelectListItem() { Group=slgroup2, Text="Audi",Value ="4" }
            };
        }
        public class CarViewModel
        {
            public string Car { get; set; }

            public List<SelectListItem> Cars { get; } = GetSelectListItems();
        }
        public IActionResult About()
        {
            ViewBag.CarsList = GetSelectListItems();//the first Demo
            ViewBag.CarsList2 = new SelectList(Car.GetCars(), "Id", "Name", 1, "Category"); //the second Demo
            var model = new CarViewModel();//the third Demo
            model.Car = "3";
            return View(model);
        }

        public IActionResult Contact()
        {
            System.Drawing.Image c;
            Bitmap d;

            Document document = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("Chap0101.pdf", FileMode.Create));
            document.Open();
            document.Add(new Paragraph("Hello World"));
            document.Close();
            ViewData["Message"] = "Your contact page.";
             
            DataTable a;
            //a.AsEnumerable();
            //ImageProcessorCore.Image d;
            //d.
            
            return View();
        }
     
        public IActionResult Error()
        {
            return View();
        }
    }
}
