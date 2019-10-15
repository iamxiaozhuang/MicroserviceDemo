using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CommonLibrary;

namespace ProductService.Domain
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryCode { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
       
    }
}
