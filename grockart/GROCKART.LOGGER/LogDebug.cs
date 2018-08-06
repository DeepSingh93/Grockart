using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.LOGGER
{
    [Serializable]
    public class LogDebug : Exception
    {
        public LogDebug()
        {
        }

        public LogDebug(string message) : base(message)
        {
        }

        public LogDebug(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LogDebug(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
