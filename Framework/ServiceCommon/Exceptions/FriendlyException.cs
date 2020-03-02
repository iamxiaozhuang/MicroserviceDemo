using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCommon
{
    public class FriendlyException : ApplicationException
    {
        public FriendlyException(int exceptionCode)
        {
            ExceptionCode = exceptionCode;
        }
        public FriendlyException(int exceptionCode, string exceptionMessage)
            : base(exceptionMessage)
        {
            ExceptionCode = exceptionCode;
            ExceptionMessage = exceptionMessage;
        }
        public int ExceptionCode { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
