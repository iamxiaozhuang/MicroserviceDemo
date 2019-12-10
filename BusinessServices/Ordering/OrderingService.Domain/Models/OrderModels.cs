using ServiceCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingService.Domain.Models
{
    public class AddOrderModel : BaseModel
    {
        public string ProductCode { get; set; }
    }
}
