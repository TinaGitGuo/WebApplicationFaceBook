using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplicationMVC01.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public HttpPostedFileBase Image { get; set; }
       
        public decimal Price { get; set; }

        

        //public ProductViewModel(int Id,string name,string OutputImage, decimal Price )
        //{
        //    this.Id = Id;
        //    this.Name = name;
        //    this.Price = Price;

        //    this.OutputImage = OutputImage;           
        //}
        public string OutputImage { get; set; }

        //public string OutputImage
        //{
        //    get
        //    {
        //        return string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(OutputImage)));
        //    }
        //    set
        //    {
        //        this.OutputImage = value  ;
        //    }
        //}
        //public string

        //// ViewModel => Model | Implicit type Operator
        public static explicit operator ProductViewModel(Product model)
        {
            var viewModel = new ProductViewModel
            {
                Id = model.Id,
                Name = model.Name,
                OutputImage = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(model.Image)),
                Price = model.Price
            };

            return viewModel;
        }
     }
}