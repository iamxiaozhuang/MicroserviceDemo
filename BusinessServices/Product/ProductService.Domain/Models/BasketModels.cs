using ServiceCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Domain.Models
{
    public class CreateOrderModel : BaseModel
    {
        public string ProductCode { get; set; }
    }

    public class CreateOrderCapMessage : BaseCapMessage
    {
        public string OrderNO { get; set; }
        public string ProductCode { get; set; }
    }
}
