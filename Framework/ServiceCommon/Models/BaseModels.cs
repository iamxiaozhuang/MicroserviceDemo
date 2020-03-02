using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCommon.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }
    }


    public class QueryModel<T>
    {
        public T QueryEntity { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

    }
    public enum ReturnStatus
    {
        Success = 1,
        Fail = 0,
        ConfirmIsContinue = 2,
        Error = 3
    }

    public class ListModel<T>
    {
        public List<T> ListEntity { set; get; }
        public int TotalRecotrdCount { get; set; }

    }

   

}
