using CommonLibrary.Enities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductService.Domain
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductAmount { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public List<Attachment> ProductPictures { get; set; }

        public string ProductProfile { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
