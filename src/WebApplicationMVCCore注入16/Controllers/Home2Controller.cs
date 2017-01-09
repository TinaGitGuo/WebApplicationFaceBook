using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationMVCCore注入16.Controllers
{
    public class Home2Controller : Controller
    {
        public string ErrMessage;
        public Image ResourceImage;
        public bool ThumbnailCallback()
        {
            return false;
        }

        public Image GetReducedImage(int Width, int Height)
        {
            try
            {
                Image ReducedImage;

                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);

                return ReducedImage;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return null;
            }
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public class student
        {
              public int MyProperty { get; set; }
        }
      public void c()
        {
    //        String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
    //"Data Source=" + Microsoft.AspNetCore.Server.MapPath("../ExcelData.xls") + ";" +
    //"Extended Properties=Excel 8.0;";

    //        // Create connection object by using the preceding connection string.
    //        OleDbConnection objConn = new OleDbConnection(sConnectionString);

    //        // Open connection with the database.
    //        objConn.Open();

    //        // The code to follow uses a SQL SELECT command to display the data from the worksheet.

    //        // Create new OleDbCommand to return data from worksheet.
    //        OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM myRange1", objConn);

    //        // Create new OleDbDataAdapter that is used to build a DataSet
    //        // based on the preceding SQL SELECT statement.
    //        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

    //        // Pass the Select command to the adapter.
    //        objAdapter1.SelectCommand = objCmdSelect;

    //        // Create new DataSet to hold information from the worksheet.
    //        DataSet objDataset1 = new DataSet();

    //        // Fill the DataSet with the information from the worksheet.
    //        objAdapter1.Fill(objDataset1, "XLData");
        }
        public void DisplayProducts(DataTable table)
        {

            student stu;
            Microsoft.EntityFrameworkCore.DbSet<student> j;
            



             DbDataRecord d=  table;
            d.as
            // table
            Enumerable.AsEnumerable<student>(stu);
            //var productNames = from products in table.AsEnumerable() select products.Field<string>("ProductName");
            //Console.WriteLine("Product Names: ");
            //foreach (string productName in productNames)
            //{
            //    Console.WriteLine(productName);
            //}
        }
    }
}
