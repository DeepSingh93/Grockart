using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.LOGGER
{
    [Serializable]
    public class LogInfo : Exception
    {
        public LogInfo()
        {
        }

        public LogInfo(string message) : base(message)
        {
        }

        public LogInfo(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LogInfo(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
