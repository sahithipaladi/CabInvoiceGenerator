using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    class CabInvoiceException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME, NULL_RIDES, NULL_USER
        }

        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}

