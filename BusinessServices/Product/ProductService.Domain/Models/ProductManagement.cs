using CommonLibrary.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductService.Domain.Models
{
    public class AddProductModel : BaseModel
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Product Code is required")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Amount is required")]
        public int ProductAmount { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        public decimal ProductPrice { get; set; }
        public List<Attachment> ProductPictures { get; set; }
        public string ProductProfile { get; set; }
        [Required(ErrorMessage = "ProductPrice Category is required")]
        public Guid CategoryId { get; set; }

        //[RegularExpression(@"^1[3|4|5|7|8][0-9]\d{8}$", ErrorMessage = "手机号格式错误")]
        //public string UserMobilePhone { get; set; }
    }
}
