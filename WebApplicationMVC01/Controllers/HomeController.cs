using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVC01.Controllers
{
    public class HomeController : Controller
    {
        //public class Car
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }

        //    public static List<Car> GetCars()
        //    {
        //        return new List<Car>{
        //        new Car{Id=1, Name="Volvo"         },
        //        new Car{Id=2, Name="Mercedes-Benz"  },
        //        new Car{Id=3, Name="Saab"          },
        //        new Car{Id=4, Name="Audi"         },
        //        new Car{Id=5, Name="Audi"          }
        //        };
        //    }
        //}
        public class BookMaster
        {
            public string strBookTypeId { get; set; }
            public string strAccessionId { get; set; }
            public string PublisherId { get; set; }
            public  virtual Publisher Publisherr {get;set;}
            public  SelectList  Publishers { get; set; }
        }
        public static List<Publisher> GetPublishers()
        {
            return new List<Publisher>{
                new Publisher{PublisherId="1", PublisherName="Volvo"         },
                new Publisher{PublisherId="2", PublisherName="Mercedes-Benz"  },
                new Publisher{PublisherId="3", PublisherName="Saab"          },
                new Publisher{PublisherId="4", PublisherName="Audi"         },
                new Publisher{PublisherId="5", PublisherName="Audi2"          }
                };
        }
        public class Publisher
        {
            public string PublisherId { get; set; }
            public string PublisherName { get; set; }
            public DateTime PublishingYear { get; set; }        
        }  


        public class BookMaster2
        {
            public string strBookTypeId { get; set; }
            public string strAccessionId { get; set; }
            public string PublisherId { get; set; }
             public List<SelectListItem> Publishers { get; set; }
        }       
        public static List<SelectListItem> GetSelectListItems(List<Publisher> Publishers)
        {
            List<SelectListItem> products =Publishers.Select( x=>   new SelectListItem() { Text = x.PublisherId, Value = x.PublisherName }).ToList()  ;
            //List<SelectListItem> listPublisher=new List<SelectListItem>();

            //foreach (Publisher publisher in Publishers )
            //{
            //    listPublisher.Add(new SelectListItem() { Text = publisher.PublisherName, Value = publisher.PublisherId });
            //}
            return Publishers.Select(x => new SelectListItem() { Text = x.PublisherName, Value = x.PublisherId }).ToList();
        }
        //public class CarViewModel
        //{
        //    public string Car { get; set; }

        //    public List<SelectListItem> Cars { get; } = GetSelectListItems();
        //}
        public  ActionResult About()
        {
            //ViewBag.CarsList = GetSelectListItems();//the first Demo

            var model = new BookMaster();//the third Demo
            model.Publishers =new SelectList( GetPublishers(), "PublisherId", "PublisherName", 2); //the second Demo
            model.PublisherId = "2";
            ViewBag.Message = "Your application description page.";
            return View(model);
        }
        //public ActionResult Index()
        //{

        //    return View();
        //}

        public ActionResult Contact()
        {
            var model2 = new BookMaster2();//the third Demo
            model2.Publishers = GetSelectListItems(GetPublishers());//the second Demo
            model2.PublisherId = "2";
            ViewBag.Message = "Your contact page.";

            return View(model2);
        }

    }
}