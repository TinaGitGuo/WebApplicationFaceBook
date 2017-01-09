using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft​.Azure​.Devices​.Shared;
 
namespace WebApplicationno.Controllers
{
    public class HomeController : Controller
    {
        WebApplicationwithidenty.Data.ApplicationDbContext db;
        public IActionResult Index()
        {
            //            var base64 = Convert.ToBase64String(item.BusLogo);
            //            var imagesrc = string.Format("data:image/png;base64,{0}", base64);
            //< img src = '@imagesrc' style = "max-width:100px;max-height:100px" />

            #region MyRegion
            //File(new System.IO.MemoryStream(Convert.ToByte("hello world ")), "application/pdf", "filename.pdf")
            #endregion

            //F:\Publish\WebApplicationFaceBook\src\WebApplicationno\wwwroot\images\1ad6d6d772966fc112a68096dee8a315.png
            byte[] a = { 1,3,5};
            byte[] b = { 2, 6, 7 };
           byte[] c= Microsoft.Azure.Devices.Client.SHA.computeHMAC_SHA256(a,b);
           string path =   FileStrem.GetFilePath("wwwroot/images/1ad6d6d772966fc112a68096dee8a315.png");
           byte[] imagebyte= LoadImage.GetPictureData(path);
            ViewBag.imagebyte = imagebyte;
           var base64 = Convert.ToBase64String(imagebyte);           
           ViewBag.imagesrc = string.Format("data:image/png;base64,{0}", base64);
            ViewBag.imagelegth = base64.Length;
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
