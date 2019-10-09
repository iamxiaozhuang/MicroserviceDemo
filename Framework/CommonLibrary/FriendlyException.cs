using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class FriendlyException : Exception
    {
        public int ExceptionCode { get; set; }
        private int httpStatusCode;
        public int HttpStatusCode
        {
            get
            {
                if (ExceptionCode != 0)
                    return ExceptionCode;
                else
                    return httpStatusCode;
            }
            set
            {
                httpStatusCode = value;
            }
        }
        public string ExceptionMessage { get; set; }

    }
}
