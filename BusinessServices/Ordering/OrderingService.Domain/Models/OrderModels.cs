using ServiceCommon;
using ServiceCommon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingService.Domain.Models
{
    public class AddOrderModel : BaseModel
    {
        public string OrderNO { get; set; }
        public string ProductCode { get; set; }
    }
}
