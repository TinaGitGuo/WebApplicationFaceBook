using System;
using System.IO;

namespace WebApplicationMVC01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
 
        public static explicit operator Product(ProductViewModel model)
        {
            var model2 = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Image = ConvertToByte(model),
                Price = model.Price
            };
            return model2;
        }
        public static byte[] ConvertToByte(ProductViewModel model)
        {
            if (model.Image != null)
            {
                byte[] imageByte = null;
                BinaryReader rdr = new BinaryReader(model.Image.InputStream);
                imageByte = rdr.ReadBytes((int)model.Image.ContentLength);

                return imageByte;
            }

            return null;
        }
    }
}