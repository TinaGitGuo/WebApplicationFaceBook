using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            {
                System.Drawing.Image a;
                Microsoft.AspNetCore.Mvc.ActionContext b;
                CreateThumbnailImage();
            }Console.WriteLine("dd");
            Console.ReadLine();

        }
        private static void CreateThumbnailImage()
        {
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
