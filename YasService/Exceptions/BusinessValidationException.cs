using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YasService.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}