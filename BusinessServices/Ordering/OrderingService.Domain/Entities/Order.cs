using ServiceCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderingService.Domain.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        [Required]
        public string OrderCode { get; set; }
        [Required]
        public string OrderName { get; set; }

    }
}
