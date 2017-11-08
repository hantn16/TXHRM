using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TXHRM.Common.Exceptions
{
    public class NameDuplicatedException : Exception
    {
        public NameDuplicatedException()
        {
        }

        public NameDuplicatedException(string message) : base(message)
        {
        }

        public NameDuplicatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameDuplicatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
