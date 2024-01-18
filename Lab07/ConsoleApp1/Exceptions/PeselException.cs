using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    public class PeselException : Exception
    {
        public PeselException()
        {
        }

        public PeselException(string? message) : base(message)
        {
        }

        public PeselException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PeselException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
