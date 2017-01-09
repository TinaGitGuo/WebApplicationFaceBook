using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Microsoft.Azure.Devices.Client.Common;
//using System.Security.Cryptography;
namespace ClassLibrary18
{
    public class Program
    {
        public static void Main()
        {
           
             //Microsoft.Azure.Devices.Client a;              Microsoft.Azure.Devices.Client.DeviceAuthenticationWithX509Certificate
            // Create a new PDF document
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
            
            // Create an empty page
            PdfSharp.Pdf.PdfPage page = document.AddPage();
           
        }
        private static void CreateThumbnailImage()
        { System.Drawing.Image a;
            Microsoft.AspNetCore.Mvc.ActionContext b;
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string thumbPath = Path.Combine(imagePath, "Thumb");

            if (Directory.Exists(thumbPath))
            {
                DeleteExistFiles(thumbPath);
            }
            Directory.CreateDirectory(thumbPath);

            foreach (string fileName in Directory.GetFiles(imagePath, "*.jpg"))
            {
                Image originalImage = Image.FromFile(fileName);
                Image thumbImage = originalImage.GetThumbnailImage(160, 120, null, IntPtr.Zero);

                string thumbFileName = "Thumb_" + Path.GetFileName(fileName);
                thumbImage.Save(Path.Combine(thumbPath, thumbFileName));
            }
        }

        private static void DeleteExistFiles(string dir)
        {
            foreach (string fileName in Directory.GetFiles(dir))
            {
                File.Delete(fileName);
            }
            Directory.Delete(dir);
        }
    }
}
